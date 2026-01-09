### Problem Statement

### Code
```csharp
public delegate bool IsEligibleforScholarship(Student std);
public class Student
{
    public int RollNo{get; set;}
    public string Name{get; set;}
    public int Marks{get; set;}
    public char SportsGrade{get; set;}

    public static string GetEligibleStudents(List<Student> studentsList, IsEligibleforScholarship isEligible)
    {
        List<string> eligible=new List<string>();
        foreach(var s in studentsList)
        {
            if (isEligible(s))
            {
                eligible.Add(s.Name);
            }  
        }
       return string.Join(", ", eligible);
    }
}
class Program
{
    public static bool ScholarshipEligibility(Student std)
    {
        return std.Marks>80 && std.SportsGrade=='A';
    }
    static void Main()
    {
        List<Student> s=new List<Student>();
        Student obj1=new Student()
        {
            RollNo=1,Name="Raj",Marks=75,SportsGrade='A'
        };
        Student obj2=new Student()
        {
            RollNo=2,Name="Rahul",Marks=82,SportsGrade='A'

        };
        Student obj3=new Student()
        {
            RollNo=3,Name="Kiran",Marks=89,SportsGrade='B'

        };
        Student obj4=new Student()
        {
            RollNo=4,Name="Sunil",Marks=86,SportsGrade='A'

        };
        s.Add(obj1);
        s.Add(obj2);
        s.Add(obj3);
        s.Add(obj4);
        IsEligibleforScholarship del = ScholarshipEligibility;

        string result = Student.GetEligibleStudents(s, del);

        Console.WriteLine(result);
    }

}
```
