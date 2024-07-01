
CREATE TRIGGER T_INSERTAR_A_TOTALES_BIE
on Recibo 
AFTER INSERT
AS
BEGIN 
	
	DECLARE 
	@total_basico		int,
	@total_intermedio	int, 
	@total_excedente	int 

	SELECT 
	@total_basico		= Recibo.total_basico,
	@total_intermedio	= Recibo.total_intermedio,
	@total_excedente	= Recibo.total_excedente
	
	FROM Recibo
	INSERT INTO Recibo(total_basico, total_intermedio, total_excedente)
		SELECT (Consumo.Cons_Basico * Tarifa.Tarifa_Básico),(Consumo.Cons_Intermedio * Tarifa.Tarifa_Intermedio), 
		(Consumo.Cons_Excedente * Tarifa.Tarifa_Excedente ) 
		FROM Consumo join Tarifa ON Tarifa.num_tarifa = Consumo.FK_NUM_TARIFA

END

DROP TRIGGER T_INSERTAR_A_TOTALES_BIE