USE Proyecto3ra

DROP TABLE Cliente
DROP TABLE Empleado
DROP TABLE Servicio

DROP TABLE Tarifa
DROP TABLE Consumo
DROP TABLE Recibo

CREATE TABLE Empleado
(
RFC varchar (55)				NOT NULL		PRIMARY KEY,
CURP_empleado varchar(55)		NOT NULL, 
fecha_nacimiento date,
fecha_alta_mod date,
usuario varchar(55)				NOT NULL, 
contraseña varchar(55)			NOT NULL,
administrador char,
nombre1 varchar (55)			NOT NULL,
nombre2 varchar (55),
a_paterno varchar (55)			NOT NULL,
a_materno varchar (55)			NOT NULL,
activo char						NOT NULL, 

)

CREATE TABLE Cliente
(
email varchar (55),
CURP_Cliente varchar (55)	NOT NULL		PRIMARY KEY,
fecha_nacimiento date,	
fecha_alta_mod date			NOT NULL, 
genero char, 
usuario varchar(55)			NOT NULL,
contraseña varchar(55)		NOT NULL, 
nombre1 varchar (55)		NOT NULL,
nombre2 varchar (55),
a_paterno varchar (55)		NOT NULL,
a_materno varchar (55)		NOT NULL,
activo char					NOT NULL, 


FK_RFC varchar (55) FOREIGN KEY REFERENCES Empleado(RFC),
);

CREATE TABLE Servicio
(
num_medidor int identity(1,1)	NOT NULL		PRIMARY KEY,	
calle varchar(55)				NOT NULL,
numero int						NOT NULL, 
colonia varchar(55)				NOT NULL,
cpp int							NOT NULL,
municipio varchar(55)			NOT NULL,
tipo_servicio varchar(55)		NOT NULL,

FK_CURP_Cliente varchar (55) FOREIGN KEY REFERENCES Cliente(CURP_Cliente),
FK_RFC varchar (55) FOREIGN KEY REFERENCES Empleado(RFC),
)

CREATE TABLE Tarifa
(
num_tarifa int identity(1, 1)	NOT NULL PRIMARY KEY,
Tarifa_Básico float,
Tarifa_Intermedio float,
Tarifa_Excedente float, 
periodo_factura date,
tipo_servicio varchar(55),

FK_RFC varchar (55) FOREIGN KEY REFERENCES Empleado(RFC),
FK_NUM_MEDIDOR int FOREIGN KEY REFERENCES Servicio(num_medidor),

)

CREATE TABLE Consumo
(
num_consumo int  identity (1, 1) NOT NULL	PRIMARY KEY,
Cons_Basico int,
Cons_Intermedio int,
Cons_Excedente int,
periodo_consumo date,

FK_CURP_Cliente varchar (55) FOREIGN KEY REFERENCES Cliente(CURP_Cliente),
FK_RFC varchar (55) FOREIGN KEY REFERENCES Empleado(RFC),
FK_NUM_MEDIDOR int FOREIGN KEY REFERENCES Servicio(num_medidor),
FK_NUM_TARIFA int FOREIGN KEY REFERENCES Tarifa(num_tarifa)
)


CREATE TABLE Recibo
(
num_recibo int identity(1, 1)	NOT NULL		PRIMARY KEY,
periodo_factura date,
pendiente_pago bit,
subtotal float, 
impuesto float, 
total_pago int, 
total_basico int,
total_intermedio int,
total_excedente int,

FK_NUM_MEDIDOR int FOREIGN KEY REFERENCES Servicio(num_medidor), 
FK_NUM_CONSUMO int FOREIGN KEY REFERENCES Consumo(num_consumo),
FK_NUM_TARIFA int FOREIGN KEY REFERENCES Tarifa(num_tarifa),

)