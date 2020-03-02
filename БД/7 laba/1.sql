select min(Auditorium_capacity) [min],
max(Auditorium_capacity) [max],
sum(Auditorium_capacity) [sum],
count(*) [count]
from Auditorium