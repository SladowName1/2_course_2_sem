--CREATE Function PULPCOUNT(@fac char(10)) RETURNS int AS
--	BEGIN
--		RETURN
--		(
--			SELECT COUNT(*)
--			FROM PULPIT
--			WHERE PULPIT.Faculty = @fac
--		)
--	END;
--GO

--CREATE Function GROUPCOUNT(@fac char(10)) RETURNS int AS
--	BEGIN
--		RETURN
--		(
--			SELECT COUNT(*)
--			FROM IDGroup
--			WHERE IDGroup.Faculty = @fac
--		)
--	END;
--GO

--CREATE Function PROFCOUNT(@fac char(10)) RETURNS int AS
--	BEGIN
--		RETURN
--		(
--			SELECT COUNT(*)
--			FROM PROFESSION
--			WHERE PROFESSION.Faculty = @fac
--		)
--	END;
--GO

create function FACULTY_REPORT(@c int) returns @fr table
(
	[Факультет] varchar(50),
	[Количество кафедр] int,
	[Количество групп]  int,
	[Количество студентов] int,
	[Количество специальностей] int
) AS
	begin
		declare cc CURSOR static for
			select FACULTY
			from FACULTY
			where dbo.COUNT_STUDENT(Faculty) > @c;
		declare @f varchar(30);
		open cc;
			fetch cc into @f;
			while @@fetch_status = 0
				begin
					insert @fr values
					(
						@f,
						dbo.PULPCOUNT(@f),
						dbo.GROUPCOUNT(@f),	
						dbo.COUNT_STUDENT(@f),
						dbo.PROFCOUNT(@f)
					); 
					fetch cc into @f;  
				end;
		return; 
	end;
GO

SELECT * FROM FACULTY_REPORT(0)































create function FACULTY_REPORT(@c int) returns @fr table
	                        ( [Факультет] varchar(50), [Количество кафедр] int, [Количество групп]  int, 
	                                                                 [Количество студентов] int, [Количество специальностей] int )
	as begin 
                 declare cc CURSOR static for 
	       select FACULTY from FACULTY 
                                                    where dbo.COUNT_STUDENT(FACULTY, default) > @c; 
	       declare @f varchar(30);
	       open cc;  
                 fetch cc into @f;
	       while @@fetch_status = 0
	       begin
	            insert @fr values( @f,  (select count(PULPIT) from PULPIT where FACULTY = @f),
	            (select count(IDGROUP) from GROUPS where FACULTY = @f),   dbo.COUNT_STUDENTS(@f, default),
	            (select count(PROFESSION) from PROFESSION where FACULTY = @f)   ); 
	            fetch cc into @f;  
	       end;   
                 return; 
	end;

