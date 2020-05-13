create trigger Tr_T8
on Faculty instead of Delete
as raiserror (N'Delete dont be go',10,1)
return
delete Faculty where Faculty='хр'

drop trigger Tr_T8,Tr_T7,Tr_Teacher_Del1,Tr_Teacher_Del2,Tr_Teacher_Del3,
Tr_teacher, Tr_Teacher_updd,Tr_Teacher_upd,Tr_Teacher_Dell, Tr_Teacher_Del, Tr_Teacher_ins