<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageAdmin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>
<%@ MasterType VirtualPath="~/MasterPageAdmin.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style type="text/css">
        #featured_list
        {
            display: block;
            clear: both;
            width: 900px;
            margin-left:70px;
        }
        #featured_list li
        {
            list-style-type: none;
            float: left;
            width: 340px;
            height: 320px;
            text-align: center;
            margin: 20px 20px 40px 20px;
            display: block;
        }
        
        #featured_list li .thumbnail
        {
            margin: 2px auto;
            display: block;
            z-index: 1;
            cursor: auto;
        }
       
    </style>
<script type="text/javascript">
    $(document).ready(function () {
        //alert('Loaded!');
        $("#featured_list").sortable({
            placeholder: "ui-state-highlight",
            cursor: 'move',
            tolerance: 'intersect',
            opacity: .80,
            items: 'li',
            handle: '.move_link',
            stop: function (event, ui) {
                var listingIDList = "";
                //                       var formatKeyList = "";
                //                       var wformatIdList = "";

                //                       //gets the list of formatKeyId in new order
                $("#featured_list li").each(function (index) {
                    //alert($(this).attr("wformatid"));
                    //formatKeyList = formatKeyList + $(this).attr("formatIdKey") + ",";
                    listingIDList = listingIDList + $(this).attr("listing_id") + ",";
                });
                listingIDList = listingIDList.substring(0, listingIDList.length - 1);
                //alert(listingIDList);

                //updates the sort in server side
                $.ajax({
                    type: "POST",
                    url: "default.aspx/UpdateSort",
                    //data: "{ formatKeyList: '" + formatKeyList + "'}",
                    data: "{ listingIDList: '" + listingIDList + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        // alert(msg.d);
                        // Do something interesting here.
                    },
                    error: FailedMessage
                });
            }
        });

        function FailedMessage(result) {
            alert(result.status + ' ' + result.statusText);
        }
    });





function AreYouSure(id){
  doIt=confirm('이집을 정말 영원히 지울꺼요 여보?');
  if(doIt){
    window.location="Delete.aspx?id=" + id;
  }
}
</script>
<div style="width:820px;margin-left:80px; margin-top:-20px">
<div class="thumbnail">
    <img src="/images/photos/headshot_small2.jpg" /><br />
    Sonya Choi<br />
    info@sonyachoi.com<br />
    한국:070-7883-5559<br />
    미국:(C)201-233-0952<br />
    (F)201-461-2626 
</div>
<div id="hello">
<p>안녕하세요,</p>
<p>인터넷이 생활 깊숙히 자리잡은 지금 한인 인구 근 10만명에 달하는 뉴저지는 더 이상 멀리 있지 않습니다.</p>
<p>뉴저지를 가까운 이웃처럼 소개해 드립니다.</p> 
<p> 한국 분들이 선호하시는 매물 중 최근 시장에 나온 매물 중심으로 고객님의 가장 큰 자산과 행복한 보금자리가 될 최적의 주택을 정직과 신용으로 찾아 드리겠습니다.</p>
<p>감사합니다.</p>
</div>
<div id="topleft">
    <img src="/images/client-concept.jpg" /><br />
 </div>
</div>


     <ul id="featured_list">
     <asp:ListView ID="dlFeaturedListings" runat="server">
        <ItemTemplate>
        <li class="ui-state-default" listing_id="<%# Eval("listing_id") %>" >
        <div style="text-align:center; width:350px; position:relative">
        <table style="width:346px"><tr>
        <td style="width:10px; text-align:left"><a href="#" class="move_link"><img src="../images/move.png" border="0"/></a></td>
        <td>
        <img style="position:absolute; top:200px; left:230px" src='<%# Eval("status_image") %>' />
        <center><span style="font-size:18px; font-weight:bold"><%# Eval("city") %> <%# Eval("price") %></span></center></td></tr></table>
        
            <asp:Label ID="javascriptLabel" runat="server" 
                Text='<%# Eval("image_gallery") %>' />
                <center>
                <b>침실:</b><%# Eval("bed") %><b>욕실:</b><%# Eval("bath") %><br /><%# Eval("selling_point") %></center>
        </div>
        </li>
        </ItemTemplate>
    </asp:ListView>
    </ul>
</asp:Content>

