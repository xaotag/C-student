﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public class OperaterBase
    {
        private static SqlConnection getconn()
        {
            string conn = ConfigurationManager.ConnectionStrings["xaotag"].ConnectionString;
            return new SqlConnection(conn);
        }

        public static DataSet GetData(string sql)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql, getconn());
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public static int commitBySql(string sql)
        {
            SqlConnection sqlConnection = getconn();
            SqlCommand scd = new SqlCommand(sql, sqlConnection);
            sqlConnection.Open();
            int flag = scd.ExecuteNonQuery();
            sqlConnection.Close();
            return flag;
        }

    }
}