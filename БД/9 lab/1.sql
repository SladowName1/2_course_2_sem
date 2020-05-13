Declare @ch char='A',
@vch varchar='ABB',
@date datetime,
@t time,
@i int,
@si smallint,
@ti tinyint,
@n numeric(12,5);
set @date='20-12-2001';
set @t='18:13';
select @i=15, @si=16,@ti=17;
select @ch, @vch, @date, @t;
print @i;
print @ti;
print @si;
print @n;
