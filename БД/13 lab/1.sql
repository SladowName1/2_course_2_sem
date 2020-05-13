create procedure PSubject
as 
begin
declare @k int =(select count(*) from Subject)
select * from Subject
return @k
end

declare @x int =0
exec @x=PSubject
print 'counter string '+ cast(@x as varchar(10))
