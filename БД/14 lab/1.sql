alter function Count_Student(@faculty char(20)) returns int
as begin declare @rc int=0
set @rc=(select count(*) [Counter]
from STUDENT s inner join IDGroup g
on g.IDGroup=s.IDGROUP inner join Faculty f
on f.Faculty=g.Faculty
where f.Faculty=@faculty)
return @rc
end

declare @f int =dbo.Count_Student('»›‘')
print 'Counter'+ cast(@f as varchar(4))

alter function Count_Student(@faculty char(20), @prof varchar(20)=Null) returns int
as begin declare @rv int=0
set @rv=(select count(*) [Counter]
from STUDENT s inner join IDGroup g
on g.IDGroup=s.IDGROUP inner join Faculty f
on f.Faculty=g.Faculty inner join Profession p
on f.Faculty=p.Faculty
where f.Faculty=@faculty and p.Profession=@prof)
return @rv
end

declare @d int =dbo.Count_Student('’“Ë“','1-36 01 08 ')
print 'Counter'+ cast(@d as varchar(4))
