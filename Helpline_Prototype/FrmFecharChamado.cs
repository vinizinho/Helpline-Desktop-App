using System;
using System.Drawing;
using System.Windows.Forms;

public partial class FrmFecharChamado : Form
{
    private ComboBox cmbChamados;
    private TextBox txtSolucao;
    private Button btnFechar;
    private int usuarioLogadoId;

    public FrmFecharChamado(int userId)
    {
        usuarioLogadoId = userId;
        Text = "Fechar Chamado";
        Size = new Size(400, 250);

        cmbChamados = new ComboBox { Top = 20, Left = 20, Width = 300 };
        txtSolucao = new TextBox { Top = 60, Left = 20, Width = 300, Height = 100, Multiline = true, PlaceholderText = "Descreva a solução aplicada..." };
        btnFechar = new Button { Text = "Fechar Chamado", Top = 170, Left = 20 };

        Load += FrmFecharChamado_Load;
        btnFechar.Click += BtnFechar_Click;

        Controls.Add(cmbChamados);
        Controls.Add(txtSolucao);
        Controls.Add(btnFechar);
    }

    private void FrmFecharChamado_Load(object sender, EventArgs e)
    {
        try
        {
            var chamados = ChamadoDAO.Listar().FindAll(c => c.Status != "Fechado");
            
            if (chamados.Count == 0)
            {
                MessageBox.Show("Não há chamados abertos para fechar.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            cmbChamados.DataSource = chamados;
            cmbChamados.DisplayMember = "Titulo";
            cmbChamados.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar chamados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }
    }

    private void BtnFechar_Click(object sender, EventArgs e)
    {
        if (cmbChamados.SelectedValue == null)
        {
            MessageBox.Show("Por favor, selecione um chamado.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSolucao.Text))
        {
            MessageBox.Show("Por favor, descreva a solução aplicada.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSolucao.Focus();
            return;
        }

        try
        {
            int id = (int)cmbChamados.SelectedValue;
            ChamadoDAO.Fechar(id, txtSolucao.Text.Trim(), usuarioLogadoId);
            MessageBox.Show("Chamado fechado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao fechar chamado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}