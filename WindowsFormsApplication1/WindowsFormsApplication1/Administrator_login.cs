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
    public partial class Administrator_login : Form
    {
        SqlConnection con = new SqlConnection();
        public Administrator_login()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=True";
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=True");
            con.Open();
            menuStrip1.Visible = false;
           
        }

        //Administrator Login
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=True";
            con.Open();
            string username = textBox1.Text;
            string password = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select username,password from create_administrator where username='" + textBox1.Text + "'and password='" + textBox2.Text + "'", con);
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

        private void Administrator_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About na = new About();
            na.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createstudent na = new createstudent();
            na.Show();
        }

        private void deleteUserToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void manageUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudent na = new ManageStudent();
            na.Show();
        }

        private void deleteUserToolStripMenuItem2_Click(object sender, EventArgs e)
        {
          
            
        }

        private void createStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createcordinator na = new createcordinator();
            na.Show();
        }

        private void exitSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void createAdministratorLoggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createAdministrator na = new createAdministrator();
            na.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login na = new login();
            na.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
