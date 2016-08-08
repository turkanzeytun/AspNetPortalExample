<%@ Page Title="" Language="C#" EnableViewState = "False" MasterPageFile="~/MasterPages/AdminPanel.master" AutoEventWireup="true" CodeBehind="VideoYukle.aspx.cs" Inherits="YazilimciPortaliProject.YonetimPaneli.VideoYukle" %>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Icerik" runat="server">
<div id="ana_div">
    <div class="div">
      <asp:DataList ID="VideoCategories" runat="server">
          <HeaderTemplate>Bir Kategori Seçin</HeaderTemplate>
       <ItemTemplate>
           <asp:HyperLink ID="HyperLink1" 
               NavigateUrl='<%# GetRouteUrl("VideoYukle", new {ID = Eval("VideoCategoryId"), NAME="Video",PAGE = "1" }) %>'
               ToolTip="deneme"
               text='<%# HttpUtility.HtmlEncode(Eval("VideoCategoryName").ToString())%>'
               CssClass=''
               runat="server">HyperLink</asp:HyperLink>
       </ItemTemplate>
      </asp:DataList>     
    </div>
     <br/><br/>
    <div class="div">
        <table>
            <tr>
                <td colspan="2">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="741px" CssClass="submit-green" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Video Name : "></asp:Label>
                </td>
                 <td>
                    <asp:TextBox ID="txtVideoName" runat="server"></asp:TextBox>
                </td>
            </tr>
               <tr>
                <td>
                     <asp:Label ID="Label2" runat="server" Text="Comment    : "></asp:Label>
                </td>
                 <td>
                    <asp:TextBox ID="txtVideoComment" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Visible    : "></asp:Label>
                </td>
                 <td>
                    <asp:CheckBox ID="chbVisible" runat="server" />
                </td>
            </tr>
            <tr>
                <td ></td>
                <td >  
                    <asp:Button ID="btnVideoYukle" runat="server" Text="Kaydet" CssClass="submit-green" OnClick="btnVideoYukle_Click" />
                </td>
            </tr>
        </table>    
 </div>
  <br /><br />

<div class="grid_12">
    <div class="module">
       <h2><span>Sample table</span></h2>
        <div class="module-table-body">
         </div>
    </div>  
        <asp:GridView ID="grdVideos" runat="server" CssClass="tablesorter" >
             <Columns>
                 <asp:ButtonField HeaderText="Düzenle" Text="Düzenle" />
                 <asp:ButtonField HeaderText="Sil" Text="Sil" />
             </Columns>
             <RowStyle BackColor="#CC00CC" BorderStyle="Solid" />
         </asp:GridView>

  <div class="module">
        <p> 
            <asp:Label ID="HowManyPagesLabel" runat="server" ></asp:Label>
            Sayfadan
            <asp:Label ID="CurrentPageLabel" runat="server" ></asp:Label>
            Numaralı Sayfadasınız |
            <asp:HyperLink ID="PreviousLink" runat="server">Önceki</asp:HyperLink>
            <asp:Repeater ID="pagesRepeater" runat="server">
                <ItemTemplate>
                <asp:HyperLink 
                    runat="server"
                    Text='<%# HttpUtility.HtmlEncode(Eval("Page").ToString())%>'
                    NavigateUrl='<%# GetRouteUrl("VideoYukle", new {ID = Eval("Id"), NAME="Video", PAGE = Eval("Page") }) %>'>
                </asp:HyperLink>
                </ItemTemplate>
            </asp:Repeater>
             <asp:HyperLink ID="NextLink" runat="server">Sonraki</asp:HyperLink>
        </p>
    </div>
  </div>
</div>
</asp:Content>
