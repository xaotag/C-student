using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class Reset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            string mobile = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();
            if (isMobile(mobile, password))
            {
                Label3.Text = "修改成功";
                return;
            }
            Label3.Text = "修改失败";


        }

        private Boolean isMobile(string mobile,string password)
        {
            if (mobile != "")
            {
                string sql = "select mobile from studentInfo where mobile = '" + mobile + "'";
                if (OperaterBase.GetData(sql)!=null)
                {
                    ResetPassword( mobile,  password);
                    return true;
                }

                

            }

            return false;



        }

        private void ResetPassword(string mobile, string password)
        {
            if (password!="")
            {
                string sql = "update studentInfo set password = '" + password + "' where mobile = '" + mobile + "'";
                OperaterBase.commitBySql(sql);
            }
        }

    }
}