USE [ПАР_ПРОДАЖИ]

SELECT [Цена],[Количество] From Товары;

SELECT COUNT(*) From Товары;

SELECT [Наименование] [Дешевые товары] FROM Товары Where [Цена]<200; 
	
SELECT Distinct Top(5) [Наименование_товара],[Цена продажи] FROM [Заказы] Order by [Цена продажи] Desc;