﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentInfo.aspx.cs" Inherits="WebApplication4.studentInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style>
        table, tr, td {
            border: 1px solid red;
        }

        td {
            padding: 5px;
        }

        tr, td {
            text-align: center;
        }

        table {
            border-collapse: collapse;
        }
        img {
            width: 50px;
            height: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="mobile" runat="server" Text="查询" OnClick="mobile_Click" />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <HeaderTemplate>
                    <table>

                        <tr>
                            <td>学生ID</td>
                            <td>学生姓名</td>
                            <td>图像</td>
                            <td>学号</td>
                            <td>性别</td>
                            <td>手机号</td>
                            <td>密码</td>
                            <td>生日</td>
                            <td>省份</td>
                            <td>城市</td>
                            <td>地区</td>
                            <td>操作</td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%#Eval("ID") %></td>
                        <td><%#Eval("studentName") %></td>
                        <td><img src='<%#Eval("photoPath") %>'></td>
                        <td><%#Eval("studentNum") %></td>
                        <td><%#Eval("studentSex") %></td>
                        <td><%#Eval("mobile") %></td>
                        <td><%#Eval("password") %></td>
                        <td><%#Eval("birthday") %></td>
                        <td><%#Eval("province") %></td>
                        <td><%#Eval("city") %></td>
                        <td><%#Eval("district") %></td>
                        <td>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit">更新</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="delete">删除</asp:LinkButton>
                        </td>
                        <asp:HiddenField ID="BystudentNum" runat="server" Value='<%#Eval("ID") %>' />
                    </tr>   
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
