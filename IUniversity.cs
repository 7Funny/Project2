using System;
using System.Collections.Generic;

namespace Project2
{
    interface IUniversity
    {
        /*отсортировать в соответствии с вариантом 1-й лабы*/
        IEnumerable<IPerson> Persons { get; }
        IEnumerable<Student> Students { get; }
        IEnumerable<Teacher> Teachers { get; }

        /*добавить,удалить*/
        void Add(IPerson person);
        void Remove(IPerson person);

        /*Выдать всех студентов с определенной фамилией. Отсортировать по дате рождения*/
        IEnumerable<IPerson> FindByLastName(string lastName);

        /*Выдать всех преподавателей, название кафедры которых содержит заданный текст*/
        IEnumerable<Teacher> FindByDepartment(string text);
    }
}
