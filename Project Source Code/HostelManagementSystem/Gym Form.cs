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
    public partial class Form5 : Form
    {
        OracleConnection con;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=HELLO;PASSWORD=hello";
            con = new OracleConnection(conStr);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "" || guna2TextBox1.Text == "1-9")
            {
                MessageBox.Show("Please enter a valid Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Please enter a Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox1.Focus();
                    return;
                }
                else
                {
                    this.SelectNextControl(guna2TextBox1, true, true, true, true);
                }
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox4.Text == "")
            {
                MessageBox.Show("Please enter a valid Incharge Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox4.Focus();
                return;
            }
        }

        private void guna2TextBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (guna2TextBox4.Text == "")
                {
                    MessageBox.Show("Please enter a Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox4.Focus();
                    return;
                }
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("Please enter a valid Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox1.Focus();
                return;
            }
            else if (!maskedTextBox1.MaskFull)
            {
                MessageBox.Show("Please enter a valid Roll Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return;
            }
            else if (!maskedTextBox2.MaskFull)
            {
                MessageBox.Show("Please enter a Gym ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox2.Focus();
                return;
            }
            else if (guna2TextBox4.Text == "")
            {
                MessageBox.Show("Please enter a valid Gym Incharge Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox4.Focus();
                return;
            }
            else
            {
                con.Open();
                OracleCommand insertEmp = con.CreateCommand();
                insertEmp.CommandText = "INSERT INTO GYM_FORM VALUES(\'" +
               guna2TextBox1.Text.ToString() + "\',\'" + maskedTextBox1.Text.ToString() + "\',\'" + maskedTextBox1.Text.ToString() + "\',\'" + guna2TextBox4.Text.ToString() + "\',\'" + guna2DateTimePicker2.Text.ToString() + "\')";
                insertEmp.CommandType = CommandType.Text;
                int rows = insertEmp.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Gym Form Submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
                this.Hide();
            }
    }


        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Today > guna2DateTimePicker2.Value)
            {
                MessageBox.Show("Please enter a valid Time In Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2DateTimePicker2.Value = DateTime.Today;
                guna2DateTimePicker2.Focus();
                return;
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!maskedTextBox1.MaskFull)
            {
                MessageBox.Show("Please enter a valid Roll Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox1.Focus();
                return;
            }
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!maskedTextBox2.MaskFull)
            {
                MessageBox.Show("Please enter a valid Roll Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox2.Focus();
                return;
            }
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!maskedTextBox1.MaskFull)
                {
                    MessageBox.Show("Please enter a Roll Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Please enter a Gym ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    maskedTextBox2.Focus();
                    return;
                }
                else
                {
                    this.SelectNextControl(maskedTextBox2, true, true, true, true);
                }
            }
        }
    }
}
