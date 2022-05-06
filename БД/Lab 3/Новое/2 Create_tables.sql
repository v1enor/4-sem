USE [PAR_MyBase]
GO

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
