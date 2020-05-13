create table #L10T2
( TKey int,
	CC int identity(10,1),
	Tf varchar(100)
);

set nocount on;
declare @i int=0;
while @i<33454
begin
insert #L10T2(TKey,Tf) 
values(floor(31341*rand()),replicate('string',10));
set @i=@i+1;
end;

select count(*) as Counter from #L10T2
Select * 
from #L10T2
where TKey between 2000 and 50002

--Create index #L10T2L on #L10T2(Tkey,CC)

SELECT * from  #L10T2 where  TKEY > 1500 and  CC < 4500;  

select * from #L10T2 where TKey=2502 and CC>10