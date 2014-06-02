<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Landscape.aspx.cs" Inherits="WebbsidaFotograf.Pages.CategoryPages.Landscape" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:FileUpload ID="FileUpload" runat="server" />
        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
<br />
    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
</asp:Content>