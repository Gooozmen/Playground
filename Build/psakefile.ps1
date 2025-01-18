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


# dotnet test C:\Git\Playground\Output\Tests.dll --logger "trx;LogFileName=TestsResult.trx" --results-directory C:\Git\Playground\Artifacts\
  dotnet test C:\Git\Playground\Output\Tests.dll --logger 'trx;LogFileName=TestResults.trx' --results-directory C:\Git\Playground\Artifacts
