using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavingHiddenFile
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            pictureBox8.Visible = false;
            pictureBox9.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)  // log in into an existing account
        {
            LogInAccount f = new LogInAccount();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)  // creating new account
        {
            CreateUserAndPass f = new CreateUserAndPass();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox8.Visible = true;
            pictureBox2.Visible = false;
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox9.Visible = true;
            pictureBox5.Visible = false;
            timer2.Enabled = false;

        }
    }
}
