using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite
{
    public partial class RequestsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Update();
        }

        public void Update()
        {
            if (Session["user"] == null) Response.Redirect("404.aspx");

            var user = (User)Session["user"];

            List<User> incomingFriends = Connections.IncomingFriendRequests(user.Id);
            List<User> outgoingFriends = Connections.OutgoingFriendRequests(user.Id);
            List<Developer> incomingDeveloper = Connections.IncomingDeveloperRequests(user.Id);

            IncomingFriendRequests.DataSource = incomingFriends;
            OutgoingFriendRequests.DataSource = outgoingFriends;
            IncomingDeveloperRequests.DataSource = incomingDeveloper;


            IncomingFriendRequests.DataBind();
            OutgoingFriendRequests.DataBind();
            IncomingDeveloperRequests.DataBind();

            if (Session["dev"] == null) return;

            var dev = (Developer)Session["dev"];

            OutgoingDeveloperRequests.Visible = true;

            List<User> outgoingDeveloper = Connections.OutgoingDeveloperRequests(dev.Id);

            OutgoingDeveloperRequests.DataSource = outgoingDeveloper;

            OutgoingDeveloperRequests.DataBind();
        }

        protected void IncomingFriendRequests_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            var user = (User)Session["user"];

            var row = Convert.ToInt32(e.CommandArgument);
            var user2 = ((List<User>)IncomingFriendRequests.DataSource)[row];


            switch (e.CommandName)
            {
                case "Accept":
                    Connections.SendFriendRequest(user.Id, user2.Id);
                    break;
                case "Deny":
                    Connections.RemoveFriend(user.Id, user2.Id);
                    break;
            }
            Response.Redirect("RequestsPage.aspx");
        }

        protected void OutgoingFriendRequests_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Cancel") return;
            var user = (User) Session["user"];
            var row = Convert.ToInt32(e.CommandArgument);

            var user2 = ((List<User>) OutgoingFriendRequests.DataSource)[row];

            Connections.RemoveFriend(user.Id, user2.Id);

            Response.Redirect("RequestsPage.aspx");
        }

        protected void IncomingDeveloperRequests_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var user = (User)Session["user"];

            var row = Convert.ToInt32(e.CommandArgument);

            var dev = ((List<Developer>)IncomingDeveloperRequests.DataSource)[row];

            switch (e.CommandName)
            {
                case "Accept":
                {
                    Connections.FulfillRequest(user.Id, dev);
                    Session["dev"] = dev;
                    break;
                }
                case "Deny":
                    Connections.DenyRequest(user.Id, dev.Id);
                    break;
            }

            Response.Redirect("RequestsPage.aspx");
        }

        protected void OutgoingDeveloperRequests_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "Cancel") return;
            var dev = (User)Session["dev"];
            var row = Convert.ToInt32(e.CommandArgument);
            var user2 = ((List<User>)OutgoingDeveloperRequests.DataSource)[row];

            Connections.DenyRequest(user2.Id, dev.Id);

            Response.Redirect("RequestsPage.aspx");
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var item = (User) e.Row.DataItem;
            var row = e.Row;
            var hyperlink = (HyperLink) row.Cells[1].Controls[0];
            
            hyperlink.NavigateUrl = "Profile.aspx?id=" + item.Id;
        }

        protected void IncomingDeveloperRequests_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var item = (Developer) e.Row.DataItem;
            var row = e.Row;
            var hyperlink = (HyperLink) row.Cells[1].Controls[0];
            hyperlink.NavigateUrl = "CompanyPage.aspx?dev=" + item.Id;
        }
    }
}