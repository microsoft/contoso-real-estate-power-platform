# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
# This script sets up the stripe payment keys
# -----------------------------------------------------------------------
param (
    [string]$azureEnv
)

# -----------------------------------------------------------------------
# Import the environment variables
. "$PSScriptRoot\function-get-environment-variables.ps1"
$envVars = GetEnvironmentVariables -azureEnv $azureEnv

$functionAppName = $envVars.SERVICE_API_NAME
$functionName = "StripeWebhook"
$resourceGroupName = "rg-$($envVars.AZURE_RESOURCE_PREFIX)"
$keyVaultName = $envVars.AZURE_KEY_VAULT_NAME

WRite-Host $resourceGroupName

# Prompt for the Stripe Webhook Secret
Write-Host @"
Locate the Stripe API Key in your Stripe account by:
1. Logging into your Stripe account
2. Navigating to the Developers-> API Keys section https://dashboard.stripe.com/test/apikeys
3. Copy the 'Secret key' by clicking on it, and enter it below

"@ -ForegroundColor Cyan
$stripeApiKey = Read-Host -Prompt "Please enter the Stripe API Key (Right click to paste)"

Write-Host "Setting the Stripe API Key in the Key Vault" -ForegroundColor Green
az keyvault secret set --vault-name $keyVaultName --name 'StripeApiKey' --value $stripeApiKey > $null

# Get the Function App URL
$functionAppUrl=$(az functionapp show --name $functionAppName --resource-group $resourceGroupName --query "defaultHostName" --output tsv)
# Get the Function Key
$functionKey=$(az functionapp function keys list --function-name $functionName --name $functionAppName --resource-group $resourceGroupName --query "default" --output tsv)
# Construct the Full URL
$functionUrl="https://$($functionAppUrl)/api/stripe/webhook?code=$($functionKey)"

Write-Host @"
Register a new webhook endpoint in your Stripe account:

You can do this by:
1. Logging into your Stripe account
2. Navigating to the Developers -> Webhooks section https://dashboard.stripe.com/test/workbench/webhooks
4. Select '+ Add destination'
5. Select Checkout -> Select all Checkout events.
6. Select Continue -> Webhook endpoint -> Continue
7. Entering the following URL in the 'Endpoint URL' field
    $functionUrl
8. Select on 'Create destination'
9. Select Reveal next to the Signing secret.
10. Copy the 'Signing secret' by selecting the clip board icon, and enter it below 

"@ -ForegroundColor Cyan

# Prompt for the Stripe API Key
$stripeWebhookSigningSecret = Read-Host -Prompt "Please enter the Webhook 'Signing secret' (Right click to paste)"

Write-Host "Setting the Stripe Webhook Signing Secret in the Key Vault" -ForegroundColor Green
az keyvault secret set --vault-name $keyVaultName --name 'StripeWebhookSecret' --value $stripeWebhookSigningSecret > $null
