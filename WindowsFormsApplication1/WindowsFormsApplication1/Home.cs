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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        //Go to Administrator Login
        private void button3_Click(object sender, EventArgs e)
        {
            Administrator_login f1 = new Administrator_login();
            this.Hide();
            f1.ShowDialog();
        }

        //Go to Student Login
        private void button4_Click(object sender, EventArgs e)
        {
            student_login f1 = new student_login();
            this.Hide();
            f1.ShowDialog();

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            student_coordinator f1 = new student_coordinator();
            this.Hide();
            f1.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
