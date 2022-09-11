using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Smart_Cooking_App.Interfaces;
using Smart_Cooking_App.Models;



namespace Smart_Cooking_App.Repositories
{
    public class UserrRepository : Controller, IUserRepo
    {
        public IActionResult addUser(Userr u)
        {
            //*************************ADD INTO DATABASE******************************** 
            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartCookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string Query = "insert into [Userr] (Name,Email,Password,Username) values(@n,@e,@p,@u)";
            SqlParameter p1 = new SqlParameter("n", u.Name);
            SqlParameter p2 = new SqlParameter("p", u.Password);
            SqlParameter p3 = new SqlParameter("e", u.Email);
            SqlParameter p4 = new SqlParameter("u", u.Username);
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.ExecuteNonQuery();
            con.Close();
            return View();
        }
        public IList<Userr> GetUser()
        {

            IList<Userr> List = new List<Userr>();
            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartCookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string Query = "select* from [Userr]";
            SqlCommand cmd = new SqlCommand(Query, con);

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Userr u = new Userr();
                u.Name = dr[1].ToString();
                u.Username = dr[2].ToString();
                u.Email= dr[3].ToString();
                u.Password=dr[4].ToString();
                u.Role=dr[6].ToString();
                List.Add(u);

            }
            con.Close();

            return List;
        }
        public bool UserExist(Userr u)
        {

            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartCookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string Query = "select* from [Userr] where Email=@e and Password=@p";
            SqlParameter p1, p2;

            p1 = new SqlParameter("e", u.Email);
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
        public bool UserExistForLogin(Userr u)
        {

            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartCookingApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            string Query = "select* from [Userr] where Username=@u or Email=@e";
            SqlParameter p1, p4;

            p1 = new SqlParameter("u", u.Username);
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
