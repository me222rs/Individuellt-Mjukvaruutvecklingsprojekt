<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="UpdatePost.aspx.cs" Inherits="WebbsidaFotograf.Pages.UpdatePost" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <asp:FormView ID="BlogPostFormView" 
        runat="server" 
        ItemType="WebbsidaFotograf.Model.Blog" 
        DefaultMode="Edit" 
        UpdateMethod="BlogPostFormView_UpdateItem" 
        DataKeyNames="PostID" 
        SelectMethod="BlogPostFormView_GetItem">

        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox ID="EditTitleTextBox" runat="server" Text='<%# BindItem.Title %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="PostTextBox" runat="server" Text='<%# BindItem.Post %>' TextMode="MultiLine" Rows="5"></asp:TextBox>
                </td>
            </tr>
        </EditItemTemplate>
    </asp:FormView>
</asp:Content>
