Declare @x int =(select avg(Note) from PROGRESS)
if(@x>6)
print '���� ��������� ����� ����'
else
print '���� �����'