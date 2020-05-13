Create View [Аудитории1] (Аудитории, наименование_аудиторий)
as select Auditorium, Auditorium_name
from Auditorium
where Auditorium_type = 'ЛК'
go 
select * from Аудитории1
insert [Аудитории1]values('2000-1','30-2')