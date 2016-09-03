create database logistica 
GO

use logistica
GO 

create table produto(
    id int not null identity primary key,
    gtin char(14) not null,
    nome varchar(100) not null
)
GO

create table sscc(
    id int not null identity primary key,
    digitoExtencao char(1) not null,
    licencaGS1 char(9) not null,
    serial char(7) not null,
    digitoVerificador char(1) not null,
    dataExpedicao date not null
)
GO

create table caixa(
    id int not null identity primary key,
    produto_id int not null foreign key references produto(id),
    fabricacao date not null,
    validade date not null,
    lote varchar(20) not null,
    registroProcessador char(8) not null,
    sscc_id int not null foreign key references sscc(id),
    taraEmbalagem decimal(6,3) not null,
    taraCaixa decimal(6,3) not null
)
GO

create table palete(
    id int not null identity primary key,
    produto_id int not null foreign key references produto(id),
    quantidade int not null,
    fabricacao date not null,
    validade date not null,
    lote varchar(20) not null,
    registroProcessador char(8) not null,
    sscc_id int not null foreign key references sscc(id),
    taraEmbalagem decimal(6,3) not null,
    taraPalete decimal(6,3) not null,
    taraRack decimal(6,3) not null,
    taraStrech decimal(6,3) not null,
    taraCantoneira decimal(6,3) not null
)
GO