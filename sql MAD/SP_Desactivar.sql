USE Proyecto3ra
GO

IF OBJECT_ID('SP_DESACTIVAR')IS NOT NULL
	DROP PROCEDURE  SP_DESACTIVAR
GO

CREATE PROCEDURE SP_DESACTIVAR
(
@Opc				CHAR(1),
@usuario			varchar(55)


)AS
BEGIN
IF @Opc = 'E'
	BEGIN 
UPDATE Empleado
	SET activo = 0
	WHERE usuario = @usuario;
	
	END

	IF @Opc = 'C'
	BEGIN 
UPDATE Cliente
	SET activo = 0
	WHERE usuario = @usuario;
	
	END
	IF @Opc = 'D'
	BEGIN 
UPDATE Empleado
	SET activo = 1
	WHERE usuario = @usuario;
	
	END

	IF @Opc = 'F'
	BEGIN 
UPDATE Cliente
	SET activo = 1
	WHERE usuario = @usuario;
	
	END
END
GO