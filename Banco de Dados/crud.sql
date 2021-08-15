-- OBSERVAÇÕES\ALERTAS: NÃO FAÇA CADASTROS DE ALUNOS COM A CONTA ADMIN, POIS É NECESSARIO QUE O LOGIN
-- TENHA UM FUNCIONÁRIO VINCULADO. SE FOR CADASTRAR FUNCIONÁRIOS COM A CONTA ADMIN DARÁ ERRO, MAS O FUNCIONÁRIO SERÁ CADASTRADO, POIS
-- TAMBEM É NECESSÁRIO POSSUIR UM FUNCIONÁRIO VINCULADO COM A CONTA\LOGIN, PORÉM VOCÊ PODE E DEVE PARA PRIMEIRO ACESSO CADASTRAR UM
-- FUNCIONÁRIO COM ESSA CONTA E CRIAR UM LOGIN PARA ESSE FUNCIONÁIO E UTILIZA-LO PARA FAZER CADASTRO DE
-- ALUNOS E FUNCIONÁRIOS, NÃO DARÁ ERRO...PELO MENOS É O QUE EU ESPERO. MAS ESSE PRIMEIRO FUNCIONÁRIO NÃO SERÁ MARCADO\REGISTRADO NA TABELA DE
-- RELAÇÃO DA TABELA FUNCIONÁRIO COM ELA MESMA, ENTÃO O USUÁRIO NÃO PODERÁ VER QUEM REGISTROU ESSE FUNCIONÁRIO.
-- CRIAR TURMAS: PARA CRIAR UMA TURMA DEVE SE TER UM FUNCIONÁIO CADASTRADO COMO DOCENTE.
-- CADASTRO DE ALUNOS: PARA PRIMEIRO ACESSO TEM (É OBRIGATORIO) QUE CRIAR UMA TURMA PRIMEIRO PARA EXECUTAR O CADATRO DO ALUNO.

-- CRIANDO BANCO DE DADOS
create database db_crud;
use db_crud;

-- TABELA DE PRIVILÉGIO PARA LOGIN
create table tb_privi(id_privi int primary key not null auto_increment,
nome_privi varchar(100) not null);

-- INSERINDO PRIVILÉGIOS
insert into tb_privi(nome_privi) values("Administrador"), ("Usuário"), ("Sem Usuário");

-- TABELA ESTADO
create table tb_estado(id_est int primary key not null auto_increment,
nome_est char(2) not null);

-- INSERINDO ESTADOS
insert into tb_estado(nome_est) values('AC'),
 ('AL'), ('AP'), ('AM'), ('BA'), 
 ('CE'), ('DF'), ('ES'), ('GO'),
 ('MA'), ('MT'), ('MS'), ('MG'),
 ('PA'), ('PB'), ('PR'), ('PE'),
 ('PI'), ('RN'), ('RS'), ('RJ'),
 ('RO'), ('RR'), ('SC'), ('SP'),
  ('SE'), ('TO');

-- TABELA PAIS
create table tb_pais(id_pais int primary key not null auto_increment,
nome_pais varchar(100) not null);

-- INSERINDO OS PAISES
insert into tb_pais(nome_pais) values("Argentina"),
("Austrália"), ("Áustria"), ("Bélgica"), ("Bolivia"), ("Brasil"),
("Canadá"), ("Croácia"), ("Chile"), ("China"), ("Cuba"), ("Dinamarca"),
("Inglaterra"), ("França"), ("Finlândia"), ("Alemanha"), ("Grécia"), ("Islândia"),
("Índia"), ("Iraque"), ("Irlanda"), ("Itália"), ("Jamaica"), ("Quênia"),
("México"), ("NetherLands"), ("Nova Zelândia"), ("Noruega"), ("Paraguai"),
("Portugal"), ("Polônia"), ("Rússia"), ("Escócia"), ("Espanha"), ("Suécia"),
("Suíça"), ("África do Sul"), ("Turquia"), ("Reino Unido"), ("Estados Unidos"),
("Uruguai"), ("Wales"), ("Zimbabué");

-- TABELA HORARIO
create table tb_hora(id_h int primary key not null auto_increment,
hora_h varchar(100) not null);

-- INSERINDO OS HORARIOS DO CURSO
insert into tb_hora(hora_h) values("Manhã: 8:00 ás 12:00"),
("Tarde: 13:00 ás 17:00"), ("Noite: 19:00 ás 22:00");

-- TABELA CARGO
create table tb_cargo(id_car int primary key not null auto_increment,
nome_car varchar(100) not null);

-- iINSERINDO CARGOS
insert into tb_cargo(nome_car) values("Docente"),
("Administrador"), ("Recepcionista"), ("Assitente Administrativo"), ("Recrutador"), ("Faxineira"),
("Merendeira"), ("Diretor"), ("Porteiro"), ("Segurança"),
("Coordenador"), ("Supervidor"), ("Vice-Diretor"), ("Zelador");

-- TABELA DEPARTAMENTO
create table tb_departamento(id_dep int primary key not null auto_increment,
nome_dep varchar(100) not null);

-- INSERINDO DEPARTAMENTOS
insert into tb_departamento(nome_dep) values("Administrativo"),
("RH"), ("Comercial"), ("Operacional"), ("Pedagógico"), ("Financeiro"), ("Secretaria"), ("Serviços Gerais"), ("Segurança do Trabalho"),
("Acadêmico");

-- TABELA CURSO
create table tb_curso (id_c int primary key not null auto_increment,
nome_c varchar(100) not null);

-- INSERINDO CURSOS
insert into tb_curso(nome_c) values("Desenvolvedor Web"),
("Produções de Games 2D"), ("Montagem e Manutenção de Computadores"),
("Técnico em Redes"), ("Técnico em Informática"), ("Informática Básica"), ("Artes Digitais"),
("Eletronica");

-- TABELA ALUNO
create table tb_aluno(id_aluno int primary key not null auto_increment,
nome_a varchar(100) not null, sexo_a char(1) not null, dtnasc_a date not null, cpf_a varchar(14) not null unique,
rg_a varchar(14) not null,org_a varchar(100), resp_a varchar(100), email_a varchar(100) not null, tel_a varchar(17) not null,
cel_a varchar(18), rua_a varchar(100) not null, cidade_a varchar(100) not null, bairro_a varchar(100) not null, n_a varchar(100) not null,
matri_a date not null, foto_a varchar(100), id_pais int not null, id_est int not null, id_c int not null, id_h int not null,
constraint fk_pais_a foreign key (id_pais) references tb_pais(id_pais) on delete cascade on update cascade,
constraint fk_est_a foreign key (id_est) references tb_estado(id_est) on delete cascade on update cascade,
constraint fk_c_a foreign key (id_c) references tb_curso(id_c) on delete cascade on update cascade,
constraint fk_h_a foreign key (id_h) references tb_hora(id_h) on delete cascade on update cascade);

-- TABELA FUNCIONARIO
create table tb_func(id_func int primary key not null auto_increment,
nome_func varchar(100) not null, sexo_func char(1) not null, data_func date not null, cpf_func varchar(14) not null unique, rg_func varchar(14) not null,
org_func varchar(100) not null,pis_func varchar(14) not null, email_func varchar(100) not null,
tel_func varchar(17) not null, cel_func varchar(18), carte_func varchar(14), rua_func varchar(100) not null,
bairro_func varchar(100) not null, cidade_func varchar(100) not null, n_func varchar(100), admi_func date not null, salario_func decimal(10, 2) not null,
func_func varchar(1000), foto_func varchar(200),func_cad int unique default 0 not null, id_car int not null, id_dep int not null, id_est int not null, id_pais int not null,
constraint fk_est_func foreign key (id_est) references tb_estado(id_est) on delete cascade on update cascade,
constraint fk_pais_func foreign key (id_pais) references tb_pais(id_pais) on delete cascade on update cascade,
constraint fk_car_func foreign key (id_car) references tb_cargo(id_car) on delete cascade on update cascade,
constraint fk_dep_func foreign key (id_dep) references tb_departamento(id_dep) on delete cascade on update cascade);

-- TABELA TURMA
create table tb_turma(id_t int primary key not null auto_increment,
nome_t varchar(100) not null,num_t int not null, max_a int not null, est_t varchar(100), id_c int, id_h int, id_func int, 
constraint fk_c_t foreign key (id_c) references tb_curso(id_c) on delete cascade on update cascade,
constraint fk_h_t foreign key (id_h) references tb_hora(id_h) on delete cascade on update cascade,
constraint fk_t_f foreign key (id_func) references tb_func(id_func) on delete cascade on update cascade);

-- TABELA DE RELAÇÃO ALUNO, TURMA, CURSO E HORARIO
create table tb_fk_a_t(id_t int, id_c int, id_h int, id_aluno int, constraint fk_t_a foreign key (id_t) references tb_turma(id_t) on delete cascade on update cascade,
constraint fk_a_t foreign key (id_aluno) references tb_aluno(id_aluno) on delete cascade on update cascade, constraint fk_t_c foreign key (id_c) references tb_curso(id_c) on delete cascade on update cascade,
constraint fk_t_h foreign key (id_h) references tb_hora(id_h) on delete cascade on update cascade);

-- TABELA LOGIN
create table tb_login(id_log int primary key auto_increment,
usuario_log varchar(100) not null, senha_log varchar(100) not null, id_privi int not null, id_func int,
constraint fk_l_p foreign key (id_privi) references tb_privi(id_privi) on delete cascade on update cascade,
 constraint fk_log_f foreign key (id_func) references tb_func(id_func) on delete cascade on update cascade);

-- INSERINDO LOGIN PARA TESTE
insert into tb_login(usuario_log, senha_log, id_privi) value("Admin", "123", 1);

-- TABELA DE RELAÇÃO DE FUNCIONARIO COM A TABELA ALUNO
create table tb_fk_f_a(id_func int not null, id_aluno int not null,
constraint fk_f_a foreign key (id_func) references tb_func(id_func) on delete cascade on update cascade ,
constraint fk_a_f foreign key (id_aluno) references tb_aluno(id_aluno) on delete cascade on update cascade);

-- TABELA DE RELAÇÃO DE FUNCIONARIO COM ELA MESMA
create table tb_fk_f_f(id_func int default 0 not null, func_cad int, constraint fk_f_f foreign key (id_func) references tb_func(id_func) on delete cascade on update cascade);

-- DELETAR TABELA SE FOR NECESSÁRIO MUDAR ALGO
drop database db_crud;