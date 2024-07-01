USE Proyecto3ra
GO

IF OBJECT_ID('SP_ACTIVO')IS NOT NULL
	DROP PROCEDURE  SP_ACTIVO
GO

CREATE PROCEDURE SP_ACTIVO
(
@Opc				CHAR(1),
@usuario			varchar(55)


)AS
BEGIN
IF @Opc = 'E'
	BEGIN 
	SELECT  usuario,  Empleado.activo
		FROM	Empleado
		WHERE usuario = @usuario


	END
	IF @Opc = 'c'
	BEGIN 
	SELECT  usuario, activo
		FROM	Cliente
		WHERE usuario = @usuario;


	END
END
GO
