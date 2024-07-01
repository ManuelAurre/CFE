USE Proyecto3ra
GO

IF OBJECT_ID('SP_LOGINC')IS NOT NULL
	DROP PROCEDURE  SP_LOGINC
GO

CREATE PROCEDURE SP_LOGINC
(

@usuario			varchar(55),
@contraseņa			varchar(55)


)AS
SELECT  usuario, contraseņa,fecha_nacimiento, fecha_alta_mod, usuario, contraseņa, nombre1, nombre2, a_paterno, a_materno
		FROM	Cliente
		WHERE usuario = @usuario and contraseņa = @contraseņa;
GO