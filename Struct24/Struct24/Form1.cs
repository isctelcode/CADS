using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using static System.Math;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Struct24
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
                case "Получить значение по ключу":
                    operationType = 1;
                    break;
                case "Присвоить значение по ключу":
                    operationType = 2;
                    break;
                case "Удаление элемента по ключу":
                    operationType = 3;
                    break;
            }
        }

        private void run_Click(object sender, EventArgs e)
        {
            Stopwatch timer = new Stopwatch();
            Random random = new Random();
            long[] hashMapOperationTime = new long[4];
            long[] treeMapOperationTime = new long[4];
            HashMap<int> hashMap;
            TreeMap<int> treeMap;
            switch (operationType)
            {
                case 1:
                    hashMapOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        hashMap = new HashMap<int>();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            hashMap.Put(j, j);
                        }
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            hashMap.Get(j);
                        }
                        timer.Stop();
                        hashMapOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    treeMapOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        treeMap = new TreeMap<int>();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            treeMap.Put(j, j);
                        }
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            treeMap.Get(j);
                        }
                        timer.Stop();
                        treeMapOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    break;
                case 2:
                    hashMapOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        hashMap = new HashMap<int>();
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            hashMap.Put(j, j);
                        }
                        timer.Stop();
                        hashMapOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    treeMapOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        treeMap = new TreeMap<int>();
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            treeMap.Put(j, j);
                        }
                        timer.Stop();
                        treeMapOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    break;
                case 3:
                    hashMapOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        hashMap = new HashMap<int>();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            hashMap.Put(j, j);
                        }
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            hashMap.Remove(j);
                        }
                        timer.Stop();
                        hashMapOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    treeMapOperationTime = new long[4];
                    for (int i = 0; i < 4; ++i)
                    {
                        timer = new Stopwatch();
                        treeMap = new TreeMap<int>();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            treeMap.Put(j, j);
                        }
                        timer.Start();
                        for (int j = 0; j < Pow(10, i + 2) - 1; ++j)
                        {
                            treeMap.Remove(j);
                        }
                        timer.Stop();
                        treeMapOperationTime[i] = timer.ElapsedMilliseconds;
                    }
                    break;
            }

            GraphPane pane = graph.GraphPane;
            pane.Title.Text = "График";
            pane.XAxis.Title.Text = "Количество элементов";
            pane.YAxis.Title.Text = "Скорость работы (мс)";
            pane.CurveList.Clear();
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = 100000;
            pane.YAxis.Scale.Min = 0;
            PointPairList pointList;

            switch (operationType)
            {
                case 1:
                    pane.Title.Text = "Получить значение по ключу";
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), hashMapOperationTime[i]);
                    pane.AddCurve("Хеш-таблица", pointList, Color.Red, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), treeMapOperationTime[i]);
                    pane.AddCurve("Дерево поиска", pointList, Color.Blue, SymbolType.Default);
                    break;
                case 2:
                    pane.Title.Text = "Присвоить значение по ключу";
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), hashMapOperationTime[i]);
                    pane.AddCurve("Хеш-таблица", pointList, Color.Red, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), treeMapOperationTime[i]);
                    pane.AddCurve("Дерево поиска", pointList, Color.Blue, SymbolType.Default);
                    break;
                case 3:
                    pane.Title.Text = "Удаление элемента по ключу";
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), hashMapOperationTime[i]);
                    pane.AddCurve("Хеш-таблица", pointList, Color.Red, SymbolType.Default);
                    pointList = new PointPairList();
                    for (int i = 0; i < 4; ++i)
                        pointList.Add(Pow(10, i + 2), treeMapOperationTime[i]);
                    pane.AddCurve("Дерево поиска", pointList, Color.Blue, SymbolType.Default);
                    break;
            }
            graph.AxisChange();
            graph.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}