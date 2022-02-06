using System;

namespace Project2
{

    public class Teacher : IPerson
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
        // дополнительно: кафедра, стаж, должность(enum)
        public string Department { get; }
        public int Experience //считается через Start
        { 
            get => DateDifference.YearsFromSometimesToToday(Start);
        }
        public DateTime Start { get; }
        //должности: ректор, декан, заместитель декана, преподаватель
        public enum Posts
        {
            Rector, Dean, DepytyDean, Lecturer
        }
        public Posts Post { get; }

        /*--------------конструктор--------------*/
        public Teacher(string name, string patronymic, string lastname, DateTime date, string departament, DateTime start, Posts post )
        {
            this.Name = name;
            this.Patronymic = patronymic;
            this.Lastname = lastname;
            this.Date = date;
            this.Department = departament;
            this.Start = start;
            this.Post = post;
        }
        /*--------------статическая функция создания из строки--------------*/
        public static Teacher Parse(string line)
        {
            string[] elem = line.Split(',');
            Teacher teacher = new Teacher(
                     elem[0], elem[1], elem[2],DateTime.Parse(elem[3]),
                     elem[4], DateTime.Parse(elem[5]), 
                     (Posts)Enum.Parse(typeof(Posts), elem[6])
                     );
            return teacher;
        }
        /*--------------переопеределение функции--------------*/
        public override string ToString()
        {
            string result = $"{this.Name} {this.Patronymic} {this.Lastname}, {this.Date:dd MMM yyyy}, {this.Age} years old, Departament:{this.Department}, Beginning of work: {this.Start}, Expirience: {this.Experience}, Post: {this.Post}";
            return result;
        }
        /*--------------есть ли в базе данных--------------*/
        public bool InTheDatabase(Teacher teacher)
        {
            if (Name == teacher.Name && Patronymic == teacher.Patronymic && Lastname == teacher.Lastname && Date == teacher.Date &&
                 Department == teacher.Department && Start == teacher.Start && Post == teacher.Post)
            {
                return true;
            }
            else return false;
        }
    }
}

