<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebbsidaFotograf.Pages.Contact" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Kontakta mig</h2>
    <p>Här kan du fylla i formuläret om du har någon fråga angående användning av mina bilder, anlita mig för att fotografera eller vilken fråga som helst.</p>

    <p>Namn</p>
        <asp:TextBox ID="Namn" runat="server"></asp:TextBox>
    <p>E-post</p>
        <asp:TextBox ID="Epost" runat="server"></asp:TextBox>
    <p>Telefon</p>
        <asp:TextBox ID="Telefon" runat="server"></asp:TextBox>
    <p>Meddelande</p>
        <asp:TextBox ID="Meddelande" runat="server" TextMode="MultiLine"></asp:TextBox>
    <p>
        <asp:Button ID="SendButton" runat="server" Text="Skicka" />
    </p>
</asp:Content>