using System;
using System.Drawing;
using System.Windows.Forms;

public partial class FrmCadastroUsuario : Form
{
    private TextBox txtNome, txtEmail, txtSenha;
    private Button btnSalvar;

    public FrmCadastroUsuario()
    {
        Text = "Cadastro de Usuário";
        Size = new Size(300, 200);
        
        txtNome = new TextBox { PlaceholderText = "Nome", Top = 20, Left = 20, Width = 200 };
        txtEmail = new TextBox { PlaceholderText = "Email", Top = 50, Left = 20, Width = 200 };
        txtSenha = new TextBox { PlaceholderText = "Senha", Top = 80, Left = 20, Width = 200, PasswordChar = '*' };
        btnSalvar = new Button { Text = "Salvar", Top = 110, Left = 20 };

        btnSalvar.Click += BtnSalvar_Click;

        Controls.Add(txtNome);
        Controls.Add(txtEmail);
        Controls.Add(txtSenha);
        Controls.Add(btnSalvar);
    }

    private void BtnSalvar_Click(object sender, EventArgs e)
    {
        // Validações
        if (string.IsNullOrWhiteSpace(txtNome.Text))
        {
            MessageBox.Show("Por favor, preencha o nome.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNome.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtEmail.Text))
        {
            MessageBox.Show("Por favor, preencha o email.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtEmail.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txtSenha.Text))
        {
            MessageBox.Show("Por favor, preencha a senha.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSenha.Focus();
            return;
        }

        if (txtSenha.Text.Length < 3)
        {
            MessageBox.Show("A senha deve ter pelo menos 3 caracteres.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtSenha.Focus();
            return;
        }

        try
        {
            var u = new Usuario
            {
                Nome = txtNome.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Senha = txtSenha.Text // Hash antes de salvar
            };
            UsuarioDAO.Inserir(u);
            MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Limpa os campos
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtNome.Focus();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao cadastrar usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}