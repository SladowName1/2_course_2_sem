alter table Teacher  add constraint Gender check(Gender='�' or Gender='�')
go
update Teacher set Gender='�' where Pulpit='�'