<%@ Page Language="C#" %>

<script language="C#" runat="server">
protected void button1_click(object sender, EventArgs e)
{
   try
   {
     //do some complex stuff

     //generate your fictional exception
     int x = 1;
     int y = 0;
     int z = x / y;
   }
   catch(DivideByZeroException ex)
   {
     //put cleanup code here
     throw(ex);
   }
}
</script>

<form runat="server">
   <asp:button id="button1" onclick="button1_click"
     text="click me" runat="server" />
</form>