USE Proyecto3ra
GO

IF OBJECT_ID('SP_LOGINC')IS NOT NULL
	DROP PROCEDURE  SP_LOGINC
GO

CREATE PROCEDURE SP_LOGINC
(

@usuario			varchar(55),
@contrase�a			varchar(55)


)AS
SELECT  usuario, contrase�a,fecha_nacimiento, fecha_alta_mod, usuario, contrase�a, nombre1, nombre2, a_paterno, a_materno
		FROM	Cliente
		WHERE usuario = @usuario and contrase�a = @contrase�a;
GO