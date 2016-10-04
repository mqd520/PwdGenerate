using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PwdGenerate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pwd = Tool.Generate(12);
            textBox1.Text = pwd;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pwd = "";
            if (textBox2.Text.Trim() != "")
            {
                pwd = Tool.Generate(textBox2.Text.Trim().ToCharArray(), number: true);
            }
            else
            {
                pwd = Tool.Generate(12);
            }
            textBox1.Text = pwd;
        }
    }
}
