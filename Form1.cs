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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            String fileLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            String myFileName = "pass&user.txt";
            String []fileLocationSpliter = fileLocation.Split('\\');
            String myFileNameSpliter = fileLocationSpliter[fileLocationSpliter.Length - 1];
            fileLocation = fileLocation.Replace("\\SavingHiddenFile.exe","\\"+myFileName);

            try
            {
                //FileInfo newFile = new FileInfo("file.txt");
                //newFile.Attributes = FileAttributes.Normal;
                StreamReader rd = new StreamReader(fileLocation);
                String info = rd.ReadLine();
                MessageBox.Show(info);
                rd.Close();
                FileInfo newFile = new FileInfo(myFileName);
                newFile.Attributes = FileAttributes.Normal;
            }
            catch (Exception exc)
            {
                CreateUserAndPass f = new CreateUserAndPass();
                this.Hide();
                f.ShowDialog();
                this.Close();

                /*StreamWriter wr = new StreamWriter(fileLocation);
                wr.WriteLine("I write Something Here for the first time!");
                FileInfo newFile = new FileInfo(myFileName);
                newFile.Attributes = FileAttributes.Normal;
                wr.Close();*/
            }

            MessageBox.Show("Done!");
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
