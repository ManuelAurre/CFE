USE Proyecto3ra
GO

IF OBJECT_ID('SP_EMPLEADOS')IS NOT NULL
	DROP PROCEDURE  SP_EMPLEADOS
GO

CREATE PROCEDURE SP_EMPLEADOS
(
@Opc				CHAR(1),

@RFC				varchar(55),
@CURP_empleado		varchar(18),
@fecha_nacimiento	date NULL,
 
@usuario			varchar(55),
@contraseña			varchar(55),
@administrador		char = 0,

----------

@nombre1			varchar (55),
@nombre2			varchar (55) NULL,
@a_paterno			varchar (55),
@a_materno			varchar (55),
@fecha_alta_mod		Date

)AS

BEGIN

DECLARE @Hoy datetime;

	SET @Hoy = GETDATE();
	---INSERTAR
	IF @Opc = 'I'
	BEGIN 
		INSERT INTO Empleado(RFC, CURP_empleado, fecha_nacimiento, fecha_alta_mod, usuario, contraseña, administrador,nombre1, nombre2, a_paterno, a_materno,activo)
		VALUES(@RFC, @CURP_empleado, @fecha_nacimiento, @fecha_alta_mod, @usuario, @contraseña, @administrador, @nombre1, @nombre2, @a_paterno, @a_materno,1);
	END
	----MODIFICAR
	IF @Opc = 'M'
	BEGIN
		UPDATE Empleado
		SET		CURP_empleado		= ISNULL (@CURP_empleado, CURP_empleado),
				fecha_nacimiento	= ISNULL (@fecha_nacimiento, fecha_nacimiento),
				fecha_alta_mod		= ISNULL (@fecha_alta_mod, fecha_alta_mod), 
				usuario				= ISNULL (@usuario, usuario),
				contraseña			= ISNULL (@contraseña, contraseña),
				administrador		= ISNULL (@administrador, administrador),
				nombre1				= ISNULL (@nombre1, nombre1),
				nombre2				= ISNULL (@nombre2, nombre2),
				a_paterno			= ISNULL (@a_paterno, a_paterno), 
				a_materno			= ISNULL (@a_materno, a_materno)
		WHERE	RFC					= @RFC;

	
	END
	---BORRAR
	IF @Opc = 'B'
	BEGIN
		DELETE
			FROM Empleado
			WHERE RFC = @RFC;
	END
	

END
GO

