using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voyage_Guide_Service.Models
{
    public class ImageDataContent
    {
       
        public int UserId { get; set; }

      
        public string firstName { get; set; }

      
        public string lastName { get; set; }

       
        public byte[] imageData { get; set; }

      
        public string VoyageContent { get; set; }
    }
}