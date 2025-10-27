# RegistroDeTickets

## DLL para las tablas de la DB

CREATE DATABASE RegistroDeTicketsPW3;
GO

CREATE TABLE Usuario(
	Id INT NOT NULL IDENTITY,
	Username VARCHAR(20),
	Email VARCHAR(255),
	PasswordHash NVARCHAR(MAX), -- SQL Server no recomienda gurdar las contraseñas como texto plano, por lo que lo guardo como HASH
	CONSTRAINT pk_usuario PRIMARY KEY (Id)
);

CREATE TABLE Ticket(
	Id INT NOT NULL IDENTITY,
	Motivo VARCHAR(30),
	Tipo VARCHAR(30),
	Descripcion TEXT,
	Estado VARCHAR(30),
	FechaCreacion DATETIME2 DEFAULT GETDATE(), -- Utilizo DATETIME2 para obtener hora, minuto y segundo
	FechaActualizacion DATETIME2 NULL, -- Fecha de actualizacion es nula al principio
	Id_usuario INT NOT NULL,
	CONSTRAINT pk_ticket PRIMARY KEY (Id),
	CONSTRAINT fk_ticket_usuario FOREIGN KEY (Id_usuario) REFERENCES Usuario(Id)
);
GO
