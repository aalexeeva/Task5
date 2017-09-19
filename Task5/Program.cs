using System;
using static System.Console;

namespace Task5
{
    class Program
    {
        public static int Input(bool status) // ввод числа N
        {
            var number = 0; // переменная для числа
            bool ok; // показатель корректности ввода
            do
            {
                try
                {
                    number = Convert.ToInt32(ReadLine());
                    if (status) // проверка значения порядка матрицы
                    {
                        if (number < 2)
                        {
                            WriteLine("Порядок матрицы должен быть больше или равен 2, повторите ввод");
                            ok = false;
                        }
                        else if (number > 100)
                        {
                            WriteLine("Введено слишком большое число, повторите ввод");
                            ok = false;
                        }
                        else ok = true;
                    }
                    else ok = true;
                }
                catch (FormatException)
                {
                    WriteLine("Ошибка при вводе числа");
                    ok = false;
                }
                catch (OverflowException)
                {
                    WriteLine("Ошибка при вводе числа");
                    ok = false;
                }
            } while (!ok);
            return number;
        }

        public static bool Exit() // выход из программы
        {
            WriteLine("Желаете начать сначала или нет? \nВведите да или нет");
            var word = Convert.ToString(ReadLine()); // ответ пользователя
            Clear();
            if (word == "да" || word == "Да" || word == "ДА")
            {
                Clear();
                return false;
            }
            Clear();
            WriteLine("Вы ввели 'нет' или что-то непонятное. Нажмите любую клавишу, чтобы выйти из программы.");
            ReadKey();
            return true;
        }

        static void Main(string[] args)
        {
            bool okay;
            do
            {

                WriteLine("Введите порядок квадратной матрицы");
                var n = Input(true); // ввод порядка матрицы
                var arr = new int[n, n]; // создание матрицы
                for (var i = 0; i < n; i++) // ввод элементов матрицы
                for (var j = 0; j < n; j++)
                {
                    WriteLine("Введите элемент {0} строки {1}", j, i);
                    arr[i, j] = Input(false);
                }
                WriteLine("Последовательность, полученная в результате анализа элементов строк матрицы: ");
                bool downSeq = false, upSeq = false; // переменные-показатели типа последовательности
                for (var i = 0; i < n; i++) // рассчет результата
                {
                    // проверка типа последовательности по первым двум элементам
                    if (arr[i, 0] > arr[i, 1]) downSeq = true; // последовательность убывающая
                    else if (arr[i, 0] < arr[i, 1]) upSeq = true; // последовательность восходящая
                    else if (arr[i, 0] == arr[i, 1])
                    {
                        downSeq = false;
                        upSeq = false;
                    } // не является последовательностью
                    for (var j = 1; j < n; j++)
                        // проверка соответствия остальных элементов типу последовательности первых двух
                    {
                        if (downSeq)
                        {
                            if (arr[i, j - 1] > arr[i, j]) continue;
                            downSeq = false;
                            break;
                        }
                        if (!upSeq) continue;
                        if (arr[i, j - 1] < arr[i, j]) continue;
                        upSeq = false;
                        break;
                    }
                    if (downSeq || upSeq) Write("1"); // вывод результата
                    else Write("0");
                    downSeq = false;
                    upSeq = false;
                }
                okay = Exit();
            } while (!okay);
        }
    }
}
