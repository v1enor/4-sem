use [PAR_MyBase]
GO

--1Е
CREATE VIEW [Водители]	AS SELECT
		Водитель.ID_Водителя, Водитель.Имя, Водитель.Стаж
	FROM Водитель;
GO
select * from [Водители];
--drop view [Водители];

--2Е
CREATE VIEW [Количество заказов]
	AS SELECT v.ID_Водителя ,  count(*) [Кол-во заказов]
		FROM [Водитель] v join [Заказ] z
		on  v.ID_Водителя = z.ID_заказа 
		group by v.ID_Водителя 
GO
select * from [Количество заказов];
--drop view [Количество заказов];

--3е
CREATE VIEW [Фамилии водителей] 
	AS SELECT Имя, Фамилия,Отчество,Стаж, ID_Водителя
		FROM Водитель where Фамилия like 'П%'
GO
--drop view [Фамилии водителей] ;	
select * from [Фамилии водителей] ;

insert [Фамилии водителей] (Имя, Фамилия,Отчество,Стаж, ID_Водителя) values('Игнат', 'ПБыстрый', 'Быстрый',2, 10);
update [Фамилии водителей] set Имя = 'Игнат2' where Имя = 'Игнат';
delete from [Фамилии водителей] where ID_Водителя = '10';

--4е
CREATE VIEW [Фамилии водителей2] 
	AS SELECT Имя, Фамилия, Отчество, Стаж, ID_Водителя [Номер водителя]
		FROM Водитель where Фамилия like 'П%'  with check option ;
GO
--drop view [Фамилии водителей2] ;	
select * from [Фамилии водителей2] ;

insert [Фамилии водителей2] (Имя, Фамилия,Отчество,Стаж, [Номер водителя]) values('Игнат', 'ПБыстрый', 'Быстрый',2, 10);
update [Фамилии водителей2] set Имя = 'Игнат2' where Имя = 'Игнат';
delete from [Фамилии водителей2] where [Номер водителя] = '10';

--5е
CREATE VIEW [Маршруты]
	AS SELECT TOP(2) [ID_Маршрута][код], [Название маршрута], [Дальность]
	FROM Маршрут
	ORDER BY Маршрут.[ID_Маршрута] DESC;
GO


--drop view [Маршруты];	 
select * from [Маршруты];	

--6е
ALTER VIEW [Количество заказов]  WITH SCHEMABINDING
	AS SELECT v.ID_Водителя ,  count(*) [Кол-во заказов]
		FROM [dbo].[Водитель] v join [dbo].[Заказ] z
		on  v.ID_Водителя = z.ID_заказа 
		group by v.ID_Водителя 
GO

select * from [Количество заказов];
--drop view [Количество заказов];
delete from [Количество заказов]  where [ID_Маршрута] = 3;


