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
    public partial class AssigmentView : Form
    {
        SqlConnection con = new SqlConnection("Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=true;");
        SqlCommand cmd;
        SqlDataReader reader;
       
        public AssigmentView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        } 

       

        private void AssigmentView_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog na = new SaveFileDialog() { Filter = "ALL files|*.*" })
            {
                if (na.ShowDialog() == DialogResult.OK)
                {
                    DialogResult dialog = MessageBox.Show("are sure you want to downlord this file ?", "Colombo_city_Institute", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.Yes)
                    {
                        string filename = na.FileName;
                        downloadfile(filename);
                    }
                    else
                    {

                        return;
                    }
                }

            }


        }



        private void downloadfile(String file)
        {
            con.Open();
            bool en = false;
            using (cmd = new SqlCommand("select upload from Documents where ID='" + textBox1 + "'", con))
            {
                using (reader = cmd.ExecuteReader(CommandBehavior.Default))
                {
                    if (reader.Read())
                    {
                        en = true;
                        byte[] filedata = (byte[])reader.GetValue(0);
                        using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite))
                        {
                            using (BinaryWriter bw = new BinaryWriter(fs))
                            {
                                bw.Write(filedata);
                                bw.Close();
                            }
                        }
                        MessageBox.Show("Download Done");
                    }
                    if (en == false)
                    {
                        MessageBox.Show("no data");
                    }
                    reader.Close();
                }
            }
        }

       

    }
}
