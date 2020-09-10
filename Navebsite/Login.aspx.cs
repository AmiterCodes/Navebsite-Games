﻿using NavebsiteBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navebsite
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["user"] != null) 
                Response.Redirect("Store");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Validate();
            if (IsValid)
            {
                string userName = username.Text;
                string pass = password.Text;
 
                User user = NavebsiteBL.User.AuthUser(userName, pass);
                if (user == null)
                {
                    errorBox.Text = "Login did not work";
                }
                else
                {
                    Session["user"] = user;
                    if(user.IsDeveloper)
                    {
                        Session["dev"] = new Developer(user.DeveloperId);
                    }
                    if(user.IsAdmin)
                    {
                        Session["admin"] = true;
                    }
                    Response.Redirect("Profile.aspx?id=" + user.Id);
                }
            }
        }
    }
}