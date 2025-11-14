using System;
using System.Data.SqlClient;
using System.Collections.Generic;

public class ChamadoDAO
{
    public static int Abrir(Chamado c)
    {
        // Se estiver em modo in-memory, usa dados em memória
        if (Database.UsarModoInMemory)
        {
            return DatabaseInMemory.InserirChamado(c);
        }

        // Tenta usar SQL Server
        using (var conn = Database.GetConnection())
        {
            conn.Open();
            string sql = @"INSERT INTO Chamados (Titulo, Descricao, DataAbertura, Status, UsuarioId)
                           VALUES (@titulo, @desc, @abertura, @status, @userId);
                           SELECT SCOPE_IDENTITY();";
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@titulo", c.Titulo);
                cmd.Parameters.AddWithValue("@desc", c.Descricao);
                cmd.Parameters.AddWithValue("@abertura", c.DataAbertura);
                cmd.Parameters.AddWithValue("@status", c.Status);
                cmd.Parameters.AddWithValue("@userId", c.UsuarioId);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }

    public static List<Chamado> Listar()
    {
        // Se estiver em modo in-memory, usa dados em memória
        if (Database.UsarModoInMemory)
        {
            return DatabaseInMemory.ListarChamados();
        }

        // Tenta usar SQL Server
        var lista = new List<Chamado>();
        using (var conn = Database.GetConnection())
        {
            conn.Open();
            string sql = "SELECT * FROM Chamados";
            using (var cmd = new SqlCommand(sql, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new Chamado
                    {
                        Id = (int)reader["Id"],
                        Titulo = (string)reader["Titulo"],
                        Descricao = (string)reader["Descricao"],
                        DataAbertura = (DateTime)reader["DataAbertura"],
                        DataFechamento = reader["DataFechamento"] as DateTime?,
                        Status = (string)reader["Status"],
                        UsuarioId = (int)reader["UsuarioId"]
                    });
                }
            }
        }
        return lista;
    }

    public static void Fechar(int chamadoId, string textoFinal, int usuarioId)
    {
        // Se estiver em modo in-memory, usa dados em memória
        if (Database.UsarModoInMemory)
        {
            DatabaseInMemory.FecharChamado(chamadoId, textoFinal, usuarioId);
            return;
        }

        // Tenta usar SQL Server
        using (var conn = Database.GetConnection())
        {
            conn.Open();
            using (var tx = conn.BeginTransaction())
            {
                // 1. Atualiza status e data de fechamento
                string sqlUpdate = @"UPDATE Chamados 
                                     SET Status = 'Fechado', DataFechamento = @dataFechamento 
                                     WHERE Id = @id";
                using (var cmd = new SqlCommand(sqlUpdate, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@dataFechamento", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id", chamadoId);
                    cmd.ExecuteNonQuery();
                }

                // 2. Registra a interação final
                string sqlInsert = @"INSERT INTO Interacoes (ChamadoId, Texto, Data, UsuarioId)
                                     VALUES (@chamadoId, @texto, @data, @userId)";
                using (var cmd = new SqlCommand(sqlInsert, conn, tx))
                {
                    cmd.Parameters.AddWithValue("@chamadoId", chamadoId);
                    cmd.Parameters.AddWithValue("@texto", textoFinal);
                    cmd.Parameters.AddWithValue("@data", DateTime.Now);
                    cmd.Parameters.AddWithValue("@userId", usuarioId);
                    cmd.ExecuteNonQuery();
                }

                tx.Commit();
            }
        }
    }
}