--1
use Lab4Univer
select  AUDITORIUM.AUDITORIUM[Номер аудитории], AUDITORIUM_TYPE.AUDITORIUM_TYPENAME[Тип аудитории]
from AUDITORIUM inner join AUDITORIUM_TYPE
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE

--2
select  AUDITORIUM.AUDITORIUM[Номер аудитории], AUDITORIUM_TYPE.AUDITORIUM_TYPENAME[Тип аудитории]
from AUDITORIUM inner join AUDITORIUM_TYPE
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE and AUDITORIUM_TYPE.AUDITORIUM_TYPENAME like '%компьютер%'
                                                              --where AUDITORIUM_TYPE.AUDITORIUM_TYPENAME like '%компьютер%'

--3-1
select  AUDITORIUM.AUDITORIUM[Номер аудитории], AUDITORIUM_TYPE.AUDITORIUM_TYPENAME[Тип аудитории]
from AUDITORIUM,  AUDITORIUM_TYPE
where AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE

--3-2
select  A1.AUDITORIUM[Номер аудитории], A2.AUDITORIUM_TYPENAME[Тип аудитории]
from AUDITORIUM as A1,AUDITORIUM_TYPE as A2
where A2.AUDITORIUM_TYPE = A1.AUDITORIUM_TYPE and A2.AUDITORIUM_TYPENAME like '%компьютер%'

--4
select FACULTY.FACULTY_NAME[Факультет], PULPIT.PULPIT_NAME[Кафедра], SUBJECT.SUBJECT_NAME[Предмет],PROFESSION.PROFESSION_NAME[Специальность], STUDENT.NAME[ФИО],
Case
when (PROGRESS.NOTE = 6) then 'шесть'
when (PROGRESS.NOTE = 7) then 'семь'
when (PROGRESS.NOTE = 8) then 'восемь'
end [Оценка]
from FACULTY
inner join GROUPS on FACULTY.FACULTY = GROUPS.FACULTY 
inner join STUDENT on GROUPS.IDGROUP = STUDENT.IDGROUP
inner join PROGRESS on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
inner join SUBJECT on PROGRESS.SUBJECT = SUBJECT.SUBJECT
inner join PULPIT on SUBJECT.PULPIT = PULPIT.PULPIT
inner join PROFESSION on GROUPS.PROFESSION = PROFESSION.PROFESSION
and PROGRESS.NOTE between 6 and 8
order by PROGRESS.NOTE Desc

--5
select FACULTY.FACULTY_NAME[Факультет], PULPIT.PULPIT_NAME[Кафедра], SUBJECT.SUBJECT_NAME[Предмет],PROFESSION.PROFESSION_NAME[Специальность], STUDENT.NAME[ФИО],
Case
when (PROGRESS.NOTE = 6) then 'шесть'
when (PROGRESS.NOTE = 7) then 'семь'
when (PROGRESS.NOTE = 8) then 'восемь'
end [Оценка]
from FACULTY
inner join GROUPS on FACULTY.FACULTY = GROUPS.FACULTY 
inner join STUDENT on GROUPS.IDGROUP = STUDENT.IDGROUP
inner join PROGRESS on STUDENT.IDSTUDENT = PROGRESS.IDSTUDENT
inner join SUBJECT on PROGRESS.SUBJECT = SUBJECT.SUBJECT
inner join PULPIT on SUBJECT.PULPIT = PULPIT.PULPIT
inner join PROFESSION on GROUPS.PROFESSION = PROFESSION.PROFESSION
and PROGRESS.NOTE between 6 and 8
order by
(
Case
when (PROGRESS.NOTE = 6) then 3
when (PROGRESS.NOTE = 7) then 1
when (PROGRESS.NOTE = 8) then 2 
end
)

--6
select PULPIT.PULPIT_NAME[Кафедра], isnull(TEACHER.TEACHER_NAME, '***')[Преподаватель]
from PULPIT left outer join TEACHER
on PULPIT.PULPIT = TEACHER.PULPIT

--7-1
select PULPIT.PULPIT_NAME[Кафедра], isnull(TEACHER.TEACHER_NAME, '***')[Преподаватель]
from TEACHER left outer join PULPIT
on PULPIT.PULPIT = TEACHER.PULPIT

--7-2
select PULPIT.PULPIT_NAME[Кафедра], isnull(TEACHER.TEACHER_NAME, '***')[Преподаватель]
from TEACHER right outer join PULPIT
on TEACHER.PULPIT = PULPIT.PULPIT 

--8
select  AUDITORIUM.AUDITORIUM[Номер аудитории], AUDITORIUM_TYPE.AUDITORIUM_TYPENAME[Тип аудитории]
from AUDITORIUM full outer join AUDITORIUM_TYPE
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE
---------------------------------------------------------------------------------------------------------------------------------------------------------
select  AUDITORIUM.AUDITORIUM[Номер аудитории], AUDITORIUM_TYPE.AUDITORIUM_TYPENAME[Тип аудитории]
from AUDITORIUM_TYPE full outer join AUDITORIUM
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE
---------------------------------------------------------------------------------------------------------------------------------------------------------
select  AUDITORIUM.AUDITORIUM[Номер аудитории], AUDITORIUM_TYPE.AUDITORIUM_TYPENAME[Тип аудитории]
from AUDITORIUM left outer join AUDITORIUM_TYPE
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE
---------------------------------------------------------------------------------------------------------------------------------------------------------
select  AUDITORIUM.AUDITORIUM[Номер аудитории], AUDITORIUM_TYPE.AUDITORIUM_TYPENAME[Тип аудитории]
from AUDITORIUM right outer join AUDITORIUM_TYPE
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE
---------------------------------------------------------------------------------------------------------------------------------------------------------
select  AUDITORIUM.AUDITORIUM[Номер аудитории], AUDITORIUM_TYPE.AUDITORIUM_TYPENAME[Тип аудитории]
from AUDITORIUM inner join AUDITORIUM_TYPE
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE
---------------------------------------------------------------------------------------------------------------------------------------------------------
select  AUDITORIUM.AUDITORIUM[Номер аудитории], AUDITORIUM_TYPE.AUDITORIUM_TYPENAME[Тип аудитории]
from AUDITORIUM full outer join AUDITORIUM_TYPE
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE
---------------------------------------------------------------------------------------------------------------------------------------------------------
select  AUDITORIUM.AUDITORIUM, AUDITORIUM.AUDITORIUM_CAPACITY, AUDITORIUM.AUDITORIUM_NAME, AUDITORIUM.AUDITORIUM_TYPE
from AUDITORIUM_TYPE full outer join AUDITORIUM
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE 
---------------------------------------------------------------------------------------------------------------------------------------------------------
select AUDITORIUM_TYPE.AUDITORIUM_TYPE,AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
from AUDITORIUM_TYPE full outer join AUDITORIUM
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE 
---------------------------------------------------------------------------------------------------------------------------------------------------------
select *
from AUDITORIUM_TYPE full outer join AUDITORIUM
on AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE 
where AUDITORIUM.AUDITORIUM is not null
and AUDITORIUM_TYPE.AUDITORIUM_TYPE is not null
and AUDITORIUM.AUDITORIUM_CAPACITY is not null
and AUDITORIUM.AUDITORIUM_NAME is not null

--9
select AUDITORIUM.AUDITORIUM, AUDITORIUM_TYPE.AUDITORIUM_TYPENAME
from AUDITORIUM cross join AUDITORIUM_TYPE
where AUDITORIUM_TYPE.AUDITORIUM_TYPE = AUDITORIUM.AUDITORIUM_TYPE

--10--Тут переключить БД
use MyBase
select  Teacher.Surname, Teacher.Name, Teacher.Patronymic_Name, Class.Subject, Teacher.Years_Of_Experience, Class.Class_Type, Class.Number_Of_Hours, Class.Payment
from Teacher inner join Class 
on Class.Subject = Teacher.Main_Subject
where Class.Class_Type like '%ра%'
---------------------------------------------------------------------------------------------------------------------------------------------------------
select  T1.Surname, T1.Name, T1.Patronymic_Name, C1.Subject, T1.Years_Of_Experience, C1.Class_Type, C1.Number_Of_Hours, C1.Payment
from Teacher T1, Class C1
where C1.Subject = T1.Main_Subject and C1.Class_Type like '%ра%'
---------------------------------------------------------------------------------------------------------------------------------------------------------
select Groupp.Group_Number, isnull(Groupp.Specialization, '***')[Groupp.Specialization], Groupp.Department, Groupp.Number_Of_Students,
Teacher.Main_Subject, Teacher.Surname, Teacher.Name, Teacher.Patronymic_Name,
Class.Class_Type, Class.Payment,
Case
when (Class.Number_Of_Hours = 24) then 'двадцать четыре часа'
when (Class.Number_Of_Hours = 36) then 'тридцать шесть часов'
when (Class.Number_Of_Hours = 100) then 'сто часов'
end [Количество часов]
from Groupp
inner join Teacher on Teacher.Teacher_ID = Groupp.Curator_ID
inner join Class on Teacher.Main_Subject = Class.Subject
---------------------------------------------------------------------------------------------------------------------------------------------------------
select Groupp.Group_Number, isnull(Groupp.Specialization, '***')[Groupp.Specialization], Groupp.Department, Groupp.Number_Of_Students,
Teacher.Main_Subject, Teacher.Surname, Teacher.Name, Teacher.Patronymic_Name,
Class.Class_Type, Class.Payment,
Case
when (Class.Number_Of_Hours = 24) then 'двадцать четыре часа'
when (Class.Number_Of_Hours = 36) then 'тридцать шесть часов'
when (Class.Number_Of_Hours = 100) then 'сто часов'
end [Количество часов]
from Groupp
inner join Teacher on Teacher.Teacher_ID = Groupp.Curator_ID
inner join Class on Teacher.Main_Subject = Class.Subject
order by
(
Case
when (Class.Number_Of_Hours = 24) then 1
when (Class.Number_Of_Hours = 100) then 3
when (Class.Number_Of_Hours = 36) then 2
end
)
---------------------------------------------------------------------------------------------------------------------------------------------------------
select Teacher.Main_Subject, isnull(Groupp.Specialization, '***')[Groupp.Specialization]
from Groupp left outer join Teacher 
on Teacher.Teacher_ID = Groupp.Curator_ID
---------------------------------------------------------------------------------------------------------------------------------------------------------
select * 
from Teacher full outer join Groupp
on Teacher.Teacher_ID = Groupp.Curator_ID
---------------------------------------------------------------------------------------------------------------------------------------------------------
select Teacher.Main_Subject, Class.Number_Of_Hours
from Teacher cross join Class
where Teacher.Main_Subject = Class.Subject
---------------------------------------------------------------------------------------------------------------------------------------------------------

--11--Тут тоже переключить БД
use Lab4UniverTimeTable
select AUDITORIUM.AUDITORIUM_NAME, WEEKDAYS.NAME, TIMESPACES.STARTTIME -- свободные аудитории
from (AUDITORIUM cross join TIMESPACES cross join WEEKDAYS) 
	left outer join TIMETABLE 
	on AUDITORIUM.AUDITORIUM = TIMETABLE.AUDITORIUM AND WEEKDAYS.ID = TIMETABLE.WEEKDAY AND TIMESPACES.ID = TIMETABLE.TIMESPACE
where TIMETABLE.ID is null 
order by AUDITORIUM.AUDITORIUM_NAME, WEEKDAYS.ID, TIMESPACES.STARTTIME
---------------------------------------------------------------------------------------------------------------------------------------------------------
select AUDITORIUM.AUDITORIUM_NAME, WEEKDAYS.NAME, TIMESPACES.STARTTIME, TIMETABLE.IDGROUP -- занятые аудитории
from (AUDITORIUM cross join TIMESPACES cross join WEEKDAYS) inner join TIMETABLE on AUDITORIUM.AUDITORIUM = TIMETABLE.AUDITORIUM
AND TIMESPACES.ID = TIMETABLE.TIMESPACE AND WEEKDAYS.ID = TIMETABLE.WEEKDAY
order by AUDITORIUM.AUDITORIUM_NAME, WEEKDAYS.ID, TIMESPACES.STARTTIME
---------------------------------------------------------------------------------------------------------------------------------------------------------
select GROUPS.IDGROUP, WEEKDAYS.NAME, TIMESPACES.STARTTIME -- окна у групп
from (GROUPS cross join TIMESPACES cross join WEEKDAYS) 
left outer join TIMETABLE 
on GROUPS.IDGROUP = TIMETABLE.IDGROUP AND TIMESPACES.ID = TIMETABLE.TIMESPACE AND WEEKDAYS.ID = TIMETABLE.WEEKDAY
where TIMETABLE.IDGROUP is null
order by GROUPS.IDGROUP, WEEKDAYS.ID, TIMESPACES.STARTTIME
---------------------------------------------------------------------------------------------------------------------------------------------------------
select GROUPS.IDGROUP, WEEKDAYS.NAME, TIMESPACES.STARTTIME -- занятые пары у студентов
from (GROUPS cross join TIMESPACES cross join WEEKDAYS) left outer join TIMETABLE on GROUPS.IDGROUP = TIMETABLE.IDGROUP
where TIMESPACES.ID = TIMETABLE.TIMESPACE AND WEEKDAYS.ID = TIMETABLE.WEEKDAY
order by GROUPS.IDGROUP, WEEKDAYS.ID, TIMESPACES.STARTTIME
---------------------------------------------------------------------------------------------------------------------------------------------------------
select TEACHER.TEACHER_NAME, WEEKDAYS.NAME, TIMESPACES.STARTTIME -- окна у преподов
from (TEACHER cross join TIMESPACES cross join WEEKDAYS) 
left outer join TIMETABLE 
on TEACHER.TEACHER = TIMETABLE.TEACHER AND TIMESPACES.ID = TIMETABLE.TIMESPACE AND WEEKDAYS.ID = TIMETABLE.WEEKDAY
where TIMETABLE.IDGROUP is null
order by TEACHER.TEACHER, WEEKDAYS.ID, TIMESPACES.STARTTIME
---------------------------------------------------------------------------------------------------------------------------------------------------------
select TEACHER.TEACHER_NAME, WEEKDAYS.NAME, TIMESPACES.STARTTIME -- занятые пары у преподов
from (TEACHER cross join TIMESPACES cross join WEEKDAYS) 
left outer join TIMETABLE 
on TEACHER.TEACHER = TIMETABLE.TEACHER AND TIMESPACES.ID = TIMETABLE.TIMESPACE AND WEEKDAYS.ID = TIMETABLE.WEEKDAY
where TIMETABLE.IDGROUP is not null
order by TEACHER.TEACHER, WEEKDAYS.ID, TIMESPACES.STARTTIME
