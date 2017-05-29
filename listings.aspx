<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="listings.aspx.cs" Inherits="listings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <div style="width:830px; margin: 0 auto">
    <asp:GridView ID="gvRents" runat="server" AutoGenerateColumns="False" 
        CellPadding="3" CellSpacing="3" 
    GridLines="None" AllowSorting="True" OnSorting="gvRents_Sorting" 
        onrowdatabound="gvRents_RowDataBound">
        <RowStyle VerticalAlign="Top" />
        <Columns>
            <asp:BoundField DataField="listing_id" HeaderText="Listing ID" SortExpression="listing_id" />
            <asp:BoundField DataField="image_gallery" HeaderText=""  HtmlEncode="false"/>
            <asp:BoundField DataField="city" HeaderText="도시" SortExpression="city" />
            <asp:BoundField DataField="price" HeaderText="가격" SortExpression="price" />
            <asp:BoundField DataField="selling_point" HeaderText="주요 내용" />
            <asp:TemplateField HeaderText="스타일" SortExpression="style" ItemStyle-Width="60">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("style") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("style") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="침실" SortExpression="bed" ItemStyle-Width="42">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("bed") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="욕실" SortExpression="bath" ItemStyle-Width="42">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("bath") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <AlternatingRowStyle BackColor="#E7F2E9" />
    </asp:GridView>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

