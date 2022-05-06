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
)

go