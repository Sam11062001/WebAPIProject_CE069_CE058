using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage_Guide_Client.Model
{
    class ImageDataContent
    {
        public int UserId { get; set; }


        public string firstName { get; set; }


        public string lastName { get; set; }


        public byte[] imageData { get; set; }


        public string VoyageContent { get; set; }
    }
}
