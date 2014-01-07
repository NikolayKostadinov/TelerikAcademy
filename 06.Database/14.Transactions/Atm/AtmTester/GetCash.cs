
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

        private void BtGetCash_Click(object sender, EventArgs e)
        {
            using (AtmContext context = new AtmContext()) 
            {
                UpdateAccountCash(context);

                try
                {
                    context.SaveChanges();
                }
                catch(DbUpdateConcurrencyException)
                {
                    Utility.CardAccount = Utility.GetAccountDetails(Utility.CardAccount);
                    string message = 
                        string.Format("Transaction is blocked due to paralel transaction.\n"
                        +"The card cash is {0:F2}.\nDo you want to continue with transaction?",
                        Utility.CardAccount.CardCash);
 
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
            Utility.CardAccount = (from acc in context.CardAccounts
                                                  where acc.CardNumber == tbCardNumber.Text
                                                  select acc).Single();
            try
            {
                decimal wantedCash;
                decimal.TryParse(tbWantedCash.Text, out wantedCash);
                Utility.CardAccount.CardCash -= wantedCash;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Not enought CardCash");
            }
        }
    }
}
