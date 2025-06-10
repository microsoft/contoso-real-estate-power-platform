// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
// Note: Minimum Bicep version required to deploy this quickstart template is v0.29.45.
// See: https://learn.microsoft.com/en-us/graph/templates/?view=graph-bicep-1.0
extension 'br:mcr.microsoft.com/bicep/extensions/microsoftgraph/v1.0:0.1.9-preview'

targetScope = 'subscription'

// The main bicep module to provision Azure resources.
// For a more complete walkthrough to understand how this file works with azd,
// see https://learn.microsoft.com/en-us/azure/developer/azure-developer-cli/make-azd-compatible?pivots=azd-create

@minLength(1)
@maxLength(64)
@description('Name of the the environment which is used to generate a short unique hash used in all resources.')
param environmentName string

@minLength(1)
@description('Primary location for all resources')
param location string

@description('Id of the user to assign application roles')
param principalId string = ''

@description('The Login of the user to assign application roles')
param principalLoginName string

@description('The App Id of the Entra API client application. If empty, a new application will be created.')
param entraApiClientAppId string = ''
param entraApiClientObjectId string = ''

@secure()
param paymentsDatabaseAdminPassword string

// Overrides
param keyVaultName string = ''
param appServicePlanName string = ''
param storageAccountName string = ''
param applicationInsightsName string = ''
param logAnalyticsName string = ''
param apiServiceName string = ''

// Optional parameters to override the default azd resource naming conventions.
// Add the following to main.parameters.json to provide values:
// "resourceGroupName": {
//      "value": "myGroupName"
// }
param resourceGroupName string = ''
param appName string = 'cre'

var abbrs = loadJsonContent('./abbreviations.json')
var builtInRoles = loadJsonContent('./built-in-roles.json')

// tags that should be applied to all resources.
var tags = {
  // Tag all resources with the environment name.
  'azd-env-name': environmentName
  // Tag all resources with the application name.
  'azd-app-name': appName
}

// Generate a unique token to be used in naming resources.
// Remove linter suppression after using.
#disable-next-line no-unused-vars
var resourceToken = toLower(uniqueString(subscription().id, environmentName, location))
var resourcesPrefix = '${appName}-${resourceToken}-${environmentName}'


// Organize resources in a resource group
resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: !empty(resourceGroupName) ? resourceGroupName : '${abbrs.resourcesResourceGroups}${resourcesPrefix}'
  location: location
  tags: tags
}

// Store secrets in a keyvault
var keyValueName = !empty(keyVaultName) ? keyVaultName : '${abbrs.keyVaultVaults}${resourceToken}' // Max 24 characters length
module keyVault './payments-api/security/keyvault.bicep' = {
  name: 'keyvault'
  scope: rg
  params: {
    name: keyValueName
    location: location
    tags: tags
    enabledForDeployment: true
    enabledForTemplateDeployment: true
  }
}

// Call role.bicep to create a role assignment on the keyvault for the role 'Key Vault Secrets User' for Dataverse '00000007-0000-0000-c000-000000000000'
resource dataverseServicePrincipal 'Microsoft.Graph/servicePrincipals@v1.0' existing = {
  appId: '00000007-0000-0000-c000-000000000000' // Dataverse
} 

module dataverseKeyVaultAccess './payments-api/security/keyvault-role-assignment.bicep' = {
  name: 'role'
  scope: rg
  params: {
    keyVaultName: keyVault.outputs.name
    principalId: dataverseServicePrincipal.id // Dataverse
    roleDefinitionId: builtInRoles.KeyVaultSecretsUser
  }
}

// Call the api-application module to create the Entra ID API application.
module apiApplication './payments-api/security/api-application.bicep' = {
  name: 'apiApplication'
  scope: rg
  params: {
    name: 'Contoso Real Estate Payments API (${resourcesPrefix}-payments-api)'
    applicationUniqueName: '${resourcesPrefix}-payments-api'
    applicationClientUniqueName: '${resourcesPrefix}-payments-api-client'
    keyVaultName: keyVault.outputs.name
    // Set newOrExisting based on if entraApiClientAppId is empty or not
    existingAppClientApplicationId:entraApiClientAppId
    existingAppClientObjectId:entraApiClientObjectId
  }
}


module storageAccount './core/storage/storage-account.bicep' = {
  name: 'storage'
  scope: rg
  params: {
    name: !empty(storageAccountName) ? storageAccountName : '${abbrs.storageStorageAccounts}${resourceToken}'
    location: location
    tags: tags
    sku: {
      name: 'Standard_LRS'
      tier: 'Standard'
    }
    kind: 'Storage'
    defaultToOAuthAuthentication: true
    allowCrossTenantReplication: false
    allowBlobPublicAccess: false
    networkAcls: {
      bypass: 'AzureServices'
      defaultAction: 'Allow'
    }
    supportsHttpsTrafficOnly: true
    
  }
}

// Create an App Service Plan to group applications under the same payment plan and SKU
module appServicePlan './core/host/appserviceplan.bicep' = {
  name: 'appserviceplan'
  scope: rg
  params: {
    name: !empty(appServicePlanName) ? appServicePlanName : '${abbrs.webServerFarms}${resourceToken}'
    location: location
    tags: tags
    reserved:false
    kind: 'functionapp'
    sku: {
      name: 'Y1'
      tier: 'Dynamic'
      family: 'Y1'
      size: 'Y1'
      capacity: 0
    }
  }
}

module monitoring './core/monitor/monitoring.bicep' = {
  name: 'monitoring'
  scope: rg
  params: {
    location: location
    tags: tags
    applicationInsightsName: !empty(applicationInsightsName) ? applicationInsightsName : '${abbrs.insightsComponents}${resourceToken}'
    logAnalyticsName: !empty(logAnalyticsName) ? logAnalyticsName : '${abbrs.insightsComponents}logs-${resourceToken}'
  }
}




// The application backend
var apiServiceUniqueName = !empty(apiServiceName) ? apiServiceName : '${abbrs.webSitesAppService}payments-api-${resourceToken}'
module api './payments-api/payments-api.bicep' = {
  name: 'payments-api'
  scope: rg
  params: {
    name: apiServiceUniqueName
    location: location
    tags: union(tags, { 'azd-service-name': 'payments-api' })
    applicationInsightsName  : monitoring.outputs.applicationInsightsName
    storageAccountName: storageAccount.outputs.name
    appServicePlanName: appServicePlan.outputs.name
    keyVaultName: keyVault.outputs.name
    apiApplicationID: apiApplication.outputs.appId
    appClientKeyVaultSecretName: apiApplication.outputs.appClientKeyVaultSecretName
    }
  }

// Create Payments SQL server and database
module sqlServer './payments-api/database/sqlserver.bicep' = {
  name: 'sqlServer'
  scope: rg
  dependsOn: [
    // Needed to to be created so that the managed identity can be assigned to the SQL server. 
    // The reference to api.outputs below will create an implicit dependency. Explicit dependencies are added for clarity.
    api
    keyVault
  ]
  params: {
    applicationUniqueName: 'payments-api'
    serverName: '${resourcesPrefix}-sql'
    sqlDBName: '${resourcesPrefix}-payments-sql-db'
    location: location
    administratorLoginPassword: paymentsDatabaseAdminPassword
    principalId: principalId
    principalLoginName: principalLoginName
    keyVaultName: keyVault.outputs.name
    appManagedIdentityName: api.outputs.SERVICE_API_NAME
  }
} 
// Add outputs from the deployment here, if needed.
//
// This allows the outputs to be referenced by other bicep deployments in the deployment pipeline,
// or by the local machine as a way to reference created resources in Azure for local development.
// Secrets should not be added here.
//
// Outputs are automatically saved in the local azd environment .env file.
// To see these outputs, run `azd env get-values`,  or `azd env get-values --output json` for json output.
output AZURE_LOCATION string = location
output AZURE_TENANT_ID string = tenant().tenantId
output AZURE_RESOURCE_GROUP string = rg.name
output AZURE_RESOURCE_PREFIX string = resourcesPrefix
output ENTRA_API_APP_ID string = apiApplication.outputs.appId
output ENTRA_API_OBJECT_ID string = apiApplication.outputs.appObjectId
output ENTRA_API_CLIENT_APP_ID string = apiApplication.outputs.appClientApplicationId
output ENTRA_API_CLIENT_OBJECT_ID string = apiApplication.outputs.appClientObjectId
output AZURE_OWNER_OWNER string = principalLoginName
output AZURE_OWNER_OBJECT_ID string = principalId
output AZURE_KEY_VAULT_NAME string = keyVault.outputs.name
output AZURE_KEY_VAULT_ENTRA_API_SECRET_NAME string = apiApplication.outputs.appClientKeyVaultSecretName
output SERVICE_API_IDENTITY_PRINCIPAL_ID string = api.outputs.SERVICE_API_IDENTITY_PRINCIPAL_ID
output SERVICE_API_NAME string =  api.outputs.SERVICE_API_NAME
output SERVICE_API_URI string =  api.outputs.SERVICE_API_URI
output SERVICE_API_RESOURCE_URI string = apiApplication.outputs.appResourceUri
