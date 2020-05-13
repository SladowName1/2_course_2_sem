create table #L10T3
( Tkey int,
CC int identity(12,132),
Tf varchar(100));

set nocount on;
declare @i int =0;
while @i<11000
begin
insert #L10T3(Tkey,Tf) values (floor(31231*rand()),replicate('string',10))
set @i=@i+1;
end;

select * from #L10T3
where Tkey>100 and CC>1231

create index #L10T3L on #L10T3(Tkey) include (CC)

select CC from #L10T3 where Tkey>1000