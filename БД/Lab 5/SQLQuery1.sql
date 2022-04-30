-- 1е задание
SELECT PULPIT_NAME
	FROM PULPIT, FACULTY
	WHERE FACULTY.FACULTY = PULPIT.FACULTY AND
	FACULTY.FACULTY IN 
		(SELECT FACULTY FROM PROFESSION WHERE(PROFESSION_NAME LIKE '%технология%'))


-- 2е задание
SELECT PULPIT_NAME 
	FROM PULPIT INNER JOIN FACULTY
	ON FACULTY.FACULTY = PULPIT.FACULTY AND
	FACULTY.FACULTY IN 
		(SELECT FACULTY FROM PROFESSION WHERE(PROFESSION_NAME LIKE '%технология%'))


-- 3е задание
SELECT PULPIT_NAME 
	FROM PULPIT INNER JOIN FACULTY
	ON FACULTY.FACULTY = PULPIT.FACULTY 
		INNER JOIN PROFESSION
		ON PROFESSION.FACULTY = FACULTY.FACULTY WHERE PROFESSION.PROFESSION_NAME LIKE '%технология%'
	--FACULTY.FACULTY IN 
	--	(SELECT FACULTY FROM PROFESSION WHERE(PROFESSION_NAME LIKE '%технология%'))


-- 4е задание
select AUDITORIUM_CAPACITY, AUDITORIUM_TYPE
	from AUDITORIUM 
	where AUDITORIUM_CAPACITY in (select top(8)	AUDITORIUM_CAPACITY from AUDITORIUM) order by AUDITORIUM_CAPACITY desc


--5е задание exist
select distinct FACULTY_NAME
	from FACULTY, PULPIT
	where exists (select * from PULPIT)


--6е задание 
select top(1) 

(select avg(NOTE) from PROGRESS
	where SUBJECT like 'ОАиП') [ОАиП],
(select avg(NOTE) from PROGRESS
	where SUBJECT like 'КГ') [КГ],
(select avg(NOTE) from PROGRESS
	where SUBJECT like 'СУБД') [СУБД]

from PROGRESS


--7е задание 
select NOTE, SUBJECT
	from PROGRESS
	where NOTE >= all(select NOTE from PROGRESS where SUBJECT like 'К%')


--8е задание 
select NOTE, SUBJECT
	from PROGRESS
	where NOTE > any(select NOTE from PROGRESS where SUBJECT like 'К%')

--10е задание
SELECT DISTINCT E1.idstudent, 
                E1.NAME, 
                E1.BDAY, 
                E2.idstudent, 
                E2.NAME, 
                E2.BDAY
FROM   STUDENT E1, STUDENT E2 
WHERE  Day(E1.BDAY) = Day(E2.BDAY) 
       AND Month(E1.BDAY) = Month(E2.BDAY) 
       AND E1.idstudent < E2.idstudent