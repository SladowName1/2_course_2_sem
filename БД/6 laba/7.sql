select P1.SUBJECT, Note from PROGRESS P1
Where P1.Note >=all
(select Note from PROGRESS P
where P.SUBJECT like 'Ï%')