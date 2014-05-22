﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="PostDetails.aspx.cs" Inherits="WebbsidaFotograf.Pages.PostDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceholder" runat="server">

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
                        
                        <asp:Literal ID="TagLiteral" runat="server"></asp:Literal>
                        <br />
                        <%# Eval("Post") %>
                        <%--<%#: Item.Post %>--%>
                        <br />
                        
                        <h5><%#: Item.Date %></h5>
                        <asp:LinkButton ID="DeletePost" runat="server" OnClick="Delete_Click">Ta bort</asp:LinkButton>
                        
                    </td>
                    
                </tr>
                    </table>
            </ItemTemplate>
        </asp:ListView>
    
    <asp:Panel ID="Panel1" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
    <asp:FormView ID="UpdatePostFormView" runat="server"         
        ItemType="WebbsidaFotograf.Model.Blog" 
        DefaultMode="Edit" 
        UpdateMethod="BlogPostFormView_UpdateItem" 
        DataKeyNames="BlogPostID" 
        SelectMethod="BlogPostFormView_GetItem">
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                    <asp:TextBox ID="EditTitleTextBox" runat="server" Text='<%# BindItem.Title %>'></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="PostTextBox" runat="server" Text='<%# BindItem.Post %>' TextMode="MultiLine" Rows="5" ></asp:TextBox>

                </td>
                <asp:LinkButton ID="SaveButton" runat="server" CommandName="Update">Spara</asp:LinkButton>
            </tr>

            


        </EditItemTemplate>
    </asp:FormView>

        <asp:Button ID="Fetstil" runat="server" Text="FetStil" OnClientClick="insertAtCursorOrSelection('[BOLD]', '[/BOLD]'); return false;" CausesValidation="False" />
    <asp:Button ID="Kursiv" runat="server" Text="Kursiv" OnClientClick="insertAtCursorOrSelection('[ITALIC]', '[/ITALIC]'); return false;" CausesValidation="False" />
    <asp:Button ID="Rubrik" runat="server" Text="H1" OnClientClick="insertAtCursorOrSelection('[HEADER1]', '[/HEADER1]'); return false;" CausesValidation="False" />
    <asp:Button ID="Rubrik2" runat="server" Text="H2" OnClientClick="insertAtCursorOrSelection('[HEADER2]', '[/HEADER2]'); return false;" CausesValidation="False" />
    <asp:Button ID="Link" runat="server" Text="Länk" OnClientClick="insertAtCursorOrSelection('[LINK]', '[/LINK]'); return false;" CausesValidation="False" />

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

    </asp:PlaceHolder>
        </asp:Panel>
    <div id="fbdiv" class="fb-comments" runat="server" data-href="http://localhost:2257/Pages/PostDetails.aspx?Id=" data-numposts="5" data-colorscheme="light"></div>
</asp:Content>
