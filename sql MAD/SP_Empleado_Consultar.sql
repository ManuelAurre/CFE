USE Proyecto3ra
GO

IF OBJECT_ID('SP_EMPLEADO_CONSULTAR')IS NOT NULL
	DROP PROCEDURE  SP_EMPLEADO_CONSULTAR
GO

CREATE PROCEDURE SP_EMPLEADO_CONSULTAR
(
@Opc				CHAR(1),
@RFC				varchar (55),
@activo				char


)AS
		
---CONSULTAR
	IF @Opc = 'C'
	BEGIN
		SELECT RFC, CURP_empleado, fecha_nacimiento, fecha_alta_mod, usuario, contraseña, administrador, administrador, nombre1, nombre2, a_paterno, a_materno
		FROM	Empleado
		WHERE	RFC		= @RFC;
	END
	IF @Opc = 'B'
	BEGIN
		SELECT usuario, CONCAT (nombre1, ' ', nombre2,' ', a_paterno, '',a_materno) NombreCompleto
		FROM	Empleado
		WHERE activo = @activo;
	END

GO
