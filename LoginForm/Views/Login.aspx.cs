using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Caching;
using System.Data;

namespace LoginForm.Views
{
    public partial class Login : Page
    {
        PostGreSQL sql = new PostGreSQL();
        Cryptography crypto = new Cryptography();
        Helper helper = new Helper();
        DatabaseInfo dbInfo = new DatabaseInfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SessionID"] != null)
                Response.Redirect("/views/index", false);
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            //creating connection string for db
            string connString = dbInfo.connString();

            try
            {
                //db connection
                sql.ConnectDB(connString);
            }
            catch (Exception ex)
            {
                helper.ExceptionWriter(ex.Message, ex.StackTrace);
            }

            //encrypt input password to db check
            string _password = crypto.EncryptText(lbl_password.Text);
            string userStatus = string.Empty;
            DataTable user = sql.SelectUser(lbl_username.Text, _password);

            if (user.Rows.Count > 0)
                userStatus = user.Rows[0][0].ToString();
            else userStatus = null;

            if(userStatus != null && userStatus == "valid")
            {
                Session["Username"] = lbl_username.Text;
                Session["SessionID"] = Session.SessionID.ToString();
                sql.DisconnectDB();
                Response.Redirect("/views/index", false);
            }
            else if(userStatus == "blocked")
            {
                lbl_message.Text = $"User {lbl_username.Text} is blocked.";
            }
            else
            {
                lbl_message.Text = $"Credentials entered are incorrect.";
            }

            sql.DisconnectDB();
        }
    }
}