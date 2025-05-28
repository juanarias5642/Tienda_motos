create database db_Tienda_motosyamamotos
GO
use db_Tienda_motosyamamotos;
GO

create table Personas(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
	[Apellido] NVARCHAR(50) NOT NULL,
	[Cedula] NVARCHAR(50) NOT NULL,
);

create table Chasises(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
	[Peso] INT NOT NULL,
);

create table Tipos(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
	[Alta_gama] BIT NOT NULL,
);

create table Referencias(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
	[Anio_lanzamiento] int NOT NULL,
);

create table Marcas(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
	[Pais_origen] NVARCHAR(50) NOT NULL,
);

create table Facturas(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Cod_factura] NVARCHAR(50) UNIQUE NOT NULL,
	[Persona] INT NOT NULL,
	[Fecha] SMALLDATETIME NOT NULL,
	[Total] DECIMAL (10,2) NOT NULL,
	FOREIGN KEY (Persona) REFERENCES Personas(Id) ON DELETE CASCADE
);

create table Motocicletas(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Cod_moto] NVARCHAR(50) UNIQUE NOT NULL,
	[Modelo] VARCHAR(100) NOT NULL,
	[Color] VARCHAR(100) NOT NULL,
	[Cilindraje] INT NOT NULL,
	[Precio] DECIMAL (10,2) NOT NULL,
	[Chasis] INT NOT NULL,
	[Marca] INT NOT NULL,
	[Referencia] INT NOT NULL,
	[Tipo] INT NOT NULL,
	[ImagenUrl] NVARCHAR(100)  NULL,
	FOREIGN KEY (Chasis) REFERENCES Chasises(Id) ,
	FOREIGN KEY (Marca) REFERENCES Marcas(Id) ,
	FOREIGN KEY (Referencia) REFERENCES Referencias(Id) ,
	FOREIGN KEY (Tipo) REFERENCES Tipos(Id) 
);

create table Fact_motos(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Codigo] NVARCHAR(50) UNIQUE NOT NULL,
	[Factura] INT NOT NULL,
	[Moto] INT NOT NULL,
	[Cantidad] NVARCHAR NOT NULL,
	[Precio] DECIMAL (10,2) NOT NULL,
	[Iva] DECIMAL (10,2) NOT NULL,
	[Total] DECIMAL (10,2) NOT NULL,
	FOREIGN KEY (Factura) REFERENCES Facturas(Id) ON DELETE CASCADE,
	FOREIGN KEY (Moto) REFERENCES Motocicletas(Id) ON DELETE CASCADE
);

CREATE TABLE [Auditorias] (
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[Usuario] NVARCHAR (50),
	[Entidad] NVARCHAR (50),
	[Operacion] NVARCHAR (50),
	[Datos] NVARCHAR (250),
	[Fecha] DATETIME 
);

INSERT INTO [Personas] ([Nombre],[Apellido],[Cedula])
VALUES ('anderson','jimenez','102549');

INSERT INTO [Facturas] ([Cod_factura],[Persona],[Fecha],[Total])
VALUES ('F003',1,GETDATE(),15000.00);

INSERT INTO [Chasises] ([Nombre],[Peso])
VALUES ('BVN423JM',158);

INSERT INTO [Tipos] ([Nombre],[Alta_gama])
VALUES ('enduro',1);

INSERT INTO [Referencias] ([Nombre],[Anio_lanzamiento])
VALUES ('benelli 900',2022);

INSERT INTO [Marcas] ([Nombre],[Pais_origen])
VALUES ('Benelli','Italia');

INSERT INTO [Motocicletas] ([Cod_moto],[Modelo],[Color],[Cilindraje],[Precio],[Chasis],[Marca],[Referencia],[Tipo],[ImagenUrl])
VALUES ('m1','2023','negro',450,15000.00,1,1,1,1,NULL);

INSERT INTO [Fact_motos] ([Codigo],[Factura],[Moto],[Precio],[Iva],[Total],[Cantidad])
VALUES ('gh123',3,2,15000.00,5000,20000,1);

SELECT *FROM [Personas];
SELECT *FROM [Facturas];
SELECT *FROM [Chasises];
SELECT *FROM [Tipos];
SELECT *FROM [Referencias];
SELECT *FROM [Marcas];
SELECT *FROM [Motocicletas];
SELECT *FROM[Fact_motos];

SELECT *FROM[Auditorias];

ALTER TABLE Fact_motos
ALTER COLUMN Cantidad INT;