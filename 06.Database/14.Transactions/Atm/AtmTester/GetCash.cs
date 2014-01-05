
namespace AtmTester
{
    using Atm.Data.Models;
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Data.Entity.Infrastructure;
    using Atm.Data;

    public partial class GetCash : Form
    {
        public GetCash()
        {
            InitializeComponent();
        }

        private void GetCash_Load(object sender, EventArgs e)
        {
            this.tbCardNumber.Text = ReportForAvailableCash.CardAccount.CardNumber;
            this.lblAvailableCash.Text = string.Format("{0:F2}", ReportForAvailableCash.CardAccount.CardCash);
        }

        private void BtGetCash_Click(object sender, EventArgs e)
        {
            using (AtmContext context = new AtmContext()) 
            {
                UpdateAccountCash(context);

                try
                {
                    context.SaveChanges();
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    ReportForAvailableCash.CardAccount = Utility.GetAccountDetails(ReportForAvailableCash.CardAccount);
                    string message = 
                        string.Format("Transaction is blocked due to paralel transaction.\n"
                        +"The card cash is {0:F2}.\nDo you want to continue with transaction?", 
                        ReportForAvailableCash.CardAccount.CardCash);
 
                    var result = MessageBox.Show(message,"Money transfer error!", MessageBoxButtons.YesNo);
                    
                    if (result.ToString() == "Yes") 
                    { 
                        UpdateAccountCash(context); 
                    }
                }
                this.Hide();
            }
        }

        private void UpdateAccountCash(AtmContext context)
        {
            ReportForAvailableCash.CardAccount = (from acc in context.CardAccounts
                                                  where acc.CardNumber == tbCardNumber.Text
                                                  select acc).Single();
            try
            {
                decimal wantedCash;
                decimal.TryParse(tbWantedCash.Text, out wantedCash);
                ReportForAvailableCash.CardAccount.CardCash -= wantedCash;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Not enought CardCash");
            }
        }
    }
}
