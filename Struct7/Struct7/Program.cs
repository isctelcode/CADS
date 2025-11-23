using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Struct7
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<Request> requests = new PriorityQueue<Request>();

            Console.Write("Введите количество итераций добавления заявок >> ");
            int n = Convert.ToInt32(Console.ReadLine());
            int id = 1;
            Random random = new Random();
            Stopwatch timer = new Stopwatch();
            timer.Start();

            using (StreamWriter input = new StreamWriter("data.txt", false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < n; ++i)
                {
                    int iterationNumber = random.Next(1, 11);
                    for (int j = 0; j < iterationNumber; ++j)
                    {
                        int iteration = i + 1;
                        int priority = random.Next(1, 6);
                        requests.Add(new Request(iteration, id, priority));
                        input.WriteLine($"ADD {id} {priority} {iteration}");
                        ++id;
                    }
                    Request removed = requests.Poll();
                    input.WriteLine($"REMOVE {removed.Id} {removed.Priority} {removed.Iteration}");
                }

                while (!requests.IsEmpty())
                {
                    if (requests.Size == 1)
                    {
                        timer.Stop();
                        Console.WriteLine($"Время ожидания последней заявки : {timer.ElapsedMilliseconds}мс");
                    }
                    Request removed = requests.Poll();
                    input.WriteLine($"REMOVE {removed.Id} {removed.Priority} {removed.Iteration}");
                }
            }
        }
    }
}
