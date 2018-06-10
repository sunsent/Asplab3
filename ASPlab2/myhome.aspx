<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myhome.aspx.cs" Inherits="ASPlab2.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="label_wel" runat="server" Text="欢迎来到专属空间"></asp:Label>
        <p>
            <asp:Label ID="label_usrInfo" runat="server"></asp:Label>
        </p>
        <asp:Label ID="label_time" runat="server"></asp:Label>
        <p>
            <asp:ListBox ID="ListBox_MyClass" runat="server" Height="113px" Width="206px"></asp:ListBox>
            <asp:Button ID="BtnSearchMyClass" runat="server" OnClick="BtnSearchMyClass_Click" Text="查询" />
        </p>
        <p>
            <asp:Button ID="btn_logout" runat="server" OnClick="btn_logout_Click" Text="注销" />
        </p>
    </form>
</body>
</html>
