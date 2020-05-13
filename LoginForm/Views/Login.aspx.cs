using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Caching;

namespace LoginForm.Views
{
    public partial class Login : Page
    {
        PostGreSQL sql = new PostGreSQL();
        Cryptography crypto = new Cryptography();
        Helper helper = new Helper();

        string connStringSQL = "Server={0};Username={1};Database={2};Port={3};Password={4};";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SessionID"] != null)
                Response.Redirect("/views/home", false);

            if (!IsPostBack)
            {
                //loading web config fields
                helper.LoadConfigFILE();
                //decrypt password from web config
                string _pwd = crypto.DecryptText(helper.db_pwd);
                //creating connection string for db
                connStringSQL = string.Format(connStringSQL, helper.db_ip, helper.db_username, helper.db_name, helper.db_port, _pwd);
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                //db connection
                sql.ConnectDB(connStringSQL);
            }
            catch (Exception ex)
            {
                //write exception
                helper.ExceptionWriter(ex.Message, ex.StackTrace);
            }

            Session["Username"] = lbl_username.Text;
            Session["SessionID"] = Session.SessionID.ToString();
            Response.Redirect("/views/index", false);
        }
    }
}