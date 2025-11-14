# Guia de Instalação e Compilação

## Problema: Comando `dotnet` não funciona no VS Code

Se o comando `dotnet` não está funcionando, você tem duas opções:

---

## Opção 1: Instalar o .NET SDK (Recomendado para projetos modernos)

### No macOS (seu caso):

1. **Instalar via Homebrew** (mais fácil):
   ```bash
   brew install --cask dotnet-sdk
   ```

2. **Ou baixar diretamente**:
   - Acesse: https://dotnet.microsoft.com/download
   - Baixe o .NET 6.0 SDK ou superior
   - Instale o arquivo `.pkg`

3. **Verificar instalação**:
   - Feche e reabra o terminal
   - Execute: `dotnet --version`
   - Deve mostrar algo como: `6.0.xxx` ou `7.0.xxx`

4. **No VS Code**:
   - Instale a extensão "C#" (da Microsoft)
   - Reinicie o VS Code
   - O comando `dotnet` deve funcionar no terminal integrado

### No Windows:

1. Baixe o instalador em: https://dotnet.microsoft.com/download
2. Execute o instalador
3. Reinicie o VS Code
4. Teste com: `dotnet --version`

### No Linux:

```bash
# Ubuntu/Debian
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y dotnet-sdk-6.0

# Verificar
dotnet --version
```

---

## Opção 2: Usar .NET Framework (Não precisa do dotnet CLI)

Se você tem o **Visual Studio** instalado (não VS Code), pode usar o projeto `.NET Framework`:

### Passos:

1. **Renomeie o arquivo de projeto**:
   - Renomeie `HelpDeskApp.csproj` para `HelpDeskApp_Modern.csproj` (backup)
   - Renomeie `HelpDeskApp_Framework.csproj` para `HelpDeskApp.csproj`

2. **Abra no Visual Studio**:
   - Abra o Visual Studio (não VS Code)
   - File → Open → Project/Solution
   - Selecione `HelpDeskApp.csproj`
   - Pressione F5 para compilar e executar

3. **Ou compile via MSBuild** (se tiver Visual Studio instalado):
   ```bash
   # No Windows, use o Developer Command Prompt:
   msbuild HelpDeskApp.csproj /p:Configuration=Debug
   ```

---

## Opção 3: Usar Visual Studio Community (Mais fácil para Windows Forms)

Se você está no **Windows**, a forma mais simples é:

1. **Baixe o Visual Studio Community** (grátis):
   - https://visualstudio.microsoft.com/pt-br/vs/community/

2. **Durante a instalação**, selecione:
   - ✅ Desenvolvimento para desktop com .NET
   - ✅ .NET Framework 4.8 SDK

3. **Abra o projeto**:
   - File → Open → Project/Solution
   - Selecione `HelpDeskApp.csproj` (ou `HelpDeskApp_Framework.csproj`)
   - Pressione F5

---

## Verificar qual opção você tem instalada

Execute no terminal:

```bash
# Verificar .NET SDK (moderno)
dotnet --version

# Verificar .NET Framework (Windows)
# No Windows PowerShell:
[System.Environment]::Version

# Verificar MSBuild (Visual Studio)
# No Windows, no Developer Command Prompt:
msbuild /version
```

---

## Resumo das Opções

| Opção | Requisitos | Comando |
|-------|-----------|---------|
| **.NET 6+ SDK** | Instalar SDK | `dotnet build` |
| **.NET Framework** | Visual Studio | Abrir no VS e F5 |
| **Visual Studio Community** | Instalar VS | Abrir projeto e F5 |

---

## Recomendação

- **macOS/Linux**: Instale o .NET SDK via Homebrew ou download
- **Windows**: Use Visual Studio Community (mais fácil para Windows Forms)

Se precisar de ajuda com alguma dessas opções, me avise!

