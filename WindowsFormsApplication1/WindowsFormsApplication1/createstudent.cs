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
    public partial class createstudent : Form
    {

         SqlConnection con = new SqlConnection("Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
      
        public createstudent()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from create_student", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }


       
        //Insert logging details
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into create_student(username,registration, password, gender, mobile , course, job, address)values(@username,@registration, @password,@gender, @mobile , @course, @job ,@address )", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@username", txtname.Text);
            cmd.Parameters.AddWithValue("@registration", txtid.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@gender", radioButton1.Text);
            cmd.Parameters.AddWithValue("@mobile", txtmobile.Text);
            cmd.Parameters.AddWithValue("@course", txtemail.Text);
            cmd.Parameters.AddWithValue("@job", txtschool.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
            ClearData();
            MessageBox.Show("Record Inserted Successfully");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            cmd = new SqlCommand("insert into create_student(username,registration, password, gender, mobile , course, job, address)values(@username,@registration, @password,@gender, @mobile , @course, @job ,@address )", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@username", txtname.Text);
            cmd.Parameters.AddWithValue("@registration", txtid.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@gender", radioButton1.Text);
            cmd.Parameters.AddWithValue("@mobile", txtmobile.Text);
            cmd.Parameters.AddWithValue("@course", txtemail.Text);
            cmd.Parameters.AddWithValue("@job", txtschool.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
            ClearData();
            MessageBox.Show("Record Inserted Successfully");



        }

    
        private void ClearData()
        {
            txtname.Text = "";
            txtid.Text = "";
            txtpassword.Text = "";
            txtmobile.Text = "";
            txtemail.Text = "";
            txtschool.Text = "";
            txtaddress.Text = "";
            ID = 0;
        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtjob_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_RowHeaderMousClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtpassword.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            radioButton1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            radioButton2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtmobile.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtemail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtschool.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update create_student set username=@username,registration=@registration, password=@password, gender=@gender, mobile=@mobile , course=@course, job=@job, address=@address  where ID=@ID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@username", txtname.Text);
            cmd.Parameters.AddWithValue("@registration", txtid.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@gender", radioButton1.Text);
            cmd.Parameters.AddWithValue("@mobile", txtmobile.Text);
            cmd.Parameters.AddWithValue("@course", txtemail.Text);

            cmd.Parameters.AddWithValue("@job", txtschool.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            DisplayData();
            ClearData();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (ID != 0)
            {
                cmd = new SqlCommand("delete create_student where ID=@ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void txtschool_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
