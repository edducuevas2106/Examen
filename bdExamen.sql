Create database [Examen]
Go

Create table Persona(
Id int identity(1,1) primary key,
Nombre varchar(50) not null,
APaterno varchar(50) not null,
AMaterno varchar(50) not null,
Identificacion varchar(10)not null 
)
Go

Create table Factura(
Id int identity(1,1) primary key,
Monto decimal(10,2) not null,
Fecha datetime not null,
IdPersona int foreign Key references Persona (id) not null
)
go

CREATE NONCLUSTERED INDEX [IX_IdPersonas] ON [dbo].[Factura]
(
	[IdPersona] DESC
)
INCLUDE([Id],[Monto],[Fecha]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO


CREATE PROCEDURE sp_Generar_Codigo
AS BEGIN
    DECLARE @contador INT, @codigo_secundario VARCHAR(4) 

    SET @contador= (SELECT COUNT(*)+1 FROM Persona); 
    IF(@contador<10) 
        SET @codigo_secundario = CONCAT('P00',@contador);
    IF(@contador>=10 and @contador<100)
        SET @codigo_secundario = CONCAT('P0',@contador);
    IF(@contador>100)
        SET @codigo_secundario = CONCAT('P',@contador);

	select @codigo_secundario
END
Go