declare @t int, @tv char(20);
declare Sub cursor local dynamic Scroll
for select ROW_NUMBER() over(order by Subject) S, Subject from dbo.Subject
open Sub;
fetch Sub into @t, @tv;
print 'next string :'+cast(@t as varchar(30))+rtrim(@tv);
fetch last from sub into @t, @tv;
print 'last string '+cast(@t as varchar(30))+rtrim(@tv);
close Sub;