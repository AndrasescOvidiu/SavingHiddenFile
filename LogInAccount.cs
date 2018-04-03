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
    public partial class LogInAccount : Form
    {
        public static String userDetails;
        public LogInAccount()
        {
            InitializeComponent();

            pictureBox1.Visible = false;
            pictureBox7.Visible = false;
            pictureBox8.Visible = false;
            leftTryesModifier.Visible = false;
            leftTryesText.Visible = false;
            
        }
        private int counter = 3;
        private async void button2_Click(object sender, EventArgs e)   // log in button
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            


            if (username != "" && password != "")
            {
                /*
                 * String fileLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
                    String user_passwords = "user&passwords.txt";
                    String myFileName = username+"File.txt";

                    String[] fileLocationSpliter = fileLocation.Split('\\');
                    String myFileNameSpliter = fileLocationSpliter[fileLocationSpliter.Length - 1];
                    fileLocation = fileLocation.Replace("\\SavingHiddenFile.exe", "\\" + myFileName);
                 * */
                String fileLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
                String user_passwords = "user&passwords.txt";
                String myFileName = username + "File.txt";

                String[] fileLocationSpliter = fileLocation.Split('\\');
                String myFileNameSpliter = fileLocationSpliter[fileLocationSpliter.Length - 1];
                fileLocation = fileLocation.Replace("\\Digital Notebook.exe", "\\" + user_passwords);

                int ok = 0;
                try
                {
                    StreamReader rd = new StreamReader(fileLocation);
                    String info = "";
                    while((info = rd.ReadLine())!=null)
                    {
                        String[] table = info.Split(' ');
                        if(table[0] == username && table[1]== password)
                        {
                            //MessageBox.Show("Succeded to connect!");
                            timer1.Start();
                            pictureBox7.Visible = true;
                            pictureBox1.Visible = false;
                            pictureBox8.Visible = false;
                            ok = 1;

                            await Task.Delay(500);

                            userDetails = username;

                            UserForm f = new UserForm();
                            this.Hide();
                            f.ShowDialog();
                            this.Close();
                        }
                    }
                    if(ok == 0 && counter >=0)
                    {
                        leftTryesModifier.Visible = true;
                        leftTryesText.Visible = true;
                        counter--;

                        timer1.Start();
                        pictureBox1.Visible = true;
                        pictureBox2.Visible = false;
                        pictureBox8.Visible = false;

                        if (counter != -1)
                        {
                            leftTryesText.Visible = true;
                            leftTryesModifier.Text = counter.ToString();
                        }
                    }
                    if(counter == -1)
                    {
                        MessageBox.Show("Eroareee cacatel! Se inchide");
                        this.Close();
                    }

                }catch(Exception exc)
                {
                    MessageBox.Show("No accounts were created yet. Create one? Yes No");
                }
            }
            else
                MessageBox.Show("Enter your username and password");

            /**/
        }


        private void timer1_Tick(object sender, EventArgs e)   // timerrr
        {
            if (pictureBox1.Visible)
            {
                pictureBox2.Visible = true;
                pictureBox1.Visible = false;
                timer1.Enabled = false;
            }
            if(pictureBox7.Visible)
            {
                pictureBox8.Visible = true;
                pictureBox7.Visible = false;
                timer1.Enabled = false;
            }
        }

        private void label4_Click(object sender, EventArgs e)  // label click to register account
        {
            CreateUserAndPass f = new CreateUserAndPass();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e) // back to menu
        {
            Menu f = new Menu();
            this.Hide();
            f.ShowDialog();
            this.Close();

        }
        private void button1_Click(object sender, EventArgs e)   // exit
        {
            this.Close();

        }

    }
}
