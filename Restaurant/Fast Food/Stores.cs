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
    public partial class Stores : Form
    {

        string connection = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        public Stores()
        {
            InitializeComponent();
        }

        MySqlConnection myconn;




        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Stores_Load(object sender, EventArgs e)
        {
            populateDGV();
        }

        public void populateDGV()
        {

            myconn = new MySqlConnection(connection);

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM items", myconn);

            adapter.Fill(table);

            dataGridView_items.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "Insert into items (Item_name , Price , Quantity , Category_id) value ('" + textBoxName.Text + "','" + textBoxPrice.Text + "','" + textBoxQuantity.Text + "','" + textBoxCat.Text + "');";
            executeMyQuery(insertQuery);

            logfile log = new logfile();
            bool result = log.logfilee("Insert into items (Item_name , Price , Quantity , Category_id) value ('" + textBoxName.Text + "','" + textBoxPrice.Text + "','" + textBoxQuantity.Text + "','" + textBoxCat.Text + "')");


            populateDGV();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            adminHome adh = new adminHome();
            adh.Show();
        }
        
        
        private void dataGridView_items_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxID.Text = dataGridView_items.CurrentRow.Cells[0].Value.ToString();
            textBoxName.Text = dataGridView_items.CurrentRow.Cells[1].Value.ToString();
            textBoxPrice.Text = dataGridView_items.CurrentRow.Cells[2].Value.ToString();
            textBoxQuantity.Text = dataGridView_items.CurrentRow.Cells[3].Value.ToString();
            textBoxCat.Text = dataGridView_items.CurrentRow.Cells[4].Value.ToString();

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
                MySqlCommand command = new MySqlCommand(query,myconn);
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

        private void button2_Click(object sender, EventArgs e)
        {
            string updateQuery = "update items set Item_name='" + textBoxName.Text + "' , Price= '" + textBoxPrice.Text + "', Quantity='" + textBoxQuantity.Text + "' , Category_id='" + textBoxCat.Text + "' where Item_id = '"+int.Parse(textBoxID.Text)+"'";
            executeMyQuery(updateQuery);

            logfile log = new logfile();
            bool result = log.logfilee("update items set Item_name='" + textBoxName.Text + "' , Price= '" + textBoxPrice.Text + "', Quantity='" + textBoxQuantity.Text + "' , Category_id='" + textBoxCat.Text + "' where Item_id = '" + int.Parse(textBoxID.Text) + "'");


            populateDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string deleteQuery = "delete from items where Item_id = '" + int.Parse(textBoxID.Text) + "'";
            executeMyQuery(deleteQuery);

            logfile log = new logfile();
            bool result = log.logfilee("delete from items where Item_id = '" + int.Parse(textBoxID.Text) + "'");


            populateDGV();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myconn = new MySqlConnection(connection);

            MySqlDataReader mdr;
            string select = "select * from items where Item_id = '" + int.Parse(textBoxID.Text) + "'";
            MySqlCommand command = new MySqlCommand(select, myconn);
            openConnection();
            mdr = command.ExecuteReader();

            logfile log = new logfile();
            bool result = log.logfilee("select * from items where Item_id = '" + int.Parse(textBoxID.Text) + "'");

            if (mdr.Read())
            {
                textBoxName.Text = mdr.GetString("Item_name");
                textBoxPrice.Text = mdr.GetString("Price");
                textBoxQuantity.Text = mdr.GetString("Quantity");
                textBoxCat.Text = mdr.GetString("Category_id");
            }
            else
            {
                MessageBox.Show("Item Not Found");
            }
            closeConnection();
        }
    }
}
