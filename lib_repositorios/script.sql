create database db_Tienda_motos
GO
use db_Tienda_motos

create table Personas(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nombre] NVARCHAR(50) NOT NULL,
	[Apellido] NVARCHAR(50) NOT NULL,
	[Codigo] NVARCHAR(50) NOT NULL,
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
	[Modelo] VARCHAR(100) NOT NULL,
	[Color] VARCHAR(100) NOT NULL,
	[Cilindraje] INT NOT NULL,
	[Precio] DECIMAL (10,2) NOT NULL,
	[Chasis] INT NOT NULL,
	[Marca] INT NOT NULL,
	[Referencia] INT NOT NULL,
	[Tipo] INT NOT NULL,
	FOREIGN KEY (Chasis) REFERENCES Chasises(Id) ON DELETE CASCADE,
	FOREIGN KEY (Marca) REFERENCES Marcas(Id) ON DELETE CASCADE,
	FOREIGN KEY (Referencia) REFERENCES Referencias(Id) ON DELETE CASCADE,
	FOREIGN KEY (Tipo) REFERENCES Tipos(Id) ON DELETE CASCADE
);

create table Fact_motos(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Factura] INT NOT NULL,
	[Moto] INT NOT NULL,
	[Cantidad] INT NOT NULL,
	[Precio] DECIMAL (10,2) NOT NULL,
	[Iva] DECIMAL (10,2) NOT NULL,
	[Total] DECIMAL (10,2) NOT NULL,
	FOREIGN KEY (Factura) REFERENCES Facturas(Id) ON DELETE CASCADE,
	FOREIGN KEY (Moto) REFERENCES Motocicletas(Id) ON DELETE CASCADE
);



INSERT INTO [Personas] ([Nombre],[Apellido],[Codigo])
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

INSERT INTO [Motocicletas] ([Modelo],[Color],[Cilindraje],[Precio],[Chasis],[Marca],[Referencia],[Tipo])
VALUES ('2023','negro',450,15000.00,1,1,1,1);

INSERT INTO [Fact_motos] ([Factura],[Moto],[Precio],[Iva],[Total],[Cantidad])
VALUES (1,1,15000.00,5000,20000,1);

SELECT *FROM [Personas];
SELECT *FROM [Facturas];
SELECT *FROM [Chasises];
SELECT *FROM [Tipos];
SELECT *FROM [Referencias];
SELECT *FROM [Marcas];
SELECT *FROM [Motocicletas];
SELECT *FROM[Fact_motos];