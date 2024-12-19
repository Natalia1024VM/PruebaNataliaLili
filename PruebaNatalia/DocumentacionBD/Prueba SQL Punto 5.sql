USE PruebaTecnica 

GO
SELECT dbo.Funcion_ObtenerCampoValor('aut:11111|respuesta:Ok|recibo:33333333', 'aut');

SELECT dbo.Funcion_ObtenerCampoValor('aut:11111|respuesta:Ok|recibo:33333333', 'respuesta');

SELECT dbo.Funcion_ObtenerCampoValor('aut:11111|respuesta:Ok|recibo:33333333', 'recibo');

SELECT dbo.Funcion_ObtenerCampoValor('aut:11111|respuesta:Ok|recibo:33333333', 'prueba');
