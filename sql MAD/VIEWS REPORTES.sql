CREATE VIEW V_REPORTE_GENERAL
AS
SELECT CONCAT (Cliente.nombre1,' ',Cliente.nombre2,' ',Cliente.a_paterno,' ',Cliente.a_materno) AS nombrecompleto,
			YEAR(Recibo.periodo_factura) AS Año_de_Factura, 
			MONTH(Recibo.periodo_factura) AS Mes_deFactura, 
			Servicio.tipo_servicio AS Tipo_de_Servicio, 
			Recibo.total_pago AS Total_Pago,
					Recibo.pendiente_pago AS Pendiente_Pago
FROM
		 Cliente, Tarifa, Servicio, Consumo, Recibo
          WHERE  
			 --Cliente.CURP_Cliente = Consumo.FK_CURP_Cliente  AND
			 Servicio.num_medidor = Recibo.FK_NUM_MEDIDOR AND
			  Servicio.num_medidor = Tarifa.FK_NUM_MEDIDOR AND
			  Consumo.FK_NUM_MEDIDOR = Tarifa.FK_NUM_MEDIDOR AND
			 Consumo.num_consumo = Recibo.FK_NUM_CONSUMO AND
			 Tarifa.num_tarifa = Recibo.FK_NUM_TARIFA AND
			 Consumo.FK_NUM_MEDIDOR = Servicio.num_medidor AND
			Servicio.tipo_servicio = Tarifa.tipo_servicio AND
			Tarifa.periodo_factura = Recibo.periodo_factura

			--Servicio ON Cliente.CURP_Cliente = Servicio.FK_CURP_Cliente INNER JOIN
   --         Tarifa ON Servicio.num_medidor = Tarifa.FK_NUM_MEDIDOR INNER JOIN
			--Consumo.FK_NUM_MEDIDOR = Servicio.num_medidor AND Recibo.FK_NUM_MEDIDOR = Servicio.num_medidor INNER JOIN
			
			--GROUP BY Cliente.nombre1, Cliente.nombre2, Cliente.a_paterno, Cliente.a_materno, Recibo.periodo_factura,
			--.tipo_servicio, Recibo.total_basico, Recibo.total_intermedio, Recibo.total_excedente, Recibo.total_pago, Recibo.pendiente_pago

--DROP VIEW V_REPORTE_GENERAL

CREATE PROCEDURE SP_REPORTE_GENERAL 
AS
BEGIN
SELECT  nombre1, nombre2, a_paterno, a_materno, Recibo.periodo_factura, Servicio.tipo_servicio, total_pago, pendiente_pago
FROM Recibo, Servicio, Cliente, Consumo, Tarifa
WHERE Consumo.num_consumo = Recibo.FK_NUM_CONSUMO AND Tarifa.num_tarifa = Recibo.FK_NUM_TARIFA
 AND Servicio.num_medidor = Recibo.FK_NUM_MEDIDOR

 --Servicio.num_medidor = Recibo.FK_NUM_MEDIDOR AND
	--		 Consumo.num_consumo = Recibo.FK_NUM_CONSUMO AND
	--		 Tarifa.num_tarifa = Recibo.FK_NUM_TARIFA AND
	--		 Consumo.FK_NUM_MEDIDOR = Servicio.num_medidor
END

GO