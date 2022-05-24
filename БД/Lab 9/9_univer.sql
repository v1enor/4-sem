--1е
use UNIVER
exec SP_HELPINDEX 'AUDITORIUM_TYPE'

create table #example
(	tind int,
	tchar varchar(100)
);

set nocount on;
declare @i int = 0;
while @i <1000
begin 
	insert #example
		values(FLOOR(20000*RAND()), REPLICATE('строка', 10));
	if (@i % 100 = 0) print @i;
	set @i = @i + 1;
end;

select * from #example where tind between 1500 and 2500 order by tind;

checkpoint;  --фиксация БД
DBCC DROPCLEANBUFFERS;  --очистить буферный кэш

CREATE clustered index #EXPLRE_CL on #example(TIND asc);
--drop table #example;

--2е
CREATE table #EX_2
(    TKEY int, 
      CC int identity(1, 1),
      TF varchar(100)
);


set nocount on;           
declare @i_2 int = 0;
while   @i_2 < 20000       -- добавление в таблицу 20000 строк
begin
    INSERT #EX_2(TKEY, TF) values(floor(30000*RAND()), replicate('строка ', 10));
    set @i_2 = @i_2 + 1; 
end;
  
SELECT count(*)[количество строк] from #EX_2;
SELECT * from #EX_2

CREATE index #EX_NONCLU on #EX_2(TKEY, CC);

SELECT * from  #EX_2 where  TKEY > 1500 and  CC < 4500;  
SELECT * from  #EX_2 order by  TKEY, CC;

SELECT * from  #EX_2 where  TKEY = 556 and  CC > 3;

--3е
CREATE table #EX_3
(    TKEY int, 
      CC int identity(1, 1),
      TF varchar(100)
);


set nocount on;           
declare @i_3 int = 0;
while   @i_3 < 10000      
begin
    INSERT #EX_3(TKEY, TF) values(floor(30000*RAND()), replicate('строка ', 10));
    set @i_3 = @i_3 + 1; 
end;

CREATE  index #EX_TKEY_X on #EX_3(TKEY) INCLUDE (CC)
SELECT CC from #EX_3 where TKEY>15000 