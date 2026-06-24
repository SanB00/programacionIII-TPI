USE MASTER
GO 
-- DROP DATABASE [BDClinica]

CREATE DATABASE [BDClinica]
GO

USE BDClinica
GO

CREATE TABLE PROVINCIA (
    IdProvincia INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,

    CONSTRAINT PK_PROVINCIA PRIMARY KEY (IdProvincia)
);
GO

CREATE TABLE LOCALIDAD (
    IdLocalidad INT NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    IdProvincia INT NOT NULL,
    
    CONSTRAINT PK_LOCALIDAD PRIMARY KEY (IdLocalidad),
    CONSTRAINT FK_LOCALIDAD FOREIGN KEY (IdProvincia) REFERENCES PROVINCIA (IdProvincia)
);

CREATE TABLE USUARIO(
    IdUsuario INT IDENTITY(1,1),
    NombreUsuario VARCHAR(50) NOT NULL UNIQUE,
    Contrasena VARCHAR(8) NOT NULL,
    TipoUsuario VARCHAR(20) NOT NULL,

    CONSTRAINT PK_USUARIO PRIMARY KEY (IdUsuario)
);

CREATE TABLE PACIENTE(
    DNI CHAR(8),
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Sexo CHAR(1),
    Nacionalidad VARCHAR(50),
    FechaNacimiento DATE,
    Direccion VARCHAR(100),
    CorreoElectronico VARCHAR(100),
    Telefono VARCHAR(20),
    IdProvincia INT NOT NULL,
    IdLocalidad INT NOT NULL,

    CONSTRAINT PK_PACIENTE PRIMARY KEY (DNI),
    CONSTRAINT FK_PACIENTE_PROVINCIA FOREIGN KEY (IdProvincia) REFERENCES PROVINCIA(IdProvincia),
    CONSTRAINT FK_PACIENTE_LOCALIDAD FOREIGN KEY (IdLocalidad) REFERENCES Localidad(IdLocalidad)
);


CREATE TABLE ESPECIALIDAD(
    IdEspecialidad INT,
    Nombre VARCHAR(100) NOT NULL,

    CONSTRAINT PK_ESPECIALIDAD PRIMARY KEY (IdEspecialidad)
);

CREATE TABLE MEDICO(
    Legajo INT,
    DNI CHAR(8) NOT NULL UNIQUE,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Sexo CHAR(1),
    Nacionalidad VARCHAR(50),
    FechaNacimiento DATE,
    Direccion VARCHAR(100),
    CorreoElectronico VARCHAR(100),
    Telefono VARCHAR(20),

    IdLocalidad INT NOT NULL,
    IdEspecialidad INT NOT NULL,
    IdUsuario INT UNIQUE,

    CONSTRAINT PK_MEDICO PRIMARY KEY (Legajo),
    CONSTRAINT FK_MEDICO_LOCALIDAD FOREIGN KEY (IdLocalidad) REFERENCES Localidad(IdLocalidad),
    CONSTRAINT FK_MEDICO_ESPECIALIDAD FOREIGN KEY (IdEspecialidad) REFERENCES Especialidad(IdEspecialidad),
    CONSTRAINT FK_MEDICO_IDUSUARIO FOREIGN KEY (IdUsuario)  REFERENCES Usuario(IdUsuario)
);


INSERT INTO PROVINCIA (IdProvincia, Nombre) 
SELECT 1 ,'Buenos Aires' UNION
SELECT 2, 'Catamarca' UNION
SELECT 3, 'Chaco' UNION
SELECT 4, 'Chubut' UNION
SELECT 5, 'Ciudad Autónoma de Buenos Aires' UNION
SELECT 6, 'Córdoba' UNION
SELECT 7, 'Corrientes' UNION
SELECT 8, 'Entre Ríos' UNION
SELECT 9, 'Formosa' UNION
SELECT 10, 'Jujuy' UNION
SELECT 11, 'La Pampa' UNION
SELECT 12, 'La Rioja' UNION
SELECT 13, 'Mendoza' UNION
SELECT 14, 'Misiones' UNION
SELECT 15, 'Neuquén' UNION
SELECT 16, 'Río Negro' UNION
SELECT 17, 'Salta' UNION
SELECT 18, 'San Juan' UNION
SELECT 19, 'San Luis' UNION
SELECT 20, 'Santa Cruz' UNION
SELECT 21, 'Santa Fe' UNION
SELECT 22, 'Santiago del Estero' UNION
SELECT 23, 'Tierra del Fuego' UNION
SELECT 24, 'Tucumán';
GO

INSERT INTO LOCALIDAD (IdLocalidad, Nombre, IdProvincia)
SELECT 1, 'Don Torcuato', 1 UNION
SELECT 2, 'Tigre', 1 UNION
SELECT 3, 'San Fernando', 1 UNION
SELECT 4, 'San Isidro', 1 UNION
SELECT 5, 'Vicente López', 1 UNION
SELECT 6, 'La Plata', 1 UNION
SELECT 7, 'Mar del Plata', 1 UNION
SELECT 8, 'Palermo', 5 UNION
SELECT 9, 'Recoleta', 5 UNION
SELECT 10, 'Belgrano', 5 UNION
SELECT 11, 'Córdoba Capital', 6 UNION
SELECT 12, 'Río Cuarto', 6;
GO

INSERT INTO PACIENTE(DNI, Nombre, Apellido, Sexo, Nacionalidad, FechaNacimiento, Direccion, CorreoElectronico, Telefono, IdProvincia,IdLocalidad)
SELECT '42419605','Lautaro', 'Gimenez','M','Argentina','2000-02-07','Ayacucho 81','lautaromail@gmail.com','1182729098',1 ,5 UNION
SELECT '12345678', 'Juan', 'Perez', 'M', 'Argentina', '1995-08-15', 'Av. Rivadavia 1234', 'juan.perez@gmail.com', '1122334455',1 ,1 UNION
SELECT '23456789', 'Maria', 'Gomez', 'F', 'Argentina', '2000-03-20', 'San Martin 567', 'maria.gomez@gmail.com', '1166778899',1 ,2 UNION
SELECT '34567890', 'Carlos', 'Lopez', 'M', 'Uruguay', '1988-11-10', 'Belgrano 890', 'carlos.lopez@gmail.com', '1177889900',1 ,3;
GO
