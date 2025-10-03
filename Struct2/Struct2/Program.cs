using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Struct2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the real and imaginary of complex numbers");
            Console.Write("number 1 >> ");
            double[] ri1 = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Complex number1 = new Complex(ri1[0], ri1[1]);
            Console.Write("number 2 >> ");
            double[] ri2 = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Complex number2 = new Complex(ri2[0], ri2[1]);
            number1.getNumber();
            number2.getNumber();
            while (true)
            {
                Console.WriteLine("Choose the operation:\n" +
                                  "Addition - a\n" +
                                  "Subtraction - s\n" +
                                  "Multiplication - m\n" +
                                  "Division - d\n" +
                                  "Abs - b\n" +
                                  "Argument - g\n" +
                                  "Get real - r\n" +
                                  "Get imaginary - i\n" +
                                  "Output numbers - u\n" +
                                  "Quit program - q\n");
                char select = Convert.ToChar(Console.ReadLine());
                switch (select)
                {
                    case 'a':
                        number1.getNumber();
                        Console.WriteLine($" + ");
                        number2.getNumber();
                        Console.WriteLine($" = ");
                        Complex numberA = number1 + number2;
                        numberA.getNumber();
                        break;
                    case 's':
                        number1.getNumber();
                        Console.WriteLine($" + ");
                        number2.getNumber();
                        Console.WriteLine($" = ");
                        Complex numberS = number1 - number2;
                        numberS.getNumber();
                        break;
                    case 'm':
                        number1.getNumber();
                        Console.WriteLine($" + ");
                        number2.getNumber();
                        Console.WriteLine($" = ");
                        Complex numberM = number1 * number2;
                        numberM.getNumber();
                        break;
                    case 'd':
                        number1.getNumber();
                        Console.WriteLine($" + ");
                        number2.getNumber();
                        Console.WriteLine($" = ");
                        Complex numberD = number1 / number2;
                        numberD.getNumber();
                        break;
                    case 'b':
                        Console.Write("For which number? >> ");
                        char selectAbs = Convert.ToChar(Console.ReadLine());
                        if (selectAbs == '1') Console.WriteLine(number1.CAbs());
                        else if (selectAbs == '2') Console.WriteLine(number2.CAbs());
                        else Console.WriteLine("wrong number\n");
                        break;
                    case 'g':
                        Console.Write("For which number? >> ");
                        char selectArg = Convert.ToChar(Console.ReadLine());
                        if (selectArg == '1') Console.WriteLine(number1.CArg());
                        else if (selectArg == '2') Console.WriteLine(number2.CArg());
                        else Console.WriteLine("wrong number\n");
                        break;
                    case 'r':
                        Console.Write("For which number? >> ");
                        char selectReal = Convert.ToChar(Console.ReadLine());
                        if (selectReal == '1') Console.WriteLine(number1.getReal());
                        else if (selectReal == '2') Console.WriteLine(number2.getReal());
                        else Console.WriteLine("wrong number\n");
                        break;
                    case 'i':
                        Console.Write("For which number? >> ");
                        char selectImaginary = Convert.ToChar(Console.ReadLine());
                        if (selectImaginary == '1') Console.WriteLine(number1.getImaginary());
                        else if (selectImaginary == '2') Console.WriteLine(number2.getImaginary());
                        else Console.WriteLine("wrong number\n");
                        break;
                    case 'u':
                        number1.getNumber();
                        number2.getNumber();
                        break;
                    case 'q':
                        Console.WriteLine("Thanks for using!");
                        return;
                    default:
                        Console.WriteLine("unknown operation\n");
                        break;
                }
            }
        }

        internal class Complex
        {
            private double real;
            private double imaginary;

            public double getReal()
            {
                return real;
            }

            public void setReal(double real)
            {
                this.real = real;
            }

            public double getImaginary()
            {
                return imaginary;
            }

            public void setImaginary(double imaginary)
            {
                this.imaginary = imaginary;
            }

            public Complex()
            {
                real = 0;
                imaginary = 0;
            }

            public Complex(double real, double imaginary)
            {
                this.real = real;
                this.imaginary = imaginary;
            }

            public static Complex operator +(Complex a, Complex b)
            {
                double real = a.real + b.real;
                double imaginary = a.imaginary + b.imaginary;
                return new Complex(real, imaginary);
            }

            public static Complex operator -(Complex a, Complex b)
            {
                double real = a.real - b.real;
                double imaginary = a.imaginary - b.imaginary;
                return new Complex(real, imaginary);
            }

            public static Complex operator *(Complex a, Complex b)
            {
                double real = a.real * b.real - a.imaginary * b.imaginary;
                double imaginary = a.real * b.imaginary + a.imaginary * b.real;
                return new Complex(real, imaginary);
            }

            public static Complex operator /(Complex a, Complex b)
            {
                double real;
                double imaginary;
                if (b.imaginary == 0)
                {
                    real = a.real / b.real;
                    imaginary = a.imaginary / b.real;
                }
                else
                {
                    Complex c = a * new Complex(b.real, -b.imaginary);
                    real = c.real / (b.real * b.real + b.imaginary * b.imaginary);
                    imaginary = c.imaginary / (b.real * b.real + b.imaginary * b.imaginary);
                }
                return new Complex(real, imaginary);
            }

            public double CAbs()
            {
                return Math.Sqrt(real * real + imaginary * imaginary);
            }

            public double CArg()
            {
                if (real > 0 && imaginary >= 0) return Atan(imaginary / real);
                else if (real < 0 && imaginary >= 0) return PI - Atan(Abs(imaginary / real));
                else if (real < 0 && imaginary < 0) return PI + Atan(Abs(imaginary / real));
                else if (real > 0 && imaginary < 0) return 2 * PI - Atan(Abs(imaginary / real));
                else if (real == 0 && imaginary > 0) return PI / 2;
                else return 3 * PI / 2;
            }

            public void getNumber()
            {
                if (real == 0 && imaginary == 0) Console.WriteLine(0);
                else if (real == 0) Console.WriteLine($"{imaginary}i");
                else if (imaginary == 0) Console.WriteLine(real);
                else if (imaginary > 0) Console.WriteLine($"{real} + {imaginary}i");
                else Console.WriteLine($"{real} - {-imaginary}i");
            }
        }
    }
}
