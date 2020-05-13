<%@ Page Title="Login Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginForm.Views.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="loginform">
            <div>
                <p>LOGIN</p>
            </div>
            <div class="form-group">
                <asp:TextBox class="form-control" id="lbl_username" runat="server" placeholder="Username"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox Type="password" class="form-control" id="lbl_password" runat="server" placeholder="Password"></asp:TextBox>
            </div>
            <div class="form-group button-help">
                <asp:Button class="btn btn-dark" ID="btn_login" runat="server" Text="Log In" OnClick="btn_login_Click" />
            </div>
            <div class="form-group">
                <small class="form-text text-muted"><a href="#">Sign Up</a></small>
            </div>
        </div>
    </div>

</asp:Content>
