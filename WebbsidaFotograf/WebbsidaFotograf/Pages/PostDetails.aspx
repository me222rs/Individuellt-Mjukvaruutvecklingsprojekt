<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="PostDetails.aspx.cs" Inherits="WebbsidaFotograf.Pages.PostDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <%-- Hämta något med hjälp av ett inskickat id --%>
    <div id="fbdiv" class="fb-comments" runat="server" data-href="http://localhost:2257/Pages/PostDetails.aspx?Id=" data-numposts="5" data-colorscheme="light"></div>
</asp:Content>
