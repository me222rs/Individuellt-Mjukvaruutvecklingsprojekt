<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebbsidaFotograf.Pages.Home" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div id="BlogContent">
        <asp:Label ID="loggedIn" runat="server" Text="Inloggad som admin." Visible="False"></asp:Label>
        <asp:Button ID="Button1" runat="server" Text="Logga ut" CausesValidation="False" OnClick="Button1_Click" Visible="false"/>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="AdminPages/AdminLogIn.aspx" >Logga in</asp:HyperLink>

    <h2>Blogg</h2>
    <p>Här ska några blogginlägg ligga.</p>
        
        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
            <asp:HyperLink ID="CreateNewBlogPost" runat="server" NavigateUrl="~/Pages/CreateBlogPost.aspx">Skapa nytt blogginlägg</asp:HyperLink>
        </asp:PlaceHolder>


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
            Det finns inga poster
        </EmptyDataTemplate>
        </asp:ListView>

<asp:DataPager ID="ListViewDataPager1" runat="server" PagedControlID="ListView2" PageSize="3">
    <Fields>
        <asp:NumericPagerField ButtonType="Link" />
    </Fields>
</asp:DataPager>




        </div>
    
    <p>Skriv gärna en kommentar och gilla sidan!</p>
    <%-- Facebook kommentarer fungerar inte på skolans server kupan eftersom facebook inte kan komma åt vpn200, localhost fungerar. 
         För att ta bort kommentarer så får man via facebooks utvecklarsida ange sin adress, localhost och kupan fungerar inte.        
        --%>
    <a href="https://twitter.com/share" class="twitter-share-button" data-url="http://vhost9.lnu.se:20081/1dv406/me222rs/Pages/Home.aspx">Tweet</a>
    <div class="fb-like" data-href="http://vhost9.lnu.se:20081/1dv406/me222rs/Pages/Home.aspx" data-layout="standard" data-action="like" data-show-faces="true" data-share="true"></div>
    <div>
        <div class="fb-comments" data-href="http://vhost9.lnu.se:20081/1dv406/me222rs/Pages/Home.aspx" data-numposts="5" data-colorscheme="light"></div>
        
    </div>
    
</asp:Content>
