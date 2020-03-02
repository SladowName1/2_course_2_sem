select A2.AUDITORIUM_TYPENAME,
max(A1.Auditorium_capacity) [max],
min(A1.Auditorium_capacity) [min],
sum(A1.Auditorium_capacity) [sum],
avg(A1.Auditorium_capacity) [avg],
count(*) [count]
from Auditorium A1 inner join Auditorium_type A2
on A1.Auditorium_type=A2.Auditorium_type
group by A2.Auditorium_typename