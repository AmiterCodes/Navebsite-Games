using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Navebsite.App_Code
{
    public class UploadHelper
    {

        public static string ImageFileUpload(FileUpload fileUpload, string path, string def, HttpServerUtility Server)
        {
            string output;
            if (fileUpload.HasFile)
            {
                output = Server.MapPath("~/" + path +
                                        Path.ChangeExtension(Path.GetRandomFileName(),
                                            Path.GetExtension(fileUpload.FileName)));
                fileUpload.SaveAs(output);
            }
            else
            {
                output = Server.MapPath("~/" + path + def);
            }

            return new FileInfo(output).Name;
        }
    }
}