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
    public partial class Form9 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hp\Desktop\Ahmed-12224-VPL-Project\WindowsFormsApplication1\WindowsFormsApplication1\Database1.mdf;Integrated Security=True");

        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            int ro = Convert.ToInt16(textBox1.Text);
            SqlCommand cmd = new SqlCommand("select * from OPD1 where Id ='" + ro + "'", cn);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dr.Close();
                DialogResult dialogResult = MessageBox.Show("OPD I'd Already exist please try another ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
                cmd.CommandText = "insert into OPD1 values ('" + ro + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')"; cmd.Parameters.AddWithValue("username", textBox1.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                MessageBox.Show("Record Inserted Successfully");
          }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            this.Hide();
            f7.Show();
     
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}
