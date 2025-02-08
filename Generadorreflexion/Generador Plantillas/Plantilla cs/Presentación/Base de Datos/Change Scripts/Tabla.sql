
exec sp_addtype codigo,'bigint','not null'

Create table Especie(
idEspecie codigo primary key,
nombre_Especie varchar(70)not null,
nombre_Comun varchar(70)not null,
)
go
Create table Tipo_Suelo(
idTipo_Suelo codigo primary key,
nombre_TipoSuelo Varchar (70)not null,
)
go

Create table Dpto(
idDpto codigo primary key,
nombre_Dpto varchar(70) not null,
)
go

Create table Provincia(
idProvincia codigo primary key,
nombre_Provincia varchar(70) not null,
idDpto codigo references Dpto(idDpto),
)
go

Create table Municipio(
idMunicipio codigo primary key,
nombre_Municipio varchar(70)not null,
idProvincia codigo references Provincia(idProvincia),
)
go 

Create table Bosque(
idBosque codigo primary key,
hectaria float not null,
idTipo_Suelo codigo references Tipo_Suelo(idTipo_Suelo),
idMunicipio codigo references Municipio(idMunicipio),

)
go

Create table Arbol(
idArbol codigo primary key,
nombre_Arbol varchar(70) not null,
edad float,
ancho float,
idEspecie codigo references Especie(idEspecie),
idBosque codigo references Bosque(idBosque),
)
go

Create table Tallo(
idArbol codigo primary key references Arbol(idArbol),
longitud float,
diametro float,
)
go

Create table Hoja(
idArbol codigo primary key references Arbol(idArbol),
forma varchar(70) not null,
color varchar(70) not null,
)
go

Create table Raiz(
idArbol codigo primary key references Arbol(idArbol),
longitud float,
descripcion varchar(70)not null,
)
go


