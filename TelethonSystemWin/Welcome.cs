using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelethonSystemWin
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        int attemps = 1;
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            string username = UsernameTxt.Text;
            string password = PasswordTxt.Text;
            

            using (StreamReader sr = new StreamReader(@"..\Debug\Login.txt"))
            {
                {
                    while (sr.Peek() >= 0)
                    {
                        if (attemps == 3)
                        {
                            MessageBox.Show("You have reached the maximum number of attemps...");
                            Application.Exit();
                            break;
                        }
                        if (username == "" || password == "")
                        {
                            MessageBox.Show("Please enter username and password.");
                        }


                        string str;
                        string[] strArray;
                        str = sr.ReadLine();

                        strArray = str.Split(',');

                        if (strArray[0] == username && strArray[1] == password)
                        {
                            ETSTelethon ETSTelethon = new ETSTelethon();
                            //ETSTelethon.Visible = true;
                            //ETSTelethon.Activate();
                            ETSTelethon.ShowDialog();
                                this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Error! Credentials do not match.. please try again\n Attemps done: " + attemps + " out of 3");
                            attemps++;
                        }

                        

                    }
                }
                

            }


        }

        private void btn_Exit_Click(object sender, EventArgs e)
        { 
            Environment.Exit(0);
        }

        private void Password_checkBox_CheckedChanged(object sender, EventArgs e)
        {
         
            if (Password_checkBox.CheckState == CheckState.Checked)
            {
                PasswordTxt.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordTxt.UseSystemPasswordChar = true;
            }

        }
    }
}
