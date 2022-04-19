-- 1е задание

SELECT Фамилия
	FROM Водитель, Заказ, Маршрут
	WHERE Водитель.[ID_Водителя] = Заказ.[Номер водителя] AND
	Маршрут.ID_Маршрута = Заказ.ID_Заказа and Маршрут.ID_Маршрута IN 
		(SELECT [ID_Маршрута] FROM Маршрут WHERE([Название маршрута] LIKE 'Минск%'))

---- 2е задание
SELECT Фамилия
	FROM Водитель INNER JOIN Заказ
	ON Водитель.[ID_Водителя] = Заказ.[Номер водителя] INNER JOIN Маршрут 
	ON  Заказ.ID_Заказа = Маршрут.ID_Маршрута and Маршрут.ID_Маршрута IN 
		(SELECT [ID_Маршрута] FROM Маршрут WHERE([Название маршрута] LIKE 'Минск%'))



---- 3е задание
SELECT Фамилия
	FROM Водитель INNER JOIN Заказ
	ON Водитель.[ID_Водителя] = Заказ.[Номер водителя] INNER JOIN Маршрут 
	ON Заказ.ID_Заказа = Маршрут.ID_Маршрута WHERE([Название маршрута] LIKE 'Минск%')


---- 4е задание 
SELECT [Номер водителя],[Номер маршрута]
	FROM [Заказ] z
	WHERE [ID_Заказа] = (select top (1) [ID_Заказа] from  Заказ zz
						where zz.[Номер водителя]  = z.[Номер водителя]  order by [Дата возвращения])

--5е задание
SELECT Фамилия
	FROM [dbo].[Водитель]
	WHERE not exists (select * from [Заказ]
			where Заказ.[Номер водителя] = Водитель.ID_Водителя)

----6е задание 
SELECT TOP 1
(SELECT AVG([Оплата]) FROM Маршрут
					where [Название маршрута] like '%Минск%')[Минск],

(SELECT AVG([Оплата]) FROM Маршрут
					where [Название маршрута] like '%Бобруйск%')[Бобруйск]

From Маршрут

----7е задание 
SELECT [Название маршрута], [Дальность]
	FROM [Маршрут]
	WHERE [Оплата] >= any 
--SELECT IDSTUDENT, NOTE
--	FROM PROGRESS 
--	WHERE NOTE >= ANY (SELECT NOTE FROM PROGRESS WHERE IDSTUDENT LIKE 2)		