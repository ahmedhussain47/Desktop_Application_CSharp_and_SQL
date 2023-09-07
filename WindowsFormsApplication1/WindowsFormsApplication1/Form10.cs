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
    public partial class Form10 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Desktop\Ahmed-12224-VPL-Project\WindowsFormsApplication1\WindowsFormsApplication1\Database1.mdf;Integrated Security=True");

        public Form10()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from OPD1 where Id = '" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["Name"].ToString();
                textBox2.Text = dr["Days"].ToString();
                textBox3.Text = dr["Timings"].ToString();
                textBox4.Text = dr["Fees"].ToString();
            }
            cn.Close();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            disp_data();
            combo();
        }
        public void disp_data()
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from OPD1";
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
            cmd.CommandText = "select * from OPD1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Id"].ToString());
            }

            cn.Close();
        }
   

        private void button1_Click_1(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd =
            cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            int ro = Convert.ToInt16(comboBox1.Text);
            cmd.CommandText = "update OPD1 set Name = '" + textBox1.Text + "',Days = '" + textBox2.Text + "',Timings='" + textBox4.Text + "' where Id = '" + ro + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            cn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            disp_data();

            combo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from OPD1 where Id='" + comboBox1.Text + "'";
            cmd.ExecuteNonQuery();
            cn.Close();
            disp_data();
            MessageBox.Show("Record deleted Successfully");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form9 f9 = new Form9();
            f9.Show();
        }
    }
}
