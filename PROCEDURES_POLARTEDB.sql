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
