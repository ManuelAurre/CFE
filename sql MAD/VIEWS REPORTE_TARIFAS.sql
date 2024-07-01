IF OBJECT_ID('V_REPORTE_TARIFAS')IS NOT NULL
	
DROP VIEW V_REPORTE_TARIFAS
GO

CREATE VIEW V_REPORTE_TARIFAS
AS 
SELECT		YEAR(Tarifa.periodo_factura) AS Año_de_Factura, 
			MONTH(Tarifa.periodo_factura) AS Mes_deFactura, 
			Tarifa.Tarifa_Básico AS Tarifa_Básico, 
			Tarifa.Tarifa_Intermedio AS Tarifa_Intermedio,	Tarifa.Tarifa_Excedente AS Tarifa_Excedente
FROM        Tarifa

GO


IF OBJECT_ID('V_REPORTE_CONSUMOS')IS NOT NULL
	
DROP VIEW V_REPORTE_CONSUMOS
GO

CREATE VIEW V_REPORTE_CONSUMOS
AS 
SELECT		YEAR(Consumo.periodo_consumo) AS Año_de_Consumo, 
			MONTH(Consumo.periodo_consumo) AS Mes_de_Consumo, 
			Consumo.Cons_Basico AS Cons_Basico, 
			Consumo.Cons_Intermedio AS Cons_Intermedio,	Consumo.Cons_Excedente AS Cons_Excedente
FROM        Consumo

GO