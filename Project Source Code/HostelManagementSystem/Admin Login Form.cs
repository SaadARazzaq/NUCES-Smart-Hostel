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
    public partial class Form9 : Form
    {
        OracleConnection con;
        public Form9()
        {
            InitializeComponent();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("Please enter a valid email id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox1.Focus();
                return;
            }
        }

        private void guna2TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (guna2TextBox1.Text == "")
                {
                    MessageBox.Show("Please enter a valid username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox1.Focus();
                    return;
                }
                else
                {
                    this.SelectNextControl(guna2TextBox1, true, true, true, true);
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

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("Please enter a valid username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox1.Focus();
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
                cmd = new OracleCommand("SELECT username,password FROM admin WHERE username=:UNAME AND password =:PWORD", con);
                cmd.Parameters.Add(new OracleParameter("UNAME", guna2TextBox1.Text));
                cmd.Parameters.Add(new OracleParameter("PWORD", guna2TextBox2.Text));
                OracleDataReader r = cmd.ExecuteReader();
                string[] feilds = new string[2];

                if (r.Read() && r.GetValue(0).ToString() == guna2TextBox1.Text && r.GetValue(1).ToString() == guna2TextBox2.Text)
                {
                    MessageBox.Show("Admin logged in Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    AdminDashboard form = new AdminDashboard();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Admin Credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox1.Focus();
                }
                con.Close();

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form10 form = new Form10();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=HELLO;PASSWORD=hello";
            con = new OracleConnection(conStr);
        }
    }
}
