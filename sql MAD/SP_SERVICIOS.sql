USE Proyecto3ra
GO

IF OBJECT_ID('SP_SERVICIOS')IS NOT NULL
	DROP PROCEDURE  SP_SERVICIOS
GO

CREATE PROCEDURE SP_SERVICIOS
(
@Opc				CHAR(1),

@calle varchar(55),				
@numero int, 
@colonia varchar(55),
@cpp int,
@municipio varchar(55),
@tipo_servicio varchar(55),

@FK_CURP_Cliente varchar (55),
@FK_RFC varchar (55)
)AS

BEGIN

	---INSERTAR
	IF @Opc = 'I'
	BEGIN 
		INSERT INTO Servicio( calle, numero, colonia, cpp, municipio, tipo_servicio,FK_CURP_Cliente, FK_RFC)
		VALUES(@calle, @numero, @colonia, @cpp, @municipio, @tipo_servicio, @FK_CURP_Cliente,@FK_RFC);
	END
END
GO
