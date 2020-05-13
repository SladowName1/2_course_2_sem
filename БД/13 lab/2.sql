alter procedure PSubject @p varchar(20), @c int output
as begin
declare @k int=(select count(*) from Subject)
print 'parametrs: @p='+@p+',@c='+cast(@c as varchar(3))
select * from Subject where Subject=@p
set @c=@@rowcount
return @k
end

declare @k int =0, @r int =0,@p varchar(20)
exec @k=PSubject @p='нно', @c=@r output
print 'counter all subject= '+cast(@k as varchar(3))
print 'counter subject'+cast(@p as varchar(3))+'='+cast(@r as varchar(3))