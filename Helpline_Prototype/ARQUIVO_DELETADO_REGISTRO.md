# Registro de Arquivo Deletado

## Arquivo Deletado: `HelpDeskApp_Framework.csproj`

**Data da Deleção**: 2024 (verificação realizada)

**Motivo da Deleção**: 
Este arquivo era uma versão alternativa do projeto usando .NET Framework 4.8, que é um formato antigo e Windows-only. O arquivo `HelpDeskApp.csproj` (que permanece) é a versão moderna e correta para Windows, usando .NET 9.0-windows com formato SDK-style, que pode ser compilado e executado via `dotnet` CLI.

**Conteúdo do Arquivo Deletado**:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" Condition="Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')" />
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{A1B2C3D4-E5F6-4A5B-8C9D-0E1F2A3B4C5D}</ProjectGuid>
    <OutputType>WinExe</OutputType>
    <RootNamespace>HelpDeskApp</RootNamespace>
    <AssemblyName>HelpDeskApp</AssemblyName>
    <TargetFrameworkVersion>v4.8</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <AutoGenerateBindingRedirects>true</AutoGenerateBindingRedirects>
    <Deterministic>true</Deterministic>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <PlatformTarget>AnyCPU</PlatformTarget>
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Data" />
    <Reference Include="System.Data.SqlClient" />
    <Reference Include="System.Windows.Forms" />
    <Reference Include="System.Xml" />
    <Reference Include="System.Xml.Linq" />
  </ItemGroup>
  <ItemGroup>
    <Compile Include="Chamado.cs" />
    <Compile Include="ChamadoDAO.cs" />
    <Compile Include="Database.cs" />
    <Compile Include="FrmCadastroUsuario.cs">
      <SubType>Form</SubType>
    </Compile>
    <Compile Include="FrmFecharChamado.cs">
      <SubType>Form</SubType>
    </Compile>
    <Compile Include="FrmNovoChamado.cs">
      <SubType>Form</SubType>
    </Compile>
    <Compile Include="FrmTrilha.cs">
      <SubType>Form</SubType>
    </Compile>
    <Compile Include="Interacao.cs" />
    <Compile Include="InteracaoDAO.cs" />
    <Compile Include="Program.cs" />
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="Usuario.cs" />
    <Compile Include="UsuarioDAO.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="App.config" />
  </ItemGroup>
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
</Project>
```

**Características do Arquivo Deletado**:
- Formato antigo: Usava o formato de projeto .NET Framework tradicional (ToolsVersion="15.0")
- Target Framework: .NET Framework 4.8 (v4.8)
- Dependências: Referências diretas a assemblies do .NET Framework (System, System.Core, System.Data, etc.)
- Compilação: Requeria Visual Studio ou MSBuild do Windows
- Compatibilidade: Apenas Windows (não podia ser usado no macOS para compilar)

**Arquivo Mantido**: `HelpDeskApp.csproj`
- Formato moderno: SDK-style project
- Target Framework: .NET 9.0-windows
- Compilação: Pode ser compilado via `dotnet` CLI em Windows, macOS ou Linux
- Execução: Windows (devido ao uso de Windows Forms)

