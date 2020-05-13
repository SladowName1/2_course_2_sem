create table L10T5
(
Tkey int,
Tf varchar(100),
CC int identity(1,1)
)
set nocount on;
declare @i int=0;
while @i<10008
begin
insert L10T5(Tkey,Tf) values(floor(12313*rand()), replicate('string',10));
set @i=@i+1;
end;

select *
from L10T5
create index #L10T511 on dbo.L10T5(Tkey) where (Tkey>=1500 and Tkey<3000)

Select*
from L10T5
where Tkey>=200 and Tkey<3000
--insert top(10008) L10T5(Tkey,Tf) select Tkey, TF from L10T5
--Alter index #L10T511 on L10T5 reorganize
--Alter index #L10T511 on L10T5 rebuild 
--drop index #L10T511 on L10T5
--create index #L10T511 on L10T5(Tkey) with (fillfactor=65)
insert top(10008) L10T5(Tkey,Tf) select Tkey, TF from L10T5
SELECT name [Индекс], avg_fragmentation_in_percent [Фрагментация (%)]
        FROM sys.dm_db_index_physical_stats(DB_ID(N'L10T5'), 
        OBJECT_ID(N'#L10T511'), NULL, NULL, NULL) ss
        JOIN sys.indexes ii on ss.object_id = ii.object_id and ss.index_id = ii.index_id  
        WHERE name is not null;
