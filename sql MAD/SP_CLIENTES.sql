USE Proyecto3ra
GO

IF OBJECT_ID('SP_CLIENTES')IS NOT NULL
	DROP PROCEDURE  SP_CLIENTES
GO

CREATE PROCEDURE SP_CLIENTES
(
@Opc				CHAR(1),
@email				varchar(55)		NULL,
@CURP_Cliente		varchar(18)		NULL,
@fecha_nacimiento	date			NULL, 
@genero				char			NULL, 
@usuario			varchar(55)		NULL,
@contraseña			varchar(55)		NULL,
@FK_RFC				varchar (55),
----------

@nombre1			varchar (55),
@nombre2			varchar (55)	NULL,
@a_paterno			varchar (55),
@a_materno			varchar (55)

)AS
BEGIN

DECLARE @Hoy datetime;

	SET @Hoy = GETDATE();
	---INSERTAR
	IF @Opc = 'I'
	BEGIN 
		INSERT INTO Cliente(email, CURP_Cliente, fecha_nacimiento, fecha_alta_mod,genero, usuario, contraseña,FK_RFC, nombre1, nombre2, a_paterno, a_materno, activo)
		VALUES(@email, @CURP_Cliente, @fecha_nacimiento, @Hoy, @genero, @usuario, @contraseña, @FK_RFC, @nombre1, @nombre2, @a_paterno, @a_materno, 1);
	END
	----MODIFICAR
	IF @Opc = 'M'
	BEGIN
		UPDATE Cliente
		SET		email				= ISNULL (@email, email),
				fecha_nacimiento	= ISNULL (@fecha_nacimiento, fecha_nacimiento),
				fecha_alta_mod		= ISNULL (@Hoy, fecha_alta_mod), 
				genero				= ISNULL (@genero, genero),
				usuario				= ISNULL (@usuario, usuario),
				contraseña			= ISNULL (@contraseña, contraseña),	
				@FK_RFC				= ISNULL (@FK_RFC, FK_RFC),	
				nombre1				= ISNULL (@nombre1, nombre1),
				nombre2				= ISNULL (@nombre2, nombre2),
				a_paterno			= ISNULL (@a_paterno, a_paterno), 
				a_materno			= ISNULL (@a_materno, a_materno)
		WHERE	CURP_Cliente		= @CURP_Cliente;
	END
	---BORRAR
	IF @Opc = 'B'
	BEGIN
		DELETE
			FROM Cliente
			WHERE CURP_Cliente = @CURP_Cliente;
	END
	---CONSULTAR
	IF @Opc = 'C'
	BEGIN
		SELECT email, CURP_Cliente, fecha_nacimiento, fecha_alta_mod,genero, usuario, contraseña, FK_RFC, nombre1, nombre2, a_paterno, a_materno
		FROM	Cliente
		WHERE	CURP_Cliente		= @CURP_Cliente;
	END
END
GO