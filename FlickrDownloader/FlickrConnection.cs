//using System;
//using System.Net.Http;
//using System.Threading.Tasks;

//namespace FlickrDownloader
//{
//    class FlickrConnection
//    {
//        /* Declaring Private Variables
//         */
//        #region Private
//        private static readonly HttpClient client = new HttpClient(); // HTTP Client for Establishing Connection
//        private JSONObjectGenerator jog = new JSONObjectGenerator(); // JSONObjectGenerator class Object

//        private const string BASE_URL = "https://api.flickr.com/services/rest/?method="; // Base URL For Flickr APIs
//        private const int DEFAULT_IMAGE_NUMBER = 100; // Default Number Of Images shown per page
//        private const int DEFAULT_PAGE_NUMBER = 1; // Default Page
//        private int Images_Per_Page; // User Entered Number of Images per Page
//        private int Number_Of_Pages; // User Entered Number of Pages

//        #region Flickr Format Request
//        private const string JSONFormatRequest = "&format=json&nojsoncallback=1";
//        #endregion

//        #region Flickr Methods
//        private const string Galleries_GetPHotos = "flickr.galleries.getPhotos&api_key="; // Galleries GetPhotos 
//        private const string People_NSID = "flickr.urls.lookupUser&api_key="; // Urls LookUpUser 
//        private const string GetPublicPhotos = "flickr.people.getPublicPhotos&api_key="; // People GetPublicPhotos 
//        private const string GetSizes = "flickr.photos.getSizes&api_key="; // Photos GetSizes
//        private const string Search_By_Text = "flickr.photos.search&api_key=";
//        #endregion
//        #region Private Methods

//        #endregion
//        #endregion
//        #region Public
//        /* Declaring Public Variables
//         */
//        public string API_KEY { get; set; }
//        public FlickrConnection() { }

//        #region Public Methods
//        /*
//          Checks if the API Key varriable is Empty or not 

//       */
//        public bool CheckAPIKey(string Key)
//        {
//            if (Key.Equals(""))
//            {
//                Console.WriteLine("Incorrect API Key, Try Again: ");
//                return false;
//            }
//            else
//            {
//                API_KEY = Key;
//                return true;
//            }
//        }
//        /*
//         Using flickr.urls.lookupUser& API Method to get User NSID
//         Calling GetUserNSID Methods From JSONObjectGenerator Class that takes a JSON Response string as Argument
//         Parses it, and returns the Flickr User NSID.
//        */
//        public string GenerateLookUpUserAPI(string User_URL)
//        {
//            string NSID = "";
//            string USER_URL = "&url=\"" + User_URL + "\"";
//            string UserNSIDAPIUrl = BASE_URL + People_NSID + API_KEY + USER_URL + JSONFormatRequest;
//            NSID = jog.GetUserNSID(GetMessage(UserNSIDAPIUrl).Result);
//            return NSID;
//        }
//        /*
//         * For Now, takes in a desired number as an argument and checks if it's larger than 500 (Max images per page). 
//         */
//        public bool Per_Page(string PerPage)
//        {
//            try
//            {
//                int num = int.Parse(PerPage);
//                if (num > 500)
//                {
//                    Images_Per_Page = 500;
//                }
//                else
//                {
//                    Images_Per_Page = num;
//                }
//                return true;
//            }
//            catch (FormatException)
//            {
//                Console.WriteLine("Per Page Number is not correct. Try again");
//                return false;
//            }
//        }
//        /*
//         * For Now, takes in a desired number as an argument and checks if it's smaller than 1 (Max images per page). 
//         */
//        public bool Num_Pages(string PagesNumber)
//        {
//            try
//            {
//                int num = int.Parse(PagesNumber);
//                if (num <= 1)
//                {
//                    Number_Of_Pages = 1;
//                }
//                else
//                {
//                    Number_Of_Pages = num;
//                }
//                return true;
//            }
//            catch (FormatException)
//            {
//                Console.WriteLine("Number of Pages is not correct. Try again");
//                return false;
//            }
//        }
//        /*
//         * Takes in a Photo_ID and forms a complete API Url for Flickr's GetSizes Method and returns it.
//         */
//        public string GenerateGetSizesAPI(string Photo_ID)
//        {
//            string photo_id = "&photo_id=" + Photo_ID;
//            string Photos_GetSizes = BASE_URL + GetSizes + API_KEY + photo_id + JSONFormatRequest;
//            return Photos_GetSizes;
//        }
//        /*
//         * Takes in Flickr User URL as an argument along with Location where the images should be saved and then it downloads the images one by one
//         * From the List of Photo Ids from JSON Object Generator Class And then Flushes the List for new IDs to be filled in from the next page.
//         */
//        public void DownloadUserPublicPhotos(string User_URL, string Download_Location)
//        {
//            string UserID = "&user_id=" + GenerateLookUpUserAPI(User_URL);
//            for (int i = 1; i <= Number_Of_Pages; i++)
//            {
//                string PublicPhotosAPIUrl = BASE_URL + GetPublicPhotos + API_KEY + UserID + "&per_page=" + Images_Per_Page + "&page=" + i + "&format=json&nojsoncallback=1";
//                jog.User_Information(GetMessage(PublicPhotosAPIUrl).Result, Images_Per_Page);
//                string DL_Loc = Download_Location + "\\";
//                Console.WriteLine(PublicPhotosAPIUrl);

//                jog.PopulateListOfPhotoIDs(GetMessage(PublicPhotosAPIUrl).Result);

//                foreach (string Photo_ID in jog.ListOfPhotoIDs)
//                {
//                    string DownloadLink = jog.GetSizeDownload(GetMessage(GenerateGetSizesAPI(Photo_ID)).Result);
//                    DownloaderClass.DownloadFile(DownloadLink, Download_Location);
//                }
//                jog.FlushTheListOfIDs();
//            }
//        }
//        #endregion

//        #endregion
//    }
//}
