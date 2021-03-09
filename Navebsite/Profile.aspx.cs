using System;
using System.Collections.Generic;
using System.Linq;
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
                    Response.Redirect("Login.aspx");
                    return;
                }
            }
            else
            {
                user = new User(id);
            }

            activities.Activities = user.Activities;
            gallery.Photos = UserPhoto.GetPhotosByUser(user.Id).Cast<Photo>().ToList();

            var list = Review.ReviewsByUser(user.Id);
            foreach (var review in list)
            {
                var reviewControl = (Controls.Review)Page.LoadControl("~/Controls/Review.ascx");
                reviewControl.ReviewObject = review;
                reviewControl.ID = "" + review.UserId;
                reviewList.Controls.Add(reviewControl);
            }

            friends.Users = Connections.GetFriends(user.Id);

            mutualFriends.Users = new List<User>();
            

            if (IsPostBack) return;
            banner.ImageUrl = user.BackgroundUrl;
            icon.ImageUrl = user.ProfilePictureUrl;

            name.Text = Server.HtmlEncode(user.Username);
            ProfileBio.Text = Server.HtmlEncode(user.Description);
            if (Session["user"] == null) return;
            var viewer = (User) Session["user"];


            if (viewer.Id == user.Id)
            {
                AddButton.Visible = false;
                RemoveButton.Visible = false;
                InviteToCompany.Visible = false;
                return;
            }
            else
            {
                mutualFriends.Users = Connections.GetMutualFriends(user.Id, viewer.Id);
                mutualFriends.Visible = true;
            }
            

            var areFriends = Connections.AreFriends(viewer, user);
            
            if (areFriends)
            {
                AddButton.Visible = false;
            }
            else
            {
                if (Connections.ExistsFriendRequest(user, viewer))
                {
                    AddButton.Text = "Accept Friend Request";
                    RemoveButton.Text = "Deny Friend Request";
                }
                else if (Connections.ExistsFriendRequest(viewer, user))
                {
                    AddButton.Enabled = false;
                    AddButton.Text = "Requested";
                }

                RemoveButton.Visible = false;
            }

            if (Session["dev"] == null) return;

            var dev = (Developer)Session["dev"];

            if (user.DeveloperId == dev.Id) return;


            InviteToCompany.Visible = true;
            if (Connections.ExistsDeveloperRequest(dev.Id, user.Id))
            {
                InviteToCompany.Enabled = false;
                InviteToCompany.Text = "Requested to develop";
            }
        }

        protected void RemoveButton_OnClick(object sender, EventArgs e)
        {
            if (Session["user"] == null) return;
            var viewer = (User) Session["user"];

            Connections.RemoveFriend(viewer.Id, user.Id);
            AddButton.Visible = true;
            RemoveButton.Visible = false;
        }

        protected void AddButton_OnClick(object sender, EventArgs e)
        {
            if (Session["user"] == null) return;
            var viewer = (User) Session["user"];

            Connections.SendFriendRequest(viewer.Id, user.Id);
            Response.Redirect($"Profile.aspx?id={user.Id}");
        }

        protected void InviteToCompany_OnClick_OnClick(object sender, EventArgs e)
        {
            if (Session["user"] == null) return;

            if (Session["dev"] == null) return;

            var dev = (Developer) Session["dev"];

            if (user.IsDeveloper && user.DeveloperId == dev.Id) return;

            Connections.SendDeveloperInvite(user.Id, dev.Id);

            Response.Redirect($"Profile.aspx?id={user.Id}");

        }
    }
}