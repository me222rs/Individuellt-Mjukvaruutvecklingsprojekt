<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="WebbsidaFotograf.Pages.Gallery" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Kategorier</h2>
    <asp:HyperLink ID="Landscape" runat="server" NavigateUrl="~/Pages/CategoryPages/Landscape.aspx">Landscape</asp:HyperLink>
    <asp:HyperLink ID="Animals" runat="server" NavigateUrl="~/Pages/CategoryPages/Animals.aspx">Animals</asp:HyperLink>
    <asp:HyperLink ID="Other" runat="server" NavigateUrl="~/Pages/CategoryPages/Other.aspx">Other</asp:HyperLink>
</asp:Content>