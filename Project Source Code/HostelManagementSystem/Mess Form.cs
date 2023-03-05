using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace HostelManagementSystem
{
    public partial class Form6 : Form
    {
        OracleConnection con;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=HELLO;PASSWORD=hello";
            con = new OracleConnection(conStr);
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "")
            {
                MessageBox.Show("Please enter a valid Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox2.Focus();
                return;
            }
        }

        string meal1 = "";
        string meal2 = "";
        string meal3 = "";
        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Today > guna2DateTimePicker2.Value)
            {
                MessageBox.Show("Please enter a valid Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2DateTimePicker2.Value = DateTime.Today;
                guna2DateTimePicker2.Focus();
                return;
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.Text == "Breakfast")
            {
                meal1 = "Breakfast";
            }
            else if (guna2ComboBox1.Text == "Lunch")
            {
                meal1 = "Lunch";
            }
            else if (guna2ComboBox1.Text == "Dinner")
            {
                meal1 = "Dinner";
            }

            if (guna2ComboBox2.Text == "Breakfast")
            {
                meal2 = "Breakfast";
            }
            else if (guna2ComboBox2.Text == "Lunch")
            {
                meal2 = "Lunch";
            }
            else if (guna2ComboBox2.Text == "Dinner")
            {
                meal2 = "Dinner";
            }

            if (guna2ComboBox3.Text == "Breakfast")
            {
                meal3 = "Breakfast";
            }
            else if (guna2ComboBox3.Text == "Lunch")
            {
                meal3 = "Lunch";
            }
            else if (guna2ComboBox3.Text == "Dinner")
            {
                meal3 = "Dinner";
            }

            if (!maskedTextBox1.MaskFull)
            {
                MessageBox.Show("Please enter a valid Roll Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return;
            }
            else if (guna2TextBox2.Text == "")
            {
                MessageBox.Show("Please enter a valid Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox2.Focus();
                return;
            }
            else if (guna2ComboBox1.Text == "Meal 1")
            {
                MessageBox.Show("Please enter a valid Meal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ComboBox1.Focus();
                return;
            }
            else if (guna2ComboBox2.Text == "Meal 2")
            {
                MessageBox.Show("Please enter a valid Meal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ComboBox1.Focus();
                return;
            }
            else if (guna2ComboBox3.Text == "Meal 3")
            {
                MessageBox.Show("Please enter a valid Meal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ComboBox1.Focus();
                return;
            }
            else if ((guna2ComboBox1.Text == guna2ComboBox2.Text) || (guna2ComboBox1.Text == guna2ComboBox3.Text) || (guna2ComboBox2.Text == guna2ComboBox3.Text))
            {
                MessageBox.Show("Please enter a valid Meal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ComboBox1.Focus();
                return;
            }
            else
            {
                con.Open();
                OracleCommand insertEmp = con.CreateCommand();
                insertEmp.CommandText = "INSERT INTO MESS_FORM VALUES(\'" +
               maskedTextBox1.Text.ToString() + "\',\'" + guna2TextBox2.Text.ToString() + "\',\'" + guna2ComboBox1.Text.ToString() + "\',\'" + guna2ComboBox2.Text.ToString() + "\',\'" + guna2ComboBox3.Text.ToString() + "\',\'" + guna2DateTimePicker2.Text.ToString() + "\')";
                insertEmp.CommandType = CommandType.Text;
                int rows = insertEmp.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Mess Form Submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
                this.Hide();
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if(!maskedTextBox1.MaskFull)
            {
                MessageBox.Show("Please enter a valid Roll Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return;
            }
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!maskedTextBox1.MaskFull)
                {
                    MessageBox.Show("Please enter a valid Roll Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedTextBox1.Focus();
                    return;
                }
                else
                {
                    this.SelectNextControl(maskedTextBox1, true, true, true, true);
                }
            }
        }
    }
}
