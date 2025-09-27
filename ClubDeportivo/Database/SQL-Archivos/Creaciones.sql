-- ======================
-- Crear la base de datos
-- ======================
CREATE DATABASE IF NOT EXISTS club_deportivo;
USE club_deportivo;

-- ======================
-- Tabla base: Persona
-- ======================
CREATE TABLE Persona (
    id_persona INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    dni VARCHAR(8) UNIQUE NOT NULL,
    fecha_nacimiento DATE NOT NULL,                     
    usuario VARCHAR(50) UNIQUE NOT NULL,  
    clave VARCHAR(255) NOT NULL     
);

-- ======================
-- Tabla: Socio
-- ======================
CREATE TABLE Socio (
    id_socio INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    id_persona INT UNSIGNED NOT NULL,
    fechaAlta DATE NOT NULL DEFAULT (CURRENT_DATE),
    tieneCarnet BOOLEAN NOT NULL DEFAULT TRUE,
    fichaMedica BOOLEAN NOT NULL DEFAULT FALSE,
    FOREIGN KEY (id_persona) REFERENCES Persona(id_persona)
        ON DELETE CASCADE
);

-- ======================
-- Tabla: NoSocio
-- ======================
CREATE TABLE NoSocio (
    id_noSocio INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    id_persona INT UNSIGNED NOT NULL,
    FOREIGN KEY (id_persona) REFERENCES Persona(id_persona)
        ON DELETE CASCADE
);

-- ======================
-- Tabla: Cuota
-- ======================
CREATE TABLE Cuota (
    id_cuota INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    id_socio INT UNSIGNED NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    fechaPago DATE NOT NULL,
    fechaVencimiento DATE NOT NULL,
    medioPago ENUM('Efectivo','Tarjeta') NOT NULL,
    promocion ENUM('0','3','6') DEFAULT '0',
    FOREIGN KEY (id_socio) REFERENCES Socio(id_socio)
        ON DELETE CASCADE
);

-- ======================
-- Tabla: Actividad
-- ======================
CREATE TABLE Actividad (
    id_actividad INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    tipo VARCHAR(50) NOT NULL,
    profesor VARCHAR(100) NOT NULL,
    horario DATETIME NOT NULL,
    capacidad INT NOT NULL,
    costo DECIMAL(10,2) NOT NULL
);

-- ======================
-- Tabla: PagoActividad
-- ======================
CREATE TABLE PagoActividad (
    id_pagoActividad INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    id_noSocio INT UNSIGNED NOT NULL,
    id_actividad INT UNSIGNED NOT NULL,
    fecha DATE NOT NULL,
    montoAPagar DECIMAL(10,2) NOT NULL,
    metodoPago ENUM('Efectivo','Tarjeta') NOT NULL,
    FOREIGN KEY (id_noSocio) REFERENCES NoSocio(id_noSocio)
        ON DELETE CASCADE,
    FOREIGN KEY (id_actividad) REFERENCES Actividad(id_actividad)
        ON DELETE CASCADE
);

-- ======================
-- Tabla: Administrador
-- ======================
CREATE TABLE Administrador (
    id_admin INT UNSIGNED AUTO_INCREMENT PRIMARY KEY,
    id_persona INT UNSIGNED NOT NULL,
    FOREIGN KEY (id_persona) REFERENCES Persona(id_persona)
        ON DELETE CASCADE
);

