<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="DefaultCrude.aspx.cs" Inherits="admin_Default" %>
<%@ MasterType VirtualPath="~/MasterPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript">
function AreYouSure(id){
  doIt=confirm('이집을 정말 영원히 지울꺼요 여보?');
  if(doIt){
    window.location="Delete.aspx?id=" + id;
  }
}
</script>
<div style="width:750px; background-color:Lime; clear:both; margin:0 auto">
<div style="padding-left:18px; clear:both">
    <asp:Button ID="btnAdd" runat="server" Text="Add +" onclick="btnAdd_Click" /></div>
    <asp:GridView ID="gvRents" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" CellSpacing="3" 
    GridLines="None" onrowdatabound="gvRents_RowDataBound" DataKeyNames="listing_id" 
        onselectedindexchanged="gvRents_SelectedIndexChanged">
        <RowStyle VerticalAlign="Top" />
        <Columns>
            <asp:TemplateField HeaderText="listing_id" SortExpression="listing_id">
                <ItemTemplate>
                    <asp:Label ID="lblID" runat="server" Text='<%# Bind("listing_id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="image_gallery" HeaderText="image_gallery"  HtmlEncode="false"/>
            <asp:BoundField DataField="city" HeaderText="city" SortExpression="city" />
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            <asp:BoundField DataField="selling_point" HeaderText="selling_point" />
            <asp:BoundField DataField="style" HeaderText="style" />
            <asp:BoundField DataField="bed" HeaderText="bed" />
            <asp:BoundField DataField="bath" HeaderText="bath" />
            <asp:TemplateField HeaderText="Sort">
                <ItemTemplate>
                    <table><tr style="<%# DataBinder.Eval(Container.DataItem, "up_style") %>"><td>
                    <a href="move.aspx?id=<%# DataBinder.Eval(Container.DataItem, "listing_id") %>&tid=<%# DataBinder.Eval(Container.DataItem, "prev_listing_id") %>">
                    <img src="../images/buttons/up.gif" width="19" height="19" border="0"/>
                    </a>
                    </td>
                    </tr>
                    <tr style="<%# DataBinder.Eval(Container.DataItem, "down_style") %>">   
                    <td>
                    <a href="move.aspx?id=<%# DataBinder.Eval(Container.DataItem, "listing_id") %>&tid=<%# DataBinder.Eval(Container.DataItem, "next_listing_id") %>">
                    <img src="../images/buttons/down.gif" width="19" height="19" border="0"/>
                      </a>
                    </td></tr></table>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" 
                SelectText="Delete" />
            
        </Columns>
        <AlternatingRowStyle BackColor="#E7F2E9" />
    </asp:GridView>
<div style="padding-left:18px"><asp:Button ID="btnAdd2" runat="server" Text="Add +" onclick="btnAdd_Click" /></div>
</div>
</asp:Content>

