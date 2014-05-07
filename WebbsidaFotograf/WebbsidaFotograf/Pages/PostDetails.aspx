<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="PostDetails.aspx.cs" Inherits="WebbsidaFotograf.Pages.PostDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" runat="server">

    <asp:ListView ID="ListView2" runat="server"
            ItemType="WebbsidaFotograf.Model.Blog"
            SelectMethod="ListView2_GetData"
            UpdateMethod="ListView2_UpdateItem">

            <ItemTemplate>
                <table class="BlogTable">
                <tr>
                    <td>
                        <h2><%#: Item.Title %></h2>
                        <br />
                        <%#: Item.Post %>
                        <br />
                        <h5><%#: Item.Date %></h5>
                        <asp:LinkButton ID="DeletePost" runat="server" OnClick="Delete_Click">Ta bort</asp:LinkButton>
                        <asp:LinkButton ID="UpdatePost" runat="server" OnClick="UpdatePost_Click">Redigera</asp:LinkButton>
                    </td>
                    
                </tr>
                    </table>
            </ItemTemplate>
        </asp:ListView>
        
    <asp:FormView ID="UpdatePostFormView" runat="server"         
        ItemType="WebbsidaFotograf.Model.Blog" 
        DefaultMode="Edit" 
        UpdateMethod="BlogPostFormView_UpdateItem" 
        DataKeyNames="BlogPostID" 
        SelectMethod="BlogPostFormView_GetItem">
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox ID="EditTitleTextBox" runat="server" Text='<%# BindItem.Title %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="PostTextBox" runat="server" Text='<%# BindItem.Post %>' TextMode="MultiLine" Rows="5"></asp:TextBox>
                </td>
                <asp:LinkButton ID="SaveButton" runat="server" CommandName="Update">Spara</asp:LinkButton>
            </tr>
        </EditItemTemplate>
    </asp:FormView>
    <%-- Hämta något med hjälp av ett inskickat id --%>
    <div id="fbdiv" class="fb-comments" runat="server" data-href="http://localhost:2257/Pages/PostDetails.aspx?Id=" data-numposts="5" data-colorscheme="light"></div>
</asp:Content>
