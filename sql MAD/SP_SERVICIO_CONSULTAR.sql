USE Proyecto3ra
GO

IF OBJECT_ID('SP_SERVICIO_CONSULTAR')IS NOT NULL
	DROP PROCEDURE  SP_SERVICIO_CONSULTAR
GO

CREATE PROCEDURE SP_SERVICIO_CONSULTAR
(
@Opc				CHAR(1),
@FK_CURP_Cliente varchar (55)


)AS
		IF @Opc = 'A'
	BEGIN
		SELECT num_medidor, CONCAT (calle, ' ', colonia,' ', municipio) Ubicacion
		FROM	Servicio
		WHERE	FK_CURP_Cliente		= @FK_CURP_Cliente;
	END

	IF @Opc = 'B'
	BEGIN
		SELECT num_medidor, CONCAT (calle, ' ', colonia,' ', municipio) Ubicacion
		FROM	Servicio
		
	END
	IF @Opc = 'C'
	BEGIN
		SELECT num_medidor
		FROM	Servicio
		
	END

	IF @Opc = 'D'
	BEGIN
		SELECT num_medidor, FK_CURP_Cliente
		FROM	Servicio
		
	END

	IF @Opc = 'E'
	BEGIN
		SELECT num_medidor, tipo_servicio, FK_CURP_Cliente
		FROM	Servicio
		
	END
GO


USE Proyecto3ra
GO

IF OBJECT_ID('SP_TARIFA_CONSULTAR')IS NOT NULL
	DROP PROCEDURE  SP_TARIFA_CONSULTAR
GO

CREATE PROCEDURE SP_TARIFA_CONSULTAR
(
@Opc				CHAR(1),
@tipo_servicio  varchar (55)


)AS
	

	IF @Opc = 'A'
	BEGIN
		SELECT FK_NUM_MEDIDOR, tipo_servicio, periodo_factura, num_tarifa
		FROM	Tarifa
	END

	IF @Opc = 'B'
	BEGIN
		SELECT FK_NUM_MEDIDOR, tipo_servicio, periodo_factura, num_tarifa
		FROM	Tarifa
		WHERE tipo_servicio = @tipo_servicio
	END

GO

IF OBJECT_ID('SP_TARIFA_VIEW')IS NOT NULL
	DROP PROCEDURE  SP_TARIFA_VIEW
GO

CREATE PROCEDURE SP_TARIFA_VIEW
(
@Opc				CHAR(1),
@periodo_factura  DATE


)AS
	
	IF @Opc = 'C'
	BEGIN

		SELECT Tarifa_Básico, Tarifa_Intermedio, Tarifa_Excedente, periodo_factura
		FROM	Tarifa
		WHERE periodo_factura = @periodo_factura
	END
	IF @Opc = 'D'
	BEGIN

		SELECT Tarifa_Básico, Tarifa_Intermedio, Tarifa_Excedente, Año_de_Factura, Mes_deFactura
		FROM V_REPORTE_TARIFAS
		WHERE  Año_de_Factura = YEAR(@periodo_factura)
	END
GO


IF OBJECT_ID('SP_CONSUMO_VIEW')IS NOT NULL
	DROP PROCEDURE  SP_CONSUMO_VIEW
GO

CREATE PROCEDURE SP_CONSUMO_VIEW
(
@Opc				CHAR(1),
@periodo_consumo  DATE


)AS
	
	IF @Opc = 'C'
	BEGIN

		SELECT Cons_Basico, Cons_Intermedio, Cons_Excedente, periodo_consumo
		FROM	Consumo
		WHERE periodo_consumo = @periodo_consumo
	END
	IF @Opc = 'D'
	BEGIN

		SELECT Cons_Basico, Cons_Intermedio, Cons_Excedente, Año_de_Consumo, Mes_de_Consumo
		FROM V_REPORTE_CONSUMOS
		WHERE  Año_de_Consumo = YEAR(@periodo_consumo)
	END
GO



IF OBJECT_ID('SP_CONSUMO_HISTORICO_VIEW')IS NOT NULL
	DROP PROCEDURE  SP_CONSUMO_HISTORICO_VIEW
GO

CREATE PROCEDURE SP_CONSUMO_HISTORICO_VIEW
(
@Opc				CHAR(1),
@periodo_factura	DATE,
@FK_NUM_MEDIDOR		int,
@tipo_servicio		varchar(55)		

)AS
	
	IF @Opc = 'D'
	BEGIN
		SELECT Perido_De_Factura, Consumo_kw, Importe, Pago, Pendiente_Pago,Medidor,Servicio
		FROM V_CONSUMO_HISTORICO
		WHERE  Año_de_Factura = YEAR(@periodo_factura) and Medidor = @FK_NUM_MEDIDOR	
	END
	IF @Opc = 'E'
	BEGIN
		SELECT Perido_De_Factura, Consumo_kw, Importe, Pago, Pendiente_Pago,Medidor ,Servicio
		FROM V_CONSUMO_HISTORICO
		WHERE  Año_de_Factura = YEAR(@periodo_factura) and Servicio = @tipo_servicio	
	END
	IF @Opc = 'F'
	BEGIN
		SELECT Perido_De_Factura, Consumo_kw, Importe, Pago, Pendiente_Pago,Medidor,Servicio
		FROM V_CONSUMO_HISTORICO
		WHERE  Año_de_Factura = YEAR(@periodo_factura)
	END
GO



IF OBJECT_ID('SP_REPORTE_GENERAL')IS NOT NULL
	DROP PROCEDURE  SP_REPORTE_GENERAL
GO

CREATE PROCEDURE SP_REPORTE_GENERAL
(
@Opc				CHAR(1),
@periodo_factura	DATE,
@tipo_servicio		varchar(55)		

)AS
	
	IF @Opc = 'D'
	BEGIN
		SELECT Año_de_Factura, Mes_de_Factura, Servicio, Total_Pagado, Pendiente_Pago
		FROM V_REPORTE_GENERAL
		WHERE  Año_de_Factura = YEAR(@periodo_factura) AND Servicio = @tipo_servicio 
	END

	IF @Opc = 'E'
	BEGIN
		SELECT Año_de_Factura, Mes_de_Factura, Servicio, Total_Pagado, Pendiente_Pago
		FROM V_REPORTE_GENERAL
		WHERE  Año_de_Factura = YEAR(@periodo_factura) AND Mes_de_Factura = MONTH(@periodo_factura) AND Servicio = @tipo_servicio 
	END


	IF @Opc = 'F'
	BEGIN
		SELECT Año_de_Factura, Mes_de_Factura, Servicio, Total_Pagado, Pendiente_Pago
		FROM V_REPORTE_GENERAL
		WHERE  Año_de_Factura = YEAR(@periodo_factura) 
	END
	IF @Opc = 'G'
	BEGIN
		SELECT Año_de_Factura, Mes_de_Factura, Servicio, Total_Pagado, Pendiente_Pago
		FROM V_REPORTE_GENERAL
		WHERE  Año_de_Factura = YEAR(@periodo_factura) AND Mes_de_Factura = MONTH(@periodo_factura)
	END

	
GO



IF OBJECT_ID('SP_RECIBO_VIEW')IS NOT NULL
	DROP PROCEDURE  SP_RECIBO_VIEW
GO

CREATE PROCEDURE SP_RECIBO_VIEW
(
@Opc				CHAR(1),
@periodo_factura	DATE,
@FK_NUM_MEDIDOR		INT

)AS
	
	IF @Opc = 'D'
	BEGIN
		SELECT NombreCompleto, Domicilio, Numero_De_Medidor,Periodo_De_Factura, Total_a_Pagar, Nivel_de_Consumos, Tarifas_por_Nivel, SubTotal, Impuestos, Letra
		FROM V_RECIBO
		WHERE  Año_de_Factura = YEAR(@periodo_factura) AND Mes_de_Factura = MONTH(@periodo_factura) and Pendiente_De_Pago = 1 and Numero_De_Medidor = @FK_NUM_MEDIDOR
	END

	
GO







IF OBJECT_ID('SP_CONSUMOS_CONSULTAR')IS NOT NULL
	DROP PROCEDURE  SP_CONSUMOS_CONSULTAR
GO

CREATE PROCEDURE SP_CONSUMOS_CONSULTAR
(
@Opc				CHAR(1),
@FK_NUM_MEDIDOR  varchar (55)


)AS
	

	IF @Opc = 'A'
	BEGIN
		SELECT FK_NUM_MEDIDOR, FK_NUM_TARIFA, periodo_consumo, num_consumo
		FROM	Consumo
	END

	
GO