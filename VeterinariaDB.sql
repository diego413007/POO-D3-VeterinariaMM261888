CREATE DATABASE VeterinariaDB;
GO
USE VeterinariaDB;
GO

CREATE TABLE Especie (
    codigo_especie  INT IDENTITY(1,1) PRIMARY KEY,
    nombre_especie  NVARCHAR(50) NOT NULL
);

CREATE TABLE Raza (
    codigo_raza     INT IDENTITY(1,1) PRIMARY KEY,
    nombre_raza     NVARCHAR(80) NOT NULL,
    tamano          NVARCHAR(20) NULL,
    codigo_especie  INT NOT NULL,
    CONSTRAINT FK_Raza_Especie FOREIGN KEY (codigo_especie)
        REFERENCES Especie(codigo_especie)
);

CREATE TABLE Propietario (
    dui               CHAR(10) PRIMARY KEY,
    nombres           NVARCHAR(80) NOT NULL,
    primer_apellido   NVARCHAR(50) NOT NULL,
    segundo_apellido  NVARCHAR(50) NULL,
    telefono          NVARCHAR(15) NULL,
    direccion         NVARCHAR(150) NULL
);

CREATE TABLE Mascota (
    codigo_mascota   INT IDENTITY(1,1) PRIMARY KEY,
    nombre           NVARCHAR(50) NOT NULL,
    sexo             CHAR(1) NOT NULL CHECK (sexo IN ('M','H')),
    peso_kg           DECIMAL(6,2) NULL,
    fecha_ingreso    DATE NOT NULL DEFAULT GETDATE(),
    codigo_raza      INT NOT NULL,
    dui_propietario  CHAR(10) NOT NULL,
    CONSTRAINT FK_Mascota_Raza FOREIGN KEY (codigo_raza)
        REFERENCES Raza(codigo_raza),
    CONSTRAINT FK_Mascota_Propietario FOREIGN KEY (dui_propietario)
        REFERENCES Propietario(dui)
);
GO

-- Vista para la consulta avanzada
CREATE VIEW vw_MascotaCompleta AS
SELECT m.codigo_mascota, m.nombre AS mascota, m.sexo, m.peso_kg, m.fecha_ingreso,
       r.nombre_raza, e.nombre_especie,
       p.nombres + ' ' + p.primer_apellido AS propietario, p.telefono
FROM Mascota m
JOIN Raza r        ON m.codigo_raza = r.codigo_raza
JOIN Especie e     ON r.codigo_especie = e.codigo_especie
JOIN Propietario p ON m.dui_propietario = p.dui;
GO


-- =============================================
-- INSERCIÓN DE DATOS DE PRUEBA
-- =============================================

-- 1. Especies
INSERT INTO Especie (nombre_especie) VALUES 
('Canino'),
('Felino'),
('Ave');

-- 2. Razas (Asociadas a las especies anteriores: 1=Canino, 2=Felino, 3=Ave)
INSERT INTO Raza (nombre_raza, tamano, codigo_especie) VALUES 
('Labrador Retriever', 'Grande', 1),
('Chihuahua', 'Pequeño', 1),
('Persa', 'Mediano', 2),
('Siamés', 'Mediano', 2),
('Periquito Australiano', 'Pequeño', 3),
('Golden Retriever', 'Grande', 1);

-- 3. Propietarios
INSERT INTO Propietario (dui, nombres, primer_apellido, segundo_apellido, telefono, direccion) VALUES 
('01234567-1', 'Juan Carlos', 'Pérez', 'Gómez', '7890-1234', 'San Salvador'),
('02345678-2', 'María Elena', 'López', 'Martínez', '7123-4567', 'Santa Tecla'),
('03456789-3', 'Carlos Alberto', 'Ramírez', 'Flores', '7987-6543', 'Antiguo Cuscatlán'),
('04567890-4', 'Ana Sofía', 'Hernández', 'Rivas', '7456-7890', 'Soyapango'),
('05678901-5', 'José Luis', 'Martínez', 'Castro', '7321-9876', 'San Salvador'),
('06789012-6', 'Carmen Rosa', 'González', 'Vásquez', '7654-3210', 'Mejicanos'),
('07890123-7', 'Francisco Javier', 'Torres', 'Mejía', '7111-2233', 'Santa Tecla'),
('08901234-8', 'Lucía Beatriz', 'Cruz', 'Sola', '7444-5566', 'San Salvador');

-- 4. Mascotas (8 registros combinando razas y propietarios)
INSERT INTO Mascota (nombre, sexo, peso_kg, fecha_ingreso, codigo_raza, dui_propietario) VALUES 
('Firulais', 'M', 28.50, '2026-01-10', 1, '01234567-1'),
('Kira', 'H', 3.20, '2026-02-15', 2, '02345678-2'),
('Copito', 'M', 4.10, '2026-03-01', 3, '03456789-3'),
('Luna', 'H', 3.80, '2026-03-12', 4, '04567890-4'),
('Piolín', 'M', 0.05, '2026-04-05', 5, '05678901-5'),
('Max', 'M', 32.00, '2026-04-10', 6, '06789012-6'),
('Princesa', 'H', 5.50, '2026-05-02', 3, '07890123-7'),
('Rocky', 'M', 6.20, '2026-05-10', 2, '08901234-8');
GO

-- Prueba rápida para verificar la vista creada
SELECT * FROM vw_MascotaCompleta;
GO