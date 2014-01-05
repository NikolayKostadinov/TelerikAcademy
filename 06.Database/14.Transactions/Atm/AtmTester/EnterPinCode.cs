using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atm.Data.Models;

namespace AtmTester
{
    public partial class EnterPinCode : Form
    {
        public static bool IsPinValid { get; set; }

        public EnterPinCode()
        {
            InitializeComponent();
        }

        void tbPinCode_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                IsPinValid = (ReportForAvailableCash.CardAccount.CardPin == this.tbPinCode.Text);
                this.Hide();
            }
        }
    }
}
