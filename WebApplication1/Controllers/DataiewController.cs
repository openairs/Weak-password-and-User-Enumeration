using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace WebApplication1.Controllers
{
    public class DataiewController : Controller
    {
        public IActionResult ViewUser()
        {
            string mainconn = ConfigurationManager.ConnectionStrings["WebApplication1ContextConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "SELECT TOP (1000) [Id] ,[FirstName] ,[LastName] ,[UserName],[NormalizedUserName],[Password] FROM[NewMVCAuthDB].[dbo].[AspNetUsers]";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<DataClass> ec = new List<DataClass>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ec.Add(new DataClass
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    FirstName = Convert.ToString(dr["FirstName"]),
                    LastName = Convert.ToString(dr["LasttName"]),
                    UserName = Convert.ToString(dr["UserName"]),
                    Password = Convert.ToString(dr["Password"]),
                });
            }
            ViewData["Datalist"] = ec;
            return View();
        }
    }
}
