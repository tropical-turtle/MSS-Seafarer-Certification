# SeaCertsBlazor

This shouldn't be here

[![Board Status](https://dev.azure.com/transport-canada/0f91b5b9-ce7e-44d1-b2f1-ca76af598788/f7a003ec-d6de-4bef-a3b5-e1ea2d282372/_apis/work/boardbadge/f8975bd6-2e82-4aee-927a-642bbe432844)](https://dev.azure.com/transport-canada/0f91b5b9-ce7e-44d1-b2f1-ca76af598788/_boards/board/t/f7a003ec-d6de-4bef-a3b5-e1ea2d282372/Microsoft.RequirementCategory)

![.NET Core](https://github.com/tc-tibo/SeaCertsBlazor/workflows/.NET%20Core/badge.svg?branch=master)

# Introduction 

This is the prototype for the digital CDN Application Form as part of TC's Seafarer Credentials Project. It is written in Blazor and is strictly for development purposes. Actual development will be hosted in TC's official Github home.

# Getting Started

NB - these instructions are written specifically for getting the project running in Visual Studio 2019 Enterprise Edition on a computer running Windows 10 Enterprise Operating system.

1.	Installation process

To run this project locally from VisualStudio 2019, clone repository, open .sln file in Visual Studio, and then choose Debug -> Start Debugging, or F5 on the keyboard.

2.	Software dependencies

The following are managed via NuGet package manager in Visual Studio:
  -https://www.nuget.org/packages/GoC.WebTemplate-Components.Core
  -https://www.nuget.org/packages/Microsoft.Azure.Storage.Blob
  -https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design
  
The Target framework is .NET Core 3.1, which is available for download from [Microsoft](https://dotnet.microsoft.com/download/dotnet-core/3.1).

3.	Latest releases

Releases are continuosly deployed to:

https://seacertsblazor.azurewebsites.net/

Upon commits to master.

4.	API references

None.

# Build and Test

The solution can be built from Visual Studio's "Build" menu or from Ctrl+Shift+B from keyboard. There are currently no unit tests.

# Contribute

Some ideas:
  - implement localization using CDTS
  - add test scripts
  - containerize using Docker
  - set up AKS
