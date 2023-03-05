using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using Oracle.ManagedDataAccess.Client;

namespace HostelManagementSystem
{
    public partial class Form11 : Form
    {
        public string roomT { get; set; }
        public string Username;
        public string roomtype;
        
        OracleConnection con;
        public Form11()
        {
            InitializeComponent();
            bunifuPages1.SetPage("dashboard");
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=HELLO;PASSWORD=hello";
            timer1.Start();
            OracleConnection con = new OracleConnection(conStr);
            
            con.Open();
            
            string query1 = "SELECT first_name FROM student_registration";
            string query2 = "SELECT P_HALL FROM student_registration";
            string query3 = "select P_ROOM from STUDENT_REGISTRATION";
            OracleCommand cmd1 = new OracleCommand(query1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            OracleCommand cmd2 = new OracleCommand(query2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            OracleCommand cmd3 = new OracleCommand(query3, con);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            while (dr2.Read())
            {
                label16.Text = dr2.GetValue(0).ToString();
            }
            while (dr3.Read())
            {
                label18.Text = dr3.GetValue(0).ToString();
            }
            con.Close();
        }

        private void MovePanel(Control btn)
        {
            panelSlide.Top = btn.Top;
            panelSlide.Height = btn.Height;
        }

        private void linkLabel1LogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Do you want to Log Out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(DialogResult.Yes == result)
            {
                timer1.Stop();
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelDateTime_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy | hh:mm:ss tt");

        }

        private void button1Dashboard_Click(object sender, EventArgs e)
        {
            MovePanel(button1Dashboard);
            bunifuPages1.SetPage("dashboard");
        }

        private void button2Mess_Click(object sender, EventArgs e)
        {
            MovePanel(button2Mess);
            bunifuPages1.SetPage("mess");

        }

        private void button3Visitors_Click(object sender, EventArgs e)
        {
            MovePanel(button3Visitors);
            bunifuPages1.SetPage("visitors");
        }

        private void button4Gym_Click(object sender, EventArgs e)
        {
            MovePanel(button4Gym);
            bunifuPages1.SetPage("gym");
        }

        private void button5InOutForm_Click(object sender, EventArgs e)
        {
            MovePanel(button5InOutForm);
            bunifuPages1.SetPage("inoutform");
        }

        private void button6Complaint_Click(object sender, EventArgs e)
        {
            MovePanel(button6Complaint);
            bunifuPages1.SetPage("complaint");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!(this.checkBox1Mess.Checked))
            {
                MessageBox.Show("Read the instructions please!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form6 form = new Form6();
                form.Show();
                checkBox1Mess.Checked = false;
            }
            
        }

        private void checkBox1Mess_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!(this.checkBox1.Checked))
            {
                MessageBox.Show("Read the instructions please!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form13 form = new Form13();
                form.Show();
                checkBox1.Checked = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (!(this.checkBox2.Checked))
            {
                MessageBox.Show("Read the instructions please!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form5 form = new Form5();
                form.Show();
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!(this.checkBox3.Checked))
            {
                MessageBox.Show("Read the instructions please!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form4 form = new Form4();
                form.Show();
                checkBox3.Checked = false;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dashboard_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (!(this.checkBox4.Checked))
            {
                MessageBox.Show("Read the instructions please!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Form12 form = new Form12();
                form.Show();
                checkBox4.Checked = false;
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mail.google.com/mail/u/1/#inbox?compose=GTvVlcSGKnXDSxqTqVpJRmfDSxTXVgFdCFfftTtnHwGDtLWzBlxsPfwtKgfsQdrXLQmVQccrWkPdK");
        }

        private void panelA_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelUsername_Click(object sender, EventArgs e)
        {
            
        }

        private void labelWelcome_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panelSlide_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPages1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel8_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
            
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void mess_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1MessAttendanceForm_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void visitors_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void gym_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void inoutform_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void complaint_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox4complaint_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
