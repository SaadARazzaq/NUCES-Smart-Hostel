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
    public partial class Form13 : Form
    {
        OracleConnection con;
        public Form13()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!maskedTextBox1.MaskFull)
            {
                MessageBox.Show("Please enter a valid Roll Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2Button1.Focus();
                return;
            }
        }

        private void guna2CustomRadioButton5CashW_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomRadioButton2Home_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomRadioButton3Medical_CheckedChanged(object sender, EventArgs e)
        {

        }
        string choice="";
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2CustomRadioButton1Food.Checked)
            {
                choice = "Food";
            }
            else if (guna2CustomRadioButton2Home.Checked)
            {
                choice = "Leaving for Home";
            }
            else if(guna2CustomRadioButton3Medical.Checked){
                choice = "Medical Purposes";
            }
            else if (guna2CustomRadioButton5CashW.Checked)
            {
                choice = "Cash WithDrawal";
            }
            if (!maskedTextBox1.MaskFull)
            {
                MessageBox.Show("Please enter a valid Roll Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2Button1.Focus();
                return;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter a valid Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            else if (!(this.guna2CustomRadioButton1Food.Checked || this.guna2CustomRadioButton5CashW.Checked || this.guna2CustomRadioButton2Home.Checked || this.guna2CustomRadioButton3Medical.Checked))
            {
                MessageBox.Show("Select a Reason to go outside!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                OracleCommand insertEmp = con.CreateCommand();
                insertEmp.CommandText = "INSERT INTO gate_passform VALUES(\'" +
               maskedTextBox1.Text.ToString() + "\',\'" + textBox1.Text.ToString() + "\',\'" + choice + "\')";
                insertEmp.CommandType = CommandType.Text;
                int rows = insertEmp.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Hostel Gate Pass Form Submitted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                con.Close();
                this.Hide();
            }
        }

        private void guna2CustomRadioButton1Food_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form13_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=HELLO;PASSWORD=hello";
            con = new OracleConnection(conStr);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "1-9")
            {
                MessageBox.Show("Please enter a valid Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
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
