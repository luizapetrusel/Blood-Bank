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
    public partial class Form4 : Form
    {
        myDBConnection con = new myDBConnection();
        MySqlCommand command;
        MySqlDataAdapter da;
        DataTable dt;
        string sql;
        int result;

        public Form4()
        {
            InitializeComponent();
            con.Connect();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (userTextbox.Text == "")
            {
                MessageBox.Show("Username cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (passwordTextbox.Text == "")
            {
                MessageBox.Show("Password cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sql = "Insert into users ( username, password ) VALUES " +
                    "('" + userTextbox.Text + "' " +
                    ",'" + passwordTextbox.Text + "')";
            try
            {
                con.cn.Open();
                command = new MySqlCommand();
                command.Connection = con.cn;
                command.CommandText = sql;
                result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Account created!");
                }
                else
                {
                    MessageBox.Show("Cannot create account!");
                }
                con.cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            userTextbox.Clear();
            passwordTextbox.Clear();


        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }
    }
}
