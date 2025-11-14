# Como Testar o Projeto - Guia Rápido

Agora que o .NET SDK está instalado, siga estes passos:

## 1. Navegar até a pasta do projeto

No terminal do VS Code ou terminal normal:

```bash
cd /Users/vinicera/CURSOR/PIM4Ba
```

## 2. Restaurar os pacotes NuGet

```bash
dotnet restore
```

## 3. Compilar o projeto

```bash
dotnet build
```

Se compilar com sucesso, você verá algo como:
```
Build succeeded.
    0 Warning(s)
    0 Error(s)
```

## 4. Executar o programa

```bash
dotnet run
```

Isso vai abrir a aplicação Windows Forms.

## 5. Configurar o Banco de Dados (IMPORTANTE!)

Antes de executar, você precisa:

1. **Criar o banco de dados**:
   - Execute o script `SQLServer.sql` no SQL Server Management Studio
   - Ou use o comando: `sqlcmd -S SEU_SERVIDOR -i SQLServer.sql`

2. **Configurar a connection string**:
   - Abra o arquivo `Database.cs`
   - Atualize a linha com suas credenciais:
   ```csharp
   private static string connectionString = "Server=SEU_SERVIDOR;Database=HelpDeskDB;User Id=sa;Password=SUA_SENHA;";
   ```

   Exemplos:
   - **LocalDB**: `"Server=(localdb)\\mssqllocaldb;Database=HelpDeskDB;Trusted_Connection=true;"`
   - **SQL Server Express**: `"Server=.\\SQLEXPRESS;Database=HelpDeskDB;Integrated Security=true;"`

## Comandos Resumidos

```bash
# 1. Ir para a pasta
cd /Users/vinicera/CURSOR/PIM4Ba

# 2. Restaurar pacotes
dotnet restore

# 3. Compilar
dotnet build

# 4. Executar
dotnet run
```

## Troubleshooting

### Erro: "No executable found"
- Execute `dotnet build` primeiro
- Depois `dotnet run`

### Erro de conexão com banco
- Verifique se o SQL Server está rodando
- Confirme a connection string em `Database.cs`
- Execute o script `SQLServer.sql` para criar o banco

### Erro: "Package not found"
- Execute `dotnet restore` novamente
- Verifique sua conexão com a internet

## Próximos Passos

1. ✅ .NET SDK instalado
2. ⏳ Configurar banco de dados
3. ⏳ Configurar connection string
4. ⏳ Compilar e executar
5. ⏳ Testar funcionalidades

