﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="KMBlog.login"
    MasterPageFile="~/KMBlog.Master" Title="Administrative Login" %>

<asp:Content ID="default" ContentPlaceHolderID="body" runat="server">
    <form id="form1" runat="server">
        <div id="maindiv">
            <h1 id="header">
                <a href="/">Key Mapper Blog Admin Login</a></h1>
        </div>
        <asp:Login ID="KMLogin" runat="server" onauthenticate="Login1_Authenticate">
        </asp:Login>
    </form>
</asp:Content>