<%@ Page Title="" Language="C#" EnableViewState = "False" MasterPageFile="~/MasterPages/AnaSayfa.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="YazilimciPortaliProject.Sayfalar.Iletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="CSSHeader" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">   
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
      <h2>Write A Comment</h2>
      <div id="respond">         
          <p>          
              <asp:TextBox ID="name" runat="server" ></asp:TextBox>
            <label for="name"><small>&#304;S&#304;M (required)</small></label>
          </p>
          <p>
            
              <asp:TextBox ID="email" runat="server" ></asp:TextBox>
            <label for="email"><small>MA&#304;L ADRES (required)</small></label>
          </p>
          <p>
            
              <asp:TextBox ID="comment" runat="server" Height="104px" TextMode="MultiLine" Width="584px"></asp:TextBox>
            <label for="comment" style="display:none;"><small>MESAJ (required)</small></label>
          </p>
          <p>
              <asp:Button ID="submit" runat="server" Text="GÖNDER" OnClick="submit_Click"  />
            &nbsp;            
              <asp:Button ID="reset" runat="server" Text="TEM&#304;ZLE"  />
          </p>
      </div>
   
</asp:Content>
