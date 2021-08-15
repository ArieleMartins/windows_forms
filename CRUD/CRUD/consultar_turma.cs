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
    public partial class consultar_turma : Form
    {

        string[] dados = new string[3];
        private string privi;
        private string usuario;
        private string senha;
        private int idturma;
        private string nomet;
        public consultar_turma()
        {
            InitializeComponent();
        }

        private void consultar_turma_Load(object sender, EventArgs e)
        {
            BD bd = new BD();
            bd.consultaTurma();
            while (bd.Tabela.Read())
            {
                cbTurma.Items.Add(bd.Tabela["nome_t"].ToString());
                dados[0] = bd.Tabela["id_t"].ToString();
                dados[1] = bd.Tabela["nome_t"].ToString();
                dados[2] = bd.Tabela["hora_h"].ToString();
                ListViewItem lista = new ListViewItem(dados);
                listTurma.Items.Add(lista);
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem buscar in listTurma.Items)
            {
                if (txtId.Text == buscar.SubItems[0].Text)
                {

                    buscar.Selected = true;
                    listTurma.Focus();
                    listTurma.TopItem = buscar;
                    break;

                }
                else
                {

                    buscar.Selected = false;
                }
            }
            if(txtId.Text == "")
            {
                cbTurma.SelectedIndex = -1;
            }
        }


        private void btPesquisar_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem buscar in listTurma.Items)
            {
                if (cbTurma.SelectedItem.ToString().ToUpper() == buscar.SubItems[1].Text.ToUpper())
                {

                    buscar.Selected = true;
                    listTurma.Focus();
                    break;
                }

            }
        }
        public string Privi
        {
            set { this.privi = value; }
            get { return this.privi; }
        }
        public string Usuario
        {
            set { this.usuario = value; }
            get { return this.usuario; }
        } 
        public string Senha
        {
            set { this.senha = value; }
            get { return this.senha; }
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Privi = privi;
            menu.Usuario = usuario;
            menu.Senha = senha;
            this.Hide();
            menu.ShowDialog();
        }

        private void btConsultar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(txtId.Text) || cbTurma.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha os campos ID e turma para realizar a consulta", "Campo Obrigatorios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                idturma = int.Parse(txtId.Text);
                nomet = cbTurma.SelectedItem.ToString();
                consulta_turmaexp turma = new consulta_turmaexp();
                turma.Privi = privi;
                turma.Usuario = usuario;
                turma.Senha = senha;
                turma.Id = idturma;
                turma.nomeTurma = nomet;
                this.Hide();
                turma.ShowDialog();
            }
        }

        private void listTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTurma.SelectedItems.Count > 0)
            {
                txtId.Text = listTurma.SelectedItems[0].SubItems[0].Text;
                cbTurma.SelectedItem = listTurma.SelectedItems[0].SubItems[1].Text;
            }
        }
        public int ID
        {
            set { this.idturma = value; }
            get { return this.idturma; }
        }
        public string nomeTurma
        {
            set { this.nomet = value; }
            get { return this.nomet; }
        }
    }
}
