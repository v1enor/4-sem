use UNIVER
GO

--1Е
CREATE VIEW [ПРЕПОДАВАТЕЛЬ]	AS SELECT
		TEACHER.TEACHER_NAME,TEACHER.GENDER,TEACHER.PULPIT
	FROM TEACHER;
GO
select * from [ПРЕПОДАВАТЕЛЬ];
--drop view [ПРЕПОДАВАТЕЛЬ];

--2Е
CREATE VIEW [Количество кафедр]
	AS SELECT f.FACULTY_NAME,  count(*) [Кол-во кафедр]
		FROM FACULTY f join PULPIT p
		on  f.FACULTY = p.FACULTY 
		group by f.FACULTY_NAME
GO
select * from [Количество кафедр];
--drop view [Количество кафедр];

--3е
CREATE VIEW [Аудитории] 
	AS SELECT AUDITORIUM, AUDITORIUM_TYPE
		FROM AUDITORIUM where AUDITORIUM_TYPE like 'ЛК%'
GO
--drop view [Аудитории];	
select * from Аудитории;

insert Аудитории values('121-2', 'ЛК');
update Аудитории set AUDITORIUM = '1212' where AUDITORIUM = '121';
delete from Аудитории where AUDITORIUM = '1212';

--4е
CREATE VIEW [Лекционные_аудитории] ([код],[наименование аудитории],AUDITORIUM_TYPE)
	AS SELECT AUDITORIUM [код], AUDITORIUM_NAME[наименование аудитории], AUDITORIUM_TYPE
	FROM AUDITORIUM WHERE  AUDITORIUM_TYPE like 'ЛК%' with check option ;
GO
--drop view [Лекционные_аудитории];	 
select * from [Лекционные_аудитории];

insert [Лекционные_аудитории] values('121-22', ' Крутая аудитория', 'ЛК');
update [Лекционные_аудитории] set [код] = '1212' where [код] = '121';
delete from [Лекционные_аудитории] where  [код] = '121-22';

--5е
CREATE VIEW [Дисциплины]
	AS SELECT TOP(6) SUBJECT[код], SUBJECT_NAME[наименование дисциплины], PULPIT[код кафедры]
	FROM SUBJECT
	ORDER BY SUBJECT.SUBJECT_NAME;
GO

--drop view [Дисциплины];	 
select * from [Дисциплины];	

--6е
ALTER VIEW [Количество кафедр] WITH SCHEMABINDING
	AS SELECT f.FACULTY_NAME,  count(*) [Кол-во кафедр]
		FROM dbo.FACULTY f join dbo.PULPIT p
		on  f.FACULTY = p.FACULTY 
		group by f.FACULTY_NAME
GO

select * from [Количество кафедр];
--drop view [Количество кафедр];
delete from [Количество кафедр]  where  FACULTY_NAME = 'Инженерно-экономический факультет';
drop from [Количество кафедр] SCHEMABINDING;

--8е
create view Расписание as
select top(10) * from
		(select top(10) [DAY_NAME] День,LESSON Пара,IDGROUP, AUDITORIUM + [SUBJECT] t
		from TIMETABLE) ttbl
			pivot (max(t) for IDGROUP in ([3],[4],[5])) pvt
		order by Пара
GO

select * from Расписание;