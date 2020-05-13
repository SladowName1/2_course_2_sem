alter procedure PSubject @p varchar(20)
as begin
declare @k int=(select count(*) from Subject)
select * from Subject where Subject=@p
end
create table #Subject 
(
Subject varchar(10) primary key,
Subject_name varchar(30),
Pulpit varchar(10)
)

insert #Subject exec PSubject @p='ÁÄ'
insert #Subject exec PSubject @p='ÈÃ'

select * from #Subject