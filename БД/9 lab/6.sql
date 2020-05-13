select Case
	when Note between 1 and 4 then 'от 1 до 4'
	when Note between 5 and 7 then 'от 4 до 7'
	when Note between 8 and 10 then '8 до 10'
	else '0'
	end note, count(*) [Counter]
from PROGRESS
Group by Case
	when Note between 1 and 4 then 'от 1 до 4'
	when Note between 5 and 7 then 'от 4 до 7'
	when Note between 8 and 10 then '8 до 10'
	else '0'
	end