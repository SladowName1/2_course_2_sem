select top 1
(select avg(Note) from PROGRESS Pr
where Pr.SUBJECT like '��') [��],
(select avg(Note) from PROGRESS Pr
where Pr.SUBJECT like '����') [����],
(select avg(Note) from PROGRESS Pr
where Pr.SUBJECT like '����') [����]
from PROGRESS