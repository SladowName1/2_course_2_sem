declare @ti int, @tn int
declare LastT cursor local dynamic
for select Note, IDSTUDENT from PROGRESS for update
open LastT
fetch LastT into @tn, @ti
delete PROGRESS where Note<=4 
fetch LastT into @ti,@tn
update PROGRESS set Note=Note+1 where IDSTUDENT=1016
close LastT