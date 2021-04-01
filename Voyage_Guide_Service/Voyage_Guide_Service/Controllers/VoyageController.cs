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
    [RoutePrefix("api/Voyage")]
    public class VoyageController : ApiController
    {
        [Route("addData")]
        [HttpPost]
        public bool addNewVoyageData([FromBody]VoyageData data)
        {
            bool result = false;
            //creating the connection to the database
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();
            //create the instance to the SqlCommand Object
            SqlCommand cmd = new SqlCommand();
            //Command Object population to the connection and providing the Query string to the sql command object
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO VoyageData(VoyageUserID,ImageData,VoyageContent,VoyageState,VoyageCity)" +
                "VALUES(@userId,@image,@content,@state,@city)";
            //using the parameterized query
            cmd.Parameters.AddWithValue("@userId", data.UserId);
            cmd.Parameters.AddWithValue("@image", data.imageData);
            cmd.Parameters.AddWithValue("@content", data.VoyageContent);
            cmd.Parameters.AddWithValue("@state", data.VoyageState);
            cmd.Parameters.AddWithValue("@city", data.VoyageCity);

            //try block starting
            try
            {
                //open the connection to database
                con.Open();
                //returns the number of rows affected in the database
                int rows_affected = cmd.ExecuteNonQuery();
                //return the result of the operation
                result = true;
            }
            //starting of the catch block
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                //Closing the Database Connection
                con.Close();

            }
            return result;
        }

        [HttpGet]
        [Route("getNumber")]
        public int getResultNumber(string state,string city)
        {
            int count = 0;
            //creating the instance of the Conenction
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();
            //Creating the instance of the Sql Command Object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //Parameterized query for the Database to authenticate the user
            cmd.CommandText = "Select COUNT(*) from VoyageData where VoyageState=@state and VoyageCity=@city";
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@city", city);
            try
            {
                con.Open();
                count = (Int32)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured:" + ex.Message);
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();

            }

            return count;
        }

        [HttpGet]
        [Route("getData")]
        public ImageDataContent[] getImageDataContent(string state, string city, int results)
        {
            ImageDataContent[] imageDataContentResult = new ImageDataContent[results];
            
            //creating the instance of the Conenction
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();
            
            //Creating the instance of the Sql Command Object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            
            //Parameterized query for the Database to authenticate the user
            cmd.CommandText = "Select VoyageUserID,ImageData,VoyageContent from VoyageData where VoyageState=@state and VoyageCity=@city";
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@city", city);
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    int i = 0;
                    while (rdr.Read())
                    {
                        imageDataContentResult[i] = new ImageDataContent();
                        imageDataContentResult[i].UserId = (Int32)rdr["VoyageUserID"];
                        imageDataContentResult[i].imageData = (byte[])rdr["ImageData"];
                        imageDataContentResult[i].VoyageContent = (String)rdr["VoyageContent"];
                        i++;
                    }
                    rdr.Close();

                    for (int j = 0; j < results; j++)
                    {
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = con;
                        //Parameterized query for the Database to authenticate the user
                        cmd1.CommandText = "Select FirstName,LastName from VoyageUser where Id=@userId";
                        cmd1.Parameters.AddWithValue("@userId", imageDataContentResult[j].UserId);
                        SqlDataReader rdr1 = cmd1.ExecuteReader();
                        rdr1.Read();
                        imageDataContentResult[j].firstName = (string)rdr1["FirstName"];
                        imageDataContentResult[j].lastName = (string)rdr1["LastName"];
                        rdr1.Close();

                    }

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                con.Close();
            }

            return imageDataContentResult;
        }


        [HttpGet]
        [Route("GetById")]
        public ImageDataContent[] getDataById(string state,string city,int results, int id)
        {
            ImageDataContent[] imageDataContentResult = new ImageDataContent[results];

            //creating the instance of the Conenction
            DbConnection connection = new DbConnection();
            SqlConnection con = connection.connectToDatabase();

            //Creating the instance of the Sql Command Object
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            //Parameterized query for the Database to authenticate the user
            cmd.CommandText = "Select VoyageUserID,ImageData,VoyageContent from VoyageData where VoyageState=@state and VoyageCity=@city and VoyageUserId=@Id";
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@Id", id);
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr != null)
                {
                    int i = 0;
                    while (rdr.Read())
                    {
                        imageDataContentResult[i] = new ImageDataContent();
                        imageDataContentResult[i].UserId = (Int32)rdr["VoyageUserID"];
                        imageDataContentResult[i].imageData = (byte[])rdr["ImageData"];
                        imageDataContentResult[i].VoyageContent = (String)rdr["VoyageContent"];
                        i++;
                    }
                    rdr.Close();

                    for (int j = 0; j < results; j++)
                    {
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = con;
                        //Parameterized query for the Database to authenticate the user
                        cmd1.CommandText = "Select FirstName,LastName from VoyageUser where Id=@userId";
                        cmd1.Parameters.AddWithValue("@userId", imageDataContentResult[j].UserId);
                        SqlDataReader rdr1 = cmd1.ExecuteReader();
                        rdr1.Read();
                        imageDataContentResult[j].firstName = (string)rdr1["FirstName"];
                        imageDataContentResult[j].lastName = (string)rdr1["LastName"];
                        rdr1.Close();

                    }

                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            finally
            {
                con.Close();
            }

            return imageDataContentResult;
        }
    }


    
}
