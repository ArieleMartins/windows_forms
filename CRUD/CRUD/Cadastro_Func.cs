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
using System.IO;

namespace CRUD
{
    public partial class Cadastro_Func : Form
    {
        private string origem;
        private string foto;
        private string destino;
        private DialogResult resp;
        private int id;
        private string usuario;
        public Cadastro_Func()
        {
            InitializeComponent();
        }

        private void Cadastro_Func_Load(object sender, EventArgs e)
        {
            rbAdmin.Visible = false;
            rbUsu.Visible = false;
            rdF.Checked = true;
            rbAdmin.Checked = false;
            rbUsu.Checked = false;
            gpLogin.Visible = false;
            this.Size = new Size(816, 536);
            BD bd = new BD();
            bd.CargoCB();
            while (bd.Tabela.Read())
            {
                cbCar.Items.Add(bd.Tabela["nome_car"].ToString());
            }
            bd.Tabela.Close();
            bd.Departamento();
            while (bd.Tabela.Read())
            {
                cbDep.Items.Add(bd.Tabela["nome_dep"].ToString());
            }
            bd.Tabela.Close();
            bd.PaisCB();
            while (bd.Tabela.Read())
            {
                cbPAis.Items.Add(bd.Tabela["nome_pais"].ToString());
            }
            bd.Tabela.Close();
            bd.Estado();
            while (bd.Tabela.Read())
            {
                cbEst.Items.Add(bd.Tabela["nome_est"].ToString());
            }
        }

        private void checkSim_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSim.Checked)
            {
                rbAdmin.Visible = true;
                rbUsu.Visible = true;
                gpLogin.Visible = true;
                this.Size = new Size(816, 677);
                rbUsu.Checked = true;
            }
            else
            {
                rbAdmin.Visible = false;
                rbUsu.Visible = false;
                gpLogin.Visible = false;
                this.Size = new Size(816, 536);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNome.Text) || String.IsNullOrWhiteSpace(txtBairro.Text) || String.IsNullOrWhiteSpace(txtCidade.Text) || String.IsNullOrWhiteSpace(txtCTPS.Text) || String.IsNullOrWhiteSpace(txtEmail.Text) || String.IsNullOrWhiteSpace(txtNum.Text) || String.IsNullOrWhiteSpace(txtOrg.Text) || String.IsNullOrWhiteSpace(txtPis.Text) || String.IsNullOrWhiteSpace(txtRua.Text) || String.IsNullOrWhiteSpace(txtSal.Text) || String.IsNullOrWhiteSpace(maskAdmi.Text) || String.IsNullOrWhiteSpace(maskTel.Text) || String.IsNullOrWhiteSpace(maskCPF.Text) || String.IsNullOrWhiteSpace(maskDataNasc.Text) || String.IsNullOrWhiteSpace(maskRG.Text) || String.IsNullOrWhiteSpace(cbPAis.Text) || String.IsNullOrWhiteSpace(cbEst.Text) || String.IsNullOrWhiteSpace(cbDep.Text) || String.IsNullOrWhiteSpace(cbCar.Text))
            {
                MessageBox.Show("Preencha os campos obrigatorios para cadastrar o funcionario", "Campos Obrigatorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                BD bd = new BD();
                try
                {
                    
                        try
                        {

                            bd.Nome = txtNome.Text;
                            bd.Admi = DateTime.Parse(maskAdmi.Text);
                            bd.Bairro = txtBairro.Text;
                            bd.Cargo = int.Parse((cbCar.SelectedIndex + 1).ToString());
                            bd.Cel = maskCel.Text;
                            bd.Cpf = maskCPF.Text;
                            bd.Dep = int.Parse((cbDep.SelectedIndex + 1).ToString());
                            bd.Email = txtEmail.Text;
                            bd.Est = int.Parse((cbEst.SelectedIndex + 1).ToString());
                            bd.Funcao = txtFunc.Text;
                            bd.Nasc = DateTime.Parse(maskDataNasc.Text);
                            bd.Num = txtNum.Text;
                            bd.Org = txtOrg.Text;
                            bd.Pais = int.Parse((cbPAis.SelectedIndex + 1).ToString());
                            bd.Pis = txtPis.Text;
                            bd.Rg = maskRG.Text;
                            bd.Rua = txtRua.Text;
                            bd.Cidade = txtCidade.Text;
                            bd.Salario = double.Parse(txtSal.Text);
                            bd.Ctps = txtCTPS.Text;
                            if (foto == null || origem == null)
                            {
                                resp = MessageBox.Show("Nenhuma foto foi selecionada deseja continuar?", "Sem foto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                if (resp == DialogResult.No)
                                {
                                    return;
                            }
                            else
                            {
                                bd.Foto = "";
                            }

                            }
                            if (foto != null || origem != null)
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
                                            ptFoto.Image = Properties.Resources.Design_sem_nome;

                                        }
                                        else
                                        {
                                            MessageBox.Show("Não foi possivel copiar imagem.");
                                        }
                                    }

                                }
                                else
                                {

                                    File.Copy(origem, destino);
                                    if (File.Exists(destino))
                                    {

                                        bd.Foto = foto;
                                        MessageBox.Show("Arquivo Salvo com Sucesso!");
                                        ptFoto.Image = Properties.Resources.Design_sem_nome;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Não foi possivel salvar o arquivo");
                                    }
                                }
                            }
                            if (rdF.Checked)
                            {
                                bd.Sexo = char.Parse(rdF.Text);
                            }
                            else
                            {
                                bd.Sexo = char.Parse(rdM.Text);
                            }
                            bd.Tel = maskTel.Text;



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
                
                    bd.cadastroFunc();
                    bd.Cpf = maskCPF.Text;
                    bd.IdFunc();
                    bd.Cpf = maskCPF.Text;
                    if (bd.Tabela.HasRows)
                    {
                        if (bd.Tabela.Read())
                        {
                            id = int.Parse(bd.Tabela["id_func"].ToString());
                            if (checkSim.Checked)
                            {
                            if (String.IsNullOrWhiteSpace(txtUsuario.Text) || String.IsNullOrWhiteSpace(txtSenha.Text))
                                {
                                    MessageBox.Show("Preecha os campos usuario e senha ou desmarque a opção de criação de login", "Campos Obrigatorios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    bd.Usuario = txtUsuario.Text;
                                    bd.Senha = txtSenha.Text;
                                    bd.Id = id;
                                    if (rbAdmin.Checked)
                                    {
                                        bd.Privi = 1;
                                    }
                                    else if (rbUsu.Checked)
                                    {
                                        bd.Privi = 2;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Escolha o que usuario poderá fazer com sua conta");
                                       
                                    }
                                    bd.cadastroLog();
                                    if (bd.Resp > 0)
                                    {
                                        rbAdmin.Visible = false;
                                        rbUsu.Visible = false;
                                        rdF.Checked = true;
                                        rbAdmin.Checked = false;
                                        rbUsu.Checked = false;
                                        this.Size = new Size(816, 536);
                                        txtUsuario.Clear();
                                        txtSenha.Clear();

                                    }
                                }
                            }
                            else if (checkSim.Checked == false)
                            {
                                bd.Usuario = "";
                                bd.Senha = "";
                                bd.Id = id;
                                bd.Privi = 3;
                                bd.cadastroLog();
                                if (bd.Resp > 0)
                                {
                                    rbAdmin.Visible = false;
                                    rbUsu.Visible = false;
                                    rdF.Checked = true;
                                    rbAdmin.Checked = false;
                                    rbUsu.Checked = false;
                                    this.Size = new Size(816, 536);
                                    txtUsuario.Clear();
                                    txtSenha.Clear();

                                }
                            }

                        }
                        else
                        {
                            Console.WriteLine("Não foi possivel pegar o id do funcionario");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não foi possivel pegar o id do funcionario");
                    }
                    bd.Tabela.Close();
                    if (bd.Resp > 0)
                    {
                        MessageBox.Show("Funcionario cadastrado com sucesso");
                        txtNome.Clear();
                        maskAdmi.Clear();
                        txtBairro.Clear();
                        cbCar.Text = "";
                        maskCel.Clear();
                        maskCPF.Clear();
                        cbDep.Text = "";
                        txtEmail.Clear();
                        cbEst.Text = "";
                        txtFunc.Clear();
                        maskDataNasc.Clear();
                        txtNum.Clear();
                        txtOrg.Clear();
                        cbPAis.Text = "";
                        txtPis.Clear();
                        maskRG.Clear();
                        txtRua.Clear();
                        txtSal.Clear();
                        maskTel.Clear();
                        txtCidade.Clear();
                        txtCTPS.Clear();
                        txtNome.Focus();
                        checkSim.Checked = false;
                        ptFoto.Image = Properties.Resources.Design_sem_nome;
                    }
                    bd.Conexao.Close();

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Menu menu = new Menu();
            BD bd = new BD();
            menu.Usuario = usuario;
            this.Hide();
            menu.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
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
                }catch (System.IO.DirectoryNotFoundException err)
                {
                    MessageBox.Show("Não foi possivel encontrar o deiretorio de destino", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch (Exception)
            {
                MessageBox.Show("Erro ao carregar imagem", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string Usuario
        {
            set { this.usuario = value; }
        }

        private void pcBImg_MouseEnter(object sender, EventArgs e)
        {
            pcBImg.Image = Properties.Resources.CameraIcon2Brilante;
        }

        private void pcBImg_MouseLeave(object sender, EventArgs e)
        {
            pcBImg.Image = Properties.Resources.CameraIcon2;
        }
    }
}
