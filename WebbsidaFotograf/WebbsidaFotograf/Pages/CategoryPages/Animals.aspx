<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Animals.aspx.cs" Inherits="WebbsidaFotograf.Pages.CategoryPages.Animals" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
    <p>Ladda upp en bild i denna kategorin.</p>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:RequiredFieldValidator ID="UploadValidator" runat="server" ErrorMessage="Du måste välja en bild att ladda upp!" ControlToValidate="FileUpload1" Display="Dynamic"></asp:RequiredFieldValidator>


    <asp:Button ID="Upload" runat="server" Text="Ladda upp" OnClick="Upload_Click"/>

<br />
    <asp:Label ID="DescriptionLabel" runat="server" Text="Beskrivning"></asp:Label>
    <asp:TextBox ID="DescriptionTextBox" runat="server"></asp:TextBox>
<br />
    <asp:Label ID="TagLabel" runat="server" Text="Taggar"></asp:Label>
    <asp:TextBox ID="TagTextBox" runat="server"></asp:TextBox>


    <p><asp:Label ID="Success" runat="server" Text=""></asp:Label></p>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Delete_Click" CausesValidation="False">Radera</asp:LinkButton>
        </asp:PlaceHolder>
    <p>
        
        <asp:Image ID="BigImage" runat="server"/>

    <br />

    </p>
    <div id="fbdiv" class="fb-comments" runat="server" data-href="http://localhost:2257/Pages/CategoryPages/Animals.aspx" data-numposts="5" data-colorscheme="light"></div>
    <div id="ThumbNails">
            
        <p>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" ItemType="System.String" SelectMethod="Repeater1_GetData" >
                <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server"  
                           ImageUrl='<%# "~/Content/GalleryThumbs/" + Item %>'
                           NavigateUrl='<%# "?name=" + Item %>'/>
                </ItemTemplate>
            </asp:Repeater>
        </p>
        </div>
</asp:Content>
