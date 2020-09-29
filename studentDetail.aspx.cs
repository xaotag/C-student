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

 
        protected void Button1_Click1(object sender, EventArgs e)
        {
            //查询
            string con = ConfigurationManager.ConnectionStrings["xaotag"].ConnectionString;
            SqlConnection sct = new SqlConnection(con);
            string sql = "SELECT   classId, studentName, studentNum, studentSex, mobile, password,birthday, province, city, district, isDelete from studentInfo;";
            SqlDataAdapter sqlData = new SqlDataAdapter(sql, sct);
            DataSet ds = new DataSet();
            sqlData.Fill(ds);
            GridView1.DataSource = ds.Tables[0].DefaultView;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string studentName = TextBox9.Text; 
            string studentNum = TextBox1.Text;
            string studentSex = TextBox2.Text;
            string Mobile = TextBox3.Text;
            string pwd = TextBox4.Text;
            string birthday = TextBox5.Text;
            string province = TextBox6.Text;
            string city = TextBox7.Text;
            string district = TextBox8.Text;
            string studentClassId = TextBox10.Text ;
            
            string sql = @"INSERT INTO studentInfo (studentName,studentNum,studentSex,mobile,password,birthday,province,city,district,classId) VALUES (N'" + studentName + "',N'" + studentNum + "',N'" + studentSex + "',N'" + Mobile + "',N'" 
+ pwd + "','" + birthday + "',N'" + province + "',N'" + city + "',N'" + district + "', N'" + studentClassId + "')";


            string con = ConfigurationManager.ConnectionStrings["xaotag"].ConnectionString;
            SqlConnection sct = new SqlConnection(con);
            SqlCommand command = new SqlCommand(sql, sct);
            sct.Open();
            int flag = command.ExecuteNonQuery();
            sct.Close();
            if (flag > 0)
            {
                Label11.Text = "插入成功";
            }

        }
    }
}