using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

//Поиск КСС Тарьяна, Построение максимального потока Диница, Построение максимальной клики эвристическим "слиянием"
namespace Struct20
{
    internal class Program
    {
        static List<int>[] graph;

        static int[] indexes;
        static int[] lowlinks;
        static Stack<int> stack;
        static bool[] inStack;
        static int index = 0;
        static int[] SCC;

        static int[] level;
        static int[,] flow;
        static int[,] capacity;
        static int[] leftEdge;
        static int s;
        static int t;

        static List<List<int>> cliques;

        static void Tarjana()
        {
            for (int i = 1; i < graph.Length; ++i)
            {
                if (indexes[i] == 0)
                {
                    Tarjana(i);
                }
            }
        }

        static void Tarjana(int currentVertex)
        {
            indexes[currentVertex] = index + 1;
            lowlinks[currentVertex] = index + 1;
            ++index;
            stack.Push(currentVertex);
            inStack[currentVertex] = true;

            foreach (int vertex in graph[currentVertex])
            {
                if (indexes[vertex] == 0)
                {
                    Tarjana(vertex);
                    lowlinks[currentVertex] = Min(lowlinks[currentVertex], lowlinks[vertex]);
                }
                else if (inStack[vertex])
                {
                    lowlinks[currentVertex] = Min(lowlinks[currentVertex], indexes[vertex]);
                }
            }

            if (lowlinks[currentVertex] == indexes[currentVertex])
            {
                int backDrift = stack.Pop();
                SCC[backDrift] = currentVertex;
                inStack[backDrift] = false;
                while (currentVertex != backDrift)
                {
                    backDrift = stack.Pop();
                    SCC[backDrift] = currentVertex;
                    inStack[backDrift] = false;
                }
            }
        }

        static bool DinicBFS()
        {
            for (int i = 0; i < level.Length; ++i)
            {
                level[i] = 1000000;
            }
            level[s] = 0;
            Queue<int> bfs = new Queue<int>();
            bfs.Enqueue(s);
            while (bfs.Count() != 0)
            {
                int u = bfs.Dequeue();
                foreach (int v in graph[u])
                {
                    if (flow[u, v] < capacity[u, v] && level[v] == 1000000)
                    {
                        level[v] = level[u] + 1;
                        bfs.Enqueue(v);
                    }
                }
            }
            return level[t] != 1000000;
        }

        static int DinicDFS(int u, int minCap)
        {
            if (u == t || minCap == 0)
            {
                return minCap;
            }
            for (int v = leftEdge[u]; v < graph.Length; ++v)
            {
                if (level[v] == level[u] + 1)
                {
                    int delta = DinicDFS(v, Min(minCap, capacity[u, v] - flow[u, v]));
                    if (delta != 0)
                    {
                        flow[u, v] += delta;
                        flow[v, u] -= delta;
                        return delta;
                    }
                }
                ++leftEdge[u];
            }
            return 0;
        }

        static int Dinic()
        {
            int mxFlow = 0;
            while (DinicBFS())
            {
                for (int i = 0; i < leftEdge.Length; ++i)
                {
                    leftEdge[i] = 0;
                }
                int flow = DinicDFS(s, 1000000);
                while (flow != 0)
                {
                    mxFlow += flow;
                    flow = DinicDFS(s, 1000000);
                }
            }
            return mxFlow;
        }

        static void HeuristicClique()
        {
            bool isIter = true;
            bool isEdge1 = false;
            bool isEdge2 = false;
            bool isClique = false;
            foreach (List<int> cliq1 in cliques)
            {
                foreach (List<int> cliq2 in cliques)
                {
                    isClique = true;
                    if (cliq1 != cliq2)
                    {
                        foreach (int u in cliq1)
                        {
                            foreach (int v in cliq2)
                            {
                                isEdge1 = false;
                                isEdge2 = false;
                                foreach (int w in graph[u])
                                {
                                    if (w == v)
                                    {
                                        isEdge1 = true;
                                        break;
                                    }
                                }
                                if (!isEdge1)
                                {
                                    isClique = false;
                                }
                                foreach (int w in graph[v])
                                {
                                    if (w == u)
                                    {
                                        isEdge2 = true;
                                        break;
                                    }
                                }
                                if (!isEdge2)
                                {
                                    isClique = false;
                                }
                            }
                            if (!isClique)
                            {
                                break;
                            }
                        }
                        if (!isClique)
                        {
                            break;
                        }
                        List<int> newClique = cliq1.Concat(cliq2).ToList();
                        cliques.Remove(cliq1);
                        cliques.Remove(cliq2);
                        cliques.Insert(0, newClique);
                        HeuristicClique();
                        return;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            graph = new List<int>[9];
            indexes = new int[9];
            lowlinks = new int[9];
            inStack = new bool[9];
            stack = new Stack<int>();
            SCC = new int[9];

            for (int i = 0; i < 9; ++i)
            {
                graph[i] = new List<int>();
                indexes[i] = 0;
                lowlinks[i] = 0;
                inStack[i] = false;
                SCC[i] = 0;
            }

            graph[1].Add(2);
            graph[2].Add(3);
            graph[3].Add(1);
            graph[4].Add(2);
            graph[4].Add(3);
            graph[4].Add(5);
            graph[5].Add(4);
            graph[5].Add(6);
            graph[6].Add(3);
            graph[6].Add(7);
            graph[7].Add(6);
            graph[8].Add(5);
            graph[8].Add(7);
            graph[8].Add(8);

            Tarjana();

            for (int i = 1; i < 9; ++i)
            {
                Console.Write(SCC[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            graph = new List<int>[8];
            level = new int[8];
            flow = new int[8, 8];
            capacity = new int[8, 8];
            leftEdge = new int[8];
            s = 1; t = 7;

            for (int i = 0; i < 8; ++i)
            {
                graph[i] = new List<int>();
                level[i] = 1000000;
                leftEdge[i] = 0;
                for (int j = 0; j < 8; ++j)
                {
                    flow[i, j] = 0;
                    flow[j, i] = 0;
                }
            }

            graph[1].Add(2);
            graph[1].Add(3);
            graph[2].Add(4);
            graph[3].Add(5);
            graph[4].Add(3);
            graph[4].Add(6);
            graph[5].Add(4);
            graph[5].Add(6);
            graph[6].Add(2);
            graph[6].Add(7);
            capacity[1, 2] = 16;
            capacity[1, 3] = 10;
            capacity[2, 4] = 9;
            capacity[3, 5] = 18;
            capacity[4, 3] = 9;
            capacity[4, 6] = 20;
            capacity[5, 4] = 6;
            capacity[5, 6] = 12;
            capacity[6, 2] = 5;
            capacity[6, 7] = 30;

            Console.WriteLine(Dinic());
            Console.WriteLine();

            graph = new List<int>[8];
            cliques = new List<List<int>>();
            for (int i = 1; i < 8; ++i)
            {
                graph[i] = new List<int>();
                List<int> clique = new List<int> { i };
                cliques.Add(clique);
            }

            graph[1].Add(2);
            graph[1].Add(3);
            graph[1].Add(4);
            graph[1].Add(5);
            graph[2].Add(1);
            graph[2].Add(3);
            graph[2].Add(4);
            graph[2].Add(5);
            graph[3].Add(1);
            graph[3].Add(2);
            graph[3].Add(4);
            graph[3].Add(5);
            graph[4].Add(1);
            graph[4].Add(2);
            graph[4].Add(3);
            graph[4].Add(5);
            graph[5].Add(1);
            graph[5].Add(2);
            graph[5].Add(3);
            graph[5].Add(4);
            graph[5].Add(6);
            graph[5].Add(7);
            graph[6].Add(5);
            graph[6].Add(7);
            graph[7].Add(5);
            graph[7].Add(6);

            HeuristicClique();

            int mxClique = 0;
            List<int> mxCliqueVertexes = new List<int>();

            foreach (List<int> clique in cliques)
            {
                if (clique.Count > mxClique)
                {
                    mxClique = clique.Count;
                    mxCliqueVertexes = clique;
                }
            }

            Console.WriteLine(mxClique);
            foreach (int u in mxCliqueVertexes)
            {
                Console.Write(u + " ");
            }
        }
    }
}
