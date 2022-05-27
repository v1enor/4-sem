--1е
use [PAR_MyBase]
exec SP_HELPINDEX 'Заказ'

--create index зк on Заказ([ID_заказа],[Номер водителя]);
--drop index зк on Заказ;
select * from Заказ;
select * from Заказ where ID_заказа = 1;
checkpoint;  --фиксация БД
DBCC DROPCLEANBUFFERS;  --очистить буферный кэш

SELECT  OBJECT_NAME(T1.object_id) AS NameTable,
        T2.name AS IndexName,
        T1.avg_fragmentation_in_percent AS Fragmentation
FROM sys.dm_db_index_physical_stats (DB_ID(), NULL, NULL, NULL, NULL) AS T1
LEFT JOIN sys.indexes AS T2 ON T1.object_id = T2.object_id AND T1.index_id = T2.index_id
