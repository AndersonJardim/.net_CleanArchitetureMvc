# Comandos iniciais

md CleanArchMvc_NET_CLI
cd CleanArchMvc_NET_CLI

dotnet new gitignore

# Para ver todos templates disponíveis:
# dotnet new

#Nome do modelo / Nome curto , que será usado:
#Solution File   / sln
#Class library   / classlib
#ASP.NET Core Web App (Model-View-Controller) / mvc

dotnet new sln --name CleanArchMvc
dotnet new classlib --name CleanArchMvc.Domain
dotnet new classlib --name CleanArchMvc.Application
dotnet new classlib --name CleanArchMvc.Infra.Data
dotnet new classlib --name CleanArchMvc.Infra.IoC
dotnet new mvc --name CleanArchMvc.WebUI

dotnet sln CleanArchMvc.sln add CleanArchMvc.Domain/CleanArchMvc.Domain.csproj
dotnet sln CleanArchMvc.sln add CleanArchMvc.Application/CleanArchMvc.Application.csproj
dotnet sln CleanArchMvc.sln add CleanArchMvc.Infra.Data/CleanArchMvc.Infra.Data.csproj
dotnet sln CleanArchMvc.sln add CleanArchMvc.Infra.IoC/CleanArchMvc.Infra.IoC.csproj
dotnet sln CleanArchMvc.sln add CleanArchMvc.WebUI/CleanArchMvc.WebUI.csproj

dotnet builder
dotnet run --project CleanArchMvc.WebUI/CleanArchMvc.csproj
# ou
# dotnet run --project .\CleanArchMvc.WebUI\CleanArchMvc.WebUI.csproj
# http://localhost:5220/

dotnet sln CleanArchMvc.sln add CleanArchMvc.Infra.Data/CleanArchMvc.Infra.Data.csproj

#
dotnet add CleanArchMvc.Application reference .\CleanArchMvc.Domain\CleanArchMvc.Domain.csproj
dotnet add CleanArchMvc.Infra.Data reference .\CleanArchMvc.Domain\CleanArchMvc.Domain.csproj
#
dotnet add CleanArchMvc.Infra.IoC reference .\CleanArchMvc.Application\CleanArchMvc.Application.csproj
dotnet add CleanArchMvc.Infra.IoC reference .\CleanArchMvc.Domain\CleanArchMvc.Domain.csproj
dotnet add CleanArchMvc.Infra.IoC reference .\CleanArchMvc.Infra.Data\CleanArchMvc.Infra.Data.csproj
#
dotnet add CleanArchMvc.WebUI reference .\CleanArchMvc.Infra.IoC\CleanArchMvc.Infra.IoC.csproj

## Incluir referência aos pacotes Nuget
# Microsoft.EntityFrameworkCore.SqlServer
# Microsoft.EntityFrameworkCore.Tools
# Microsoft.EntityFrameworkCore.Design










