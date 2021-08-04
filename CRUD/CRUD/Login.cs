using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Login : Form
    {
        private string usuario;
        private string senha;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            BD bd = new BD();
            bd.UsuarioLog = txtUsuario.Text;
            bd.SenhaLog = txtSenha.Text;
            if (String.IsNullOrWhiteSpace(txtSenha.Text) || String.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Preeencha os campos para pode fazer o acesso", "Campos obrigatorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                bd.Logar();
                try
                {
                    if (bd.Tabela.HasRows)
                    {
                        if (bd.Tabela.Read())
                        {
                            
                            if (bd.Tabela["id_privi"].ToString() != "")
                            {
                                Menu menu = new Menu();
                                menu.Usuario = txtUsuario.Text;
                                menu.Senha = txtSenha.Text;
                                menu.Privi = bd.Tabela["id_privi"].ToString();
                                this.Hide();
                                menu.ShowDialog();
                            }
                           // else if (bd.Tabela["id_privi"].ToString() == "2")
                           // {
                               // Menu_Usu usuario = new Menu_Usu();
                               // usuario.Usuario = txtUsuario.Text;
                               // this.Hide();
                               // usuario.ShowDialog();
                           // }
                            else
                            {
                                MessageBox.Show("Usuário não possui autorização para acessar essa aplicação!!", "Negado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }

                        else
                        {
                            MessageBox.Show("Usuário não encontrado!", "Sem cadastro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado!", "Sem cadastro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch (System.NullReferenceException err)
                {
                    MessageBox.Show("Não foi possivel fazer login.     " + err);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        public string Usuario
        {
            set { this.usuario = value; }
        }
        public string Senha
        {
            set { this.senha = value; }
        }
    }
}
