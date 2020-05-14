using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginForm.Views
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentSessionID = HttpContext.Current.Session.SessionID.ToString();

            if(Session["SessionID"] == null)
                Response.Redirect("/views/login", false);
            else if (Session["SessionID"].ToString() == currentSessionID)
                logged_user.Text = Session["Username"].ToString();
            else Response.Redirect("/views/login", false);
        }
    }
}