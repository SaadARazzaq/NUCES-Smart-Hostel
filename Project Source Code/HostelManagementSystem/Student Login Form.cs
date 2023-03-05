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
    public partial class StudentLogin : Form
    {
        OracleConnection con;
        public StudentLogin()
        {
            InitializeComponent();
        }

        private void updateGrid()
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=HELLO;PASSWORD=hello";
            con = new OracleConnection(conStr);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (maskedTextBox1.Text == "")
                {
                    MessageBox.Show("Please enter a valid email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedTextBox1.Focus();
                    return;
                }
                else
                {
                    this.SelectNextControl(maskedTextBox1, true, true, true, true);
                }
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "")
            {
                MessageBox.Show("Please enter a valid password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox2.Focus();
                return;
            }
            else
            {
                guna2TextBox2.PasswordChar = '*'; //this is done only for making characters in the password textbox not visible
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void guna2GradientButton1_Click(object sender, EventArgs e) //this done for only validating if there is no email id or password entered in login
        {

            if (!maskedTextBox1.MaskFull)
            {
                MessageBox.Show("Please enter a valid Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return;
            }
            else if (guna2TextBox2.Text == "")
            {
                MessageBox.Show("Please enter a valid password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox2.Focus();
                return;
            }
            else
            {
                con.Open();

                OracleCommand cmd = new OracleCommand();
                cmd = new OracleCommand("SELECT email_address,e_password FROM student_registration WHERE email_address=:email AND e_password =:pass", con);
                cmd.Parameters.Add(new OracleParameter("email", maskedTextBox1.Text));
                cmd.Parameters.Add(new OracleParameter("pass", guna2TextBox2.Text));
                OracleDataReader r = cmd.ExecuteReader();
                string[] feilds = new string[2];

                if (r.Read() && r.GetValue(0).ToString() == maskedTextBox1.Text && r.GetValue(1).ToString() == guna2TextBox2.Text)
                {
                    MessageBox.Show("Student logged in Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form11 form11 = new Form11();
                    form11.Show();
                }
                else
                {
                    MessageBox.Show("User Not Registered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedTextBox1.Focus();
                }
                con.Close();
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e) 
        {
            this.Hide();
            StudentRegistration form = new StudentRegistration();
            form.Show();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }



        //AISY HE................................................................

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form8 form = new Form8();
            form.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form9 form = new Form9();
            form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form7 form = new Form7();
            form.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form = new Form6();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 form = new Form4();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form = new Form5();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 form = new Form11();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form12 form = new Form12();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form13 form = new Form13();
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form14 form = new Form14();
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard form = new AdminDashboard();
            form.Show();
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}