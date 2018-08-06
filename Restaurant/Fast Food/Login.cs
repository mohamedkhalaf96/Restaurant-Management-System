using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using Fast_Food;
using admin;



namespace login_page
{
    public partial class Login : Form
    {
        public static string user;

        public static string SetValueForText1 = "";


        string connection = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
        public Login()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetValueForText1 = TextBox1.Text;
            log();
        
        }

        private void log()
        {
            if (TextBox1.Text == "" || TextBox2.Text == "")
            {
                MessageBox.Show("Please Complete the data");
            }
            else
            {
                MySqlConnection myconn = new MySqlConnection(connection);

                MySqlDataReader r;

                try
                {
                    myconn.Open();

                    MySqlCommand selectcomm = new MySqlCommand("employee", myconn);
                    selectcomm.CommandType = CommandType.StoredProcedure;

                    selectcomm.Parameters.AddWithValue("@k", "login");
                    selectcomm.Parameters.AddWithValue("@Id_par1", 0);
                    selectcomm.Parameters.AddWithValue("@Name_par2", "None");
                    selectcomm.Parameters.AddWithValue("@Job_par3", "None");
                    selectcomm.Parameters.AddWithValue("@Phone_par4", 0);
                    selectcomm.Parameters.AddWithValue("@Address_par5", "None");
                    selectcomm.Parameters.AddWithValue("@User_par6", TextBox1.Text);
                    selectcomm.Parameters.AddWithValue("@Pass_par7", TextBox2.Text);
                    selectcomm.Parameters.AddWithValue("@Salary_par8", 0);
                    selectcomm.Parameters.AddWithValue("@Shift_par9", 0);

                    user = TextBox1.Text;

                    MySqlDataAdapter adapter = new MySqlDataAdapter(selectcomm);

                    DataTable datatb = new DataTable();

                    adapter.Fill(datatb);

                    if (datatb.Rows.Count == 1)
                    {

                        r = selectcomm.ExecuteReader();

                        r.Read();

                        if (r.GetValue(2).ToString() == "Casher")
                        {

                            Form1 dh = new Form1();
                            dh.Show();
                            this.Hide();
                        }
                        else if (r.GetValue(2).ToString() == "Admin")
                        {

                            adminHome ad = new adminHome();
                            ad.Show();
                            this.Hide();
                        }

                        logfile log = new logfile();
                        bool result = log.logfilee("select user,pass,Job from employee where user = user_par6 and pass = pass_par7");


                    }
                    else
                    {
                        MessageBox.Show("Username or password incorrect");
                    }

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

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                log();
            }
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                log();
            }
        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            

            if (CheckBox1.Checked)
            {
                TextBox2.UseSystemPasswordChar = false;
            }

            else
            {
                TextBox2.UseSystemPasswordChar = true;
            }
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                TextBox2.UseSystemPasswordChar = false;
            }

            else
            {
                TextBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
