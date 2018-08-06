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
    public partial class Category : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        public Category()
        {
            InitializeComponent();
        }

        MySqlConnection myconn;

        public void populateDGV()
        {
            myconn = new MySqlConnection(connection);

            string selectQuery = " SELECT * FROM category ";
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, myconn);
            adapter.Fill(table);
            dataGridView_category.DataSource = table;
        }
        private void Category_Load(object sender, EventArgs e)
        {
            populateDGV();
        }

        private void dataGridView_category_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxID.Text = dataGridView_category.CurrentRow.Cells[0].Value.ToString();
            textBoxName.Text = dataGridView_category.CurrentRow.Cells[1].Value.ToString();

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
                openConnection();
                MySqlCommand command = new MySqlCommand(query, myconn);
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
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "Insert into category (Category_name) value ('" + textBoxName.Text + "');";
            executeMyQuery(insertQuery);
            populateDGV();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            adminHome adh = new adminHome();
            adh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string updateQuery = "update category set Category_name='" + textBoxName.Text + "'   where Category_id = '" + int.Parse(textBoxID.Text) + "'";
            executeMyQuery(updateQuery);
            populateDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deleteQuery = " delete from category where Category_id = '" + int.Parse(textBoxID.Text) + "'";
            executeMyQuery(deleteQuery);
            populateDGV();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myconn = new MySqlConnection(connection);

            MySqlDataReader mdr;
            string select = " select * from category where Category_id = '" + int.Parse(textBoxID.Text) + "'";
            MySqlCommand command = new MySqlCommand(select, myconn);
            myconn.Open();
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                textBoxName.Text = mdr.GetString("Category_name");
                
            }
            else
            {
                MessageBox.Show("Item Not Found");
            }
            myconn.Close();
        }
    }
}
