using System;
using System.Linq;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива: ");

            int size = 0;
            bool validSize = false;

            while (!validSize)
            {
                if (!int.TryParse(Console.ReadLine(), out size))
                {
                    Console.WriteLine("Некорректный ввод размера массива. Попробуйте снова.");
                }
                else
                {
                    validSize = true;
                }
            }

            PersonnelManagement personnelManagement = new PersonnelManagement(size);
            Person people = new Person();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"№{i}");

                Console.WriteLine("Введите фамилию: ");
                string surname = "";
                string tempSurname = Console.ReadLine();

                bool validSurname = false;
                while (!validSurname)
                {
                    if (string.IsNullOrEmpty(tempSurname))
                    {
                        Console.WriteLine("Фамилия не может быть пустой. Попробуйте снова.");
                        tempSurname = Console.ReadLine();
                    }
                    else if (!tempSurname.All(char.IsLetter))
                    {
                        Console.WriteLine("В фамилии не могут быть цифры. Попробуйте снова.");
                        tempSurname = Console.ReadLine();
                    }
                    else
                    {
                        surname = tempSurname;
                        validSurname = true;
                    }
                }

                Console.WriteLine("Введите имя: ");

                string name = "";
                string tempName = Console.ReadLine();

                bool validName = false;
                while (!validName)
                {
                    if (string.IsNullOrEmpty(tempName))
                    {
                        Console.WriteLine("Имя не может быть пустым. Попробуйте снова.");
                        tempName = Console.ReadLine();
                    }
                    else if (!tempName.All(char.IsLetter))
                    {
                        Console.WriteLine("В имени не могут быть цифры. Попробуйте снова.");
                        tempName = Console.ReadLine();
                    }
                    else
                    {
                        name = tempName;
                        validName = true;
                    }
                }

                Console.WriteLine("Введите год рождения: ");

                int year = 0;
                bool validYear = false;
                while (!validYear) {
                    if (!int.TryParse(Console.ReadLine(), out year))
                    {
                        Console.WriteLine("Год может быть только числом");
                    }
                    else if (year > 2025 || year < 1900)
                    {
                        Console.WriteLine("Введите действительный год. Попробуте снова");
                    }
                    else
                    {
                        validYear = true;
                    }
                }

                people = new Person { Surname = surname, Name = name, DateBirth = year };
                personnelManagement.AddPersonToArray(people);
            }

            Console.WriteLine("Массив был отсортирован. ");
            personnelManagement.SortPerson();

            Console.WriteLine("Сохранить данные в файл? (д\\н)");
            string choise = Console.ReadLine();
            if(choise == "д")
            {
                Console.WriteLine("Введите имя файла: ");
                string filename = Console.ReadLine();
                bool validFilename = false;

                while (!validFilename)
                {
                    if (string.IsNullOrEmpty(filename))
                    {
                        Console.WriteLine("Название файла не может быть пустым. Попробуйте снова. ");
                        filename = Console.ReadLine();
                    }
                    else
                    {
                        personnelManagement.SavePersonToFile(filename + ".txt");
                        validFilename = true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Вывыбрали не сохранять данные в файл. ");
            }
            Console.WriteLine("Выход из приложения.");
        }
    }
}
