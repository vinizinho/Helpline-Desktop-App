using System;
using System.Drawing;
using System.Windows.Forms;

public partial class FrmPrincipal : Form
{
    private Button btnCadastrarUsuario;
    private Button btnNovoChamado;
    private Button btnFecharChamado;
    private Button btnAdicionarInteracao;
    private Button btnTrilha;
    private Label lblTitulo;
    private int usuarioLogadoId = 1; // Por padrão, usuário ID 1

    public FrmPrincipal()
    {
        Text = "Sistema Help Desk - Menu Principal";
        Size = new Size(400, 350);
        StartPosition = FormStartPosition.CenterScreen;

        lblTitulo = new Label
        {
            Text = "Sistema Help Desk",
            Font = new Font("Arial", 16, FontStyle.Bold),
            AutoSize = true,
            Top = 20,
            Left = 120
        };

        btnCadastrarUsuario = new Button
        {
            Text = "Cadastrar Usuário",
            Size = new Size(200, 40),
            Top = 70,
            Left = 100
        };
        btnCadastrarUsuario.Click += BtnCadastrarUsuario_Click;

        btnNovoChamado = new Button
        {
            Text = "Novo Chamado",
            Size = new Size(200, 40),
            Top = 120,
            Left = 100
        };
        btnNovoChamado.Click += BtnNovoChamado_Click;

        btnFecharChamado = new Button
        {
            Text = "Fechar Chamado",
            Size = new Size(200, 40),
            Top = 170,
            Left = 100
        };
        btnFecharChamado.Click += BtnFecharChamado_Click;

        btnAdicionarInteracao = new Button
        {
            Text = "Adicionar Interação",
            Size = new Size(200, 40),
            Top = 220,
            Left = 100
        };
        btnAdicionarInteracao.Click += BtnAdicionarInteracao_Click;

        btnTrilha = new Button
        {
            Text = "Ver Trilha de Interações",
            Size = new Size(200, 40),
            Top = 270,
            Left = 100
        };
        btnTrilha.Click += BtnTrilha_Click;

        Controls.Add(lblTitulo);
        Controls.Add(btnCadastrarUsuario);
        Controls.Add(btnNovoChamado);
        Controls.Add(btnFecharChamado);
        Controls.Add(btnAdicionarInteracao);
        Controls.Add(btnTrilha);
    }

    private void BtnCadastrarUsuario_Click(object sender, EventArgs e)
    {
        var form = new FrmCadastroUsuario();
        form.ShowDialog();
    }

    private void BtnNovoChamado_Click(object sender, EventArgs e)
    {
        var form = new FrmNovoChamado(usuarioLogadoId);
        form.ShowDialog();
    }

    private void BtnFecharChamado_Click(object sender, EventArgs e)
    {
        var form = new FrmFecharChamado(usuarioLogadoId);
        form.ShowDialog();
    }

    private void BtnAdicionarInteracao_Click(object sender, EventArgs e)
    {
        var form = new FrmAdicionarInteracao(usuarioLogadoId);
        form.ShowDialog();
    }

    private void BtnTrilha_Click(object sender, EventArgs e)
    {
        var form = new FrmTrilha();
        form.ShowDialog();
    }
}

