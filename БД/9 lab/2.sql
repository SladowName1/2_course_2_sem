Declare @y1 numeric(8,3)=(select cast(sum(Auditorium_capacity)
as numeric(8,3)) from Auditorium), @y2 real, @y3 numeric(8,3), @y4 real, @y5 real
if @y1>200
begin
Select @y2=(select cast(count(*) as numeric(8,3)) from Auditorium),
@y3=(select cast(avg(Auditorium_capacity) as numeric(8,3))from Auditorium)
Set @y4=(select cast(count(*) as numeric(8,3)) from Auditorium where Auditorium_capacity<@y3)
select @y5=@y4/@y2*100
select @y1 '����� �����', @y2 '����������', @y3 '������� ��������', @y4 '���������� ��������� � ������������ ������ �������', @y5 '������� ���� ���������'
end
else if @y1<200 print '����� ����������� ������ 200'