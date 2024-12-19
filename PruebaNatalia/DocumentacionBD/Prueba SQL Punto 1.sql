use PruebaTecnica 
go 

CREATE TABLE [dbo].[CLIENTE](
	[CEDULA] [varchar](50) NULL,
	[NOMBRE] [varchar](500) NULL,
	[TELEFONO] [varchar](10) NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[CLIENTE]
           ([CEDULA]
           ,[NOMBRE]
           ,[TELEFONO])
     VALUES
           ('234567896', 'JUAN CASAS', '3102334567'),
           ('123983874', 'MARIA MESA', '3102334561'),
           ('298767639', 'JULIO COCINA', '3102334562'),
           ('098273646', 'ANDRES DIAS', '3102334563');

GO
CREATE TABLE [dbo].[PRODUCTOS](
	[ID] [varchar](max) NULL,
	[NOMBRE] [varchar](500) NULL,
	[VALOR] [decimal](18, 0) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT INTO [dbo].[PRODUCTOS]
           ([ID]
           ,[NOMBRE]
           ,[VALOR])
     VALUES
           ('P000000001', 'MEDIAS LARGAS', 15200),
           ('P000000002', 'MEDIAS CORTAS', 12400),
           ('P000000003', 'MEDIAS AZULES', 14100),
           ('P000000004', 'MEDIAS ROTAS', 10000);
GO
CREATE TABLE [dbo].[FACTURA](
	[NO_FACTURA] [int] NULL,
	[CLIENTE] [varchar](50) NULL,
	[PRODUCTO] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

INSERT INTO [dbo].[FACTURA]
           ([NO_FACTURA]
           ,[CLIENTE]
           ,[PRODUCTO])
     VALUES
           (1, '234567896', 'P000000002'),
           (1, '234567896', 'P000000003'),
           (2, '298767639', 'P000000001'),
           (3, '098273646', 'P000000002'),
           (3, '098273646', 'P000000004'),
           (4, '234567896', 'P000000001'),
           (4, '234567896', 'P000000002'),
           (4, '234567896', 'P000000001');


