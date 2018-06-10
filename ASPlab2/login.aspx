<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ASPlab2.myhome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="用户名"></asp:Label>
        <asp:TextBox ID="txtUsrname" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="密码"></asp:Label>
            &nbsp
            <asp:TextBox ID="txtPwd" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="label_tip" runat="server" Text="请输入用户名和密码"></asp:Label>
        <p>
            <asp:Button ID="btn_login" runat="server" Text="登录" OnClick="btn_login_Click" />&nbsp
            <asp:Button ID="btn_reset" runat="server" Text="清空重写" OnClick="btn_reset_Click" style="height: 21px" />
        </p>
    </form>
</body>
</html>
