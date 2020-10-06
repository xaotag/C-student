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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string studentName = TextBox9.Text.Trim();
            string studentNum = TextBox1.Text.Trim();
            string studentSex = TextBox2.Text.Trim();
            string Mobile = TextBox3.Text.Trim();
            string pwd = TextBox4.Text.Trim();
            string birthday = TextBox5.Text.Trim();
            string province = TextBox6.Text.Trim();
            string city = TextBox7.Text.Trim();
            string district = TextBox8.Text.Trim();
            string studentClassId = TextBox10.Text.Trim();

            string sql = @"INSERT INTO studentInfo (studentName,studentNum,studentSex,mobile,password,birthday,province,city,district,classId) VALUES  (N'" + studentName + "',N'" + studentNum + "',N'" + studentSex + "',N'" + Mobile + "',N'"
+ pwd + "','" + birthday + "',N'" + province + "',N'" + city + "',N'" + district + "', N'" + studentClassId + "')";
            //判断手机号是否唯一
            if (IsMobile(studentNum, Mobile))
            {

                if (OperaterBase.commitBySql(sql) > 0)
                {
                    Label11.Text = "插入成功";
                    Response.Redirect("studentInfo.aspx");
                }
            }
            else
            {
                Label11.Text = "插入失败 。。。。";

            }
        }

        /// <summary>
        /// 判断手机号是否唯一
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns>true or false</returns>
        private Boolean IsMobile(string studentNum, string mobile)
        {

            string sql = "select mobile , studentNum from studentInfo where  studentNum = '" + studentNum + "' or  mobile = '" +mobile+"'";
            DataSet ds = OperaterBase.GetData(sql);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                return true;
            }
            return false;
        }


    }
}