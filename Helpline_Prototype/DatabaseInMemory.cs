using System;
using System.Collections.Generic;
using System.Linq;

// Repositório em memória para desenvolvimento sem SQL Server
public static class DatabaseInMemory
{
    private static List<Usuario> _usuarios = new List<Usuario>();
    private static List<Chamado> _chamados = new List<Chamado>();
    private static List<Interacao> _interacoes = new List<Interacao>();
    
    private static int _nextUsuarioId = 1;
    private static int _nextChamadoId = 1;
    private static int _nextInteracaoId = 1;

    // Usuários
    public static void InserirUsuario(Usuario u)
    {
        u.Id = _nextUsuarioId++;
        _usuarios.Add(u);
    }

    public static List<Usuario> ListarUsuarios()
    {
        return new List<Usuario>(_usuarios);
    }

    // Chamados
    public static int InserirChamado(Chamado c)
    {
        c.Id = _nextChamadoId++;
        _chamados.Add(c);
        return c.Id;
    }

    public static List<Chamado> ListarChamados()
    {
        return new List<Chamado>(_chamados);
    }

    public static void FecharChamado(int chamadoId, string textoFinal, int usuarioId)
    {
        var chamado = _chamados.FirstOrDefault(c => c.Id == chamadoId);
        if (chamado != null)
        {
            chamado.Status = "Fechado";
            chamado.DataFechamento = DateTime.Now;
            
            // Adiciona interação final
            var interacao = new Interacao
            {
                Id = _nextInteracaoId++,
                ChamadoId = chamadoId,
                Texto = textoFinal,
                Data = DateTime.Now,
                UsuarioId = usuarioId
            };
            _interacoes.Add(interacao);
        }
    }

    // Interações
    public static void InserirInteracao(Interacao i)
    {
        i.Id = _nextInteracaoId++;
        _interacoes.Add(i);
    }

    public static List<Interacao> ListarInteracoesPorChamado(int chamadoId)
    {
        return _interacoes.Where(i => i.ChamadoId == chamadoId)
                        .OrderBy(i => i.Data)
                        .ToList();
    }

    // Limpar todos os dados (útil para testes)
    public static void Limpar()
    {
        _usuarios.Clear();
        _chamados.Clear();
        _interacoes.Clear();
        _nextUsuarioId = 1;
        _nextChamadoId = 1;
        _nextInteracaoId = 1;
    }
}

