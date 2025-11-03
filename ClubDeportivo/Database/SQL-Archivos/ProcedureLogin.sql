DELIMITER //
CREATE PROCEDURE IngresoLogin(IN Usu VARCHAR(50))
BEGIN
    SELECT p.id_persona, 'Administrador' AS rol, p.clave
    FROM persona p
    INNER JOIN Administrador a ON a.id_persona = p.id_persona
    WHERE p.usuario = Usu

    UNION

    SELECT p.id_persona, 'Socio' AS rol, p.clave
    FROM persona p
    INNER JOIN Socio s ON s.id_persona = p.id_persona
    WHERE p.usuario = Usu

    UNION

    SELECT p.id_persona, 'NoSocio' AS rol, p.clave
    FROM persona p
    INNER JOIN NoSocio n ON n.id_persona = p.id_persona
    WHERE p.usuario = Usu

    ORDER BY FIELD(rol, 'Administrador','Socio','NoSocio')
    LIMIT 1;
END //
DELIMITER ;
