using NavebsiteBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navebsite.Controls
{
    public partial class SmallUserList : System.Web.UI.UserControl
    {
        public List<User> Users;
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach(User user in Users)
            {
                HyperLink link = new HyperLink();
                link.CssClass = "user";
                Label caption = new Label();
                caption.CssClass = "user_caption";
                Image image = new Image();
                image.CssClass = "user_img";

                image.ImageUrl = "../" + user.ProfilePictureUrl;
                link.NavigateUrl = "../Profile.aspx?id=" + user.Id;
                caption.Text = Server.HtmlEncode(user.Username);

                link.Controls.Add(caption);
                link.Controls.Add(image);
                userList.Controls.Add(link);
            }
        }
    }
}