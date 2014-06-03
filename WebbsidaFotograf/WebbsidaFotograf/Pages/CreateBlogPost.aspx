<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CreateBlogPost.aspx.cs" Inherits="WebbsidaFotograf.Pages.CreateBlogPost" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <div id="CreateBlogPostContent">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
    <asp:Label ID="Label1" runat="server" Text="Titel"></asp:Label>
    <asp:TextBox ID="BlogTitle" runat="server" MaxLength="40"></asp:TextBox>
    <asp:RequiredFieldValidator ID="BlogTitleRequiredFieldValidator" runat="server" ErrorMessage="Du måste ha en titel!" ControlToValidate="BlogTitle"></asp:RequiredFieldValidator>
        
        <br />

    <asp:TextBox ID="BlogContent" runat="server" MaxLength="2000" TextMode="MultiLine" Rows="10" Width="500px" Height="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="BlogContentRequiredFieldValidator" runat="server" ErrorMessage="Du måste skriva något!" ControlToValidate="BlogContent"></asp:RequiredFieldValidator>
        

    
            <div id="CreateBlogPostButtons">
     <asp:Label ID="Help" runat="server" Text="Klicka på en knapp så läggs det till taggar i textfältet. Du kan även markera text och klicka för att sätta taggarna vid start och slut av markeringen."></asp:Label>
    <br />
    <asp:Button ID="Fetstil" runat="server" Text="FetStil" OnClientClick="insertAtCursorOrSelection('[BOLD]', '[/BOLD]'); return false;" CausesValidation="False" />
    <asp:Button ID="Kursiv" runat="server" Text="Kursiv" OnClientClick="insertAtCursorOrSelection('[ITALIC]', '[/ITALIC]'); return false;" CausesValidation="False" />
    <asp:Button ID="Rubrik" runat="server" Text="H1" OnClientClick="insertAtCursorOrSelection('[HEADER1]', '[/HEADER1]'); return false;" CausesValidation="False" />
    <asp:Button ID="Rubrik2" runat="server" Text="H2" OnClientClick="insertAtCursorOrSelection('[HEADER2]', '[/HEADER2]'); return false;" CausesValidation="False" />
<script>
    function insertAtCursorOrSelection(before, after) {
        textbox = document.getElementById('<%=BlogContent.ClientID%>');
        if (document.selection) {

            textbox.focus();
            document.selection.createRange().text = before + document.selection.createRange().text + after;


        } else if (textbox.selectionStart || textbox.selectionStart == '0') {

            var startPos = textbox.selectionStart;
            var endPos = textbox.selectionEnd;
            textbox.value = textbox.value.substring(0, startPos) + before + textbox.value.substring(startPos, endPos) + after + textbox.value.substring(endPos, textbox.value.length);

        }
    }


    </script>
        </div>



    <div id="CreateBlogPostTags">
        <asp:Label ID="BlogPostTagsLabel" runat="server" Text="Tagga inlägget, separera varje tagg med ,"></asp:Label>
        <asp:TextBox ID="BlogPostTagsTextBox" runat="server" MaxLength="200"></asp:TextBox>
    </div>




    <div id="PostBlogPost">
        <asp:Button ID="Post" runat="server" Text="Posta" OnClick="Post_Click"/>
    </div>







    </asp:PlaceHolder>

    <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="True">
        <p>ACCESS DENIED</p>
    </asp:PlaceHolder>




        </div>

</asp:Content>
