select Case
	when Note between 1 and 4 then '�� 1 �� 4'
	when Note between 5 and 7 then '�� 4 �� 7'
	when Note between 8 and 10 then '8 �� 10'
	else '0'
	end note, count(*) [Counter]
from PROGRESS
Group by Case
	when Note between 1 and 4 then '�� 1 �� 4'
	when Note between 5 and 7 then '�� 4 �� 7'
	when Note between 8 and 10 then '8 �� 10'
	else '0'
	end