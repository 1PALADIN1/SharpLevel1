using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Threading.Tasks;

/*
4. *Задача ЕГЭ. На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих
N строк имеет следующий формат: <Фамилия> <Имя> <оценки>, где <Фамилия> — строка, состоящая не более чем из 20 символов,
<Имя> — строка, состоящая не более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе.
<Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
Пример входной строки: Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников.
Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
*/
namespace SharpLesson5 {
    partial class Program {
        const int STUDENTS_MIN = 10;
        const int STUDENTS_MAX = 100;
        const int FST_NAME_MAX = 15;
        const int LAST_NAME_MAX = 20;
        const int BAD_STUDENTS_NUM = 3; //количество худших студентов (3 по заданию)

        static void Task4() {
            ArrayList result = WorstStudents("students.txt");

            //худшие студенты
            Console.WriteLine("Худшие студенты:");
            for (int i = 0; i < result.Count; i++) {
                Console.WriteLine("{0}", result[i]);
            }
        }

        //на вход подаётся файл с учениками
        static ArrayList WorstStudents(string fileName) {
            StreamReader sr = null;
            ArrayList resultArray = new ArrayList();
            string[] studentsArray = null;
            double[] markArray = null;

            try {
                sr = new StreamReader(fileName);
                int studentsNum = int.Parse(sr.ReadLine());

                if (studentsNum < 10 || studentsNum > 100)
                    throw new Exception("Количество студентов должно быть не меньше 10 и не больше 100");
                studentsArray = new string[studentsNum]; //Фамилия и имя студента
                markArray = new double[studentsNum]; //массив со средним баллом
                string[] lineArray;

                for (int i = 0; i < studentsNum; i++) {
                    lineArray = sr.ReadLine().Split(' ');

                    if (lineArray.Length != 5) throw new Exception("Ошибка формата входных данных");
                    if (lineArray[0].Length > LAST_NAME_MAX) throw new Exception(String.Format("Фамилия учеников не должна превышать {0} символов", LAST_NAME_MAX));
                    if (lineArray[1].Length > FST_NAME_MAX) throw new Exception(String.Format("Имя учеников не должно превышать {0} символов", FST_NAME_MAX));

                    studentsArray[i] = String.Format("{0} {1}", lineArray[0], lineArray[1]);
                    markArray[i] = Double.Parse(lineArray[2]) * Double.Parse(lineArray[3]) * Double.Parse(lineArray[4]) / 3;
                }

                Array.Sort(markArray, studentsArray); //сортируем массивы по возврастающей

                for (int i = 0; i < studentsArray.Length; i++) {
                    if (markArray[i] <= markArray[BAD_STUDENTS_NUM - 1]) {
                        //включам всех худших студентов
                        resultArray.Add(studentsArray[i]);
                    } else {
                        break;
                    }
                }

            } catch (Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                if (sr != null) sr.Close();
            }

            return resultArray;
        }
    }
}
