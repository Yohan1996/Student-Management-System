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
    
    public partial class student_coordinator : Form
    {
        SqlConnection con = new SqlConnection();

        public student_coordinator()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=GLDHAMMIKAMANA\\SQLEXPRESS; Initial Catalog=CCI;Integrated Security=True";
            InitializeComponent();
        }

        private void student_coordinator_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=True");
            con.Open();
            menuStrip2.Visible = false;
        }

        private void student_coordinator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void batchDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grade na = new grade();
            na.Show();
        }

        private void subjectDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }


        //Cordinator Login
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=True";
            con.Open();
            string username = textBox1.Text;
            string password = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select username,password from create_coordinator where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {


                panel1.Visible = false;
                menuStrip2.Visible = true;
            }
            else
            {

                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();
        }

        private void insertUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudent na = new ManageStudent();
            na.Show();
                   
        }

        private void addBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Courses na = new Courses();
            na.Show();
        }

        private void assignmentSubmissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssigmentView na = new AssigmentView();
            na.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssigmentView na = new AssigmentView();
            na.Show();
        }

        private void assignmentGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void insertUpdateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grade na = new grade();
            na.Show();
        }

        private void printStudentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void studentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print na = new Print();
            na.Show();
        }

        private void studentGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print2 na = new Print2();
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

