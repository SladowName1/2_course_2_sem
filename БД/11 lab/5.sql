declare @t char(20), @tc date, @tv int
declare Sub cursor local dynamic
for select Subject, PDATE, Note from PROGRESS for update;
open Sub
fetch Sub into @t,@tc,@tv;
delete PROGRESS where current of Sub;
fetch Sub into @t, @tc,@tv;
update PROGRESS set note=note+1 where Current of Sub
close Sub