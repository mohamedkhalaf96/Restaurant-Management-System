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

namespace Fast_Food
{
    public partial class select : Form
    {
        public select()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            employee emp = new employee();
            emp.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateEmployee emp = new UpdateEmployee();
            emp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteEmployee emp = new DeleteEmployee();
            emp.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            adminHome lg = new adminHome();
            lg.Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            adminHome adh = new adminHome();
            adh.Show();
            this.Hide();
        }
    }
}
