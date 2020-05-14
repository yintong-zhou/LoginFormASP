using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginForm
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_logo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/views/index", false);
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["SessionID"] = null;
            Response.Redirect("/views/login", false);
        }
    }
}