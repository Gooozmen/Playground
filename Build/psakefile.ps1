$ToolkitPath = Resolve-Path "..\Dependencies\Toolkit*\lib\Tasks.ps1"
. $ToolkitPath

# Debug: The default configuration, typically used for development. Includes debug symbols and disables optimizations.
# Release: Used for production builds. Optimizations are enabled, and debug symbols are excluded.
$configuration = "Debug"
$SolutionPath = Resolve-Path ("..\src\Playground.sln")
$OutputPath = Resolve-Path ("..\Output")
$ArtifactsPath = Resolve-Path ("..\Artifacts")

$SourceFolder = $OutputPath
$OutputFolder = $ArtifactsPath
$TestDllPath = "$OutputPath\Tests.dll"
$TestsLogOutput = $ArtifactsPath



$ArtifactsFolder = $ArtifactsPath 
$DestinationFolder = "$ArtifactsFolder\Application.zip"
$ProjectArtifact = $DestinationFolder

$BucketName = $ENV:AWS_S3_NAME
$S3Key = $ENV:AWS_S3_PATHKEY
$Region = $ENV:AWS_S3_REGION
$AccessKey = $ENV:AWS_S3_ACCESSKEY
$SecretKey = $ENV:AWS_S3_SECTRETKEY 
$FileKey = "Playground-Api"
