#################################################################################
######################### SISTEMA COMERCIAL SISCREAM 1.0 ########################

################################## ALUNOS #######################################
# André Raymundo | Gabriel Henrique | Gabrielly Lorraynne | Paulo Santos        #
# Thallia Michelle | Victor Daniel                                              #
#################################################################################

############################ REQUISITOS FUNCIONAIS ##############################
# Cadastrar Cliente, Cadastrar Funcionário, Vender Produto, Abrir Caixa         #
# Fazer Login, Cadastrar Produto, Lançar gasto, Fechar caixa, Consultar         #
# estoque, Devolver produto, Consultar cliente, Repor estoque             #
#################################################################################

############################## BANCO DE DADOS ###################################

CREATE DATABASE siscream;
USE siscream;

################################# TABELAS #######################################

CREATE TABLE tb_produto (
	cod_prod int not null PRIMARY KEY auto_increment,
	nome_prod varchar (100) not null,
	unidademed_prod varchar (100) not null,
	datavalidade_prod date not null,
	tipo_prod varchar (100) not null,
    estoque_prod int,
	fabricante_prod varchar (100) not null,
	marca_prod varchar (100) not null,
	codbarras_prod varchar (100) not null,
	comissao_prod int not null,
	preco_prod float not null,
	custo_prod float not null,
	descricao_prod varchar (200) not null
);



CREATE TABLE tb_endereco (
    cod_end int not null PRIMARY KEY auto_increment,
    logradouro_end varchar (100) not null, 
    numero_end varchar(5) not null,
    bairro_end varchar(15) not null,
    cidade_end varchar (100) not null, 
    uf_end varchar(100) not null,
    cep_end varchar (100) not null 
);

CREATE TABLE tb_caixa (
    cod_caixa int primary key not null auto_increment,
    funcionario_caixa varchar (100),
	valorAbertura_caixa float,
    data_abt date,
	suprimento float,
    dinheiro_caixa float,
	credito_caixa float,
	debito_caixa float,
    total_caixa float,
    valor_retirado_caixa float,
    especificacoes varchar(500),
    saldofinal_caixa float
);

CREATE TABLE tb_funcionario (
    cod_func int not null PRIMARY KEY auto_increment,
    nome_func varchar (100) not null,
    cpf_func varchar (11) not null,
    sexo_func varchar (20) not null, 
    nascimento_func date,
    telefone_func varchar (20), 
    email_func varchar (50),
    rg_func varchar (15) not null,
    cargo_func varchar (20) not null,
    tipoContrato_func varchar (20) not null,
    senha_func varchar (20) not null,
    dataAdmissao_func date not null,
    cod_end_fk int not null,
    salario_func float not null,
	foreign key (cod_end_fk) references tb_endereco (cod_end)
);

CREATE TABLE tb_cliente (
    cod_cli int not null PRIMARY KEY auto_increment,
    nome_cli varchar (100) not null,
    cnpj_cli varchar (20),
    email_cli varchar(100),
    inscricao_cli varchar(100),
	celular_cli varchar(100),
    telefone_cli varchar(100),
    cod_end_fk int not null,
	foreign key (cod_end_fk) references tb_endereco (cod_end)
);

CREATE TABLE tb_venda (
    cod_venda int primary key not null auto_increment,
	valor_venda float,
    formaPagamento_venda varchar(100),
	data_venda date,
    cod_caixa_fk int not null,
	foreign key (cod_caixa_fk) references tb_Caixa (cod_caixa)
);

CREATE TABLE tb_gasto (
	cod_gas int not null primary key auto_increment,
	Descricao_gas varchar (100) not null,
	valor_gas float not null,
	data_gas date,
	cod_caixa_fk int not null,
	foreign key (cod_caixa_fk) references tb_Caixa (cod_caixa) 
);

CREATE TABLE tb_login(
	cod_log int not null primary key auto_increment,
    cod_func_fk int not null,
    cpf_log varchar(100),
    senha_log varchar(100),
	foreign key (cod_func_fk) references tb_funcionario (cod_func) 
);

CREATE TABLE tb_Venda_Produto (
	cod_vendaProd int not null PRIMARY KEY auto_increment,
	quantidade_prodVenda int,
    valor_prodVenda double,
    valorTotal_prodVenda double,
	cod_prod_fk int not null,
	foreign key (cod_prod_fk) references tb_produto (cod_prod)
);

CREATE TABLE tb_devolver_produto (
	cod_dev_pro int not null PRIMARY KEY auto_increment,
	cod_prod_fk int not null,
    data_dev_pro date,
    valor_dev_pro FLOAT,
    valor_total_dev_prod FLOAT,
	foreign key (cod_prod_fk) references tb_produto (cod_prod)
); 

CREATE TABLE tb_devolucao_produtos (
	cod_dev_produtos int not null PRIMARY KEY auto_increment,
    quant_dev_produtos int,
    cod_prod_fk int,
    cod_dev_fk int,
	foreign key (cod_prod_fk) references tb_produto (cod_prod),
    foreign key (cod_dev_fk) references tb_devolver_produto (cod_dev_pro)
); 
