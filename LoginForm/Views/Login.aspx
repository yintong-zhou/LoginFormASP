<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginForm.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="../Content/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="../Content/style/Login.css">
    <title>Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="loginform">
                <div>
                    <p>LOGIN</p>
                </div>
                <div class="form-group">
                    <asp:TextBox class="form-control" ID="lbl_username" runat="server" placeholder="Username"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox Type="password" class="form-control" ID="lbl_password" runat="server" placeholder="Password"></asp:TextBox>
                </div>
                <div class="form-group button-help">
                    <asp:Button class="btn btn-dark" ID="btn_login" runat="server" Text="Log In" OnClick="btn_login_Click" />
                </div>
                <div class="form-group text-message">
                    <asp:Label class="form-text" ID="lbl_message" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
