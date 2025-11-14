# Sistema Help Desk - PIM4B

## Problemas Corrigidos

1. **ChamadoDAO2.cs**: O método `Fechar` estava solto sem declaração de classe. Foi movido para dentro de `ChamadoDAO.cs`.

2. **Falta de using System**: Adicionado `using System;` nos arquivos que usam `DateTime` e outras classes do System.

3. **ChamadoDAO.cs**: Adicionado o método `Fechar` que estava faltando e que é chamado por `FrmFecharChamado.cs`.

## Como Testar o Programa

### Pré-requisitos

1. **SQL Server** instalado e rodando (SQL Server Express ou LocalDB)
2. **.NET Framework** ou **.NET 6/7/8** instalado
3. **Visual Studio** ou **Visual Studio Code** com extensão C#

### Passo 1: Configurar o Banco de Dados

1. Abra o SQL Server Management Studio (SSMS) ou use o `sqlcmd`
2. Execute o script `SQLServer.sql` para criar o banco de dados e as tabelas:
   ```sql
   -- Execute o arquivo SQLServer.sql
   ```

### Passo 2: Configurar a Connection String

1. Abra o arquivo `Database.cs`
2. Atualize a connection string com suas credenciais:
   ```csharp
   private static string connectionString = "Server=SEU_SERVIDOR;Database=HelpDeskDB;User Id=sa;Password=SUA_SENHA;";
   ```
   
   Exemplos:
   - **SQL Server LocalDB**: `"Server=(localdb)\\mssqllocaldb;Database=HelpDeskDB;Trusted_Connection=true;"`
   - **SQL Server Express**: `"Server=.\\SQLEXPRESS;Database=HelpDeskDB;Integrated Security=true;"`
   - **SQL Server com autenticação**: `"Server=localhost;Database=HelpDeskDB;User Id=sa;Password=SUA_SENHA;"`

### Passo 3: Compilar e Executar

O projeto já possui um arquivo `HelpDeskApp.csproj` configurado! Basta seguir os passos abaixo:

**Opção A - Usando Visual Studio:**
1. Abra o Visual Studio
2. File → Open → Project/Solution
3. Selecione o arquivo `HelpDeskApp.csproj`
4. Pressione F5 ou clique em "Start" para compilar e executar

**Opção B - Usando linha de comando (.NET 6+):**
```bash
cd PIM4B
dotnet restore    # Restaura os pacotes NuGet
dotnet build      # Compila o projeto
dotnet run        # Executa o programa
```

**Nota**: Certifique-se de ter o .NET 6.0 SDK ou superior instalado. Você pode verificar com:
```bash
dotnet --version
```

**⚠️ **Problema: Comando `dotnet` não funciona?**
- Se o comando `dotnet` não está funcionando no VS Code, você tem 3 opções:
  1. **Instalar o .NET SDK** (veja `GUIA_INSTALACAO.md` para instruções detalhadas)
  2. **Usar Visual Studio** (não VS Code) - abra o projeto e pressione F5
  3. **Usar .NET Framework** - renomeie `HelpDeskApp_Framework.csproj` para `HelpDeskApp.csproj` e abra no Visual Studio

Para mais detalhes, consulte o arquivo `GUIA_INSTALACAO.md`.

### Passo 4: Testar as Funcionalidades


1. **Cadastrar Usuário**:
   - Execute o programa (inicia com `FrmCadastroUsuario`)
   - Preencha Nome, Email e Senha
   - Clique em "Salvar"

2. **Abrir Novo Chamado**:
   - Modifique o `Program.cs` para abrir `FrmNovoChamado(1)` (onde 1 é o ID do usuário)
   - Preencha Título e Descrição
   - Clique em "Abrir Chamado"

3. **Fechar Chamado**:
   - Abra `FrmFecharChamado(1)`
   - Selecione um chamado aberto
   - Digite a solução aplicada
   - Clique em "Fechar Chamado"

4. **Visualizar Trilha**:
   - Abra `FrmTrilha`
   - Selecione um chamado no ComboBox
   - Veja a trilha de interações

## Estrutura do Projeto

- **Chamado.cs**: Modelo de dados para chamados
- **ChamadoDAO.cs**: Acesso a dados de chamados (Abrir, Listar, Fechar)
- **Usuario.cs**: Modelo de dados para usuários
- **UsuarioDAO.cs**: Acesso a dados de usuários
- **Interacao.cs**: Modelo de dados para interações
- **InteracaoDAO.cs**: Acesso a dados de interações
- **Database.cs**: Classe para gerenciar conexões com o banco
- **FrmCadastroUsuario.cs**: Formulário de cadastro de usuários
- **FrmNovoChamado.cs**: Formulário para abrir novos chamados
- **FrmFecharChamado.cs**: Formulário para fechar chamados
- **FrmTrilha.cs**: Formulário para visualizar trilha de interações
- **Program.cs**: Ponto de entrada da aplicação

## Observações Importantes

⚠️ **Segurança**: O código atual armazena senhas em texto puro. Em produção, use hash (BCrypt, SHA256, etc.)

⚠️ **Connection String**: Certifique-se de configurar corretamente antes de executar

⚠️ **Validações**: O código não possui validações extensivas. Considere adicionar validações de entrada.

