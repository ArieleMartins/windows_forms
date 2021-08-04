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

namespace CRUD
{
    public partial class Consulta_func : Form
    {
        private string[] dados = new string[7];
        private string usuario;
        public Consulta_func()
        {
            InitializeComponent();
        }

        private void Consulta_func_Load(object sender, EventArgs e)
        {
            BD bd = new BD();
            bd.Lista();

            while (bd.Tabela.Read())
            {
                dados[0] = bd.Tabela["id_func"].ToString();
                dados[1] = bd.Tabela["nome_func"].ToString();
                dados[2] = bd.Tabela["nome_car"].ToString();
                dados[3] = bd.Tabela["nome_dep"].ToString();
                dados[4] = bd.Tabela["salario_func"].ToString();
                dados[5] = bd.Tabela["cpf_func"].ToString();
                if(bd.Tabela["id_log"].ToString() == "")
                {
                    dados[6] = "";
                }
                else
                {
                    dados[6] = bd.Tabela["usuario_log"].ToString();
                }
                ListViewItem lista = new ListViewItem(dados);
                Lista1.Items.Add(lista);
            }
            bd.Tabela.Close();
        }
        private void Lista1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Lista1.SelectedItems.Count > 0)
            {
                txtID.Text = Lista1.SelectedItems[0].SubItems[0].Text;
                txtCPF.Text = Lista1.SelectedItems[0].SubItems[5].Text;
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Usuario = usuario;
            this.Hide();
            menu.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem buscar in Lista1.Items)
            {
                if(txtID.Text == buscar.SubItems[0].Text)
                {
                    
                        buscar.Selected = true;
                        Lista1.Focus();
                        Lista1.TopItem = buscar;
                        break;
                    
                }
                else
                {
                    txtCPF.Clear();
                    buscar.Selected = false;
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem buscar in Lista1.Items)
            {
                if (txtCPF.Text.ToUpper() == buscar.SubItems[5].Text.ToUpper())
                {
                    
                    buscar.Selected = true;
                    Lista1.Focus();
                    break;
                }
                    
            }
            
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtID.Text) && String.IsNullOrWhiteSpace(txtCPF.Text))
            {
                MessageBox.Show("É preciso informar o ID e CPF do funcionario para consultar os dados do mesmo", "Campos Necessarios", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                BD bd = new BD();
                bd.Id = int.Parse(txtID.Text);
                bd.Cpf = txtCPF.Text;
                bd.Consultar();
                if (bd.Tabela.HasRows)
                {
                    if (bd.Tabela.Read())
                    {
                        if (bd.Tabela["usuario_log"].ToString() != "" && bd.Tabela["senha_log"].ToString() != "")
                        {
                            Consulta_funcesp funcionario = new Consulta_funcesp();
                            funcionario.Usuario = usuario;
                            funcionario.Cpf = txtCPF.Text;
                            funcionario.Id = int.Parse(txtID.Text);
                            bd.Tabela.Close();
                            bd.Conexao.Close();
                            this.Hide();
                            funcionario.ShowDialog();
                        }
                        else if(bd.Tabela["usuario_log"].ToString() == "" && bd.Tabela["senha_log"].ToString() == "")
                        {
                            Consulta_funcesp2 usu = new Consulta_funcesp2();
                            usu.Usuario = usuario;
                            usu.Cpf = txtCPF.Text;
                            usu.Id = int.Parse(txtID.Text);
                            bd.Tabela.Close();
                            bd.Conexao.Close();
                            this.Hide();
                            usu.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Funcionario não encontrado");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Funcionario não encontrado!");
                    }
                }
                else
                {
                    MessageBox.Show("Funcionario não encontrado!");
                }
            }
        }
        public string Usu
        {
            set { this.usuario = value; }
        }
    }
}
