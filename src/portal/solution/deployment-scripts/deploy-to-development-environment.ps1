# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
param (
    [string]$azureEnv
)

$solutionName = "ContosoRealEstatePortal"
Write-Host "This script will deploy the $solutionName solution to your development environment." -ForegroundColor White

# -----------------------------------------------------------------------
# Import the environment variables
$publicRepo = "https://github.com/microsoft/contoso-real-estate-power-platform/"
$repoRoot =  Join-Path -Path $PSScriptRoot -ChildPath "/../../../../"
# Resolve to an absolute path
$repoRoot = (Get-Item -Path $repoRoot).FullName

. "$repoRoot/src/core/solution/deployment-scripts/function-get-environment-variables.ps1"
$envVars = GetEnvironmentVariables -azureEnv $azureEnv

$sourceFolder = Join-Path -Path $PSScriptRoot -ChildPath "../$solutionName"
$tempReleaseFolder = Join-Path -Path $repoRoot -ChildPath "/temp_releases"

Write-Host @"
Download the most recent `ContosoRealEstateCustomControls_managed.zip` solution into the folder '$tempReleaseFolder'. 
$publicRepo/releases?q=ContosoRealEstateCustomControls&expanded=true

Download the most recent `ContosoRealEstateCore_managed.zip` solution into the folder '$tempReleaseFolder'. 
$publicRepo/releases?q=ContosoRealEstateCore&expanded=true

"@ -ForegroundColor Yellow

# Wait for any key to continue
Write-Host "Press any key to continue..."
$null = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")

# Check that the ContosoRealEstateCustomControls_managed.zip file exists
if (-not (Test-Path -Path "$tempReleaseFolder/ContosoRealEstateCustomControls_managed.zip")) {
    Write-Host "The ContosoRealEstateCustomControls_managed.zip file does not exist in the temp_releases folder." -ForegroundColor Red
    Write-Host @"
Download the most recent `ContosoRealEstateCustomControls_managed.zip` solution into the folder . 
$publicRepo/releases?q=ContosoRealEstateCustomControls&expanded=true
"@ -ForegroundColor Yellow
    exit
}

# Check that the ContosoRealEstateCore_managed.zip file exists
if (-not (Test-Path -Path "$tempReleaseFolder/ContosoRealEstateCore_managed.zip")) {
    Write-Host "The ContosoRealEstateCore_managed.zip file does not exist in the temp_releases folder." -ForegroundColor Red
    Write-Host @"
Download the most recent `ContosoRealEstateCore_managed.zip` solution into the folder . 
$publicRepo/releases?q=ContosoRealEstateCore&expanded=true
"@ -ForegroundColor Yellow
    exit
}

Write-Host "Building solution at '$sourceFolder'" -ForegroundColor Green
dotnet build -c Release "$sourceFolder"
if ($? -eq $false) {
    throw $_.Exception
    exit 1
}

# Create core deployment settings file
. "$repoRoot/src/core/solution/deployment-scripts/generate-deployment-settings.ps1" -azureEnv $azureEnv

Write-Host "Checking access via Power Platform CLI..." -ForegroundColor Green

# Get the environment name that the user is currently authenticated for the Power Apps CLI and check that they are happy with this
$environment = pac env who --json | ConvertFrom-Json
$environmentName = $environment.FriendlyName
$azureEnv = $envVars.AZURE_ENV_NAME

if (-not (ConfirmPrompt -message "Are you sure you want to deploy to the environment ${environmentName}?")) {
    Write-Host "Exiting" -ForegroundColor Yellow
    exit
}

# Enable PCF controls in Canvas Apps
pac env update-settings --name "iscustomcontrolsincanvasappsenabled" --value true

# Enable JavaScript attachments for the portal
pac env update-settings --name "blockedattachments" --value "ade;adp;app;asa;ashx;asmx;asp;bas;bat;cdx;cer;chm;class;cmd;com;config;cpl;crt;csh;dll;exe;fxp;hlp;hta;htr;htw;ida;idc;idq;inf;ins;isp;its;jar;jse;ksh;lnk;mad;maf;mag;mam;maq;mar;mas;mat;mau;mav;maw;mda;mdb;mde;mdt;mdw;mdz;msc;msh;msh1;msh1xml;msh2;msh2xml;mshxml;msi;msp;mst;ops;pcd;pif;prf;prg;printer;pst;reg;rem;scf;scr;sct;shb;shs;shtm;shtml;soap;stm;tmp;url;vb;vbe;vbs;vsmacros;vss;vst;vsw;ws;wsc;wsf;wsh"


# Deploy the dependencies
Write-Host "Deploying 'ContosoRealEstateCustomControls_managed.zip' to '$environmentName'" -ForegroundColor Green
pac solution import -p "$tempReleaseFolder/ContosoRealEstateCustomControls_managed.zip" -a
if ($? -eq $false) {
    throw $_.Exception
    exit 1
}

Write-Host "Deploying 'ContosoRealEstateCore_managed.zip' to '$environmentName'" -ForegroundColor Green
pac solution import -p "$tempReleaseFolder/ContosoRealEstateCore_managed.zip" -a -ap --settings-file "$repoRoot/src/core/solution/deployment-scripts/temp_deploymentSettings_$azureEnv.json" 
if ($? -eq $false) {
    throw $_.Exception
    exit 1
}

# Deploy the development unmanaged solution
Write-Host "Deploying solution '$solutionName' to '$environmentName'" -ForegroundColor Green
pac solution import -p "$sourceFolder/bin/$solutionName.zip" -a -ap -pc
if ($? -eq $false) {
    throw $_.Exception
    exit 1
}

# Import test data
Write-Host "Importing test data" -ForegroundColor Green
pac data import -d "$repoRoot/src/core/data/reference-data.zip"
pac data import -d "$repoRoot/src/core/data/sample-data.zip"

Write-Host "Complete" -ForegroundColor Green
