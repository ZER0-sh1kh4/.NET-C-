
using System;
using System.Collections.Generic;
using System.Linq;

namespace University_Course_Registration_System
{
     // =========================
    // Program (Menu-Driven)
    // =========================
    class Program
    {
        static void Main()
        {
            UniversitySystem system = new UniversitySystem();
            bool exit = false;

            Console.WriteLine("Welcome to University Course Registration System");

            while (!exit)
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Student");
                Console.WriteLine("3. Register Student for Course");
                Console.WriteLine("4. Drop Student from Course");
                Console.WriteLine("5. Display All Courses");
                Console.WriteLine("6. Display Student Schedule");
                Console.WriteLine("7. Display System Summary");
                Console.WriteLine("8. Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                try
                {
                    // TODO:
                    // Implement menu handling logic using switch-case
                    // Prompt user inputs
                    // Call appropriate UniversitySystem methods
                    
                        switch (choice)
                        {
                            case "1":
                                Console.Write("Code: ");
                                string courseCode = Console.ReadLine();

                                Console.Write("Name: ");
                                string courseName = Console.ReadLine();

                        Console.Write("Credits: ");
                        int courseCredits = int.Parse(Console.ReadLine());

                        system.AddCourse(courseCode, courseName, courseCredits);
                        break;

                    case "2":
                        Console.Write("Enter Student ID: ");
                        string studentId = Console.ReadLine();

                        Console.Write("Enter Student Name: ");
                        string studentName = Console.ReadLine();

                        Console.Write("Enter Student Major: ");
                        string studentMajor = Console.ReadLine();

                        system.AddStudent(studentId, studentName, studentMajor);
                        break;

                    case "3":
                        Console.Write("Enter Student ID: ");
                        studentId = Console.ReadLine();

                        Console.Write("Enter Course Code: ");
                        courseCode = Console.ReadLine();

                        bool registrationResult = system.RegisterStudentForCourse(studentId, courseCode);
                        Console.WriteLine(registrationResult ? "Registered successfully" : "Registration failed");
                        break;

                    case "4":
                        Console.Write("Enter Student ID: ");
                        studentId = Console.ReadLine();

                        Console.Write("Enter Course Code: ");
                        courseCode = Console.ReadLine();

                        bool dropResult = system.DropStudentFromCourse(studentId, courseCode);
                        Console.WriteLine(dropResult ? "Dropped successfully" : "Drop failed");
                        break;

                    case "5":
                        system.DisplayAllCourses();
                        break;

                    case "6":
                        Console.Write("Enter Student ID: ");
                        studentId = Console.ReadLine();
                        system.DisplayStudentSchedule(studentId);
                        break;

                    case "7":
                        system.DisplaySystemSummary();
                        break;

                    case "8":
                        exit = true;
                        Console.WriteLine("Exiting system...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;


                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}

