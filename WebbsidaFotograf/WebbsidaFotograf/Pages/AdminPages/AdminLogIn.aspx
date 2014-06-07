<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogIn.aspx.cs" Inherits="WebbsidaFotograf.Pages.AdminPages.AdminLogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="LoginContent">
        <p>Logga in som admin.</p>
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate"></asp:Login>
    </div>
    </form>
</body>
</html>
