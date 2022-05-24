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
    public partial class Form1 : Form
    {
        myDBConnection con = new myDBConnection();
        MySqlCommand command;
        MySqlDataAdapter da;
        DataTable dt;
        MySqlDataReader dr;
        int result;
        string sql;

        public Form1()
        {
            InitializeComponent();
            con.Connect();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            con.cn.Open();
            command = new MySqlCommand();
            command.Connection = con.cn;
            command.CommandText = "SELECT * FROM users where username='" + userTextbox.Text + "' AND password='" + passwordTextbox.Text + "'";
            dr = command.ExecuteReader();
            if (dr.Read())
            {
                this.Hide();
                if (userTextbox.Text != "admin")
                {
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                }
                if (userTextbox.Text == "admin")
                {
                    Form3 f3 = new Form3();
                    f3.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Invalid Login! Please check username and password");
            }
            con.cn.Close();
            userTextbox.Clear();
            passwordTextbox.Clear();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }
    }
}
