using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CADS_LW5
{
    internal class Exceptions
    {
        public static void Milk()
        {
            Milk();
        }

        public void ExceptionTest(int index)
        {
            switch (index)
            {
                case 1:
                    try
                    {
                        Milk();
                    }
                    catch (StackOverflowException exception)
                    {
                        Console.WriteLine($"Переполнение стека вызовов >> {exception.Message}");
                    }
                    break;
                case 2:
                    try
                    {
                        object[] numbers = new string[5];
                        numbers[0] = 42;
                    }
                    catch (ArrayTypeMismatchException exception)
                    {
                        Console.WriteLine($"Несоответствие типов объектов массива и объекта >> {exception.Message}");
                    }
                    break;
                case 3:
                    try
                    {
                        int zero = 0;
                        int div = 42 / zero;
                    }
                    catch (DivideByZeroException exception)
                    {
                        Console.WriteLine($"Деление на ноль >> {exception.Message}");
                    }
                    break;
                case 4:
                    try
                    {
                        int[] numbers = new int[5];
                        int number = numbers[5];
                    }
                    catch (IndexOutOfRangeException exception)
                    {
                        Console.WriteLine($"Индекс за границей массива >> {exception.Message}");
                    }
                    break;
                case 5:
                    try
                    {
                        object name = "John";
                        int number = (int)name;
                    }
                    catch (InvalidCastException exception)
                    {
                        Console.WriteLine($"Некорректное приведение типов >> {exception.Message}");
                    }
                    break;
                case 6:
                    try
                    {
                        int[] numbers = new int[int.MaxValue];
                    }
                    catch (OutOfMemoryException exception)
                    {
                        Console.WriteLine($"Переполнение памяти >> {exception.Message}");
                    }
                    break;
                case 7:
                    try
                    {
                        checked
                        {
                            int number1 = int.MaxValue;
                            int number2 = number1 + 1;
                        }
                    }
                    catch (OverflowException exception)
                    {
                        Console.WriteLine($"Переполнение >> {exception.Message}");
                    }
                    break;
            }
        }
    }
}
