use master  
create database оюп_опндюфх_2 on primary
( name = N'оюп_опндюфх_mdf', filename = N'C:\Users\ilya\Desktop\СВЕАЮ\ад\кЮАЮ_3\АД\оюп_опндюфхR_mdf.mdf', 
   size = 10240Kb, maxsize=UNLIMITED, filegrowth=1024Kb),
( name = N'оюп_опндюфх_ndf', filename = N'C:\Users\ilya\Desktop\СВЕАЮ\ад\кЮАЮ_3\АД\оюп_опндюфхR_ndf.ndf', 
   size = 10240KB, maxsize=1Gb, filegrowth=25%),
filegroup FG1
( name = N'оюп_опндюфх_fg1_1', filename = N'C:\Users\ilya\Desktop\СВЕАЮ\ад\кЮАЮ_3\АД\оюп_опндюфхR_fgq-1.ndf', 
   size = 10240Kb, maxsize=1Gb, filegrowth=25%),
( name = N'оюп_опндюфх_fg1_2', filename = N'C:\Users\ilya\Desktop\СВЕАЮ\ад\кЮАЮ_3\АД\оюп_опндюфхR_fgq-2.ndf', 
   size = 10240Kb, maxsize=1Gb, filegrowth=25%)
log on
( name = N'оюп_опндюфх_log', filename=N'C:\Users\ilya\Desktop\СВЕАЮ\ад\кЮАЮ_3\АД\оюп_опндюфхR_log.ldf',       
   size=10240Kb,  maxsize=2048Gb, filegrowth=10%)
