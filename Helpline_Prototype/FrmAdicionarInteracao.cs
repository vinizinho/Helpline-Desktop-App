using System;
using System.Drawing;
using System.Windows.Forms;

public partial class FrmAdicionarInteracao : Form
{
    private ComboBox cmbChamados;
    private TextBox txtInteracao;
    private Button btnAdicionar;
    private int usuarioLogadoId;

    public FrmAdicionarInteracao(int userId)
    {
        usuarioLogadoId = userId;
        Text = "Adicionar Interação";
        Size = new Size(500, 300);

        var lblChamado = new Label
        {
            Text = "Chamado:",
            Top = 20,
            Left = 20,
            AutoSize = true
        };

        cmbChamados = new ComboBox
        {
            Top = 20,
            Left = 100,
            Width = 350
        };

        var lblInteracao = new Label
        {
            Text = "Interação:",
            Top = 60,
            Left = 20,
            AutoSize = true
        };

        txtInteracao = new TextBox
        {
            Top = 60,
            Left = 100,
            Width = 350,
            Height = 120,
            Multiline = true,
            PlaceholderText = "Descreva a interação ou atualização do chamado..."
        };

        btnAdicionar = new Button
        {
            Text = "Adicionar Interação",
            Size = new Size(150, 35),
            Top = 200,
            Left = 100
        };
        btnAdicionar.Click += BtnAdicionar_Click;

        Load += FrmAdicionarInteracao_Load;

        Controls.Add(lblChamado);
        Controls.Add(cmbChamados);
        Controls.Add(lblInteracao);
        Controls.Add(txtInteracao);
        Controls.Add(btnAdicionar);
    }

    private void FrmAdicionarInteracao_Load(object sender, EventArgs e)
    {
        try
        {
            var chamados = ChamadoDAO.Listar().FindAll(c => c.Status != "Fechado");
            
            if (chamados.Count == 0)
            {
                MessageBox.Show("Não há chamados abertos para adicionar interações.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    private void BtnAdicionar_Click(object sender, EventArgs e)
    {
        if (cmbChamados.SelectedValue == null)
        {
            MessageBox.Show("Por favor, selecione um chamado.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrWhiteSpace(txtInteracao.Text))
        {
            MessageBox.Show("Por favor, descreva a interação.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtInteracao.Focus();
            return;
        }

        try
        {
            var interacao = new Interacao
            {
                ChamadoId = (int)cmbChamados.SelectedValue,
                Texto = txtInteracao.Text.Trim(),
                Data = DateTime.Now,
                UsuarioId = usuarioLogadoId
            };

            InteracaoDAO.Inserir(interacao);
            MessageBox.Show("Interação adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Limpa o campo de interação, mas mantém o chamado selecionado
            txtInteracao.Clear();
            txtInteracao.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao adicionar interação: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

