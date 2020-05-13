Select Subject, Note,
(select count(*) from Progress) as Counter
from PROGRESS
Group by Note, Subject
Having Note=8 or Note=9