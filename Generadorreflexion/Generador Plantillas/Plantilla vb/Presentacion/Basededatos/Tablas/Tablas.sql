--EXEC sp_Addtype codigo,'bigint','not null'
go
drop table especie
create table especie(
	Idespecie identity primary key,
	nombre_especie varchar(70),
	Nombre_comun varchar(70)
)
go
create table dpto(
	Iddpto codigo primary key,
	nombre_dpto varchar(70),
)
go
create table provincia(
	Idprovincia codigo primary key,
	nombre_provincia varchar(70),
	Iddpto codigo references dpto(Iddpto),
)
go
create table localidad(
	Idlocalidad codigo primary key,
	nombre_localidad varchar(70),
	Idprovincia codigo references provincia(Idprovincia),
)
go
create table zona(
	Idzona codigo primary key,
	nombre_zona varchar(70),
	Idlocalidad codigo references localidad(Idlocalidad),
)
go
create table bosque(
	Idbosque codigo primary key,
	nombre_bosque varchar(70),
	Idzona codigo references zona(Idzona),
)
go
create table arbol(
	Idarbol codigo primary key,
	edad float not null,
	altura float,
	Idbosque codigo references bosque(Idbosque),
	Idespecie codigo references especie(Idespecie),
)
go

create table arbol1(
	Idarbol1 codigo primary key references arbol(idarbol),
	carasteristica float not null,
)

go
create table tallo(
	Idtallo codigo primary key,
	diametro float,
	longitud float,
	Idarbol codigo references arbol(Idarbol),
)
go
create table hoja(
	Idhoja codigo primary key,
	color varchar(70),
	forma varchar(70),
	Idarbol codigo references arbol(Idarbol),
)
go
create table raiz(
	Idraiz codigo primary key,
	longitud float,
	forma varchar(70),
	Idarbol codigo references arbol(Idarbol),
)
go
drop table pedido
create table pedido(
	idpedido codigo  primary key,
	fecha_pedido datetime
)
go
drop table Detalle_pedido
create table Detalle_pedido(
	cantidad float,
	precio float,
	idpedido codigo references pedido(idpedido),
	idarbol codigo references Arbol(idarbol)
)
	
