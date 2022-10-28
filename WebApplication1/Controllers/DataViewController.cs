using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Controllers
{
    public class DataViewController : Controller
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        

        public void Index()

        {
            string mainconn = "Data Source=ADMIN-MACHINE-1\\SQLEXPRESS; Initial Catalog=NewMVCAuthDB;Integrated Security=True; TrustServerCertificate=True";
            SqlConnection sqlConn = new SqlConnection(mainconn);
            sqlConn.Open();
            string sqlquery = "SELECT TOP (1000) [Id] ,[FirstName] ,[LastName] ,[UserName],[NormalizedUserName],[Password] FROM[NewMVCAuthDB].[dbo].[AspNetUsers]";
            SqlCommand sqlcmd = new SqlCommand(sqlquery, sqlConn);
            SqlDataReader dr = sqlcmd.ExecuteReader();
            if (dr.Read())
            {
                Id = (int)dr["Id"];
                FirstName = dr["FirstName"].ToString();
                LastName = dr["LasttName"].ToString();
                UserName = dr["UserName"].ToString();
                Password = dr["PasswordHash"].ToString();
            }
            sqlConn.Close();
            /*SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);

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
                    Password = Convert.ToString(dr["PasswordHash"]),
                });
            }
            ViewData["Datalist"] = ec;
            return View();*/
        }
    }
}
