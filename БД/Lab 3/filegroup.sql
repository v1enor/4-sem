--alter database [ПАР_ПРОДАЖИ] add filegroup G1;


alter database [ПАР_ПРОДАЖИ] add file
 (name = N'ПАР_ПРОДАЖИ1', filename = N'C:\Users\ilya\Desktop\учеба\БД\Лаба_3\Файловая группа для бд\ПАР_ПРОДАЖИ.ndf', 
   size = 10240KB, maxsize=1Gb, filegrowth=25%
  )  to filegroup G1;

alter database [ПАР_ПРОДАЖИ] modify filegroup G1 default;
