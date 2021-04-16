/* Creacion base de datos */ 

CREATE DATABASE UsuariosDB;

use UsuariosDB; /*uso db */ 

--DROP DATABASE UsuariosDB; borra base de datos
-- Select @@version -- muestra la version sql server  

CREATE TABLE EMPLEADO ( --Creacion tabla empleado
    idEmpleado int IDENTITY(1,1), /*Autoincrementable*/ 
	documento varchar (25) PRIMARY KEY not null,
    nombre varchar(32) NOT NULL,
	apellido VARCHAR (32) not null,
	);

CREATE TABLE REGISTRO ( --Creacion tabla registro 
    idRegistro int IDENTITY(1,1) PRIMARY KEY , /*Autoincrementable*/
	documento varchar(25) not null , 
    huella varbinary(max) not null,
	FOREIGN KEY (documento) REFERENCES EMPLEADO(documento) --referencia campo documento con la tabla Empleado (documento)
);

CREATE TABLE TIPOMARCACION ( --Creacion tabla tipo de marcacion 
    idTipoMarcacion int PRIMARY KEY ,/*Autoincrementable*/
    tipoMarcacion varchar(25) not null
);
 
CREATE TABLE MARCACION( -- Creacion tabla Marcacion 
    idMarcacion int IDENTITY(1,1),/*Autoincrementable*/
    horaMarcacion time NOT NULL, --**Este dato esta pendiente de si es datetime, date, time , aqui se ingresa la hora
	diaMarcacion date not null, --aqui se ingresa la fecha, solo el dia ejmp 12/10/2020
	idRegistro int not null ,
	tipoMarcacion int, 
	FOREIGN KEY (idRegistro) REFERENCES REGISTRO (idRegistro), --referencia campo idregistro con la tabla registro (idregistro)
	FOREIGN KEY (tipoMarcacion) REFERENCES TIPOMARCACION(idTipoMarcacion), --referencia campo tipoMarcacion con la tabla TIPOMARCACION (idTipoMarcacion)
	primary key (idRegistro,diaMarcacion, tipoMarcacion) --Llave primaria compuesta
);
