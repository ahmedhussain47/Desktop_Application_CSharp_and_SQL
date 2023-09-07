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
    public partial class Form6 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Desktop\Ahmed-12224-VPL-Project\WindowsFormsApplication1\WindowsFormsApplication1\Database1.mdf;Integrated Security=True");

        public Form6()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            int ro = Convert.ToInt16(textBox1.Text);
            SqlCommand cmd = new SqlCommand("select * from Doc_Data1 where DocID ='" + ro + "'", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                DialogResult dialogResult = MessageBox.Show("Doctor I'd Already exist please try another ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (dialogResult == DialogResult.OK)
                {
                    this.Hide();
                    Form6 f6 = new Form6();
                    f6.Show();
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
                cmd.CommandType = CommandType.Text;
                int charg = Convert.ToInt16(textBox6.Text);

                cmd.CommandText = "insert into Doc_Data1 values ('" + ro + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')"; cmd.Parameters.AddWithValue("username", textBox1.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox6.Clear();
                MessageBox.Show("Record Inserted Successfully");


            }
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
