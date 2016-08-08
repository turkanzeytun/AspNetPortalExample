<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AnaSayfa.Master" AutoEventWireup="true" CodeBehind="YayinlananVideolar.aspx.cs" Inherits="YazilimciPortaliProject.Sayfalar.YayinlananVideolar" EnableViewState = "False" %>
<%--<%@ Register Assembly="ASPNetFlashVideo.NET4" Namespace="ASPNetFlashVideo" TagPrefix="ASPNetFlashVideo" %>--%>

<asp:Content ID="Content4" ContentPlaceHolderID="CSSHeader" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <asp:DataList ID="VideoList" RepeatColumns="3" runat="server">
        <ItemTemplate>
            <h3>
                <a href='<%# GetRouteUrl("VideoGoster", new {ID = Eval("videID") }) %>'>
                <%# HttpUtility.HtmlEncode(Eval("videoName").ToString()) %>
                    </a>
              </h3>
            <p>
                <a href='<%# GetRouteUrl("VideoGoster", new {ID = Eval("videID") }) %>'>
                <img src="<%# HttpUtility.HtmlEncode(Eval("thumbnail").ToString()) %>"  />
                    </a>
             </p>

               <p>
                   <%# HttpUtility.HtmlEncode(Eval("comment").ToString()) %>
               </p>
          
        </ItemTemplate>
    </asp:DataList>

      <p> 
            <asp:Label ID="HowManyPagesLabel" runat="server" ></asp:Label>
            Sayfadan
            <asp:Label ID="CurrentPageLabel" runat="server" ></asp:Label>
            Numaral&#305; Sayfadas&#305;n&#305;z |
            <asp:HyperLink ID="PreviousLink" runat="server">Önceki</asp:HyperLink>
            <asp:Repeater ID="pagesRepeater" runat="server">
                <ItemTemplate>
                <asp:HyperLink 
                    runat="server"
                    Text='<%# HttpUtility.HtmlEncode(Eval("page").ToString())%>'
                    NavigateUrl='<%# GetRouteUrl("VideolariGoster", new {ID = Eval("Id"), PAGE = Eval("Page") }) %>'>
                </asp:HyperLink>
                </ItemTemplate>
            </asp:Repeater>
             <asp:HyperLink ID="NextLink" runat="server">Sonraki</asp:HyperLink>
        </p>  
</asp:Content>

