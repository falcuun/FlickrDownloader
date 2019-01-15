using System;
using System.Collections.Generic;
using System.Text;

namespace FlickrDownloader
{
    class PhotoModel
    {
        public string id { get; set; } // Photo ID
        public string owner { get; set; } // NSID Of the Photo Owner
        public string secret { get; set; } // Photo Owner's public Secret
        public string server { get; set; } //
        public int farm { get; set; } //
        public string title { get; set; } // Photo's Title
        public int ispublic { get; set; } // Is Photo Public 1/0
        public int isfriend { get; set; } // Are You Friend With User 1/0
        public int isfamily { get; set; } // Are You Family with User 1/0
    }
}
