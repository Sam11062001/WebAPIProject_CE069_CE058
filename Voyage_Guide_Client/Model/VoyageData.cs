using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voyage_Guide_Client.Model
{
    class VoyageData
    {
        public int UserId { get; set; }

        public byte[] imageData { get; set; }

        public string VoyageContent { get; set; }

        public string VoyageState { get; set; }

        public string VoyageCity { get; set; }

    }
}
