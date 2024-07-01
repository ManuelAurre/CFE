USE Proyecto3ra
GO

IF OBJECT_ID('SP_RECIBOS')IS NOT NULL
	DROP PROCEDURE  SP_RECIBOS
GO

CREATE PROCEDURE SP_RECIBOS
(
@Opc				CHAR(1),

@periodo_factura date,
@pendiente_pago bit, 
@FK_NUM_MEDIDOR int, 
@FK_NUM_CONSUMO int, 
@FK_NUM_TARIFA int

)AS

BEGIN

	---INSERTAR
	IF @Opc = 'I'
	BEGIN 
		INSERT INTO Recibo(periodo_factura, pendiente_pago, FK_NUM_MEDIDOR, FK_NUM_CONSUMO, FK_NUM_TARIFA)
		VALUES(@periodo_factura, @pendiente_pago, @FK_NUM_MEDIDOR, @FK_NUM_CONSUMO, @FK_NUM_TARIFA);
	END


END
GO 

IF OBJECT_ID('SP_PAGAR')IS NOT NULL
	DROP PROCEDURE  SP_PAGAR
GO

CREATE PROCEDURE SP_PAGAR
(

@periodo_factura date,
@pendiente_pago bit, 
@FK_NUM_MEDIDOR int

)AS

BEGIN

	 BEGIN
		UPDATE Recibo
		SET		pendiente_pago	= 0
		WHERE	periodo_factura	= @periodo_factura AND FK_NUM_MEDIDOR = @FK_NUM_MEDIDOR
	END

END
GO 

