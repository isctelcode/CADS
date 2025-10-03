using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct2
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            public double Abs()
            {
                return Math.Sqrt(real * real + imaginary * imaginary);
            }

            public double Arg()
            {
                if (real > 0 && imaginary >= 0) return Math.Atan()
            }
        }
    }
}
