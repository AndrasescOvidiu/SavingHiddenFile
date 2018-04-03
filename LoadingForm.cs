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
    public partial class LoadingFormsd : Form
    {
        public LoadingFormsd()
        {
            InitializeComponent();
            pictureBox9.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu f = new Menu();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox8.Visible = false;
            pictureBox9.Visible = true;
            timer1.Enabled = false;
        }
    }
}
