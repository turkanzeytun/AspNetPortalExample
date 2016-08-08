<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="YazilimciPortaliProject.YonetimPaneli.AdminIndex" EnableViewState = "False" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Icerik" runat="server">
   <%-- <form id="frmAdminIndexIcerik" runat="server">--%>
  <!-- Dashboard icons -->
            <div class="grid_7">
               
                <a href="#" class="dashboard-module" >
                <img src="/App_Themes/AdminTemalar/Crystal_Clear_write.gif"  
                    width="64" height="64" alt="edit" />
                    <span >Yeni Makale</span>
                    </a>
                
                <a href="#"  class="dashboard-module" >         
                    <asp:ImageButton ID="imgBtnVideoYukle" CssClass="imgAdminIndex" runat="server" 
                        ImageUrl="/App_Themes/AdminTemalar/Crystal_Clear_file.gif" 
                        width="64" height="64" alt="edit" OnClick="imgBtnVideoYukle_Click"   />
                	<span >Video Ekle</span>
                </a>
                
                     <a href="#"  class="dashboard-module" >         
                    <asp:ImageButton ID="imgBtnPrgYukle" CssClass="imgAdminIndex" runat="server" 
                        ImageUrl="/App_Themes/AdminTemalar/Crystal_Clear_files.gif" 
                        width="64" height="64" alt="edit" OnClick="imgBtnPrgYukle_Click"   />
                	<span >Program Ekle</span>
                </a>

                <a href='<%# GetRouteUrl("Videos", new {ID ="TÜMVİDEOLAR" }) %>' class="dashboard-module" >
                <img src="/App_Themes/AdminTemalar/Crystal_Clear_calendar.gif"  
                    width="64" height="64" alt="edit" />
                    <span>Takvim</span>
                    </a>
                
                 <a href='<%# GetRouteUrl("Videos", new {ID ="TÜMVİDEOLAR" }) %>' class="dashboard-module" >
                <img src="/App_Themes/AdminTemalar/Crystal_Clear_user.gif"  
                    width="64" height="64" alt="edit" />
                    <span>Kullanıcı Ayarları</span>
                    </a>
               
                 <a href='<%# GetRouteUrl("Videos", new {ID ="TÜMVİDEOLAR" }) %>' class="dashboard-module" >
                <img src="/App_Themes/AdminTemalar/Crystal_Clear_stats.gif"  
                    width="64" height="64" alt="edit" />
                    <span>Ayarlar</span>
                    </a>

                <a href='<%# GetRouteUrl("Videos", new {ID ="TÜMVİDEOLAR" }) %>' class="dashboard-module" >
                <img src="/App_Themes/AdminTemalar/Crystal_Clear_settings.gif"  
                    width="64" height="64" alt="edit" />
                    <span>Ayarlar</span>
                    </a>
                
                
                <div style="clear: both"></div>
            </div> <!-- End .grid_7 -->

          <%--  </form>--%>
               
</asp:Content>
