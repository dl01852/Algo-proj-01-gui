using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algo_proj_01_GUI.Properties;

namespace Algo_proj_01_GUI
{
    public partial class Form1 : Form
    {
        string[] subArrays = new string[35];
        private Dictionary<string, string> allData = Utility.getAllData(); 
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < subArrays.Length; i++)
            {
                // just to make 2 digit num i.e 01,02,03 instead of 1, 2, 3
                    subArrays[i] = string.Format("MaxSubArray_{0:00}", i+1); 
            }
            comboBox1.DataSource = subArrays;

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string paddingIndex = string.Format("{0:00}", comboBox1.SelectedIndex+1);
            string file = "MaxSubArray_" + paddingIndex;
            var data =
                allData[file].Trim()
                    .Replace("\r\n", "")
                    .Split(',')
                    .Where(f => !string.IsNullOrEmpty(f))
                    .Select(d => Convert.ToInt32(d))
                    .ToArray();
            var getAnswer = Utility.FindMaximumSubArray(data, 0, data.Length - 1);
            MessageBox.Show(outputformat(file, getAnswer));

        }

        public string outputformat(string csvFileName, SubArray s)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CSCI 5330 Spring 2016\r\n");
            sb.Append("David Lewis\r\n");
            sb.Append("900732205\r\n\r\n");
            sb.Append(string.Format("Running data for file {0}\r\n",csvFileName));
            sb.Append(s);

            return sb.ToString();
        }
    }

   
    public struct SubArray
    {
        public int Low { get; set; }
        public int High { get; set; }
        public int Sum { get; set; }

        public override string ToString()
        {   
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("{0}= {1}\r\n", "Low", Low));
            sb.Append(string.Format("{0}= {1}\r\n", "High", High));
            sb.Append(string.Format("{0}= {1}\r\n", "Max", Sum));
            return sb.ToString();
        }
    }
}
