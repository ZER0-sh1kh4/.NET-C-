--Question 2
alter table [dbo].[Student_Master] add RewardPoints int default 0

--Question 3
alter table [dbo].[Student_Master] add constraint Reward check ([RewardPoints] between 0 and 100)

--Question 4
select StudentName, CourseName, TrainerName, ExamMonth , ExamYear, Marks from [dbo].[Student_Master] 
inner join Exam on Student_Master.StudentId=Exam.StudentId inner join Course on
Exam.CourseId=Course.CourseId inner join [dbo].[Trainer_Master] on
Course.TrainerId=Trainer_Master.TrainerId

--Question 5
select StudentId, sum(Marks) as TotalMarks from Exam where ExamYear=year(getdate()) group by StudentId

--Question 6
select Student_Master.StudentName, left(Student_Master.StudentName,3)+substring(Course.CourseName,1,2)+cast(Student_Master.StudentId as varchar) as LoginId 
from Student_Master inner join Course on
Student_Master.StudentId=Course.CourseId

--Question 7
select avg(TotalMarks) as average from(select sum(Marks) as TotalMarks from Exam group by StudentId ) as T

select StudentName , sum(Marks) as TotalMarks from Student_Master 
inner join Exam on Student_Master.StudentId=Exam.StudentId group by StudentName having Sum(Marks)>
(select avg(TotalMarks) from (Select Sum(Marks) as TotalMarks from Exam group by StudentId)as T)

--Question 8
select StudentName ,Marks,'High' as category from Student_Master inner join Exam on 
Student_Master.StudentId=Exam.StudentId where Marks>80 union
select StudentName ,Marks,'Low' as category from Student_Master inner join Exam on 
Student_Master.StudentId=Exam.StudentId where Marks<40

--Question 9
create trigger trg_UpdateRewardPoint on Exam after insert
as 
begin
update S /*Student_Master*/
set RewardPoints = coalesce(S.RewardPoints,0) +
case
when I.Marks>=80 then 10 /*I->Exam*/
when I.Marks>=60 then 5
else 2
end
from Student_Master S inner join inserted I on S.StudentId = I.StudentId;
END;

INSERT INTO Exam (ExamId,CourseId, ExamMonth, ExamYear, Marks, StudentId)
VALUES (8,1, 4, 2026, 88, 1);

INSERT INTO Exam (ExamId,CourseId, ExamMonth, ExamYear, Marks, StudentId)
VALUES (9,2, 4, 2026,65, 2);

select * from Student_Master
select * from Exam

--Question 10
select StudentName, JoiningDate,Datediff(year,JoiningDate, getdate()) as yearofstudy,
case when datediff(year, JoiningDate, getdate())>=3
then 10000
else 0
end as ScholarshipAmount,
coalesce(RewardPoints,0) as RewardPoints from Student_Master;



