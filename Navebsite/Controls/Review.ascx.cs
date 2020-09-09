using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class Review : System.Web.UI.UserControl
    {
        public NavebsiteBL.Review review;
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++) {

                Image image = new Image();
                image.ImageUrl = "./starfilled.svg";
                if (i >= review.Stars)
                {
                    image.ImageUrl = "./starempty.svg";
                }
                stars.Controls.Add(image);
            }
            content.Text = review.Content;
            title.Text = "Review";
        }
    }
}