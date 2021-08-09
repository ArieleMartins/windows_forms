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
    public partial class Consultar_alunos : Form
    {
        private string[] alunos = new string[5];
        private string usuario;
        private string senha;
        private string privi;
        public Consultar_alunos()
        {
            InitializeComponent();
        }

        private void Consultar_alunos_Load(object sender, EventArgs e)
        {
            BD bd = new BD();
            bd.ConsTu();
            while (bd.Tabela.Read())
            {
                alunos[0] = bd.Tabela["id_aluno"].ToString();
                alunos[1] = bd.Tabela["nome_a"].ToString();
                alunos[2] = bd.Tabela["nome_c"].ToString();
                alunos[3] = bd.Tabela["nome_t"].ToString();
                alunos[4] = bd.Tabela["cpf_a"].ToString();
                ListViewItem lista = new ListViewItem(alunos);
                Lista1.Items.Add(lista);
            }
            bd.Tabela.Close();
        }

        private void Lista1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Lista1.SelectedItems.Count > 0)
            {
                txtID.Text = Lista1.SelectedItems[0].SubItems[0].Text;
                maskCPF.Text = Lista1.SelectedItems[0].SubItems[4].Text;
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem buscar in Lista1.Items)
            {
                if (txtID.Text == buscar.SubItems[0].Text)
                {

                    buscar.Selected = true;
                    Lista1.Focus();
                    Lista1.TopItem = buscar;
                    break;

                }
                else
                {
                    maskCPF.Clear();
                    buscar.Selected = false;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem buscar in Lista1.Items)
            {
                if (maskCPF.Text.ToUpper() == buscar.SubItems[4].Text.ToUpper())
                {

                    buscar.Selected = true;
                    Lista1.Focus();
                    break;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtID.Text) && String.IsNullOrWhiteSpace(maskCPF.Text))
                {
                    MessageBox.Show("É preciso informar o ID e CPF do aluno para consultar os dados do mesmo", "Campos Necessarios", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    BD bd = new BD();
                    bd.IdAluno = int.Parse(txtID.Text);
                    bd.Cpf = maskCPF.Text;
                    bd.ConsAlu();
                    if (bd.Tabela.HasRows)
                    {
                        if (bd.Tabela.Read())
                        {

                            Consulta_aluno aluno = new Consulta_aluno();
                            aluno.Usuario = usuario;
                            aluno.Privi = privi;
                            aluno.Cpf = maskCPF.Text;
                            aluno.Id = int.Parse(txtID.Text);
                            bd.Tabela.Close();
                            bd.Conexao.Close();
                            this.Hide();
                            aluno.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("Aluno não encontrado!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aluno não encontrado!");
                    }
                }
            }catch(System.FormatException err)
            {
                MessageBox.Show("É preciso informar o ID e CPF do aluno para consultar os dados do mesmo", "Campos Necessarios", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void btSair_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Usuario = usuario;
            menu.Privi = privi;
            menu.Senha = senha;
            this.Hide();
            menu.ShowDialog();
        }
        public string Usuario
        {
            set { this.usuario = value; }
        }
        public string Privi
        {
            set { this.privi = value; }
        }
        public string Senha
        {
            set { this.senha = value; }
        }
    }
}
