using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Algoritm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// test
        /// </summary>
      //  private int[] bases = { 1,2,3 };
    //   private int[] spliters = { 4 };
     //   private int[] bases = { 1, 2, 3 };
      //  private int[] spliters = { 2,10 };
        /// <summary>
        /// Исходные данные
        /// </summary>
           private int[] bases = {3,6,7,9,13,18,20};
           private int[] spliters = { 1,4,9,15,20,23,24 };

        /// <summary>
        /// Решение 2
        /// </summary>
        private List<List<int>> result1 = new List<List<int>>();
        private List<int> newList = new List<int>();

        /// <summary>
        /// Решение 1 и Решение 3
        /// </summary>
        private List<int[]> result  = new List<int[]>();

        private int[] mass = null;

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            int[] newArray = new int[]{};
            var maxspliteelem = spliters.ElementAt(spliters.Length - 1);
                for (int j = 0; j < spliters.Length; j++)
                {
                    foreach (var bas in bases)
                    {
                        if (spliters[j] >= bas)
                        {
                            Array.Resize(ref newArray, newArray.Length + 1);
                            newArray[i] = bas;
                            ////Можно индекс запоминать
                            bases = bases.Where(val => val != bases[0]).ToArray();
                            i++;
                        }
                        if (spliters[j] <= bas)
                        {
                            i = 0;
                            break;
                        }
                    }
                if (newArray.Length > 0)
                {
                    result.Add(newArray);
                    newArray = new int[] { };
                    if (spliters[j] == maxspliteelem)
                    {
                        Array.Resize(ref newArray, bases.Length);
                        newArray = bases;
                        result.Add(newArray);
                    }
                }
            }
            var s =  result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int base_index = 0;
            int splitter_index = 0;

            while (base_index<bases.Length)
            {
                while (base_index<bases.Length && (splitter_index>=spliters.Length||bases[base_index]<=spliters[splitter_index]))
                {
                    newList.Add(bases[base_index]);
                    base_index++;
                }
                if (newList.Count > 0)
                {
                    result1.Add(newList);
                    newList = new List<int>();
                }
                splitter_index++;
            }
            var u = result1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var borderBase = 0;
            var maxBase = bases.Max();
            var maxSplit = spliters.Max();
            for (int i = 0; i < spliters.Length; i++)
            {
                    mass = bases.Where(val => val <= spliters[i] && val > borderBase).ToArray();
                    borderBase = spliters[i];
                     if (mass.Length > 0)
                     {
                        result.Add(mass);
                        mass = null;
                     }
                    //Обработка остатков если есть
                    if (maxSplit == spliters[i] && maxBase > borderBase)
                    {
                        mass = bases.Where(val => val > borderBase).ToArray();
                        result.Add(mass);
                    }
            }
            var е = result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var s = new Sample();
            s.Print();
            ISample i = s;
            i.Print();
        }
    }

    public interface ISample
    {
        void Print(string val = "1");
    }
    public class Sample : ISample
    {
        public void Print(string val = "2")
        {
            System.Console.Write(val);
        }

        public void S()
        {
            
        }
    }
}
