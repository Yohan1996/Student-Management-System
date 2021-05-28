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
using System.IO;

namespace WindowsFormsApplication1
{
    
    public partial class up : Form
    {
        SqlConnection con = new SqlConnection("Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=true;");
      
        public up()
        {
            
            InitializeComponent();
        }

        

       

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
          
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
         
        }

        private void up_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtstreams_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtstatus_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            textBox1.Text = dlg.FileName;
        }


        //Upload Assignment
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFile(textBox1.Text);
            MessageBox.Show("Submitted");
        }

        private void SaveFile(String filePath)
        {
            using (Stream stream = File.OpenRead(filePath))
            {

                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                string extn = new FileInfo(filePath).Extension;

                string query = "INSERT INTO Documents(SID,Batch, Subject, Stream,Status, Data, Extension)VALUES(@SID,@Batch, @Subject, @Stream, @Status, @data, @extn)";

                con.Open();

                
                    SqlCommand cmd = new SqlCommand(query, con);
                    
                    cmd.Parameters.AddWithValue("@SID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Batch", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Subject", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Stream", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Status", textBox6.Text = "Submited");
                    cmd.Parameters.Add("@data", SqlDbType.VarBinary).Value = buffer;
                    cmd.Parameters.Add("@extn", SqlDbType.Char).Value = extn;
                    
                    cmd.ExecuteNonQuery();
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
       
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            LoadData();
        }

        private void LoadData()
        {
            
            


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
       
            
        
    }
}
