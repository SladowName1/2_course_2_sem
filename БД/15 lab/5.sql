alter table Teacher  add constraint Gender check(Gender='æ' or Gender='ì')
go
update Teacher set Gender='ô' where Pulpit='æ'