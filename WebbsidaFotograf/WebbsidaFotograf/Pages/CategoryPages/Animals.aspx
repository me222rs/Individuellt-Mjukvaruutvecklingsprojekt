<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Animals.aspx.cs" Inherits="WebbsidaFotograf.Pages.CategoryPages.Animals" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:Label ID="SearchLabel" runat="server" Text="Sök efter bild"></asp:Label>
    <asp:TextBox ID="SearchTextBox" runat="server"></asp:TextBox>

    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
    <p>Ladda upp en bild i denna kategorin.</p>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:RequiredFieldValidator ID="UploadValidator" runat="server" ErrorMessage="Du måste välja en bild att ladda upp!" ControlToValidate="FileUpload1" Display="Dynamic"></asp:RequiredFieldValidator>


    <asp:Button ID="Upload" runat="server" Text="Ladda upp" OnClick="Upload_Click"/>

<br />
    <asp:Label ID="DescriptionLabel" runat="server" Text="Beskrivning"></asp:Label>
    <asp:TextBox ID="DescriptionTextBox" runat="server" MaxLength="200"></asp:TextBox>
        <asp:RequiredFieldValidator ID="DescriptionTextBoxRequiredFieldValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="DescriptionTextBox"></asp:RequiredFieldValidator>
    
<br />
    <asp:Label ID="TagLabel" runat="server" Text="Lägg till taggar, separera varje tagg med ,"></asp:Label>
    <asp:TextBox ID="TagTextBox" runat="server" MaxLength="200"></asp:TextBox>


    <p><asp:Label ID="Success" runat="server" Text=""></asp:Label></p>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Delete_Click" CausesValidation="False">Radera</asp:LinkButton>
        <br />
        <asp:LinkButton ID="UpdateDescription" runat="server" OnClick="UpdateDescription_Click" CausesValidation="false">Uppdatera Beskrivning</asp:LinkButton>
        <br />
        <asp:TextBox ID="UpdateDescriptionTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
        </asp:PlaceHolder>
    <p id="ImageInfos">
        
        <asp:Literal ID="DescriptionLiteral" runat="server"></asp:Literal>
        <br />

        </p>
        <div id="bild">
        <asp:Image ID="BigImage" runat="server"/>
        </div>
        <br />
        <asp:LinkButton ID="ShowTags" runat="server" CausesValidation="True" OnClick="ShowTags_Click">Visa taggar</asp:LinkButton>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="true">
        <asp:Label ID="ImageTags" runat="server" Visible="true" Text="Här kommer taggarna ligga!"></asp:Label>
        </asp:PlaceHolder>
    <br />




    

    <div id="fbdiv" class="fb-comments" runat="server" data-href="http://localhost:2257/Pages/CategoryPages/Animals.aspx" data-numposts="5" data-colorscheme="light"></div>
    <div id="ThumbNails">
            
        <p>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" 
                ItemType="System.String" 
                SelectMethod="Repeater1_GetData" >
                <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server"  
                           ImageUrl='<%# "~/Content/GalleryThumbs/" + Item %>'
                           NavigateUrl='<%# "?name=" + Item %>'/>
                </ItemTemplate>
            </asp:Repeater>
        </p>
        </div>
</asp:Content>
