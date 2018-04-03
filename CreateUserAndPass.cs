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
    public partial class CreateUserAndPass : Form
    {
        public CreateUserAndPass()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            String username = textBox1.Text;
            String password1 = textBox2.Text;
            String password2 = textBox3.Text;

            if(password1!="" && password2!=""&& username != "")
            {
                if (password1 == password2)
                {

                    String fileLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
                    String user_passwords = "user&passwords.txt";
                    String myFileName = username+"File.txt";

                    String[] fileLocationSpliter = fileLocation.Split('\\');
                    String myFileNameSpliter = fileLocationSpliter[fileLocationSpliter.Length - 1];
                    fileLocation = fileLocation.Replace("\\Digital Notebook.exe", "\\" + myFileName);

                    int ok = 0;
                    try
                    {

                        StreamReader rd = new StreamReader(user_passwords);
                        String info = "";
                        
                        while((info = rd.ReadLine())!=null)
                        {
                            String[] table = info.Split(' ');
                            if(table[0] == username )
                            {
                                MessageBox.Show("It's already an account with that username, choose a diferent one");
                                ok = 1;
                            }
                        }
                        rd.Close();
                        if (ok == 0)
                        {
                            fileLocation = fileLocation.Replace("\\" + myFileName, "\\" + user_passwords);

                            StreamWriter wrd = new StreamWriter(fileLocation, true);
                            wrd.WriteLine(username + " " + password1+"\n");
                            FileInfo secFile = new FileInfo(user_passwords);
                            secFile.Attributes = FileAttributes.Normal;
                            wrd.Close();


                            fileLocation = fileLocation.Replace("\\" + user_passwords, "\\" + myFileName);

                            // creare noua fila
                            StreamWriter wr = new StreamWriter(fileLocation);
                            wr.WriteLine("I write Something Here for the first time!");
                            FileInfo newFile = new FileInfo(myFileName);
                            newFile.Attributes = FileAttributes.Normal;
                            wr.Close();

                            MessageBox.Show("Your account was created!");

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                        }


                    }
                    catch (Exception exc)
                    {
                        fileLocation = fileLocation.Replace("\\" + myFileName, "\\" + user_passwords);
                        MessageBox.Show(fileLocation);
                        StreamWriter wrd = new StreamWriter(fileLocation, true);
                        wrd.WriteLine(username + " " + password1);
                        FileInfo secFile = new FileInfo(user_passwords);
                        secFile.Attributes = FileAttributes.Normal;
                        wrd.Close();
                        fileLocation = fileLocation.Replace("\\" + user_passwords, "\\" + myFileName);

                        StreamWriter wr = new StreamWriter(fileLocation);
                        wr.WriteLine("I write Something Here for the first time!");
                        FileInfo newFile = new FileInfo(myFileName);
                        newFile.Attributes = FileAttributes.Normal;
                        wr.Close();

                        MessageBox.Show("Your account was created!");

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                    }


                    // creare fila noua cu OvidiuFile.txt - unde se salveaza datele
                    /*StreamWriter wr = new StreamWriter(fileLocation);
                    wr.WriteLine("I write Something Here for the first time!");
                    FileInfo newFile = new FileInfo(myFileName);
                    newFile.Attributes = FileAttributes.Normal;
                    wr.Close();*/

                   // fileLocation = fileLocation.Replace("\\"+myFileName, "\\" + user_passwords);
                    
                    //adaugare de user & password;

                    /*StreamWriter wrd = new StreamWriter(fileLocation);
                    wrd.WriteLine(username+" "+password1);
                    FileInfo secFile = new FileInfo(user_passwords);
                    secFile.Attributes = FileAttributes.Normal;
                    wrd.Close();*/

                  
                }

            }
            else
            {
                MessageBox.Show("Please fill all the areas!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e) // exit
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)   // back to menu
        {
            Menu f = new Menu();
            this.Hide();
            f.ShowDialog();
            this.Close();
        }
    }
}
