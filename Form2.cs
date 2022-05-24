using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BloodBank
{
    public partial class Form2 : Form
    {
        myDBConnection con = new myDBConnection();
        MySqlCommand command, command1;
        MySqlDataAdapter da;
        DataTable dt;
        MySqlDataReader dr, dr1;
        int result;
        int sql;

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        public Form2()
        {
            InitializeComponent();
            con.Connect();
        }

        private void donateButton_Click(object sender, EventArgs e)
        {
            con.cn.Open();
            command = new MySqlCommand();
            command.Connection = con.cn;
            command.CommandText = "SELECT * FROM donors where firstName='" + firstnameTextbox.Text + "' AND lastName='" + lastnameTextbox.Text + "'";
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                //command1 = new MySqlCommand();
                // command1.Connection = con.cn;
                con.cn.Close();
                con.cn.Open();
                command = new MySqlCommand();
                command.Connection = con.cn;
                command.CommandText = "Insert into blood_donation (dateDonated, quantity ) VALUES " +
                    "('" + dateTextbox.Text + "' " + ",'" + quantityTextbox.Text + "')";
                // dr = command.ExecuteReader();
                sql = command.ExecuteNonQuery();
                if (sql>0)
                {
                    MessageBox.Show("Donation made succesfully!");
                }
                else
                {
                    MessageBox.Show("Donation not made!");
                }
            }
            else
            {
                MessageBox.Show("Donor not in the database");
            }
            firstnameTextbox.Clear();
            lastnameTextbox.Clear();
            dateTextbox.Clear();
            quantityTextbox.Clear();
            con.cn.Close();
        }
    }
}
