set nocount on
if exists(select * from SYS.OBJECTS
where OBJECT_ID=object_id(N'DBO.GR'))
drop table GR
declare @c int , @flag char='f', @b int=0
set implicit_transactions on
create table GR(K int);
insert GR values (1),(3),(5);
set @c=(select count(*) from GR)
print 'Counter string in table GR '+cast(@c as varchar(2))
if @flag='c' commit
else rollback
set implicit_transactions off
if exists(select * from SYS.OBJECTS 
where OBJECT_ID=object_id(N'DBO.GR'))
print 'Table GR is'
else print 'Table GR isnt'
