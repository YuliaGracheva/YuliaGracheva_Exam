using System;
using System.Collections.Generic;
using System.Text;

namespace Exam
{
    public class Person
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public int DateBirth { get; set; }
        public Person() { }
        public Person(string surname, string name, int date)
        {
            Surname = surname;
            Name = name;
            DateBirth = date;
        }
    }
}
