exec sp_helpindex'Auditorium'
create table #L10T1
(
	Tind int,
	Tfield varchar(100)
);
Set nocount on
Declare @i int=0;
while @i<1000
begin
insert #L10T1(Tind,Tfield)
values(floor(20000*rand()),replicate('string',10));
if(@i%100=0) print @i;
set @i=@i+1;
end;b

select * from #L10T1 where Tind between 1500 and 2000 order by Tind

Create clustered index #L10T1L on #L10T1(Tind asc)