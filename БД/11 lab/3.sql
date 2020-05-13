declare @tid char(10), @tnm char(40), @tgn char(20);
declare Sub Cursor local static
for select Subject, Pulpit, Subject_name from Subject
open Sub
print 'Counter string '+cast(@@Cursor_rows as varchar(5));
update Subject set Subject ='ннннО' where Subject='ясад'
delete Subject where Subject='йЦХЦ'
fetch Sub into @tid, @tnm,@tgn;
while @@fetch_status=0
begin 
print @tid+''+@tnm+''+@tgn;
fetch Sub into @tid, @tnm, @tgn;
end;
Close Sub