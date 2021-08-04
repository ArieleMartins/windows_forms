create database db_crud;
use db_crud;

-- tabela de privilegio
create table tb_privi(id_privi int primary key not null auto_increment,
nome_privi varchar(100) not null);

insert into tb_privi(nome_privi) values("Administrador"), ("Usuário"), ("Sem Usuário");


-- tabela estado
create table tb_estado(id_est int primary key not null auto_increment,
nome_est char(2) not null);

-- inserindo os estados
insert into tb_estado(nome_est) values('AC'),
 ('AL'), ('AP'), ('AM'), ('BA'), 
 ('CE'), ('DF'), ('ES'), ('GO'),
 ('MA'), ('MT'), ('MS'), ('MG'),
 ('PA'), ('PB'), ('PR'), ('PE'),
 ('PI'), ('RN'), ('RS'), ('RJ'),
 ('RO'), ('RR'), ('SC'), ('SP'),
  ('SE'), ('TO');

-- tabela pais
create table tb_pais(id_pais int primary key not null auto_increment,
nome_pais varchar(100) not null);

-- inserindo os paises
insert into tb_pais(nome_pais) values("Argentina"),
("Austrália"), ("Áustria"), ("Bélgica"), ("Bolivia"), ("Brasil"),
("Canadá"), ("Croácia"), ("Chile"), ("China"), ("Cuba"), ("Dinamarca"),
("Inglaterra"), ("França"), ("Finlândia"), ("Alemanha"), ("Grécia"), ("Islândia"),
("Índia"), ("Iraque"), ("Irlanda"), ("Itália"), ("Jamaica"), ("Quênia"),
("México"), ("NetherLands"), ("Nova Zelândia"), ("Noruega"), ("Paraguai"),
("Portugal"), ("Polônia"), ("Rússia"), ("Escócia"), ("Espanha"), ("Suécia"),
("Suíça"), ("África do Sul"), ("Turquia"), ("Reino Unido"), ("Estados Unidos"),
("Uruguai"), ("Wales"), ("Zimbabué");

-- tabela horário
create table tb_hora(id_h int primary key not null auto_increment,
hora_h varchar(100) not null);

-- inserindo os horários do curso
insert into tb_hora(hora_h) values("Manhã: 8:00 ás 12:00"),
("Tarde: 13:00 ás 17:00"), ("Noite: 19:00 ás 22:00");

-- tabela cargo
create table tb_cargo(id_car int primary key not null auto_increment,
nome_car varchar(100) not null);

-- inserindo os cargos
insert into tb_cargo(nome_car) values("Docente"),
("Administrador"), ("Recepcionista"), ("Assitente Administrativo"), ("Recrutador"), ("Faxineira"),
("Merendeira"), ("Diretor"), ("Porteiro"), ("Segurança"),
("Coordenador"), ("Supervidor"), ("Vice-Diretor"), ("Zelador");

-- tabela departamento
create table tb_departamento(id_dep int primary key not null auto_increment,
nome_dep varchar(100) not null);

-- inserindo os departamentos
insert into tb_departamento(nome_dep) values("Administrativo"),
("RH"), ("Comercial"), ("Operacional"), ("Pedagógico"), ("Financeiro"), ("Secretaria");

-- tabel turma
create table tb_turma(id_t int primary key not null auto_increment,
nome_t varchar(100) not null);

insert into tb_turma(nome_t) values("Desenvolvedor Web Básica"), ("Desenvolvedor Web Avançado"), 
("Eletronica Básica"),("Eletronica Avançada"), ("Artes Digitais Básica"),("Artes Digitais Avançado"), ("Produções de Games 2D Básica"),
("Produções de Games 2D Avançado"),
("Técnico em Inforática e Ensino Médio"), ("Técnico em Informatica"), ("Técnico em Redes"),
("Informatica Básica"), ("Montagem e Manutenção de Computadores");
-- tabela estado
-- create table tb_endereco(id_e int primary key not null auto_increment,
-- rua_e varchar(100) not null, bairro_e varchar(100) not null,
-- cidade_e varchar(100) not null, id_est int not null);

-- tabela curso
create table tb_curso (id_c int primary key not null auto_increment,
nome_c varchar(100) not null);

insert into tb_curso(nome_c) values("Desenvolvedor Web"),
("Produções de Games 2D"), ("Montagem e Manutenção de Computadores"),
("Técnico em Redes"), ("Técnico em Informática"), ("Informática Básica"), ("Artes Digitais"),
("Eletronica");



-- tabela aluno
create table tb_aluno(id_aluno int primary key not null auto_increment,
nome_a varchar(100) not null, sexo_a char(1) not null, dtnasc_a date not null, cpf_a varchar(14) not null unique,
rg_a varchar(14) not null,org_a varchar(100), resp_a varchar(100), email_a varchar(100) not null, tel_a varchar(17) not null,
cel_a varchar(18), rua_a varchar(100) not null, cidade_a varchar(100) not null, bairro_a varchar(100) not null, n_a varchar(100) not null,
matri_a date not null, foto_a varchar(100), id_pais int not null, id_est int not null, id_c int not null, id_h int not null,
constraint fk_pais_a foreign key (id_pais) references tb_pais(id_pais) on delete cascade on update cascade,
constraint fk_est_a foreign key (id_est) references tb_estado(id_est) on delete cascade on update cascade,
constraint fk_c_a foreign key (id_c) references tb_curso(id_c) on delete cascade on update cascade,
constraint fk_h_a foreign key (id_h) references tb_hora(id_h) on delete cascade on update cascade);

create table tb_fk_a_t(id_t int, id_c int, id_h int, id_aluno int, constraint fk_t_a foreign key (id_t) references tb_turma(id_t) on delete cascade on update cascade,
constraint fk_a_t foreign key (id_aluno) references tb_aluno(id_aluno) on delete cascade on update cascade, constraint fk_t_c foreign key (id_c) references tb_curso(id_c) on delete cascade on update cascade,
constraint fk_t_h foreign key (id_h) references tb_hora(id_h) on delete cascade on update cascade);

-- tabela funcionario
create table tb_func(id_func int primary key not null auto_increment,
nome_func varchar(100) not null, sexo_func char(1) not null, data_func date not null, cpf_func varchar(14) not null unique, rg_func varchar(14) not null,
org_func varchar(100) not null,pis_func varchar(14) not null, email_func varchar(100) not null,
tel_func varchar(17) not null, cel_func varchar(18), carte_func varchar(14), rua_func varchar(100) not null,
bairro_func varchar(100) not null, cidade_func varchar(100) not null, n_func varchar(100), admi_func date not null, salario_func decimal(10, 2) not null,
func_func varchar(1000), foto_func varchar(200), id_car int not null, id_dep int not null, id_est int not null, id_pais int not null,
constraint fk_est_func foreign key (id_est) references tb_estado(id_est) on delete cascade on update cascade,
constraint fk_pais_func foreign key (id_pais) references tb_pais(id_pais) on delete cascade on update cascade,
constraint fk_car_func foreign key (id_car) references tb_cargo(id_car) on delete cascade on update cascade,
constraint fk_dep_func foreign key (id_dep) references tb_departamento(id_dep) on delete cascade on update cascade);

create table tb_login(id_log int primary key auto_increment,
usuario_log varchar(100) not null, senha_log varchar(100) not null, id_privi int not null, id_func int,
constraint fk_l_p foreign key (id_privi) references tb_privi(id_privi) on delete cascade on update cascade,
 constraint fk_log_f foreign key (id_func) references tb_func(id_func) on delete cascade on update cascade);

insert into tb_login(usuario_log, senha_log, id_privi) value("Admin", "123", 1);

-- tabela de relação da tabela funcionario com a tabela aluno
create table tb_fk_f_a(id_func int not null, id_aluno int not null,
constraint fk_f_a foreign key (id_func) references tb_func(id_func) on delete cascade on update cascade ,
constraint fk_a_f foreign key (id_aluno) references tb_aluno(id_aluno) on delete cascade on update cascade);

-- Tabela de relacão da tabela funcionario com a tabela funcionario
create table tb_fk_f_f(id_func int, cad_func int, constraint fk_f_f foreign key (id_func) references tb_func(id_func));


-- deletar a tabela caso algo de errado.

drop database db_crud;