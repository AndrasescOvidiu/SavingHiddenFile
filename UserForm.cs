using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SavingHiddenFile
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();

            String username = LogInAccount.userDetails;

            String fileLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            String myFileName = username + "File.txt";

            String[] fileLocationSpliter = fileLocation.Split('\\');
            String myFileNameSpliter = fileLocationSpliter[fileLocationSpliter.Length - 1];
            fileLocation = fileLocation.Replace("\\Digital Notebook.exe", "\\" + myFileName);
            try
            {
                int i = 0;
                StreamReader rd = new StreamReader(fileLocation);
                //->>  
                String info = "aa";
                String containt = "";
                while ((info = rd.ReadLine()) != null)
                {
                    i++;
                    containt += info + "\n";
                }
                for (int j = 0; j < 20 - i; i++)
                {
                    containt += "\n";
                }

                richTextBox1.Text = containt;
                rd.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Your file is empty.");

            }
        }

        private void button1_Click(object sender, EventArgs e) // exit
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)   // saving
        {

            String username = LogInAccount.userDetails;

            String fileContainer = "";

            String fileLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            String myFileName = username + "File.txt";

            String[] fileLocationSpliter = fileLocation.Split('\\');
            String myFileNameSpliter = fileLocationSpliter[fileLocationSpliter.Length - 1];
            fileLocation = fileLocation.Replace("\\Digital Notebook.exe", "\\" + myFileName);
            try
            {
                int i = 0;
                StreamReader rd = new StreamReader(fileLocation);
                //->>  
                String info = "aa";
                String containt = "";
                while ((info = rd.ReadLine()) != null)
                {
                    i++;
                    containt += info + "\n";
                }
                /*for (int j = 0; j < 20 - i; i++)
                {
                    containt += "\n";
                }
                */
                fileContainer = containt.Trim();

                rd.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Your file is empty.");

            }


            if (richTextBox1.Text.Trim() != fileContainer)
            {
                DialogResult d = MessageBox.Show("Are you sure?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d == DialogResult.Yes)
                {
                    StreamWriter wr = new StreamWriter(fileLocation);
                    String info = richTextBox1.Text.Trim();
                    wr.WriteLine(info);
                    wr.Close();
                }

            }
        }


        private void button4_Click(object sender, EventArgs e)  // delete
        {

            DialogResult  d= MessageBox.Show("This action will delete your file!\nContinue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d == DialogResult.Yes)
            {

                String username = LogInAccount.userDetails;

                String fileLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
                String myFileName = username + "File.txt";

                String[] fileLocationSpliter = fileLocation.Split('\\');
                String myFileNameSpliter = fileLocationSpliter[fileLocationSpliter.Length - 1];
                fileLocation = fileLocation.Replace("\\Digital Notebook.exe", "\\" + myFileName);

                StreamWriter wr = new StreamWriter(fileLocation);
                wr.WriteLine("");
                richTextBox1.Text = "";
                for (int i = 0; i <= 20; i++)
                {
                    richTextBox1.Text += "\n";
                }
                wr.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)  // show my info
        {
            String username = LogInAccount.userDetails;

            String fileContainer = "";

            String fileLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            String myFileName = username + "File.txt";

            String[] fileLocationSpliter = fileLocation.Split('\\');
            String myFileNameSpliter = fileLocationSpliter[fileLocationSpliter.Length - 1];
            fileLocation = fileLocation.Replace("\\Digital Notebook.exe", "\\" + myFileName);
            try
            {
                int i = 0;
                StreamReader rd = new StreamReader(fileLocation);
                //->>  
                String info = "aa";
                String containt = "";
                while ((info = rd.ReadLine()) != null)
                {
                    i++;
                    containt += info + "\n";
                }
                /*for (int j = 0; j < 20 - i; i++)
                {
                    containt += "\n";
                }
                */
                fileContainer = containt.Trim();
                
                rd.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Your file is empty.");

            }
            
            if (richTextBox1.Text.Trim() != fileContainer)
            {
                if (richTextBox1.Text.Trim() != "")
                {
                    DialogResult d = MessageBox.Show("This will show the containt of your file and clear the previous info. Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (d == DialogResult.Yes)
                    {
                        richTextBox1.Text = fileContainer;
                    }
                }
                else
                    richTextBox1.Text = fileContainer;
            }
            else
                richTextBox1.Text = fileContainer;
            
        }


        private void button6_Click(object sender, EventArgs e)
        {
             richTextBox1.Text = "";
             for (int i = 0; i <= 20; i++)
             {
                    richTextBox1.Text += "\n";
             }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LogInAccount f = new LogInAccount();
            this.Hide();
            f.ShowDialog();
            this.Close();
      
        }
    }
}
