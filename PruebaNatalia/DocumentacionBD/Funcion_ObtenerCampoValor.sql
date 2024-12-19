CREATE FUNCTION dbo.Funcion_ObtenerCampoValor (
    @texto varchar(MAX),
    @campo varchar(100)
)
RETURNS varchar(100) 
AS
BEGIN
    DECLARE @valor varchar(100);
    DECLARE @inicio int;
    DECLARE @fin int;

    SET @inicio = CHARINDEX(@campo + ':', @texto);

    IF @inicio = 0
    BEGIN
        RETURN 'No existe texto' ;
    END

    SET @inicio = @inicio + LEN(@campo) + 1;

    SET @fin = CHARINDEX('|', @texto + '|', @inicio);

    SET @valor = SUBSTRING(@texto, @inicio, @fin - @inicio);

    RETURN @valor ;
END
