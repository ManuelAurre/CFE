IF OBJECT_ID('V_CONSUMO_HISTORICO')IS NOT NULL
	
DROP VIEW V_CONSUMO_HISTORICO
GO

CREATE VIEW V_CONSUMO_HISTORICO
AS
SELECT		
			Recibo.periodo_factura AS Perido_De_Factura,
			YEAR(Recibo.periodo_factura) As A�o_de_Factura,  
			(Consumo.Cons_Basico + Consumo.Cons_Intermedio + Consumo.Cons_Excedente) AS Consumo_kw,
			Recibo.subtotal as Importe,					
			Recibo.total_pago as Pago, 
			Recibo.pendiente_pago as Pendiente_Pago,
			Tarifa.periodo_factura AS Periodo_Factura_Tarifa,
			Consumo.FK_NUM_MEDIDOR	AS Medidor,	
			Tarifa.tipo_servicio	AS Servicio

FROM Consumo, Recibo, Tarifa
WHERE	Consumo.FK_NUM_MEDIDOR = Tarifa.FK_NUM_MEDIDOR 
	and Consumo.periodo_consumo = Tarifa.periodo_factura 
	and Recibo.periodo_factura = Tarifa.periodo_factura 
	and Recibo.FK_NUM_MEDIDOR = Tarifa.FK_NUM_MEDIDOR 
GO



IF OBJECT_ID('V_REPORTE_GENERAL')IS NOT NULL
	
DROP VIEW V_REPORTE_GENERAL
GO

CREATE VIEW V_REPORTE_GENERAL
AS
SELECT		YEAR(Recibo.periodo_factura) As A�o_de_Factura, 
			MONTH(Recibo.periodo_factura) As Mes_de_Factura,
			Tarifa.tipo_servicio	AS Servicio,				
			Recibo.total_pago as Total_Pagado, 
			Recibo.pendiente_pago as Pendiente_Pago

FROM  Recibo, Tarifa
WHERE Recibo.periodo_factura = Tarifa.periodo_factura 
	and Recibo.FK_NUM_MEDIDOR = Tarifa.FK_NUM_MEDIDOR 
GO

 --los datos de
--identificaci�n del cliente, domicilio, n�mero de medidor,
--n�mero de servicio, periodo de facturaci�n, total a pagar,
--desglose del pago por nivel de consumo, tarifa por nivel,
--subtotal, impuesto, cantidad en letra,




IF OBJECT_ID('V_RECIBO')IS NOT NULL
	
DROP VIEW V_RECIBO
GO

CREATE VIEW V_RECIBO
AS
SELECT		CONCAT (Cliente.nombre1, ' ', Cliente.nombre2,' ', Cliente.a_paterno, ' ',Cliente.a_materno) AS NombreCompleto,
			CONCAT ('Calle: ',Servicio.calle, ' Colonia: ', Servicio.colonia,' Codigo Postal: ', Servicio.cpp, ' Municipio: ',Servicio.municipio, ' Numero: ',Servicio.numero) AS Domicilio,
			Servicio.num_medidor As Numero_De_Medidor,
			Recibo.periodo_factura As Periodo_De_Factura,
			YEAR(Recibo.periodo_factura) As A�o_de_Factura, 
			MONTH(Recibo.periodo_factura) As Mes_de_Factura,
			Recibo.total_pago As Total_a_Pagar,
			CONCAT ('Consumo Basico: ',Consumo.Cons_Basico, ' Consumo Intermedio: ', Consumo.Cons_Intermedio,' Consumo Excedente: ', Consumo.Cons_Excedente) AS Nivel_de_Consumos,
			CONCAT ('Tarifa Basico: ',Tarifa.Tarifa_B�sico, ' Tarifa Intermedio: ', Tarifa.Tarifa_Intermedio,' Tarifa Excedente: ', Tarifa.Tarifa_Excedente) AS Tarifas_por_Nivel,
			Recibo.subtotal As SubTotal, 
			Recibo.impuesto As Impuestos,
			[dbo].[CantidadConLetra](Recibo.total_pago) As Letra,
			Recibo.Pendiente_Pago As Pendiente_De_Pago
 

FROM  Recibo, Cliente, Servicio, Consumo,Tarifa
WHERE	Consumo.FK_NUM_MEDIDOR = Tarifa.FK_NUM_MEDIDOR 
	and Consumo.periodo_consumo = Tarifa.periodo_factura 
	and Recibo.periodo_factura = Tarifa.periodo_factura 
	and Recibo.FK_NUM_MEDIDOR = Tarifa.FK_NUM_MEDIDOR 
	and Servicio.FK_CURP_Cliente = Cliente.CURP_Cliente
	and Consumo.FK_CURP_Cliente = Cliente.CURP_Cliente
GO





IF OBJECT_ID('[dbo].[CantidadConLetra]')IS NOT NULL
	
Drop Function [dbo].[CantidadConLetra]
GO




CREATE FUNCTION [dbo].[CantidadConLetra]
(
    @Numero             Decimal(18,2)
)
RETURNS Varchar(180)
AS
BEGIN
    DECLARE @ImpLetra Varchar(180)
        DECLARE @lnEntero INT,
                        @lcRetorno VARCHAR(512),
                        @lnTerna INT,
                        @lcMiles VARCHAR(512),
                        @lcCadena VARCHAR(512),
                        @lnUnidades INT,
                        @lnDecenas INT,
                        @lnCentenas INT,
                        @lnFraccion INT
        SELECT  @lnEntero = CAST(@Numero AS INT),
                        @lnFraccion = (@Numero - @lnEntero) * 100,
                        @lcRetorno = '',
                        @lnTerna = 1
  WHILE @lnEntero > 0
  BEGIN /* WHILE */
            -- Recorro terna por terna
            SELECT @lcCadena = ''
            SELECT @lnUnidades = @lnEntero % 10
            SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
            SELECT @lnDecenas = @lnEntero % 10
            SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
            SELECT @lnCentenas = @lnEntero % 10
            SELECT @lnEntero = CAST(@lnEntero/10 AS INT)
            -- Analizo las unidades
            SELECT @lcCadena =
            CASE /* UNIDADES */
              WHEN @lnUnidades = 1 THEN 'UN ' + @lcCadena
              WHEN @lnUnidades = 2 THEN 'DOS ' + @lcCadena
              WHEN @lnUnidades = 3 THEN 'TRES ' + @lcCadena
              WHEN @lnUnidades = 4 THEN 'CUATRO ' + @lcCadena
              WHEN @lnUnidades = 5 THEN 'CINCO ' + @lcCadena
              WHEN @lnUnidades = 6 THEN 'SEIS ' + @lcCadena
              WHEN @lnUnidades = 7 THEN 'SIETE ' + @lcCadena
              WHEN @lnUnidades = 8 THEN 'OCHO ' + @lcCadena
              WHEN @lnUnidades = 9 THEN 'NUEVE ' + @lcCadena
              ELSE @lcCadena
            END /* UNIDADES */
            -- Analizo las decenas
            SELECT @lcCadena =
            CASE /* DECENAS */
              WHEN @lnDecenas = 1 THEN
                CASE @lnUnidades
                  WHEN 0 THEN 'DIEZ '
                  WHEN 1 THEN 'ONCE '
                  WHEN 2 THEN 'DOCE '
                  WHEN 3 THEN 'TRECE '
                  WHEN 4 THEN 'CATORCE '
                  WHEN 5 THEN 'QUINCE '
                  WHEN 6 THEN 'DIEZ Y SEIS '
                  WHEN 7 THEN 'DIEZ Y SIETE '
                  WHEN 8 THEN 'DIEZ Y OCHO '
                  WHEN 9 THEN 'DIEZ Y NUEVE '
                END
              WHEN @lnDecenas = 2 THEN
              CASE @lnUnidades
                WHEN 0 THEN 'VEINTE '
                ELSE 'VEINTI' + @lcCadena
              END
              WHEN @lnDecenas = 3 THEN
              CASE @lnUnidades
                WHEN 0 THEN 'TREINTA '
                ELSE 'TREINTA Y ' + @lcCadena
              END
              WHEN @lnDecenas = 4 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'CUARENTA'
                    ELSE 'CUARENTA Y ' + @lcCadena
                END
              WHEN @lnDecenas = 5 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'CINCUENTA '
                    ELSE 'CINCUENTA Y ' + @lcCadena
                END
              WHEN @lnDecenas = 6 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'SESENTA '
                    ELSE 'SESENTA Y ' + @lcCadena
                END
              WHEN @lnDecenas = 7 THEN
                 CASE @lnUnidades
                    WHEN 0 THEN 'SETENTA '
                    ELSE 'SETENTA Y ' + @lcCadena
                 END
              WHEN @lnDecenas = 8 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'OCHENTA '
                    ELSE  'OCHENTA Y ' + @lcCadena
                END
              WHEN @lnDecenas = 9 THEN
                CASE @lnUnidades
                    WHEN 0 THEN 'NOVENTA '
                    ELSE 'NOVENTA Y ' + @lcCadena
                END
              ELSE @lcCadena
            END /* DECENAS */
            -- Analizo las centenas
            SELECT @lcCadena =
            CASE /* CENTENAS */
              WHEN @lnCentenas = 1 THEN 'CIENTO ' + @lcCadena
              WHEN @lnCentenas = 2 THEN 'DOSCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 3 THEN 'TRESCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 4 THEN 'CUATROCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 5 THEN 'QUINIENTOS ' + @lcCadena
              WHEN @lnCentenas = 6 THEN 'SEISCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 7 THEN 'SETECIENTOS ' + @lcCadena
              WHEN @lnCentenas = 8 THEN 'OCHOCIENTOS ' + @lcCadena
              WHEN @lnCentenas = 9 THEN 'NOVECIENTOS ' + @lcCadena
              ELSE @lcCadena
            END /* CENTENAS */
            -- Analizo la terna
            SELECT @lcCadena =
            CASE /* TERNA */
              WHEN @lnTerna = 1 THEN @lcCadena
              WHEN @lnTerna = 2 THEN @lcCadena + 'MIL '
              WHEN @lnTerna = 3 THEN @lcCadena + 'MILLONES '
              WHEN @lnTerna = 4 THEN @lcCadena + 'MIL '
              ELSE ''
            END /* TERNA */
            -- Armo el retorno terna a terna
            SELECT @lcRetorno = @lcCadena  + @lcRetorno
            SELECT @lnTerna = @lnTerna + 1
   END /* WHILE */
   IF @lnTerna = 1
       SELECT @lcRetorno = 'CERO'
   DECLARE @sFraccion VARCHAR(15)
   SET @sFraccion = '00' + LTRIM(CAST(@lnFraccion AS varchar))
   SELECT @ImpLetra = RTRIM(@lcRetorno) + ' PESOS ' + SUBSTRING(@sFraccion,LEN(@sFraccion)-1,2) + '/100 PESOS'

   RETURN @ImpLetra
END
GO