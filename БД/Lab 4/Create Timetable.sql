create table TIMETABLE
(
    IDGROUP		int				foreign key references GROUPS(IDGROUP),
    AUDITORIUM  char(20)		foreign key references AUDITORIUM(AUDITORIUM),
    LESSON		int check		(LESSON between 1 and 4),
    DAY_NAME	char(2) check	(DAY_NAME in('пн', 'вт', 'ср', 'чт', 'пт', 'сб')),
    TEACHER		varchar(100)	foreign key references TEACHER(TEACHER_NAME),
    SUBJECT		char(10)		foreign key references SUBJECT(SUBJECT),
)

insert into TIMETABLE
values
    ( 1,'206-1',2,'пн', 'Акунович Станислав Иванович', 'БД'),
    ( 2,'206-1',3,'пн', 'Акунович Станислав Иванович', 'БД'),
    ( 3,'206-1',4,'пн', 'Акунович Станислав Иванович', 'БД'),

    ( 3,'236-1',2,'ср', 'Безбородов Владимир Степанович', 'ВТЛ'),
    ( 2,'206-1',3,'ср', 'Безбородов Владимир Степанович', 'ВТЛ'),
    ( 4,'301-1',1,'ср', 'Безбородов Владимир Степанович', 'ВТЛ'),

    ( 4,'301-1',1,'ср', 'Бракович Андрей Игоревич', 'ИГ '),
	( 4,'301-1',1,'пт', 'Бракович Андрей Игоревич', 'ИГ '),
	( 4,'301-1',1,'пн', 'Бракович Андрей Игоревич', 'ИГ ')