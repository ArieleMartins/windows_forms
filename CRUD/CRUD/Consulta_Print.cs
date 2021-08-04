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
    public partial class Consulta_Print : Form
    {
        private string[] dados = new string[3];
        private string usuario;
        private string privi;

        private string cpf;
        private string nome;
        private string admi;
        private string tel;
        private string cel;
        private string cidade;
        private string est;
        private string cargo;
        private string dep;
        private string salario;
        private string email;
        private string funcao;
        private string foto;
        private string curso;
        private string hora;
        private string turma;
        private string responsavel;
        private string matricula;
        public Consulta_Print()
        {
            InitializeComponent();
        }

        private void Consulta_Print_Load(object sender, EventArgs e)
        {
            rdFunc.Checked = true;
        }

        public string Privi
        {
            set { this.privi = value; }
        }
        public string Usuario
        {
            set { this.usuario = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Usuario = usuario;
            menu.Privi = privi;
            this.Hide();
            menu.ShowDialog();
        }

        private void btImprimi_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text) || String.IsNullOrWhiteSpace(txtCpf.Text))
            {
                MessageBox.Show("Preeencha os campos obrigatorios", "Campos obrigatorios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (rdAluno.Checked)
                {
                    BD bd = new BD();
                    bd.Nome = txtNome.Text;
                    bd.Cpf = txtCpf.Text;
                    bd.ConsTu();
                    if (bd.Tabela.Read())
                    {
                        nome = bd.Tabela["nome_a"].ToString();
                        cpf = bd.Tabela["cpf_a"].ToString();
                        cidade = bd.Tabela["cidade_a"].ToString();
                        matricula = DateTime.Parse(bd.Tabela["matri_a"].ToString()).Date.ToString("d/MM/yyyy");
                        est = bd.Tabela["nome_est"].ToString();
                        curso = bd.Tabela["nome_c"].ToString();
                        turma = bd.Tabela["nome_t"].ToString();
                        hora = bd.Tabela["hora_h"].ToString();
                        cel = bd.Tabela["cel_a"].ToString();
                        tel = bd.Tabela["tel_a"].ToString();
                        email = bd.Tabela["email_a"].ToString();
                        responsavel = bd.Tabela["resp_a"].ToString();
                        print.Document = imprimirDocumento;
                        print.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Aluno não cadastrado!", "Sem Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (rdFunc.Checked)
                {
                    BD bd = new BD();
                    bd.Nome = txtNome.Text;
                    bd.Cpf = txtCpf.Text;
                    bd.ImprimiFunc();
                    if (bd.Tabela.Read())
                    {
                        nome = bd.Tabela["nome_func"].ToString();
                        cpf = bd.Tabela["cpf_func"].ToString();
                        cidade = bd.Tabela["cidade_func"].ToString();
                        admi = DateTime.Parse(bd.Tabela["admi_func"].ToString()).Date.ToString("d/MM/yyyy");
                        est = bd.Tabela["nome_est"].ToString();
                        cargo = bd.Tabela["nome_car"].ToString();
                        dep = bd.Tabela["nome_dep"].ToString();
                        funcao = bd.Tabela["func_func"].ToString();
                        cel = bd.Tabela["cel_func"].ToString();
                        tel = bd.Tabela["tel_func"].ToString();
                        email = bd.Tabela["email_func"].ToString();
                        foto = bd.Tabela["foto_func"].ToString();
                        printFunc.Document = ImprimirDocument2;
                        printFunc.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Funcionario não cadastrado!", "Sem Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
               
            }
        }

        private void imprimirDocumento_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap img = Properties.Resources.LogoImprimir;
            Image imagem = img;
            e.Graphics.DrawImage(imagem, 150, 0, imagem.Width, imagem.Height);
            Font letra = new Font("Arial", 16, FontStyle.Regular);
            Brush pincel = new SolidBrush(Color.Black);
            e.Graphics.DrawString(label4.Text, new Font("Arial", 20, FontStyle.Regular), pincel, new Point(0, 160));
            e.Graphics.DrawString("Nome: " + nome + "                                               CPF: " + cpf, letra, pincel, new Point(0,200));
            e.Graphics.DrawString("Responsavel: " + responsavel, letra, pincel, new Point(0, 240));
            e.Graphics.DrawString("Cidade: " + cidade + "                                         Estado: " + est, letra, pincel, new Point(0, 280));
            e.Graphics.DrawString("Curso: " + curso + "                     Turma: " + turma, letra, pincel, new Point(0, 320));
            e.Graphics.DrawString("Hora: " + hora, letra, pincel, new Point(0, 350));
            e.Graphics.DrawString("Matricula: " + matricula, letra, pincel, new Point(0, 390));
            e.Graphics.DrawString("Cel: " + cel + "                                               Tel: " + tel, letra, pincel, new Point(0, 430));
            e.Graphics.DrawString("Email: " + email, letra, pincel, new Point(0, 470));
            e.Graphics.DrawString(label4.Text, new Font("Arial", 20, FontStyle.Regular), pincel, new Point(0, 510));
            e.Graphics.DrawString("Data da Impressão: " + DateTime.Now, letra, pincel, new Point(0, 1110));




        }

        private void ImprimirDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap img = Properties.Resources.LogoImprimir;
            Image imagem = img;
            e.Graphics.DrawImage(imagem, 150, 0, imagem.Width, imagem.Height);
            Font letra = new Font("Arial", 16, FontStyle.Regular);
            Brush pincel = new SolidBrush(Color.Black);
            e.Graphics.DrawString(label4.Text, new Font("Arial", 20, FontStyle.Regular), pincel, new Point(0, 160));
            e.Graphics.DrawString("Nome: " + nome + "                            CPF: " + cpf, letra, pincel, new Point(0, 200));
            e.Graphics.DrawString("Cidade: " + cidade + "                                                           Estado: " + est, letra, pincel, new Point(0, 240));
            e.Graphics.DrawString("Cargo: " + cargo + "                                           Departamento: " + dep, letra, pincel, new Point(0, 280));
            e.Graphics.DrawString("Função: " + funcao, letra, pincel, new Point(0, 320));
            e.Graphics.DrawString("Data de Admissão: " + admi, letra, pincel, new Point(0, 390));
            e.Graphics.DrawString("Cel: " + cel + "                                              Tel: " + tel, letra, pincel, new Point(0, 430));
            e.Graphics.DrawString("Email: " + email, letra, pincel, new Point(0, 470));
            e.Graphics.DrawString(label4.Text, new Font("Arial", 20, FontStyle.Regular), pincel, new Point(0, 510));
            e.Graphics.DrawString("Data da Impressão: " + DateTime.Now.ToString("d/MM/yyyy"), letra, pincel, new Point(0, 1110));
        }
    }
}
