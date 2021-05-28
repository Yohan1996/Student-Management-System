using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class student_login : Form
    {
        //Create Connection
        SqlConnection con = new SqlConnection();

        // Open Connection
        public student_login()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog =school;integrated security=true";
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=True");
            con.Open();
            menuStrip1.Visible = false;
        }

        //Exit
        private void student_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        //Find user and validate password
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=True";
            con.Open();
            string userid = textBox1.Text;
            string password = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select username,password from create_student where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
           
            if (dt.Rows.Count > 0)
            {

               
                panel1.Visible = false;
                menuStrip1.Visible = true;
            }
            else
            {
               
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void viweInformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            viwe_detail na = new viwe_detail();
            na.Show();
        }

        private void viweStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_grade na = new view_grade();
            na.Show();
        }

        private void assigmentSubmissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            up na = new up();
            na.Show();
        }

        private void assignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void studentDeatilToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void assignmentSubmissionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            up na = new up();
            na.Show();
        }

        private void assigmentGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_grade na = new view_grade();
            na.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login na = new login();
            na.Show();
            this.Hide();
        }
    }
}
