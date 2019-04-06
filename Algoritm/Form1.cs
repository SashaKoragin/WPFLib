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

        private int[] bases = { 1,2,3 };
        private int[] spliters = {  4};
       // private int[] bases = {1,3,4,6,7,9,13,18,20};
      //  private int[] spliters = { 1,4,9,15,21,22,23,34 };
        private List<List<int>> result1 = new List<List<int>>();
        private List<int> prom = new List<int>();
        private List<int[]> result  = new List<int[]>();
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            int[] newNumber = new int[]{};
            var maxspliteelem = spliters.ElementAt(spliters.Length - 1);
                for (int j = 0; j < spliters.Length; j++)
                {
                    foreach (var bas in bases)
                    {
                        if (spliters[j] >= bas)
                        {
                            Array.Resize(ref newNumber, newNumber.Length + 1);
                            newNumber[i] = bas;
                            bases = bases.Where(val => val != bases[0]).ToArray();
                            i++;
                        }
                        if (spliters[j] <= bas)
                        {
                          if (spliters[j] == maxspliteelem)
                              {
                                  Array.Resize(ref newNumber, bases.Length);
                                  newNumber = bases;
                               }
                            i = 0;
                            break;
                        }
                    }
                if (newNumber.Length > 0)
                {
                    result.Add(newNumber);
                    newNumber = new int[] { };
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
                prom.Add(bases[base_index]);
                    base_index++;
                }
                if (prom.Count > 0)
                {
                    result1.Add(prom);
                    prom =new List<int>();
                }
                splitter_index++;
            }
            var u = result1;
        }
        
    }

}
