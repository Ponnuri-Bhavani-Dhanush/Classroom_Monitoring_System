using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CMSystem_back.Models;


namespace CMSystem_back.Controllers
{
    public class StudentController : ApiController
    {
        // GET: Student
        /*public ActionResult Index()
        {
            return View();
        }*/

        public HttpResponseMessage Get()
        {
            string query = @"
                select * from
                dbo.Students_table
            ";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["StudentsDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        public String Post(Students stu)
        {
            try
            {
                string query = @"insert into dbo.Students_table values
                                (
                                    '" + stu.Name + @"',
                                    '" + stu.Rollnumber + @"',
                                    '" + stu.Email + @"',
                                    '" + stu.Mobile + @"',
                                    '" + stu.Gender + @"',
                                    '" + stu.Place + @"'
                                )
                                ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["StudentsDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public String Put(Students stu)
        {
            try
            {
                string query = @"update dbo.Students_table set 
                                name = '" + stu.Name + @"',
                                rollnumber = '" + stu.Rollnumber + @"',
                                email = '" + stu.Email + @"',
                                mobile = '" + stu.Mobile + @"',
                                gender = '" + stu.Gender + @"',
                                place = '" + stu.Place + @"'
                                where rollnumber = '" + stu.Rollnumber + @"'
                                ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["StudentsDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }


        public String Delete(string rollnumber)
        {
            try
            {
                string query = @"delete from dbo.Students_table
                                where rollnumber = '" + rollnumber + @"'
                                ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["StudentsDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }


        public HttpResponseMessage GetData(String rollnumber)
        {

            string query = @"select * from dbo.Students_table where rollnumber = '" + rollnumber + @"'";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["StudentsDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }


}
