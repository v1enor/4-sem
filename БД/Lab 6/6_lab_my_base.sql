use [PAR_MyBase]

--1е
SELECT	MAX([Оплата]) [Макс оплата],
	    MIN([Оплата]) [Мин оплата],
		AVG([Оплата]) [Средняя оплата],
		SUM([Оплата]) [Сум оплата],
		COUNT([Оплата]) [Количество маршрутов]

FROM [Маршрут]

--2е
SELECT	Заказ.[Номер водителя],
		MAX([Оплата]) [Макс оплата],
	    MIN([Оплата]) [Мин оплата],
		AVG([Оплата]) [Средняя оплата],
		SUM([Оплата]) [Сум оплата],
		COUNT([Оплата]) [Количество маршрутов]

FROM Заказ inner join Маршрут
	on Заказ.ID_заказа = Маршрут.ID_Маршрута
	Group by Заказ.[Номер водителя]

--3е	

SELECT * 
		FROM(SELECT 

			CASE 
				WHEN Стаж between 0 and 12 THEN '0-12'
				WHEN Стаж between 13 and 20 THEN  '13-20'
				WHEN Стаж  > 20 THEN  '>20'
			end [Стаж], COUNT(*) [Количество]		

			FROM  Водитель GROUP BY
				CASE
					WHEN Стаж between 0 and 12 THEN '0-12'
					WHEN Стаж between 13 and 20 THEN  '13-20'
					WHEN Стаж  > 20 THEN  '>20'
				end ) as T
					
					ORDER BY CASE [Стаж]
						when '0-12'  then 1
						when '13-20' then 2
						when '>20' then 3
						else 0
					end;

----- 4е

SELECT v.ID_Водителя,  ROUND(AVG(CAST(m.Оплата AS FLOAT(4))),2) [Ср оплата]

FROM Водитель v inner join Заказ z
	on v.ID_Водителя = z.[Номер водителя] inner join Маршрут m
	on z.[Номер маршрута] = m.ID_Маршрута 
	GROUP BY v.ID_Водителя
	ORDER BY [Ср оплата]


SELECT v.ID_Водителя,  ROUND(AVG(CAST(m.Оплата AS FLOAT(4))),2) [Ср оплата]

FROM Водитель v inner join Заказ z
	on v.ID_Водителя = z.[Номер водителя] inner join Маршрут m
	on z.[Номер маршрута] = m.ID_Маршрута where v.Имя in ('Илья', 'Иван')
	GROUP BY v.ID_Водителя
	ORDER BY [Ср оплата]



----5e 
SELECT v.ID_Водителя, z.ID_заказа , ROUND(AVG(CAST(m.Оплата AS FLOAT(4))),2) [Ср оплата]

FROM Водитель v inner join Заказ z
	on v.ID_Водителя = z.[Номер водителя] inner join Маршрут m
	on z.[Номер маршрута] = m.ID_Маршрута where v.Имя in ('Илья', 'Иван')
	GROUP BY ROLLUP (v.ID_Водителя, z.ID_заказа)
	


----6е
SELECT v.ID_Водителя, z.ID_заказа , ROUND(AVG(CAST(m.Оплата AS FLOAT(4))),2) [Ср оплата]

FROM Водитель v inner join Заказ z
	on v.ID_Водителя = z.[Номер водителя] inner join Маршрут m
	on z.[Номер маршрута] = m.ID_Маршрута where v.Имя in ('Илья', 'Иван')
	GROUP BY CUBE (v.ID_Водителя, z.ID_заказа)

----7е
SELECT v.ID_Водителя, v.Имя , ROUND(AVG(CAST(m.Оплата AS FLOAT(4))),2) [Ср оплата]

FROM Водитель v inner join Заказ z
	on v.ID_Водителя = z.[Номер водителя] inner join Маршрут m
	on z.[Номер маршрута] = m.ID_Маршрута where v.Имя in ('Иван', 'Илья')
	GROUP BY  v.ID_Водителя, v.Имя
	
	UNION
	
SELECT v.ID_Водителя,  v.Имя , ROUND(AVG(CAST(m.Оплата AS FLOAT(4))),2) [Ср оплата]

FROM Водитель v inner join Заказ z
	on v.ID_Водителя = z.[Номер водителя] inner join Маршрут m
	on z.[Номер маршрута] = m.ID_Маршрута where v.Имя = 'Илья'
	GROUP BY v.ID_Водителя, v.Имя


SELECT  v.ID_Водителя , ROUND(AVG(CAST(m.Оплата AS FLOAT(4))),2) [Ср оплата]

FROM Водитель v inner join Заказ z
	on v.ID_Водителя = z.[Номер водителя] inner join Маршрут m
	on z.[Номер маршрута] = m.ID_Маршрута where v.Имя in ('Иван', 'Илья')
	GROUP BY   v.ID_Водителя
	
	UNION all
	
SELECT v.ID_Водителя, ROUND(AVG(CAST(m.Оплата AS FLOAT(4))),2) [Ср оплата]

FROM Водитель v inner join Заказ z
	on v.ID_Водителя = z.[Номер водителя] inner join Маршрут m
	on z.[Номер маршрута] = m.ID_Маршрута where v.Имя = 'Илья'
	GROUP BY v.ID_Водителя


----8е 
SELECT  v.ID_Водителя , ROUND(AVG(CAST(m.Оплата AS FLOAT(4))),2) [Ср оплата]

FROM Водитель v inner join Заказ z
	on v.ID_Водителя = z.[Номер водителя] inner join Маршрут m
	on z.[Номер маршрута] = m.ID_Маршрута where v.Имя in ('Иван', 'Илья')
	GROUP BY   v.ID_Водителя
	
	INTERSECT
	
SELECT v.ID_Водителя, ROUND(AVG(CAST(m.Оплата AS FLOAT(4))),2) [Ср оплата]

FROM Водитель v inner join Заказ z
	on v.ID_Водителя = z.[Номер водителя] inner join Маршрут m
	on z.[Номер маршрута] = m.ID_Маршрута where v.Имя = 'Илья'
	GROUP BY v.ID_Водителя


----9е
SELECT  v.ID_Водителя , ROUND(AVG(CAST(m.Оплата AS FLOAT(4))),2) [Ср оплата]

FROM Водитель v inner join Заказ z
	on v.ID_Водителя = z.[Номер водителя] inner join Маршрут m
	on z.[Номер маршрута] = m.ID_Маршрута where v.Имя in ('Иван', 'Илья')
	GROUP BY   v.ID_Водителя
	
	EXCEPT
	
SELECT v.ID_Водителя, ROUND(AVG(CAST(m.Оплата AS FLOAT(4))),2) [Ср оплата]

FROM Водитель v inner join Заказ z
	on v.ID_Водителя = z.[Номер водителя] inner join Маршрут m
	on z.[Номер маршрута] = m.ID_Маршрута where v.Имя = 'Илья'
	GROUP BY v.ID_Водителя


----10е
SELECT v.Стаж, v.Имя, (SELECT COUNT(*) FROM Водитель v2 where v.Имя = v2.Имя and v2.Стаж in (12,15)) [Кол-во со стражем]
	FROM Водитель v
	GROUP BY v.Стаж, v.Имя
	HAVING v.Стаж in (12,15)
