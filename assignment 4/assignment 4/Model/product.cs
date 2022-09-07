using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace assignment_4.Model
{
    internal class product
    {
        static List<product> products = new List<product>();
        public int PID { get; set; }
        public DateTime date { get; set; }
        public string objectname { get; set; }
        public int price { get; set; }

        // public  Boolean isavailable { get; set; }
       

        

        public void save()
        {
           
            string connetionString = "Data Source=LAPTOP-T23BOQMU;Initial Catalog=master;Integrated Security=true";

            SqlConnection cnn = new SqlConnection(connetionString);



            try
            {

                cnn.Open();
                string query = "insert into product values(" + PID + "," + "'" + objectname + "'" + "," + price +","+ "'" + date +"' )";

                SqlCommand cmd = new SqlCommand(query, cnn);
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Saved to DB ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

       
        }
        
        public void Add()
            {
                products.Add(this);
            }

        public static List<product> findbyname(string name)
        { 
                return products.FindAll(p=> p.objectname==name); 

        }
        public static List< product> findbyPrice(double price)
        {
            return products.FindAll(p => p.price == price);
        }
        public static List<product> getallproducts() 
        {
            string connetionString = null;
            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;

            SqlConnection cnn;

            sql = " Select * from product";
            connetionString = "Data Source=LAPTOP-T23BOQMU;Initial Catalog=master; User ID=sa;Password=1234";



            try
            {
                cnn = new SqlConnection(connetionString);
                cnn.Open();

                command = new SqlCommand(sql, cnn);
                dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    product p = new product();

                    p.PID = Convert.ToInt32(dataReader.GetValue(0).ToString());
                   p.objectname = dataReader.GetValue(1).ToString();
                   p. price = Convert.ToInt32(dataReader.GetValue(2).ToString());
                   p. date = Convert.ToDateTime(dataReader.GetValue(3).ToString());
                    p.Add();

                }


                dataReader.Close();
                command.Dispose();
                cnn.Close();
                MessageBox.Show(" open connection ! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }

            return products;    
        }
    }
}
