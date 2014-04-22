<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebbsidaFotograf.Pages.Home" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:Label ID="loggedIn" runat="server" Text="Inloggad som admin." Visible="False"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Logga ut" CausesValidation="False" OnClick="Button1_Click" />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="AdminPages/AdminLogIn.aspx" >Logga in</asp:HyperLink>
    <div id="BlogContent">
    <h2>Blogg</h2>
    <p>Här ska några blogginlägg ligga.</p>
    
    

    </div>
    <p>Skriv gärna en kommentar och gilla sidan!</p>
    
    <a href="https://twitter.com/share" class="twitter-share-button" data-url="http://localhost:2257/Pages/Home.aspx">Tweet</a>
    <div class="fb-like" data-href="http://localhost:2257/Pages/About.aspx" data-layout="standard" data-action="like" data-show-faces="true" data-share="true"></div>
    <div>
    <div class="fb-comments" data-href="http://localhost:2257/Pages/Home.aspx" data-numposts="5" data-colorscheme="light"></div>
    </div>
</asp:Content>
