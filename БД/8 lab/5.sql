Create View [Дисциплины](код, [наименование дисциплины], [код кафедры])
as select TOP 100 Subject, Subject_name, Pulpit
from Subject
order by Subject_name