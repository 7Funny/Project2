using System;
using System.IO;
using System.Collections.Generic;

namespace Project2
{
    class Program
    {
        public static void Main()
        {

            IUniversity university = new University();

            /*----------------------ADD----------------------*/
            List<Teacher> teacher = new List<Teacher>();
            foreach (string line in File.ReadAllLines("teachers.txt"))
                teacher.Add(Teacher.Parse(line));
            List<Student> student = new List<Student>();
            foreach (string line in File.ReadAllLines("students.txt"))
                student.Add(Student.Parse(line));

            /*----------------------Menu----------------------*/
            Console.WriteLine("0. Display command menu");
            Console.WriteLine("1. ADD student or teacher to database");
            Console.WriteLine("2. REMOVE student or teacher to database");
            Console.WriteLine("3. GET all information about students and/or teachers");
            Console.WriteLine("4. FIND someone by last name or teacher by department");
            Console.WriteLine("5. LOG OFF");

            bool trueNumber = true;
            while (trueNumber)
            {
                Console.WriteLine("Enter command number >>");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 0:
                        Console.WriteLine("0. Display command menu");
                        Console.WriteLine("1. ADD student or teacher to database");
                        Console.WriteLine("2. REMOVE student or teacher to database");
                        Console.WriteLine("3. GET all information about students and/or teachers");
                        Console.WriteLine("4. FIND someone by last name or teacher by department");
                        Console.WriteLine("5. LOG OFF");
                        break;
                    /*----------------------ADD----------------------*/
                    case 1:
                        Console.WriteLine("     1. ADD student to database");
                        Console.WriteLine("     2. ADD teacher to database");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                Console.WriteLine("Format:[Name],[Patronymic],[Last name],[Birthday],[Course],[Group],[GPA]");
                                Console.WriteLine("Explanation:[string],[string],[string],[00.00.0000],[byte],[string],[int]");
                                string AddStudent = Console.ReadLine();
                                try
                                {
                                    university.Add(Student.Parse(AddStudent));
                                    //File.AppendAllText("out.txt", $"{AddStudent.ToString() + "\n"}");
                                    foreach (var SomeStudent in university.Students)
                                        if (SomeStudent.InTheDatabase(Student.Parse(AddStudent)))
                                        {
                                            Console.WriteLine(">> Student successfully added to database");
                                        } else Console.WriteLine(">> Unsuccessfully");
                                }
                                catch
                                {
                                    Console.WriteLine(">> Invalid input format");
                                }
                                break;
                            case 2:
                                Console.WriteLine("Format:[Name],[Patronymic],[Last name],[Birthday],[Departament],[Beginning of work],[Post]");
                                Console.WriteLine("Explanation:[string],[string],[string],[00.00.0000],[string],[00.00.0000],[Rector|Dean|DepytyDean|Lecturer]");
                                string AddTeacher = Console.ReadLine();
                                try
                                {
                                    university.Add(Teacher.Parse(AddTeacher));
                                    foreach (var SomeTeacher in university.Teachers)
                                        if (SomeTeacher.InTheDatabase(Teacher.Parse(AddTeacher)))
                                        {
                                            Console.WriteLine(">> Teacher successfully added to database");
                                        }else Console.WriteLine(">> Unsuccessfully");
                                }
                                catch
                                {
                                    Console.WriteLine(">> Invalid input format");
                                }
                                break;
                            default:
                                Console.WriteLine(">> Wrong command number!");
                                break;
                        }
                        break;
                    /*----------------------REMOVE----------------------*/
                    case 2:
                        Console.WriteLine("     1. REMOVE student to database");
                        Console.WriteLine("     2. REMOVE teacher to database");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                Console.WriteLine("Format:[Name],[Patronymic],[Last name],[Birthday],[Course],[Group],[GPA]");
                                Console.WriteLine("Explanation:[string],[string],[string],[00.00.0000],[byte],[string],[int]");
                                string RemoveStudent = Console.ReadLine();
                                foreach(var SomeStudent in university.Students)
                                    
                                if (SomeStudent.InTheDatabase(Student.Parse(RemoveStudent)))
                                {
                                    try
                                    {
                                         university.Remove(Student.Parse(RemoveStudent));
                                         Console.WriteLine(">> Student successfully removed to database");
                                    }
                                    catch
                                    {
                                        Console.WriteLine(">> Invalid input format");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(">> Student with such data is not in the database");
                                }
                                
                                break;
                            case 2:
                                Console.WriteLine("Format:[Name],[Patronymic],[Last name],[Birthday],[Departament],[Beginning of work],[Post]");
                                Console.WriteLine("Explanation:[string],[string],[string],[00.00.0000],[string],[00.00.0000],[Rector|Dean|DepytyDean|Lecturer]");
                                string RemoveTeacher = Console.ReadLine();
                                foreach(var SomeTeacher in university.Teachers)
                                    
                                if (SomeTeacher.InTheDatabase(Teacher.Parse(RemoveTeacher)))
                                {
                                    try
                                    {
                                         university.Remove(Teacher.Parse(RemoveTeacher));
                                         Console.WriteLine(">> Student successfully removed to database");
                                    }
                                    catch
                                    {
                                        Console.WriteLine(">> Invalid input format");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(">> Teacher with such data is not in the database");
                                }
                               
                                break;
                            default:
                                Console.WriteLine(">> Wrong command number!");
                                break;
                        }
                        break;
                    /*----------------------GET----------------------*/
                    case 3:
                        Console.WriteLine("     1. GET all information about students");
                        Console.WriteLine("     2. GET all information about teachers");
                        Console.WriteLine("     3. GET all information about all");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                Console.WriteLine("[In]");
                                foreach (var GetStudents in university.Students)
                                    Console.WriteLine("::" + GetStudents.ToString());
                                break;
                            case 2:
                                Console.WriteLine("[In]");
                                foreach (var GetTeachers in university.Teachers)
                                    Console.WriteLine("::" + GetTeachers.ToString());
                                break;
                            case 3:
                                Console.WriteLine("[In]");
                                foreach (var GetAll in university.Persons)
                                    Console.WriteLine("::" + GetAll.ToString());
                                break;
                            default:
                                Console.WriteLine(">> Wrong command number!");
                                break;
                        }
                        break;
                    /*----------------------FIND----------------------*/
                    case 4:
                        Console.WriteLine("     1. FIND someone by last name");
                        Console.WriteLine("     2. FIND teacher by department");
                        switch (Convert.ToInt32(Console.ReadLine()))
                        {
                            case 1:
                                Console.WriteLine("Enter last name without spaces >>");
                                string FindLastname = Console.ReadLine();
                                foreach (var FindSomeone in university.FindByLastName(FindLastname))
                                    Console.WriteLine("::" + FindSomeone.ToString());
                                Console.WriteLine("[In]");
                                break;
                            case 2:
                                Console.WriteLine("Enter department without spaces >>");
                                string FindDepartment = Console.ReadLine();
                                foreach (var FindTeacher in university.FindByDepartment(FindDepartment))
                                    Console.WriteLine("::" + FindTeacher.ToString());
                                Console.WriteLine("[In]");
                                break;
                            default:
                                Console.WriteLine(">> Wrong command number!");
                                break;
                        }
                        break;
                    /*----------------------LOG OFF----------------------*/
                    case 5:
                        trueNumber = false;
                        break;
                    default:
                        Console.WriteLine(">> Wrong command number!");
                        break;
                }
            }
        }
    }
}
