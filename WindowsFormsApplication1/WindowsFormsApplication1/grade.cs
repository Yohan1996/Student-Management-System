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
    public partial class grade : Form
    {
        SqlConnection con = new SqlConnection("Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
       
        public grade()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Grade", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into Grade(SID,name, course, batch, Assignment_name, grade)values(@SID,@name, @course, @batch, @Assignment_name, @grade)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@SID", txtSID.Text);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@course", txtcourse.Text);
            cmd.Parameters.AddWithValue("@batch", txtbatch.Text);

            cmd.Parameters.AddWithValue("@Assignment_name", txta_name.Text);

            cmd.Parameters.AddWithValue("@grade", txtgrade.Text);
            
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
            ClearData();
            MessageBox.Show("Record Inserted Successfully");

        }

        private void ClearData()
        {
            txtname.Text = "";
            txtSID.Text = "";
            txtcourse.Text = "";
            txtbatch.Text = "";

            txta_name.Text = "";
            txtgrade.Text = "";
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
            txtcourse.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
            txtbatch.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

            txta_name.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtgrade.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update Grade set SID=@SID,name=@name, course=@course, batch=@batch, Assignment_name=@Assignment_name, grade=@grade where ID=@ID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@SID", txtSID.Text);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@course", txtcourse.Text);
            cmd.Parameters.AddWithValue("@batch", txtbatch.Text);

            cmd.Parameters.AddWithValue("@Assignment_name", txta_name.Text);

            cmd.Parameters.AddWithValue("@grade", txtgrade.Text);

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
                cmd = new SqlCommand("delete Grade where ID=@ID", con);
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
