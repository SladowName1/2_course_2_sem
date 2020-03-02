select P1.SUBJECT, Note from PROGRESS P1
Where P1.Note >any
(select Note from PROGRESS P
where P.SUBJECT like 'Ï%')