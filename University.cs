using System;
using System.Collections.Generic;
using System.Linq;

namespace Project2
{
    class University : IUniversity
    {
        private List<IPerson> persons = new List <IPerson>();
        
        /*отсортировать по дате рождения*/
        IEnumerable<IPerson> IUniversity.Persons 
        {
            get => persons.OrderBy(person => person.Date);
        }

        IEnumerable<Student> IUniversity.Students
        {
            get => persons.OfType<Student>().OrderBy(student => student.Date);
        }

        /*отсортировать по должности*/
        IEnumerable<Teacher> IUniversity.Teachers
        {
            get => persons.OfType<Teacher>().OrderBy(teacher => teacher.Post);
        }
        /*----------добавить/удалить----------*/
        void IUniversity.Add(IPerson person)
        {
            persons.Add(person);
        }

        void IUniversity.Remove(IPerson person)
        {
            persons.Remove(person);
        }

        /*----------найти----------*/
        IEnumerable<Teacher> IUniversity.FindByDepartment(string department)
        {
            return persons.OfType<Teacher>().Where(teacher => teacher.Department == department).OrderBy(teacher => teacher.Post);
        }

        IEnumerable<IPerson> IUniversity.FindByLastName(string lastName)
        {
            return persons.Where(person => person.Lastname == lastName).OrderBy(person => person.Lastname);
        }
    }
}
