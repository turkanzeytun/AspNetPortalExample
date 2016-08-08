<%@ Page Title="" Language="C#" EnableViewState = "False" MasterPageFile="~/MasterPages/AnaSayfa.Master" AutoEventWireup="true" CodeBehind="VideoShow.aspx.cs" Inherits="YazilimciPortaliProject.Sayfalar.VideoShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
      <iframe width="420" height="345" src= "<%# HttpUtility.HtmlEncode(Eval("videoyolu").ToString()) %>" ></iframe>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CSSHeader" runat="server">
</asp:Content>
