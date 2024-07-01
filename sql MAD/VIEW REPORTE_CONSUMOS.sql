CREATE VIEW V_REPORTE_CONSUMOS
AS
SELECT		YEAR(Recibo.periodo_factura) AS Año_de_Factura, 
			MONTH(Recibo.periodo_factura) AS Mes_deFactura, 	
			Servicio.num_medidor AS Número_Medidor, 
			Consumo.Cons_Basico AS Consumo_Básico,			Consumo.Cons_Intermedio AS Consumo_Intermedio, 
			Consumo.Cons_Excedente AS Consumo_Excedente
FROM		Consumo, Servicio, Recibo, Tarifa
WHERE		Consumo.num_consumo = Recibo.FK_NUM_CONSUMO AND
--Tarifa.num_tarifa = Recibo.FK_NUM_TARIFA AND Servicio.num_medidor = Recibo.FK_NUM_MEDIDOR
			--INNER JOIN Recibo ON Consumo.FK_NUM_RECIBO = Recibo.num_recibo 
	 --Consumo.FK_NUM_MEDIDOR = Servicio.num_medidor AND Recibo.FK_NUM_MEDIDOR = Servicio.num_medidor
	  Servicio.num_medidor = Recibo.FK_NUM_MEDIDOR AND
			 Consumo.num_consumo = Recibo.FK_NUM_CONSUMO 

--DROP VIEW V_REPORTE_CONSUMOS