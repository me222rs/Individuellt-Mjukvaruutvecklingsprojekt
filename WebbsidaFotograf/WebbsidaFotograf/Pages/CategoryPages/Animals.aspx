<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Animals.aspx.cs" Inherits="WebbsidaFotograf.Pages.CategoryPages.Animals" MasterPageFile="~/Pages/Shared/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div id="GalleryContent">

    <%-- Kolumn 1 - Uppladdning, beskrivning och taggar--%>
    <asp:PlaceHolder ID="Column1PlaceHolder" runat="server" Visible="false">
    <div id="Column1">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">

    <%-- Uppladdning --%>
            <p>Ladda upp en bild i denna kategorin.</p>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:RequiredFieldValidator ID="UploadValidator" runat="server" ErrorMessage="Du måste välja en bild att ladda upp!" ForeColor="Red" ControlToValidate="FileUpload1" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="FileUpload1RegularExpressionValidator" runat="server" ErrorMessage="Måste vara av filformatet jpg, png eller gif" ControlToValidate="FileUpload1" ValidationExpression="^.*\.(gif|jpg|png)$"></asp:RegularExpressionValidator>
    
<br />
            <asp:Label ID="DescriptionLabel" runat="server" Text="Beskrivning"></asp:Label>
<br />
            <asp:TextBox ID="DescriptionTextBox" runat="server" MaxLength="200" TextMode="MultiLine" Rows="5"></asp:TextBox>
<br />
            <asp:RequiredFieldValidator ID="DescriptionTextBoxRequiredFieldValidator" runat="server" ErrorMessage="Du måste ge en beskrivning!" ForeColor="Red" ControlToValidate="DescriptionTextBox"></asp:RequiredFieldValidator>
    
<br />
            <asp:Label ID="TagLabel" runat="server" Text="Lägg till taggar, separera varje tagg med ,"></asp:Label>
<br />            
                <asp:TextBox ID="TagTextBox" runat="server" MaxLength="200"></asp:TextBox>


    <p>
        <%-- Visar meddelande --%>
            <asp:Label ID="Success" runat="server" Text=""></asp:Label>
    </p>    
             <asp:Button ID="Upload" runat="server" Text="Ladda upp" OnClick="Upload_Click"/>
<br />
        <%-- Knapp för att radera --%>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Delete_Click" CausesValidation="False">Radera</asp:LinkButton>
<br />
        <%-- Knapp för att uppdatera beskrivning --%>
            <asp:LinkButton ID="Update" runat="server" OnClick="Update_Click" CausesValidation="false">Uppdatera</asp:LinkButton>
                <asp:PlaceHolder ID="UpdatePlaceHolder" runat="server" Visible="false">
                    
<br />
        <%-- Textbox för ny beskrivning  --%>
                    <asp:Label ID="Label1" runat="server" Text="Label">Beskrivning</asp:Label>
                    <br />
                    <asp:TextBox ID="UpdateDescriptionTextBox" runat="server" TextMode="MultiLine" Rows="5" MaxLength="200"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="Du måste ha en beskrivning!" ControlToValidate="UpdateDescriptionTextBox"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="Label2" runat="server" Text="Label">Taggar</asp:Label>
                    <br />
                    <asp:TextBox ID="UpdateTagsTextBox" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Du måste ange minst en tagg!" ControlToValidate="UpdateTagsTextBox"></asp:RequiredFieldValidator>
                    <br />
                    <asp:LinkButton ID="UpdateDescription" runat="server" OnClick="UpdateDescription_Click" CausesValidation="false">Uppdatera Beskrivning</asp:LinkButton>
                    
                </asp:PlaceHolder>
            </asp:PlaceHolder>
<%--        <div id="Info">
            <p id="ImageInfos">
                
                <asp:Literal ID="DescriptionLiteral" runat="server"></asp:Literal> 
            </p>
        </div>--%>

        <%--<asp:LinkButton ID="ShowTags" runat="server" CausesValidation="True" OnClick="ShowTags_Click">Visa taggar</asp:LinkButton>--%>
<%--    <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="true">
        <asp:Label ID="ImageTags" runat="server" Visible="true" Text="Här kommer taggarna ligga!"></asp:Label>
        </asp:PlaceHolder>--%>
    </div>
        
<br />
        </asp:PlaceHolder>
            <%-- Kolumn 3 - Tumnaglarna--%>
    <div id="ThumbNails">
            
        <p>
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" 
                ItemType="System.String" 
                SelectMethod="Repeater1_GetData" >
                <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server"
                           ImageUrl='<%# "~/Content/" + Session["Category"] + "Thumbs/" + Item %>' 
                           
                           NavigateUrl='<%# "?name=" + Item + "&Category=" + Session["Category"]%>' />
                </ItemTemplate>
            </asp:Repeater>
        </p>
        </div>
       
    <%-- Kolumn 2 - Den stora bilden och kommentarer--%>
        
        <%-- Den stora bilden --%>
    <asp:Panel runat="server" ID="Panel2" HorizontalAlign="Center">

        <div id="bild">
            <asp:Image ID="BigImage" runat="server"/>
            <br/>
        
        </div>
        <asp:PlaceHolder ID="DescPlaceHolder" runat="server">
        <div id="Description">
            <p>
            <asp:Literal ID="DescriptionLiteral" runat="server"></asp:Literal>
            </p>
            <p>
                <asp:Label ID="Label3" runat="server" Text="Taggar:" Font-Bold="true"></asp:Label>
                <asp:Label ID="ImageTags" runat="server" Visible="true" Text="Här kommer taggarna ligga!" Font-Italic="true" Font-Size="Small"></asp:Label>
            </p>
        </div>
            </asp:PlaceHolder>
    </asp:Panel>

<br />

<br />


    <div id="facebook">

    <div id="fbdiv" class="fb-comments" runat="server" data-href="http://localhost:2257/Pages/CategoryPages/Animals.aspx" data-numposts="5" data-colorscheme="light"></div>

    </div>

    </div>
</asp:Content>
<%--ImageUrl='<%# "~/Content/GalleryThumbs/" + Item %>'--%>
