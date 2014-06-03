﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebbsidaFotograf.Pages.Home" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div id="BlogContent">
    <asp:Label ID="loggedIn" runat="server" Text="Inloggad som admin." Visible="False"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Logga ut" CausesValidation="False" OnClick="Button1_Click" />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="AdminPages/AdminLogIn.aspx" >Logga in</asp:HyperLink>

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


    <%--<div id="BlogpostDiv">
        <asp:ListView ID="ListView1" runat="server"
            ItemType="WebbsidaFotograf.Model.Blog"
            SelectMethod="ListView1_GetData"
            OnItemDataBound="ListView1_ItemDataBound">

            
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
                </tr>
                    </table>

            </ItemTemplate>
        </asp:ListView>--%>

        <div>

<br />

<br />

</div>
        

        <asp:ListView ID="ListView2" runat="server" OnPagePropertiesChanging="ListView2_PagePropertiesChanging">
        <LayoutTemplate>
            <ul>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </ul>
        </LayoutTemplate>
        <ItemTemplate>
            <table class="BlogTable">
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# Eval("BlogPostID", "~/Pages/PostDetails.aspx?Id={0}") %>'><h2><%#: Eval("Title") %></h2></asp:HyperLink>
                        <%--<asp:Image ID="BlogImage" runat="server" width="300px" Height="200px"/>--%>
                        <%# Eval("Post") %>

                        <br />

                        <h5><%# Eval("Date") %></h5>
                    </td>
                </tr>
                
            </table>

        </ItemTemplate>
        <EmptyDataTemplate>
            No data
        </EmptyDataTemplate>
        </asp:ListView>

<asp:DataPager ID="ListViewDataPager1" runat="server" PagedControlID="ListView2" PageSize="3">
    <Fields>
        <asp:NumericPagerField ButtonType="Link" />
    </Fields>
</asp:DataPager>




        </div>
    
    <p>Skriv gärna en kommentar och gilla sidan!</p>
    
    <a href="https://twitter.com/share" class="twitter-share-button" data-url="http://localhost:2257/Pages/Home.aspx">Tweet</a>
    <div class="fb-like" data-href="http://localhost:2257/Pages/About.aspx" data-layout="standard" data-action="like" data-show-faces="true" data-share="true"></div>
    <div>
    <div class="fb-comments" data-href="http://localhost:2257/Pages/Home.aspx" data-numposts="5" data-colorscheme="light"></div>
    </div>
</asp:Content>