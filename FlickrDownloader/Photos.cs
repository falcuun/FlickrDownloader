using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Photos
    { 
        public int page { get; set; } // Current Page
        public int pages { get; set; } // Total Number of Pages
        public int perpage { get; set; } // Images Displayed Per Page
        public int total { get; set; } // Total Amout of Images
        public List<PhotoModel> photo { get; set; } // List of all Passed Photos
    }
}
