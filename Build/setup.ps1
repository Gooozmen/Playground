function Add-PackageSource([string] $Command){
    $Username = $env:NUGET_USERNAME
    $Password = $env:NUGET_PASSWORD
    Write-Output "Username $Username"
    Write-Output "PASS $Password"


    if (-not $Username -or -not $Password) {
        Write-Error "Environment variables NUGET_USERNAME or NUGET_PASSWORD are not set."
        return
    }

    nuget sources $Command -Name "github" -Source "https://nuget.pkg.github.com/Gooozmen/index.json" -username $Username -password $Password
}
function Set-PackageSource{
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
Set-PackageSource
Remove-Folder -FolderArray @("..\Dependencies\psake*","..\Dependencies\Toolkit*")
Install-Toolkit
Import-ToolkitSetup


