create  trigger DDL_Unvir on database 
for DDL_DATABASE_LEVEL_EVENTS  as   
declare @t varchar(50) =  EVENTDATA().value('(/EVENT_INSTANCE/EventType)[1]', 'varchar(50)');
declare @t1 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectName)[1]', 'varchar(50)');
declare @t2 varchar(50) = EVENTDATA().value('(/EVENT_INSTANCE/ObjectType)[1]', 'varchar(50)'); 
if @t1 = 'GR_Univer'
begin
print '��� �������: '+@t;
print '��� �������: '+@t1;
print '��� �������: '+@t2;
raiserror( N'�������� � �������� F���������', 16, 1);  
rollback;    
end;

Alter table Auditorium drop column Auditorium_name
