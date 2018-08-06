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
using System.Configuration;
using System.Text.RegularExpressions;
using System.IO;
using GeneralPro;



namespace Fast_Food
{
    public partial class employee : Form
    {

        string connection = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        public employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            
        }

        private void Browse_Button_Click(object sender, EventArgs e)
        {



            Regex regex_Name = new Regex("^[a-zA-Z]{1,20}$");
            Regex regex_Numbers = new Regex("^[0-9]*$");
            // Regex regex_Address = new Regex("^[1-zA-Z0-9]{1,20}$");
            Regex regex_Salary = new Regex("^[0-9]");
            Regex regex_User = new Regex("^[a-zA-Z]{1,20}$");
            Regex regex_Job = new Regex("^[a-zA-Z]{1,20}$");
            Regex regex_Time = new Regex("^[0-9]");
            //  Regex regex_Password = new Regex("^[1-zA-Z0-9$]{1,20}$");

            if (!regex_Name.IsMatch(txt_employeename.Text))
            {
                MessageBox.Show("Please Enter the First name with Alpha A-Z no number accpted");
                return;
            }
            if (!regex_Numbers.IsMatch(txt_Phone.Text))
            {
                MessageBox.Show("Please Enter the Phone with 0-9 number no Alpha A-Z accpted");
                return;
            }

            if (!regex_Salary.IsMatch(txt_Salary.Text))
            {
                MessageBox.Show("Please Enter the Salary  with Alpha A-Z  No 0-9 number accpted");
                return;
            }
            if (!regex_User.IsMatch(txt_User.Text))
            {
                MessageBox.Show("Please Enter the User with   with Alpha A-Z no number accpted ");
                return;
            }
            if (!regex_Job.IsMatch(txt_Job.Text))
            {
                MessageBox.Show("Please Enter the User with   with Alpha A-Z no number accpted ");
                return;
            }
            if (!regex_Time.IsMatch(txt_shift.Text))
            {
                MessageBox.Show("Please Enter the Salary  with   0-9 number no Alpha A-Z accpted");
                return;
            }

            if (txt_employeename.Text == "" || txt_Phone.Text == "" || txt_Address.Text == "" || txt_Salary.Text == "" || txt_User.Text == "" || txt_Job.Text == "" || txt_shift.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Please Complete the data");
            }
            
            MySqlConnection myconn = new MySqlConnection(connection);
            
            try
            {
                myconn.Open();

                MySqlCommand mycomm = new MySqlCommand("employee", myconn);
                mycomm.CommandType = CommandType.StoredProcedure;

                mycomm.Parameters.AddWithValue("@k", "insert");
                mycomm.Parameters.AddWithValue("@Id_par1", 0);
                mycomm.Parameters.AddWithValue("@Name_par2", txt_employeename.Text);
                mycomm.Parameters.AddWithValue("@Job_par3", txt_Job.Text);
                mycomm.Parameters.AddWithValue("@Phone_par4", txt_Phone.Text);
                mycomm.Parameters.AddWithValue("@Address_par5", txt_Address.Text);
                mycomm.Parameters.AddWithValue("@User_par6", txt_User.Text);
                mycomm.Parameters.AddWithValue("@Pass_par7", txt_Password.Text);
                mycomm.Parameters.AddWithValue("@Salary_par8", txt_Salary.Text);
                mycomm.Parameters.AddWithValue("@Shift_par9", txt_shift.Text);

                mycomm.ExecuteNonQuery();              

                MessageBox.Show("The data inserted");

                logfile log = new logfile();
                bool result = log.logfilee("insert into employee (Employee_name, Job, Phone, Address, user, pass, salary, shift) values (Name_par2, Job_par3, Phone_par4, Address_par5, User_par6, Pass_par7, Salary_par8, Shift_par9)");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                myconn.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
          
        }

        private void button14_Click(object sender, EventArgs e)
        {
            select sc = new select();
            sc.Show();
            this.Hide();
        }
    }
}
