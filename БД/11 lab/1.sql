Declare @tv char (20), @t char(300)='';
Declare Sub Cursor
for select Subject from Subject
Where Pulpit='ศั่า'
Open Sub
fetch Sub into @tv;
print 'Subjects';
while @@FETCH_STATUS=0
begin
set @t=rtrim(@tv)+','+@t;
fetch Sub into @tv;
end;
print @t;
close Sub