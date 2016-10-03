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


--select palete.id,produto.nome
--from palete
--join caixasPalete on palete.id=caixasPalete.palete_id
--join caixa on caixa.id=caixasPalete.caixa_id
--join produto on produto.id=caixa.produto_id
--group by palete.id,produto.nome
--GO

--select c.id,c.sscc from caixa c join caixasPalete cp on cp.caixa_id=c.id where cp.palete_id=12
--GO

--select quantidade from palete
--go

--select p.cod1, p.cod2, p.cod3, p.sscc, p.palete, p.stretch, p.cantoneira, p.quantidade, pr.gtin, cx.fabricacao, cx.validade, cx.registroProcessador, cx.lote, pr.nome, pr.embalagem, pr.caixa
--from palete p
--join caixasPalete cp on p.id=cp.palete_id
--join caixa cx on cx.id=cp.caixa_id
--join produto pr on pr.id=cx.produto_id
--where p.carregamento_id=1
--group by p.id,p.cod1, p.cod2, p.cod3, p.sscc, p.palete, p.stretch, p.cantoneira, p.quantidade, pr.gtin, cx.fabricacao, cx.validade, cx.registroProcessador, cx.lote, pr.nome, pr.embalagem, pr.caixa
--go

--select cx.cod1,cx.cod2,cx.cod3,cx.sscc
--from caixa cx
--join caixasPalete cp on cp.caixa_id=cx.id
--join palete pl on pl.id=cp.palete_id
--GO

--select p.cod1, p.cod2, p.cod3, p.sscc, p.palete, p.stretch, p.cantoneira, p.quantidade, pr.gtin, cx.fabricacao, cx.validade, cx.registroProcessador, cx.lote, pr.nome, pr.embalagem, pr.caixa, p.id
--from palete p join caixasPalete cp on p.id = cp.palete_id
--join caixa cx on cx.id = cp.caixa_id
--join produto pr on pr.id = cx.produto_id
--where p.id = 4
--group by p.id, p.cod1, p.cod2, p.cod3, p.sscc, p.palete, p.stretch, p.cantoneira, p.quantidade, pr.gtin, cx.fabricacao, cx.validade, cx.registroProcessador, cx.lote, pr.nome, pr.embalagem, pr.caixa

select pl.id from palete pl join carregamento cr on cr.id=pl.carregamento_id where carregamento_id=1
go

delete cx from caixa cx join caixasPalete cp on cp.caixa_id=cx.id join palete pl on pl.id=cp.palete_id where pl.id=@palete_id