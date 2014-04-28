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

        <asp:Literal ID="DescriptionLiteral" runat="server"></asp:Literal>
        
         <%--<asp:ListView ID="DescListView" runat="server" 
            ItemType="WebbsidaFotograf.Model.ImageProps" 
            SelectMethod="DescListView_GetData">
            <LayoutTemplate>
                <div class="descTable">
                    <table>
                        <tr>
                            <td>
                                ImageID
                            </td>
                            <td>
                                ImageName
                            </td>
                            <td>
                                Description
                            </td>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%#: Item.ImageID %>
                    </td>
                    <td>
                        <asp:ImageButton ID="Image1" runat="server" ImageUrl='<%# "~/Content/GalleryThumbs/" + Item.ImageName %>' OnClick="Image1_Click"/>  
                        <%#: Item.ImageName %>
                    </td>
                    <td>
                        <%#: Item.Description %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>--%>

        <asp:Image ID="BigImage" runat="server"/>
        <br />
        <asp:LinkButton ID="ShowTags" runat="server" CausesValidation="True" OnClick="ShowTags_Click">Visa taggar</asp:LinkButton>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
        <asp:Label ID="ImageTags" runat="server" Visible="true" Text="Här kommer taggarna ligga!"></asp:Label>
        </asp:PlaceHolder>
    <br />

    </p>

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
