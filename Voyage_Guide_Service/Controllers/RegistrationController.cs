using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

using Voyage_Guide_Service.Models;

namespace Voyage_Guide_Service.Controllers
{
    [RoutePrefix("api/Register")]
    public class RegistrationController : ApiController
    {

        // GET: Registration
       [Route("newVoyageUser")]
        [HttpPost]
        public bool registerNewUser([FromBody]UserRegister user)
        {
            bool result = false;
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();

            string query = "INSERT INTO VoyageUser(FirstName,LastName,EmailAddress,userPassword,UserName)VALUES" +
                "(@firstname,@lastname,@emailaddress,@password,@username)";


            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@firstname", user.firstName);
            cmd.Parameters.AddWithValue("@lastname", user.lastName);
            cmd.Parameters.AddWithValue("@emailaddress", user.email);
            cmd.Parameters.AddWithValue("@password", user.password);
            cmd.Parameters.AddWithValue("@username", user.username);

            try
            {

                con.Open();
                int rows_affected = cmd.ExecuteNonQuery();

                Console.WriteLine("User is succesfully registered");
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User is not registered" + ex.Message);
                result = false;
            }
            finally
            {
                con.Close();

            }
            return result;
        }
    }
}