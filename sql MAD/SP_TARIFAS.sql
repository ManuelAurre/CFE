USE Proyecto3ra
GO

IF OBJECT_ID('SP_TARIFAS')IS NOT NULL
	DROP PROCEDURE  SP_TARIFAS
GO

CREATE PROCEDURE SP_TARIFAS
(
@Opc				CHAR(1),

@Tarifa_Básico		float ,
@Tarifa_Intermedio	float ,
@Tarifa_Excedente	float,
@FK_RFC				varchar (55),
@FK_NUM_MEDIDOR		int,
@periodo_factura date,
@tipo_servicio varchar(55)

)AS

BEGIN

	---INSERTAR
	IF @Opc = 'I'
	BEGIN 
		INSERT INTO Tarifa(Tarifa_Básico, Tarifa_Intermedio, Tarifa_Excedente, FK_RFC, FK_NUM_MEDIDOR,periodo_factura, tipo_servicio)
		VALUES(@Tarifa_Básico, @Tarifa_intermedio, @Tarifa_Excedente, @FK_RFC, @FK_NUM_MEDIDOR, @periodo_factura, @tipo_servicio);
	END
	
END
GO