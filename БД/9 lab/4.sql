Declare @z float, @t float=5, @x int =6;
if @t>@x 
set @z=POWER(sin(@t),2)
else if @t<@x
set @z=4*(@t+@x)
else	
set @z=1-exp(@x-2)
print 'z='+cast(@z as varchar(10));

DECLARE @a nvarchar(50) = 'Грудинский Павел Владимирович';

SET @a = ltrim(@a);
SET @a = rtrim(@a);
SET @a =
LEFT ( @a, CHARINDEX( ' ', @a ) ) +
LEFT ( RIGHT ( @a, LEN(@a) - CHARINDEX(' ', @a) ), 1 ) + '.' +
LEFT ( RIGHT ( @a, LEN(@a) - CHARINDEX(' ', @a, CHARINDEX (' ', @a) + 1 ) ), 1 ) + '.'
PRINT @a;

select 
BDAY,
NAME,
Year(getdate())-year(BDAY) [Age]
from 
STUDENT
Where 
MONTH(BDAY)=MONTH(getdate())+1
select 
S.Name,
P.SUBJECT,
S.Idgroup,
DAY(P.PDATE) as [DAY]
from STUDENT S inner join PROGRESS P
on S.IDSTUDENT=P.IDSTUDENT
Where S.IDGROUP=4 and P.SUBJECT='СУБД'