USE RegistroDeTicketsPW3;
GO

INSERT INTO TicketEstado (Nombre) VALUES ('Iniciado'), ('Asignado'), ('Respondido'), ('Finalizado');
GO

INSERT INTO TicketPrioridad (Nombre) VALUES ('Baja'), ('Media'), ('Alta');
GO

INSERT INTO Usuario (Username, Email, PasswordHash) 
VALUES ('cliente_prueba', 'cliente@test.com', 'hash_de_prueba_123');

INSERT INTO Cliente (Id) 
VALUES (1);
GO