using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace CRUD
{
    class BD
    {
        private string caminho = "server= localhost; database= db_crud; user= root";
        private MySqlConnection conexao;
        private string sql;
        private MySqlCommand command;
        private MySqlDataReader tabela;
        private int id;
        private string cpf;
        private string nome;
        private string rg;
        private DateTime admi;
        private DateTime nasc;
        private string tel;
        private string cel;
        private string rua;
        private string bairro;
        private string cidade;
        private int est;
        private int pais;
        private string org;
        private string pis;
        private string ctps;
        private string num;
        private int cargo;
        private int dep;
        private double salario;
        private char sexo;
        private string email;
        private string funcao;
        private string log;

        private int resp;

        private string usuario;
        private string senha;
        private int privi;
        private int cad;

        private int idlog;
        private string usuario_log;
        private string senha_log;

        private string nomeimg;
        private string foto;

        private int curso;
        private int hora;
        private int turma;
        private int idaluno;
        private string responsavel;
        private DateTime matricula;
        public MySqlConnection Conexao
        {
            get { return this.conexao; }
        }
        public void DeletarFunc()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"delete from tb_func where id_func = {id}";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void DeletarAlu()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"delete from tb_aluno where id_aluno = {idaluno}";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void DeletarLog()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"delete from tb_login where id_func = {idlog}";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void UpdateConLog()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"update tb_login " +
                    $"set usuario_log = '{usuario}', senha_log = '{senha}', id_privi = {privi} where tb_login.id_func = {id}";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void UpdateCon()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"update tb_func " +
                    $"set nome_func = '{nome}', sexo_func = '{sexo}', data_func = '{nasc.ToString("yyyy/MM/d")}', cpf_func = '{cpf}', rg_func = '{rg}',org_func = '{org}',pis_func = '{pis}', email_func = '{email}',tel_func = '{tel}', cel_func = '{cel}',carte_func = '{ctps}', rua_func = '{rua}',bairro_func = '{bairro}', cidade_func = '{cidade}', n_func = '{num}', admi_func = '{admi.ToString("yyyy/MM/d")}', salario_func = {salario},func_func = '{funcao}', id_car = {cargo}, id_dep = {dep}, id_est = {est}, id_pais = {pais}, foto_func = '{foto}' where tb_func.id_func = {id}";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void UpdateAlu()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"update tb_aluno " +
                    $"set nome_a = '{nome}', sexo_a = '{sexo}', dtnasc_a = '{nasc.ToString("yyyy/MM/d")}', cpf_a = '{cpf}', rg_a = '{rg}', org_a = '{org}', email_a = '{email}', tel_a = '{tel}', cel_a = '{cel}', rua_a = '{rua}', bairro_a = '{bairro}', cidade_a = '{cidade}', n_a = '{num}', matri_a = '{matricula.ToString("yyyy/MM/d")}', resp_a = '{responsavel}', id_est = { est }, id_pais = { pais }, foto_a = '{foto}', id_c = {curso}, id_h = { hora } where tb_aluno.id_aluno = {idaluno}; ";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void UpdateTu()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"update tb_fk_a_t " +
                    $"set id_t = {turma}, id_c = {curso} where id_aluno = {idaluno};";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void CadastroAluno()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"insert into tb_aluno(nome_a, sexo_a, dtnasc_a, cpf_a, rg_a, org_a, email_a, tel_a, cel_a, rua_a, bairro_a, cidade_a, n_a, matri_a, id_est, id_pais, id_c, id_h , foto_a, resp_a) values('{nome}', '{sexo}', '{nasc.ToString("yyyy/MM/d")}', '{cpf}', '{rg}' , '{org}', '{email}', '{tel}', '{cel}', '{rua}', '{bairro}', '{cidade}', '{num}', '{matricula.ToString("yyyy/MM/d")}', {est}, {pais}, {curso}, {hora}, '{foto}', '{responsavel}'); ";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public int IdCurso
        {
            set { this.curso = value; }
        }
        public int Hora
        {
            set { this.hora = value; }
        }
        public int IdTurma
        {
            set { this.turma = value; }
        }
        public string Responsavel
        {
            set { this.responsavel = value; }
        }
        public int IdAluno
        {
            set { this.idaluno = value; }
        }
        public void SelectAluno()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_aluno where cpf_a = '{cpf}'";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void CadTurma()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"insert into tb_fk_a_t(id_t, id_aluno, id_c, id_h) values ({turma}, {idaluno}, {curso}, {hora})";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void Turma()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_turma";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void Curso()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_curso";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void Horario()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_hora";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
      
        public void Consultar()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_func left join tb_login on tb_func.id_func = tb_login.id_func inner join tb_cargo on tb_func.id_car = tb_cargo.id_car inner join tb_departamento on tb_func.id_dep = tb_departamento.id_dep inner join tb_pais on tb_func.id_pais = tb_pais.id_pais inner join tb_estado on tb_func.id_est = tb_estado.id_est where tb_func.id_func = {id} and cpf_func = '{cpf}'";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void ImprimiFunc()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_func left join tb_login on tb_func.id_func = tb_login.id_func inner join tb_cargo on tb_func.id_car = tb_cargo.id_car inner join tb_departamento on tb_func.id_dep = tb_departamento.id_dep inner join tb_pais on tb_func.id_pais = tb_pais.id_pais inner join tb_estado on tb_func.id_est = tb_estado.id_est where nome_func = '{nome}' and cpf_func = '{cpf}'";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void ConsAlu()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_aluno inner join tb_curso on tb_aluno.id_c = tb_curso.id_c inner join tb_pais on tb_aluno.id_pais = tb_pais.id_pais inner join tb_estado on tb_aluno.id_est = tb_estado.id_est where id_aluno = {idaluno} and cpf_a = '{cpf}'";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void ImprimirAlu()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_aluno inner join tb_curso on tb_aluno.id_c = tb_curso.id_c inner join tb_pais on tb_aluno.id_pais = tb_pais.id_pais inner join tb_estado on tb_aluno.id_est = tb_estado.id_est where cpf_a = '{cpf}' and nome_a = '{nome}'";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void ConsTu()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_fk_a_t inner join tb_aluno on tb_fk_a_t.id_aluno = tb_aluno.id_aluno left join tb_turma on tb_fk_a_t.id_t = tb_turma.id_t inner join tb_curso on tb_fk_a_t.id_c = tb_curso.id_c inner join tb_hora on tb_fk_a_t.id_h = tb_hora.id_h inner join tb_estado on tb_aluno.id_est = tb_estado.id_est inner join tb_pais on tb_aluno.id_pais = tb_pais.id_pais";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void ConsTuA()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_fk_a_t inner join tb_aluno on tb_fk_a_t.id_aluno = tb_aluno.id_aluno left join tb_turma on tb_fk_a_t.id_t = tb_turma.id_t inner join tb_curso on tb_fk_a_t.id_c = tb_curso.id_c inner join tb_hora on tb_fk_a_t.id_h = tb_hora.id_h inner join tb_estado on tb_aluno.id_est = tb_estado.id_est inner join tb_pais on tb_aluno.id_pais = tb_pais.id_pais where tb_aluno.id_aluno = {idaluno} and cpf_a = '{cpf}'";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public string NomeImg
        {
            set { this.nomeimg = value; }
        }
        public string Foto
        {
            get { return this.foto; }
            set { this.foto = value; }
        }
        public void Logar()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_login where usuario_log = '{usuario_log}' and senha_log = '{senha_log}'";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Servidor não disponivel, tente mais tarde");
            }
        }
        public void ListaFuncionarios()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_fk_f_f inner join tb_func on tb_fk_f_f.func_cad = tb_func.func_cad where tb_fk_f_f.id_func = {id}";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Servidor não disponivel, tente mais tarde");
            }
        }
        public string UsuarioLog
        {
            set { this.usuario_log = value; }
        }
        public string SenhaLog
        {
            set { this.senha_log = value; }
        }
        public void Lista()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                    sql = "select * from tb_func inner join tb_departamento on tb_func.id_dep = tb_departamento.id_dep inner join tb_cargo on tb_func.id_car = tb_cargo.id_car left join tb_login on tb_func.id_func = tb_login.id_func;";
                    command = new MySqlCommand(sql, conexao);
                    tabela = command.ExecuteReader();
            }catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        public void Estado()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = "select * from tb_estado";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void CargoCB()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = "select * from tb_cargo";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void Departamento()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = "select * from tb_departamento";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void PaisCB()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = "select * from tb_pais";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public MySqlDataReader Tabela
        {
            get { return this.tabela; }
            set { this.tabela = value; }
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Cpf
        {
            get { return this.cpf; }
            set { this.cpf = value; }
        }

        public void IdFunc()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_func where cpf_func = '{cpf}'";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void cadastroFunc()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"insert into tb_func(nome_func, sexo_func, data_func, cpf_func, rg_func, org_func, pis_func, email_func, tel_func, cel_func, carte_func, rua_func, bairro_func, cidade_func, n_func, admi_func, salario_func, func_func, id_car, id_dep, id_est, id_pais, foto_func, func_cad) values('{nome}', '{sexo}', '{nasc.ToString("yyyy/MM/d")}', '{cpf}', '{rg}' , '{org}', '{pis}', '{email}', '{tel}', '{cel}', '{ctps}', '{rua}', '{bairro}', '{cidade}', '{num}', '{admi.ToString("yyyy/MM/d")}', {salario}, '{funcao}', {cargo}, {dep}, {est}, {pais}, '{foto}', {cad}); ";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
               MessageBox.Show(err.ToString());
            }
        }

        public void cadastroLog()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"insert into tb_login(usuario_log, senha_log, id_privi, id_func) values('{usuario}', '{senha}', {privi}, {id});";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void Funcionarios()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"insert into tb_fk_f_f(id_func, func_cad) values({id}, {cad});";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void IdLog() 
        {
            try
            {
            conexao = new MySqlConnection(caminho);
            conexao.Open();
            sql = $" select * from tb_login where usuario_log = '{usuario}' and senha_log = '{senha}'";
            command = new MySqlCommand(sql, conexao);
            tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
              MessageBox.Show(err.ToString());
            }
        }
        public void CliId()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_func inner join tb_login on tb_func.id_func = tb_login.id_func where usuario_log = '{usuario}' and senha_log = '{senha}';";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void TabCliFun()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"insert into tb_fk_f_a(id_func, id_aluno) values({id}, {idaluno})";
                command = new MySqlCommand(sql, conexao);
                resp = command.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
               MessageBox.Show(err.ToString());
            }
        }
        public void Alunos()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = "select * from tb_fk_f_a inner join tb_func on tb_fk_f_a.id_func = tb_func.id_func inner join tb_aluno on tb_fk_f_a.id_aluno = tb_aluno.id_aluno";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void ListaAlu()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = "select * from tb_aluno inner join tb_curso on tb_aluno.id_c = tb_curso.id_c";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public void ListFA()
        {
            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                sql = $"select * from tb_fk_f_a inner join tb_func on tb_fk_f_a.id_func = tb_func.id_func inner join tb_aluno on tb_fk_f_a.id_aluno = tb_aluno.id_aluno where tb_func.id_func = {id} and cpf_func = '{cpf}'";
                command = new MySqlCommand(sql, conexao);
                tabela = command.ExecuteReader();
            }
            catch (MySqlException err)
            {
                MessageBox.Show(err.ToString());
            }
        }
        public int IdLogin
        {
            set { this.idlog = value; }
        }
        public string Usuario
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
        public string Senha
        {
            get { return this.senha; }
            set { this.senha = value; }
        }
        public int Privi
        {
            get { return this.privi; }
            set { this.privi = value; }
        }
        public int Resp
        {
            get { return this.resp; }
            set { this.resp = value; }
        }
        public string Ctps
        {
            get { return this.ctps; }
            set { this.ctps = value; }
        }
        public string Nome
        {
            get { return this.nome; }
            set { this.nome = value; }
        }
        public char Sexo
        {
            get { return this.sexo; }
            set { this.sexo = value; }
        }
        public DateTime Nasc
        {
            get { return this.nasc; }
            set { this.nasc = value; }
        }
        public string Rg
        {
            get { return this.rg; }
            set { this.rg = value; }
        }
        public string Org
        {
            get { return this.org; }
            set { this.org = value; }
        }
        public string Pis
        {
            get { return this.pis; }
            set { this.pis = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string Tel
        {
            get { return this.tel; }
            set { this.tel = value; }
        }
        public string Cel
        {
            get { return this.cel; }
            set { this.cel = value; }
        }
        public string Rua
        {
            get { return this.rua; }
            set { this.rua = value; }
        }
        public string Bairro
        {
            get { return this.bairro; }
            set { this.bairro = value; }
        }
        public string Num
        {
            get { return this.num; }
            set{ this.num = value; }
        }
        public DateTime Admi
        {
            get { return this.admi; }
            set { this.admi = value; }
        }
        public double Salario
        {
            get { return this.salario; }
            set { this.salario = value; }
        }
        public string Funcao
        {
            get { return this.funcao; }
            set { this.funcao = value; }
        }
        public int Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }
        public int Dep
        {
            get { return this.dep; }
            set { this.dep = value; }
        }
        public int Est
        {
            get { return this.est; }
            set { this.est = value; }
        }
        public int Pais
        {
            get { return this.pais; }
            set { this.pais = value; }
        }
        public string Log
        {
            get { return this.log; }
            set { this.log = value; }
        }
        public string Cidade
        {
            get { return this.cidade; }
            set { this.cidade = value; }
        }
        public DateTime Matri
        {
            set { this.matricula = value; }
            get { return this.matricula; }
        }
        public int Cad
        {
            set { this.cad = value; }
            get { return this.cad; }
        }
    }
}
