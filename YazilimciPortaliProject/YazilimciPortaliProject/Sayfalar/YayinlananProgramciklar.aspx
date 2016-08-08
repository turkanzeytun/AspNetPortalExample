<%@ Page Title="" Language="C#" EnableViewState = "False" MasterPageFile="~/MasterPages/AnaSayfa.Master" AutoEventWireup="true" CodeBehind="YayinlananProgramciklar.aspx.cs" Inherits="YazilimciPortaliProject.Sayfalar.YayinlananProgramciklar" %>

<asp:Content ID="Content4" ContentPlaceHolderID="CSSHeader" runat="server">
    <link href="/styles/LightBox/css/lightbox.css" rel="stylesheet" />
    <link href="/styles/LightBox/css/screen.css" rel="stylesheet" />   
    <link rel="shortcut icon" href="/styles/LightBox/img/demopage/favicon.png">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
<%--<div id="container">--%>
    
    <h1>Headline 1 Colour and Size</h1>

    <section id="examples" class="examples-section">
		<div class="container">
			<h2>Examples</h2>
			<h3>Two individual images</h3>
			<div class="image-row">
				<a class="example-image-link" href="/images/LightBox/img/demopage/image-1.jpg" data-lightbox="example-1">
                    <img class="example-image" src="/images/LightBox/img/demopage/image-1.jpg" alt="image-1" /></a>
				<a class="example-image-link" href="/images/LightBox/img/demopage/image-2.jpg" data-lightbox="example-2" data-title="Optional caption.">
                    <img class="example-image" src="/images/LightBox/img/demopage/image-2.jpg" alt="image-1"/></a>
			</div>
			<hr />

			<h3 style="clear: both;">Four image set</h3>
			<div class="image-row">
				<div class="image-set">
					<a class="example-image-link" href="/images/LightBox/img/demopage/image-3.jpg" data-lightbox="example-set" data-title="Click the right half of the image to move forward.">
                        <img class="example-image" src="/images/LightBox/img/demopage/thumb-3.jpg" alt=""/></a>
					<a class="example-image-link" href="/images/LightBox/img/demopage/image-4.jpg" data-lightbox="example-set" data-title="Or press the right arrow on your keyboard.">
                        <img class="example-image" src="/images/LightBox/img/demopage/thumb-4.jpg" alt="" /></a>
					<a class="example-image-link" href="/images/LightBox/img/demopage/image-5.jpg" data-lightbox="example-set" data-title="The next image in the set is preloaded as you're viewing.">
                        <img class="example-image" src="/images/LightBox/img/demopage/thumb-5.jpg" alt="" /></a>
					<a class="example-image-link" href="/images/LightBox/img/demopage/image-6.jpg" data-lightbox="example-set" data-title="Click anywhere outside the image or the X to the right to close.">
                        <img class="example-image" src="/images/LightBox/img/demopage/thumb-6.jpg" alt="" /></a>
				</div>
			</div>
		</div>
	</section>

    <h2>Headline 2 Colour and Size</h2>

    <asp:Repeater ID="Repeater1" runat="server">

    </asp:Repeater>


    <h3>Headline 3 Colour and Size</h3>
    <h4>Headline 4 Colour and Size</h4>
    <h5>Headline 5 Colour and Size</h5>
    <h6>Headline 6 Colour and Size</h6>
   
<%--  </div>--%>

    <script src="/styles/LightBox/js/lightbox.min.js"></script>
    <script src="/styles/LightBox/js/jquery-1.11.0.min.js"></script>
    <script src="/styles/LightBox/js/lightbox.js"></script>
    <script>
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-2196019-1']);
        _gaq.push(['_trackPageview']);

        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();


        document.getElementById("menu1").className="active";
	</script>
</asp:Content>
