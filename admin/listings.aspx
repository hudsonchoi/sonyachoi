<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="listings.aspx.cs" Inherits="admin_listings" %>
<%@ MasterType VirtualPath="~/MasterPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
<script language="javascript">
function AreYouSure(id, typeId){
  doIt=confirm('이집을 정말 영원히 지울꺼요 여보?');
  if(doIt){
    window.location="Delete.aspx?id=" + id + "&type_id=" + typeId;
  }
}
</script>
<div style="width:800px; clear:both; margin:0 auto">
<div style="padding-left:18px; clear:both">
    <asp:Button ID="btnAdd" runat="server" Text="Add +" onclick="btnAdd_Click" /></div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>  
    <asp:GridView ID="gvRents" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" CellSpacing="3" 
    GridLines="None" onrowdatabound="gvRents_RowDataBound" DataKeyNames="listing_id" 
        onselectedindexchanged="gvRents_SelectedIndexChanged" 
        onrowcommand="gvRents_RowCommand">
        <RowStyle VerticalAlign="Top" />
        <Columns>
            <asp:BoundField DataField="listing_id" HeaderText="Listing ID" SortExpression="listing_id" />
            <asp:BoundField DataField="image_gallery" HeaderText=""  HtmlEncode="false"/>
            <asp:BoundField DataField="city" HeaderText="도시" SortExpression="city" />
            <asp:BoundField DataField="price" HeaderText="가격" SortExpression="price" />
            <asp:BoundField DataField="selling_point" HeaderText="주요 내용" />
<asp:TemplateField HeaderText="스타일" ItemStyle-Width="50">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("style") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("style") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="침실" SortExpression="bed" ItemStyle-Width="30">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("bed") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("bed") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="욕실" SortExpression="bath" ItemStyle-Width="30">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("bath") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("bath") %>'></asp:Label>
                </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sort">
                <ItemTemplate>
                    <asp:HiddenField ID="hfListingID" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "listing_id")%>' />
                    <table><tr style="<%# DataBinder.Eval(Container.DataItem, "up_style") %>"><td>
                    <asp:ImageButton ID="ibUp" ImageUrl="../images/buttons/up.gif" Width="19" Height="19" CommandName="Up" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "prev_listing_id") %>'  />
                    </td>
                    </tr>
                    <tr style="<%# DataBinder.Eval(Container.DataItem, "down_style") %>">   
                    <td>
                    <asp:ImageButton ID="ibDown" ImageUrl="../images/buttons/down.gif" Width="19" Height="19" CommandName="Down" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "next_listing_id") %>'  />
                    </td></tr></table>
                    
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" ShowSelectButton="True" 
                SelectText="Delete" />
            
        </Columns>
        <AlternatingRowStyle BackColor="#E7F2E9" />
    </asp:GridView>
    </ContentTemplate>     
   </asp:UpdatePanel>    
<div style="padding-left:18px"><asp:Button ID="btnAdd2" runat="server" Text="Add +" onclick="btnAdd_Click" /></div>
</div>
</asp:Content>


