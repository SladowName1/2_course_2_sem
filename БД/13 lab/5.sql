create procedure Subject_reportt  @p CHAR(50)
   as  
   declare @rc int = 0;                            
   begin try    
      declare @tv char(20), @t char(300) = ' ';  
      declare ZkTov CURSOR  for 
      select Subject from Subject where Pulpit = @p;
      if not exists (select Subject from Subject where Pulpit=@p)
          raiserror('ошибка', 11, 1);
       else 
      open ZkTov;	  
  fetch  ZkTov into @tv;   
  print   'Selected Subject';   
  while @@fetch_status = 0                                     
   begin 
       set @t = rtrim(@tv) + ', ' + @t;  
       set @rc = @rc + 1;       
       fetch  ZkTov into @tv; 
    end;   
print @t;        
close  ZkTov;
    return @rc;
   end try  
   begin catch              
        print 'ошибка в параметрах' 
        if error_procedure() is not null   
  print 'имя процедуры : ' + error_procedure();
        return @rc;
   end catch; 


declare @v int
exec @v=[Subject_reportt] @p='ИСиТ'
print 'counter subject'+cast(@v as varchar(3))