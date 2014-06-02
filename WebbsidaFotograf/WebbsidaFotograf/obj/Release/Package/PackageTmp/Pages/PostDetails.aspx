<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="PostDetails.aspx.cs" Inherits="WebbsidaFotograf.Pages.PostDetails" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <div id="PostDetailsContent">
    <asp:ListView ID="ListView2" runat="server"
            ItemType="WebbsidaFotograf.Model.Blog"
            SelectMethod="ListView2_GetData"
            UpdateMethod="ListView2_UpdateItem" 
            OnItemDataBound="ListView2_ItemDataBound">

            <ItemTemplate>
                <table class="BlogTable">
                <tr>
                    <td>
                        <h2><%#: Item.Title %></h2>
                        
                        
                        <br />
                        <%# Eval("Post") %>
                        <%--<%#: Item.Post %>--%>
                        <br />
                        <h5><asp:Label ID="Label1" runat="server" Text="Taggar: "></asp:Label><asp:Literal ID="TagLiteral" runat="server"></asp:Literal></h5>
                        <h5><%#: Item.Date %></h5>
                        
                        
                    </td>
                    
                </tr>
                    </table>
            </ItemTemplate>
        </asp:ListView>
    <div id="BlogButtons">
        <asp:LinkButton ID="DeletePost" runat="server" OnClick="Delete_Click">Ta bort</asp:LinkButton>
        <br />
        <asp:LinkButton ID="Edit" runat="server" OnClick="Edit_Click">Redigera</asp:LinkButton>
    </div>

    <asp:Panel ID="Panel1" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">

        <asp:PlaceHolder ID="EditPost" runat="server"  Visible="false">
    
            <div id="EditPostDetails">
    <asp:FormView ID="UpdatePostFormView" runat="server"         
        ItemType="WebbsidaFotograf.Model.Blog" 
        DefaultMode="Edit" 
        UpdateMethod="BlogPostFormView_UpdateItem" 
        DataKeyNames="BlogPostID" 
        SelectMethod="BlogPostFormView_GetItem">
        <EditItemTemplate>
            
           
                    <asp:TextBox ID="EditTitleTextBox" runat="server" Text='<%# BindItem.Title %>' MaxLength="40"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EditTitleTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Du måste ha en titel!" ControlToValidate="EditTitleTextBox" Display="Static"></asp:RequiredFieldValidator>
       <br />
                    <asp:TextBox ID="PostTextBox" runat="server" Text='<%# BindItem.Post %>' TextMode="MultiLine" Rows="5" Width="500px" Height="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PostTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Du måste ha en post!" ControlToValidate="PostTextBox"></asp:RequiredFieldValidator>
        <br />
                <asp:LinkButton ID="SaveButton" runat="server" CommandName="Update">Spara</asp:LinkButton>
                
           

            


        </EditItemTemplate>
    </asp:FormView>
                </div>
                <div id="TagsPostDetails">
        <asp:TextBox ID="TagsTextBox" runat="server" Text="" MaxLength="200"></asp:TextBox>
        <asp:Button ID="Fetstil" runat="server" Text="FetStil" OnClientClick="insertAtCursorOrSelection('[BOLD]', '[/BOLD]'); return false;" CausesValidation="False" />
    <asp:Button ID="Kursiv" runat="server" Text="Kursiv" OnClientClick="insertAtCursorOrSelection('[ITALIC]', '[/ITALIC]'); return false;" CausesValidation="False" />
    <asp:Button ID="Rubrik" runat="server" Text="H1" OnClientClick="insertAtCursorOrSelection('[HEADER1]', '[/HEADER1]'); return false;" CausesValidation="False" />
    <asp:Button ID="Rubrik2" runat="server" Text="H2" OnClientClick="insertAtCursorOrSelection('[HEADER2]', '[/HEADER2]'); return false;" CausesValidation="False" />
    

                            <script>
                                function insertAtCursorOrSelection(before, after) {
                                    console.log(textbox);
                                    var textbox = document.getElementById('<%= UpdatePostFormView.FindControl("PostTextBox").ClientID %>');

                            console.log("textbox = ", textbox);

                            if (document.selection) {

                                textbox.focus();
                                document.selection.createRange().text = before + document.selection.createRange().text + after;


                            } else if (textbox.selectionStart || textbox.selectionStart == '0') {

                                var startPos = textbox.selectionStart;
                                console.log("startPos =", startPos);
                                var endPos = textbox.selectionEnd;
                                console.log("endPos =", endPos);
                                console.log(textbox.value);
                                textbox.value = textbox.value.substring(0, startPos) + before + textbox.value.substring(startPos, endPos) + after + textbox.value.substring(endPos, textbox.value.length);

                            }
                        }

    </script>
                    </div>
    
    </asp:PlaceHolder>
    </asp:PlaceHolder>
        </asp:Panel>

    <div id="facebookBlog">
        <div id="fbdiv" class="fb-comments" runat="server" data-href="http://localhost:2257/Pages/PostDetails.aspx?Id=" data-numposts="5" data-colorscheme="light"></div>
    </div>
        </div>
</asp:Content>
