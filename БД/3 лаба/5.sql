use Грудинский_UNIVER;
Select * from Student;
Select номер_зачетки, Фамилия_студента from Student;
Select count(*) from Student;
Select Фамилия_студента [1 gruppa] from Student
Where Номер_группы=1;
Select Distinct Top(5) Фамилия_студента, Номер_группы from Student 
Order by Фамилия_студента Desc;