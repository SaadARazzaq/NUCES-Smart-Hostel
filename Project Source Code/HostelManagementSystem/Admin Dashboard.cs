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
using System.Collections.Specialized;
using System.Configuration;

namespace HostelManagementSystem
{
    public partial class AdminDashboard : Form
    {
        OracleConnection con;
        public string Username;
        public AdminDashboard()
        {
            InitializeComponent();
            bunifuPages1.SetPage("dashboard");
        }
        private void updateGrid()
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT * FROM student_registration";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView1.DataSource = empDT;
            con.Close();

        }

        private void updateGrid1()
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT * FROM mess_form";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView4.DataSource = empDT;
            con.Close();

        }

        private void updateGrid2()
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT * FROM gym_form";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView5.DataSource = empDT;
            con.Close();

        }

        private void updateGrid3()
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT * FROM visitor";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView6.DataSource = empDT;
            con.Close();

        }

        private void updateGrid4()
        {
            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT * FROM gate_passform";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView7.DataSource = empDT;
            con.Close();

        }

        private void updateGrid5()
        {
            con.Open();
            OracleCommand selectCRUD = con.CreateCommand();
            selectCRUD.CommandText = "SELECT * FROM STUDENT_REGISTRATION";
            selectCRUD.CommandType = CommandType.Text;
            OracleDataReader empDR = selectCRUD.ExecuteReader();
            DataTable empDT = new DataTable();
            empDT.Load(empDR);
            dataGridView3.DataSource = empDT;
            con.Close();
        }
        private void Form16_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=HELLO;PASSWORD=hello";
            con = new OracleConnection(conStr);
            this.updateGrid();
            this.updateGrid1();//mess
            this.updateGrid2();//gym
            this.updateGrid3();//visitor
            this.updateGrid4();//gatepass
            this.updateGrid5();//addStudent
            timer1.Start();
            con.Open();
            string query1 = "SELECT COUNT(*) FROM student_registration";
            string query2 = "select count(*) from STUDENT_REGISTRATION where p_room = 'SingleRoom'";
            string query3 = "select count(*) from STUDENT_REGISTRATION where p_room = 'DoubleRoom'";
            string query4 = "select count(*) from STUDENT_REGISTRATION where p_room = 'SharedRoom'";
            OracleCommand cmd1 = new OracleCommand(query1, con);
            OracleDataReader dr1 = cmd1.ExecuteReader();
            OracleCommand cmd2 = new OracleCommand(query2, con);
            OracleDataReader dr2 = cmd2.ExecuteReader();
            OracleCommand cmd3 = new OracleCommand(query3, con);
            OracleDataReader dr3 = cmd3.ExecuteReader();
            OracleCommand cmd4 = new OracleCommand(query4, con);
            OracleDataReader dr4 = cmd4.ExecuteReader();
            while (dr1.Read())
            {
                totalStudentsRegistered.Text = dr1.GetValue(0).ToString();
            }
            while (dr2.Read())
            {
                singleroomsAssigned.Text = dr2.GetValue(0).ToString();
            }
            while (dr3.Read())
            {
                doubleroomsAssigned.Text = dr3.GetValue(0).ToString();
            }
            while (dr4.Read())
            {
                sharedroomsAssigned.Text = dr4.GetValue(0).ToString();
            }
            con.Close();
        }

        private void MovePanel(Control btn)
        {
            panelSlide.Top = btn.Top;
            panelSlide.Height = btn.Height;
        }

        private void linkLabel1LogOut_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DialogResult result = MessageBox.Show("Do you want to Log Out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == result)
            {
                timer1.Stop();
                this.Close();
            }
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void labelDateTime_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            labelDateTime.Text = DateTime.Now.ToString("dd-MMM-yyyy | hh:mm:ss tt");

        }

        private void button1Dashboard_Click_1(object sender, EventArgs e)
        {
            MovePanel(button1Dashboard);
            bunifuPages1.SetPage("dashboard");
        }

        private void button2searchStudents_Click_1(object sender, EventArgs e)
        {
            MovePanel(button2searchStudents);
            bunifuPages1.SetPage("searchStudents");

        }

        private void button3addStudents_Click_1(object sender, EventArgs e)
        {
            MovePanel(button3addStudents);
            bunifuPages1.SetPage("addStudents");
        }

        private void button5delStudents_Click_1(object sender, EventArgs e)
        {
            MovePanel(button5delStudents);
            bunifuPages1.SetPage("delStudents");
        }

        private void button6viewRooms_Click_1(object sender, EventArgs e)
        {
            MovePanel(button6viewRooms);
            bunifuPages1.SetPage("viewRooms");
        }

        private void button7MessForms_Click_1()
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void searchstudentButton_Click_1(object sender, EventArgs e)
        {
            

        }

        private void checkBox1Mess_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void panel8_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            if (!(this.checkBox1.Checked))
            {
                MessageBox.Show("Read the instructions please!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!maskedTextBox1.MaskFull)
            {
                MessageBox.Show("Enter A Proper email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                OracleCommand insertEmp = con.CreateCommand();
                insertEmp.CommandText = "DELETE FROM STUDENT_REGISTRATION WHERE EMAIL_ADDRESS = \'" +
               maskedTextBox1.Text.ToString() + "\'";
                insertEmp.CommandType = CommandType.Text;
                int rows = insertEmp.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Student with email " + maskedTextBox1.Text + " Deleted Successfully!", "Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }


        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
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

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void dashboard_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void label25_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void searchRoom_Click(object sender, EventArgs e)
        {
            
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

        private void labelAdmin_Click_1(object sender, EventArgs e)
        {

        }

        private void labelWelcome_Click_1(object sender, EventArgs e)
        {

        }

        private void panelSlide_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuPages1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void label22_Click_1(object sender, EventArgs e)
        {

        }

        private void label21_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }


        private void label17_Click_1(object sender, EventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }


        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        public void roomtotal()
        {
            
        }

        private void singleroomsAssigned_Click_1(object sender, EventArgs e)
        {

        }

        private void doubleroomsAssigned_Click(object sender, EventArgs e)
        {

        }

        private void sharedroomsAssigned_Click(object sender, EventArgs e)
        {

        }
        
        private void totalRoomsAssigned_Click(object sender, EventArgs e)
        {
            
        }

        private void totalStudentsRegistered_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click_1(object sender, EventArgs e)
        {

        }

        private void mess_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1SearchStudent_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void visitors_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void gym_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click_1(object sender, EventArgs e)
        {

        }

        private void inoutform_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void complaint_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox4complaint_Click_1(object sender, EventArgs e)
        {

        }

        private void label27_Click_1(object sender, EventArgs e)
        {

        }

        private void label26_Click_1(object sender, EventArgs e)
        {

        }

        private void panel5_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void searchStudentTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void guna2GroupBox4viewRoom_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2GroupBox3editStudents_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_AddStudentEmail_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox3_AddStudentRoomNumber_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void guna2ComboBox3AddStudentRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1AddStudentDOB_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Today <= guna2DateTimePicker1AddStudentDOB.Value)
            {
                MessageBox.Show("Please enter a valid Date Of Birth", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2DateTimePicker1AddStudentDOB.Value = DateTime.Today;
                guna2DateTimePicker1AddStudentDOB.Focus();
                return;
            }
        }

        private void maskedTextBox4_AddStudentRoll_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3AddStudentLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2AddStudentFirstName_TextChanged(object sender, EventArgs e)
        {

        }


        string gender = "";
        string batch = "";
        string hall = "";
        string roomtype = "";

        private void guna2Button1_AddStudentButton_Click(object sender, EventArgs e)
        {
            if (guna2ImageRadioButton1.Checked)
            {
                gender = "Male";
            }
            else if (guna2ImageRadioButton2.Checked)
            {
                gender = "Female";
            }
            if (guna2ComboBox3AddStudentRoomType.Text == "SingleRoom")
            {
                roomtype = "SingleRoom";
            }
            else if (guna2ComboBox3AddStudentRoomType.Text == "DoubleRoom")
            {
                roomtype = "DoubleRoom";
            }
            else if (guna2ComboBox3AddStudentRoomType.Text == "SharedRoom")
            {
                roomtype = "SharedRoom";
            }
            if (guna2ComboBox3.Text == "Jinnah Hall")
            {
                hall = "Jinnah Hall";
            }
            else if (guna2ComboBox3.Text == "Iqbal Hall")
            {
                hall = "Iqbal Hall";
            }
            if (guna2ComboBox4.Text == "17" || guna2ComboBox4.Text == "18" || guna2ComboBox4.Text == "19" || guna2ComboBox4.Text == "20" || guna2ComboBox4.Text == "21" || guna2ComboBox4.Text == "22")
            {
                batch = guna2ComboBox4.Text;
            }

            if (guna2TextBox2AddStudentFirstName.Text == "")
            {
                MessageBox.Show("Please enter a valid First name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox2AddStudentFirstName.Focus();
                return;
            }
            else if (guna2TextBox3AddStudentLastName.Text == "")
            {
                MessageBox.Show("Please enter a valid Last name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox3AddStudentLastName.Focus();
                return;
            }
            else if (!maskedTextBox3AddStudentEmail.MaskFull)
            {
                MessageBox.Show("Please enter a valid email id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maskedTextBox3AddStudentEmail.Focus();
                return;
            }
            else if (guna2TextBox1.Text == "")
            {
                MessageBox.Show("Please enter a valid password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2TextBox1.Focus();
                return;
            }
            else if (!(this.guna2ImageRadioButton1.Checked || this.guna2ImageRadioButton2.Checked))
            {
                MessageBox.Show("Select Your Gender!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (guna2ComboBox4.Text == "Enter Batch")
            {
                MessageBox.Show("Please enter a valid Batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ComboBox4.Focus();
                return;
            }
            else if (guna2ComboBox3.Text == "Hall")
            {
                MessageBox.Show("Please enter a Preference, Your Preference matters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ComboBox3.Focus();
                return;
            }
            else if (guna2ComboBox3AddStudentRoomType.Text == "Room Type")
            {
                MessageBox.Show("Please enter a Preference, Your Preference matters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                guna2ComboBox3AddStudentRoomType.Focus();
                return;
            }
            else
            {
                con.Open();
                OracleCommand insertEmp = con.CreateCommand();
                insertEmp.CommandText = "INSERT INTO STUDENT_REGISTRATION VALUES(\'" +
               maskedTextBox3AddStudentEmail.Text.ToString() + "\',\'" +
               guna2TextBox2AddStudentFirstName.Text.ToString() + "\',\'" +
               guna2TextBox3AddStudentLastName.Text.ToString() + "\',\'" + 
               guna2TextBox1.Text.ToString() + "\',\'" + 
               guna2DateTimePicker1AddStudentDOB.Text.ToString() + "\',\'" + 
               gender + "\',\'" + batch + "\',\'" + hall + "\',\'" + guna2ComboBox3AddStudentRoomType.Text.ToString() + "\')";
                insertEmp.CommandType = CommandType.Text;
                int rows = insertEmp.ExecuteNonQuery();
                if (rows > 0)
                {
                    MessageBox.Show("Student registered in Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con.Close();
                updateGrid5();
            }
        }



        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }

        private void button7ViewMessForms_Click(object sender, EventArgs e)
        {
            MovePanel(button7ViewMessForms);
            bunifuPages1.SetPage("viewMess");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MovePanel(button2);
            bunifuPages1.SetPage("viewGym");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MovePanel(button3);
            bunifuPages1.SetPage("viewVisitor");
        }

       
private void button4_Click(object sender, EventArgs e)
        {
            MovePanel(button4);
            bunifuPages1.SetPage("viewGate");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected_2(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void guna2ImageRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ImageRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelA_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}