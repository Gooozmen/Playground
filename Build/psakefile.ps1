$ToolkitPath = Resolve-Path "..\Dependencies\Toolkit*\lib\Tools.ps1"
. $ToolkitPath

# Debug: The default configuration, typically used for development. Includes debug symbols and disables optimizations.
# Release: Used for production builds. Optimizations are enabled, and debug symbols are excluded.
$Configuration = "Release"
$SolutionPath = "..\src\Playground.sln"

$ArtifactsFolder = Resolve-Path "..\Artifacts"
$SourceFolder =  "$ArtifactsFolder\Application"
$OutputPath = "$ArtifactsFolder\Application"
$DestinationFolder = "$ArtifactsFolder\Application.zip"
$ProjectArtifact = $DestinationFolder

$BucketName = $ENV:AWS_S3_NAME
$S3Key = $ENV:AWS_S3_PATHKEY
$Region = $ENV:AWS_S3_REGION
$AccessKey = $ENV:AWS_S3_ACCESSKEY
$SecretKey = $ENV:AWS_S3_SECTRETKEY 
$FileKey = "Playground-Api"


