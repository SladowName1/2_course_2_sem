use GR_Univer
select Auditorium.Auditorium, Auditorium_type.Auditorium_typename
from Auditorium, Auditorium_type
Where Auditorium.Auditorium_type=Auditorium_type.Auditorium_type and Auditorium_type.Auditorium_typename like 'компьютер%'
use GR_Univer
select A1.Auditorium, A2.Auditorium_typename
from Auditorium as A1, Auditorium_type as A2
where A1.Auditorium_type=A2.Auditorium_type