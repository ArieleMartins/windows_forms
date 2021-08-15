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
    public partial class Consulta_funcesp : Form
    {
        private string cpf_consulta;
        private int id_consulta;
        private string origem;
        private string foto;
        private string destino;
        private string privi;
        private DialogResult resp;
        private string usuario;
        private string senha;
        private string antigo;
        private string[] dados = new string[4];
        private string[] funcionarios = new string[3];
        private string local;
        public Consulta_funcesp()
        {
            InitializeComponent();
        }

        private void Consulta_funcesp_Load(object sender, EventArgs e)
        {
            stripHorario.Text = DateTime.Now.ToString();
            tmrHora.Enabled = true;
            ptFoto.Image = Properties.Resources.Design_sem_nome;
            BD bd = new BD();
            bd.CargoCB();
            while (bd.Tabela.Read())
            {
                cbCar.Items.Add(bd.Tabela["nome_car"].ToString());
            }
            bd.Tabela.Close();
            bd.PaisCB();
            while (bd.Tabela.Read())
            {
                cbPAis.Items.Add(bd.Tabela["nome_pais"].ToString());
            }
            bd.Tabela.Close();
            bd.Departamento();
            while (bd.Tabela.Read())
            {
                cbDep.Items.Add(bd.Tabela["nome_dep"].ToString());
            }
            bd.Tabela.Close();
            bd.Estado();
            while (bd.Tabela.Read())
            {
                cbEst.Items.Add(bd.Tabela["nome_est"]);
            }
            bd.Tabela.Close();
            bd.Id = id_consulta;
            bd.Cpf = cpf_consulta;
            bd.Consultar();
            if (bd.Tabela.HasRows)
            {
                if (bd.Tabela.Read())
                {
                    checkSim.Checked = true;
                    txtUsuario.Text = bd.Tabela["usuario_log"].ToString();
                    txtSenha.Text = bd.Tabela["senha_log"].ToString();
                    this.Size = new Size(1250, 667);

                    if (bd.Tabela["id_privi"].ToString() == "1")
                    {
                        rbAdmin.Checked = true;
                        gpAlunos.Visible = true;
                        gpFunc.Visible = true;
                    }
                    else if (bd.Tabela["id_privi"].ToString() == "2")
                    {
                        rbUsu.Checked = true;
                        gpAlunos.Visible = true;
                        gpFunc.Visible = false;
                    }
                    else
                    {
                        rbAdmin.Visible = false;
                        rbUsu.Visible = false;
                    }
                    txtNome.Text = bd.Tabela["nome_func"].ToString();
                    txtBairro.Text = bd.Tabela["bairro_func"].ToString();
                    txtCidade.Text = bd.Tabela["cidade_func"].ToString();
                    txtCTPS.Text = bd.Tabela["carte_func"].ToString();
                    txtEmail.Text = bd.Tabela["email_func"].ToString();
                    if (bd.Tabela["func_func"].ToString() == null)
                    {
                        txtFunc.Text = "";
                    }
                    else
                    {
                        txtFunc.Text = bd.Tabela["func_func"].ToString();
                    }
                    if (bd.Tabela["sexo_func"].ToString() == "F")
                    {
                        rdF.Checked = true;
                    }
                    else if (bd.Tabela["sexo_func"].ToString() == "M")
                    {
                        rdM.Checked = true;
                    }
                    txtNum.Text = bd.Tabela["n_func"].ToString();
                    txtOrg.Text = bd.Tabela["org_func"].ToString();
                    txtPis.Text = bd.Tabela["pis_func"].ToString();
                    txtRua.Text = bd.Tabela["rua_func"].ToString();
                    txtSal.Text = bd.Tabela["salario_func"].ToString();
                    maskAdmi.Text = DateTime.Parse(bd.Tabela["admi_func"].ToString()).ToString("yyyy/MM/d");
                    maskCel.Text = bd.Tabela["cel_func"].ToString();
                    maskCPF.Text = bd.Tabela["cpf_func"].ToString();
                    maskDataNasc.Text = DateTime.Parse(bd.Tabela["data_func"].ToString()).ToString("yyyy/MM/d");
                    maskRG.Text = bd.Tabela["rg_func"].ToString();
                    maskTel.Text = bd.Tabela["tel_func"].ToString();
                    cbCar.SelectedIndex = int.Parse(bd.Tabela["id_car"].ToString()) - 1;
                    cbDep.SelectedIndex = int.Parse(bd.Tabela["id_dep"].ToString()) - 1;
                    cbEst.SelectedIndex = int.Parse(bd.Tabela["id_est"].ToString()) - 1;
                    cbPAis.SelectedIndex = int.Parse(bd.Tabela["id_pais"].ToString()) - 1;
                    cpf_consulta = bd.Tabela["cpf_func"].ToString();
                    id_consulta = int.Parse(bd.Tabela["id_func"].ToString());
                    if (bd.Tabela["foto_func"].ToString() != "")
                    {
                        foto = bd.Tabela["foto_func"].ToString();
                        local = System.Environment.CurrentDirectory + "\\Funcionario\\" + bd.Tabela["foto_func"].ToString();
                        origem = local;
                        destino = local;
                        antigo = bd.Tabela["foto_func"].ToString();
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
                }
                else
                {
                    MessageBox.Show("Funcionario não encontrado");
                }
            }
            else
            {
                MessageBox.Show("Funcionario não encontrado");
            }
            bd.Id = id_consulta;
            bd.Cpf = cpf_consulta;
            bd.ListFA();
            while (bd.Tabela.Read())
            {
                dados[0] = bd.Tabela["id_aluno"].ToString();
                dados[1] = bd.Tabela["nome_a"].ToString();
                dados[2] = DateTime.Parse(bd.Tabela["matri_a"].ToString()).ToString("yyyy/MM/d");
                dados[3] = bd.Tabela["cpf_a"].ToString();
                ListViewItem lista = new ListViewItem(dados);
                listAluno.Items.Add(lista);
            }
            bd.Tabela.Close();
            bd.ListaFuncionarios();
            while (bd.Tabela.Read())
            {
                funcionarios[0] = bd.Tabela["nome_func"].ToString();
                funcionarios[1] = bd.Tabela["cpf_func"].ToString();
                funcionarios[2] = DateTime.Parse(bd.Tabela["admi_func"].ToString()).ToString("yyyy/MM/d");
                ListViewItem funcs = new ListViewItem(funcionarios);
                listFunc.Items.Add(funcs);
            }
            bd.Conexao.Close();
        }
        public string Cpf
        {
            set { this.cpf_consulta = value; }
        }
        public int Id
        {
            set { this.id_consulta = value; }
        }

        private void checkSim_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSim.Checked)
            {
                rbAdmin.Visible = true;
                rbUsu.Visible = true;
                gpConta.Visible = true;
                
            }
            else
            {
                rbAdmin.Visible = false;
                rbUsu.Visible = false;
                gpConta.Visible = false;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD bd = new BD();
            if (String.IsNullOrWhiteSpace(txtBairro.Text) || String.IsNullOrWhiteSpace(txtCidade.Text) || String.IsNullOrWhiteSpace(txtCTPS.Text) || String.IsNullOrWhiteSpace(txtEmail.Text) || String.IsNullOrWhiteSpace(txtNome.Text) || String.IsNullOrWhiteSpace(txtNum.Text) || String.IsNullOrWhiteSpace(txtOrg.Text) || String.IsNullOrWhiteSpace(txtPis.Text) || String.IsNullOrWhiteSpace(txtRua.Text) || String.IsNullOrWhiteSpace(txtSal.Text) || String.IsNullOrWhiteSpace(maskAdmi.Text) || String.IsNullOrWhiteSpace(maskCPF.Text) || String.IsNullOrWhiteSpace(maskDataNasc.Text) || String.IsNullOrWhiteSpace(maskRG.Text) || String.IsNullOrWhiteSpace(maskTel.Text) || cbCar.SelectedIndex == -1 || cbDep.SelectedIndex == -1 || cbEst.SelectedIndex == -1 || cbPAis.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha os campos obrigatorio", "Campos Obrigatorios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult resp;
                resp = MessageBox.Show("Tem certeza que deseja alterar os dados do funcionario?", "Alterar Dados", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (resp == DialogResult.Yes)
                {
                    try
                    {
                        bd.Cpf = cpf_consulta;
                        bd.IdFunc();
                        if (bd.Tabela.Read())
                        {
                            id_consulta = int.Parse(bd.Tabela["id_func"].ToString());
                        }
                        else
                        {
                            MessageBox.Show("Não foi possivel encontrar o funcionario");
                        }
                        bd.Tabela.Close();
                        if (checkSim.Checked)
                        {
                            bd.Usuario = txtUsuario.Text;
                            bd.Senha = txtSenha.Text;
                            if (rbAdmin.Checked)
                            {
                                bd.Privi = 1;
                            }
                            else if (rbUsu.Checked)
                            {
                                bd.Privi = 2;
                            }
                            bd.Id = id_consulta;
                            bd.UpdateConLog();
                            if (bd.Resp > 0)
                            {
                                MessageBox.Show("Login criado com sucesso!");
                            }
                            else
                            {
                                MessageBox.Show("Não foi possivel criar login");
                            }
                        }
                        else
                        {
                            bd.Usuario = "";
                            bd.Senha = "";
                            bd.Privi = 3;
                            bd.Id = id_consulta;
                            bd.UpdateConLog();
                            if (bd.Resp > 0)
                            {
                                MessageBox.Show("Dados alterados com sucesso");
                            }
                            else
                            {
                                MessageBox.Show("Não foi possivel mudar a conta");
                            }
                        }
                        bd.Nome = txtNome.Text;
                        bd.Admi = DateTime.Parse(maskAdmi.Text);
                        bd.Nasc = DateTime.Parse(maskDataNasc.Text);
                        bd.Bairro = txtBairro.Text;
                        bd.Cargo = cbCar.SelectedIndex + 1;
                        bd.Cel = maskCel.Text;
                        bd.Cidade = txtCidade.Text;
                        bd.Cpf = maskCPF.Text;
                        bd.Ctps = txtCTPS.Text;
                        bd.Dep = cbDep.SelectedIndex + 1;
                        bd.Email = txtEmail.Text;
                        bd.Est = cbEst.SelectedIndex + 1;
                        bd.Funcao = txtFunc.Text;
                        bd.Num = txtNum.Text;
                        bd.Org = txtOrg.Text;
                        bd.Pais = cbPAis.SelectedIndex + 1;
                        bd.Pis = txtPis.Text;
                        bd.Rg = maskRG.Text;
                        bd.Rua = txtRua.Text;
                        bd.Salario = double.Parse(txtSal.Text);
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
                                            ptFoto.ImageLocation = destino;

                                        }
                                        else
                                        {
                                            MessageBox.Show("Não foi possivel copiar imagem.");
                                        }
                                    }
                                    else
                                    {
                                        bd.Foto = antigo;
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
                                bd.Foto = antigo;
                            }
                        }
                        bd.Id = id_consulta;
                        bd.UpdateCon();
                        if (bd.Resp > 0)
                        {
                            MessageBox.Show("Dados Alterados com sucesso!", "Alterado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Não foi possivel alterar os dados do funcionario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        bd.Conexao.Close();
                    }
                    catch (System.IO.DirectoryNotFoundException err)
                    {
                        MessageBox.Show("Não foi possivel encontrar o deiretorio de destino", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consulta_func funcionario = new Consulta_func();
            funcionario.Usu = usuario;
            funcionario.Senha = senha;
            funcionario.Privi = privi;
            this.Hide();
            funcionario.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DialogResult resp;
            resp = MessageBox.Show("Tem certeza que deseja deletar os dados do funcionario?", "Deletar Funcionario", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (resp == DialogResult.Yes)
            {
                
                BD bd = new BD();
                bd.Id = id_consulta;
                bd.DeletarLog();
                if (bd.Resp == 0)
                {
                   
                }
                else
                {
                    MessageBox.Show("Não foi possivel deletar conta", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                bd.IdLogin = id_consulta;
                bd.DeletarFunc();

                if (bd.Resp > 0)
                {
                    MessageBox.Show("Funcionario Deletado com Sucesso!!!", "Funcionario Deletado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Dados da conta deletado!!!", "Conta Deletado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Consulta_func funcionario = new Consulta_func();
                    funcionario.Usu = usuario;
                    funcionario.Senha = senha;
                    funcionario.Privi = privi;
                    try
                    {
                        if (File.Exists(local))
                        {
                            ptFoto.Image.Dispose();
                            File.Delete(local);
                        }
                    }catch (System.IO.IOException err)
                    {
                        MessageBox.Show("Não é possivel deletar imagem, pois esta sendo usada", "Imagem Usada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.Hide();
                    funcionario.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Não foi possivel deletar funcionario", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                bd.Conexao.Close();
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
                        destino = aplicacao + "\\Funcionario\\" + foto;
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
        public string Usuario
        {
            set { this.usuario = value; }
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
        public string Senha
        {
            set { this.senha = value; }
        }

        private void tmrHora_Tick(object sender, EventArgs e)
        {
            stripHorario.Text = DateTime.Now.ToString();
        }
    }
}
