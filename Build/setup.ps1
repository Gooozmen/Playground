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
    nuget install Toolkit -Source "github" -OutputDirectory "..\Dependencies" -NoCache
}

function Import-ToolkitSetup{
    $ToolkitPath = Resolve-Path "..\Dependencies\Toolkit*\lib\setup.ps1"
    . $ToolkitPath
}

function Remove-Folder([string[]] $FolderArray){
    foreach($_ in $FolderArray){
        If(Test-Path("$_")) {Remove-Item $_ -Recurse }
    }
}

function Clear-NugetCache{
    nuget locals all -clear
}

Clear-NugetCache
Verify-PackageSource
Remove-Folder -FolderArray @("..\Dependencies\psake*","..\Dependencies\Toolkit*")
Install-Toolkit
Import-ToolkitSetup


