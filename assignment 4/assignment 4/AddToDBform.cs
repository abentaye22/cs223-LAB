using assignment_4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment_4
{
    public partial class AddToDBform : Form
    {
        
        public AddToDBform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<product> temp = new List<product>();
            product p=new product();

            
            p.PID = Convert.ToInt32(textBox1.Text);;
            p.date = dateTimePicker1.Value;
            p.objectname=textBox2.Text;
            p.price = Convert.ToInt32(textBox3.Text);    
            p.save(); 
            temp.Add(p);
            


            /*string connetionString = "Data Source=LAPTOP-T23BOQMU;Initial Catalog=master;Integrated Security=true";

            SqlConnection cnn = new SqlConnection(connetionString);



            try
            {

                cnn.Open();
                // string query = "  use university insert into accounting values("+Convert.ToInt32(textBox1.Text)+","+ textBox2.Text + "," + textBox3.Text + "," +textBox4.Text + "," + textBox5.Text+")";

                string query = "  insert into product values(" + Convert.ToInt32(textBox1.Text) + "," + "'" + Convert.ToString(textBox2.Text) + "'" + "," + Convert.ToInt32(textBox3.Text) + ")";

                SqlCommand cmd = new SqlCommand(query, cnn);
                var result = cmd.ExecuteNonQuery();
                label1.Text = result.ToString();
                MessageBox.Show("Connection Open ! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
        }

        private void AddToDBform_Load(object sender, EventArgs e)
        {

        }
    }
}
