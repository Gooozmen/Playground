$ToolkitPath = Resolve-Path "..\Dependencies\Toolkit*\lib\Tools.ps1"
. $ToolkitPath

# Debug: The default configuration, typically used for development. Includes debug symbols and disables optimizations.
# Release: Used for production builds. Optimizations are enabled, and debug symbols are excluded.
$configuration = "Debug"
$SolutionPath = "..\src\Playground.sln"


