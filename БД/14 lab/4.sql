create function FcTeacher(@p varchar(20)) returns int
as begin
declare @rc int=(select count(*) from Teacher
where Pulpit=isnull(@p,Teacher_name))
return @rc
end

select *, dbo.FcTeacher(Pulpit) from Teacher