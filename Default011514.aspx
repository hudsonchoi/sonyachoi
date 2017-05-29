<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" EnableViewState="false" Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript">
    $(document).ready(function(){
        //alert("yes");
        $.ajax({
            type: "POST",
            url: "default.aspx/LogUser",
            data: "{'referral':'<%=referral%>'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                // Do something interesting here.
                //alert(msg.d);
            }
        });
    });
</script>
<div style="width:820px;margin-left:80px; margin-top:-10px">
<div class="thumbnail">
    <img src="images/photos/headshot_small2.jpg" /><br />
    Sonya Choi<br />
    info@sonyachoi.com<br />
    한국:070-7883-5559<br />
    미국:(C)201-233-0952<br />
    (F)201-461-2626 
</div>
<div id="hello">
<p>락펠러 센터의 점등식이 기다려지는 2013연말입니다.</p>
<p>뉴저지는 Palisades Park과 Fort Lee를 중심으로 한인들의 상권이 발달되어있습니다.</p>
<p>맨하탄으로의 출퇴근이편리하고 한국에서도 유명한 Tenafly학군과 Northern Valley Regional High School ( Demarest & Old Tappan)학군등 좋은 학교들이 많아 자녀를 키우기에 좋은 주 ( 뉴저지 닉네임: The Garden State )입니다.</p> 
<p>공인 중개사들이 가입하는 뉴저지 MLS (멀티플 리스팅 시스템)로 많은 공유 리스팅을 소개해 드릴수 있습니다.</p>
<p>정직과 신용으로 도와드리겠습니다.</p>
<p>감사합니다.</p>
</div>
<div id="topleft">
    <img src="images/client-concept.jpg" /><br />
 </div>
</div>
<div style="width:800px; margin-left:80px; clear:both">
    <asp:DataList ID="dlFeaturedListings" runat="server" 
        DataKeyField="listing_id" RepeatColumns="2" CellPadding="14" RepeatDirection="Horizontal">
        <ItemTemplate>
        <div style="text-align:center; width:350px; position:relative">
        <img style="position:absolute; top:200px; left:230px" src='<%# Eval("status_image") %>' />
        <span style="font-size:18px; font-weight:bold"><%# Eval("city") %> <%# Eval("price") %></span>

            <asp:Label ID="javascriptLabel" runat="server" 
                Text='<%# Eval("image_gallery") %>' />
                <b>침실:</b> <%# Eval("bed") %> <b>욕실:</b> <%# Eval("bath") %><br />
                <span id="selling_point"><%# Eval("selling_point") %></span>
        </div>
        </ItemTemplate>
    </asp:DataList>
</div>
<br/><br/>
</asp:Content>

