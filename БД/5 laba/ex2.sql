use GR_Univer
select Auditorium.Auditorium, Auditorium_type.Auditorium_typename
from Auditorium inner join Auditorium_type
on Auditorium.Auditorium_type=Auditorium_type.Auditorium_type and Auditorium_type.Auditorium_typename like '���������%'