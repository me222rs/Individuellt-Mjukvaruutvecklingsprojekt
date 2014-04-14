<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebbsidaFotograf.Pages.About" MasterPageFile="~/Pages/Shared/Site.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <div>
        <aside>
            <p>Slideshow</p>
        </aside>
            <div class="AboutText">
            <h2>Vem är jag?</h2>
                <asp:Image ID="ProfilePicture" runat="server" width="200px" ImageUrl="../Content/ProfilePics/Me.png"/>
            <p>
                Jag heter Mikael Edberg och är en hobbyfotograf som helst fotograferar djur, natur och landskap. 
                För två år sedan började jag fotografera när jag upptäckte att jag hade en systemkamera som i stort 
                sett aldrig använts. Mina första bilder var på ett par gräsänder och några svanar som sprang omkring 
                i slottsparken.
                Efter ett par månaders fotografering märkte jag att kameran inte riktigt hängde med djur i rörelse och 
                bildkvaliteén inte var något vidare. Det blev helt enkelt en uppgradering av kamera och objektiv.
            </p>

            <h2>Min utrustning</h2>
            <p>
                Min kamerautrustning består av en Canon 7D som jag köpte tillsammans med ett Canon EF 24-105mm f/4L IS USM under en kampanj.
                Veckan efter så skaffade jag ett Canon EF 400mm f/5.6L USM för att hålla mig på så långt avstånd som möjligt från djuren, detta 
                ska även vara ett av Canons skarpaste objektiv någonsin. Enda nackdelen är att den saknar bildstabilisering vilket gör att det 
                blir svårt att använda när ljuset är begränsat. I vintras köpte jag mig ett s.k ultravidvinkelobjektiv vilket gör det möjligt 
                till en extrem vidvinkel, vilket är perfekt för fotografering av natthimlen tack vare att den stora bländaröppningen, men jag 
                använder den mest till landskap.
            </p>
        </div>
        <div class="fb-like" data-href="http://localhost:2257/Pages/About.aspx" data-layout="standard" data-action="like" data-show-faces="true" data-share="true"></div>
    </div>
    <footer>
        <p>Copyright Mikael Edberg</p>
    </footer>
</asp:Content>
