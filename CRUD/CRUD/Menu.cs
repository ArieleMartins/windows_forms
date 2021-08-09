using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace CRUD
{
    public partial class Menu : Form
    {
        Image btaddnormal;
        Image btaddmouse;
        Image btconsnormal;
        Image btconsmouse;
        private string usuario;
        private string nomeusuario;
        private string privi;
        private string login;
        private string senha;
        public Menu()
        {
            InitializeComponent();
            btaddnormal = Properties.Resources.Botao_adicionar;
            btaddmouse = Properties.Resources.botao_adicionar_brilhante;
            btconsnormal = Properties.Resources.Botao_consulta;
            btconsmouse = Properties.Resources.Botao_consulta_bilhante;
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            try
            {
                ptAddCli.Image = btaddnormal;
                ptCoCli.Image = btconsnormal;
                ptAddFunc.Image = btaddnormal;
                ptCoFunc.Image = btconsnormal;
                Horario.Text = DateTime.Now.ToString();
                timer1.Enabled = true;
                nomeusuario = "Olá, " + usuario.ToUpper();
                lblUsuario.Text = nomeusuario;
                if(privi == "1")
                {
                    gpCli.Visible = true;
                    gpFunc.Visible = true;
                    funcionarios.Visible = true;
                }else if(privi == "2")
                {
                    gpCli.Visible = true;
                    gpFunc.Visible = false;
                    funcionarios.Visible = false;
                }

            }
            catch (System.NullReferenceException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Horario.Text = DateTime.Now.ToString();
        }



        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Deseja fechar a aplicação?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Deseja trocar de usuário?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
            {
                Login login = new Login();
                login.Usuario = usuario;
                login.Senha = senha;
                this.Hide();
                login.ShowDialog();
            }
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cadastro_Func funcionario = new Cadastro_Func();
            lblUsuario.Text = "";
            funcionario.Usuario = usuario;
            funcionario.Senha = senha;
            this.Hide();
            funcionario.ShowDialog();
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Consulta_func consulta = new Consulta_func();
            consulta.Usu = usuario;
            consulta.Senha = senha;
            this.Hide();
            consulta.ShowDialog();
        }
        public string Usuario
        {
            set {this.usuario = value; }
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastro_aluno aluno = new Cadastro_aluno();
            aluno.Login = usuario;
            aluno.Senha = senha;
            aluno.Privi = privi;
            this.Hide();
            aluno.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultar_alunos consulta = new Consultar_alunos();
            consulta.Usuario = usuario;
            consulta.Senha = senha;
            consulta.Privi = privi;
            this.Hide();
            consulta.ShowDialog();
        }
        public string Privi
        {
            set { this.privi = value; }
        }
        public string Senha
        {
            set { this.senha = value; }
        }


        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consulta_Print imprimir = new Consulta_Print();
            imprimir.Privi = privi;
            imprimir.Usuario = usuario;
            imprimir.Senha = senha;
            this.Hide();
            imprimir.ShowDialog();
        }

        private void navegadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
                Process.Start("chrome.exe");
            }catch (System.ComponentModel.Win32Exception err)
            {
                MessageBox.Show("Aplicação não encontrada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("winword");
            }catch (System.ComponentModel.Win32Exception err)
            {
                MessageBox.Show("Aplicação não encontrada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
                Process.Start("excel");
            }catch (System.ComponentModel.Win32Exception err)
            {
                MessageBox.Show("Aplicação não encontrada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void powerPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
                Process.Start("ppsx");
            }catch (System.ComponentModel.Win32Exception err)
            {
                MessageBox.Show("Aplicação não encontrada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void blocoDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
                Process.Start("notepad");
            }catch (System.ComponentModel.Win32Exception err)
            {
                MessageBox.Show("Aplicação não encontrada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try { 
                Process.Start("calc");
            }catch (System.ComponentModel.Win32Exception err)
            {
                MessageBox.Show("Aplicação não encontrada", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void ptCoFunc_MouseEnter_1(object sender, EventArgs e)
        {
            ptCoFunc.Image = btconsmouse;
        }

        private void ptCoFunc_MouseLeave(object sender, EventArgs e)
        {
            ptCoFunc.Image = btconsnormal;
        }

        private void ptAddFunc_MouseEnter(object sender, EventArgs e)
        {
            ptAddFunc.Image = btaddmouse;
        }

        private void ptAddFunc_MouseLeave(object sender, EventArgs e)
        {
            ptAddFunc.Image = btaddnormal;
        }

        private void ptCoCli_MouseEnter(object sender, EventArgs e)
        {
            ptCoCli.Image = btconsmouse;
        }

        private void ptCoCli_MouseLeave(object sender, EventArgs e)
        {
            ptCoCli.Image = btconsnormal;
        }

        private void ptAddCli_MouseEnter(object sender, EventArgs e)
        {
            ptAddCli.Image = btaddmouse;
        }

        private void ptAddCli_MouseLeave(object sender, EventArgs e)
        {
            ptAddCli.Image = btaddnormal;
        }

        private void ptAddCli_Click_1(object sender, EventArgs e)
        {
            Cadastro_aluno aluno = new Cadastro_aluno();
            aluno.Login = usuario;
            aluno.Senha = senha;
            aluno.Privi = privi;
            this.Hide();
            aluno.ShowDialog();
        }

        private void ptCoCli_Click_1(object sender, EventArgs e)
        {
            Consultar_alunos alunos = new Consultar_alunos();
            alunos.Usuario = usuario;
            alunos.Privi = privi;
            alunos.Senha = senha;
            this.Hide();
            alunos.ShowDialog();
        }

        private void ptAddFunc_Click_1(object sender, EventArgs e)
        {
            Cadastro_Func funcionario = new Cadastro_Func();
            funcionario.Usuario = usuario;
            funcionario.Senha = senha;
            this.Hide();
            funcionario.ShowDialog();
        }

        private void ptCoFunc_Click(object sender, EventArgs e)
        {
            Consulta_func consulta = new Consulta_func();
            consulta.Usu = usuario;
            consulta.Senha = senha;
            consulta.Privi = privi;
            this.Hide();
            consulta.ShowDialog();
        }
    }
}
