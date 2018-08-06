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


namespace Fast_Food
{
    public partial class UpdateEmployee : Form
    {

        string connection = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        public UpdateEmployee()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txt_Job_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txt_shift_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Browse_Button_Click(object sender, EventArgs e)
        {

            MySqlConnection myconn = new MySqlConnection(connection);

            try
            {
                myconn.Open();

                MySqlCommand mycomm = new MySqlCommand("employee", myconn);
                mycomm.CommandType = CommandType.StoredProcedure;

                mycomm.Parameters.AddWithValue("@k", "update");
                mycomm.Parameters.AddWithValue("@Id_par1", txt_employeename.Text);
                mycomm.Parameters.AddWithValue("@Name_par2", "None");
                mycomm.Parameters.AddWithValue("@Job_par3", "None");
                mycomm.Parameters.AddWithValue("@Phone_par4", txt_Phone.Text);
                mycomm.Parameters.AddWithValue("@Address_par5", txt_Address.Text);
                mycomm.Parameters.AddWithValue("@User_par6", txt_User.Text);
                mycomm.Parameters.AddWithValue("@Pass_par7", txt_Password.Text);
                mycomm.Parameters.AddWithValue("@Salary_par8", txt_Salary.Text);
                mycomm.Parameters.AddWithValue("@Shift_par9", txt_shift.Text);

                mycomm.ExecuteNonQuery();

                MessageBox.Show("The data Updated");

                logfile log = new logfile();
                bool result = log.logfilee("UPDATE employee SET Phone =Phone_par4, Address=Address_par5, user=User_par6, pass=Pass_par7, salary=Salary_par8, shift=Shift_par9 WHERE Employee_name=Name_par2");

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

        private void button14_Click(object sender, EventArgs e)
        {
            select sc = new select();
            sc.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection myconn = new MySqlConnection(connection);

            MySqlDataReader r;

            try
            {
                myconn.Open();

                MySqlCommand mycomm = new MySqlCommand("SELECT * FROM resturant.employee where Employee_id = '" + txt_employeename.Text + "' ", myconn);

                r = mycomm.ExecuteReader();
                r.Read();

                txt_User.Text = r.GetValue(5).ToString();
                txt_Password.Text = r.GetValue(6).ToString();
                txt_Phone.Text = r.GetValue(3).ToString();
                txt_Address.Text = r.GetValue(4).ToString();
                txt_Salary.Text = r.GetValue(7).ToString();
                txt_shift.Text = r.GetValue(8).ToString();


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
    }
}
