using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

public partial class FrmTrilha : Form
{
    private ComboBox cmbChamados;
    private TextBox txtTrilha;

    public FrmTrilha()
    {
        Text = "Trilha de Interações";
        Size = new Size(600, 400);

        cmbChamados = new ComboBox { Top = 20, Left = 20, Width = 300 };
        txtTrilha = new TextBox { Top = 60, Left = 20, Width = 500, Height = 300, Multiline = true, ScrollBars = ScrollBars.Vertical, ReadOnly = true };

        Load += FrmTrilha_Load;
        cmbChamados.SelectedIndexChanged += CmbChamados_SelectedIndexChanged;

        Controls.Add(cmbChamados);
        Controls.Add(txtTrilha);
    }

    private void FrmTrilha_Load(object sender, EventArgs e)
    {
        try
        {
            var chamados = ChamadoDAO.Listar();
            
            if (chamados.Count == 0)
            {
                txtTrilha.Text = "Não há chamados cadastrados.";
                return;
            }

            cmbChamados.DataSource = chamados;
            cmbChamados.DisplayMember = "Titulo";
            cmbChamados.ValueMember = "Id";
            
            // Carrega o primeiro chamado automaticamente
            if (chamados.Count > 0)
            {
                CarregarTrilha((int)cmbChamados.SelectedValue);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar chamados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtTrilha.Text = "Erro ao carregar dados.";
        }
    }

    private void CmbChamados_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbChamados.SelectedValue == null) return;
        
        try
        {
            CarregarTrilha((int)cmbChamados.SelectedValue);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar trilha: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CarregarTrilha(int chamadoId)
    {
        var chamado = ChamadoDAO.Listar().Find(c => c.Id == chamadoId);
        if (chamado == null)
        {
            txtTrilha.Text = "Chamado não encontrado.";
            return;
        }

        var interacoes = InteracaoDAO.ListarPorChamado(chamadoId);

        var sb = new StringBuilder();
        sb.AppendLine($"═══════════════════════════════════════");
        sb.AppendLine($"CHAMADO: {chamado.Titulo}");
        sb.AppendLine($"═══════════════════════════════════════");
        sb.AppendLine($"ID: #{chamado.Id}");
        sb.AppendLine($"Descrição: {chamado.Descricao}");
        sb.AppendLine($"Aberto em: {chamado.DataAbertura:dd/MM/yyyy HH:mm:ss}");
        sb.AppendLine($"Status: {chamado.Status}");
        if (chamado.DataFechamento.HasValue)
        {
            sb.AppendLine($"Fechado em: {chamado.DataFechamento.Value:dd/MM/yyyy HH:mm:ss}");
        }
        sb.AppendLine($"");
        sb.AppendLine($"═══════════════════════════════════════");
        sb.AppendLine($"TRILHA DE INTERAÇÕES");
        sb.AppendLine($"═══════════════════════════════════════");
        
        if (interacoes.Count == 0)
        {
            sb.AppendLine("Nenhuma interação registrada ainda.");
        }
        else
        {
            foreach (var i in interacoes)
            {
                sb.AppendLine($"[{i.Data:dd/MM/yyyy HH:mm:ss}] Usuário #{i.UsuarioId}:");
                sb.AppendLine($"  {i.Texto}");
                sb.AppendLine();
            }
        }

        txtTrilha.Text = sb.ToString();
    }
}