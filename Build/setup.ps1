function Add-PackageSource([string] $Command){
    nuget sources $Command -Name "github" -Source "https://nuget.pkg.github.com/Gooozmen/index.json" -username Gooozmen -password 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
}

function Verify-PackageSource{
    $sources = nuget sources list
    if($sources -like "*https://nuget.pkg.github.com/Gooozmen/index.json*"){
        Add-PackageSource -Command "update"
        Write-Host "Github source was updated"
    }
    else{
        Add-PackageSource -Command "add"
        Write-Host "Github source was added"
    }
}

function Install-Toolkit{
    nuget install Toolkit -Source "github" -OutputDirectory "..\Dependencies"
}

function Import-ToolkitSetup{
    $ToolkitPath = Resolve-Path "..\Dependencies\Toolkit*\lib\setup.ps1"
    . $ToolkitPath
}

Verify-PackageSource
Install-Toolkit
Import-ToolkitSetup


