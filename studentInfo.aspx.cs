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
        string globalSql = "SELECT  classId, studentName, studentNum, studentSex, mobile, password,birthday, province, city, district, isDelete from studentInfo;";
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
    }
}