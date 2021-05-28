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
    public partial class EngineeringStream : Form
    {
        SqlConnection con = new SqlConnection("Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        //ID variable used in Updating and Deleting Record  
        int ID = 0;
        public EngineeringStream()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from EngineeringStream", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into EngineeringStream(BatchID,name, stream, NoOfSubjects, subject1 , subject2, subject3, subject4, subject5)values(@BatchID,@name, @stream,@NoOfSubjects, @subject1 , @subject2, @subject3 ,@subject4, @subject5)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@BatchID", txtBatchID.Text);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@stream", txtstream.Text);
            cmd.Parameters.AddWithValue("@NoOfSubjects", txtNoSub.Text);
            cmd.Parameters.AddWithValue("@subject1", textsub1.Text);
            cmd.Parameters.AddWithValue("@subject2", txtsub2.Text);
            cmd.Parameters.AddWithValue("@subject3", textsub3.Text);
            cmd.Parameters.AddWithValue("@subject4", textsub4.Text);
            cmd.Parameters.AddWithValue("@subject5", textsub5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayData();
            ClearData();
            MessageBox.Show("Record Inserted Successfully");
        }

        private void ClearData()
        {
            txtBatchID.Text = "";
            txtname.Text = "";

            txtNoSub.Text = "";
            textsub1.Text = "";
            txtsub2.Text = "";
            textsub3.Text = "";
            textsub4.Text = "";
            textsub5.Text = "";
            ID = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("update EngineeringStream set BatchID=@BatchID,name=@name, stream=@stream, NoOfSubjects=@NoOfSubjects, subject1=@subject1 , subject2=@subject2, subject3=@subject3, subject4=@subject4, subject5=@subject5  where ID=@ID", con);
            con.Open();
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@BatchID", txtBatchID.Text);
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@stream", txtstream.Text);
            cmd.Parameters.AddWithValue("@NoOfSubjects", txtNoSub.Text);
            cmd.Parameters.AddWithValue("@subject1", textsub1.Text);
            cmd.Parameters.AddWithValue("@subject2", txtsub2.Text);
            cmd.Parameters.AddWithValue("@subject3", textsub3.Text);
            cmd.Parameters.AddWithValue("@subject4", textsub4.Text);
            cmd.Parameters.AddWithValue("@subject5", textsub5.Text);

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
                cmd = new SqlCommand("delete EngineeringStream where ID=@ID", con);
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

        private void dataGridView1_RowHeaderMousClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtBatchID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtstream.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtNoSub.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textsub1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtsub2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textsub3.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            textsub4.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textsub5.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();

        }
    }
}
