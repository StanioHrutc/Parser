using Purser.Core;
using Purser.Core.Habra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Purser.Core
{
    public partial class MainForm : Form
    {
        ParserWorker<string[]> parser;

        public MainForm()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(new HabraParser());

            parser.OnCompleted += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            listBox.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All works done!");
        }

       

        private void button3_Click_1(object sender, EventArgs e)
        {
            parser.Settings = new HabraSettings((int)numericUpDown3.Value, (int)numericUpDown4.Value);
            parser.Start();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            parser.Abort();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
