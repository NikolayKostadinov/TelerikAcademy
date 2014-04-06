using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentRegistrationForm
{
    public partial class StudentForm : System.Web.UI.Page
    {
        private IEnumerable<KeyValuePair<int, string>> universities =
            new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0,"TU Varna"),
                new KeyValuePair<int, string>(1,"IU Varna"),
                new KeyValuePair<int, string>(2,"Sofia Univarsity"),
                new KeyValuePair<int, string>(3,"UNSS"),
                new KeyValuePair<int, string>(4,"TU Sofia"),
                new KeyValuePair<int, string>(5,"BSU"),
            };

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DropDownListUniversity.Items.Add(string.Empty);
            if (!this.Page.IsPostBack)
            {
                foreach (var university in universities)
                {
                    this.DropDownListUniversity.Items.Add(
                        new ListItem(
                            university.Value,
                            university.Key.ToString()));
                }
            }
        }

        protected void DropDownListUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownListUniversity.SelectedIndex == 0)
            {
                return;
            }
            this.ListBoxSpecialty.Items.Clear();
            var universityName = this.DropDownListUniversity.SelectedItem.Text;
            var specialties = new List<KeyValuePair<int, String>>();
            for (int i = 0; i < 20; i++)
            {
                this.ListBoxSpecialty.Items.Add(
                    new ListItem("Specialty " + i + " of the " + universityName ,i.ToString()));
            }
        }
    }
}