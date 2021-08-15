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
    public partial class consulta_turmaexp : Form
    {
        private string privi;
        private string usuario;
        private string senha;
        private int idturma;
        private string nomet;
        private string[] dados = new string[3];
        private int max;
        private int indice;
        private List<int> ids = new List<int>();
        
        public consulta_turmaexp()
        {
            InitializeComponent();
        }

        private void consulta_turmaexp_Load(object sender, EventArgs e)
        {
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
            
            lblTurma.Text = nomet;
            BD bd = new BD();
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
            bd.IdTurma = idturma;
            bd.nomeTurma = nomet;
            bd.consulTurma();
            while (bd.Tabela.Read())
            {
                indice = cbMax.FindString(bd.Tabela["max_a"].ToString());
                for (int i = 0; i < indice; i++)
                {
                    cbMax.SelectedIndex = 0;
                    if (cbMax.SelectedItem.ToString() != bd.Tabela["max_a"].ToString())
                    {
                        cbMax.Items.RemoveAt(0);
                    }
                    else if (cbMax.SelectedItem.ToString() == bd.Tabela["max_a"].ToString())
                    {
                        i = 10;
                    }

                }
                cbHorario.SelectedItem = bd.Tabela["hora_h"].ToString();
                cbMax.SelectedItem = bd.Tabela["max_a"].ToString();
                max = int.Parse(bd.Tabela["max_a"].ToString());
                cbEstado.SelectedItem = bd.Tabela["est_t"].ToString();
                cbDocentes.SelectedItem = bd.Tabela["nome_func"].ToString();
            }
            bd.Tabela.Close();
            bd.IdTurma = idturma;
            bd.nomeTurma = nomet;
            bd.consulTurmas();
            while (bd.Tabela.Read())
            {
                dados[0] = bd.Tabela["id_aluno"].ToString();
                dados[1] = bd.Tabela["nome_a"].ToString();
                dados[2] = bd.Tabela["nome_c"].ToString();
                ListViewItem lista = new ListViewItem(dados);
                listView1.Items.Add(lista);
            }
            
            
            if(listView1.Items.Count == 0)
            {
                cbHorario.Enabled = true;
                cbMax.Items.Clear();
                cbMax.Items.Add("5");
                cbMax.Items.Add("10");
                cbMax.Items.Add("15");
                cbMax.Items.Add("20");
                cbMax.Items.Add("25");
                cbMax.Items.Add("30");
                cbMax.Items.Add("35");
            }
            else
            {
                cbHorario.Enabled = false;
            }
            bd.Tabela.Close();
            bd.Conexao.Close();
        }
        public string Privi
        {
            set { this.privi = value; }
        }
        public string Senha
        {
            set { this.senha = value; }
        }
        public string Usuario
        {
            set { this.usuario = value; }
        }
        public int Id
        {
            set { this.idturma = value; }
        }
        public string nomeTurma
        {
            set { this.nomet = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbEstado.SelectedIndex == -1|| cbHorario.SelectedIndex == -1|| cbMax.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha os campos para alterar os dados da turma", "Alterar Dados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult resp = MessageBox.Show("Deseja alterar os dados da turma", "Alterar Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    BD bd = new BD();
                    bd.IdTurma = idturma;
                    bd.nomeTurma = nomet;
                    bd.EstadoTurma = cbEstado.SelectedItem.ToString();
                    bd.Hora = cbHorario.SelectedIndex + 1;
                    bd.Maximo = int.Parse(cbMax.SelectedItem.ToString());
                    bd.Id = ids[cbDocentes.SelectedIndex];
                    bd.UpdateTurma();
                    if(bd.Resp > 0)
                    {
                        MessageBox.Show("Turma alterada com sucesso!!!");
                    }
                    else
                    {
                        MessageBox.Show("Não foi possivel alterar turma", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Deseja deletar os dados da turma", "Deletar Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                BD bd = new BD();
                bd.IdTurma = idturma;
                bd.nomeTurma = nomet;
                bd.DeletarTurma();
                if (bd.Resp > 0)
                {
                    MessageBox.Show("Turma deletada com sucesso!!!");
                    consultar_turma turma = new consultar_turma();
                    turma.Privi = privi;
                    turma.Usuario = usuario;
                    turma.Senha = senha;
                    this.Hide();
                    turma.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Não foi possivel deletar turma", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            consultar_turma turma = new consultar_turma();
            turma.Privi = privi;
            turma.Usuario = usuario;
            turma.Senha = senha;
            this.Hide();
            turma.ShowDialog();
        }

       
    }
}
