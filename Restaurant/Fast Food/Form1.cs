using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using login_page;
using MySql.Data.MySqlClient;
using System.Configuration;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Tables_page;

namespace Fast_Food
{
    public partial class Form1 : Form
    {

        public String Get_Code()
        {

            MySqlConnection myconn = new MySqlConnection(connection);

            MySqlDataReader r;

            
                myconn.Open();

                MySqlCommand mycomm = new MySqlCommand("SELECT max(Sells_bill_id)+1 FROM resturant.sells_bill", myconn);

                

            r = mycomm.ExecuteReader();
                r.Read();

            string code = r.GetValue(0).ToString();

            return code;

        }

        public int RowIndex = 0;

        string connection = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
       
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            MySqlConnection myconn = new MySqlConnection(connection);

            try
            {
                myconn.Open();

                MySqlCommand mycomm = new MySqlCommand("select * from category", myconn);

      
                MySqlDataAdapter adapter = new MySqlDataAdapter(mycomm);

                DataTable datatb = new DataTable();

                adapter.Fill(datatb);

                int x = panel1.Location.X + 70;
                int y = panel1.Location.Y;

                Button[] but = new Button[datatb.Rows.Count];

                int i = 0;

                foreach (DataRow row in datatb.Rows)
                {


                    but[i] = new Button();
                    but[i].Text = row["Category_name"].ToString();
                    but[i].Size = new System.Drawing.Size(150, 80);
                    but[i].BackColor = Color.White;
                    but[i].Tag = row["Category_id"].ToString();

                    but[i].Top = y;
                    but[i].Left = x;
                    panel1.Controls.Add(but[i]);

                    but[i].Click += productEvent;

                    y += 90;

                    i++;

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

        public void productEvent(object sender, EventArgs e)
        {

            panel3.Controls.Clear();

            MySqlConnection myconn = new MySqlConnection(connection);

            try
            {
                myconn.Open();

                MySqlCommand mycomm = new MySqlCommand("SELECT * FROM resturant.items join resturant.category on resturant.category.Category_id = resturant.items.Category_id where Category_name = '" + ((Button)sender).Text+"' ", myconn);

                MySqlDataAdapter adapter = new MySqlDataAdapter(mycomm);

                DataTable datatb = new DataTable();

                adapter.Fill(datatb);

                int x = panel3.Location.X + 70;
                int y = panel3.Location.Y;

                Button[] but = new Button[datatb.Rows.Count];

                int i = 0;

                foreach (DataRow row in datatb.Rows)
                {


                    but[i] = new Button();
                    but[i].Text = row["Item_name"].ToString();
                    but[i].Size = new System.Drawing.Size(150, 80);
                    but[i].BackColor = Color.White;
                    but[i].Tag = row["Item_id"].ToString();

                    but[i].Top = y;
                    but[i].Left = x;
                    panel3.Controls.Add(but[i]);

                    but[i].Click += itemEvent;

                    y += 90;

                    i++;

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

        private void itemEvent(object sender, EventArgs e)
        {


            MySqlConnection myconn = new MySqlConnection(connection);

            MySqlDataReader r;

            try
            {
                myconn.Open();

                MySqlCommand mycomm = new MySqlCommand("SELECT * FROM resturant.items where Item_name = '" + ((Button)sender).Text + "' ", myconn);
            
                    r = mycomm.ExecuteReader();
                    r.Read();

                int ProductID = Convert.ToInt32(r.GetValue(0).ToString());

                if (CheckProductAlreadyAdded(ProductID))
                {
                   
                    int Quantity = Convert.ToInt32(dataGridView1.Rows[RowIndex].Cells["Quantity"].Value);
                    double Price = Convert.ToDouble(dataGridView1.Rows[RowIndex].Cells["Price"].Value);

                    Quantity++;

                   
                    double TotalPrice = Convert.ToDouble(Quantity * Price);

                    dataGridView1.Rows[RowIndex].Cells["Quantity"].Value = Quantity;
                    dataGridView1.Rows[RowIndex].Cells["TotalPrice"].Value = TotalPrice;

                    TotalBillText.Text = CalculateTotalBill(dataGridView1).ToString();

                    quant.Text = QuantityItems(dataGridView1).ToString();

                    service.Text = ((CalculateTotalBill(dataGridView1) * 10) / 100).ToString();

                    addedText.Text = ((CalculateTotalBill(dataGridView1) * 14) / 100).ToString();

                    totalText.Text = (CalculateTotalBill(dataGridView1) + ((CalculateTotalBill(dataGridView1) * 10) / 100) + ((CalculateTotalBill(dataGridView1) * 14) / 100)).ToString();

                }
                else
                {
                    
                    dataGridView1.Rows.Add(r.GetValue(0).ToString(), r.GetValue(1).ToString(),Convert.ToDouble(r.GetValue(2)), 1, Convert.ToDouble(r.GetValue(2)));

                    TotalBillText.Text = CalculateTotalBill(dataGridView1).ToString();

                    quant.Text = QuantityItems(dataGridView1).ToString();

                    service.Text = ((CalculateTotalBill(dataGridView1) * 10) / 100).ToString();

                    addedText.Text = ((CalculateTotalBill(dataGridView1) * 14) / 100).ToString();

                    totalText.Text = (CalculateTotalBill(dataGridView1) + ((CalculateTotalBill(dataGridView1) * 10) / 100) + ((CalculateTotalBill(dataGridView1) * 14) / 100)).ToString();
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


        public bool CheckProductAlreadyAdded(int ProductID)
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                if (Convert.ToInt32(Row.Cells["ItemID"].Value) == ProductID)
                {
                    RowIndex = Row.Index;
                    return true;
                }
            }
            return false;
        }

        public decimal CalculateTotalBill(DataGridView dataGridView1)
        {
            decimal TotalBill = 0;

            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                decimal ProductTotal = Convert.ToDecimal(Row.Cells["TotalPrice"].Value);

                TotalBill = TotalBill + ProductTotal;
            }

            return TotalBill;
        }

        public decimal QuantityItems(DataGridView dataGridView1)
        {
            int q = 0;

            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {
                int quant = Convert.ToInt32(Row.Cells["Quantity"].Value);

                q = q + quant;
            }

            return q;
        }


        private void button7_Click(object sender, EventArgs e)
        {
           

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if ( panel1.Width == 251)
            {
                panel1.Height = 736;
                panel1.Width = 46;
            }
            else if(panel1.Width == 46)
            {
                panel1.Height = 736;
                panel1.Width = 251;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            code.Text = Get_Code();
            Date.Text = DateTime.Now.ToShortDateString();
            time.Text = DateTime.Now.ToShortTimeString();

            MySqlConnection myconn = new MySqlConnection(connection);

            MySqlDataReader r;

            try
            {
                myconn.Open();

                    MySqlCommand mycomm = new MySqlCommand("SELECT Employee_name,shift FROM resturant.employee where user = '"+Login.user+"' ", myconn);

                    r = mycomm.ExecuteReader();
                    r.Read();

                    shift.Text = r.GetValue(1).ToString();
                    casheir.Text = r.GetValue(0).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                myconn.Close();
            }





            dataGridView1.Rows.Clear();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
                {
                    if (MessageBox.Show("Are You Sure You Want to Delete this Product", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        decimal DeletedProductTotal = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["TotalPrice"].Value);

                        decimal CurrentTotalBill = Convert.ToDecimal(TotalBillText.Text);

                        CurrentTotalBill = CurrentTotalBill - DeletedProductTotal;

                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                        TotalBillText.Text = CurrentTotalBill.ToString();
                    }
                }
            }


        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {


            MySqlConnection myconn = new MySqlConnection(connection);

            try
            {
                myconn.Open();

                MySqlCommand mycomm = new MySqlCommand("insert into resturant.sells_bill (Total_price,Customer_id,bill_Date,bill_Time,shift) values ('"+ totalText.Text + "','"+ customer_id.Text +"','"+Date.Text+"','"+time.Text+"','"+shift.Text+"')", myconn);

                logfile log = new logfile();
                bool result = log.logfilee("insert into resturant.sells_bill (Total_price,Customer_id,bill_Date,bill_Time,shift) values ('" + totalText.Text + "','" + customer_id.Text + "','" + Date.Text + "','" + time.Text + "','" + shift.Text + "')");

                mycomm.ExecuteNonQuery();

                MessageBox.Show("Bill Saved");

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

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {

        }

        private void customer_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            
            Customers cs = new Customers();
            cs.Show();
            this.Hide();



        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Rochta.pdf", FileMode.Create));
            doc.Open();

            Paragraph p1 = new Paragraph("bill Num : " + code.Text + "\t                     Shift Num : " + shift.Text + "\n");
 
            Paragraph p2 = new Paragraph("Table number : " + table.Text + "\t            Casheir Name: " + casheir.Text + "\n\n");

            Paragraph p3 = new Paragraph("       Item name \t                  Price\t                  Quantity\t                  Total Price ");

            doc.Add(p1);
            doc.Add(p2);
            doc.Add(p3);


            Paragraph p6 = new Paragraph();


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                p6 = new Paragraph("       "+dataGridView1.Rows[i].Cells["ItemName"].Value + "\t                    " + dataGridView1.Rows[i].Cells["Price"].Value + "\t                    " + dataGridView1.Rows[i].Cells["Quantity"].Value + "\t                    " + dataGridView1.Rows[i].Cells["TotalPrice"].Value);
                doc.Add(p6);
            }
            
    

            Paragraph p7 = new Paragraph("\n ____________________________________________________________________________________");

            Paragraph p8 = new Paragraph("\n Total\t               Tax\t              Services\t          Total Bill ");

            Paragraph p9 = new Paragraph("\n"+totalText.Text.ToString()+ "\t           " + addedText.Text.ToString()+ "\t           " + service.Text.ToString()+ "\t           " + TotalBillText.Text.ToString());

            Paragraph p10 = new Paragraph("\n\n Date :   "+DateTime.Now.ToShortDateString() + "\t     Time :   "+DateTime.Now.ToShortTimeString());

            doc.Add(p7);
            doc.Add(p8);
            doc.Add(p9);
            doc.Add(p10);
            doc.Close();

        }

        private void customer_id_MouseHover(object sender, EventArgs e)
        {
            customer_id.Text = Customers.Statevalue;
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            Form11 ta = new Form11();
            ta.Show();
        }

      


    }
}
