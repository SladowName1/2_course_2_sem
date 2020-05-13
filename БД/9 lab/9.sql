begin Try
Update Auditorium_type set Auditorium_type='À¡-X'
where Auditorium_type='À '
end try
begin catch
print Error_number()
print Error_message()
print Error_line()
print Error_procedure()
print Error_severity()
print Error_state()
end catch