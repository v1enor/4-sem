use master
go
create database Elib
----
use Elib
go
create table Files
( file_id nvarchar(40) not null primary key,
format nvarchar(5),
file_size real
)
insert into Files(file_id, format, file_size)
values ('война_и_мир_Толстой', 'pdf', 1.5),
	   ('властелин_колец_Толкин', 'txt', 0.9),
	   ('преступление_наказание_Достоевский', 'pdf', 1.3),
	   ('белая_гвардия_Булгаков', 'doc', 0.5),
	   ('жестяной_барабан_Грасс', 'docx', 1.4),
	   ('бабий_ветер_Рубина', 'pdf', 0.7)
--------
create table Authors
(FIO nvarchar(30) not null primary key,
country nvarchar(20)
)
insert into Authors(FIO, country)
values ('Толстой Л.Н.', 'Россия'),
	   ('Толкин Р.Р', 'Великобритания'),
	   ('Достоевский Ф.М.','Россия'),
	   ('Булгаков М.С.','Россия'),
	   ('Грасс','Германия'),
	   ('Рубина Д.','Россия'),
	   ('Гёте И.','Германия'),
	   ('Кинг С.','США'),
	   ('Селинджер Дж.','США'),
	   ('Набоков В.', 'Россия'),
	   ('Кэрол Л.','Великобритания')
---------
create table Books
(title nvarchar(100) not null primary key,
 author nvarchar(30) foreign key references Authors(FIO),
 file_id nvarchar(40) foreign key references Files(file_id),
 pages int,
 year int
)
insert into Books(title, author, file_id, pages, year)
values ('Жестяной Барабан','Грасс','жестяной_барабан_Грасс', 789, 1998),
	   ('Война и Мир','Толстой Л.Н.','война_и_мир_Толстой', 1034, 1867),
	   ('Властелин Колец','Толкин Р.Р','властелин_колец_Толкин', 935, 1954)