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
values ('�����_�_���_�������', 'pdf', 1.5),
	   ('���������_�����_������', 'txt', 0.9),
	   ('������������_���������_�����������', 'pdf', 1.3),
	   ('�����_�������_��������', 'doc', 0.5),
	   ('��������_�������_�����', 'docx', 1.4),
	   ('�����_�����_������', 'pdf', 0.7)
--------
create table Authors
(FIO nvarchar(30) not null primary key,
country nvarchar(20)
)
insert into Authors(FIO, country)
values ('������� �.�.', '������'),
	   ('������ �.�', '��������������'),
	   ('����������� �.�.','������'),
	   ('�������� �.�.','������'),
	   ('�����','��������'),
	   ('������ �.','������'),
	   ('ø�� �.','��������'),
	   ('���� �.','���'),
	   ('��������� ��.','���'),
	   ('������� �.', '������'),
	   ('����� �.','��������������')
---------
create table Books
(title nvarchar(100) not null primary key,
 author nvarchar(30) foreign key references Authors(FIO),
 file_id nvarchar(40) foreign key references Files(file_id),
 pages int,
 year int
)
insert into Books(title, author, file_id, pages, year)
values ('�������� �������','�����','��������_�������_�����', 789, 1998),
	   ('����� � ���','������� �.�.','�����_�_���_�������', 1034, 1867),
	   ('��������� �����','������ �.�','���������_�����_������', 935, 1954)