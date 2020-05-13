create function FSubjects (@p varchar(20)) returns varchar(300)
as 
begin
declare @tv varchar(20)
declare @t varchar(300)='Subject name: '
declare PSub cursor local
for select Subject_name from Subject
where Pulpit=@p
open PSub
fetch PSub into @tv
while @@fetch_status=0
begin
set @t=@t+','+rtrim(@tv)
fetch PSub into @tv
end
return @t
end

select Subject_name,dbo.Fsubjects(Pulpit) from Subject
declare @f varchar(300)=dbo.FSubjects('ศั่า')
print @f