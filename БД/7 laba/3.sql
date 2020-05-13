use GR_Univer
select *
from 
(
select Case 
	when Note between 4 and 5 then '4-5'
	when Note between 6 and 7 then '6-7'
	when Note=8 then '8'
	else '9' 
	end [Note], count (*) [Counter]
From PROGRESS group by case 
	when Note between 4 and 5 then '4-5'
	when Note between 6 and 7 then '6-7'
	when Note=8 then '8'
	else '9'
	end
) as T
Order by case [Note]
when '4-5' then 4
when '6-7' then 3
when '8' then 2
when '9' then 1
else 0
end