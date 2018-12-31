using System;
using System.Collections.Generic;
using System.Text;

namespace FlickrDownloader
{
    class JSON
    {
        public Sizes sizes { get; set; } // Object For Sizes JSON Response
        public Photos photos { get; set; } // Object For Photos JSON Response
        public UserModel user { get; set; } // Object For User JSON Response
    }
}
