select * from Test1 full outer join Test2
on Test1.Test1_number=Test2.Test2_number
where Test2.Test2 is null
select * from Test1 full outer join Test2
on Test1.Test1_number=Test2.Test2_number
where Test2.Test2 is not null
select * from Test1 full outer join Test2
on Test1.Test1_number=Test2.Test2_number
