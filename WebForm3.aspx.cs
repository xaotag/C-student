using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropList1();
            }
        }

        private void DropList1()
        {
            string sql = "select sp.ProvinceName,sp.ProvinceID from S_Province sp";
            DataSet ds = OperaterBase.GetData(sql);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "ProvinceName";
            DropDownList1.DataValueField = "ProvinceID";
            DropDownList1.DataBind();


        }
        private void DropList2()
        {
            int value = Convert.ToInt32(DropDownList1.SelectedValue);
            string sql = "SELECT * FROM S_City WHERE ProvinceID = "+value;
            DataSet ds = OperaterBase.GetData(sql);
            DropDownList2.DataSource = ds;
            DropDownList2.DataTextField = "CityName";
            DropDownList2.DataValueField = "CityID";
            DropDownList2.DataBind();


        }
        private void DropList3()
        {
            int value = Convert.ToInt32(DropDownList2.SelectedValue);
            string sql = "SELECT * FROM S_District WHERE CityID = " + value;
            DataSet ds = OperaterBase.GetData(sql);
            DropDownList3.DataSource = ds;
            DropDownList3.DataTextField = "DistrictName";
            DropDownList3.DataValueField = "DistrictID";
            DropDownList3.DataBind();


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropList2();
            DropList3();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropList3();
        }
    }
}