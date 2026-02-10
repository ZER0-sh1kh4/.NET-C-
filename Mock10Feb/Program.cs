
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
                            Console.Write("Course Code: ");
                            string courseCode = Console.ReadLine();

                            Console.Write("Course Name: ");
                            string courseName = Console.ReadLine();

                            Console.Write("Credits: ");
                            int credits = int.Parse(Console.ReadLine());

                            Console.Write("Max Capacity (press Enter for 50): ");
                            string capInput = Console.ReadLine();
                            int maxCapacity = string.IsNullOrWhiteSpace(capInput) ? 50 : int.Parse(capInput);

                            Console.Write("Prerequisites (comma separated, Enter for none): ");
                            string preInput = Console.ReadLine();
                            List<string> prerequisites = string.IsNullOrWhiteSpace(preInput)? new List<string>(): preInput.Split(',').Select(p => p.Trim()).ToList();
                            system.AddCourse(courseCode, courseName, credits, maxCapacity, prerequisites);
                            Console.WriteLine("Course added successfully.");
                            break;

                        case "2":
                            Console.Write("Student ID: ");
                            string studentId = Console.ReadLine();

                            Console.Write("Student Name: ");
                            string studentName = Console.ReadLine();

                            Console.Write("Major: ");
                            string major = Console.ReadLine();

                            Console.Write("Max Credits (press Enter for 18): ");
                            string creditInput = Console.ReadLine();
                            int maxCredits = string.IsNullOrWhiteSpace(creditInput) ? 18 : int.Parse(creditInput);

                            Console.Write("Completed Courses (comma separated, Enter for none): ");
                            string compInput = Console.ReadLine();
                            List<string> completedCourses = string.IsNullOrWhiteSpace(compInput)? new List<string>(): compInput.Split(',').Select(p => p.Trim()).ToList();
                            system.AddStudent(studentId, studentName, major, maxCredits, completedCourses);
                            Console.WriteLine("Student added successfully.");
                            break;

                        case "3":
                            Console.Write("Student ID: ");
                            studentId = Console.ReadLine();

                            Console.Write("Course Code: ");
                            courseCode = Console.ReadLine();

                            system.RegisterStudentForCourse(studentId, courseCode);
                            break;

                        case "4":
                            Console.Write("Student ID: ");
                            studentId = Console.ReadLine();

                            Console.Write("Course Code: ");
                            courseCode = Console.ReadLine();

                            system.DropStudentFromCourse(studentId, courseCode);
                            break;

                        case "5":
                            system.DisplayAllCourses();
                            break;

                        case "6":
                            Console.Write("Student ID: ");
                            studentId = Console.ReadLine();
                            system.DisplayStudentSchedule(studentId);
                            break;

                        case "7":
                            system.DisplaySystemSummary();
                            break;

                        case "8":
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
