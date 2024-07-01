USE Proyecto3ra
GO

IF OBJECT_ID('SP_CLIENTES_CONSULTAR')IS NOT NULL
	DROP PROCEDURE  SP_CLIENTES_CONSULTAR
GO

CREATE PROCEDURE SP_CLIENTES_CONSULTAR
(
@Opc				CHAR(1),
@CURP_Cliente		varchar(18)		NULL,
@activo				char

)AS
		IF @Opc = 'A'
	BEGIN
		SELECT CURP_Cliente, CONCAT (nombre1, ' ', nombre2,' ', a_paterno, ' ',a_materno) nombrecompleto
		FROM	Cliente
		WHERE	CURP_Cliente		= @CURP_Cliente;
	END
	IF @Opc = 'C'
	BEGIN
		SELECT CURP_Cliente, CONCAT (nombre1, ' ',nombre2,' ', a_paterno, ' ',a_materno) nombrecompleto
		FROM	Cliente
		WHERE	activo = @activo;
	END
	IF @Opc = 'B'
	BEGIN
		SELECT usuario, CONCAT (nombre1, ' ',nombre2,' ', a_paterno, ' ',a_materno) nombrecompleto
		FROM	Cliente
		WHERE	activo = @activo;
	END
GO