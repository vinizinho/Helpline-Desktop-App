# Como Executar o Programa sem SQL Server

## ✅ Modo In-Memory (Dados em Memória)

O programa agora suporta um **modo de desenvolvimento** que funciona **sem SQL Server**, usando dados em memória.

### Como Ativar

1. Abra o arquivo `Database.cs`
2. Certifique-se de que a linha está assim:
   ```csharp
   public static bool UsarModoInMemory = true;
   ```

### Como Executar

```bash
cd PIM4Ba
dotnet build
dotnet run
```

**Pronto!** O programa vai funcionar normalmente, mas os dados serão armazenados apenas em memória (serão perdidos quando você fechar o programa).

---

## 📝 Funcionalidades Disponíveis

No modo in-memory, todas as funcionalidades funcionam:

- ✅ Cadastrar usuários
- ✅ Criar chamados
- ✅ Listar chamados
- ✅ Fechar chamados
- ✅ Visualizar trilha de interações

---

## ⚠️ Limitações do Modo In-Memory

1. **Dados temporários**: Os dados são perdidos quando você fecha o programa
2. **Sem persistência**: Não há salvamento permanente
3. **Apenas para desenvolvimento**: Ideal para testar a interface e funcionalidades

---

## 🔄 Quando Quiser Usar SQL Server

Quando estiver pronto para usar SQL Server:

1. Configure o SQL Server (veja `ERRO_CONEXAO_SQL.md`)
2. Abra o arquivo `Database.cs`
3. Altere para:
   ```csharp
   public static bool UsarModoInMemory = false;
   ```
4. Configure a connection string no mesmo arquivo
5. Execute o script `SQLServer.sql` para criar o banco de dados

---

## 🎯 Vantagens do Modo In-Memory

- ✅ Não precisa instalar SQL Server
- ✅ Executa imediatamente via `dotnet run`
- ✅ Perfeito para desenvolvimento e testes
- ✅ Testa todas as funcionalidades da interface

---

## 📌 Resumo

**Para executar sem SQL Server:**
- `Database.UsarModoInMemory = true` em `Database.cs`
- Execute: `dotnet run`

**Para usar SQL Server:**
- `Database.UsarModoInMemory = false` em `Database.cs`
- Configure a connection string
- Execute o script SQL

