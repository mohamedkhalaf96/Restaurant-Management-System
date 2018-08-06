using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using admin;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Fast_Food
{
    public partial class Customers : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        public Customers()
        {
            InitializeComponent();
        }

        MySqlConnection myconn;

        MySqlCommand command;
        MySqlDataAdapter adapter;
        MySqlCommandBuilder bulider;
        DataTable table;
    public void populateDGV()
        {
            myconn = new MySqlConnection(connection);

            string selectQuery = " SELECT * FROM customer";
            table = new DataTable();
            adapter = new MySqlDataAdapter(selectQuery, myconn);
            adapter.Fill(table);
            dataGridView_Customer.DataSource = table;
        }
        private void Customers_Load(object sender, EventArgs e)
        {
            populateDGV();
        }

        private void dataGridView_Customer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        public void openConnection()
        {
            myconn = new MySqlConnection(connection);

            if (myconn.State == ConnectionState.Closed)
            {
                myconn.Open();
            }
        }

        public void closeConnection()
        {
            myconn = new MySqlConnection(connection);

            if (myconn.State == ConnectionState.Open)
            {
                myconn.Close();
            }
        }
        public void executeMyQuery(string query)
        {
            myconn = new MySqlConnection(connection);

            try
            {
                myconn.Open();
                command = new MySqlCommand(query, myconn);
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Query Executed");
                }
                else
                {
                    MessageBox.Show("Query Not Executed");

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

        

        private void button2_Click(object sender, EventArgs e)
        {
            bulider = new MySqlCommandBuilder(adapter);
            adapter.Update(table);
            MessageBox.Show("Successful");
        }

        

        

        private void button14_Click(object sender, EventArgs e)
        {
            Form1 ad = new Form1();
            ad.Show();
            this.Hide();
        }

        public static String Statevalue = "";

        private void dataGridView_Customer_MouseClick(object sender, MouseEventArgs e)
        {
            Statevalue = dataGridView_Customer.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
