create table #Exxplre
(
Tind int,
TField varchar(100)
);
Set nocount on
Declare @a int=1;
While @a<10
begin 
insert #Exxplre(Tind, TField)
values (floor(30000*rand()),replicate('строка',1));
if(@a%100=0)
print @a;
set @a=@a+1;
end;