using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Voyage_Guide_Service.Models;

namespace Voyage_Guide_Service.Controllers
{
    [RoutePrefix("api/Auth")]
    public class AuthController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("VoyageLogin")]
        public int userAuthenticate([FromBody]AuthenticateUser user)
        {
            //Creating the instance of the Message Contract Typw which is required to send to the user
            AuthenticateReply authenticateReply = new AuthenticateReply();
            authenticateReply.VoyageisAuthenticated = false;
            //creating the instance of the Conenction
            DbConnection connection = new DbConnection();

            SqlConnection con = connection.connectToDatabase();
            //Creating the instance of the Sql Command Object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //Parameterized query for the Database to authenticate the user
            cmd.CommandText = "Select Id,UserName,userPassword from VoyageUser where UserName=@username and userPassword=@password";
            cmd.Parameters.AddWithValue("@username", user.username);
            cmd.Parameters.AddWithValue("@password", user.password);
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                    authenticateReply.VoyageisAuthenticated = true;
                    authenticateReply.VoyageUserId = Int32.Parse(rdr["Id"].ToString());
                    rdr.Close();
                }
                //rdr.Close();
            }
            catch (Exception ex)
            {
                return -99;

            }
            finally
            {
                //finally closing the Database Connection
                con.Close();

            }
            return authenticateReply.VoyageUserId;
        }
    }
}
