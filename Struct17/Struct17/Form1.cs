using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Math;
using ZedGraph;
using System.Diagnostics;
using System.IO;
using System.Globalization;
using System.Collections;

namespace Struct3
{
    public partial class Form1 : Form
    {
        int operationType = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void data_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = data.SelectedItem.ToString();
            switch (type)
            {
                case "Добавить элемент в конец":
                    operationType = 1;
                    break;
                case "Получить значение":
                    operationType = 2;
                    break;
                case "Изменить значение":
                    operationType = 3;
                    break;
                case "Добавить элемент по индексу":
                    operationType = 4;
                    break;
                case "Удалить элемент":
                    operationType = 5;
                    break;
            }
        }

        private void run_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            Random random = new Random();
            long[] arrayListOperationTime = new long[4];
            long[] linkedListOperationTime = new long[4];
            ArrayList<int> arrayList;
            LinkedList<int> linkedList;
            switch (operationType)
            {
                case 1:
                    arrayListOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        arrayList = new ArrayList<int>();
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            arrayList.Add(1);
                        }
                        timer.Stop();
                        arrayListOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    linkedListOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        linkedList = new LinkedList<int>();
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            linkedList.Add(1);
                        }
                        timer.Stop();
                        linkedListOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    break;
                case 2:
                    arrayListOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        arrayList = new ArrayList<int>();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            arrayList.Add(1);
                        }
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            arrayList.Get(random.Next(1, Convert.ToInt32(Pow(10, i + 2))) - 1);
                        }
                        timer.Stop();
                        arrayListOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    linkedListOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        linkedList = new LinkedList<int>();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            linkedList.Add(1);
                        }
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            linkedList.Get(random.Next(1, Convert.ToInt32(Pow(10, i + 2))) - 1);
                        }
                        timer.Stop();
                        linkedListOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    break;
                case 3:
                    arrayListOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        arrayList = new ArrayList<int>();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            arrayList.Add(1);
                        }
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            arrayList.Set(random.Next(1, Convert.ToInt32(Pow(10, i + 2))) - 1, 1);
                        }
                        timer.Stop();
                        arrayListOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    linkedListOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        linkedList = new LinkedList<int>();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            linkedList.Add(1);
                        }
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            linkedList.Set(random.Next(1, Convert.ToInt32(Pow(10, i + 2))) - 1, 1);
                        }
                        timer.Stop();
                        linkedListOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    break;
                case 4:
                    arrayListOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        arrayList = new ArrayList<int>();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            arrayList.Add(1);
                        }
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            arrayList.Add(random.Next(1, Convert.ToInt32(Pow(10, i + 2))) - 1, 1);
                        }
                        timer.Stop();
                        arrayListOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    linkedListOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        linkedList = new LinkedList<int>();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            linkedList.Add(1);
                        }
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            linkedList.Add(random.Next(1, Convert.ToInt32(Pow(10, i + 2))) - 1, 1);
                        }
                        timer.Stop();
                        linkedListOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    break;
                case 5:
                    arrayListOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        arrayList = new ArrayList<int>();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            arrayList.Add(1);
                        }
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            arrayList.Remove(1);
                        }
                        timer.Stop();
                        arrayListOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    linkedListOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        linkedList = new LinkedList<int>();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            linkedList.Add(1);
                        }
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            linkedList.Remove(1);
                        }
                        timer.Stop();
                        linkedListOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    break;
            }

            GraphPane pane = graph.GraphPane;
            pane.Title.Text = "График";
            pane.XAxis.Title.Text = "Количество элементов";
            pane.YAxis.Title.Text = "Скорость работы (мс)";
            pane.CurveList.Clear();
            PointPairList pointList;

            switch(operationType)
            {
                case 1:
                    pane.Title.Text = "Добавление в конец";
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), arrayListOperationTime[i]);
                    pane.AddCurve("Динамический массив", pointList, Color.Red, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), linkedListOperationTime[i]);
                    pane.AddCurve("Двунаправленный список", pointList, Color.Blue, SymbolType.Default);
                    break;
                case 2:
                    pane.Title.Text = "Получение значения";
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), arrayListOperationTime[i]);
                    pane.AddCurve("Динамический массив", pointList, Color.Red, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), linkedListOperationTime[i]);
                    pane.AddCurve("Двунаправленный список", pointList, Color.Blue, SymbolType.Default);
                    break;
                case 3:
                    pane.Title.Text = "Изменение значения";
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), arrayListOperationTime[i]);
                    pane.AddCurve("Динамический массив", pointList, Color.Red, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), linkedListOperationTime[i]);
                    pane.AddCurve("Двунаправленный список", pointList, Color.Blue, SymbolType.Default);
                    break;
                case 4:
                    pane.Title.Text = "Добавление элемента по индексу";
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), arrayListOperationTime[i]);
                    pane.AddCurve("Динамический массив", pointList, Color.Red, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), linkedListOperationTime[i]);
                    pane.AddCurve("Двунаправленный список", pointList, Color.Blue, SymbolType.Default);
                    break;
                case 5:
                    pane.Title.Text = "Удаление элемента";
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), arrayListOperationTime[i]);
                    pane.AddCurve("Динамический массив", pointList, Color.Red, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), linkedListOperationTime[i]);
                    pane.AddCurve("Двунаправленный список", pointList, Color.Blue, SymbolType.Default);
                    break;
            }
            graph.AxisChange();
            graph.Invalidate();
        }

        
    }
}