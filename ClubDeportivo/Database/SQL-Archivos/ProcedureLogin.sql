
/* se cambia el delimitador de linea para poder almacenar en
el sistema gestor el código del procedimiento
Se puede utilizar cualquier caracater 
*************************************************   */

delimiter //  
create procedure IngresoLogin(in Usu varchar(50),in Pass varchar(255))

/* =============================================================================
Se colocan dos parametros de entrada por eso son in
uno para el nombre de usuario y el otro para la contraseña
observar que la longitud debe ser igual que la longitud del atributo de la tabla
===================================================================================  */
begin
  /* proyecto en la consulta el rol que tiene el usuario que ingresa */
  
	SELECT p.id_persona
		FROM persona p
			INNER JOIN socio s ON s.id_persona = p.id_persona
		where p.usuario = Usu and p.clave = Pass
	UNION
	SELECT p.id_persona
		FROM persona p
			INNER JOIN nosocio n ON n.id_persona = p.id_persona
		where p.usuario = Usu and p.clave = Pass;/* se compara con los parametros */
end 
//

/* ==========================
si queremos probar el procedure se usa call
====================================================== */

call IngresoLogin('dato1', 'dato2')//

/* ===============================
si los datos de los parametros existen la consulta arroja 1 FILA
si los datos de los parametros NO EXISTEN la consulta arroja 0 FILAS
============================================================================= */