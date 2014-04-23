using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using WebChat.Models;

namespace WebChat
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect(@"~\Account\Login.aspx");
            }
        }

        /// <summary>
        /// Prepares the grid.
        /// </summary>

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            var controll = this.ListViewMessages.InsertItem;

            var newMessage = GetItemDataAsMessageObject(controll);

            var repository = new Repositories.MessagesRepository();
            repository.AddNew(newMessage);
            Page.DataBind();
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            var controll = this.ListViewMessages.EditItem;
            var newMessage = GetItemDataAsMessageObject(controll);

            var repository = new Repositories.MessagesRepository();
            repository.Update(newMessage);
            this.ListViewMessages.EditIndex = -1;
            Page.DataBind();
        }

        private ChatMessage GetItemDataAsMessageObject(ListViewItem controll)
        {
            var idBox = controll.FindControl("MessageIdTextBox") as TextBox;
            var messageBox = controll.FindControl("MessageTextBox") as TextBox;

            var newMessage = new ChatMessage()
            {
                MessageId = idBox != null ? int.Parse(idBox.Text) : 0,
                MessageText = messageBox.Text,
                MessageDateTime = DateTime.Now,
                UserId = Context.User.Identity.GetUserId(),
            };
            return newMessage;
        }

        protected void ListViewMessages_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var userId = User.Identity.GetUserId();

            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.Find(userId);

                Button editButton = e.Item.FindControl("EditButton") as Button;
                Button deleteButton = e.Item.FindControl("DeleteButton") as Button;

                if (editButton!=null)
                {
                    editButton.Visible = User.IsInRole("Moderator") || User.IsInRole("Administrator");
                }
                
                if(deleteButton!=null)
                {
                    deleteButton.Visible = User.IsInRole("Administrator");   
                }
            }

        }
    }
}