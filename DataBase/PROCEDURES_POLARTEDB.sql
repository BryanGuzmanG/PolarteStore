USE [PolarteDB]

/** PROCEDURE PDE VER PRODUCTOS**/

CREATE PROCEDURE [dbo].[spc_VerProducts]
as

select p.ProductoID as 'ID ', p.CodigoProducto as 'CODIGO ', p.DescripcionProducto as 'NOMBRE',  
	   c.Nombre as  'CATEGORIA' , CAST(p.Precio  AS decimal(6,2)) as 'PRECIO' , p.Existencia as 'STOCK', s.NombreSuplidor as 'SUPLIDOR'
from Productos as p
inner join Categorias as c on c.CategoriaID = p.CategoriaID
inner join Suplidores as s on s.SuplidorID = p.SuplidorID
GO

/** PROCEDURE DE EDITAR PRODUCTO */

CREATE PROCEDURE [dbo].[spc_EditarProducts]
@proID int,
@CodigoProd nvarchar(10),
@Nombre nvarchar(30),
@Stock int,
@Precio money,
@SuplidorID int,
@CategoriaID int
as
update Productos set CodigoProducto=@CodigoProd,DescripcionProducto=@Nombre, 
		Existencia =@Stock,Precio= @Precio, SuplidorID =@SuplidorID,CategoriaID= @CategoriaID 
Where ProductoID = @proID
GO

/***PROCEDURE DE ELIMINAR PROFUCTO **/
CREATE PROCEDURE [dbo].[spc_InsertarProducts]
@CodigoProd nvarchar(10),
@Nombre nvarchar(30),
@Stock int,
@Precio money,
@SuplidorID int,
@CategoriaID int
as
insert into Productos values (@CodigoProd,@Nombre,@Stock,@Precio,@SuplidorID,@CategoriaID)
GO

/*PROCEDURE DE INSERTAR SUPLIDOR*/

CREATE PROCEDURE spc_InsertarSuplidor
@CodigoSupli varchar(15),
@NombreSuplidor varchar(50),
@Telefono varchar(13),
@Direccion varchar(max)
as
insert into Suplidores values (@CodigoSupli,@NombreSuplidor,@Telefono,@Direccion)
GO

--exec spc_InsertarSuplidor 'AS-BREA','Bernado & Asoc','8498597565','Los Rios'
select * from Suplidores

/* PROCEDURE DE EDITAR SUPLIDOR*/

CREATE PROCEDURE spc_EditarSuplidor
@SuplidorID int,
@CodigoSupli varchar(15),
@NombreSuplidor varchar(50),
@Telefono varchar(13),
@Direccion varchar(max)
as
Update Suplidores set CodigoSuplidor = @CodigoSupli,NombreSuplidor = @NombreSuplidor,
Telefono = @Telefono,Direccion = @Direccion
where SuplidorID = @SuplidorID
go

Update Suplidores set CodigoSuplidor = 'AS-BREA',NombreSuplidor = 'Bernado & Asoc',
Telefono = '8498597565', Direccion ='Los Rios #40'
where SuplidorID = 2


CREATE PROCEDURE spc_EditarUsuario
@userName varchar(30),
@pass varchar(15),
@name varchar(25),
@lastName varchar(45),
@mail varchar(150),
@id int
as
update Users set UserName=@userName, Password=@pass, Nombre=@name, Apellidos=@lastName, Email=@mail
 where UserID=@id
 go


 /*PROCEDURE  DE INSERTAR USUARIO*/
 CREATE PROCEDURE spc_InsertarUsuario
 @Username varchar(30),
 @Password varchar(15),
 @Nombre varchar(25),
 @Apellidos varchar(45),
 @Rol varchar(50),
 @Email varchar(150)
 as
insert into Users values (@Username,@Password,@Nombre,@Apellidos,@Rol,@Email)
go

exec spc_InsertarUsuario 'Bryan', 'Bryan', 'Bryan', 'Guzman','Administrador','BryanG@Gmail.com'

select * from Users

use PolarteDB
 Select * from Users

Select UserName, Nombre , Apellidos , Rol , Email from Users


 /*PROCEDURE  DE Editar USUARIO*/
 CREATE PROCEDURE spc_EditarEmpleado
 @UserID int,
 @Username varchar(30),
 @Password varchar(15),
 @Nombre varchar(25),
 @Apellidos varchar(45),
 @Rol varchar(50),
 @Email varchar(150)
 as
 update Users set UserName = @Username, Password = @Password, Nombre = @Nombre, 
 Apellidos = @Apellidos, Rol = @Rol , Email = @Email Where UserID = @UserID;

 update Users set UserName = 'BryanG', Password = 'Bryan', Nombre = 'Bryan', 
 Apellidos = 'Guzman', Rol = 'Administrador' , Email = 'Bryan@Gmail.com' Where UserID = 2;