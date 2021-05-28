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
    public partial class createcordinator : Form
    {

        SqlConnection con = new SqlConnection("Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
      
        public createcordinator()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from create_coordinator", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void createcordinator_Load(object sender, EventArgs e)
        {

        }

        

        private void txtschool_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into create_coordinator(username,employeeID, password, gender, mobile, job, address)values(@username,@employeeID, @password, @gender, @mobile, @job ,@address )", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@username", txtname.Text);
            cmd.Parameters.AddWithValue("@employeeID", txtid.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@gender", radioButton1.Text);
            cmd.Parameters.AddWithValue("@mobile", txtmobile.Text);
 
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
           
            txtschool.Text = "";
            txtaddress.Text = "";
            ID = 0;
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
           
            txtschool.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtaddress.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update create_coordinator set username=@username,employeeID=@employeeID, password=@password, gender=@gender, mobile=@mobile, job=@job, address=@address  where ID=@ID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@username", txtname.Text);
            cmd.Parameters.AddWithValue("@employeeID", txtid.Text);
            cmd.Parameters.AddWithValue("@password", txtpassword.Text);
            cmd.Parameters.AddWithValue("@gender", radioButton1.Text);
            cmd.Parameters.AddWithValue("@mobile", txtmobile.Text);
       

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
                cmd = new SqlCommand("delete create_coordinator where ID=@ID", con);
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

    }
}
