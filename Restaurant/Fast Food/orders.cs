using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using Fast_Food;
using login_page;



namespace Fast_Food
{
    public partial class orders : Form
    {

        string connection = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        public orders()
        {
            InitializeComponent();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void orders_Load(object sender, EventArgs e)
        {

            MySqlConnection myconn = new MySqlConnection(connection);

            try
            {
                myconn.Open();

                MySqlCommand mycomm = new MySqlCommand("select * from sells_bill", myconn);

                BindingSource source = new BindingSource();

                source.DataSource = mycomm.ExecuteReader();

                dataGridView1.DataSource = source;

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

        private void button1_Click(object sender, EventArgs e)
        {
               
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
