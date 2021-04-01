using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voyage_Guide_Service.Models
{
    public class VoyageData
    {
       
        public int UserId { get; set; }

        public byte[] imageData { get; set; }

        public string VoyageContent { get; set; }

        public string VoyageState { get; set; }

        public string VoyageCity { get; set; }

    }
}