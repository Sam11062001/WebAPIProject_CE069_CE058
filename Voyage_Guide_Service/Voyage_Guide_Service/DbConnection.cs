using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Voyage_Guide_Service
{
    public class DbConnection
    {

        public SqlConnection connectToDatabase()
        {
            //create the instance of the connection string 
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\Voyage_Guide_Service\Voyage_Guide_Service\App_Data\VoyageGuideRestApi.mdf;Integrated Security=True");
            
            //returning the  connection object 
            return con;
        }

    }
}