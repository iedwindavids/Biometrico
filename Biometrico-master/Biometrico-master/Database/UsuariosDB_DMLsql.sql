use UsuariosDB; /* uso db */

/* INSERCIONES TIPO ENTRADA */ 
INSERT INTO TIPOMARCACION (idTipoMarcacion, tipoMarcacion) values (1, 'Entrada Tienda');
INSERT INTO TIPOMARCACION (idTipoMarcacion, tipoMarcacion) values (2, 'Entrada Almuerzo');
INSERT INTO TIPOMARCACION (idTipoMarcacion, tipoMarcacion) values (3, 'Salida Almuerzo');
INSERT INTO TIPOMARCACION (idTipoMarcacion, tipoMarcacion) values (4, 'Salida Tienda');


/* procedimientos almacenados*/
create procedure mostrarRegistros
 as 
SELECT REG.documento,EM.nombre,EM.apellido,TM.tipoMarcacion,MAR.horaMarcacion,MAR.diaMarcacion
FROM MARCACION MAR,REGISTRO REG, TIPOMARCACION TM,EMPLEADO EM WHERE 
REG.idRegistro = MAR.idRegistro AND
EM.DOCUMENTO = REG.DOCUMENTO AND
TM.idTipoMarcacion = MAR.tipoMarcacion AND
MAR.diaMarcacion >= dateadd(day,-1,getdate())

execute mostrarRegistros;

/*INSERCION MANUAL para prueba*/

/*
INSERT INTO EMPLEADO (documento, nombre, apellido) values (1024581946, 'EDWIN DAVID','PALOMINO HERNANDEZ');
INSERT INTO MARCACION (horaMarcacion,diaMarcacion,idRegistro,tipoMarcacion) values (CONVERT (time, CURRENT_TIMESTAMP), CONVERT (date, CURRENT_TIMESTAMP) ,1,4);

select *from EMPLEADO where documento like '%1024581946%';

SELECT *FROM EMPLEADO;
select *from MARCACION;

*/
