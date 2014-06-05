<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="WebbsidaFotograf.Pages.Gallery" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="CategoryContent">
    <h2>Kategorier</h2>
    <div id="CategoryLinks">
        <asp:HyperLink ID="Landscape" class="CategoryLink" runat="server" ImageUrl="~/Content/CategoryImage/Landskap.png" NavigateUrl="~/Pages/CategoryPages/Animals.aspx?name=Landskap&Category=Landscape">Landscape</asp:HyperLink>
        <asp:HyperLink ID="Animals" class="CategoryLink" runat="server" ImageUrl="~/Content/CategoryImage/Djur.png" NavigateUrl="~/Pages/CategoryPages/Animals.aspx?name=Djur&Category=Gallery">Animals</asp:HyperLink>
        <asp:HyperLink ID="Portraits" class="CategoryLink" ImageUrl="~/Content/CategoryImage/Porträtt.png" runat="server" NavigateUrl="~/Pages/CategoryPages/Animals.aspx?name=Porträtt&Category=Portrait">Portrait</asp:HyperLink>
        <asp:HyperLink ID="Macro" class="CategoryLink" ImageUrl="~/Content/CategoryImage/Macro.png" runat="server" NavigateUrl="~/Pages/CategoryPages/Animals.aspx?name=Macro&Category=Macro">Macro</asp:HyperLink>
        
        
        
    
    </div>
        </div>
</asp:Content>