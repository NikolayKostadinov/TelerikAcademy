using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CarShop
{
    public partial class CarSelection : System.Web.UI.Page
    {
        private ICollection<Producer> producers;
        private ICollection<Extra> extras;
        private ICollection<EngineType> engineType;

        public CarSelection() 
        {
            this.producers = new List<Producer>();
            Populator.PopulateProducers(producers);
            extras = Populator.PopulateExtras();
            engineType = Populator.GetEngineTypes();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.DropDownListProducer.DataSource = this.producers;
                this.DropDownListProducer.DataTextField = "Name";
                this.DropDownListProducer.DataValueField = "Id";
                this.CheckBobListExtras.DataSource = this.extras;
                this.CheckBobListExtras.DataTextField = "Name";
                this.CheckBobListExtras.DataValueField = "Id";
                this.RadioButtonListEngineType.DataSource = this.engineType;
                this.RadioButtonListEngineType.DataTextField = "Name";
                this.RadioButtonListEngineType.DataValueField = "Id";
                Page.DataBind();
                this.DropDownListProducer.Items.Insert(0, string.Empty);
            }
        }

        protected void DropDownListProducer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DropDownListModel.Items.Clear();
            if (this.DropDownListProducer.SelectedIndex > 0)
            {
                int selected = int.Parse(this.DropDownListProducer.SelectedValue);
                ICollection<Model> models;
                var producer = (from pr in producers
                                where (pr.Id == selected)
                                select (pr)).FirstOrDefault();
                this.DropDownListModel.DataSource = producer.Models;
                this.DropDownListModel.DataTextField = "Name";
                this.DropDownListModel.DataValueField = "Id";
                this.DropDownListModel.DataBind();
                this.DropDownListModel.Items.Insert(0, string.Empty);
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder resultSelection = new StringBuilder();
            resultSelection.Append("<b>Result of your selection: </b><br />");
            resultSelection.Append(
                                   "<b> Producer: </b>" +
                                   Server.HtmlEncode(
                                       this.DropDownListProducer.SelectedItem != null ? this.DropDownListProducer.SelectedItem.Text : string.Empty) +
                                   "<br />");
            resultSelection.Append(
                                   "<b> Model: </b>" +
                                   Server.HtmlEncode(this.DropDownListModel.SelectedItem != null ? this.DropDownListModel.SelectedItem.Text : string.Empty) +
                                   "<br />");
            resultSelection.Append("<b> Extras: </b>");
            
            List<string> extras = new List<string>();
            foreach (ListItem item in this.CheckBobListExtras.Items)
            {
                if (item.Selected)
                {
                    resultSelection.Append(item.Text + "</br>");
                    resultSelection.Append("<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</b>");
                }
            }
            resultSelection.Append("<br /><b> Type Of Engine: </b>" +
                                   Server.HtmlEncode(this.RadioButtonListEngineType.SelectedItem != null ? 
                                   this.RadioButtonListEngineType.SelectedItem.Text : string.Empty) +
                                   "<br />");

            this.Result.Text = resultSelection.ToString();
        }
    }
}