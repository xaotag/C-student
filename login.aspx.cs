using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string user = TextBox1.Text.Trim();
            string pwd = TextBox2.Text.Trim();
            string sql = "SELECT studentNum,password FROM studentInfo WHERE studentNum = " + user + " AND password = " + pwd;
            if (OperaterBase.GetData(sql) != null)
            {
                Button1.Text = "登录成功";
            }
            else
            {
                Button1.Text = "登录失败";
            }
            Response.Redirect("studentInfo.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reset.aspx");
        }
    }
}