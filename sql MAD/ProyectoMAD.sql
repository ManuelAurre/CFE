select * from Empleado

select * from Cliente

select * from Servicio

select * from Tarifa

select *from Consumo

select * from Recibo 




DELETE
			FROM Empleado
			

DELETE
			FROM Cliente
			where CURP_Cliente = 'ERICRAFA987'

DELETE
			FROM Servicio
			--where num_medidor = '19'


DELETE
			FROM Tarifa
	

DELETE
			FROM Consumo
			

DELETE		FROM Recibo
		


--Empleado normal

INSERT INTO Empleado (RFC, CURP_empleado,fecha_nacimiento, fecha_alta_mod, usuario, contraseña, administrador,nombre1, nombre2, a_paterno, a_materno, activo)
VALUES ('123456789abcd', '1234567890abcdefgh','1998-10-15', GETDATE(), 'chicho','369', 0, 'Gerardo','Chicho','Cordova','Muñiz', '1') 

--Empleado Administrador

INSERT INTO Empleado (RFC, CURP_empleado,fecha_nacimiento, fecha_alta_mod, usuario, contraseña, administrador,nombre1, nombre2, a_paterno, a_materno, activo)
VALUES ('123456789dcba', '1234567890abcdef11','1995-07-01', GETDATE(), 'sus','123', 1, 'Susana','Deyanira','Salazar','Mata', '1') 


--Cliente Normal
INSERT INTO Cliente (email, CURP_Cliente, fecha_nacimiento, fecha_alta_mod, genero, usuario, contraseña, FK_RFC, nombre1, nombre2, a_paterno, a_materno, activo)
VALUES ('Cliente.Normal@hotmail.com', '1234567890AAAAAAAA','1997-11-11', GETDATE(), 'M', 'pollo', '195', '123456789abcd','Angel','Esteban','Gonzalez','Manzanares', '1') 


--Recibo
INSERT INTO Recibo (periodo_factura ,pendiente_pago, FK_NUM_MEDIDOR, FK_NUM_CONSUMO, FK_NUM_TARIFA)
VALUES (1, 1, 2, 12, 3)


--CREATE VIEW V_USUARIO_Y_CONTRASEÑA
--	AS
--	SELECT usuario, contraseña
--	FROM Cliente

--CREATE VIEW V_USUARIO_CONTRASEÑA_Y_ADMINISTRADOR
--	AS
--	SELECT usuario, contraseña, administrador
--	FROM Empleado

--Drop VIEW V_USUARIO_Y_CONTRASEÑA


--UPDATE Empleado
--		SET		administrador = 1
--		WHERE	RFC	= 123456789asdf; 


--DELETE
--		FROM Empleado
--			WHERE RFC = 123456789asdf;


--CREATE TRIGGER T_APLICAR_RFC
--on Cliente
--AFTER INSERT
--AS
--BEGIN
	
--	DECLARE
	 
--	@RFC varchar = (SELECT RFC FROM Empleado)
	
--	UPDATE Cliente 
--	SET FK_RFC = @RFC
--	WHERE CURP_Cliente = (SELECT CURP_Cliente FROM Cliente)

--END


--DROP TRIGGER T_APLICAR_RFC


--exec SP_CLIENTES_CONSULTAR 'B',0

UPDATE Empleado
	SET activo = 1
	WHERE usuario = 'chicho';
	

exec SP_VALIDACION_TARIFA 1


SELECT activo, CONCAT (nombre1, ' ', nombre2,' ', a_paterno, '',a_materno) NombreCompleto
		FROM	Empleado
		WHERE activo = 0;

exec SP_EMPLEADO_CONSULTAR 'B', 0,0

exec SP_VALIDACION_SERVICIO_TIPO 'Doméstico'


SELECT Año_de_Factura,Mes_de_Factura, Consumo_kw, Importe, Pago, Pendiente_Pago,Medidor,Servicio
		FROM V_CONSUMO_HISTORICO
		WHERE  Año_de_Factura = YEAR('01/01/2020') and Medidor = 4
