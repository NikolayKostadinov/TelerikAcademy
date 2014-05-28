using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebChat
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            string messageText = this.TextBoxMessage.Text;
            var message = new Message()
            {
                MessageDateTime = DateTime.Now,
                MessageText = messageText
            };

            var messageRepository = new MessageRepository();
            messageRepository.Insert(message);
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            this.ObjectDataSource1.DataBind();
            this.ListViewMessages.DataBind();
        }
    }
}