using System;

namespace Project2
{
    interface IPerson
    {
        string Name { get; }
        string Patronymic { get; }
        string Lastname { get; }
        DateTime Date { get; }
        int Age { get; }
    }
}
