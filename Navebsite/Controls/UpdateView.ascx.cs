using System;
using System.Web.UI;
using Markdig;
using NavebsiteBL;

namespace Navebsite.Controls
{
    public partial class UpdateView : UserControl
    {
        public Update Update { get; set; }
        public bool Minified { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title.Text = Update.UpdateName;
            Version.Text = Update.UpdateVersion;
            Date.Text = Update.Timestamp.ToShortDateString();

            Content.Text = Markdown.ToHtml(Update.UpdateDescription);
        }
    }
}