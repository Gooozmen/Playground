# PowerShell 7 Script to Clean and Restore NuGet Packages in a Local Folder

param (
    [string]$SolutionPath = "..\src",  # Default to current folder
    [string]$LocalNuGetPath = "..\Dependencies"  # Custom local NuGet path
)

# Function to Clean Local NuGet Repository
function Clean-LocalNuGetRepo {
    Write-Host "Cleaning local NuGet repository at: $LocalNuGetPath" -ForegroundColor Yellow

    if (Test-Path $LocalNuGetPath) {
        Remove-Item -Path $LocalNuGetPath -Recurse -Force
        Write-Host "Local NuGet repository cleaned successfully!" -ForegroundColor Green
    }
    else {
        Write-Host "Local NuGet repository not found. Skipping cleanup..." -ForegroundColor Cyan
    }
}

# Function to Restore NuGet Packages
function Restore-NuGetPackages {
    Write-Host "Restoring NuGet packages for solution: $SolutionPath" -ForegroundColor Yellow

    # Ensure packages are restored to the local folder
    $restoreResult = dotnet restore $SolutionPath --packages $LocalNuGetPath

    if ($LASTEXITCODE -eq 0) {
        Write-Host "NuGet packages restored successfully!" -ForegroundColor Green
    }
    else {
        Write-Host "Error occurred during NuGet package restoration." -ForegroundColor Red
        exit $LASTEXITCODE
    }
}

# Main Execution
Write-Host "Starting NuGet local clean and restore process..." -ForegroundColor Cyan

Clean-LocalNuGetRepo
Restore-NuGetPackages

Write-Host "NuGet local clean and restore process completed!" -ForegroundColor Green
