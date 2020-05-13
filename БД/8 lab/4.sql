Create View Лекционные_аудитории(код,наименование_аудитории)
as select Auditorium, Auditorium_type
from Auditorium
where Auditorium_type ='ЛК' with check option;
go
insert Лекционные_аудитории values(206-1,206-1)