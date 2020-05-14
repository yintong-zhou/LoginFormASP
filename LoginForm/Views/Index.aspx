<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="LoginForm.Views.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div class="text-center">
            <h3 class="display-4">
                Hello: 
                <asp:Label id="logged_user" runat="server"></asp:Label>
            </h3>
        </div>
    </div>
</asp:Content>
