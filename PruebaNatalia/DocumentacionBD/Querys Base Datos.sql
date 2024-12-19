create  database PruebaTecnica

go
use PruebaTecnica

Go

CREATE TABLE [dbo].[Reporte](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Estado] [bit] NULL
) ON [PRIMARY]
GO
CREATE PROCEDURE SP_InsertarReporte
@Nombre varchar(50),
@Estado bit,	
@resultado int OUTPUT
AS
BEGIN
INSERT INTO Reporte
VALUES (@Nombre,@Estado )
		set @resultado= @@rowcount

END
GO

CREATE PROCEDURE SP_ConsultarReportes
AS
BEGIN
SELECT * FROM Reporte

END


