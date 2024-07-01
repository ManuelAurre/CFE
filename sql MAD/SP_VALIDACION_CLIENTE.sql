USE Proyecto3ra
GO

IF OBJECT_ID('SP_VALIDACION_CLIENTES')IS NOT NULL
	DROP PROCEDURE  SP_VALIDACION_CLIENTES
GO

CREATE PROCEDURE SP_VALIDACION_CLIENTES
(
@FK_RFC			varchar(55)


)AS
BEGIN
	SELECT   FK_RFC, CURP_Cliente, email, fecha_nacimiento, fecha_alta_mod, genero, usuario, contraseña, nombre1, nombre2, a_paterno, a_materno, activo
		FROM	Cliente
		WHERE FK_RFC = @FK_RFC;
		END
GO


IF OBJECT_ID('SP_CLIENTE_ACTUAL')IS NOT NULL
	DROP PROCEDURE  SP_CLIENTE_ACTUAL
GO

CREATE PROCEDURE SP_CLIENTE_ACTUAL
(
@usuario			varchar(55)


)AS
BEGIN
	SELECT   FK_RFC, CURP_Cliente, email, fecha_nacimiento, fecha_alta_mod, genero, usuario, contraseña, nombre1, nombre2, a_paterno, a_materno, activo
		FROM	Cliente
		WHERE usuario = @usuario;
		END
GO
