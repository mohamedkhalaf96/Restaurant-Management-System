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

namespace BackupandRestoreDatabase
{
    public partial class Backupp : Form
    {

        MySqlConnection mysqlConnection = null;
        MySqlCommand myCommand = null;
        MySqlBackup mybackup = null;

        string connection = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        public Backupp()
        {
            InitializeComponent();
        }

        private void Browse_Button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if(fbd.ShowDialog() == DialogResult.OK)
            {
                Location_Text.Text = fbd.SelectedPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mysqlConnection = new MySqlConnection(connection);
            try
            {
                mysqlConnection.Open();
                MessageBox.Show("The connection is " + mysqlConnection.State);
            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
            finally
            {
                mysqlConnection.Close();
            }
        }

        private void Backup_Button_Click(object sender, EventArgs e)
        {
             using (mysqlConnection = new MySqlConnection(connection))
            {
                using (myCommand = new MySqlCommand())
                {
                    using(mybackup = new MySqlBackup(myCommand))
                    {
                        myCommand.Connection = mysqlConnection;
                        mysqlConnection.Open();
                        mybackup.ExportToFile(Location_Text.Text + "\\resturant.sql");
                        MessageBox.Show("Database Backup successfully");
                        mysqlConnection.Close();
                    }
                }
            }
        }

        private void Location_Text_TextChanged(object sender, EventArgs e)
        {

        }

        private void Location_Click(object sender, EventArgs e)
        {

        }

        private void Open_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();

            if(ofg.ShowDialog() == DialogResult.OK)
            {
                Restore_Text.Text = ofg.FileName;
                Backup_Button.Enabled = false;
            }
        }

        private void Restore_Button_Click(object sender, EventArgs e)
        {
            using(mysqlConnection = new MySqlConnection(connection))
            {
                using(myCommand = new MySqlCommand())
                {
                    using (mybackup = new MySqlBackup(myCommand))
                    {
                        myCommand.Connection = mysqlConnection;
                        mysqlConnection.Open();
                        mybackup.ImportFromFile(Restore_Text.Text);
                        MessageBox.Show("Database Restore Successfully");
                        mysqlConnection.Close();
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
