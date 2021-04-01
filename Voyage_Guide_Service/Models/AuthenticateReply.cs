using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voyage_Guide_Service.Models
{
    public class AuthenticateReply
    {
        private int UserId;
        private bool isAuthenticated;


        public int VoyageUserId
        {
            get { return UserId; }
            set
            {
                UserId = value;
            }
        }

        public bool VoyageisAuthenticated
        {
            get { return isAuthenticated; }
            set
            {
                isAuthenticated = value;
            }
        }
    }
}