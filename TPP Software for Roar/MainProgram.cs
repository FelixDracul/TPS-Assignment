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
    

namespace TPP_Software_for_Roar
{
    public partial class MainProgram : Form
    {
        //SqlCommand cmd;
        //SqlDataAdapter sda;
        //SqlCommandBuilder scb;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\TPS-Assignment\AccountsD.mdf;Integrated Security=True;Connect Timeout=30";

        public MainProgram()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)

        {
            this.Dispose();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }

        private void Date_Click(object sender, EventArgs e)
        {

        }
        //Payment Accounts
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\TPS-Assignment\AccountsD.mdf;Integrated Security=True;Connect Timeout=30");
                //MessageBox.Show("Successfully connected");
                String query = "INSERT INTO Payable_Accounts(Invoice#,Invoice_Date,Account_Holder,Account_Number,Payment_Amount) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

       
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\TPS-Assignment\AccountsD.mdf;Integrated Security=True;Connect Timeout=30");
                //MessageBox.Show("Successfully connected");
                String query = "UPDATE Payable_Accounts SET Invoice_Date='" + textBox2.Text + "',Account_Holder='" + textBox3.Text + "',Account_Number='" + textBox4.Text + "',Payment_Amount='" + textBox5.Text + "' where Invoice#='" + textBox1.Text + "'";
                //"UPDATE Receivable_Accounts SET Invoice#='"+textBox10.Text+"',Invoice_Date='"+textBox6.Text+"',Account_Holder='"+textBox9.Text+"',Account_Number='"+textBox8.Text+"',Payment_Amount='"+textBox7.Text+"') WHERE Invoice#='"+textBox10.Text+"' ";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Edited");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        //Receivable Accounts
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\TPS-Assignment\AccountsD.mdf;Integrated Security=True;Connect Timeout=30");
                //MessageBox.Show("Successfully connected");
                String query = "INSERT INTO Receivable_Accounts(Invoice#,Invoice_Date,Account_Holder,Account_Number,Receivable_Amount) Values ('" + textBox10.Text + "','" + textBox6.Text + "','" + textBox9.Text + "','" + textBox8.Text + "','" + textBox7.Text + "')";
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Saved");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SANSA\source\repos\TPS-Assignment\AccountsD.mdf;Integrated Security=True;Connect Timeout=30");
                //MessageBox.Show("Successfully connected");
                String query = "UPDATE Receivable_Accounts SET Invoice_Date='"+textBox6.Text+"',Account_Holder='"+textBox9.Text+"',Account_Number='"+textBox8.Text+"',Receivable_Amount='"+textBox7.Text+"' WHERE Invoice#='"+textBox10.Text+"' ";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully Edited");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //DataGridView Payable accounts.
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            


                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select * From Payable_Accounts", sqlcon);
                    DataTable dtbl = new DataTable();
                    sqlDa.Fill(dtbl);
                    dataGridView1.DataSource = dtbl;

                }

                 
            
        }
        //DataGridView Receivable accounts.
        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select * From Receivable_Accounts", sqlcon);
                DataTable dtbl1 = new DataTable();
                sqlDa.Fill(dtbl1);
                dataGridView2.DataSource = dtbl1;

            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainProgram_Load(object sender, EventArgs e)
        {
            timer1.Start();
            Date.Text = DateTime.Now.ToLongDateString();
            Time.Text = DateTime.Now.ToLongTimeString();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cr = new ColorDialog();
            if(cr.ShowDialog()==DialogResult.OK)
            {
                this.BackColor = cr.Color;
            }
        }
    }
    }

