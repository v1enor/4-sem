-- 2
USE [PAR_MyBase]
GO
--CREATE DATABASE [PAR_MyBase];

DROP table  Заказ, Водитель, Маршрут;



CREATE TABLE Водитель(
	Фамилия nchar(50) not null,
	Имя nchar(50) not null,
	Отчество nchar(50) not null,
	Стаж int not null,
	ID_Водителя int primary key 
)

CREATE TABLE Маршрут(
	 [Название маршрута] nchar(50) not null,
	 [Дальность] nchar(50) not null,
	 [Количество дней в пути] int not null,
	 Оплата money not null,
	 ID_Маршрута int primary key 
)

CREATE TABLE Заказ(
	[Дата отправки] smalldatetime not null,
	[Дата Возвращения] smalldatetime not null,
	[Номер водителя] int foreign key references Водитель(ID_Водителя),
	[Номер маршрута] int foreign key references Маршрут(ID_Маршрута),
	ID_заказа int primary  key
)
 update Заказ set ID_заказа = 2 where ID_заказа =2;

--3
USE PAR_MyBase

ALTER table Водитель add pol nchar(1) default'м' check (pol in ('м','ж'));

ALTER table Водитель drop constraint [DF__Водитель__pol__72C60C4A];	
ALTER table Водитель drop constraint [CK__Водитель__pol__73BA3083];
ALTER table Водитель drop column pol;

--4
INSERT INTO Маршрут values('Бобруйск-Минск', '12' , 1, 200, 1);

INSERT into Водитель values('Парибок', 'Илья', 'Александрович', 15, 1);

INSERT INTO Заказ values('2002-10-03 00:00:00','2002-10-03 00:00:00', 1,1,1)
INSERT INTO Заказ values('2002-10-03 00:00:00','2002-10-03 00:00:00', 1,1,2);

--5 
update Заказ set [Дата Возвращения] = '2002-10-03 12:00:00' where ID_заказа = 1;

select * from [Заказ];

--6
select * from Заказ where ID_заказа between 2 and 3;
select * from Водитель where Фамилия like 'П%';
select * from Маршрут where Оплата in (200.00,300.00);

--7 
--drop database [PAR_MyBase];

CREATE DATABASE [PAR_MyBase]
 ON  PRIMARY 
( NAME = N'PAR_MyBase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PAR_MyBase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB ),
filegroup FG1
( name = N'PAR_MyBase_fg1_1', filename = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PAR_MyBase_fgq-1.ndf', 
   size = 10240Kb, maxsize=1Gb, filegrowth=25%),
( name = N'PAR_MyBase_fg1_2', filename = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PAR_MyBase_fgq-2.ndf', 
   size = 10240Kb, maxsize=1Gb, filegrowth=25%)

LOG ON 
( NAME = N'PAR_MyBase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\PAR_MyBase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )

CREATE TABLE Водитель(
	Фамилия nchar(50) not null,
	Имя nchar(50) not null,
	Отчество nchar(50) not null,
	Стаж int not null,
	ID_Водителя int primary key 
)on FG1

CREATE TABLE Маршрут(
	 [Название маршрута] nchar(50) not null,
	 [Дальность] nchar(50) not null,
	 [Количество дней в пути] int not null,
	 Оплата money not null,
	 ID_Маршрута int primary key 
)

CREATE TABLE Заказ(
	[Дата отправки] smalldatetime not null,
	[Дата Возвращения] smalldatetime not null,
	[Номер водителя] int foreign key references Водитель(ID_Водителя),
	[Номер маршрута] int foreign key references Маршрут(ID_Маршрута),
	ID_заказа int primary  key
)go