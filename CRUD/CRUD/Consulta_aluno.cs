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
namespace CRUD
{
    public partial class Consulta_aluno : Form
    {
        private string usuario;
        private string senha;
        private string cpf;
        private int id;
        private string privi;
        private string origem;
        private string foto;
        private string destino;
        private string antigo;
        private string responsavel;
        private int id_consulta;
        private string local;
        private int idcurso;
        private string nomet;
        private List<string> cpfver = new List<string>();
        private List<string> idver = new List<string>();
        public Consulta_aluno()
        {
            InitializeComponent();
        }

        private void Consulta_aluno_Load(object sender, EventArgs e)
        {
            stripHorario.Text = DateTime.Now.ToString();
            tmrHora.Enabled = true;
            ptFoto.Image = Properties.Resources.Design_sem_nome;
            BD bd = new BD();
            bd.Curso();
            while (bd.Tabela.Read())
            {
                cbCurso.Items.Add(bd.Tabela["nome_c"].ToString());
            }
            bd.Tabela.Close();
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
            bd.IdAluno = id;
            bd.Cpf = cpf;
            bd.ConsTuA();
            if (bd.Tabela.Read())
            {
                txtNome.Text = bd.Tabela["nome_a"].ToString();
                txtEmail.Text = bd.Tabela["email_a"].ToString();
                txtCidade.Text = bd.Tabela["cidade_a"].ToString();
                txtBairro.Text = bd.Tabela["bairro_a"].ToString();
                txtNum.Text = bd.Tabela["n_a"].ToString();
                txtOrg.Text = bd.Tabela["org_a"].ToString();
                if(bd.Tabela["resp_a"].ToString() == "")
                {
                    txtResponsavel.Text = "";
                }
                else
                {
                    responsavel = bd.Tabela["resp_a"].ToString();
                    txtResponsavel.Text = responsavel;
                }
                if (bd.Tabela["sexo_a"].ToString() == "F")
                {
                    rdF.Checked = true;
                } else if (bd.Tabela["sexo_a"].ToString() == "M")
                {
                    rdM.Checked = true;
                }
                txtRua.Text = bd.Tabela["rua_a"].ToString();
                maskCel.Text = bd.Tabela["cel_a"].ToString();
                maskCPF.Text = bd.Tabela["cpf_a"].ToString();
                cpf = bd.Tabela["cpf_a"].ToString();
                maskDataNasc.Text = DateTime.Parse(bd.Tabela["dtnasc_a"].ToString()).ToString("yyyy/MM/d");
                maskMatricula.Text = DateTime.Parse(bd.Tabela["matri_a"].ToString()).ToString("yyyy/MM/d");
                maskRG.Text = bd.Tabela["rg_a"].ToString();
                maskTel.Text = bd.Tabela["tel_a"].ToString();
                cbCurso.SelectedIndex = int.Parse(bd.Tabela["id_c"].ToString()) - 1;
                cbEst.SelectedIndex = int.Parse(bd.Tabela["id_est"].ToString()) - 1;
                cbPAis.SelectedIndex = int.Parse(bd.Tabela["id_pais"].ToString()) - 1;
                cbTurma.SelectedItem= bd.Tabela["nome_t"].ToString();
                cbHorario.SelectedItem = bd.Tabela["hora_h"].ToString();
                if (bd.Tabela["foto_a"].ToString() != "")
                {
                    foto = bd.Tabela["foto_a"].ToString();
                    local = System.Environment.CurrentDirectory + "\\aluno\\" + bd.Tabela["foto_a"].ToString();
                    origem = local;
                    destino = local;
                    antigo = bd.Tabela["foto_a"].ToString();
                    FileStream stream = new FileStream(local, FileMode.Open, FileAccess.Read);
                    BinaryReader leitura = new BinaryReader(stream);
                    byte[] Foto = leitura.ReadBytes((int)stream.Length);
                    MemoryStream memoria = new MemoryStream(Foto);
                    Image imagem = Image.FromStream(memoria);
                    ptFoto.Image = imagem;

                }
                else
                {
                    ptFoto.Image = Properties.Resources.Design_sem_nome;
                }
                bd.Tabela.Close();
                bd.Conexao.Close();
            }
        }
        public string Usuario
        {
            set { this.usuario = value; }
        }
        public string Senha
        {
            set { this.senha = value; }
        }
        public string Cpf
        {
            set { this.cpf = value; }
        }
        public int Id
        {
            set { this.id = value; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consultar_alunos alunos = new Consultar_alunos();
            alunos.Usuario = usuario;
            alunos.Privi = privi;
            alunos.Senha = senha;
            this.Hide();
            alunos.ShowDialog();
        }
        public string Privi
        {
            set { this.privi = value; }
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

        private void pcBImg_MouseEnter(object sender, EventArgs e)
        {
            pcBImg.Image = Properties.Resources.CameraIcon2Brilante;
        }

        private void pcBImg_MouseLeave(object sender, EventArgs e)
        {
            pcBImg.Image = Properties.Resources.CameraIcon2;
        }

        private void btCadastro_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtBairro.Text) || String.IsNullOrWhiteSpace(txtCidade.Text) || String.IsNullOrWhiteSpace(maskMatricula.Text) || String.IsNullOrWhiteSpace(txtEmail.Text) || String.IsNullOrWhiteSpace(txtNome.Text) || String.IsNullOrWhiteSpace(txtNum.Text) || String.IsNullOrWhiteSpace(txtOrg.Text) || String.IsNullOrWhiteSpace(txtRua.Text) || String.IsNullOrWhiteSpace(maskCPF.Text) || String.IsNullOrWhiteSpace(maskDataNasc.Text) || String.IsNullOrWhiteSpace(maskRG.Text) || String.IsNullOrWhiteSpace(maskTel.Text) || cbTurma.SelectedIndex == -1 || cbCurso.SelectedIndex == -1 || cbEst.SelectedIndex == -1 || cbPAis.SelectedIndex == -1 || cbHorario.SelectedIndex == - 1)
            {
                MessageBox.Show("Preencha os campos obrigatorio", "Campos Obrigatorios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult resp;
                resp = MessageBox.Show("Tem certeza que deseja alterar os dados do  aluno?", "Alterar Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (resp == DialogResult.Yes)
                {
                    //try
                    //{
                        try
                        {
                            BD bd = new BD();
                            //bd.IdAluno = id;
                            //bd.Cpf = cpf;
                            //bd.ConsAlu();
                            //if (bd.Tabela.Read())
                            //{
                            //id_consulta = int.Parse(bd.Tabela["id_aluno"].ToString());
                            //}
                            //else
                            //{
                            //MessageBox.Show("Não foi possivel encontrar o aluno");
                            //}
                            //bd.Tabela.Close();
                            bd.ListaAlu();
                            while (bd.Tabela.Read())
                            {
                                cpfver.Add(bd.Tabela["cpf_a"].ToString());
                                idver.Add(bd.Tabela["id_aluno"].ToString());
                            }
                            if (bd.Tabela.HasRows == true)
                            {
                                foreach (string listacpf in cpfver)
                                {
                                    foreach (string listaid in idver)
                                    {
                                        if (listaid != id.ToString())
                                        {
                                            if (listacpf == maskCPF.Text)
                                            {
                                                MessageBox.Show("Já exite um aluno com esse cpf cadastrado", "CPF Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return;
                                            }
                                        }
                                    }

                                }
                            }
                            bd.Nome = txtNome.Text;
                            bd.Matri = DateTime.Parse(maskMatricula.Text);
                            bd.Nasc = DateTime.Parse(maskDataNasc.Text);
                            bd.Bairro = txtBairro.Text;
                            bd.Cel = maskCel.Text;
                            bd.Cidade = txtCidade.Text;
                            bd.Cpf = maskCPF.Text;
                            bd.Hora = cbHorario.SelectedIndex + 1;
                            bd.IdCurso = cbCurso.SelectedIndex + 1;
                            idcurso = cbCurso.SelectedIndex + 1;
                            bd.Email = txtEmail.Text;
                            bd.Est = cbEst.SelectedIndex + 1;
                            bd.Num = txtNum.Text;
                            bd.Org = txtOrg.Text;
                            bd.Pais = cbPAis.SelectedIndex + 1;
                            bd.Rg = maskRG.Text;
                            bd.Rua = txtRua.Text;
                            bd.Responsavel = txtResponsavel.Text;
                            bd.Tel = maskTel.Text;
                            if (rdF.Checked)
                            {
                                bd.Sexo = char.Parse(rdF.Text);
                            }
                            else if (rdM.Checked)
                            {
                                bd.Sexo = char.Parse(rdM.Text);
                            }
                            if (foto == null || origem == null)
                            {
                                resp = MessageBox.Show("Nenhuma foto foi selecionada deseja continuar?", "Sem foto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                if (resp == DialogResult.No)
                                {
                                    return;
                                }

                            }
                            if (foto != null || origem != null)
                            {
                                try
                                {
                                    if (File.Exists(destino))
                                    {

                                        resp = MessageBox.Show("Foto já existente, deseja substituir?", "Foto existente", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                        if (resp == DialogResult.Yes)
                                        {
                                            File.Copy(origem, destino, true);
                                            if (File.Exists(destino))
                                            {


                                                bd.Foto = foto;
                                                MessageBox.Show("Arquivo Salvo com Sucesso!");
                                                ptFoto.ImageLocation = destino;

                                            }
                                            else
                                            {
                                                MessageBox.Show("Não foi possivel copiar imagem.");
                                            }
                                        }
                                        else
                                        {
                                            bd.Foto = foto;
                                        }

                                    }
                                    else
                                    {

                                        File.Copy(origem, destino);
                                        if (File.Exists(destino))
                                        {

                                            bd.Foto = foto;
                                            MessageBox.Show("Arquivo Salvo com Sucesso!");
                                            ptFoto.ImageLocation = destino;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Não foi possivel salvar o arquivo");
                                        }
                                    }
                                }
                                catch (System.IO.IOException err)
                                {
                                    MessageBox.Show("Imagem já esta salva no destino", "Arquivo Existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    bd.Foto = foto;
                                }
                            }
                            bd.IdAluno = id;
                            bd.UpdateAlu();
                            if (bd.Resp > 0)
                            {
                                MessageBox.Show("Dados Alterados com sucesso!", "Alterado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Não foi possivel alterar os dados do aluno", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            bd.IdAluno = id;
                            bd.IdCurso = idcurso;
                            bd.IdTurma = cbTurma.SelectedIndex + 1;
                            bd.UpdateTu();
                            if(bd.Resp > 0)
                            {
                                MessageBox.Show("Dados da turma Alterados com sucesso!", "Alterado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Não foi possivel alterar os dados da turma", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            bd.Conexao.Close();
                        }
                        catch (System.IO.DirectoryNotFoundException err)
                        {
                            MessageBox.Show("Não foi possivel encontrar o diretorio de destino", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    //}
                    //catch (Exception)
                    //{
                        //MessageBox.Show("Não foi possivel carregar a imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("Tem certeza que deseja deletar os dados do aluno?", "Deletar Aluno", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
            {

                BD bd = new BD();
                bd.IdAluno = id;
                bd.DeletarAlu();
                if (bd.Resp > 0)
                {
                    MessageBox.Show("Aluno Deletado com Sucesso!!!", "Aluno Deletado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Consultar_alunos alunos = new Consultar_alunos();
                    alunos.Usuario = usuario;
                    alunos.Privi = privi;
                    alunos.Senha = senha;
                    try
                    {
                        ptFoto.Image.Dispose();
                        if (File.Exists(local))
                        {
                            
                            File.Delete(local);
                        }
                    }catch (System.IO.IOException err)
                    {
                        MessageBox.Show("Não é possivel deletar a imagem, pois outro formulario está usando", "Imagem Sendo Usada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Hide();
                    alunos.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Não foi possivel deletar aluno", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                bd.Conexao.Close();
                
            }
        }

        private void tmrHora_Tick(object sender, EventArgs e)
        {
            stripHorario.Text = DateTime.Now.ToString();
        }

        private void cbTurma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTurma.SelectedIndex != -1)
            {
                BD bd = new BD();

                bd.nomeTurma = cbTurma.SelectedItem.ToString();
                bd.hTurma();
                while (bd.Tabela.Read())
                {
                    cbHorario.Items.Add(bd.Tabela["hora_h"].ToString());
                }
                if (bd.Tabela.HasRows == false)
                {
                    cbHorario.Items.RemoveAt(0);
                }
                bd.Tabela.Close();
                bd.Conexao.Close();
            }
        }

        private void cbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCurso.SelectedIndex != -1)
            {
                BD bd = new BD();

                bd.NomeCurso = cbCurso.SelectedItem.ToString();
                bd.Turma();
                while (bd.Tabela.Read())
                {
                    cbTurma.Items.Add(bd.Tabela["nome_t"].ToString());

                }
                if (bd.Tabela.HasRows == false)
                {
                    cbTurma.Items.RemoveAt(0);
                }
                bd.Tabela.Close();
                bd.Conexao.Close();
            }
        }
    }
}
