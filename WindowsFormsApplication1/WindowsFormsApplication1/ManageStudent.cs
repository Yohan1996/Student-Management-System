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

      
    public partial class ManageStudent : Form
    {

        SqlConnection con = new SqlConnection("Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
        public ManageStudent()
        {
            InitializeComponent();
             DisplayData();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Manage_Student", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        //insert data
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into Manage_Student(SID,name ,BatchID, course, gender , mobile, home, address)values(@SID, @name, @BatchID,@course, @gender , @mobile, @home ,@address )", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@SID", txtSID.Text);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@BatchID", txtBatch.Text);
            cmd.Parameters.AddWithValue("@course", txtCourse.Text);
            cmd.Parameters.AddWithValue("@gender", radioButton1.Text);
            cmd.Parameters.AddWithValue("@mobile", txtmobile.Text);
            
            cmd.Parameters.AddWithValue("@home", txtHome.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
            ClearData();
            MessageBox.Show("Record Inserted Successfully");
        }
        private void ClearData()
        {
            txtSID.Text = "";
            txtname.Text = "";
            txtBatch.Text = "";
            txtmobile.Text = "";
            txtCourse.Text = "";
            txtHome.Text = "";
            txtaddress.Text = "";
            ID = 0;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridView1_RowHeaderMousClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtSID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtBatch.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtCourse.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            radioButton1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            radioButton2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtmobile.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtHome.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();

        }


        //Update Data
        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update Manage_Student set SID=@SID,name=@name, BatchID=@BatchID, course=@course, gender=@gender, mobile=@mobile, home=@home, address=@address  where ID=@ID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@SID", txtSID.Text);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@BatchID", txtBatch.Text);
            cmd.Parameters.AddWithValue("@course", txtCourse.Text);
            cmd.Parameters.AddWithValue("@gender", radioButton1.Text);
            cmd.Parameters.AddWithValue("@mobile", txtmobile.Text);

            cmd.Parameters.AddWithValue("@home", txtHome.Text);
            cmd.Parameters.AddWithValue("@address", txtaddress.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            DisplayData();
            ClearData();
        }


        //Delete Data
        private void button3_Click(object sender, EventArgs e)
        {
            if (ID != 0)
            {
                cmd = new SqlCommand("delete Manage_Student where ID=@ID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", ID);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
