using System;
using System.Data.SqlClient;
using System.Windows.Forms;

public class UsuarioDAO
{
    public static void Inserir(Usuario u)
    {
        // Se estiver em modo in-memory, usa dados em memória
        if (Database.UsarModoInMemory)
        {
            DatabaseInMemory.InserirUsuario(u);
            return;
        }

        // Tenta usar SQL Server
        try
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string sql = @"INSERT INTO Usuarios (Nome, Email, Senha, DataCriacao)
                               VALUES (@nome, @email, @senha, @data)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", u.Nome);
                    cmd.Parameters.AddWithValue("@email", u.Email);
                    cmd.Parameters.AddWithValue("@senha", u.Senha); // Use BCrypt ou similar
                    cmd.Parameters.AddWithValue("@data", u.DataCriacao);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (SqlException ex)
        {
            string mensagem = "Erro ao conectar ao banco de dados.\n\n";
            
            if (ex.Number == 53 || ex.Message.Contains("network-related") || ex.Message.Contains("server was not found"))
            {
                mensagem += "O servidor SQL Server não foi encontrado ou não está acessível.\n\n";
                mensagem += "Dica: Configure Database.UsarModoInMemory = true em Database.cs\n";
                mensagem += "para usar dados em memória sem SQL Server.\n\n";
                mensagem += "Ou verifique:\n";
                mensagem += "1. Se o SQL Server está instalado e rodando\n";
                mensagem += "2. Se a connection string em Database.cs está configurada corretamente\n";
                mensagem += "3. Se o nome do servidor está correto";
            }
            else
            {
                mensagem += $"Erro SQL: {ex.Message}";
            }
            
            MessageBox.Show(mensagem, "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            throw;
        }
    }
}
