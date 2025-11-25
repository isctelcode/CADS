using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Struct13
{
    class Program
    {
        static Stack<double> numbers = new Stack<double>();
        static Stack<Operation> operations = new Stack<Operation>();

        static void Operate(string operation)
        {
            double a, b;
            switch (operation)
            {
                case "+":
                    a = numbers.Pop(); b = numbers.Pop();
                    numbers.Push(a + b);
                    break;
                case "-":
                    a = numbers.Pop(); b = numbers.Pop();
                    numbers.Push(b - a);
                    break;
                case "*":
                    a = numbers.Pop(); b = numbers.Pop();
                    numbers.Push(a * b);
                    break;
                case "/":
                    a = numbers.Pop(); b = numbers.Pop();
                    if (a == 0) throw new DivideByZeroException();
                    numbers.Push(b / a);
                    break;
                case "//":
                    a = numbers.Pop(); b = numbers.Pop();
                    if (a == 0) throw new DivideByZeroException();
                    numbers.Push(b / a);
                    break;
                case "%":
                    a = numbers.Pop(); b = numbers.Pop();
                    if (a == 0) throw new DivideByZeroException();
                    numbers.Push(Convert.ToDouble(Convert.ToInt32(b) % Convert.ToInt32(a)));
                    break;
                case "^":
                    a = numbers.Pop(); b = numbers.Pop();
                    numbers.Push(Pow(b, a));
                    break;
                case "sqrt":
                    a = numbers.Pop();
                    numbers.Push(Sqrt(a));
                    break;
                case "abs":
                    a = numbers.Pop();
                    numbers.Push(Abs(a));
                    break;
                case "sign":
                    a = numbers.Pop();
                    numbers.Push(Sign(a));
                    break;
                case "sin":
                    a = numbers.Pop();
                    numbers.Push(Sin(a));
                    break;
                case "cos":
                    a = numbers.Pop();
                    numbers.Push(Cos(a));
                    break;
                case "tg":
                    a = numbers.Pop();
                    numbers.Push(Tan(a));
                    break;
                case "ln":
                    a = numbers.Pop();
                    numbers.Push(Log(a));
                    break;
                case "lg":
                    a = numbers.Pop();
                    numbers.Push(Log10(a));
                    break;
                case "min":
                    a = numbers.Pop(); b = numbers.Pop();
                    numbers.Push(Min(a, b));
                    break;
                case "max":
                    a = numbers.Pop(); b = numbers.Pop();
                    numbers.Push(Max(a, b));
                    break;
                case "exp":
                    a = numbers.Pop();
                    numbers.Push(Exp(a));
                    break;
                case "round":
                    a = numbers.Pop();
                    numbers.Push(Round(a));
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите строку математического выражения >> ");
            string[] expression = Console.ReadLine().Split(' ');
            Console.Write("Введите переменные и их значения >> ");
            string[] vars = Console.ReadLine().Split(' ');
            string[] varNames = new string[vars.Length];
            int[] varValues = new int[vars.Length];
            if (vars[0] != "")
            {
                for (int i = 0; i < vars.Length; ++i)
                {
                    varNames[i] = vars[i].Split('=')[0];
                    if (!int.TryParse(vars[i].Split('=')[1], out varValues[i]))
                    {
                        throw new Exception("Неверный формат значения переменной");
                    }
                }
            }

            for (int i = 0; i < expression.Length; ++i)
            {
                int inputNumber; bool varFlag = false;
                if (int.TryParse(expression[i], out inputNumber))
                {
                    numbers.Push(inputNumber);
                }
                else
                {
                    if (vars[0] != "")
                    {
                        for (int j = 0; j < varNames.Length; ++j)
                        {
                            if (expression[i] == varNames[j])
                            {
                                numbers.Push(varValues[j]);
                                varFlag = true;
                                break;
                            }
                        }
                    }
                    if (!varFlag)
                    {
                        if (expression[i] == ")")
                        {
                            while (!operations.Empty() && operations.Peek().GetOperation != "(")
                            {
                                Operate(operations.Pop().GetOperation);
                            }
                        }
                        else if (expression[i] == "(")
                        {
                            operations.Push(new Operation(expression[i]));
                        }
                        else
                        {
                            Operation newOperation = new Operation(expression[i]);
                            while (!operations.Empty() && operations.Peek().GetPriority <= newOperation.GetPriority)
                            {
                                Operate(operations.Pop().GetOperation);
                            }
                            operations.Push(newOperation);
                        }
                    }
                }
            }

            while (!operations.Empty())
            {
                if (numbers.Empty())
                {
                    throw new Exception("Некорректный формат математического выражения");
                }
                Operate(operations.Pop().GetOperation);
            }

            Console.WriteLine(numbers.Peek());
        }
    }
}
