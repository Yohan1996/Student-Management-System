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
    public partial class viwe_detail : Form
    {
        SqlConnection con = new SqlConnection("Data Source=GLDHAMMIKAMANA\\SQLEXPRESS;Initial Catalog=CCI;Integrated Security=true;");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter adpt;
        
        public viwe_detail()
        {
            InitializeComponent();
            Displayvalue();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void viwe_detail_Load(object sender, EventArgs e)
        {

        }

        public void Displayvalue()
        {

            con.Open();
            adpt = new SqlDataAdapter("select * from Manage_Student", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();




        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            SearchData(txtname.Text);

        }
        public void SearchData(string search)
        {

            con.Open();
            string query = "select * from Manage_Student where name like'%" + search + "%'";
            adpt = new SqlDataAdapter(query, con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void lblBatchId_Click(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
           


        }
    }

