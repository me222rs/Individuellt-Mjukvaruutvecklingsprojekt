<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebbsidaFotograf.Pages.Home" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <asp:Label ID="loggedIn" runat="server" Text="Inloggad som admin." Visible="False"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Logga ut" CausesValidation="False" OnClick="Button1_Click" />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="AdminPages/AdminLogIn.aspx" >Logga in</asp:HyperLink>
    <div id="BlogContent">
    <h2>Blogg</h2>
    <p>Här ska några blogginlägg ligga.</p>

        <asp:LoginView ID="LoginView1" runat="server">
            <asp:AnonymousTemplate>
                You are not logged in!
            </asp:AnonymousTemplate>
            <LoggedInTemplate>
                You are logged in!
            </LoggedInTemplate>
        </asp:LoginView>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
            <asp:HyperLink ID="CreateNewBlogPost" runat="server" NavigateUrl="~/Pages/CreateBlogPost.aspx">Skapa nytt blogginlägg</asp:HyperLink>
        </asp:PlaceHolder>



<%--        <asp:ScriptManager ID="ScriptManager1" runat="server">

        </asp:ScriptManager>

        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">

        </asp:Timer>

        <asp:Image ID="Image1" runat="server" />--%>

    <div id="BlogpostDiv">
        <asp:ListView ID="ListView1" runat="server"
            ItemType="WebbsidaFotograf.Model.Blog"
            SelectMethod="ListView1_GetData"
            OnItemDataBound="ListView1_ItemDataBound">

<%--            <LayoutTemplate>
                <table>
                    <tr>
                        <td>
                            ID
                        </td>
                        <td>
                            Titel
                        </td>
                        <td>
                            Post
                        </td>
                        <td>
                            Datum
                        </td>

                    </tr>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </table>
            </LayoutTemplate>--%>
            
            <ItemTemplate>
                <table class="BlogTable">
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("BlogPostID", "~/Pages/PostDetails.aspx?Id={0}") %>'><h2><%#: Item.Title %></h2></asp:HyperLink>
                        
                        <br />
                        <%#: Item.Post %>
                        <br />
                        <h5><%#: Item.Date %></h5>
                    </td>
<%--                    <td>
                        <%#: Item.Title %>
                    </td>
                    <td>
                        <%#: Item.Post %>
                    </td>
                    <td>
                        <%#: Item.Date %>
                    </td>--%>
                </tr>
                    </table>
            </ItemTemplate>
        </asp:ListView>
        </div>
<%--        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound"
            ItemType="WebbsidaFotograf.Model.Blog" 
            SelectMethod="Repeater1_GetData" >
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text='<%# Item.BlogPostID %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text='<%# Item.Title %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text='<%# Item.Post %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text='<%# Item.Date%>'></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>--%>
    </div>
    <p>Skriv gärna en kommentar och gilla sidan!</p>
    
    <a href="https://twitter.com/share" class="twitter-share-button" data-url="http://localhost:2257/Pages/Home.aspx">Tweet</a>
    <div class="fb-like" data-href="http://localhost:2257/Pages/About.aspx" data-layout="standard" data-action="like" data-show-faces="true" data-share="true"></div>
    <div>
    <div class="fb-comments" data-href="http://localhost:2257/Pages/Home.aspx" data-numposts="5" data-colorscheme="light"></div>
    </div>
</asp:Content>
