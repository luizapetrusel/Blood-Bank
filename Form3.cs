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
    public partial class Form3 : Form
    {
        myDBConnection con = new myDBConnection();
        MySqlCommand command;
        MySqlDataAdapter da;
        DataTable dt;
        string sql;
        int result;

        public Form3()
        {
            InitializeComponent();
            con.Connect();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            getDonors();
            getRecipients();
        }

        private void getDonors()
        {
            try
            {
                con.cn.Open();
                command = new MySqlCommand("Select * from donors", con.cn);
                command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                con.cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getRecipients()
        {
            try
            {
                con.cn.Open();
                command = new MySqlCommand("Select * from recipients", con.cn);
                command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView2.DataSource = dt.DefaultView;
                con.cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (firstnameTextbox.Text == "")
            {
                MessageBox.Show("Firstname cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (lastnameTextbox.Text == "")
            {
                MessageBox.Show("Lastname cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (addressTextbox.Text == "")
            {
                MessageBox.Show("Address cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (phoneTextbox.Text == "")
            {
                MessageBox.Show("Phone cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (dateTextbox.Text == "")
            {
                MessageBox.Show("Date of birth cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (typeTextbox.Text == "")
            {
                MessageBox.Show("Blood type cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sql = "Insert into donors ( firstName, lastName, address, phone, dateOfBirth, bloodType ) VALUES " +
                    "('" + firstnameTextbox.Text + "' " +
                    ",'" + lastnameTextbox.Text + "' " +
                    ",'" + addressTextbox.Text + "' " +
                    ",'" + phoneTextbox.Text + "' " + 
                    ",'" + dateTextbox.Text + "' " + 
                    ",'" +typeTextbox.Text + "')";
            try
            {
                con.cn.Open();
                command = new MySqlCommand();
                command.Connection = con.cn;
                command.CommandText = sql;
                result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Inserted to database!");
                }
                else
                {
                    MessageBox.Show("Cannot insert to database!");
                }
                con.cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            getDonors();

            firstnameTextbox.Clear();
            lastnameTextbox.Clear();
            addressTextbox.Clear();
            phoneTextbox.Clear();
            dateTextbox.Clear();
            typeTextbox.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string firstname, lastname, address, phone, date, type;

                firstname = row.Cells[1].Value.ToString();
                lastname = row.Cells[2].Value.ToString();
                address = row.Cells[3].Value.ToString();
                phone = row.Cells[4].Value.ToString();
                date = row.Cells[5].Value.ToString();
                type = row.Cells[6].Value.ToString();

                con.cn.Open();
                command = new MySqlCommand();
                command.Connection = con.cn;
                command.CommandText = "DELETE FROM donors WHERE firstName= '" + firstname +
                    "' AND lastName= '" + lastname +
                    "' AND address= '" + address +
                    "' AND phone= '" + phone +
                    "' AND dateOfBirth= '" + date +
                    "' AND bloodType= '" + type + "'";
                ;

                command.ExecuteReader();
                con.cn.Close();
            }

            getDonors();
            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (firstTextbox.Text == "")
            {
                MessageBox.Show("Firstname cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (lastTextbox.Text == "")
            {
                MessageBox.Show("Lastname cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (adresTextbox.Text == "")
            {
                MessageBox.Show("Address cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (phonenrTextbox.Text == "")
            {
                MessageBox.Show("Phone cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (datebirthTextbox.Text == "")
            {
                MessageBox.Show("Date of birth cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (bloodTextbox.Text == "")
            {
                MessageBox.Show("Blood type cannot be empty!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sql = "Insert into recipients ( firstName, lastName, address, phone, dateOfBirth, bloodType ) VALUES " +
                    "('" + firstTextbox.Text + "' " +
                    ",'" + lastTextbox.Text + "' " +
                    ",'" + adresTextbox.Text + "' " +
                    ",'" + phonenrTextbox.Text + "' " +
                    ",'" + datebirthTextbox.Text + "' " +
                    ",'" + bloodTextbox.Text + "')";
            try
            {
                con.cn.Open();
                command = new MySqlCommand();
                command.Connection = con.cn;
                command.CommandText = sql;
                result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Inserted to database!");
                }
                else
                {
                    MessageBox.Show("Cannot insert to database!");
                }
                con.cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            getRecipients();

            firstTextbox.Clear();
            lastTextbox.Clear();
            adresTextbox.Clear();
            phonenrTextbox.Clear();
            datebirthTextbox.Clear();
            bloodTextbox.Clear();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gobackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void deleButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                string firstname, lastname, address, phone, date, type;

                firstname = row.Cells[1].Value.ToString();
                lastname = row.Cells[2].Value.ToString();
                address = row.Cells[3].Value.ToString();
                phone = row.Cells[4].Value.ToString();
                date = row.Cells[5].Value.ToString();
                type = row.Cells[6].Value.ToString();

                con.cn.Open();
                command = new MySqlCommand();
                command.Connection = con.cn;
                command.CommandText = "DELETE FROM recipients WHERE firstName= '" + firstname +
                    "' AND lastName= '" + lastname +
                    "' AND address= '" + address +
                    "' AND phone= '" + phone +
                    "' AND dateOfBirth= '" + date +
                    "' AND bloodType= '" + type + "'";
                ;

                command.ExecuteReader();
                con.cn.Close();
            }

            getRecipients();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            string firstname = firstnameTextbox.Text;
            string lastname = lastnameTextbox.Text;
            string address = addressTextbox.Text;
            string phone = phoneTextbox.Text;
            string date = dateTextbox.Text;
            string type = typeTextbox.Text;
            string ID = textBox_donorID.Text;
            con.cn.Open();

            command = new MySqlCommand();
            command.Connection = con.cn;
            command.CommandText = "Update donors SET firstName= '" + firstname +
                "', lastName= '" + lastname +
                "', address= '" + address +
                "', phone= '" + phone +
                "', dateOfBirth= '" + date +
                "', bloodType= '" + type +
                "' WHERE donorID = '" + ID + "';";
            command.ExecuteReader();
            con.cn.Close();
            getDonors();
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            string firstname = firstTextbox.Text;
            string lastname = lastTextbox.Text;
            string address = adresTextbox.Text;
            string phone = phonenrTextbox.Text;
            string date = datebirthTextbox.Text;
            string type = bloodTextbox.Text;
            string ID = id_Textbox.Text;
            con.cn.Open();

            command = new MySqlCommand();
            command.Connection = con.cn;
            command.CommandText = "Update recipients SET firstName= '" + firstname +
                "', lastName= '" + lastname +
                "', address= '" + address +
                "', phone= '" + phone +
                "', dateOfBirth= '" + date +
                "', bloodType= '" + type +
                "' WHERE recipientID = '" + ID + "';";
            command.ExecuteReader();
            con.cn.Close();
            getRecipients();
        }
    }
}
