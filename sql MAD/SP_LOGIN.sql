USE Proyecto3ra
GO

IF OBJECT_ID('SP_LOGINE')IS NOT NULL
	DROP PROCEDURE  SP_LOGINE
GO

CREATE PROCEDURE SP_LOGINE
(
@usuario			varchar(55),
@contrase�a			varchar(55)


)AS
	SELECT  usuario, contrase�a, administrador,RFC, CURP_empleado, fecha_nacimiento, fecha_alta_mod, usuario, contrase�a, nombre1, administrador, nombre2, a_paterno, a_materno
		FROM	Empleado
		WHERE usuario = @usuario and contrase�a = @contrase�a;
GO