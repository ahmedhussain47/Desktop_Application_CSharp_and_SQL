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
    public partial class Form5 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Desktop\Ahmed-12224-VPL-Project\WindowsFormsApplication1\WindowsFormsApplication1\Database1.mdf;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Doc_Data1 where DocID = '" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["FirstName"].ToString();
                textBox2.Text = dr["SecondName"].ToString();
                textBox3.Text = dr["Gender"].ToString();
                textBox4.Text = dr["DocAddress"].ToString();
                textBox5.Text = dr["Fee"].ToString();
            }
            cn.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            disp_data();
            combo();
        }
        public void disp_data()
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Doc_Data1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }
        public void combo()
        {
            comboBox1.Items.Clear();
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Doc_Data1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["DocID"].ToString());
            }

            cn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            cn.Open();
            SqlCommand cmd =
            cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            int ro = Convert.ToInt16(comboBox1.Text);
            cmd.CommandText = "update Doc_Data1 set FirstName = '" + textBox1.Text + "',SecondName = '" + textBox2.Text + "',DocAddress='" + textBox4.Text + "',Fee='" + textBox5.Text + "' where DocID = '" + ro + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            cn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            disp_data();

            combo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Doc_Data where DocID='" + comboBox1.Text + "'";
            cmd.ExecuteNonQuery();
            cn.Close();
            disp_data();
            MessageBox.Show("Record deleted Successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();
        }
    }
}
