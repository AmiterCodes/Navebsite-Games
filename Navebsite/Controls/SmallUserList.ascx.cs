using NavebsiteBL;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Navebsite.Controls
{
    public partial class SmallUserList : System.Web.UI.UserControl
    {
        public List<User> Users;
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach(var user in Users)
            {
                var link = new HyperLink {CssClass = "user", NavigateUrl = "../Profile.aspx?id=" + user.Id};
                var caption = new Label {CssClass = "user_caption"};
                var image = new Image {CssClass = "user_img", ImageUrl = "../" + user.ProfilePictureUrl};

                caption.Text = Server.HtmlEncode(user.Username);

                link.Controls.Add(caption);
                link.Controls.Add(image);
                userList.Controls.Add(link);
            }
        }
    }
}