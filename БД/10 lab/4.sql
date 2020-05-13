create table #L10T4
( Tkey int,
CC int identity(12,132),
Tf varchar(100)
);

set nocount on;
declare @i int =0;
while @i<11000
begin
insert #L10T4(Tkey,Tf) values (floor(31231*rand()),replicate('string',10))
set @i=@i+1;
end;

select * from #L10T4 where Tkey >1000 and CC<1230

Create index #L10T4L on #L10T4(Tkey) where (Tkey>1000 and Tkey<5000);