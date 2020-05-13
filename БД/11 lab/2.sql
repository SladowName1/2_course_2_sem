Declare Sub Cursor Local
for select Subject,Pulpit from Subject
declare @tv char (20), @cena char(20);
open Sub;
fetch Sub into @tv, @cena;
print '1.'+@tv+cast(@cena as varchar(6));
go 
declare @tv char (20), @cena char(20);
fetch Sub into @tv, @cena;
print '2.'+@tv+cast(@cena as varchar(6));
go

Declare Sub2 Cursor Global
for select Subject, Pulpit from Subject 
declare @tv char (20), @cena char(20);
open Sub2;
fetch Sub2 into @tv, @cena;
print '1.'+@tv+cast(@cena as varchar(6));
go 
declare @tv char (20), @cena char(20);
fetch Sub2 into @tv, @cena;
print '2.'+@tv+cast(@cena as varchar(6));
go