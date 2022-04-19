USE [ПАР_ПРОДАЖИ]





--ALTER table Товары DROP column POL;

--ALTER table Товары ADD POL nchar(1) default 'м' check (POL in('м','ж'));





--DROP table ТОВАРЫ;

ALTER table Товары ADD Дата_поступления date;


CREATE table Товары	
( Наименование nvarchar(50) primary key,
  Цена real unique not null,
  Количество int
);

CREATE table Заказчики
( Наименование_фирмы nvarchar(50) primary key,
  Адреc nvarchar(50),
  Расчётный_счёт nvarchar(20)
);

CREATE TABLE Заказы
(
  Номер_заказа int primary key,
  Наименование_товара nvarchar(50) foreign key  references Товары(Наименование),
  [Цена продажи] real,
  Количество int,
  Дата_поставки date,
  Заказчик nvarchar(50) foreign key references Заказчики(Наименование_фирмы)

);

SELECT * FROM Заказы;