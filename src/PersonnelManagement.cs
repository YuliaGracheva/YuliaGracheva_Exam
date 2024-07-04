using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Exam
{
    public class PersonnelManagement
    {
        public Person[] person;
        public int lenght;

        public PersonnelManagement(int size)
        {
            person = new Person[size];
            lenght = 0;
        }

        public void AddPersonToArray(Person person1)
        {
            if(lenght < person.Length)
            {
                person[lenght] = person1;
                lenght++;
            }
        }
        public void SortPerson()
        {
            person = person.OrderBy(p => p.DateBirth).ThenBy(p => p.Surname).ToArray();
        }
        public void SavePersonToFile(string filename)
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                try
                {
                    for (int i = 0; i < person.Length; i++)
                    {
                        sw.WriteLine($"№{i}: {person[i].Surname} {person[i].Name}, {person[i].DateBirth}");
                    }

                    Console.WriteLine("Файл был успешно создан. ");
                }
                catch
                {
                    Console.WriteLine("Файл не был создан.");
                }
            }
        }
    }
}
