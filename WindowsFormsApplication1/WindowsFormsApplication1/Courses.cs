using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Courses : Form
    {
        public Courses()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManagementStream na = new ManagementStream();
            na.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EngineeringStream na = new EngineeringStream();
            na.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IT na = new IT();
            na.Show();
        }
    }
}
