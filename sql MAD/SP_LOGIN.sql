USE Proyecto3ra
GO

IF OBJECT_ID('SP_LOGINE')IS NOT NULL
	DROP PROCEDURE  SP_LOGINE
GO

CREATE PROCEDURE SP_LOGINE
(
@usuario			varchar(55),
@contraseña			varchar(55)


)AS
	SELECT  usuario, contraseña, administrador,RFC, CURP_empleado, fecha_nacimiento, fecha_alta_mod, usuario, contraseña, nombre1, administrador, nombre2, a_paterno, a_materno
		FROM	Empleado
		WHERE usuario = @usuario and contraseña = @contraseña;
GO