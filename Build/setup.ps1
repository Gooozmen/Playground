function Install-Toolkit{
    nuget Install Toolkit -Source "github" -Output ..\Dependencies
}

Install-Toolkit
."..\Dependencies\Toolkit*\lib\setup.ps1"