DELETE FROM Students
WHERE NOT EXISTS (SELECT 1 FROM Marks WHERE Marks.StudentID = Students.StudentID);
