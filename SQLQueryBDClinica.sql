USE MASTER
GO 

--DROP DATABASE [BDClinica]

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
    Estado BIT NOT NULL DEFAULT 1,

    CONSTRAINT PK_PACIENTE PRIMARY KEY (DNI),
    CONSTRAINT FK_PACIENTE_PROVINCIA FOREIGN KEY (IdProvincia) REFERENCES PROVINCIA(IdProvincia),
    CONSTRAINT FK_PACIENTE_LOCALIDAD FOREIGN KEY (IdLocalidad) REFERENCES Localidad(IdLocalidad)
);


CREATE TABLE ESPECIALIDAD(
    IdEspecialidad INT,
    Nombre VARCHAR(100) NOT NULL,

    CONSTRAINT PK_ESPECIALIDAD PRIMARY KEY (IdEspecialidad)
);

CREATE TABLE MEDICO (
    Legajo INT NOT NULL,
    DNI CHAR(8) NOT NULL UNIQUE,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Sexo CHAR(1),
    Nacionalidad VARCHAR(50),
    FechaNacimiento DATE,
    Direccion VARCHAR(100),
    IdLocalidad INT NOT NULL,
    IdProvincia INT NOT NULL,
    CorreoElectronico VARCHAR(100),
    Telefono VARCHAR(20),
    IdEspecialidad INT NOT NULL,
    DiasAtencion VARCHAR(100) NOT NULL,
    HorarioAtencion VARCHAR(100) NOT NULL,
    IdUsuario INT NULL,
    Estado BIT NOT NULL DEFAULT 1,

    CONSTRAINT PK_MEDICO PRIMARY KEY (Legajo),
    CONSTRAINT FK_MEDICO_LOCALIDAD FOREIGN KEY (IdLocalidad) REFERENCES LOCALIDAD (IdLocalidad),
    CONSTRAINT FK_MEDICO_PROVINCIA FOREIGN KEY (IdProvincia) REFERENCES PROVINCIA (IdProvincia),
    CONSTRAINT FK_MEDICO_ESPECIALIDAD FOREIGN KEY (IdEspecialidad) REFERENCES ESPECIALIDAD (IdEspecialidad),
    CONSTRAINT FK_MEDICO_USUARIO FOREIGN KEY (IdUsuario) REFERENCES USUARIO (IdUsuario)
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
SELECT 1,'La Plata',1 UNION
SELECT 2,'Mar del Plata',1 UNION
SELECT 3,'Bahía Blanca',1 UNION
SELECT 4,'Tandil',1 UNION
SELECT 5,'Olavarría',1 UNION
SELECT 6,'Pergamino',1 UNION
SELECT 7,'Quilmes',1 UNION
SELECT 8,'San Nicolás',1 UNION

SELECT 9,'Catamarca',2 UNION
SELECT 10,'Belén',2 UNION
SELECT 11,'Andalgalá',2 UNION
SELECT 12,'Tinogasta',2 UNION
SELECT 13,'Santa María',2 UNION
SELECT 14,'Recreo',2 UNION
SELECT 15,'Fiambalá',2 UNION
SELECT 16,'Pomán',2 UNION

SELECT 17,'Resistencia',3 UNION
SELECT 18,'Barranqueras',3 UNION
SELECT 19,'Presidencia Roque Sáenz Peña',3 UNION
SELECT 20,'Villa Ángela',3 UNION
SELECT 21,'Charata',3 UNION
SELECT 22,'General San Martín',3 UNION
SELECT 23,'Las Breñas',3 UNION
SELECT 24,'Quitilipi',3 UNION

SELECT 25,'Comodoro Rivadavia',4 UNION
SELECT 26,'Puerto Madryn',4 UNION
SELECT 27,'Trelew',4 UNION
SELECT 28,'Rawson',4 UNION
SELECT 29,'Esquel',4 UNION
SELECT 30,'Sarmiento',4 UNION
SELECT 31,'Gaiman',4 UNION
SELECT 32,'Dolavon',4 UNION

SELECT 33,'Ciudad de Buenos Aires',5 UNION
SELECT 34,'Palermo',5 UNION
SELECT 35,'Recoleta',5 UNION
SELECT 36,'Caballito',5 UNION
SELECT 37,'Belgrano',5 UNION
SELECT 38,'Flores',5 UNION
SELECT 39,'Villa Urquiza',5 UNION
SELECT 40,'Boedo',5 UNION

SELECT 41,'Córdoba',6 UNION
SELECT 42,'Villa Carlos Paz',6 UNION
SELECT 43,'Río Cuarto',6 UNION
SELECT 44,'Villa María',6 UNION
SELECT 45,'Alta Gracia',6 UNION
SELECT 46,'Jesús María',6 UNION
SELECT 47,'Bell Ville',6 UNION
SELECT 48,'Cosquín',6 UNION

SELECT 49,'Corrientes',7 UNION
SELECT 50,'Goya',7 UNION
SELECT 51,'Paso de los Libres',7 UNION
SELECT 52,'Mercedes',7 UNION
SELECT 53,'Curuzú Cuatiá',7 UNION
SELECT 54,'Santo Tomé',7 UNION
SELECT 55,'Bella Vista',7 UNION
SELECT 56,'Ituzaingó',7 UNION

SELECT 57,'Paraná',8 UNION
SELECT 58,'Concordia',8 UNION
SELECT 59,'Gualeguaychú',8 UNION
SELECT 60,'Concepción del Uruguay',8 UNION
SELECT 61,'Victoria',8 UNION
SELECT 62,'La Paz',8 UNION
SELECT 63,'Nogoyá',8 UNION
SELECT 64,'Colón',8 UNION

SELECT 65,'Formosa',9 UNION
SELECT 66,'Clorinda',9 UNION
SELECT 67,'Pirané',9 UNION
SELECT 68,'El Colorado',9 UNION
SELECT 69,'Ingeniero Juárez',9 UNION
SELECT 70,'Las Lomitas',9 UNION
SELECT 71,'Ibarreta',9 UNION
SELECT 72,'Comandante Fontana',9 UNION

SELECT 73,'San Salvador de Jujuy',10 UNION
SELECT 74,'Palpalá',10 UNION
SELECT 75,'Perico',10 UNION
SELECT 76,'Libertador General San Martín',10 UNION
SELECT 77,'Humahuaca',10 UNION
SELECT 78,'Tilcara',10 UNION
SELECT 79,'La Quiaca',10 UNION
SELECT 80,'San Pedro de Jujuy',10 UNION

SELECT 81,'Santa Rosa',11 UNION
SELECT 82,'General Pico',11 UNION
SELECT 83,'Toay',11 UNION
SELECT 84,'Eduardo Castex',11 UNION
SELECT 85,'Realicó',11 UNION
SELECT 86,'Victorica',11 UNION
SELECT 87,'General Acha',11 UNION
SELECT 88,'Macachín',11 UNION

SELECT 89,'Chilecito',12 UNION
SELECT 90,'La Rioja',12 UNION
SELECT 91,'Aimogasta',12 UNION
SELECT 92,'Chamical',12 UNION
SELECT 93,'Chepes',12 UNION
SELECT 94,'Famatina',12 UNION
SELECT 95,'Villa Unión',12 UNION
SELECT 96,'Olta',12 UNION

SELECT 97,'Mendoza',13 UNION
SELECT 98,'Godoy Cruz',13 UNION
SELECT 99,'Guaymallén',13 UNION
SELECT 100,'Maipú',13 UNION
SELECT 101,'San Rafael',13 UNION
SELECT 102,'Tunuyán',13 UNION
SELECT 103,'Luján de Cuyo',13 UNION
SELECT 104,'General Alvear',13 UNION

SELECT 105,'Posadas',14 UNION
SELECT 106,'Oberá',14 UNION
SELECT 107,'Eldorado',14 UNION
SELECT 108,'Puerto Iguazú',14 UNION
SELECT 109,'Leandro N. Alem',14 UNION
SELECT 110,'Apóstoles',14 UNION
SELECT 111,'Montecarlo',14 UNION
SELECT 112,'San Vicente',14 UNION

SELECT 113,'Neuquén',15 UNION
SELECT 114,'Cutral Có',15 UNION
SELECT 115,'Plottier',15 UNION
SELECT 116,'Centenario',15 UNION
SELECT 117,'Zapala',15 UNION
SELECT 118,'San Martín de los Andes',15 UNION
SELECT 119,'Villa La Angostura',15 UNION
SELECT 120,'Chos Malal',15 UNION

SELECT 121,'Viedma',16 UNION
SELECT 122,'San Carlos de Bariloche',16 UNION
SELECT 123,'General Roca',16 UNION
SELECT 124,'Cipolletti',16 UNION
SELECT 125,'Allen',16 UNION
SELECT 126,'El Bolsón',16 UNION
SELECT 127,'Choele Choel',16 UNION
SELECT 128,'Villa Regina',16 UNION

SELECT 129,'San Juan',18 UNION
SELECT 130,'Rawson',18 UNION
SELECT 131,'Rivadavia',18 UNION
SELECT 132,'Pocito',18 UNION
SELECT 133,'Caucete',18 UNION
SELECT 134,'Jáchal',18 UNION
SELECT 135,'Albardón',18 UNION
SELECT 136,'Santa Lucía',18 UNION

SELECT 137,'San Luis',19 UNION
SELECT 138,'Villa Mercedes',19 UNION
SELECT 139,'Merlo',19 UNION
SELECT 140,'La Punta',19 UNION
SELECT 141,'Juana Koslay',19 UNION
SELECT 142,'Quines',19 UNION
SELECT 143,'Naschel',19 UNION
SELECT 144,'Tilisarao',19 UNION

SELECT 145,'La Rioja',12 UNION
SELECT 146,'Chilecito',12 UNION
SELECT 147,'Aimogasta',12 UNION
SELECT 148,'Chamical',12 UNION
SELECT 149,'Chepes',12 UNION
SELECT 150,'Famatina',12 UNION
SELECT 151,'Villa Unión',12 UNION
SELECT 152,'Olta',12 UNION

SELECT 153,'Santa Rosa',11 UNION
SELECT 154,'General Pico',11 UNION
SELECT 155,'Toay',11 UNION
SELECT 156,'Eduardo Castex',11 UNION
SELECT 157,'Realicó',11 UNION
SELECT 158,'Victorica',11 UNION
SELECT 159,'General Acha',11 UNION
SELECT 160,'Macachín',11 UNION

SELECT 161,'Río Gallegos',20 UNION
SELECT 162,'Caleta Olivia',20 UNION
SELECT 163,'El Calafate',20 UNION
SELECT 164,'Puerto Deseado',20 UNION
SELECT 165,'Pico Truncado',20 UNION
SELECT 166,'Las Heras',20 UNION
SELECT 167,'Puerto San Julián',20 UNION
SELECT 168,'28 de Noviembre',20 UNION

SELECT 169,'Ushuaia',23 UNION
SELECT 170,'Río Grande',23 UNION
SELECT 171,'Tolhuin',23 UNION
SELECT 172,'San Sebastián',23 UNION
SELECT 173,'Lago Escondido',23 UNION
SELECT 174,'Puerto Almanza',23 UNION
SELECT 175,'Radman',23 UNION
SELECT 176,'Moat',23 UNION

SELECT 177,'San Fernando del Valle de Catamarca',2 UNION
SELECT 178,'Belén',2 UNION
SELECT 179,'Andalgalá',2 UNION
SELECT 180,'Tinogasta',2 UNION
SELECT 181,'Santa María',2 UNION
SELECT 182,'Recreo',2 UNION
SELECT 183,'Fiambalá',2 UNION
SELECT 184,'Pomán',2 UNION

SELECT 185,'Ciudad de Buenos Aires',5 UNION
SELECT 186,'Palermo',5 UNION
SELECT 187,'Recoleta',5 UNION
SELECT 188,'Caballito',5 UNION
SELECT 189,'Belgrano',5 UNION
SELECT 190,'Flores',5 UNION
SELECT 191,'Villa Urquiza',5 UNION
SELECT 192,'Boedo',5;

INSERT INTO ESPECIALIDAD (IdEspecialidad, Nombre)
SELECT 1, 'Clinica Medica' UNION
SELECT 2, 'Pediatria' UNION
SELECT 3, 'Cardiologia' UNION
SELECT 4, 'Dermatologia' UNION
SELECT 5, 'Traumatologia' UNION
SELECT 6, 'Ginecologia';
GO

INSERT INTO PACIENTE(DNI, Nombre, Apellido, Sexo, Nacionalidad, FechaNacimiento, Direccion, CorreoElectronico, Telefono, IdProvincia,IdLocalidad)
SELECT '42419605','Lautaro', 'Gimenez','M','Argentina','2000-02-07','Ayacucho 81','lautaromail@gmail.com','1182729098',1 ,5 UNION
SELECT '12345678', 'Santiago', 'Burgos', 'M', 'Argentina', '1995-08-15', 'Av. Rivadavia 1234', 'santib@gmail.com', '1122334455',1 ,1 UNION
SELECT '23456789', 'Maria', 'Gomez', 'F', 'Argentina', '2000-03-20', 'San Martin 567', 'maria.gomez@gmail.com', '1166778899',1 ,2 UNION
SELECT '34567890', 'Franco', 'Casamento', 'M', 'Uruguay', '1988-11-10', 'Belgrano 890', 'carlos.lopez@gmail.com', '1177889900',1 ,3 UNION
SELECT '45678901', 'Ana', 'Martinez', 'F', 'Argentina', '1992-05-14', 'Mitre 456', 'ana.martinez@gmail.com', '1191112233', 1, 4 UNION
SELECT '56789012', 'Elian', 'Maspero', 'M', 'Argentina', '1985-09-22', 'Sarmiento 789', 'pedro.fernandez@gmail.com', '1192223344', 1, 5 UNION
SELECT '67890123', 'Lucia', 'Rodriguez', 'F', 'Argentina', '1998-12-03', 'Moreno 321', 'lucia.rodriguez@gmail.com', '1193334455', 1, 6 UNION
SELECT '78901234', 'Guillermo', 'Maydana', 'M', 'Chile', '1991-07-18', 'Lavalle 654', 'diego.suarez@gmail.com', '1194445566', 1, 7 UNION
SELECT '89012345', 'Sofia', 'Ramirez', 'F', 'Argentina', '2001-04-27', 'Brown 987', 'sofia.ramirez@gmail.com', '1195556677', 1, 8 UNION
SELECT '90123456', 'Martin', 'Torres', 'M', 'Argentina', '1987-10-09', 'Italia 111', 'martin.torres@gmail.com', '1196667788', 2, 9 UNION
SELECT '91234567', 'Valentina', 'Castro', 'F', 'Argentina', '1999-06-12', 'España 222', 'valentina.castro@gmail.com', '1197778899', 2, 10 UNION
SELECT '92345678', 'Nicolas', 'Ruiz', 'M', 'Paraguay', '1994-01-25', 'Chile 333', 'nicolas.ruiz@gmail.com', '1198889900', 2, 11 UNION
SELECT '93456789', 'Camila', 'Silva', 'F', 'Argentina', '1997-08-30', 'Perú 444', 'camila.silva@gmail.com', '1199990011', 2, 12 UNION
SELECT '94567890', 'Javier', 'Morales', 'M', 'Argentina', '1983-03-05', 'Urquiza 555', 'javier.morales@gmail.com', '1100011122', 3, 17 UNION
SELECT '95678901', 'Florencia', 'Herrera', 'F', 'Argentina', '2002-11-19', 'Pellegrini 666', 'florencia.herrera@gmail.com', '1101122233', 3, 18 UNION
SELECT '96789012', 'Fernando', 'Acosta', 'M', 'Argentina', '1990-02-14', 'Maipú 777', 'fernando.acosta@gmail.com', '1102233344', 3, 19 UNION
SELECT '97890123', 'Julieta', 'Vega', 'F', 'Bolivia', '1996-09-07', 'Las Heras 888', 'julieta.vega@gmail.com', '1103344455', 3, 20 UNION
SELECT '98901234', 'Gonzalo', 'Navarro', 'M', 'Argentina', '1989-12-21', 'Colón 999', 'gonzalo.navarro@gmail.com', '1104455566', 4, 25 UNION
SELECT '99012345', 'Brenda', 'Rojas', 'F', 'Argentina', '2003-07-11', 'Alem 123', 'brenda.rojas@gmail.com', '1105566677', 4, 26;
GO

INSERT INTO USUARIO (NombreUsuario,Contrasena,TipoUsuario)
SELECT 'admin','1234','Administrador' UNION
SELECT 'lautaro','1111','Medico' UNION
SELECT 'guille','2222','Administrador' UNION
SELECT 'elian','4444','Medico' UNION
SELECT 'santi','5555','Administrador' UNION
SELECT 'fran','6666','Medico';
GO

INSERT INTO MEDICO (Legajo, DNI, Nombre, Apellido, Sexo, Nacionalidad, FechaNacimiento, Direccion, IdLocalidad, IdProvincia, CorreoElectronico, Telefono, IdEspecialidad, DiasAtencion, HorarioAtencion, IdUsuario)
SELECT 1001, '30111222', 'Laura', 'Fernandez', 'F', 'Argentina', '1980-05-12', 'San Martin 123', 1, 1, 'laura.fernandez@gmail.com', '1160011122', 1, 'Lunes-Miercoles', '08:00-14:00', NULL UNION
SELECT 1002, '28999888', 'Lautaro', 'Mendez', 'M', 'Argentina', '1975-09-03', 'Belgrano 456', 2, 1, 'carlos.mendez@gmail.com', '1160022233', 2, 'Martes-Jueves', '14:00-20:00', NULL UNION
SELECT 1003, '31222333', 'Sofia', 'Gomez', 'F', 'Argentina', '1988-11-20', 'Rivadavia 789', 3, 2, 'sofia.gomez@gmail.com', '1160033344', 3, 'Lunes-Viernes', '09:00-13:00', NULL UNION
SELECT 1004, '29888777', 'Elian', 'Ramirez', 'M', 'Argentina', '1979-02-15', 'Mitre 321', 4, 2, 'jorge.ramirez@gmail.com', '1160044455', 1, 'Lunes-Miercoles-Viernes', '15:00-19:00', NULL UNION
SELECT 1005, '32555666', 'Valeria', 'Torres', 'F', 'Argentina', '1990-07-08', 'Italia 654', 5, 3, 'valeria.torres@gmail.com', '1160055566', 4, 'Martes-Jueves', '10:00-16:00', NULL UNION
SELECT 1006, '27777444', 'Franco', 'Sanchez', 'M', 'Argentina', '1972-12-01', 'Urquiza 987', 6, 3, 'diego.sanchez@gmail.com', '1160066677', 2, 'Lunes-Viernes', '08:00-12:00', NULL;
GO

CREATE PROCEDURE SP_AgregarPaciente
    @dni CHAR(8),
    @nombre VARCHAR(50),
    @apellido VARCHAR(50),
    @sexo CHAR(1),
    @nacionalidad VARCHAR(50),
    @fecha DATE,
    @direccion VARCHAR(100),
    @correo VARCHAR(100),
    @telefono VARCHAR(20),
    @provincia INT,
    @localidad INT
AS
BEGIN
    INSERT INTO PACIENTE
    (
        DNI, Nombre, Apellido, Sexo, Nacionalidad, FechaNacimiento,
        Direccion, CorreoElectronico, Telefono, IdProvincia, IdLocalidad, Estado
    )
    VALUES
    (
        @dni, @nombre, @apellido, @sexo, @nacionalidad, @fecha,
        @direccion, @correo, @telefono, @provincia, @localidad, 1
    )
END
GO

CREATE PROCEDURE SP_AgregarMedico
    @legajo INT,
    @dni CHAR(8),
    @nombre VARCHAR(50),
    @apellido VARCHAR(50),
    @sexo CHAR(1),
    @nacionalidad VARCHAR(50),
    @fecha DATE,
    @direccion VARCHAR(100),
    @idLocalidad INT,
    @idProvincia INT,
    @correo VARCHAR(100),
    @telefono VARCHAR(20),
    @idEspecialidad INT,
    @diasAtencion VARCHAR(100),
    @horarioAtencion VARCHAR(100),
    @idUsuario INT = NULL
AS
BEGIN
    INSERT INTO MEDICO
    (
        Legajo, DNI, Nombre, Apellido, Sexo, Nacionalidad, FechaNacimiento,
        Direccion, IdLocalidad, IdProvincia, CorreoElectronico, Telefono,
        IdEspecialidad, DiasAtencion, HorarioAtencion, IdUsuario, Estado
    )
    VALUES
    (
        @legajo, @dni, @nombre, @apellido, @sexo, @nacionalidad, @fecha,
        @direccion, @idLocalidad, @idProvincia, @correo, @telefono,
        @idEspecialidad, @diasAtencion, @horarioAtencion, @idUsuario, 1
    )
END
GO
CREATE TABLE TURNO (
    IdTurno       INT IDENTITY(1,1),
    Legajo        INT      NOT NULL,
    DNI           CHAR(8)  NOT NULL,
    Fecha         DATE     NOT NULL,
    HorarioInicio INT      NOT NULL,
    Asistencia    BIT      NULL,
    Observacion   VARCHAR(500) NULL,
    Estado        BIT      NOT NULL DEFAULT 1,

    CONSTRAINT PK_TURNO          PRIMARY KEY (IdTurno),
    CONSTRAINT FK_TURNO_MEDICO   FOREIGN KEY (Legajo) REFERENCES MEDICO(Legajo),
    CONSTRAINT FK_TURNO_PACIENTE FOREIGN KEY (DNI)    REFERENCES PACIENTE(DNI)
);
GO

CREATE PROCEDURE SP_AgregarTurno
    @legajo        INT,
    @dni           CHAR(8),
    @fecha         DATE,
    @horarioInicio INT
AS
BEGIN
    INSERT INTO TURNO (Legajo, DNI, Fecha, HorarioInicio, Estado)
    VALUES (@legajo, @dni, @fecha, @horarioInicio, 1)
END
GO