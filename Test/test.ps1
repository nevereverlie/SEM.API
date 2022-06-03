param (
    [Parameter(Mandatory = $true)]
    [string] $Server
)

$ErrorActionPreference = 'Stop'

$testPostmanFolderPath = "$PSScriptRoot/postman"
$testResultsFolderPath = "$PSScriptRoot/testresults"

npx newman run "$testPostmanFolderPath/collection.json" `
    --globals "$testPostmanFolderPath/environment.json" `
    --global-var "server=$Server" `
    --reporters cli,json `
    --reporter-json-export "$testResultsFolderPath/postman.testresults.json" `
    --insecure
if (!$?) { exit $LASTEXITCODE }


