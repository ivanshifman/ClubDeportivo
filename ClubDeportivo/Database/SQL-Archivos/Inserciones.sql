-- ======================
-- Insertar Personas
-- ======================
INSERT INTO Persona (nombre, apellido, dni, fecha_nacimiento, usuario, clave) VALUES
('Juan', 'Pérez', '22345678', '1967-05-15', 'juanp', 'clave123'),
('María', 'Gómez', '87654321', '1985-08-22', 'mariag', 'clave456'),
('Carlos', 'López', '15223344', '1953-12-01', 'carlosl', 'clave789'),
('Lucía', 'Martínez', '44332211', '2002-03-10', 'luciam', 'clave321'),
('Admin', 'Principal', '00000000', '1980-01-01', 'admin', 'adminclave');

-- ======================
-- Insertar Socios
-- ======================
INSERT INTO Socio (id_persona, fechaAlta, tieneCarnet, fichaMedica) VALUES
(1, '2025-09-01', TRUE, TRUE),
(2, '2025-10-01', TRUE, TRUE);

-- ======================
-- Insertar NoSocios
-- ======================
INSERT INTO NoSocio (id_persona) VALUES
(3),
(4);

-- ======================
-- Insertar Administrador
-- ======================
INSERT INTO Administrador (id_persona) VALUES
(5);

-- ======================
-- Insertar Cuotas
-- ======================
INSERT INTO Cuota (id_socio, monto, fechaPago, fechaVencimiento, medioPago, promocion) VALUES
(1, 2000.00, '2025-09-01', '2025-09-30', 'Efectivo', '0'),
(2, 2000.00, '2025-10-01', '2025-10-31', 'Tarjeta', '3');

-- ======================
-- Insertar Actividades
-- ======================
INSERT INTO Actividad (nombre, tipo, profesor, horario, capacidad, costo) VALUES
('Gimnasio', 'Musculación', 'Sánchez', '2025-12-26 10:00:00', 20, 500.00),
('Natación', 'Deporte', 'Ramírez', '2025-12-26 12:00:00', 15, 600.00);

-- ======================
-- Insertar PagoActividad
-- ======================
INSERT INTO PagoActividad (id_noSocio, id_actividad, fecha, montoAPagar, metodoPago) VALUES
(1, 1, '2025-10-02', 500.00, 'Efectivo'),
(2, 2, '2025-10-02', 600.00, 'Tarjeta');
