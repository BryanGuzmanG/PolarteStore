CREATE DATABASE PolarteDB;

USE PolarteDB;

CREATE  TABLE Users(
UserID int identity(1,1) primary key ,
UserName varchar(30) UNIQUE NOT NULL,
Password varchar(15) NOT NULL,
Nombre varchar(25) NOT NULL,
Apellidos varchar(45) NOT NULL,
Rol varchar(50) NOT NULL,
Email varchar(150) NOT NULL);



insert into Users values ('admin','admin','Darlin','Reyes','DBA','DarlinReyes@gmail.com')
select * from Users


CREATE TABLE Productos(
ProductoID int primary key identity,
CodigoProducto varchar(10) NOT NULL unique,
DescripcionProducto varchar(30)NOT NULL, 
Existencia int NOT NULL,
Precio money NOT NULL,
SuplidorID int,
CategoriaID int,
);

ALTER TABLE Productos ADD CONSTRAINT Fk_ProductSupli FOREIGN KEY (SuplidorID) REFERENCES Suplidores(SuplidorID)
ALTER TABLE Productos ADD CONSTRAINT Fk_ProductCategoria FOREIGN KEY (CategoriaID) REFERENCES Categorias (CategoriaID)

CREATE TABLE Categorias(
CategoriaID int primary key,
Nombre varchar(25) NOT NULL,
Descripcion varchar(50)
)

CREATE TABLE Suplidores(
SuplidorID int primary key,
CodigoSuplidor varchar(15) NOT NULL,
NombreSuplidor varchar(50) NOT NULL,
Telefono varchar(13),
Direccion varchar(max)
);

CREATE TABLE Ordenes(
OrdenID int primary key identity(1000,1),
UsuarioID int, 
FechaOrden datetime default getdate());

CREATE TABLE OrdenDetalle(
OrdenID int,
ProductoID int,
Precio money NOT NULL,
Cantidad int NOT NULL ,
SubTotal money NOT NULL,
ITBIS money  NOT NULL,
constraint PK_OrdenDetalle primary key (ordenID, ProductoID),
CONSTRAINT Fk_OrdenDetalle_Orden FOREIGN KEY (OrdenID) REFERENCES Ordenes(OrdenID),
CONSTRAINT Fk_OrdenDetalle_Producto FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
)
