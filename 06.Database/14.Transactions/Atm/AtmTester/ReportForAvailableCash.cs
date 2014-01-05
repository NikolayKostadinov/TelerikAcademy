namespace AtmTester
{
    using Atm.Data;
    using Atm.Model;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class ReportForAvailableCash : Form
    {
        public static CardAccount CardAccount = new CardAccount();

        public ReportForAvailableCash()
        {
            InitializeComponent();
        }

        private void btnGetCash_Click(object sender, EventArgs e)
        {
            try
            {
                CardAccount = Utility.GetAccountDetails(CardAccount);
                GetCash frmGetCash = new GetCash();
                EnterPinCode enterPinCode = new EnterPinCode();
                enterPinCode.ShowDialog(this);

                if (EnterPinCode.IsPinValid)
                {
                    frmGetCash.ShowDialog(this);
                    this.tbBalance.Text = GetBalance();
                }
                else
                {
                    MessageBox.Show("Invalid Pin Code!!!");
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                this.tbCardNumber.Focus();
            }
        }

        private void btnCardCash_Click(object sender, EventArgs e)
        {
            if (this.tbCardNumber.Text != "")
            {
                EnterPinCode enterPinCode = new EnterPinCode();
                enterPinCode.ShowDialog(this);

                if (EnterPinCode.IsPinValid)
                {
                    this.tbBalance.Text = GetBalance();
                }
                else
                {
                    MessageBox.Show("Invalid Pin Code!!!");
                }
            }
            else
            {
                MessageBox.Show("You nust enter a card number!");
            }
        }

        private string GetBalance()
        {
            string cashText = string.Format("{0:F2}", CardAccount.CardCash);
            return cashText;
        }

        private void tbCardNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                CardAccount.CardNumber = this.tbCardNumber.Text;
                try
                {
                    CardAccount = Utility.GetAccountDetails(CardAccount);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    this.tbCardNumber.Focus();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReportForAvailableCash_GotFocus(object sender, System.EventArgs e)
        {
            try
            {
                if (CardAccount.CardNumber != null)
                {
                    CardAccount = Utility.GetAccountDetails(CardAccount);
                    this.tbBalance.Text = this.GetBalance();
                }
            }
            catch 
            { 
            }
        }
    }
}