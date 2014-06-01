<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebbsidaFotograf.Pages.Contact" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2>Kontakta mig</h2>
    <p>Här kan du fylla i formuläret om du har någon fråga angående användning av mina bilder, anlita mig för att fotografera eller vilken fråga som helst.</p>
    
    <p>Ämne</p>
    <asp:TextBox ID="Amne" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="SubjectRequiredFieldValidator" runat="server" ErrorMessage="Du måste ange ett ämne." ControlToValidate="Amne" Display="Dynamic"></asp:RequiredFieldValidator>

    <p>Namn</p>
    <asp:TextBox ID="Namn" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" ErrorMessage="Du måste ange ett namn." ControlToValidate="Namn" Display="Dynamic"></asp:RequiredFieldValidator>

    <p>E-post</p>
        <asp:TextBox ID="Epost" runat="server" TextMode="Email"></asp:TextBox>
    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="Du måste ange en e-post adress." ControlToValidate="Epost" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="E-postadressen är inte giltig." ControlToValidate="Epost" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$" Display="Dynamic"></asp:RegularExpressionValidator>

    <p>Meddelande</p>
        <asp:TextBox ID="Meddelande" runat="server" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ID="MessageRequiredFieldValidator" runat="server" ErrorMessage="Du måste skriva ett meddelande" ControlToValidate="Meddelande" Display="Dynamic"></asp:RequiredFieldValidator>
    <p>
        <asp:Button ID="SendButton" runat="server" Text="Skicka" OnClick="SendButton_Click" />
    </p>

    <asp:FileUpload ID="FileUpload1" runat="server" />

    <asp:Label ID="Success" runat="server" Text=""></asp:Label>
</asp:Content>