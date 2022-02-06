using System;

namespace Project2
{
	public class Student : IPerson
	{
        /*--------------поля--------------*/
        public string Name { get; }
        public string Patronymic { get; }
        public string Lastname { get; }
        public DateTime Date { get; }
        public int Age //считается через Date
        {
            get => DateDifference.YearsFromSometimesToToday(Date);
        }
        /*дополнительно: курс, группа, средний балл*/
        public byte Course { get; }
        public string Group { get; }
        public int GPA { get; }

        /*--------------конструктор--------------*/
        public Student(string name, string patronymic, string lastname, DateTime date,byte course, string group, int gpa)
        {
            this.Name = name;
            this.Patronymic = patronymic;
            this.Lastname = lastname;
            this.Date = date;
            this.Course = course;
            this.Group = group;
            this.GPA = gpa;
        }
        /*--------------статическая функция создания из строки--------------*/
        public static Student Parse(string line)
        {
            string[] elem = line.Split(',');
            Student student = new Student(
                     elem[0], elem[1], elem[2], DateTime.Parse(elem[3]),
                     Byte.Parse(elem[4]), elem[5],
                     Convert.ToInt32(elem[6])
                     );
            return student;
        }
        /*--------------переопеределение функции--------------*/
        public override string ToString()
        {
            string result = $"Full name: {this.Name} {this.Patronymic} {this.Lastname}, Birthday: {this.Date:dd MMM yyyy}, {this.Age} years old, Course:{this.Course}, Group: {this.Group}, GPA: {this.GPA}";
            return result;
        }
        /*--------------есть ли в базе данных--------------*/
        public bool InTheDatabase(Student student)
        {
            if (Name == student.Name && Patronymic == student.Patronymic &&Lastname == student.Lastname && Date == student.Date &&
                 Course == student.Course && Group == student.Group && GPA == student.GPA)
            {
                return true;
            }
            else return false;
        }
    }
}

