create database GITHUB
USE GITHUB

Create Table Clientes(
Codigo varchar(8) primary key not null,
Nombre varchar(50) not null,
Apellido varchar(50) not null,
Dni varchar(8) not null,
Direccion varchar(50) not null,
Telefono varchar(9) not null)

INSERT INTO Clientes (Codigo, Nombre, Apellido, Dni, Direccion, Telefono) VALUES
('C001', 'Juan', 'Pérez', '12345678', 'Av. Libertador 123', '987654321'),
('C002', 'Luis', 'Martínez', '34567890', 'Boulevard 789', '987654323'),
('C003', 'Ana', 'Rodríguez', '45678901', 'Plaza Mayor 101', '987654324')

select * from Clientes
