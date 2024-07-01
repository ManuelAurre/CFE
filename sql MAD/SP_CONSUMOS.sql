USE Proyecto3ra
GO

IF OBJECT_ID('SP_CONSUMOS')IS NOT NULL
	DROP PROCEDURE  SP_CONSUMOS
GO

CREATE PROCEDURE SP_CONSUMOS
(
@Opc				CHAR(1),

@Cons_Basico int,
@Cons_Intermedio int, 
@Cons_Excedente int,
@periodo_consumo date,
@FK_CURP_Cliente varchar(55),
@FK_RFC varchar (55),
@FK_NUM_TARIFA int,
@FK_NUM_MEDIDOR int

)AS

BEGIN

	---INSERTAR
	IF @Opc = 'I'
	BEGIN 
		INSERT INTO Consumo(Cons_Basico, Cons_Intermedio, Cons_Excedente, FK_CURP_Cliente, FK_RFC, FK_NUM_MEDIDOR, FK_NUM_TARIFA, periodo_consumo)
		VALUES(@Cons_Basico, @Cons_Intermedio, @Cons_Excedente, @FK_CURP_Cliente, @FK_RFC, @FK_NUM_MEDIDOR, @FK_NUM_TARIFA, @periodo_consumo);
	END


END
GO