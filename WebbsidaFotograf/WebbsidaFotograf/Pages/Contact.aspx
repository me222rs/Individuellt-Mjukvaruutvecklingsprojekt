<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebbsidaFotograf.Pages.Contact" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Kontakta mig</h2>
    <p>Här kan du fylla i formuläret om du har någon fråga angående användning av mina bilder, anlita mig för att fotografera eller vilken fråga som helst.</p>
    
    <p>Amne</p>
    <asp:TextBox ID="Amne" runat="server"></asp:TextBox>
    <p>Namn</p>
        <asp:TextBox ID="Namn" runat="server"></asp:TextBox>
    <p>E-post</p>
        <asp:TextBox ID="Epost" runat="server" TextMode="Email"></asp:TextBox>
    <p>Meddelande</p>
        <asp:TextBox ID="Meddelande" runat="server" TextMode="MultiLine"></asp:TextBox>
    <p>
        <asp:Button ID="SendButton" runat="server" Text="Skicka" OnClick="SendButton_Click" />
    </p>

    <asp:FileUpload ID="FileUpload1" runat="server" />

    <asp:Label ID="Success" runat="server" Text=""></asp:Label>
</asp:Content>