using System;
using System.Web.UI;
using NavebsiteBL;

namespace Navebsite
{
    public partial class Profile : Page
    {
        protected User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            var qs = Request.QueryString["id"];

            if (qs == null || !int.TryParse(qs, out var id))
            {
                if (Session["user"] != null)
                {
                    user = (User) Session["user"];
                }
                else
                {
                    Response.Redirect("404.aspx");
                    return;
                }
            }
            else
            {
                user = new User(id);
            }

            activities.Activities = user.Activities;
            friends.Users = Friends.GetFriends(user.Id);

            if (IsPostBack) return;
            banner.ImageUrl = user.BackgroundUrl;
            icon.ImageUrl = user.ProfilePictureUrl;

            name.Text = Server.HtmlEncode(user.Username);
            if (Session["user"] == null) return;
            var viewer = (User) Session["user"];

            if (viewer.Id == user.Id)
            {
                AddButton.Visible = false;
                RemoveButton.Visible = false;
                return;
            }

            var areFriends = Friends.AreFriends(viewer, user);
            if (areFriends)
            {
                AddButton.Visible = false;
            }
            else
            {
                if (Friends.ExistsFriendRequest(user, viewer))
                {
                    AddButton.Text = "Accept Friend Request";
                }
                else if (Friends.ExistsFriendRequest(viewer, user))
                {
                    AddButton.Enabled = false;
                    AddButton.Text = "Requested";
                }

                RemoveButton.Visible = false;
            }
        }

        protected void RemoveButton_OnClick(object sender, EventArgs e)
        {
            if (Session["user"] == null) return;
            var viewer = (User) Session["user"];

            Friends.RemoveFriend(viewer.Id, user.Id);
            AddButton.Visible = true;
            RemoveButton.Visible = false;
        }

        protected void AddButton_OnClick(object sender, EventArgs e)
        {
            if (Session["user"] == null) return;
            var viewer = (User) Session["user"];

            Friends.SendFriendRequest(viewer.Id, user.Id);
            AddButton.Enabled = false;
            AddButton.Text = "Requested";
        }
    }
}