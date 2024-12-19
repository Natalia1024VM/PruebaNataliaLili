-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE SP_ArticuloCliente
@identificacion varchar(50)
AS
BEGIN

  SELECT  TOP 1
        f.CLIENTE, 
        p.NOMBRE AS Producto, 
        p.VALOR AS ValorProducto
    FROM [dbo].[FACTURA] f
    JOIN [dbo].[PRODUCTOS] p ON f.PRODUCTO = p.ID
    WHERE f.CLIENTE =  @identificacion
	ORDER BY p.VALOR DESC;
END
GO
