select top 1
(select avg(Note) from PROGRESS Pr
where Pr.SUBJECT like 'йц') [йц],
(select avg(Note) from PROGRESS Pr
where Pr.SUBJECT like 'нюХо') [нюХо],
(select avg(Note) from PROGRESS Pr
where Pr.SUBJECT like 'ясад') [ясад]
from PROGRESS