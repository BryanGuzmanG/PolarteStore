USE [PolarteDB]
GO
/****** Object:  StoredProcedure [dbo].[spc_VerProducts]    Script Date: 18/11/2019 11:42:54 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spc_VerProducts]
as

select p.ProductoID as 'ID ', p.CodigoProducto as 'CODIGO ', p.DescripcionProducto as 'NOMBRE',  
	   c.Nombre as  'CATEGORIA' , CAST(p.Precio  AS decimal(6,2)) as 'PRECIO' , p.Existencia as 'STOCK', s.NombreSuplidor as 'SUPLIDOR'
from Productos as p
inner join Categorias as c on c.CategoriaID = p.CategoriaID
inner join Suplidores as s on s.SuplidorID = p.SuplidorID
