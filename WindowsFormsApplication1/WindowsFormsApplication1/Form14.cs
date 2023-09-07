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
    public partial class Form14 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Desktop\Ahmed-12224-VPL-Project\WindowsFormsApplication1\WindowsFormsApplication1\Database1.mdf;Integrated Security=True");
        
        public Form14()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Patient_Data where PId = '" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["PName"].ToString();
                textBox2.Text = dr["PNumber"].ToString();
                textBox3.Text = dr["PAddress"].ToString();
                textBox4.Text = dr["PGender"].ToString();
                textBox5.Text = dr["Doctor"].ToString(); 
                textBox7.Text = dr["Ward"].ToString();
                textBox8.Text = dr["Date"].ToString();
            }
            cn.Close();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            combo();
            hellocombo();
            hellocombo2();

        }
        public void combo()
        {
            comboBox1.Items.Clear();
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Patient_Data";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["PId"].ToString());
            }

            cn.Close();
        }
        public void hellocombo()
        {
            comboBox2.Items.Clear();
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
                comboBox2.Items.Add(dr["FirstName"].ToString());
            }

            cn.Close();
        }
        public void hellocombo2()
        {
            comboBox3.Items.Clear();
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Rooms";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox3.Items.Add(dr["Type"].ToString());
            }

            cn.Close();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Doc_Data1 where FirstName = '" + comboBox2.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox6.Text = dr["Fee"].ToString();
               
            }
            cn.Close();
        }

        public void disp_data()
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Bill";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            cn.Close();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            int Result;
            Int32 val1 = Convert.ToInt32(textBox10.Text);
            Int32 val2 = Convert.ToInt32(textBox9.Text);
            Int32 val3 = val1 * val2;
            Int32 val4 = Convert.ToInt32(textBox6.Text);
            Int32 finalbill = val3 + val4;
            int num = Convert.ToInt32(textBox2.Text);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Bill values ('" + comboBox1.Text + "','" + textBox1.Text + "','" + num + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + comboBox2.Text + "','" + textBox6.Text + "','" + val3  + "','" +  finalbill + "')";
            cmd.ExecuteNonQuery();
            cn.Close();

            MessageBox.Show("Record Inserted Successfully");

        }


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Rooms where type = '" + comboBox3.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox10.Text = dr["charges"].ToString();

            }
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            this.Hide();
            f15.Show();

        }
    }
}
