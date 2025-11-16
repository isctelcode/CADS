using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            University un1 = new University("КубГУ", new string[] { "ФКТиПМ", "ФМиКН", "РГФ" });
            University un2 = new University("КубГТУ", new string[] { "ФЭУБ", "ФИТК", "ФИМТ" });

            string[] programmer = new string[] { "Математический анализ", "Алгоритмы и структуры данных", "Компьютерные сети", "Комбинаторный анализ" };
            string[] mathematic = new string[] { "Математический анализ", "Алгебра", "Дифференциальные уравнения", "Аналитическая геометрия" };
            string[] philologist = new string[] { "Античная литература", "Иностранный язык", "Народная поэзия" };
            string[] physicist = new string[] { "Математический анализ", "Механика", "Электрические цепи", "Термодинамика" };
            string[] economist = new string[] { "Экономическая теория", "Бухгалтерский учёт", "Информатика в экономике" };

            List<Student> students = new List<Student>();

            students.Add(new Student("Антон", "Городецкий", 22, un1, un1.Course[0], 16, new Class[] { new Class(programmer[0], 4), new Class(programmer[1], 5), new Class(programmer[2], 5), new Class(programmer[3], 5) }));
            students.Add(new Student("Алексей", "Неплотников", 21, un1, un1.Course[0], 16, new Class[] { new Class(programmer[0], 3), new Class(programmer[1], 3), new Class(programmer[2], 3), new Class(programmer[3], 3) }));
            students.Add(new Student("Валентин", "Адронников", 21, un1, un1.Course[1], 12, new Class[] { new Class(mathematic[0], 3), new Class(mathematic[1], 4), new Class(mathematic[2], 4), new Class(mathematic[3], 3) }));
            students.Add(new Student("Василиса", "Васюткина", 19, un1, un1.Course[1], 11, new Class[] { new Class(mathematic[0], 5), new Class(mathematic[1], 4), new Class(mathematic[2], 4), new Class(mathematic[3], 4) }));
            students.Add(new Student("Крыса", "Стальная", 24, un1, un1.Course[2], 14, new Class[] { new Class(philologist[0], 5), new Class(philologist[1], 3), new Class(philologist[2], 3) }));
            students.Add(new Student("Антон", "Неплотников", 23, un1, un1.Course[2], 13, new Class[] { new Class(philologist[0], 3), new Class(philologist[1], 3), new Class(philologist[2], 4)}));
            students.Add(new Student("Евгения", "Окорокова", 23, un2, un2.Course[0], 13, new Class[] { new Class(economist[0], 3), new Class(economist[1], 5), new Class(economist[2], 2) }));
            students.Add(new Student("Евгений", "Плотников", 18, un2, un2.Course[0], 14, new Class[] { new Class(economist[0], 5), new Class(economist[1], 4), new Class(economist[2], 3) }));
            students.Add(new Student("Георгий", "Николаев", 19, un2, un2.Course[1], 13, new Class[] { new Class(programmer[0], 5), new Class(programmer[1], 5), new Class(programmer[2], 4), new Class(programmer[3], 4) }));
            students.Add(new Student("Дмитрий", "Побрацкий", 22, un2, un2.Course[1], 13, new Class[] { new Class(programmer[0], 4), new Class(programmer[1], 3), new Class(programmer[2], 4), new Class(programmer[3], 3) }));
            students.Add(new Student("Светлана", "Кочеткова", 18, un2, un2.Course[2], 11, new Class[] { new Class(physicist[0], 4), new Class(physicist[1], 2), new Class(physicist[2], 4) }));
            students.Add(new Student("Дмитрий", "Антиплотников", 23, un2, un2.Course[2], 15, new Class[] { new Class(physicist[0], 3), new Class(physicist[1], 3), new Class(physicist[2], 5) }));

            char request = 'a';
            while (request != 'q')
            {
                Console.WriteLine("Добавить студента - a");
                Console.WriteLine("Вывести список студентов - l");
                Console.WriteLine("Удалить студента - d");
                Console.WriteLine("Найти ВУЗ без двоечников - f");
                Console.WriteLine("Завершить работу программы - q");
                Console.Write("Выберите действие >> ");
                request = Convert.ToChar(Console.ReadLine());
                switch (request)
                {
                    case 'a':
                        Console.WriteLine($"ВУЗы: {un1.Name} - 1   {un2.Name} - 2");
                        Console.WriteLine($"Факультеты:\n{un1.Name}: {un1.Course[0]} - 1   {un1.Course[1]} - 2   {un1.Course[2]} - 3");
                        Console.WriteLine($"{un2.Name}: {un2.Course[0]} - 1   {un2.Course[1]} - 2   {un2.Course[2]} - 3");
                        Console.WriteLine($"Специальности: Программист - 1   Математик - 2   Филолог - 3   Физик - 4   Экономист - 5");
                        Console.WriteLine("Введите через пробел Имя, Фамилию, Возраст, Университет (выбор), Факультет (выбор), Группу, Специальность (выбор) студента");
                        Console.Write(">> ");
                        string[] stud = Console.ReadLine().Split().ToArray();
                        int[] marks;
                        Class[] classes = new Class[] { new Class(programmer[0], 5), new Class(programmer[1], 5), new Class(programmer[2], 5), new Class(programmer[3], 5) };
                        University university = un1;
                        string faculty = "ФКТиПМ";
                        if (Convert.ToInt32(stud[3]) == 1)
                        {
                            university = un1;
                            faculty = un1.Course[Convert.ToInt32(stud[4]) - 1];
                        }
                        else
                        {
                            if (Convert.ToInt32(stud[3]) == 2)
                            {
                                university = un2;
                                faculty = un2.Course[Convert.ToInt32(stud[4]) - 1];
                            }
                        }
                            switch (Convert.ToInt32(stud[6]))
                            {
                                case 1:
                                    Console.WriteLine("Введите через пробел оценки");
                                    Console.WriteLine("Математический анализ Алгоритмы и структуры данных Компьютерные сети Комбинаторный анализ");
                                    Console.Write(">> ");
                                    marks = Console.ReadLine().Split().Select(int.Parse).ToArray();
                                    classes = new Class[] { new Class(programmer[0], marks[0]), new Class(programmer[1], marks[1]), new Class(programmer[2], marks[2]), new Class(programmer[3], marks[3]) };
                                    break;
                                case 2:
                                    Console.WriteLine("Введите через пробел оценки");
                                    Console.WriteLine("Математический анализ Алгебра Дифференциальные уравнения Аналитическая геометрия");
                                    Console.Write(">> ");
                                    marks = Console.ReadLine().Split().Select(int.Parse).ToArray();
                                    classes = new Class[] { new Class(mathematic[0], marks[0]), new Class(mathematic[1], marks[1]), new Class(mathematic[2], marks[2]), new Class(mathematic[3], marks[3]) };
                                    break;
                                case 3:
                                    Console.WriteLine("Введите через пробел оценки");
                                    Console.WriteLine("Античная литература Иностранный язык Народная поэзия");
                                    Console.Write(">> ");
                                    marks = Console.ReadLine().Split().Select(int.Parse).ToArray();
                                    classes = new Class[] { new Class(philologist[0], marks[0]), new Class(philologist[1], marks[1]), new Class(philologist[2], marks[2]) };
                                    break;
                                case 4:
                                    Console.WriteLine("Введите через пробел оценки");
                                    Console.WriteLine("Математический анализ Механика Электрические цепи Термодинамика");
                                    Console.Write(">> ");
                                    marks = Console.ReadLine().Split().Select(int.Parse).ToArray();
                                    classes = new Class[] { new Class(physicist[0], marks[0]), new Class(physicist[1], marks[1]), new Class(physicist[2], marks[2]) };
                                    break;
                                case 5:
                                    Console.WriteLine("Введите через пробел оценки");
                                    Console.WriteLine("Экономическая теория Бухгалтерский учёт Информатика в экономике");
                                    Console.Write(">> ");
                                    marks = Console.ReadLine().Split().Select(int.Parse).ToArray();
                                    classes = new Class[] { new Class(economist[0], marks[0]), new Class(economist[1], marks[1]), new Class(economist[2], marks[2]) };
                                    break;
                            }
                        students.Add(new Student(stud[0], stud[1], Convert.ToInt32(stud[2]), university, faculty, Convert.ToInt32(stud[5]), classes));
                        break;
                    case 'l':
                        Console.WriteLine("Список студентов:");
                        for (int i = 0; i < students.Count; ++i)
                        {
                            Console.Write($"{i + 1}. ");
                            students[i].GetInfo();
                            students[i].GetMarks();
                        }
                        break;
                    case 'd':
                        Console.WriteLine("Список студентов:");
                        for (int i = 0; i < students.Count; ++i)
                        {
                            Console.Write($"{i + 1}. ");
                            students[i].GetInfo();
                            students[i].GetMarks();
                        }
                        Console.WriteLine("Введите номер студента для удаления");
                        Console.Write(">> ");
                        students.RemoveAt(Convert.ToInt32(Console.ReadLine()) - 1);
                        Console.WriteLine("Удаление прошло успешно");
                        break;
                    case 'f':
                        bool[] greatestUniversities = new bool[] { true, true };
                        for (int i = 0; i < students.Count; ++i)
                        {
                            for (int j = 0; j < students[i].Classes.Length; ++j)
                            {
                                if (students[i].Classes[j].Mark == 2 && students[i].University == un1)
                                    greatestUniversities[0] = false;
                                if (students[i].Classes[j].Mark == 2 && students[i].University == un2)
                                    greatestUniversities[1] = false;
                            }
                        }
                        using (StreamWriter input = new StreamWriter("data.txt", false, System.Text.Encoding.Default))
                        {
                            if (greatestUniversities[0])
                                input.WriteLine(un1.Name);
                            if (greatestUniversities[1])
                                input.WriteLine(un2.Name);
                        }

                        Console.WriteLine("Данные по запросу добавлены в файл");
                        break;
                    case 'q':
                        Console.WriteLine("Завершение работы");
                        return;
                }
            }
        }
    }
}