
CREATE TRIGGER T_INSERTAR_A_TOTAL_PAGO
on Recibo 
AFTER INSERT
AS

BEGIN 
	DECLARE 
	@num_recibo			int,
	@subtotal			int,
	@total_basico		int,		
	@total_intermedio	int,
	@total_excedente	int,
	@periodo_factura	int,
	@FK_NUM_CONSUMO		int, 
	@FK_NUM_TARIFA		int, 
	@FK_NUM_MEDIDOR	int
	
	SELECT 
	@total_basico		= Recibo.total_basico,
	@total_intermedio	= Recibo.total_intermedio,
	@total_excedente	= Recibo.total_excedente,
	@num_recibo			= Recibo.num_recibo,
	@FK_NUM_CONSUMO		= Recibo.FK_NUM_CONSUMO,
	@FK_NUM_TARIFA		= Recibo.FK_NUM_TARIFA,
	@FK_NUM_MEDIDOR		= Recibo.FK_NUM_MEDIDOR

	FROM Recibo

	UPDATE Recibo
	SET total_basico= (Consumo.Cons_Basico * Tarifa.Tarifa_Básico), total_intermedio = (Consumo.Cons_Intermedio * Tarifa.Tarifa_Intermedio), total_excedente = (Consumo.Cons_Excedente * Tarifa.Tarifa_Excedente)
	FROM consumo, Tarifa, Recibo, Servicio
	WHERE Consumo.num_consumo = Recibo.FK_NUM_CONSUMO AND Tarifa.num_tarifa = Recibo.FK_NUM_TARIFA AND Servicio.num_medidor = Recibo.FK_NUM_MEDIDOR
	

	--INSERT INTO Recibo(total_basico, total_intermedio, total_excedente)
	--SELECT (Consumo.Cons_Basico * Tarifa.Tarifa_Básico),(Consumo.Cons_Intermedio * Tarifa.Tarifa_Intermedio), 
	--(Consumo.Cons_Excedente * Tarifa.Tarifa_Excedente )
	--FROM Consumo, Tarifa, Servicio, Recibo
	--WHERE Consumo.num_consumo = Recibo.FK_NUM_CONSUMO AND Tarifa.num_tarifa = Recibo.FK_NUM_TARIFA AND Servicio.num_medidor = Recibo.FK_NUM_MEDIDOR
	
	--IF TRIGGER_NESTLEVEL(@@PROCID) > 0 RETURN;
	UPDATE Recibo
	SET subtotal = ( Recibo.total_basico + Recibo.total_intermedio + Recibo.total_excedente)
	--(SELECT Recibo.total_basico + Recibo.total_intermedio + Recibo.total_excedente
					--FROM Recibo
					--WHERE num_recibo = @num_recibo
					--)					
					FROM Recibo, Tarifa, Servicio, Consumo
					WHERE Consumo.num_consumo = Recibo.FK_NUM_CONSUMO AND Tarifa.num_tarifa = Recibo.FK_NUM_TARIFA AND Servicio.num_medidor = Recibo.FK_NUM_MEDIDOR
					
	UPDATE Recibo
	SET impuesto = (subtotal * .16)
	FROM Recibo, Consumo, Tarifa, Servicio
	WHERE Consumo.num_consumo = Recibo.FK_NUM_CONSUMO AND Tarifa.num_tarifa = Recibo.FK_NUM_TARIFA AND Servicio.num_medidor = Recibo.FK_NUM_MEDIDOR

	UPDATE Recibo
	SET total_pago = (subtotal * 1.16)
	FROM Recibo, Consumo, Tarifa, Servicio
	WHERE @num_recibo = num_recibo	

	--WHERE Consumo.num_consumo = Recibo.FK_NUM_CONSUMO AND Tarifa.num_tarifa = Recibo.FK_NUM_TARIFA AND Servicio.num_medidor = Recibo.FK_NUM_MEDIDOR
END

	--INSERT INTO Recibo(subtotal)
	--	SELECT 
	--	SUM (Recibo.total_basico + Recibo.total_intermedio + Recibo.total_excedente)
	--	FROM Recibo 
	--	WHERE @num_recibo = num_recibo	

--DROP TRIGGER T_INSERTAR_A_TOTAL_PAGO
