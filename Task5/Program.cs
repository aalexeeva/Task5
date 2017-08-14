using System;
using static System.Console;

namespace Task5
{
    class Program
    {
        public static int Input(bool kek) // ввод числа N
        {
            var number = 0; 
            bool ok;
            do
            {
                try
                {
                    number = Convert.ToInt32(ReadLine());
                    if (kek)
                    {
                        if (number < 2)
                        {
                            WriteLine("порядок матрицы должен быть больше или равен 2");
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

        static void Main(string[] args)
        {
            WriteLine("Введите порядок квадратной матрицы");
            var n = Input(true);
            var arr = new int[n, n];
            for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
            {
                WriteLine("Введите элемент {0} строки {1}", j, i);
                arr[i, j] = Input(false);
            }
            WriteLine("Последовательность, полученная в результате анализа элементов строк матрицы: ");
            bool mem = false, mem2 = false;
            for (var i = 0; i < n; i++)
            {
                if (arr[i, 0] > arr[i, 1]) mem = true;
                else if (arr[i, 0] < arr[i, 1]) mem2 = true;       
                for (var j = 1; j < n; j++)
                {
                    if (mem)
                    {
                        if (arr[i, j - 1] > arr[i, j]) continue;
                        mem = false;
                        break;
                    }
                    if (!mem2) continue;
                    if (arr[i, j - 1] < arr[i, j]) continue;
                    mem2 = false;
                    break;
                }
                if (mem || mem2) Write("1"); 
                else Write("0");
                mem = false;
                mem2 = false;
            }
            Read();
        }
    }
}
