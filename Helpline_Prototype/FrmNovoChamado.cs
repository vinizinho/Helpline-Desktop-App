using System;
using System.Drawing;
using System.Windows.Forms;

public partial class FrmNovoChamado : Form
{
    private TextBox txtTitulo, txtDesc;
    private Button btnSalvar;
    private int usuarioLogadoId;

    public FrmNovoChamado(int userId)
    {
        usuarioLogadoId = userId;
        Text = "Novo Chamado";
        Size = new Size(400, 250);

        txtTitulo = new TextBox { PlaceholderText = "Título", Top = 20, Left = 20, Width = 300 };
        txtDesc = new TextBox { PlaceholderText = "Descrição", Top = 60, Left = 20, Width = 300, Height = 100, Multiline = true };
        btnSalvar = new Button { Text = "Abrir Chamado", Top = 170, Left = 20 };

        btnSalvar.Click += BtnSalvar_Click;

        Controls.Add(txtTitulo);
        Controls.Add(txtDesc);
        Controls.Add(btnSalvar);
    }

    private void BtnSalvar_Click(object sender, EventArgs e)
    {
        // Validações
        if (string.IsNullOrWhiteSpace(txtTitulo.Text))
        {
            MessageBox.Show("Por favor, preencha o título do chamado.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtTitulo.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtDesc.Text))
        {
            MessageBox.Show("Por favor, preencha a descrição do chamado.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDesc.Focus();
            return;
        }

        try
        {
            var c = new Chamado
            {
                Titulo = txtTitulo.Text.Trim(),
                Descricao = txtDesc.Text.Trim(),
                UsuarioId = usuarioLogadoId
            };
            int id = ChamadoDAO.Abrir(c);
            MessageBox.Show($"Chamado #{id} aberto com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Limpa os campos
            txtTitulo.Clear();
            txtDesc.Clear();
            txtTitulo.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao abrir chamado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}