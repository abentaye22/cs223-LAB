﻿using assignment_4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace assignment_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void butn_add_Click(object sender, EventArgs e)
        {
            product p = new product();
            
            Regex number_error = new Regex(@"[0-9]{" + text_number.Text.Length + @"}");
            Regex inventory_error = new Regex(@"[0-9]{" + text_IN.Text.Length + @"}");
            Regex object_error = new Regex(@"[a-z A-Z]{" + text_objectname.Text.Length + @"}");
            Regex count_error = new Regex(@"[0-9]{" + text_count.Text.Length + @"}");
            Regex price_error = new Regex(@"[0-9]{" + text_price.Text.Length + @"}");

            string message = " ";
            foreach (var item in chk_options.CheckedItems)
            {
                message += item.ToString()+" ";
            }
            MessageBox.Show(message);

            errorProvider1.SetError(text_price, null);
            errorProvider1.SetError(text_count, null);
            errorProvider1.SetError(text_objectname, null);
            errorProvider1.SetError(text_IN, null);
            errorProvider1.SetError(text_number, null);

            if ((text_number.Text.Length != 0 && text_IN.Text.Length != 0 && text_objectname.Text.Length != 0 && text_count.Text.Length != 0 && text_price.Text.Length != 0) && (number_error.IsMatch(text_number.Text) && inventory_error.IsMatch(text_IN.Text) && object_error.IsMatch(text_objectname.Text) && count_error.IsMatch(text_count.Text)/* && price_error.IsMatch(text_price.Text)*/))
            
            {
                  
               

                    p.PID = Convert.ToInt32(text_number.Text);
                    p.date = dateTimePicker1.Value;
                    p.objectname = text_objectname.Text;
                    p.price = Convert.ToInt32(text_price.Text);

               /* if (cash_rbtn.Checked) p.payment = "cash";
                else p.payment = "money";
                
                if (eth_rbtn.Checked) p.location = "Addis ababa";
                else p.location = "other";*/
                    
                    p.save();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = product.getallproducts();
                
                }

            else { 
                if (string.IsNullOrEmpty(text_number.Text))
                {
                    errorProvider1.SetError(text_number, "please provide a number ");

                }

                else if(number_error.IsMatch(text_number.Text)==false)
                {
                    errorProvider1.SetError(text_number, "please enter a number only ");
                }

                if (string.IsNullOrEmpty(text_IN.Text))
                {
                    errorProvider1.SetError(text_IN, "enter a number ");


                }       
                 else if(inventory_error.IsMatch(text_IN.Text)==false) 
                  {
                        errorProvider1.SetError(text_IN, "please enter numbers only ");
                  }
                
             if (string.IsNullOrEmpty(text_objectname.Text))
                    {
                        errorProvider1.SetError(text_objectname, "please provide a name ");


                    }
                 else if(object_error.IsMatch(text_objectname.Text)==false)
                    {  
                     errorProvider1.SetError(text_objectname, "please enter letters only ");
                    }

                    if (string.IsNullOrEmpty(text_count.Text))
                    {
                        errorProvider1.SetError(text_count, "please provide a number ");


                    }
                    else if(count_error.IsMatch(text_count.Text)==false)
                    {
                       
                 errorProvider1.SetError(text_count, "please enter a number only ");
                    }

                    if (string.IsNullOrEmpty(text_price.Text))
                    {
                        errorProvider1.SetError(text_price, "please provide a number ");


                    }
                    else if(price_error.IsMatch(text_price.Text) ==false)
                    {
                    errorProvider1.SetError(text_price, "please enter a number only "); 
                    }

                }
            

        }

        private void butn_canel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butn_reset_Click(object sender, EventArgs e)
        {
              text_number.Text="";
              dateTimePicker1.Value =DateTime.Now;
              text_IN.Text = "";
              text_objectname.Text =  "";
              text_count.Text = "";
              text_price.Text = "";
            errorProvider1.SetError(text_price, null);
            errorProvider1.SetError(text_count, null);
            errorProvider1.SetError(text_objectname, null);
            errorProvider1.SetError(text_IN, null);
            errorProvider1.SetError(text_number, null);



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void welcome_lbl_Click(object sender, EventArgs e)
        {

        }

        private void logout_butn_Click(object sender, EventArgs e)
        {
            Dispose();
            loginform loginpage=new loginform();
            loginpage.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
