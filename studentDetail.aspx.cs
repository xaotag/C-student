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
            if (!IsPostBack)
            {
                int ID = Convert.ToInt32(Request["ID"]);
                if (ID > 0)
                {
                    Button2.CommandName = "updata";
                    fillData(ID);
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            addUser();
        }

        private void addUser()
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
            string classId = TextBox10.Text.Trim();

            if (Button2.CommandName == "insert")
            {
                string sql = @"INSERT INTO studentInfo (studentName,studentNum,studentSex,mobile,password,birthday,province,city,district,classId) VALUES  (N'" + studentName + "',N'" + studentNum + "',N'" + studentSex + "',N'" + Mobile + "',N'"
+ pwd + "','" + birthday + "',N'" + province + "',N'" + city + "',N'" + district + "', N'" + classId + "')";
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
            else if (Button2.CommandName == "updata")
            {
                // 更新数据
                string upData = "update studentInfo set studentName = N'" + studentName + "', studentNum = N'" + studentNum + "' ,studentSex = N'" + studentSex + "', mobile = N'" + Mobile + "' , password = N'" + pwd + "', birthday = N'" + birthday + "',pro" +
                    "vince = N' "+province+"', city = N'" + city + "',district = N'" + district + " ', classId = 'N" + classId + "'";
                if (OperaterBase.commitBySql(upData) > 0)
                {
                    Label11.Text = "修改成功";
                }
            }

        }
        /// <summary>
        /// 判断手机号是否唯一
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns>true or false</returns>
        private Boolean IsMobile(string studentNum, string mobile)
        {

            string sql = "select mobile , studentNum from studentInfo where  studentNum = '" + studentNum + "' or  mobile = '" + mobile + "'";
            DataSet ds = OperaterBase.GetData(sql);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 把数据 填入框里面
        /// </summary>
        /// <param name="StudentID"></param>
        private void fillData(int StudentID)
        {
            string Bysql = "select * from studentInfo where ID = " + StudentID;
            DataSet ds = OperaterBase.GetData(Bysql);
            TextBox1.Text = ds.Tables[0].Rows[0]["studentNum"].ToString();
            TextBox2.Text = ds.Tables[0].Rows[0]["studentSex"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
            TextBox4.Text = ds.Tables[0].Rows[0]["password"].ToString();
            TextBox5.Text = ds.Tables[0].Rows[0]["birthday"].ToString();
            TextBox6.Text = ds.Tables[0].Rows[0]["province"].ToString();
            TextBox7.Text = ds.Tables[0].Rows[0]["city"].ToString();
            TextBox8.Text = ds.Tables[0].Rows[0]["district"].ToString();
            TextBox10.Text = ds.Tables[0].Rows[0]["classId"].ToString();
            TextBox9.Text = ds.Tables[0].Rows[0]["studentName"].ToString();
        }


    }
}