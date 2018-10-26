using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

/*
3. Переделать программу Пример использования коллекций для решения следующих задач:
а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (частотный массив);
в) отсортировать список по возрасту студента;
г) *отсортировать список по курсу и возрасту студента;
*/
namespace SharpLesson6 {
    partial class Program {
        class Student {
            public string lastName;
            public string firstName;
            public string university;
            public string faculty;
            public int course;
            public string department;
            public int group;
            public string city;
            public int age;

            // Создаем конструктор
            public Student(string firstName, string lastName, string university,
                            string faculty, string department, int age, int course, int group, string city) {
                this.lastName = lastName;
                this.firstName = firstName;
                this.university = university;
                this.faculty = faculty;
                this.department = department;
                this.course = course;
                this.age = age;
                this.group = group;
                this.city = city;
            }

            //а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
            public static int MagistrCount(List<Student> list) {
                return list.FindAll(student => student.course == 5 || student.course == 6).Count;
            }

            //б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (частотный массив);
            public static Dictionary<string, int> StudentFreq(List<Student> list) {
                Dictionary<string, int> result = new Dictionary<string, int>();
                int count;

                for (int i = 18; i <= 20; i++) {
                    count = 0;
                    for (int j = 1; j <= 6; j++) {
                        count = list.FindAll(s => s.age == i && s.course == j).Count;
                        if (count > 0) result.Add(String.Format("{0} {1}", i, j), count);
                    }
                }
                return result;
            }

            //в) отсортировать список по возрасту студента;
            public static void SortAge(List<Student> list) {
                list.Sort((s1, s2) => s1.age - s2.age);
            }

            //г) *отсортировать список по курсу и возрасту студента;
            public static void SortAgeCourse(List<Student> list) {
                list.Sort((s1, s2) => {
                    if (s1.course - s2.course == 0) {
                        return s1.age - s2.age;
                    } else {
                        return s1.course - s2.course;
                    }
                });
            }
        }

        static int MyDelegat(Student st1, Student st2)  {
            return String.Compare(st1.firstName, st2.firstName);
        }

        static void Task3() {
            int bakalavr = 0;
            int magistr = 0;
            List<Student> list = new List<Student>();
            // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students.csv", Encoding.GetEncoding("windows-1251"));
            while (!sr.EndOfStream) {
                try {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (int.Parse(s[6]) < 5) bakalavr++; else magistr++;
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            list.Sort(new Comparison<Student>(MyDelegat));
            Console.WriteLine("Всего студентов:" + list.Count);
            Console.WriteLine("Магистров:{0}", magistr);
            Console.WriteLine("Бакалавров:{0}", bakalavr);
            foreach (var v in list) Console.WriteLine(v.firstName);
            Console.WriteLine(DateTime.Now - dt);

            //ДЗ
            Console.WriteLine("\n>> Количество студентов на 5 и 6 курсах: {0}", Student.MagistrCount(list));

            Console.WriteLine(">> Частотный анализ студентов:");
            Dictionary<string, int> dictionary = Student.StudentFreq(list);
            Console.WriteLine("Возраст\tКурс\tКол-во");
            foreach(var item in dictionary) {
                Console.WriteLine("{0}\t{1}\t{2}", item.Key.Split(' ')[0], item.Key.Split(' ')[1], item.Value);
            }

            Console.WriteLine(">> Сортировка по возрасту:");
            Student.SortAge(list);
            foreach(var item in list) {
                Console.WriteLine("{0} {1} - {2}", item.firstName, item.lastName, item.age);
            }

            Console.WriteLine(">> Сортировка по возрасту и курсу:");
            Student.SortAgeCourse(list);
            foreach (var item in list) {
                Console.WriteLine("Курс {3}: {0} {1} - {2}", item.firstName, item.lastName, item.age, item.course);
            }
        }
    }
}
