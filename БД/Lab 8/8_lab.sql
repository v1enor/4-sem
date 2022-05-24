--1
use UNIVER
declare @ch char(10) = 'test',						
		@vch varchar(10) = 'tests',		
		@dt datetime,							
		@tm time(3),							
		@in int,								
		@sint smallint,							
		@tint tinyint,						
		@nm numeric(12,5)					

set @dt = '30/12/2013'
set @tm = '11:11:11'

select @sint = 1
select @in = (select avg([NOTE]) from [dbo].[PROGRESS])
select @nm = 111111.1111

print 'char:           ' + @ch
print 'varchar:        ' + @vch
print 'int:            ' + cast(@in as char)
print 'smallint:       ' + cast(@sint as char)
print 'numeric(12,5):  ' + cast(@nm as char)


--2е
DECLARE @all int = (SELECT sum(AUDITORIUM_CAPACITY) FROM AUDITORIUM), 
		@count int, @avg real, @count_less numeric(8,3);

IF @all>200
	
	BEGIN 
		SELECT @count = (select COUNT(*) from AUDITORIUM),
			   @avg = (select CAST(AVG(AUDITORIUM_CAPACITY) AS REAL) FROM AUDITORIUM)
		SET @count_less = (select cast(COUNT(*) as numeric(8,3)) from AUDITORIUM 
														where AUDITORIUM_CAPACITY > @avg)
		SELECT @all 'общая вместимость ', @count 'количество аудиторий', @avg 'среднюю вместимость аудиторий',
			   @count_less 'которых меньше средней', ( @count_less / (@count) ) * 100 as проценты
	end

else print 'Размере общей вместимости ' + cast(@x as varchar(11))


--3е
print 'число обработанных строк: ' +				CAST(@@ROWCOUNT as char)
print 'версия SQL Server: ' +						CAST(@@VERSION as char)
print 'системный идентификатор процесса: '+			CAST(@@SPID as char)
print 'код последней ошибки: ' +					CAST(@@ERROR as char)
print 'имя сервера: ' +								CAST(@@SERVERNAME as char)
print 'уровень вложенности транзакции: ' +			CAST(@@TRANCOUNT as char)
print 'проверка результата считывания строк : ' +	CAST(@@FETCH_STATUS as char)
print 'уровень вложенности текущей про-цедуры: ' +	CAST(@@NESTLEVEL as char)


--4е
declare @z numeric(5, 3), @t real, @x real
set @t = 1 set @x = 1.2		

if (@t > @x) set @z = sin(@t) * sin(@t)
else if (@t < @x) set @z = 4 * (@t + @x)
else set @z = 1 - exp(@x - 2)

print cast(@z as char)


DECLARE @ФИО varchar(50) = 'Макейчик Татьяна Леонидовна';
SET 
@ФИО = (  SELECT SUBSTRING(@ФИО, 1, CHARINDEX(' ', @ФИО)) +
		SUBSTRING(@ФИО, CHARINDEX(' ', @ФИО) + 1, 1) + '.' +
		SUBSTRING(@ФИО, CHARINDEX(' ', @ФИО, CHARINDEX(' ', @ФИО) + 1) + 1, 1) + '.');
PRINT 'Сокращенное: ' + @ФИО;


DECLARE @DATE INT = MONTH(getdate()) + 1;
	SELECT [IDSTUDENT],[NAME] ,[BDAY] FROM STUDENT WHERE MONTH([BDAY]) = @DATE;


SELECT TOP(1) [SUBJECT], [PDATE], DATENAME(DW, [PDATE])[День недели] 
	FROM [PROGRESS] WHERE [SUBJECT] = 'СУБД';


--5е
DECLARE @AVG_NOTE FLOAT(4) = (SELECT AVG(CAST([NOTE] AS FLOAT(4))) AS FLOAT FROM [PROGRESS]), 
		@AVG_OAIP FLOAT(4) = (SELECT AVG(CAST([NOTE] AS FLOAT(4))) FROM [PROGRESS] WHERE SUBJECT = 'ОАиП');
		--set @AVG_NOTE = 5;
IF @AVG_NOTE  >= @AVG_OAIP
	BEGIN
		PRINT 'Общ. ср. выше чем ср по Оаип: ' 
		PRINT @AVG_NOTE
		PRINT @AVG_OAIP
	END;
ELSE 
	BEGIN
		PRINT 'Общ. ср.  не выше чем ср по Оаип: ' 
		PRINT @AVG_NOTE
		PRINT @AVG_OAIP
	END;

--6е
SELECT CASE 
	WHEN NOTE BETWEEN 8 AND 10 THEN 'Отлично' 
	WHEN NOTE BETWEEN 6 AND 8 THEN 'Норм'
	WHEN NOTE BETWEEN 4 AND 6 THEN 'Ну и хватит'
	else 'Пересдача('
	end NOTE, COUNT(*) [Кол-во]
FROM PROGRESS
GROUP BY CASE 
	WHEN NOTE BETWEEN 8 AND 10 THEN 'Отлично' 
	WHEN NOTE BETWEEN 6 AND 8 THEN 'Норм'
	WHEN NOTE BETWEEN 4 AND 6 THEN 'Ну и хватит'
	else 'Пересдача('
	end

--7е
CREATE TABLE #tb (
	ind int, random float, random2 float
);
--drop table #tb;

DECLARE @i int = 0;
WHILE (@i < 10)
	BEGIN
	INSERT #tb (ind, random, random2) VALUES 
			   (@i, rand() + @i, rand() +@i );
	SET @i += 1;
	END
SELECT *
FROM #tb;

--8e

DECLARE @i int = 0;
WHILE (@i < 10)
	BEGIN
	INSERT #tb (ind, random, random2) VALUES 
			   (@i, rand() + @i, rand() +@i );
	IF @i  != 8
	BEGIN 
		SET @i += 1;
	END;
	else
		begin
		SELECT * FROM #tb;
		return --- ретурн добавил  
		end;
	END
SELECT * FROM #tb;


--9е
BEGIN TRY
	UPDATE [PROGRESS] SET [PROGRESS].[NOTE] = 'фпвл' WHERE [PROGRESS].IDSTUDENT = 1
	SELECT * FROM [PROGRESS]
END TRY

BEGIN CATCH
	PRINT 'ERROR_NUMBER = ' + CAST(ERROR_NUMBER() AS varchar(10))
	PRINT 'ERROR_MESSAGE = ' + ERROR_MESSAGE()
	PRINT 'ERROR_LINE = ' + CAST(ERROR_LINE() AS varchar(10))
	PRINT 'ERROR_PROCEDURE = ' + CAST(ERROR_PROCEDURE() AS varchar(10))
	PRINT 'ERROR_SEVERITY = ' + CAST(ERROR_SEVERITY() AS varchar(10))
	PRINT 'ERROR_STATE = ' + CAST(ERROR_STATE() AS varchar(10))
END CATCH