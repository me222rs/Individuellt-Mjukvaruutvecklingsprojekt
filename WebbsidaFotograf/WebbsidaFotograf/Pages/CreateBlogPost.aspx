﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CreateBlogPost.aspx.cs" Inherits="WebbsidaFotograf.Pages.CreateBlogPost" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Titel"></asp:Label>
    <asp:TextBox ID="BlogTitle" runat="server"></asp:TextBox>
    <br />
    <asp:TextBox ID="BlogContent" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
    <asp:Button ID="Post" runat="server" Text="Posta" OnClick="Post_Click"/>
</asp:Content>