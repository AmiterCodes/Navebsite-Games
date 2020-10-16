using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class UpdateList : UserControl
    {

        public List<Update> Updates;


        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater.DataSource = Updates;
            Repeater.DataBind();
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Update update = (Update) e.Item.DataItem;
            ((UpdateView) e.Item.FindControl("UpdateView")).Update = update;
        }
    }
}