USE PAR_MyBase

ALTER table Водитель add pol nchar(1) default'м' check (pol in ('м','ж'));

ALTER table Водитель drop constraint [DF__Водитель__pol__72C60C4A];	
ALTER table Водитель drop constraint [CK__Водитель__pol__73BA3083];
ALTER table Водитель drop column pol;