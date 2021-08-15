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
    public partial class criar_turma : Form
    {
        List<string> num = new List<string>();
        List<int> ids = new List<int>();
        private int numt;
        private string nomet;
        private string privi;
        private string usuario;
        private string senha;
        private string docente;
        private int d;
        public criar_turma()
        {
            InitializeComponent();
        }

        

        private void criar_turma_Load(object sender, EventArgs e)
        {
            BD bd = new BD();
            bd.Curso();
            while (bd.Tabela.Read())
            {
                cbCurso.Items.Add(bd.Tabela["nome_c"].ToString());
            }
            bd.Tabela.Close();
            bd.Horario();
            while (bd.Tabela.Read())
            {
                cbHorario.Items.Add(bd.Tabela["hora_h"].ToString());
            }
            bd.Tabela.Close();
            bd.listaDocentes();
            while (bd.Tabela.Read())
            {
                cbDocentes.Items.Add(bd.Tabela["nome_func"].ToString());
                ids.Add(int.Parse(bd.Tabela["id_func"].ToString()));
            }
            bd.Tabela.Close();
            cbEstado.Items.Add("Disponivel");
            cbEstado.Items.Add("Pausada");
            cbEstado.Items.Add("Cancelada");
            cbEstado.Items.Add("Concluida");
            cbEstado.Items.Add("Completa");

            cbMax.Items.Add("5");
            cbMax.Items.Add("10");
            cbMax.Items.Add("15");
            cbMax.Items.Add("20");
            cbMax.Items.Add("25");
            cbMax.Items.Add("30");
            cbMax.Items.Add("35");
            bd.Conexao.Close();
        }

        private void cbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCurso.SelectedIndex != -1)
            {
                BD bd = new BD();
                bd.nomeTurma = cbCurso.SelectedItem.ToString();
                bd.numTurma();
                while (bd.Tabela.Read())
                {
                    num.Add(bd.Tabela["num_t"].ToString());
                }
                if (bd.Tabela.HasRows == false)
                {
                    num.Add("0");
                }
                bd.Tabela.Close();
                int quant = num.Count() - 1;
                numt = int.Parse(num[quant].ToString()) + 1;
                txtNomeT.Text = cbCurso.SelectedItem.ToString() + " " + numt.ToString();
                nomet = txtNomeT.Text;
                bd.Conexao.Close();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            BD bd = new BD();
            int doc = ids[cbDocentes.SelectedIndex];
            string nome = cbDocentes.SelectedItem.ToString();
            bd.Nome = nome;
            bd.Id = doc;
            bd.encDocente();
            if (bd.Tabela.Read())
            {
                d = int.Parse(bd.Tabela["id_func"].ToString());
            }
            bd.Tabela.Close();
            bd.nomeTurma = nomet;
            bd.Maximo = int.Parse(cbMax.SelectedItem.ToString());
            bd.NumeroTurma = numt;
            bd.EstadoTurma = cbEstado.SelectedItem.ToString();
            bd.Hora = cbHorario.SelectedIndex + 1;
            bd.IdCurso = cbCurso.SelectedIndex + 1;
            bd.Id = d;
            bd.inserirTurma();
            if(bd.Resp > 0)
            {
                MessageBox.Show("Turma criada com sucesso");
                cbCurso.SelectedIndex = -1;
                cbEstado.SelectedIndex = -1;
                cbHorario.SelectedIndex = -1;
                cbMax.SelectedIndex = -1;
                cbDocentes.SelectedIndex = -1;
                txtNomeT.Clear();
            }
            else
            {
                MessageBox.Show("Não foi posiivel criar turma", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            bd.Tabela.Close();
            bd.Conexao.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Privi = privi;
            menu.Usuario = usuario;
            menu.Senha = senha;
            this.Hide();
            menu.ShowDialog();
        }

        
    }
}
