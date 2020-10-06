<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentDetail.aspx.cs" Inherits="WebApplication4.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        #box {
            width:300px;
            display:inline-block;
        }
        input[type="text" i] {
         float:right;
        }
        #box span{
            display:inline-block;
            padding:3px 0 ;
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <div id="box">

                <asp:Label ID="Label9" runat="server" Text="学生姓名"></asp:Label><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label1" runat="server" Text="学号"></asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label2" runat="server" Text="性别"></asp:Label><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label3" runat="server" Text="电话"></asp:Label><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label4" runat="server" Text="密码"></asp:Label><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label5" runat="server" Text="生日"></asp:Label><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label6" runat="server" Text="省份"></asp:Label><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label7" runat="server" Text="城市"></asp:Label><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label8" runat="server" Text="详细信息"></asp:Label><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox><br />

                <asp:Label ID="Label10" runat="server" Text="班级编号"></asp:Label><asp:TextBox ID="TextBox10" runat="server"></asp:TextBox><br />

                <asp:Button ID="Button2" runat="server" Text="插入" OnClick="Button2_Click" /><asp:Label ID="Label11" runat="server"></asp:Label>
                <div></div>
            </div>
        </div>
    </form>
</body>
</html>
