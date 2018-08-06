using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tables_page
{
    public partial class Form11 : Form
    {

        Point t1_reserved = new Point(28, 74);
        Point t1_idle = new Point(870, 74);

        Point t2_reserved = new Point(28, 229);
        Point t2_idle = new Point(870, 229);

        Point t3_reserved = new Point(28, 381);
        Point t3_idle = new Point(870, 381);

        Point t4_reserved = new Point(175, 74);
        Point t4_idle = new Point(719, 74);

        Point t5_reserved = new Point(175, 229);
        Point t5_idle = new Point(719, 229);

        Point t6_reserved = new Point(175, 381);
        Point t6_idle = new Point(719, 381);

        Point t7_reserved = new Point(333, 74);
        Point t7_idle = new Point(574, 74);

        Point t8_reserved = new Point(333, 229);
        Point t8_idle = new Point(574, 229);

        Point t9_reserved = new Point(333, 381);
        Point t9_idle = new Point(574, 381);
        public Form11()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button button1 = (Button)sender;
            if (button2.Location == t1_reserved)
            {
                t1_idle = button1.Location;
            }
            else
            {
                t1_reserved = button1.Location;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button button1 = (Button)sender;
            if (button2.Location == t1_idle)
            {
                button1.Location = t1_reserved;
            }
            else
            {
                button1.Location = t1_idle;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Button button3 = (Button)sender;
            if (button4.Location == t2_reserved)
            {
                t2_idle = button3.Location;
            }
            else
            {
                t2_reserved = button3.Location;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Button button3 = (Button)sender;
            if (button4.Location == t2_idle)
            {
                button3.Location = t2_reserved;
            }
            else
            {
                button3.Location = t2_idle;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            Button button5 = (Button)sender;
            if (button6.Location == t3_reserved)
            {
                t3_idle = button6.Location;
            }
            else
            {
                t3_reserved = button5.Location;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Button button5 = (Button)sender;
            if (button6.Location == t3_idle)
            {
                button5.Location = t3_reserved;
            }
            else
            {
                button5.Location = t3_idle;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Button button7 = (Button)sender;
            if (button6.Location == t4_reserved)
            {
                t4_idle = button6.Location;
            }
            else
            {
                t4_reserved = button7.Location;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button button7 = (Button)sender;
            if (button8.Location == t4_idle)
            {
                button7.Location = t4_reserved;
            }
            else
            {
                button7.Location = t4_idle;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button button9 = (Button)sender;
            if (button10.Location == t5_reserved)
            {
                t5_idle = button10.Location;
            }
            else
            {
                t5_reserved = button9.Location;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Button button9 = (Button)sender;
            if (button10.Location == t5_idle)
            {
                button9.Location = t5_reserved;
            }
            else
            {
                button9.Location = t5_idle;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Button button11 = (Button)sender;
            if (button10.Location == t6_reserved)
            {
                t6_idle = button10.Location;
            }
            else
            {
                t6_reserved = button11.Location;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Button button11 = (Button)sender;
            if (button12.Location == t6_idle)
            {
                button11.Location = t6_reserved;
            }
            else
            {
                button11.Location = t6_idle;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            Button button13 = (Button)sender;
            if (button14.Location == t7_reserved)
            {
                t7_idle = button14.Location;
            }
            else
            {
                t7_reserved = button13.Location;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Button button13 = (Button)sender;
            if (button14.Location == t7_idle)
            {
                button13.Location = t7_reserved;
            }
            else
            {
                button13.Location = t7_idle;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button button15 = (Button)sender;
            if (button16.Location == t8_reserved)
            {
                t8_idle = button16.Location;
            }
            else
            {
                t8_reserved = button15.Location;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Button button15 = (Button)sender;
            if (button16.Location == t8_idle)
            {
                button15.Location = t8_reserved;
            }
            else
            {
                button15.Location = t8_idle;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

            Button button17 = (Button)sender;
            if (button18.Location == t9_reserved)
            {
                t9_idle = button18.Location;
            }
            else
            {
                t9_reserved = button17.Location;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Button button17 = (Button)sender;
            if (button18.Location == t9_idle)
            {
                button17.Location = t9_reserved;
            }
            else
            {
                button17.Location = t9_idle;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
