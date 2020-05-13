create trigger Tr_T7
on Auditorium after Insert, Delete, Update
as declare @c int=(select sum(Auditorium_capacity) from Auditorium)
if(@c>10000)
begin
raiserror('Total capacity dont must>10000',10,1)
rollback
end
return
update Auditorium set Auditorium_capacity=9999
where Auditorium_type='À '