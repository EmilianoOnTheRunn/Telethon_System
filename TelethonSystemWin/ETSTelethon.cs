using ETS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TelethonSystemWin
{
    public partial class ETSTelethon : Form
    {
        EtsManager man = new EtsManager();
        //private ETSTelethon eTSTelethon;
        private Welcome welcome;

        public ETSTelethon()
        {
            InitializeComponent();
        }



        //public ETSTelethon(ETSTelethon eTSTelethon)
        //{
        //    InitializeComponent();
        //    this.eTSTelethon = eTSTelethon;
        //}

        public ETSTelethon(Welcome welcome)
        {
            this.welcome = welcome;
        }






        private void closebtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



        private void AddSponsorbtn_Click(object sender, EventArgs e)
        {
            string message = "";
            message = man.addSponsor(SponsorIDtxt.Text, FirstNameTxt.Text, LastNameTxt.Text, Convert.ToDouble(ValueperPrizetxt.Text) * Convert.ToInt32(CurrentAvailabletxt.Text));
            MessageBox.Show(message);
        }



        private void AddPrizebtn_Click(object sender, EventArgs e)
        {
            string message = "";
            message = man.addPrize(PrizeIDtxt.Text, Descriptiontxt.Text, Convert.ToDouble(ValueperPrizetxt.Text), Convert.ToDouble(MinimumDonationLimittxt.Text), Convert.ToInt32(CurrentAvailabletxt.Text), Convert.ToInt32(CurrentAvailabletxt.Text), SponsorIDtxt.Text);
            MessageBox.Show(message);
        }



        private void ViewsSponsorsbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(man.ListSponsors());
            richbox.Clear();
            string list = man.ListSponsors();
            richbox.AppendText(list);
        }



        private void ViewPrizesbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(man.ListPrizes());
            richbox.Clear();
            string list = man.ListPrizes();
            richbox.AppendText(list);
        }



        private void showPrizesbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(man.ListQualifiedPrizes(Convert.ToDouble(Amounttxt.Text)));
            //MessageBox.Show(man.ListQualifiedPrizes(Convert.ToDouble(awardNumbertxt)));

        }



        private void addDonationbtn_Click(object sender, EventArgs e)
        {
            string message = "";
            message = man.addDonation(DonationIDtxt.Text, DateTime.Now.ToString("MM/dd/yyyy"), DonorIDtxt.Text, Convert.ToDouble(Amounttxt.Text), awardPrizeIDtxt.Text, Convert.ToInt32(NumberOfPrizetxt.Text));
            MessageBox.Show(message);
        }





        private void listDonationsbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(man.ListDonations());
            richbox.Clear();
            string list = man.ListDonations();
            richbox.AppendText(list);
        }



        private void listDonorsbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(man.ListDonors());  
            richbox.Clear();
            string list = man.ListDonors();
            richbox.AppendText(list);
        }



        private void saveDonorInfobtn_Click(object sender, EventArgs e)
        {
            if (man.writeIntoDonor())
            {
                MessageBox.Show("Donor has been succesfully saved.");
            }
             
        }

        private void addDonor_btn_Click(object sender, EventArgs e)
        {

            char cardType = '\0';
            if (visa_rbtn.Checked == true)
            {
                cardType = 'V';
            }
            else if (mc_rbtn.Checked == true)
            {
                cardType = 'M';
            }
            else if(amex_rbtn.Checked == true)
            {
                cardType = 'A';
            }


            //declare character
            string message = "";
            message = man.addDonor(DonorIDtxt.Text, Donor_FirstNametxt.Text, lastName_Donor_txt.Text, Donor_addresstxt.Text, donor_phonetxt.Text, cardType , numbertxt.Text,expirytxt.Text);
            MessageBox.Show(message);
        }


        private void savePrizebtn_Click(object sender, EventArgs e)
        {
            if (man.writeIntoPrize())
            {
                MessageBox.Show("The prize has been succesfully saved.");
            }
        }

        private void ETSTelethon_Load(object sender, EventArgs e)
        {
            man.readAll(); 
        }
    }
}