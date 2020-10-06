using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class studentInfo : System.Web.UI.Page
    {
        string globalSql = "SELECT  ID, studentName, studentNum, studentSex, mobile, password,birthday, province, city, district, isDelete from studentInfo where isDelete = 0;";
        /// <summary> 
        /// 获取学生列表
        /// </summary>
        private void getStudentList(string sql)
        {
            DataSet ds = OperaterBase.GetData(sql);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            getStudentList(globalSql);
        }

        /// <summary>
        /// 通过手机号码搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void mobile_Click(object sender, EventArgs e)
        {
            string Mobile = TextBox1.Text.Trim();
            if (Mobile == "")
            {
                getStudentList(globalSql);
            }
            else
            {
                string sql = "SELECT  classId, studentName, studentNum, studentSex, mobile, password,birthday, province, city, district, isDelete from studentInfo" +
                    " where mobile = '" + Mobile + "' and isDelete = 0;";
                getStudentList(sql);
            }

        }
        /// <summary>
        /// 接受 参数
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int ID = Convert.ToInt32(((HiddenField)e.Item.FindControl("BystudentNum")).Value);
            if (e.CommandName == "edit")
            {
                Response.Redirect("/studentDetail.aspx?ID=" + ID + "");

            }
            else if (e.CommandName == "delete")
            {
                isDelSql(ID);
            }
        }
        /// <summary>
        /// 逻辑删除
        /// </summary>
        private void isDelSql(int ID)
        {
            string delSql = "UPDATE studentInfo set isDelete = 1 where ID = " + ID + ";";
            if (OperaterBase.commitBySql(delSql) > 0)
            {
                string DelSql = "SELECT  ID, studentName, studentNum, studentSex, mobile, password,birthday, province, city, district, isDelete from studentInfo where isDelete = 0;";
                getStudentList(DelSql);
            }
        }
    }
}