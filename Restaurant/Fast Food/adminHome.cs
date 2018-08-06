using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fast_Food;
using login_page;
using BackupandRestoreDatabase;
using MySql.Data.MySqlClient;
namespace admin
{
    public partial class adminHome : Form
    {
        public adminHome()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("server=localhost;database=resturant;username=root;password=root");

        private void button1_Click(object sender, EventArgs e)
        {
            select sel = new select();
            sel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customers cs = new Customers();
            cs.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Stores st = new Stores();
            st.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
            if ( panel2.Width == 158)
            {
                panel2.Height = 687;
                panel2.Width = 30;
            }
            else if ( panel2.Width == 30){
              panel2.Height = 687;
              panel2.Width = 158;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            orders od = new orders();
            od.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Backupp bk = new Backupp();
            bk.Show();
        }

        String user = Login.SetValueForText1;
        MySqlCommand command;
        MySqlDataReader mdr;

        private void adminHome_Load(object sender, EventArgs e)
        {
            connection.Open();
            label4.Text = Login.SetValueForText1;
            string selectQuery = "select * from employee where user='" + user + "'";
            command = new MySqlCommand(selectQuery, connection);

            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                label5.Text = mdr.GetString("Employee_name");
                label8.Text = mdr.GetString("Phone");
                label10.Text = mdr.GetString("Address");
                // label13.Text = mdr.GetString("numShift");
                // label14.Text = mdr.GetString("salary");
            }
            else
            {
                MessageBox.Show("No Data");
            }
            connection.Close();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Category cg = new Category();
            cg.Show();
            this.Hide();
        }
    }
}
