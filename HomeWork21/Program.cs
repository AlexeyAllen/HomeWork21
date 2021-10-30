using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork21
{
    // Создать многопоточное приложение, моделирующее работу садовников:
    class Program
    {
        static object locker = new object();
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размеры прямоугольного сада");
            Console.WriteLine("Введите размер сада по горизонтали");
            int horizDim = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите размер сада по вертикали");
            int verticDim = Convert.ToInt32(Console.ReadLine());
            int k = 0;
            int l = horizDim;

            while (k < verticDim && l > 0)
            {
                ThreadStart thrdStart = new ThreadStart(Cycle2);
                Thread thread = new Thread(thrdStart);
                thread.Start();
                Cycle1();
            }

            void Cycle1()
            {
                lock (locker)
                {
                    if (k < verticDim && l > 0)
                    {
                        Console.Write("Цикл 1. Первый садовник посадил в ряду " + k + " деревья :");
                        for (int j = 0; j < l; j++)
                        {
                            Console.Write(" " + j);
                        }
                        Console.WriteLine();
                        k++;
                    }

                    if (k < verticDim && l > 0)
                    {
                        Console.Write("Цикл 1. Второй садовник посадил в столбце " + l + " деревья :");
                        for (int i = verticDim - 1; i > k - 1; i--)
                        {
                            Console.Write(" " + i);
                        }
                        Console.WriteLine();
                        l--;
                    }
                }
            }
            void Cycle2()
            {
                lock (locker)
                {
                    if (k < verticDim && l > 0)
                    {
                        Console.Write("Цикл 2. Первый садовник посадил в столбце " + l + " деревья :");
                        for (int i = verticDim - 1; i > k - 1; i--)
                        {
                            Console.Write(" " + i);
                        }
                        Console.WriteLine();
                        l--;
                    }

                    if (k < verticDim && l > 0)
                    {
                        Console.Write("Цикл 2. Второй садовник посадил в ряду " + k + " деревья :");
                        for (int j = 0; j < l; j++)
                        {
                            Console.Write(" " + j);
                        }
                        Console.WriteLine();
                        k++;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
