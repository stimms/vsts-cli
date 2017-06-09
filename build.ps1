$scriptroot = "$PSScriptRoot"
$artifacts = "$scriptroot\artifacts"

Remove-Item -Force -Recurse $artifacts -ErrorAction Ignore

$sourcedirectory = "$PSScriptRoot\src"
$solutionName = "vsts.cli"
$solutionFile = "$sourcedirectory\$solutionName.sln"

dotnet restore $solutionFile
dotnet publish $solutionFile -c Release -r win10-x64 -o $artifacts;
