<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="WebbsidaFotograf.Pages.Gallery" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Kategorier</h2>
    <div id="CategoryLinks">
        <asp:HyperLink ID="Landscape" class="CategoryLink" runat="server" NavigateUrl="~/Pages/CategoryPages/Animals.aspx?name=hej&Category=Landscape">Landscape</asp:HyperLink>
        <asp:HyperLink ID="Animals" class="CategoryLink" runat="server" NavigateUrl="~/Pages/CategoryPages/Animals.aspx?name=hej&Category=Gallery">Animals</asp:HyperLink>
        <asp:HyperLink ID="Portraits" class="CategoryLink" runat="server" NavigateUrl="~/Pages/CategoryPages/Animals.aspx?name=hej&Category=Portrait">Portrait</asp:HyperLink>
        <asp:HyperLink ID="Macro" class="CategoryLink" runat="server" NavigateUrl="~/Pages/CategoryPages/Animals.aspx?name=hej&Category=Macro">Macro</asp:HyperLink>
        
        
        <asp:HyperLink ID="Other" class="CategoryLink" runat="server" NavigateUrl="~/Pages/CategoryPages/Other.aspx?Category=Other">Other</asp:HyperLink>
    
    </div>
</asp:Content>