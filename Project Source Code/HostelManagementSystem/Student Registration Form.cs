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
using Oracle.ManagedDataAccess.Client;

namespace HostelManagementSystem
{
    public partial class StudentRegistration : Form
    {
        public string roomtype;
        OracleConnection con;
        public StudentRegistration()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=HELLO;PASSWORD=hello";
            con = new OracleConnection(conStr);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!maskedTextBox1.MaskFull)
                {
                    MessageBox.Show("Please enter a valid email id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedTextBox1.Focus();
                    return;
                }
                else
                {
                    this.SelectNextControl(maskedTextBox1, true, true, true, true);
                }
            }
        }

        private void maskedTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!maskedTextBox2.MaskFull)
                {
                    MessageBox.Show("Please enter a valid email id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedTextBox2.Focus();
                    return;
                }
                else if (maskedTextBox1.Text != maskedTextBox2.Text)
                {
                    MessageBox.Show("Email Missmatch! Please enter similar email address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedTextBox2.Focus();
                }
                else
                {
                    this.SelectNextControl(maskedTextBox2, true, true, true, true);
                }
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox3.Text == "")
            {
                MessageBox.Show("Please enter a valid password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox3.Focus();
                return;
            }
            else
            {
                guna2TextBox3.PasswordChar = '*'; //this is done only for making characters in the password textbox not visible
            }
        }

        private void guna2TextBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (guna2TextBox3.Text == "")
                {
                    MessageBox.Show("Please enter a valid password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox3.Focus();
                    return;
                }
                else
                {
                    this.SelectNextControl(guna2TextBox3, true, true, true, true);
                }
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text == "")
            {
                MessageBox.Show("Please enter a valid password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox4.Focus();
                return;
            }
            else
            {
                guna2TextBox4.PasswordChar = '*'; //this is done only for making characters in the password textbox not visible
            }
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox5.Text == "")
            {
                MessageBox.Show("Please enter a valid First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox5.Focus();
                return;
            }
        }
        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text == "")
            {
                MessageBox.Show("Please enter a valid Second Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox6.Focus();
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        string gender = "";
        string room1 = "";
        string batch1 = "";
        string hall1 = "";

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (guna2ImageRadioButton1.Checked)
            {
                gender = "Male";
            }
            else if (guna2ImageRadioButton2.Checked)
            {
                gender = "Female";
            }
            if (guna2ComboBox2.Text == "SingleRoom")
            {
                room1 = "SingleRoom";
            }
            else if (guna2ComboBox2.Text == "DoubleRoom")
            {
                room1 = "DoubleRoom";
            }
            else if (guna2ComboBox2.Text == "SharedRoom")
            {
                room1 = "SharedRoom";
            }
            if (guna2ComboBox1.Text == "Jinnah Hall")
            {
                hall1 = "Jinnah Hall";
            }
            else if (guna2ComboBox1.Text == "Iqbal Hall")
            {
                hall1 = "Iqbal Hall";
            }
            if(guna2ComboBox3.Text == "17" || guna2ComboBox3.Text == "18" || guna2ComboBox3.Text == "19" || guna2ComboBox3.Text == "20" || guna2ComboBox3.Text == "21" || guna2ComboBox3.Text == "22")
            {
                batch1 = guna2ComboBox3.Text;
            }
            
            if (guna2TextBox5.Text == "")
            {
                MessageBox.Show("Please enter a valid name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox5.Focus();
                return;
            }
            else if (guna2TextBox6.Text == "")
            {
                MessageBox.Show("Please enter a valid name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox6.Focus();
                return;
            }
            else if (!maskedTextBox1.MaskFull)
            {
                MessageBox.Show("Please enter a valid email id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return;
            }
            else if (!maskedTextBox2.MaskFull)
            {
                MessageBox.Show("Please enter a valid email id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox2.Focus();
                return;
            }
            else if (guna2TextBox3.Text == "")
            {
                MessageBox.Show("Please enter a valid password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox3.Focus();
                return;
            }
            else if (guna2TextBox4.Text == "")
            {
                MessageBox.Show("Please enter a valid password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox4.Focus();
                return;
            }
            else if (guna2TextBox3.Text != guna2TextBox4.Text)
            {
                MessageBox.Show("Password Missmatch! Please enter similar password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox4.Focus();
            }
            else if (!(this.guna2ImageRadioButton1.Checked || this.guna2ImageRadioButton2.Checked))
            {
                MessageBox.Show("Select Your Gender!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (guna2ComboBox3.Text == "Enter Batch")
            {
                MessageBox.Show("Please enter a valid Batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ComboBox3.Focus();
                return;
            }
            else if (guna2ComboBox1.Text == "Preference Hall")
            {
                MessageBox.Show("Please enter a Preference, Your Preference matters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ComboBox3.Focus();
                return;
            }
            else if (guna2ComboBox2.Text == "Preference Room Type")
            {
                MessageBox.Show("Please enter a Preference, Your Preference matters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ComboBox3.Focus();
                return;
            }
            //else if(guna2ComboBox3.Text != ma)
            //{

            //}
            else
            {
                con.Open();
                OracleCommand insertEmp = con.CreateCommand();
                insertEmp.CommandText = "INSERT INTO STUDENT_REGISTRATION VALUES(\'" +
               maskedTextBox1.Text.ToString() + "\',\'" + guna2TextBox5.Text.ToString() + "\',\'" + guna2TextBox6.Text.ToString() + "\',\'" + guna2TextBox3.Text.ToString() + "\',\'" + guna2DateTimePicker1.Text.ToString() + "\',\'" + gender + "\',\'" + batch1 + "\',\'" + hall1 + "\',\'" + room1 + "\')";
                insertEmp.CommandType = CommandType.Text;
                int rows = insertEmp.ExecuteNonQuery();
                if (rows > 0) { 
                    MessageBox.Show("Student registered in Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
                StudentLogin form = new StudentLogin();
                form.Show();
            }
        }

        private void guna2TextBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (guna2TextBox5.Text == "")
                {
                    MessageBox.Show("Please enter a First Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox5.Focus();
                    return;
                }
                else
                {
                    this.SelectNextControl(guna2TextBox5, true, true, true, true);
                }
            }
        }

        private void guna2TextBox6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (guna2TextBox6.Text == "")
                {
                    MessageBox.Show("Please enter a Last Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox6.Focus();
                    return;
                }
                else
                {
                    this.SelectNextControl(guna2TextBox6, true, true, true, true);
                }
            }
        }

        private void guna2ImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Today <= guna2DateTimePicker1.Value)
            {
                MessageBox.Show("Please enter a valid Date Of Birth", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2DateTimePicker1.Value = DateTime.Today;
                guna2DateTimePicker1.Focus();
                return;
            }
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void firstName_Popup(object sender, PopupEventArgs e)
        {

        }
        
    }
}
