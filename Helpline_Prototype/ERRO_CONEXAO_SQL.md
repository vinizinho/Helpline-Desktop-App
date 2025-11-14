# Erro de Conexão com SQL Server - Guia de Resolução

## Erro Encontrado

```
System.Data.SqlClient.SqlException: A network-related or instance-specific error occurred 
while establishing a connection to SQL Server. The server was not found or was not accessible.
```

**Erro Número**: 53  
**Causa**: O aplicativo não consegue encontrar ou conectar ao servidor SQL Server.

## O Que Significa Este Erro?

Este erro ocorre quando:
1. O SQL Server não está instalado no computador
2. O SQL Server não está rodando (serviço parado)
3. A connection string está incorreta no arquivo `Database.cs`
4. O nome do servidor/instância está errado
5. O banco de dados `HelpDeskDB` não existe

## Como Resolver

### Opção 1: Usar SQL Server LocalDB (Recomendado para Desenvolvimento)

**LocalDB** é uma versão leve do SQL Server ideal para desenvolvimento local.

#### Passo 1: Instalar SQL Server LocalDB

1. Baixe o **SQL Server Express** (que inclui LocalDB):
   - Acesse: https://www.microsoft.com/pt-br/sql-server/sql-server-downloads
   - Baixe "SQL Server Express" (grátis)
   - Durante a instalação, selecione "LocalDB"

2. Ou instale apenas o LocalDB via Visual Studio Installer:
   - Abra o Visual Studio Installer
   - Modifique a instalação
   - Marque "SQL Server Express LocalDB" em "Componentes Individuais"

#### Passo 2: Configurar a Connection String

Abra o arquivo `Database.cs` e altere a connection string para:

```csharp
private static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=HelpDeskDB;Trusted_Connection=true;";
```

#### Passo 3: Criar o Banco de Dados

1. Abra o **SQL Server Management Studio (SSMS)** ou use o **sqlcmd**
2. Execute o script `SQLServer.sql` que está na pasta do projeto
3. Isso criará o banco de dados `HelpDeskDB` e as tabelas necessárias

**Alternativa via linha de comando:**
```bash
sqlcmd -S "(localdb)\mssqllocaldb" -i SQLServer.sql
```

---

### Opção 2: Usar SQL Server Express

Se você já tem o SQL Server Express instalado:

1. Abra o arquivo `Database.cs`
2. Altere a connection string para:
   ```csharp
   private static string connectionString = "Server=.\\SQLEXPRESS;Database=HelpDeskDB;Integrated Security=true;";
   ```
   (Substitua `SQLEXPRESS` pelo nome da sua instância, se diferente)

3. Certifique-se de que o serviço **SQL Server (SQLEXPRESS)** está rodando:
   - Pressione `Win + R`
   - Digite `services.msc`
   - Procure por "SQL Server (SQLEXPRESS)"
   - Se estiver parado, clique com botão direito → Iniciar

4. Execute o script `SQLServer.sql` para criar o banco

---

### Opção 3: Usar SQL Server com Autenticação SQL

Se você tem um SQL Server configurado com usuário e senha:

1. Abra o arquivo `Database.cs`
2. Altere a connection string para:
   ```csharp
   private static string connectionString = "Server=localhost;Database=HelpDeskDB;User Id=seu_usuario;Password=sua_senha;";
   ```
   (Substitua `seu_usuario` e `sua_senha` pelas suas credenciais)

---

## Verificar se o SQL Server Está Rodando

### Para LocalDB:
```bash
sqllocaldb info mssqllocaldb
sqllocaldb start mssqllocaldb
```

### Para SQL Server Express:
1. Abra o **SQL Server Configuration Manager**
2. Verifique se o serviço está "Running" (Em execução)
3. Se não estiver, clique com botão direito → Start

### Via PowerShell:
```powershell
Get-Service | Where-Object {$_.DisplayName -like "*SQL Server*"}
```

---

## Exemplos de Connection Strings

### LocalDB (Windows Authentication):
```
Server=(localdb)\mssqllocaldb;Database=HelpDeskDB;Trusted_Connection=true;
```

### SQL Server Express (Windows Authentication):
```
Server=.\SQLEXPRESS;Database=HelpDeskDB;Integrated Security=true;
```

### SQL Server com Autenticação SQL:
```
Server=localhost;Database=HelpDeskDB;User Id=sa;Password=MinhaSenha123;
```

### SQL Server em Servidor Remoto:
```
Server=192.168.1.100;Database=HelpDeskDB;User Id=usuario;Password=senha;
```

---

## Criar o Banco de Dados Manualmente

Se preferir criar o banco manualmente:

1. Abra o **SQL Server Management Studio (SSMS)**
2. Conecte ao seu servidor (LocalDB, Express, etc.)
3. Clique com botão direito em "Databases" → "New Database"
4. Nome: `HelpDeskDB`
5. Execute o script `SQLServer.sql` para criar as tabelas

---

## Testar a Conexão

Após configurar, teste a conexão:

1. Compile o projeto: `dotnet build`
2. Execute: `dotnet run`
3. Tente cadastrar um usuário
4. Se ainda der erro, verifique:
   - Se o SQL Server está rodando
   - Se a connection string está correta
   - Se o banco de dados existe
   - Se as tabelas foram criadas

---

## Próximos Passos

Após resolver a conexão:
1. ✅ Execute o script `SQLServer.sql` para criar as tabelas
2. ✅ Teste cadastrar um usuário
3. ✅ Teste criar um chamado
4. ✅ Verifique se tudo está funcionando

Se ainda tiver problemas, verifique os logs de erro do SQL Server ou consulte a documentação do SQL Server.

