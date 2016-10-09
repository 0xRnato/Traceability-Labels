create database RastreabilidadeLogistica
GO

use RastreabilidadeLogistica
GO 

create table users(
	id int not null identity primary key,
	usuario varchar(10) not null,
	senha int not null,
	adm bit not null
)
GO

insert into users(usuario,senha,adm) values('rnato',121473,'1')
GO
insert into users(usuario,senha,adm) values('gilberto',3434,'1')
GO

create table produto(
    id int not null identity primary key,
    gtin char(14) not null,
    nome varchar(100) not null,
    embalagem decimal(4,3) not null,
    caixa decimal(4,3) not null,
	validade int not null
)
GO

create table paletePadrao(
	id int not null identity primary key,
	stretch decimal(4,3) not null,
	cantoneira decimal(4,3) not null
)

insert into paletePadrao(stretch,cantoneira) values('1.000','1.000')
GO

create table carregamento(
	id int not null identity primary key,
	codigo varchar(10) not null,
	expedicao date not null,
	userGerado varchar(10) not null,
	userImpresso varchar(10) null,
	userConferido varchar(10) null,
	dataGerado date not null,
	dataImpresso date null,
	dataConferido date null,
    estagio int not null
)
GO

create table sscc(
    id int not null identity primary key,
    digitoExtencao char(1) not null,
    licencaGS1 char(9) not null,
    serial char(7) not null,
    digitoVerificador char(1) not null,
    tipo varchar(6) not null,
    dataEmissao date not null
)
GO

create table palete(
    id int not null identity primary key,
    carregamento_id int not null foreign key references carregamento(id),
    sscc varchar(40) not null,
    palete decimal(6,3) not null,
    stretch decimal(5,3) not null,
    cantoneira decimal(5,3) not null,
    cod1 varchar(40) not null,
    cod2 varchar(40) not null,
    cod3 varchar(40) not null,
	quantidade int not null,
	userGerado varchar(10) not null,
	userImpresso varchar(10) null,
	userConferido varchar(10) null,
	dataGerado date not null,
	dataImpresso date null,
	dataConferido date null,
    estagio int not null
)
GO

create table caixa(
    id int not null identity primary key,
    produto_id int not null foreign key references produto(id),
    fabricacao date not null,
    validade date not null,
    lote varchar(4) not null,
    registroProcessador varchar(8) not null,
    sscc varchar(40) not null,
    cod1 varchar(40) not null,
    cod2 varchar(40) not null,
    cod3 varchar(40) not null,
	userGerado varchar(10) not null,
	userImpresso varchar(10) null,
	userConferido varchar(10) null,
	dataGerado date not null,
	dataImpresso date null,
	dataConferido date null,
    estagio int not null
)
GO

create table caixasPalete(
	id int not null identity primary key,
	caixa_id int not null foreign key references caixa(id),
	palete_id int not null foreign key references palete(id)
)
GO

insert into produto(nome, gtin, embalagem, caixa, validade) values('CHOCOAVELA 8 UN','17897522411014',0.024,0.082,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('TORTA LIMAO 8 UN','17897522411021',0.024,0.082,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('PRESTIGIO 8 UN','17897522411038',0.024,0.082,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('MINI PUDIM 8UN','17897522411076',0.024,0.082,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('HOLANDESA 8 UN','17897522411052',0.024,0.082,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('STROGONOFF FRANGO','17897522410017',0.648,0.234,120)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('FILE A PARMEGIANA','17897522410031',0.648,0.234,120)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('FEIJOADA','17897522410048',0.648,0.234,120)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('BOLINHO MANDIOCA','17897522400018',0.048,0.226,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('COXINHA FRANG/REQ','17897522400032',0.032,0.226,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('COXINHA SIMPLES','17897522400049',0.048,0.226,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('EMPADA FRANGO','17897522402012',0.040,0.226,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('EMPADA FRANG/REQ','17897522402029',0.040,0.226,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('EMPADAO FRANGO','17897522402043',0.048,0.226,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('ENROLADO PRE/QUE','17897522401022',0.024,0.226,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('ESFIHA DE CARNE','17897522401039',0.024,0.226,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('ESFIHA DE FRANGO','17897522401046',0.024,0.226,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('FOLHADO FRANG/REQ','17897522403026',0.024,0.226,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('PAO DE BATATA REQ','17897522401091',0.024,0.226,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('PASTEL ASSADO FRA','17897522402067',0.040,0.226,90)
GO
insert into produto(nome, gtin, embalagem, caixa, validade) values('QUIBE SIMPLES','17897522400063',0.048,0.226,90)
GO