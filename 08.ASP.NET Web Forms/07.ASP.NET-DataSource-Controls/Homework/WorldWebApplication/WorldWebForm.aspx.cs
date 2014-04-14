using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WorldWebApplication
{
    public partial class WorldWebForm : System.Web.UI.Page
    {
        public void GridViewCountries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                this.GridViewCountries.SelectedIndex = int.Parse(e.CommandArgument.ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.ListViewTowns.InsertItemPosition == InsertItemPosition.LastItem)
            {
                this.ListViewTowns.InsertItemPosition = InsertItemPosition.None;
            }
        }

        protected void btnInsertRecord_Click(object sender, EventArgs e)
        {
            this.ListViewTowns.InsertItemPosition = InsertItemPosition.LastItem;
        }
    }
}