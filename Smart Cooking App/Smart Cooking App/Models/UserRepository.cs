using Microsoft.AspNetCore.Mvc;
using Smart_Cooking_App.Models;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
namespace Smart_Cooking_App.Models
{
    public class UserRepository : Controller
    {
        public IActionResult addUser(User u)
        {
            //*************************ADD INTO DATABASE******************************** 

            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartCookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string Query = "insert into [User] (UserName,Password,Email) values(@n,@p,@e)";
            SqlParameter p1 = new SqlParameter("n", u.Name);
            SqlParameter p2 = new SqlParameter("p", u.Password);
            SqlParameter p3 = new SqlParameter("e", u.Email);
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.ExecuteNonQuery();
            con.Close();
            return View();

        }
        public IList<User> GetUser()
        {
            IList<User> List = new List<User>();
            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartCookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string Query = "select* from [User]";
            SqlCommand cmd = new SqlCommand(Query, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                User u = new User();
                u.Name = dr[1].ToString();
                u.Password = dr[2].ToString();
                u.Email= dr[3].ToString();
                List.Add(u);

            }
            con.Close();

            return List;
        }
        public bool UserExist(User u)
        {

            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartCookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string Query = "select* from [User] where UserName=@n and Password=@p";
            SqlParameter p1, p2;

            p1 = new SqlParameter("n", u.Name);
            SqlCommand cmd = new SqlCommand(Query, con);
            p2= new SqlParameter("p", u.Password);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("Emaill added");
                con.Close();
                return true;

            }

            con.Close();
            return false;
        }
        public bool UserExistForLogin(User u)
        {

            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartCookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string Query = "select* from [User] where UserName=@n or Email=@e";
            SqlParameter p1, p4;

            p1 = new SqlParameter("n", u.Name);
            SqlCommand cmd = new SqlCommand(Query, con);
            p4 = new SqlParameter("e", u.Email);
            cmd.Parameters.Add(p4);


            cmd.Parameters.Add(p1);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("Emaill added");
                con.Close();
                return true;

            }

            con.Close();
            return false;
        }
    }
}
