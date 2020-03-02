select Auditorium_type, Auditorium_capacity
from Auditorium A1
where Auditorium=(select top(1) Auditorium from Auditorium A2
where A2.Auditorium_capacity=A1.Auditorium_capacity )
order by Auditorium_capacity desc