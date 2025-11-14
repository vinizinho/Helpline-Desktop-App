using System.Data.SqlClient;
using System.Collections.Generic;

public class InteracaoDAO
{
    public static void Inserir(Interacao i)
    {
        // Se estiver em modo in-memory, usa dados em memória
        if (Database.UsarModoInMemory)
        {
            DatabaseInMemory.InserirInteracao(i);
            return;
        }

        // Tenta usar SQL Server
        using (var conn = Database.GetConnection())
        {
            conn.Open();
            string sql = @"INSERT INTO Interacoes (ChamadoId, Texto, Data, UsuarioId)
                           VALUES (@chamadoId, @texto, @data, @userId)";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@chamadoId", i.ChamadoId);
                cmd.Parameters.AddWithValue("@texto", i.Texto);
                cmd.Parameters.AddWithValue("@data", i.Data);
                cmd.Parameters.AddWithValue("@userId", i.UsuarioId);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static List<Interacao> ListarPorChamado(int chamadoId)
    {
        // Se estiver em modo in-memory, usa dados em memória
        if (Database.UsarModoInMemory)
        {
            return DatabaseInMemory.ListarInteracoesPorChamado(chamadoId);
        }

        // Tenta usar SQL Server
        var lista = new List<Interacao>();
        using (var conn = Database.GetConnection())
        {
            conn.Open();
            string sql = "SELECT * FROM Interacoes WHERE ChamadoId = @id ORDER BY Data";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", chamadoId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Interacao
                        {
                            Id = (int)reader["Id"],
                            ChamadoId = (int)reader["ChamadoId"],
                            Texto = (string)reader["Texto"],
                            Data = (DateTime)reader["Data"],
                            UsuarioId = (int)reader["UsuarioId"]
                        });
                    }
                }
            }
        }
        return lista;
    }
}