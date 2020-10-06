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
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "SELECT  classId, studentName, studentNum, studentSex, mobile, password,birthday, province, city, district, isDelete from studentInfo;";
            DataSet ds = OperaterBase.GetData(sql);
            Repeater1.DataSource = ds;
            Repeater1.DataBind();
        }
    }
}