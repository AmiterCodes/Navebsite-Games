using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Navebsite.App_Code
{
    public class SnackbarHelper
    {
        public static void DisplaySnackBar(Page page, string text)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "show" + text.Replace(" ",""), 
                $"Snackbar.show({{ pos: 'top-center', text: '{text}', showAction: false }})", true);
        }
    }
}