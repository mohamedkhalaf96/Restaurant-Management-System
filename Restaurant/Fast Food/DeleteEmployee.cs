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
    public partial class DeleteEmployee : Form
    {

        string connection = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        public DeleteEmployee()
        {
            InitializeComponent();
        }

        private void Browse_Button_Click(object sender, EventArgs e)
        {
            MySqlConnection myconn = new MySqlConnection(connection);

            try
            {
                myconn.Open();

                MySqlCommand mycomm = new MySqlCommand("employee", myconn);
                mycomm.CommandType = CommandType.StoredProcedure;

                mycomm.Parameters.AddWithValue("@k", "delete");
                mycomm.Parameters.AddWithValue("@Id_par1", txt_employeename.Text);
                mycomm.Parameters.AddWithValue("@Name_par2", "None");
                mycomm.Parameters.AddWithValue("@Job_par3", "None");
                mycomm.Parameters.AddWithValue("@Phone_par4", 0);
                mycomm.Parameters.AddWithValue("@Address_par5", "None");
                mycomm.Parameters.AddWithValue("@User_par6", "None");
                mycomm.Parameters.AddWithValue("@Pass_par7", "None");
                mycomm.Parameters.AddWithValue("@Salary_par8", 0);
                mycomm.Parameters.AddWithValue("@Shift_par9", 0);

                mycomm.ExecuteNonQuery();

                MessageBox.Show("The data Deleted");

                logfile log = new logfile();
                bool result = log.logfilee("delete from employee where Employee_id = Id_par1");


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
    }
}
