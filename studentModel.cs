using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public class studentModel
    {
        private string studentName;
        private string studentNum;
        private string studentSex;
        private string mobile;
        private string pwd;
        private string birthday;
        private string province;
        private string city;
        private string district;
        private string classId;

        public string StudentName
        {
            get => studentName;
            set => studentName = value;
        }

        public string StudentNum
        {
            get => studentNum;
            set => studentNum = value;
        }

        public string StudentSex
        {
            get => studentSex;
            set => studentSex = value;
        }

        public string Mobile
        {
            get => mobile;
            set => mobile = value;
        }

        public string Pwd
        {
            get => pwd;
            set => pwd = value;
        }

        public string Birthday
        {
            get => birthday;
            set => birthday = value;
        }

        public string Province
        {
            get => province;
            set => province = value;
        }

        public string City
        {
            
            get => city;
            set => city = value;
        }

        public string District
        {
            get => district;
            set => district = value;
        }

        public string ClassId
        {
            get => classId;
            set => classId = value;
        }
    }
}