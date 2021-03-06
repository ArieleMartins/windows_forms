using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace CRUD
{
    public partial class Cadastro_aluno : Form
    {
        private string origem;
        private string foto;
        private string destino;
        private DialogResult resp;
        private int id;
        private string login;
        private string senha;
        private int idaluno;
        private int idfunc;
        private int hora;
        private int idturma;
        private string cpf;
        private int idcurso;
        private string privi;
        private List<string> alunos = new List<string>();
        private int max;
        private List<string> cpfver = new List<string>();
        public Cadastro_aluno()
        {
            InitializeComponent();
        }

        private void Cadastro_aluno_Load(object sender, EventArgs e)
        {
            stripHorario.Text = DateTime.Now.ToString();
            tmrHora.Enabled = true;
            rdF.Checked = true;
            ptFoto.Image = Properties.Resources.Design_sem_nome;
            BD bd = new BD();
            bd.Estado();
            while (bd.Tabela.Read())
            {
                cbEst.Items.Add(bd.Tabela["nome_est"].ToString());
            }
            bd.Tabela.Close();
            bd.PaisCB();
            while (bd.Tabela.Read())
            {
                cbPAis.Items.Add(bd.Tabela["nome_pais"].ToString());
            }
            bd.Tabela.Close();
            bd.Curso();
            while (bd.Tabela.Read())
            {
                cbCurso.Items.Add(bd.Tabela["nome_c"].ToString());
            }
            bd.Tabela.Close();
            bd.Conexao.Close();
            cbHorario.Enabled = false;
        }

        private void btCadastro_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text) || String.IsNullOrWhiteSpace(txtBairro.Text) || String.IsNullOrWhiteSpace(txtCidade.Text) || String.IsNullOrWhiteSpace(txtEmail.Text) || String.IsNullOrWhiteSpace(txtNum.Text) || String.IsNullOrWhiteSpace(txtOrg.Text) || String.IsNullOrWhiteSpace(txtRua.Text) || String.IsNullOrWhiteSpace(maskTel.Text) || String.IsNullOrWhiteSpace(maskCPF.Text) || String.IsNullOrWhiteSpace(maskDataNasc.Text) || String.IsNullOrWhiteSpace(maskMatricula.Text) || String.IsNullOrWhiteSpace(maskRG.Text) || cbCurso.SelectedIndex == -1 || cbEst.SelectedIndex == -1 || cbHorario.SelectedIndex == -1 || cbPAis.SelectedIndex == -1 || cbTurma.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha os campos obrigatorios", "Campo Obrigatorio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string ano = maskDataNasc.Text.Substring(0, 4);
                int idade = DateTime.Now.Year - int.Parse(ano);
                if(idade < 18)
                {
                    if (String.IsNullOrWhiteSpace(txtResponsavel.Text))
                    {
                        MessageBox.Show("O ALUNO É MENOR DE IDADE, NOME DO RESPONSÁVEL OBRIGATÓRIO!", "CAMPO OBRIGATÓRIO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    } 
                }
                try
                {
                    try { 
                        BD bd = new BD();
                        bd.ListaAlu();
                        while (bd.Tabela.Read())
                        {
                            cpfver.Add(bd.Tabela["cpf_a"].ToString());
                        }
                        if (bd.Tabela.HasRows == true)
                        {
                            foreach (string listacpf in cpfver)
                            {
                                if (listacpf == maskCPF.Text)
                                {
                                    MessageBox.Show("Já exite um aluno com esse cpf cadastrado", "CPF Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                            }
                        }
                        bd.NomeCurso = cbCurso.SelectedItem.ToString();
                        bd.nomeTurma = cbTurma.SelectedItem.ToString();
                        bd.consulT();
                        if (bd.Tabela.Read())
                        {
                            
                            max = int.Parse(bd.Tabela["max_a"].ToString());
                            idturma = int.Parse(bd.Tabela["id_t"].ToString());

                        }
                        bd.Tabela.Close();
                        bd.NomeCurso = cbCurso.SelectedItem.ToString();
                        bd.nomeTurma = cbTurma.SelectedItem.ToString();
                        bd.consulTAlu();
                        while (bd.Tabela.Read())
                        {
                            alunos.Add(bd.Tabela["nome_a"].ToString());
                        }
                        bd.Tabela.Close();
                        int quanta = alunos.Count();
                        if(quanta == 0)
                        {
                            quanta = 1;
                        }
                        if (quanta == max)
                        {
                            MessageBox.Show("Turma já completa");
                            bd.IdTurma = idturma;
                            bd.nomeTurma = cbTurma.SelectedItem.ToString();
                            bd.EstadoTurma = "Completa";
                            bd.UpdateEstT();
                            bd.Tabela.Close();
                        }
                        else
                        {
                            bd.Nome = txtNome.Text;
                            bd.Nasc = DateTime.Parse(maskDataNasc.Text);
                            bd.Cpf = maskCPF.Text;
                            cpf = maskCPF.Text;
                            bd.Rg = maskRG.Text;
                            bd.Org = txtOrg.Text;
                            bd.Responsavel = txtResponsavel.Text;
                            bd.Pais = cbPAis.SelectedIndex + 1;
                            if (rdF.Checked)
                            {
                                bd.Sexo = Char.Parse("F");
                            }
                            else if (rdM.Checked)
                            {
                                bd.Sexo = char.Parse("M");
                            }
                            bd.Email = txtEmail.Text;
                            bd.Tel = maskTel.Text;
                            bd.Cel = maskCel.Text;
                            bd.Rua = txtRua.Text;
                            bd.Bairro = txtBairro.Text;
                            bd.Cidade = txtCidade.Text;
                            bd.Num = txtNum.Text;
                            bd.Est = cbEst.SelectedIndex + 1;
                            bd.IdCurso = cbCurso.SelectedIndex + 1;
                            idcurso = cbCurso.SelectedIndex + 1;
                            bd.Hora = cbHorario.SelectedIndex + 1;
                            hora = cbHorario.SelectedIndex + 1;
                            bd.Matri = DateTime.Parse(maskMatricula.Text);
                            if (foto == null)
                            {
                                resp = MessageBox.Show("Nenhuma foto adicionada, deseja continuar?", "Sem Foto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                if (resp == DialogResult.No)
                                {
                                    return;
                                }
                            }
                            if (foto != null)
                            {
                                if (File.Exists(destino))
                                {
                                    resp = MessageBox.Show("Foto já cadastrada, deseja substituir?", "Foto Existente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                    if (resp == DialogResult.Yes)
                                    {
                                        File.Copy(origem, destino, true);
                                        bd.Foto = foto;
                                        ptFoto.Image = Properties.Resources.Design_sem_nome;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não Foi possivel substituir a imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    File.Copy(origem, destino);
                                    if (File.Exists(destino))
                                    {
                                        bd.Foto = foto;
                                        ptFoto.Image = Properties.Resources.Design_sem_nome;
                                        MessageBox.Show("Imagem salva com sucesso", "Imagem Salva", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não foi possivel salvar a image", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }

                                }
                            }
                            bd.CadastroAluno();
                            if (bd.Resp > 0)
                            {
                                MessageBox.Show("Aluno Cadastrado com Sucesso", "Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Não foi possivel cadastrar o aluno", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            bd.Cpf = cpf;
                            bd.SelectAluno();
                            if (bd.Tabela.Read())
                            {
                                idaluno = int.Parse(bd.Tabela["id_aluno"].ToString());
                            }
                            else
                            {
                                MessageBox.Show("Não encontrar o aluno", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            bd.Tabela.Close();
                            bd.IdAluno = idaluno;
                            bd.IdCurso = idcurso;
                            bd.IdTurma = idturma;
                            bd.Hora = hora;
                            bd.CadTurma();
                            if (bd.Resp > 0)
                            {
                                MessageBox.Show("Turma cadastra com sucesso", "Turma Cadastrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Não encontrar o aluno", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            bd.Usuario = login;
                            bd.Senha = senha;
                            bd.CliId();
                            if (bd.Tabela.Read())
                            {
                                idfunc = int.Parse(bd.Tabela["id_func"].ToString());
                            }
                            else
                            {
                                MessageBox.Show("Não encontrar o funcionario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            bd.Tabela.Close();
                            bd.Id = idfunc;
                            bd.IdAluno = idaluno;
                            bd.TabCliFun();
                            if (bd.Resp > 0)
                            {
                                MessageBox.Show("Cadastrado", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtRua.Clear();
                                txtResponsavel.Clear();
                                txtOrg.Clear();
                                txtNum.Clear();
                                txtNome.Clear();
                                txtEmail.Clear();
                                txtCidade.Clear();
                                txtBairro.Clear();
                                maskCel.Clear();
                                maskCPF.Clear();
                                maskDataNasc.Clear();
                                maskMatricula.Clear();
                                maskRG.Clear();
                                maskTel.Clear();
                                cbCurso.SelectedIndex = -1;
                                cbEst.SelectedIndex = -1;
                                cbHorario.SelectedIndex = -1;
                                cbPAis.SelectedIndex = -1;
                                cbTurma.SelectedIndex = -1;
                            }
                            else
                            {
                                MessageBox.Show("Não foi possivel vincular funcionario com aluno", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                        }
                        bd.Conexao.Close();
            }
                catch (System.FormatException err)
                {
                    MessageBox.Show("Algum campo foi inserido incorretamento. As datas devem ser colocadas em ordem de: ano/mês/dia");
                    return;
                }
             }catch (System.IO.DirectoryNotFoundException err)
             {
                MessageBox.Show("Não foi possivel encontrar o diretorio de destino", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
                

}
            
        }

        private void pcBImg_Click(object sender, EventArgs e)
        {

            try
            {
                try
                {
                    string aplicacao = System.Environment.CurrentDirectory;
                    OpenFileDialog buscar = new OpenFileDialog();
                    buscar.Filter = "JPG File(*.jpg)|*.jpg|PNG File(*.png)|*.png";
                    if (buscar.ShowDialog() == DialogResult.OK)
                    {
                        origem = buscar.FileName;
                        foto = buscar.SafeFileName;
                        destino = aplicacao + "\\aluno\\" + foto;
                        ptFoto.ImageLocation = origem;
                    }
                }
                catch (System.IO.DirectoryNotFoundException err)
                {
                    MessageBox.Show("Não foi possivel encontrar o deiretorio de destino", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao carregar imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Usuario = login;
            menu.Senha = senha;
            menu.Privi = privi;
            this.Hide();
            menu.ShowDialog();

        }
        public string Senha
        {
            set { this.senha = value; }
        }
        public string Login
        {
            set { this.login = value; }
        }
        public string Privi
        {
            set { this.privi = value; }
        }

        private void pcBImg_MouseEnter(object sender, EventArgs e)
        {
            pcBImg.Image = Properties.Resources.CameraIcon2Brilante;
        }

        private void pcBImg_MouseLeave(object sender, EventArgs e)
        {
            pcBImg.Image = Properties.Resources.CameraIcon2;
        }


        private void tmrHora_Tick_1(object sender, EventArgs e)
        {
            stripHorario.Text = DateTime.Now.ToString();
        }

        private void cbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTurma.Items.Count != 0)
            {
                cbTurma.Items.Clear();
            }
            if (cbCurso.SelectedIndex != -1)
            {
                BD bd = new BD();
            
                bd.NomeCurso = cbCurso.SelectedItem.ToString();
                bd.Turma();
                while (bd.Tabela.Read())
                {
                        cbTurma.Items.Add(bd.Tabela["nome_t"].ToString());
                                   
                }
                if(bd.Tabela.HasRows == false)
                {
                    if (cbTurma.Items.Count != 0)
                    {
                        cbTurma.Text = "";
                        cbTurma.Items.Clear();
                    }
                }
                bd.Tabela.Close();
                bd.Conexao.Close();
            }
            else
            {
                if (cbTurma.Items.Count != 0)
                {
                    cbTurma.Text = "";
                    cbTurma.Items.Clear();
                }
            }
            if (cbTurma.SelectedIndex == -1)
            {
                cbTurma.Text = "";
                if (cbHorario.Items.Count != 0)
                {
                    cbHorario.Text = "";
                    cbHorario.Items.Clear();
                }
            }


        }

        private void cbTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHorario.Items.Count != 0)
            {
                cbHorario.Items.Clear();
            }
            if (cbTurma.SelectedIndex != -1)
            {
                BD bd = new BD();

                bd.nomeTurma = cbTurma.SelectedItem.ToString();
                bd.hTurma();
                while (bd.Tabela.Read())
                {
                    
                    cbHorario.Items.Add(bd.Tabela["hora_h"].ToString());
                }
                if(bd.Tabela.HasRows == false)
                {
                    if (cbHorario.Items.Count != 0)
                    {
                        cbHorario.Text = "";
                        cbHorario.Items.Clear();
                    }
                }
                else
                {
                    cbHorario.Enabled = true;
                }
                bd.Tabela.Close();
                bd.Conexao.Close();
            }
            else if(cbTurma.SelectedIndex == -1 || cbTurma.Text == "")
            {
                if (cbHorario.Items.Count != 0)
                {
                    cbHorario.Text = "";
                    cbHorario.Items.Clear();
                }
            }
        }

        private void cbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
