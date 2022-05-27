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


--4е

create table  #EX_4
(
	TKEY int,
	CC int identity(1, 1),
	TF varchar(100)
)
--drop table #EX_4

set nocount on
declare @I4 int = 0
while @I4 < 15000
begin
	insert #EX_4(TKEY, TF) 
	values (floor(30000 * rand()), replicate ('уефып', 10))
	set @I4 += 1
end

select TKEY from #EX_4 where TKEY between 5000 and 19999 
select TKEY from #EX_4 where TKEY > 15000 and  TKEY < 20000  
select TKEY from #EX_4 where TKEY = 17000

create index IX_dbo_TASK4_FILTER on #EX_4 (TKEY) where (TKEY > 15000 and TKEY < 20000)



--5е
--drop table #EX5

create table #EX5
(
	TKEY int,
	CC int identity(1, 1),
	TF varchar(100)
)

set nocount on
declare @I5 int = 0
while @I5 < 15000
begin
	insert #EX5(TKEY, TF) 
	values (floor(30000 * rand()), replicate ('SGASG', 10))
	set @I5 += 1
end

create index #EX5_TKEY on #EX5(TKEY)
--drop index #EX5_TKEY on #TASK5

INSERT top(10000) #EX5(TKEY, TF) select TKEY, TF from #EX5;


SELECT  OBJECT_NAME(T1.object_id) AS NameTable,
        T2.name AS IndexName,
        T1.avg_fragmentation_in_percent AS Fragmentation
FROM sys.dm_db_index_physical_stats (DB_ID(), NULL, NULL, NULL, NULL) AS T1
LEFT JOIN sys.indexes AS T2 ON T1.object_id = T2.object_id AND T1.index_id = T2.index_id



select OBJECT_ID, avg_fragmentation_in_percent [Процентовка(%)]
from   sys.dm_db_index_physical_stats (DB_ID(N'TEMPDB'),
	   OBJECT_ID(N'#EX5'), NULL, NULL, NULL) ss
--join   sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id
--where  name is not null


alter index #EX5_TKEY on #EX5 reorganize

alter index  #EX5_TKEY on #EX5 rebuild with (online = off)



--6е

create table #EX6
(
	TKEY int,
	CC int identity(1, 1),
	TF varchar(100)
)

--drop table #EX6;

set nocount on
declare @I6 int = 0
while @I6 < 15000
begin
	insert #EX6(TKEY, TF) 
	values (floor(30000 * rand()), replicate ('SGASG', 10))
	set @I6 += 1
end

create index #EX6_TKEY on #EX6(TKEY)

drop index #EX6_TKEY on #EX6;
drop index ex6  on #EX6;
create index ex6 on #EX6(TKEY) with (fillfactor = 65)

SELECT  OBJECT_NAME(T1.object_id) AS NameTable,
        T2.name AS IndexName,
        T1.avg_fragmentation_in_percent AS Fragmentation
FROM sys.dm_db_index_physical_stats (DB_ID(), NULL, NULL, NULL, NULL) AS T1
LEFT JOIN sys.indexes AS T2 ON T1.object_id = T2.object_id AND T1.index_id = T2.index_id