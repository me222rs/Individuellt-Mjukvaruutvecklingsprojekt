<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/Site.Master" AutoEventWireup="true" CodeBehind="CreateBlogPost.aspx.cs" Inherits="WebbsidaFotograf.Pages.CreateBlogPost" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceholder" runat="server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
    <asp:Label ID="Label1" runat="server" Text="Titel"></asp:Label>
    <asp:TextBox ID="BlogTitle" runat="server"></asp:TextBox>
    <br />
        <%--onkeypress="AddBrTag(event)--%>
    <asp:TextBox ID="BlogContent" runat="server" TextMode="MultiLine" Rows="10" onkeyup="copy_data(this)" onkeypress="AddBrTag(event)"></asp:TextBox>
    <asp:TextBox ID="HtmlText" runat="server" TextMode="MultiLine" Rows="10" onkeypress="AddBrTag(event)"></asp:TextBox>
        <asp:Button ID="BoldButton" runat="server" Text="Button" OnClientClick="ShowSelection()"/>
        <asp:Button ID="ItalicButton" runat="server" Text="Button" OnClientClick="getSelText(document.getElementById('<%=BlogContent.ClientID%>'))"/>
        <asp:DropDownList ID="ColorDropDownList" runat="server">
            <asp:ListItem>Red</asp:ListItem>
            <asp:ListItem>Green</asp:ListItem>
            <asp:ListItem>Black</asp:ListItem>
        </asp:DropDownList>
        

    <asp:Button ID="Post" runat="server" Text="Posta" OnClick="Post_Click"/>
    </asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="True">
        <p>ACCESS DENIED</p>
    </asp:PlaceHolder>
    <script> //Tvungen att lägga scriptet här pga master page
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
    </script>
        <script>
            function copy_data(val) {
                var a = document.getElementById('<%=BlogContent.ClientID%>').value
                document.getElementById('<%=HtmlText.ClientID%>').value = a
            }
    </script>

<%--    <script>
        function ShowSelection() {
            var textComponent = document.getElementById('<%=BlogContent.ClientID%>');
            var selectedText;
            // IE version
            if (document.selection != undefined) {
                textComponent.focus();
                var sel = document.selection.createRange();
                selectedText = sel.text;
            }
                // Mozilla version
            else if (textComponent.selectionStart != undefined) {
                var startPos = textComponent.selectionStart;
                var endPos = textComponent.selectionEnd;
                selectedText = textComponent.value.substring(startPos, endPos)
            }
            selectedText.replace("§§" + selectedText + "§§");
            
            //alert("You selected: " + "§§" + selectedText + "§§");
        }

    </script>--%>
    <script>
        function getSelText(textarea) {
            if (document.selection) {
                alert(document.selection.createRange().text);
            }
            else {
                alert(textarea.value.substring(textarea.selectionstart, textarea.selectionend));
            }
        }
</script>

</asp:Content>
