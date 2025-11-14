using System.Data.SqlClient;

public static class Database
{
    // ⚠️ MODO DE DESENVOLVIMENTO: Defina como true para usar dados em memória (sem SQL Server)
    // ⚠️ Defina como false para usar SQL Server real
    public static bool UsarModoInMemory = true; // ← Altere para false quando tiver SQL Server configurado
    
    // ⚠️ IMPORTANTE: Configure a connection string abaixo antes de executar o programa!
    // 
    // Exemplos de connection strings:
    // 
    // SQL Server LocalDB (recomendado para desenvolvimento):
    // "Server=(localdb)\\mssqllocaldb;Database=HelpDeskDB;Trusted_Connection=true;"
    //
    // SQL Server Express:
    // "Server=.\\SQLEXPRESS;Database=HelpDeskDB;Integrated Security=true;"
    //
    // SQL Server com autenticação SQL:
    // "Server=localhost;Database=HelpDeskDB;User Id=sa;Password=SUA_SENHA;"
    //
    // SQL Server em servidor remoto:
    // "Server=NOME_DO_SERVIDOR;Database=HelpDeskDB;User Id=usuario;Password=senha;"
    
    private static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=HelpDeskDB;Trusted_Connection=true;";

    public static SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }
    
    public static bool TestarConexao()
    {
        try
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}