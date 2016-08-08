<%@ Page Title="" Language="C#"  MasterPageFile="~/MasterPages/AdminPanelIndex.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="YazilimciPortaliProject.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UstAnaMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="UstLinkler" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Govde" runat="server">
    <!-- Password -->

            <div class="grid_6">
                <div class="module">
                     <h2><span>Giriş Yap</span></h2>
                        
                     <div class="module-body">
                               
                            <p>
                                <label>Kullanıcı Adı</label>
                               
                                <asp:TextBox ID="txtxKullanici" runat="server" CssClass="input-medium"></asp:TextBox>

                            </p>
                            <p>
                                <label>Parola</label>
                            
                                 <asp:TextBox ID="txtParola" runat="server" CssClass="input-medium password" TextMode="Password"></asp:TextBox>
                            </p>
                            <fieldset>                              
                                <asp:Button ID="btbGiris" runat="server" Text="Submit" CssClass="submit-green" OnClick="btbGiris_Click"   />
                                <asp:Button ID="btnIptal" runat="server" Text="Cancel" CssClass="submit-gray"/>
                            </fieldset>
                      
                        
                     </div> <!-- End .module-body -->
                     
                </div> <!-- End .module -->
                <div style="clear:both;"></div>
            </div> <!-- End .grid_6 -->
            <div style="clear:both;"></div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="AltKısım" runat="server">
</asp:Content>
