USE Proyecto3ra
GO

IF OBJECT_ID('SP_LOGINC')IS NOT NULL
	DROP PROCEDURE  SP_LOGINC
GO

CREATE PROCEDURE SP_LOGINC
(

@usuario			varchar(55),
@contraseña			varchar(55)


)AS
SELECT  usuario, contraseña,fecha_nacimiento, fecha_alta_mod, usuario, contraseña, nombre1, nombre2, a_paterno, a_materno
		FROM	Cliente
		WHERE usuario = @usuario and contraseña = @contraseña;
GO