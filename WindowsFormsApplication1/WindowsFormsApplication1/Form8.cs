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
    public partial class Form8 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Desktop\Ahmed-12224-VPL-Project\WindowsFormsApplication1\WindowsFormsApplication1\Database1.mdf;Integrated Security=True");
        SqlDataAdapter adapt;
        DataTable dt;
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            disp_data();
            combo();
            cn.Open();
            adapt = new SqlDataAdapter("select * from Patient_Data", cn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();

        }
        public void disp_data()
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Patient_Data";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cn.Open();
            int rom = Convert.ToInt32(textBox1.Text);
            SqlCommand cmd = new SqlCommand("select * from Patient_Data where PId ='" + rom + "'", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                DialogResult dialogResult = MessageBox.Show("Patient I'd Already exist please try another ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.OK)
                {
                    this.Hide();
                    Form8 f8 = new Form8();
                    f8.Show();
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    this.Hide();
                    Form4 f4 = new Form4();
                    f4.Show();
                }

            }
            else
            {
                
                dr.Close();
                int age = Convert.ToInt16(textBox4.Text);
                int num = Convert.ToInt32(textBox3.Text);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Patient_Data values ('" + rom + "','" + textBox2.Text + "','" + num + "','" + age + "','" + comboBox1.Text + "','" + comboBox3.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + comboBox2.Text + "','" + comboBox5.Text + "' ,'" + dateTimePicker1.Text + "')";
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Record Inserted Successfully");

                disp_data();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                


            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            
            cn.Open();
            adapt = new SqlDataAdapter("select * from Patient_Data where PId like '" + textBox11.Text + "%'", cn);
            dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            cn.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        public void combo()
        {
            comboBox5.Items.Clear();
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
                comboBox5.Items.Add(dr["FirstName"].ToString());
            }

            cn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Doc_Data1 where FirstName = '" + comboBox5.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();

            cn.Close();
        }
    }
}

