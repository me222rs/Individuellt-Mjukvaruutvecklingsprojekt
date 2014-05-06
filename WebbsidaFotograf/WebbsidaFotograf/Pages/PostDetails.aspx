<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="PostDetails.aspx.cs" Inherits="WebbsidaFotograf.Pages.PostDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" runat="server">

    <asp:ListView ID="ListView1" runat="server"
            ItemType="WebbsidaFotograf.Model.Blog"
            SelectMethod="ListView1_GetData"
            OnItemDataBound="ListView1_ItemDataBound">

            <ItemTemplate>
                <table class="BlogTable">
                <tr>
                    <td>
                        <h2><%#: Item.Title %></h2>
                        <br />
                        <%#: Item.Post %>
                        <br />
                        <h5><%#: Item.Date %></h5>
                    </td>
                </tr>
                    </table>
            </ItemTemplate>
        </asp:ListView>
    <%-- Hämta något med hjälp av ett inskickat id --%>
    <div id="fbdiv" class="fb-comments" runat="server" data-href="http://localhost:2257/Pages/PostDetails.aspx?Id=" data-numposts="5" data-colorscheme="light"></div>
</asp:Content>
