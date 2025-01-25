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

function Remove-Folder([string[]] $PathsArray){
    Write-Host "Cleaning Folders"
    foreach ($_ in $PathsArray) {
        $AbsolutePath = Resolve-Path "$_"
        Write-Host "Verifying $_ content"
        if(Test-Path $AbsolutePath){
            # $content = Get-ChildItem -Path $AbsolutePath -Force
            # Write-Host "Content: $content"
            Get-ChildItem -Path $AbsolutePath -Force | Remove-Item -Recurse -Force
        }
        else{
            Write-Host "$_ doesnt exist"
        }
    }
}

function Clear-NugetCache{
    nuget locals all -clear
}

Remove-Folder -PathsArray @("..\Dependencies","..\Artifacts","..\Output")
Clear-NugetCache
Set-PackageSource
Install-Toolkit
Import-ToolkitSetup

