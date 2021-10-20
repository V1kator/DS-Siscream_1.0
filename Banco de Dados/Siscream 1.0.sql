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
    uf_end varchar(2) not null,
    cep_end varchar (10) not null
);

CREATE TABLE tb_caixa (
    cod_caixa int primary key not null auto_increment,
    funcionario_caixa varchar (100),
    senha_caixa varchar(20),
    data_caixa date,
	periodo_caixa varchar (100),
	valorAbertura_caixa double,
    caixa_aberto datetime,
    caixa_fechado datetime,
    suprimento double,
    dinheiro_caixa double,
	credito_caixa double,
	debito_caixa double,
    total_caixa double,
    valor_retirado_caixa double,
    especificacoes varchar(500),
    saldofinal_caixa double
);

CREATE TABLE tb_funcionario (
    cod_func int not null PRIMARY KEY auto_increment,
    nome_func varchar (100) not null,
    cpf_func varchar (11) not null,
    sexo_func varchar (20) not null, 
    nascimento_func varchar (11),
    telefone_func varchar (20), 
    email_func varchar (50),
    rg_func varchar (15) not null,
    cargo_func varchar (20) not null,
    tipoContrato_func varchar (20) not null,
    senha_func varchar (20) not null,
    dataAdmissao_func date not null,
    cod_end_fk int not null,
	foreign key (cod_end_fk) references tb_endereco (cod_end)
);

CREATE TABLE tb_cliente (
    cod_cli int not null PRIMARY KEY auto_increment,
    nome_cli varchar (100) not null,
    cpf_cli varchar (11) not null,
    cnpj_cli varchar (20),
    tipo_pessoa_cli varchar (100) not null,
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
    nome_log varchar(100),
    data_log date,
	foreign key (cod_func_fk) references tb_funcionario (cod_func) 
);

CREATE TABLE tb_Venda_Produto (
	cod_vendaProd int not null PRIMARY KEY auto_increment,
	quantidade_prodVenda int,
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



############################ GATILHOS E PROCEDIMENTOS ###########################

############################## GATILHO CAIXA ###############################
DELIMITER $$
CREATE TRIGGER GastoAtualizarCaixa AFTER INSERT ON tb_gasto
FOR EACH ROW
BEGIN
	DECLARE valorabertura DOUBLE;
    DECLARE valorfinal DOUBLE;
    DECLARE valorcredito DOUBLE;
    DECLARE valordebito DOUBLE;
    
    SET valorabertura = (SELECT valorAbertura_caixa FROM tb_caixa WHERE cod_caixa = new.cod_caixa_fk);
    SET valorcredito = (SELECT credito_caixa FROM tb_caixa WHERE cod_caixa = new.cod_caixa_fk);
    SET valordebito = (SELECT debito_caixa FROM tb_caixa WHERE cod_caixa = new.cod_caixa_fk);
    
     IF (valorabertura is null) then
		SET valorabertura = 0;
	END IF;
    
    IF (valorcredito is null) then
		SET valorcredito = 0;
	END IF;
    
     IF (valordebito is null) then
		SET valordebito= 0;
	END IF;
    
    SET valorfinal = (valorabertura + valorcredito) - valordebito;

	UPDATE tb_caixa SET saldofinal_caixa =  valorfinal WHERE cod_caixa = new.cod_caixa_fk;
    UPDATE tb_caixa SET valorAbertura_caixa =  valorfinal WHERE cod_caixa = (new.cod_caixa_fk + 1);
    
    SET valorabertura = valorfinal;
    SET valorcredito = (SELECT credito_caixa FROM tb_caixa WHERE (cod_caixa = new.cod_caixa_fk + 1));
    SET valordebito = (SELECT debito_caixa FROM tb_caixa WHERE (cod_caixa = new.cod_caixa_fk + 1));
    
    IF (valorcredito is null) then
		SET valorcredito = 0;
	END IF;
    
     IF (valordebito is null) then
		SET valordebito= 0;
	END IF;
    
     SET valorfinal = (valorabertura + valorcredito) - valordebito;
    
    UPDATE tb_caixa SET saldofinal_caixa =  valorfinal WHERE (cod_caixa = new.cod_caixa_fk + 1);

END $$ DELIMITER ;

DELIMITER $$
CREATE TRIGGER VendaAtualizarCaixa AFTER INSERT ON tb_venda
FOR EACH ROW
BEGIN
	DECLARE valorabertura DOUBLE;
    DECLARE valorfinal DOUBLE;
    DECLARE valorcredito DOUBLE;
    DECLARE valordebito DOUBLE;
    
    SET valorabertura = (SELECT valorAbertura_caixa FROM tb_caixa WHERE cod_caixa = new.cod_caixa_fk);
    SET valorcredito = (SELECT credito_caixa FROM tb_caixa WHERE cod_caixa = new.cod_caixa_fk);
    SET valordebito = (SELECT debito_caixa FROM tb_caixa WHERE cod_caixa = new.cod_caixa_fk);
    
     IF (valorabertura is null) then
		SET valorabertura = 0;
	END IF;
    
    IF (valorcredito is null) then
		SET valorcredito = 0;
	END IF;
    
     IF (valordebito is null) then
		SET valordebito= 0;
	END IF;
    
    SET valorfinal = (valorabertura + valorcredito) - valordebito;

	UPDATE tb_caixa SET saldofinal_caixa =  valorfinal WHERE cod_caixa = new.cod_caixa_fk;
    UPDATE tb_caixa SET valorAbertura_caixa =  valorfinal WHERE cod_caixa = (new.cod_caixa_fk + 1);
    
    SET valorabertura = valorfinal;
    SET valorcredito = (SELECT credito_caixa FROM tb_caixa WHERE (cod_caixa = new.cod_caixa_fk + 1));
    SET valordebito = (SELECT debito_caixa FROM tb_caixa WHERE (cod_caixa = new.cod_caixa_fk + 1));
    
    IF (valorcredito is null) then
		SET valorcredito = 0;
	END IF;
    
     IF (valordebito is null) then
		SET valordebito= 0;
	END IF;
    
     SET valorfinal = (valorabertura + valorcredito) - valordebito;
    
    UPDATE tb_caixa SET saldofinal_caixa =  valorfinal WHERE (cod_caixa = new.cod_caixa_fk + 1);

END $$ DELIMITER ;

DELIMITER $$
CREATE TRIGGER DevolverProdutoAtualizarCaixa AFTER INSERT ON tb_devolver_produto
FOR EACH ROW
BEGIN
	DECLARE valorabertura DOUBLE;
    DECLARE valorfinal DOUBLE;
    DECLARE valorcredito DOUBLE;
    DECLARE valordebito DOUBLE;
    DECLARE verificar_caixa INT;
    
    SET verificar_caixa = (SELECT cod_caixa FROM tb_caixa WHERE cod_caixa = (SELECT MAX(cod_caixa) FROM tb_caixa));
    SET valorabertura = (SELECT valorAbertura_caixa FROM tb_caixa WHERE cod_caixa = verificar_caixa);
    SET valorcredito = (SELECT credito_caixa FROM tb_caixa WHERE cod_caixa = verificar_caixa);
    SET valordebito = (SELECT debito_caixa FROM tb_caixa WHERE cod_caixa = verificar_caixa);
    
     IF (valorabertura is null) then
		SET valorabertura = 0;
	END IF;
    
    IF (valorcredito is null) then
		SET valorcredito = 0;
	END IF;
    
     IF (valordebito is null) then
		SET valordebito= 0;
	END IF;
    
    SET valorfinal = (valorabertura + valorcredito) - valordebito;

	UPDATE tb_caixa SET saldofinal_caixa =  valorfinal WHERE cod_caixa = verificar_caixa;
    UPDATE tb_caixa SET valorAbertura_caixa =  valorfinal WHERE cod_caixa = (verificar_caixa + 1);
    
    SET valorabertura = valorfinal;
    SET valorcredito = (SELECT credito_caixa FROM tb_caixa WHERE (cod_caixa = verificar_caixa + 1));
    SET valordebito = (SELECT debito_caixa FROM tb_caixa WHERE (cod_caixa = verificar_caixa + 1));
    
    IF (valorcredito is null) then
		SET valorcredito = 0;
	END IF;
    
     IF (valordebito is null) then
		SET valordebito= 0;
	END IF;
    
     SET valorfinal = (valorabertura + valorcredito) - valordebito;
    
    UPDATE tb_caixa SET saldofinal_caixa =  valorfinal WHERE (cod_caixa = verificar_caixa + 1);

END $$ DELIMITER ;

###################### CADASTRAR PRODUTO ###############################
DELIMITER $$
CREATE PROCEDURE pr_CadastrarProduto (nome varchar(100), unidade varchar (5),
validade date, tipo varchar (20), estoque int, fabricante varchar (20), marca varchar (20), 
codbarras varchar (20), comissao int, preco float, custo float, descricao varchar (200))
BEGIN
	DECLARE testeexistencia VARCHAR(100);
    DECLARE testeexistencia2 VARCHAR(100);
    
    SET testeexistencia = (SELECT nome_prod FROM tb_produto WHERE nome_prod = nome);
    SET testeexistencia2 = (SELECT codbarras_prod FROM tb_produto WHERE codbarras_prod = codbarras);
    
    IF (testeexistencia IS NULL) THEN
		IF (testeexistencia2 IS NULL) THEN
			INSERT INTO tb_produto (cod_prod, nome_prod, unidademed_prod, datavalidade_prod, tipo_prod, estoque_prod, 
			fabricante_prod, marca_prod, codbarras_prod, comissao_prod, preco_prod, custo_prod, descricao_prod)
			VALUES (null, nome, unidade, validade, tipo, estoque, fabricante, marca, codbarras, comissao, preco, custo, descricao);

			SELECT 'Produto cadastrado com sucesso' AS Confirmacao;
        ELSE
			SELECT 'O Produto inserido deve conter um código de barras único' AS ERRO;
        END IF;
    ELSE
		SELECT 'O Produto inserido tem o nome repetido' AS ERRO;
    END IF;
    
END $$ DELIMITER ;

CALL pr_CadastrarProduto ('Picole de Abacate', 'gr', '2022-08-25',
'Picole',750, 'Jibom Sorvetes', 'Jibom', 0258812213, 25, 1.5, 50, 'Ingredientes:
açucar, leite em pó, leite, água, sabor artificial, gordura vegetal,
amido de milho. Contem gluten. Contem sacarose');

CALL pr_CadastrarProduto ('Picole de Leitininho', 'gr', '2022-08-25',
'Picole',750, 'Jibom Sorvetes', 'Jibom', 0258812214, 25, 1.5, 50, 'Ingredientes:
açucar, leite em pó, leite, água, sabor artificial, gordura vegetal,
amido de milho. Contem gluten. Contem sacarose');

CALL pr_CadastrarProduto ('Picole de Nata', 'gr', '2022-08-25',
'Picole',750, 'Jibom Sorvetes', 'Jibom', 0258812215, 25, 1.5, 50, 'Ingredientes:
açucar, leite em pó, leite, água, sabor artificial, gordura vegetal,
amido de milho. Contem gluten. Contem sacarose');

CALL pr_CadastrarProduto ('Picole de Morango', 'gr', '2022-08-25',
'Picole', 550,'Jibom Sorvetes', 'Jibom', 02514126, 25, 1, 35, 'Ingredientes:
açucar, leite em pó, água, sabor artificial,
amido de milho. Contem gluten. Contem sacarose');

CALL pr_CadastrarProduto ('Picole de Abacaxi', 'gr', '2022-08-25',
'Picole', 550,'Jibom Sorvetes', 'Jibom', 02514127, 25, 1, 35, 'Ingredientes:
açucar, leite em pó, água, sabor artificial,
amido de milho. Contem gluten. Contem sacarose');

CALL pr_CadastrarProduto ('Picole de Limão', 'gr', '2022-08-25',
'Picole', 550,'Jibom Sorvetes', 'Jibom', 02514128, 25, 1, 35, 'Ingredientes:
açucar, leite em pó, água, sabor artificial,
amido de milho. Contem gluten. Contem sacarose');

CALL pr_CadastrarProduto ('Caixa de sorvetes 10l', 'lt', '2022-08-25',
'Sorvete', 100,'Tropical sorvetes', 'Tropical', 8521412549, 15, 75, 20, 
'Ingredientes: açucar, leite em pó, água, sabor artificial,amido de milho.
 Contem gluten. Contem sacarose');

CALL pr_CadastrarProduto ('Caixa de sorvetes 5l', 'lt', '2022-08-25',
'Sorvete', 20,'Tropical sorvetes', 'Tropical', 536410, 15, 55, 20, 'Ingredientes:
açucar, leite em pó, água, sabor artificial,
amido de milho. Contem gluten. Contem sacarose');

CALL pr_CadastrarProduto ('Pote de açai 2L', 'lt', '2022-08-25',
'Açai', 50,'Skimo Ltda', 'skimo', 1243264210, 25, 25, 26, 'Ingredientes:
açucar, leite em pó, , polpa de açai, xarope de guarana, água,
amido de milho. Contem gluten. Contem sacarose');
select*from tb_produto;
select*from tb_caixa;
############################## CADASTRAR ENDERECO ###############################

DELIMITER $$
CREATE PROCEDURE pr_CadastrarEndereco (logradouro varchar(100), numero varchar (11), bairro varchar (100), 
cidade varchar (100), uf varchar (100), cep varchar(15))
BEGIN
	DECLARE testeexistencia VARCHAR(100);
    DECLARE testeexistencia2 VARCHAR(100);
    
    SET testeexistencia = (SELECT cep_end FROM tb_endereco WHERE cep_end = cep);
    SET testeexistencia2 = (SELECT numero_end FROM tb_endereco WHERE numero_end = numero);
    
    IF (testeexistencia IS NULL) THEN
		IF (testeexistencia2 IS NULL) THEN
			INSERT INTO tb_endereco (cod_end, logradouro_end, numero_end, bairro_end, cidade_end, uf_end, cep_end)
			VALUES (null, logradouro, numero, bairro, cidade, uf, cep);

			SELECT 'Endereço cadastrado com sucesso' AS Confirmacao;
        ELSE
			SELECT 'O Número inserido já existe, informe outro' AS ERRO;
        END IF;
    ELSE
		SELECT 'O CEP inserido já existe, informe outro' AS ERRO;
    END IF;

END $$ DELIMITER ;

CALL pr_CadastrarEndereco ('Rua do Céu', 526, 'Migrantes', 'Ouro-Preto', 'RO', 769000023);
CALL pr_CadastrarEndereco ('AV. 5 de Maio', 1469, 'Centro', 'Ji-Paraná','RO','76900709');
CALL pr_CadastrarEndereco ('AV. Dom Augusto', 715, 'Centro', 'Ji-Paraná','RO','76900007');
CALL pr_CadastrarEndereco ('AV. 7 de setembro', 749, 'Centro', 'Presidente Médici','RO','76900801');


############################## CADASTRAR FUNCIONARIO ###############################

DELIMITER $$
CREATE PROCEDURE pr_CadastrarFuncionario(nome varchar(100), cpf varchar (15), cargo varchar (100), 
tipoContrato varchar (100), senha varchar (8), dataAdmissao date, cod_endereco int)
BEGIN
	DECLARE testeexistencia VARCHAR(100);
    DECLARE testeexistencia2 VARCHAR(100);
    
    SET testeexistencia = (SELECT cpf_func FROM tb_funcionario WHERE cpf_func = cpf);
    SET testeexistencia2 = (SELECT cod_end FROM tb_endereco WHERE cod_end = cod_endereco);
    
    IF (testeexistencia IS NULL) THEN
		IF (testeexistencia2 = cod_endereco) THEN
			INSERT INTO tb_funcionario (cod_func,nome_func, cpf_func, cargo_func, tipoContrato_func, senha_func, dataAdmissao_func, cod_end_fk)
			VALUES (null, nome, cpf, cargo, tipoContrato, senha, dataAdmissao, cod_endereco);

			SELECT 'Funcionario cadastrado com sucesso, seja bem vindo' AS Confirmacao;
        ELSE
			SELECT 'O Endereço inserido já existe, informe outro' AS ERRO;
        END IF;
    ELSE
		SELECT 'O CPF inserido já existe, informe outro' AS ERRO;
    END IF;

END $$ DELIMITER ;

CALL pr_CadastrarFuncionario ('Jubileu dos Santos', 285788814, 'Auxiliar de Produção', 'Carteira assinada', '12345678', '2019-05-25', 1);
CALL pr_CadastrarFuncionario ('Juninho', 370360394, 'Operador de Caixa', 'Carteira assinada', '87654321', '2019-05-25', 3);

select cod_func codigo, nome_func nome, cpf_func cpf, cargo_func cargo, tipoContrato_func tipo_contrato, 
dataAdmissao_func Egresso, cod_end_fk cod_endereco from tb_funcionario;

############################## CADASTRAR CLIENTE ###############################

DELIMITER $$
CREATE PROCEDURE pr_CadastrarCliente (nome varchar(100), cpf varchar (11), cnpj varchar (20), 
tipo_pessoa varchar (100), cod_endereco int)
BEGIN
	DECLARE testeexistencia VARCHAR(100);
    DECLARE testeexistencia2 VARCHAR(100);
    
    SET testeexistencia = (SELECT cpf_cli FROM tb_cliente WHERE cpf_cli = cpf);
    SET testeexistencia2 = (SELECT cod_end FROM tb_endereco WHERE cod_end = cod_endereco);
    
    IF (testeexistencia IS NULL) THEN
		IF (testeexistencia2 = cod_endereco) THEN
			INSERT INTO tb_cliente (cod_cli ,nome_cli, cpf_cli, cnpj_cli, tipo_pessoa_cli, cod_end_fk)
			VALUES (null, nome, cpf, cnpj, tipo_pessoa, cod_endereco);

			SELECT 'Cliente cadastrado com sucesso.' AS Confirmacao;

        ELSE
			SELECT 'O Endereço inserido já existe, informe outro' AS ERRO;
        END IF;
    ELSE
		SELECT 'O CPF inserido já existe, informe outro' AS ERRO;
    END IF;
    

END $$ DELIMITER ;

CALL pr_CadastrarCliente ('Amarildo', 81084311070, 20819611000173, 'Juridica', 2);


###################### FAZER LOGIN ###############################

DELIMITER $$
CREATE PROCEDURE pr_Login (CPF VARCHAR(11), senha VARCHAR (20))
BEGIN
	DECLARE testecpf VARCHAR(11);
    DECLARE testesenha VARCHAR(20);
    DECLARE testefuncionario VARCHAR(20);
    DECLARE nome VARCHAR(100);
    DECLARE funcionario INT;
    
    
    SET testecpf = (SELECT cpf_func FROM tb_funcionario WHERE CPF = cpf_func);
    SET funcionario = (SELECT cod_func FROM tb_funcionario WHERE CPF = cpf_func);
    SET nome = (SELECT nome_func FROM tb_funcionario WHERE CPF = cpf_func);
    SET testesenha = (SELECT senha_func FROM tb_funcionario WHERE senha = senha_func limit 1);
    
    IF(testecpf = CPF) THEN
		IF(testesenha = senha) THEN
			INSERT INTO tb_login VALUES (null, funcionario, nome, now());
			SELECT 'Bem Vindo!!!' AS Confirmacao;
        ELSE
			SELECT 'Senha Incorreta' AS Erro_Senha;
        END IF;
	ELSE
		SELECT 'CPF Incorreto' AS Erro_CPF;
    END IF;
END $$ DELIMITER ;

CALL pr_Login('370360394', '87654321');

############################## ABRIR CAIXA ###############################
DELIMITER $$
CREATE PROCEDURE pr_AbrirCaixa (nome VARCHAR(100), periodo VARCHAR(100), senha VARCHAR(20))
BEGIN
	DECLARE valorabertura DOUBLE;
    DECLARE testesenha VARCHAR(20);
    DECLARE testefuncionario VARCHAR(20);
    
    SET testefuncionario = (SELECT nome_func FROM tb_funcionario WHERE nome_func = nome);
    SET valorabertura = (SELECT saldofinal_caixa FROM tb_caixa WHERE cod_caixa = (SELECT MAX(cod_caixa) FROM tb_caixa));
    SET testesenha = (SELECT senha_func FROM tb_funcionario WHERE senha = senha_func limit 1);
    
    IF(valorabertura is null) THEN
		SET valorabertura = 0;
    END IF;
    
    IF(testefuncionario = nome) THEN
		IF(testesenha = senha) THEN
			INSERT INTO tb_caixa(cod_caixa, funcionario_caixa, data_caixa, periodo_caixa, senha_caixa, valorAbertura_caixa)
			VALUES (null, nome, now(), periodo, senha, valorabertura);
			SELECT 'Caixa aberto com sucesso' AS Confirmacao;
		ELSE
			SELECT 'A senha está incorreta' AS Confirmacao;
        END IF;
    ELSE
		SELECT 'Funcionário não existe' AS Confirmacao;
    END IF;
	
END $$ DELIMITER ;

CALL pr_AbrirCaixa ('Juninho', 'Matutino', '87654321');
CALL pr_AbrirCaixa ('Jubileu dos Santos', 'Matutino', '12345678');

SELECT cod_caixa, funcionario_caixa, senha_caixa, data_caixa, periodo_caixa, valorAbertura_caixa, saldofinal_caixa 
FROM tb_caixa;
###################### FECHAR CAIXA ###############################

DELIMITER $$
CREATE PROCEDURE pr_FecharCaixa (cod_caixaaberto int, saida DOUBLE)
BEGIN
    DECLARE valorabertura DOUBLE;
    DECLARE valorfinal DOUBLE;
    DECLARE valorcredito DOUBLE;
    DECLARE valordebito DOUBLE;
    
    SET valorabertura = (SELECT valorAbertura_caixa FROM tb_caixa WHERE cod_caixa = cod_caixaaberto);
    SET valorcredito = (SELECT credito_caixa FROM tb_caixa WHERE cod_caixa = cod_caixaaberto);
    SET valordebito = (SELECT debito_caixa FROM tb_caixa WHERE cod_caixa = cod_caixaaberto);
    
    IF (valorcredito is null) then
		SET valorcredito = 0;
	END IF;
    
     IF (valordebito is null) then
		SET valordebito= 0;
	END IF;
    
    SET valordebito = saida + valordebito;
    
    SET valorfinal = (valorabertura + valorcredito) - valordebito;
    
	UPDATE tb_caixa SET debito_caixa = valordebito WHERE cod_caixa = cod_caixaaberto;
	UPDATE tb_caixa SET saldofinal_caixa = valorfinal WHERE cod_caixa = cod_caixaaberto;
    UPDATE tb_caixa SET credito_caixa = valorcredito WHERE cod_caixa = cod_caixaaberto;
    
    SELECT 'Caixa fechado com sucesso' AS Confirmacao;

END $$ DELIMITER ;

CALL pr_FecharCaixa (1, 10);
SELECT * FROM tb_caixa;
###################### LANÇAR GASTOS ###############################

DELIMITER $$
CREATE PROCEDURE pr_Lançar_Gastos (valor DOUBLE, descricao VARCHAR (100), caixa INT)
BEGIN
	DECLARE testecaixa INT;
    DECLARE valordebito DOUBLE;
    
    SET valordebito = (SELECT debito_caixa FROM tb_caixa WHERE cod_caixa = caixa);
	SET testecaixa = (SELECT cod_caixa FROM tb_caixa WHERE cod_caixa = caixa);
    
     IF (valordebito is null) then
		SET valordebito= 0;
	END IF;
    
    SET valordebito = valor + valordebito;
   
	IF(testecaixa = caixa) THEN
        
        UPDATE tb_caixa SET debito_caixa = valordebito WHERE cod_caixa = caixa;
        
		INSERT INTO tb_gasto VALUES (null, descricao, valor, now(), caixa);
        
        SELECT 'Gasto Adicionado' AS Confirmacao;
    ELSE
		SELECT 'Informe um Caixa Aberto' AS Confirmacao;
    END IF;
	
END $$ DELIMITER ;

CALL pr_Lançar_Gastos (10, 'Compra de remaça de Sorvete KiBom', 1);
CALL pr_Lançar_Gastos (5, 'Devolução de produto', 2);
CALL pr_Lançar_Gastos (5, 'Devolução de produto', 1);

SELECT * FROM tb_caixa;
SELECT * FROM tb_gasto;
############################## VENDA DE PRODUTO ###############################

DELIMITER $$
CREATE PROCEDURE pr_VenderProduto (CodProds INT, quantidade INT, formapagamento VARCHAR (100), vendedor VARCHAR(100))
BEGIN

	DECLARE PrecoVenda FLOAT;
	DECLARE pegarpreco FLOAT;
	DECLARE verificar_estoque INT;
    DECLARE verificar_caixa INT;
	DECLARE verificar_vendedor VARCHAR(100);
	DECLARE pegarCredito DOUBLE;
	DECLARE pegarDebito DOUBLE;
	DECLARE saldo1 DOUBLE;

	SET verificar_vendedor= (SELECT nome_func FROM tb_funcionario WHERE nome_func = vendedor);
    SET verificar_caixa = (SELECT cod_caixa FROM tb_caixa WHERE funcionario_caixa = vendedor);
	SET verificar_estoque= (SELECT estoque_prod FROM tb_produto WHERE cod_prod = CodProds);
	SET pegarpreco = (SELECT preco_prod FROM tb_produto WHERE cod_prod= CodProds);
	SET PrecoVenda = pegarpreco * quantidade;
	SET pegarDebito = (SELECT debito_caixa FROM tb_caixa WHERE funcionario_caixa = vendedor);
	SET pegarCredito = (SELECT credito_caixa FROM tb_caixa WHERE funcionario_caixa = vendedor);
	SET saldo1 = PrecoVenda - pegarDebito;

	IF(pegarCredito IS NULL) THEN
		SET pegarCredito = 0;
	END IF;
    
    IF NOT EXISTS (SELECT cod_caixa FROM tb_caixa WHERE funcionario_caixa = vendedor) THEN
		
		INSERT INTO tb_caixa (cod_caixa, funcionario_caixa, credito_caixa, debito_caixa, saldofinal_caixa) 
		VALUES (null, vendedor, PrecoVenda, pegardebito, saldo1);
            
	ELSE 
    
		UPDATE tb_caixa SET credito_caixa = pegarCredito + precoVenda WHERE funcionario_caixa = vendedor;
        
	END IF;

	IF (quantidade <= verificar_estoque) THEN
		IF (vendedor = verificar_vendedor) THEN
		
			INSERT INTO tb_venda (cod_venda, valor_venda, data_venda, formaPagamento_venda, cod_caixa_fk) 
			VALUES (null, precoVenda, now(), formapagamento, verificar_caixa);
			
			INSERT INTO tb_venda_produto (cod_vendaProd, quantidade_prodVenda, cod_prod_fk) 
			VALUES (null, quantidade, codProds);
			
			UPDATE tb_produto SET estoque_prod = estoque_prod - quantidade WHERE CodProds= cod_prod;
			
			SELECT 'Venda realizada com sucesso!' AS confirmação;
		ELSE
			SELECT 'Vendedor informado não está cadastrado na empresa ' AS Erro;
		END IF;
	ELSE
		SELECT 'A quantidade deve ser menor ou igual ao estoque do produto!' AS Erro;
	END IF;

END $$ DELIMITER ;

CALL pr_VenderProduto (8,5, 'Cartão de Crédito', 'Jubileu dos Santos');
CALL pr_VenderProduto (2,20, 'Dinheiro', 'Juninho');

select cod_venda codigo, valor_venda valor, formaPagamento_venda Forma_Pagamento, data_venda from tb_venda;
select cod_caixa codigo, funcionario_caixa funcionario, credito_caixa entradas from tb_caixa;
select cod_prod codigo, nome_prod Nome, tipo_prod tipo, estoque_prod estoque, codbarras_prod Codigo_barras, preco_prod preço from tb_produto;
select cod_vendaprod codigo, quantidade_prodvenda quantidade, cod_prod_fk codigo_produto from tb_venda_produto;



############################## CONSULTAR ESTOQUE ###############################

DELIMITER $$
CREATE PROCEDURE pr_consulta_estoque_por_nome (nome_produto varchar(100))
BEGIN 
	DECLARE testeexistencia VARCHAR(100);
    
    SET testeexistencia = (SELECT nome_prod FROM tb_produto WHERE nome_prod = nome_produto);
    
    IF (testeexistencia = nome_produto) THEN
		SELECT cod_prod, nome_prod,preco_prod,marca_prod, estoque_prod FROM tb_produto WHERE nome_prod = nome_produto;
    ELSE
		SELECT 'O Produto inserido não existe' AS Alerta;
    END IF;

END $$ DELIMITER ;

call pr_consulta_estoque_por_nome ("Picole de limão");
call pr_consulta_estoque_por_nome ("Picole de abacaxi");


DELIMITER $$
CREATE PROCEDURE pr_consulta_estoque_por_cod (cod_produto INT)
BEGIN 
	DECLARE testeexistencia INT;
    
    SET testeexistencia = (SELECT cod_prod FROM tb_produto WHERE cod_prod = cod_produto);
    
    IF (testeexistencia = cod_produto) THEN
		SELECT nome_prod,estoque_prod FROM tb_produto WHERE cod_prod = cod_produto;
    ELSE
		SELECT 'O Produto inserido não existe' AS Alerta;
    END IF;
    
END $$ DELIMITER ;

call pr_consulta_estoque_por_cod (1);

############################## CONSULTAR CLIENTE ###############################

DELIMITER $$
CREATE PROCEDURE pr_consulta_cliente_por_cnpj (cnpj VARCHAR(100))
BEGIN 
	DECLARE testeexistencia VARCHAR(100);
    
    SET testeexistencia = (SELECT cnpj_cli FROM tb_cliente WHERE cnpj_cli = cnpj);
    
    IF (testeexistencia = cnpj) THEN
		SELECT cod_cli, nome_cli, cnpj_cli, tipo_pessoa_cli FROM tb_cliente WHERE cnpj_cli = cnpj;
    ELSE
		SELECT 'O CNPJ inserido não existe' AS Alerta;
    END IF;

END $$ DELIMITER ;

call pr_consulta_cliente_por_cnpj (20819611000173);

DELIMITER $$
CREATE PROCEDURE pr_consulta_cliente_por_nome (nome VARCHAR(100))
BEGIN 
DECLARE testeexistencia VARCHAR(100);
    
    SET testeexistencia = (SELECT nome_cli FROM tb_cliente WHERE nome_cli = nome);
    
    IF (testeexistencia = nome) THEN
		SELECT cod_cli, nome_cli, cnpj_cli, tipo_pessoa_cli FROM tb_cliente WHERE nome_cli = nome;
    ELSE
		SELECT 'O nome inserido não existe' AS Alerta;
    END IF;

END $$ DELIMITER ;

call pr_consulta_cliente_por_nome ("amarildo");

############################## REPOR ESTOQUE ###############################
DELIMITER $$
CREATE PROCEDURE pr_repor_estoque (cod_produto INT, quantidade_produto INT)
BEGIN
	DECLARE testarseprodutoexiste VARCHAR(100);

	SET testarseprodutoexiste = (SELECT cod_produto FROM tb_produto WHERE cod_prod = cod_produto);

	IF (testarseprodutoexiste IS NULL) THEN

		SELECT 'Eu não consegui achar esse produto ai, dá uma conferida e tenta de novo ;)' AS Alerta;
		
	ELSE

	UPDATE tb_produto SET estoque_prod = estoque_prod + quantidade_produto WHERE cod_prod = cod_produto;

	END IF;

END $$ DELIMITER ;

call pr_repor_estoque (1, 25);


############################## DEVOLVER PRODUTO ###############################

DELIMITER $$ 
CREATE PROCEDURE pr_devolver_produto (codigo_produto INT, data_devolução DATE, quantidade_devolvida INT, valor_por_produto FLOAT, codigo_dev INT)
BEGIN 
	DECLARE valortotaldadevolucao FLOAT;
    DECLARE verificar_caixa INT;
    DECLARE testeexistencia VARCHAR(100);
    DECLARE testeexistencia2 VARCHAR(100);
    
    SET testeexistencia = (SELECT cod_prod FROM tb_produto WHERE cod_prod = codigo_produto);
    SET testeexistencia2 = (SELECT cod_dev_pro FROM tb_devolver_produto WHERE cod_dev_pro = codigo_dev);
    SET valortotaldadevolucao = quantidade_devolvida * valor_por_produto;
    SET verificar_caixa = (SELECT cod_caixa FROM tb_caixa WHERE cod_caixa = (SELECT MAX(cod_caixa) FROM tb_caixa));
    
    IF (testeexistencia2 IS NULL) THEN
		SET	testeexistencia2 = 1;
    END IF;
    
    IF (testeexistencia = codigo_produto) THEN
		IF (testeexistencia2 = codigo_dev) THEN
			UPDATE tb_produto SET estoque_prod = estoque_prod + quantidade_devolvida WHERE cod_prod = codigo_produto;
			UPDATE tb_caixa SET debito_caixa = debito_caixa + valortotaldadevolucao WHERE cod_caixa = verificar_caixa;
			
			INSERT INTO tb_devolver_produto (cod_prod_fk, data_dev_pro, valor_dev_pro, valor_total_dev_prod) 
			VALUES (codigo_produto, data_devolução, valor_por_produto,valortotaldadevolucao);
			
			INSERT INTO tb_devolucao_produtos VALUES (null, quantidade_devolvida, codigo_produto, codigo_dev);
			
			SELECT 'Seus dados foram atualizados com sucesso ;)' AS Mensagem;
        ELSE
			SELECT 'A Devolução inserida não existe, informe outro' AS ERRO;
        END IF;
    ELSE
		SELECT 'O Produto inserido não existe, informe outro' AS ERRO;
    END IF;
END $$ DELIMITER ;

CALL pr_devolver_produto(2, '2021-08-28', 2, 1.5, 2);
SELECT * FROM tb_caixa;
SELECT * FROM tb_devolver_produto;
SELECT * FROM tb_devolucao_produtos;