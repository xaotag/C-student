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
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetClassList();
            
            int ID = Convert.ToInt32(Request["ID"]);
            if (ID > 0)
            {
                Button2.CommandName = "updata";
                id = ID;
                FillData(ID);
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            AddUser();
        }

        /// <summary>
        /// 将 studentDetail 输入框的值 封装为 stduentModel 返回
        /// </summary>
        /// <returns></returns>
        private studentModel FillStudentModelData()
        {
            
            studentModel stu = new studentModel();
            stu.StudentName = TextBox9.Text.Trim();
            stu.StudentNum = TextBox1.Text.Trim();
            stu.StudentSex = TextBox2.Text.Trim();
            stu.Mobile = TextBox3.Text.Trim();
            stu.Pwd = TextBox4.Text.Trim();
            stu.Birthday = TextBox5.Text.Trim();
            stu.Province = TextBox6.Text.Trim();
            stu.City = TextBox7.Text.Trim();
            stu.District = TextBox8.Text.Trim();
            stu.ClassId = TextBox10.Text.Trim();
            return stu;
        }
        /// <summary>
        /// 添加一个学生信息
        /// </summary>
        private void AddUser()
        {
            studentModel stu = FillStudentModelData();
            if(stu==null)return;
            if (Button2.CommandName == "insert")
            {
                //判断学号或手机号是否唯一 
                if (IsMobile(stu.StudentNum, stu.Mobile))
                {
                    //如果学号或手机号码 不是唯一的 进行 insert 语句拼接 并执行
                    string sql = @"INSERT INTO studentInfo (studentName,studentNum,studentSex,mobile,password,birthday,province,city,district,classId) VALUES  (N'" + stu.StudentName + "',N'" + stu.StudentNum + "',N'" + stu.StudentSex + "',N'" + stu.Mobile + "',N'"
                                 + stu.Pwd + "','" + stu.Birthday + "',N'" + stu.Province + "',N'" + stu.City + "',N'" + stu.District + "', N'" + stu.ClassId + "')";
                    if (OperaterBase.CommitBySql(sql) > 0)
                    {
                        Label11.Text = "插入成功";
                        // 跳转
                        Response.Redirect("/studentInfo.aspx");
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
                string upData = "update studentInfo set studentName = N'" + stu.StudentName + "', studentNum = N'" + stu.StudentNum + "' ,studentSex = N'" + stu.StudentSex + "', mobile = N'" + stu.Mobile + "' , password = N'" + stu.Pwd + "', birthday = N'" + stu.Birthday + "',pro" +
                    "vince = N' " + stu.Province + "', city = N'" + stu.City + "',district = N'" + stu.District + " ', classId = 'N" + stu.ClassId + "'";
                if (OperaterBase.CommitBySql(upData) > 0)
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
        private void FillData(int StudentID) 
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

        private void GetClassList()
        {
            string sql = "select * from ClassInfo";
            DataSet ds = OperaterBase.GetData(sql);
            DropDownList1.DataSource = ds;
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataTextField = "className";
            DropDownList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UpdataPhoto(id);
        }
        private void UpdataPhoto(int id)
        {
            PhotoUpload photo = new PhotoUpload();

            if (FileUpload1.HasFile)
            {
                FileModel fileModel = photo.Upload(FileUpload1.FileName);
                FileUpload1.SaveAs(fileModel.AbsoluteFileName);
                if (photo.SavePhotoPath(fileModel.RelativeFileName, id))
                {
                    Image1.ImageUrl = fileModel.RelativeFileName;
                }
            }
        }
    }
}