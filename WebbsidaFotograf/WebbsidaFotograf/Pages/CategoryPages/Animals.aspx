<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Animals.aspx.cs" Inherits="WebbsidaFotograf.Pages.CategoryPages.Animals" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
    <p>Ladda upp en bild i denna kategorin.</p>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:RequiredFieldValidator ID="UploadValidator" runat="server" ErrorMessage="Du måste välja en bild att ladda upp!" ControlToValidate="FileUpload1" Display="Dynamic"></asp:RequiredFieldValidator>
    
    <asp:Button ID="Upload" runat="server" Text="Ladda upp" OnClick="Upload_Click"/>
    <p><asp:Label ID="Success" runat="server" Text=""></asp:Label></p>
        </asp:PlaceHolder>
    <p>
        
        <asp:Image ID="BigImage" runat="server"/>
        <asp:LinkButton ID="Delete" runat="server" OnClick="Delete_Click" CausesValidation="False">Radera</asp:LinkButton>
    </p>
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
