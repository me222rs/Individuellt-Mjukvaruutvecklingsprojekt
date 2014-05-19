<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CreateBlogPost.aspx.cs" Inherits="WebbsidaFotograf.Pages.CreateBlogPost" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
    <asp:Label ID="Label1" runat="server" Text="Titel"></asp:Label>
    <asp:TextBox ID="BlogTitle" runat="server"></asp:TextBox>
    <br />
        <%--onkeypress="AddBrTag(event)--%>
    <asp:TextBox ID="BlogContent" runat="server" TextMode="MultiLine" Rows="10" onkeyup="copy_data(this)" onkeypress="AddBrTag(event)" Width="500px" Height="300px"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="HtmlText" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox>
<%--        <asp:Button ID="BoldButton" runat="server" Text="Button" OnClientClick="ShowSelection()"/>
        <asp:Button ID="ItalicButton" runat="server" Text="Button" OnClientClick="getSelText(document.getElementById('<%=BlogContent.ClientID%>'))"/>--%>
        <asp:DropDownList ID="ColorDropDownList" runat="server">
            <asp:ListItem>Red</asp:ListItem>
            <asp:ListItem>Green</asp:ListItem>
            <asp:ListItem>Black</asp:ListItem>
        </asp:DropDownList>
        
        <asp:Button ID="addtag" runat="server" Value="AddTag" OnClientClick="function addTagSel(tag, idelm)"/>
    <asp:Button ID="Post" runat="server" Text="Posta" OnClick="Post_Click"/>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="True">
        <p>ACCESS DENIED</p>
    </asp:PlaceHolder>
<%--    <script> //Tvungen att lägga scriptet här pga master page
        function AddBrTag(e) {
            if (e.keyCode == 13) {
                //alert("HEJ"); //Fungerar
                console.log(obj);

        var obj = document.getElementById('<%=BlogContent.ClientID%>').value;
        console.log(obj);

        document.getElementById('<%=HtmlText.ClientID%>').value = obj + "§";
        console.log(obj);
    }

}
    </script>--%>
        <script>
            function copy_data(val) {
                var a = document.getElementById('<%=BlogContent.ClientID%>').value
                document.getElementById('<%=Label2.ClientID%>').value = a
            }
    </script>


<%--    <script>
        function getSelText(textarea) {
            if (document.selection) {
                alert(document.selection.createRange().text);
            }
            else {
                alert(textarea.value.substring(textarea.selectionstart, textarea.selectionend));
            }
        }
</script>--%>

    <asp:Button ID="Fetstil" runat="server" Text="FetStil" OnClientClick="insertAtCursorOrSelection('[BOLD]', '[/BOLD]'); return false;" CausesValidation="False" />
    <asp:Button ID="Kursiv" runat="server" Text="Kursiv" OnClientClick="insertAtCursorOrSelection('[ITALIC]', '[/ITALIC]'); return false;" CausesValidation="False" />
    <asp:Button ID="Rubrik" runat="server" Text="H1" OnClientClick="insertAtCursorOrSelection('[HEADER1]', '[/HEADER1]'); return false;" CausesValidation="False" />
    <asp:Button ID="Rubrik2" runat="server" Text="H2" OnClientClick="insertAtCursorOrSelection('[HEADER2]', '[/HEADER2]'); return false;" CausesValidation="False" />
    <asp:Button ID="Link" runat="server" Text="Länk" OnClientClick="insertAtCursorOrSelection('[LINK]', '[/LINK]'); return false;" CausesValidation="False" />
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


</asp:Content>
