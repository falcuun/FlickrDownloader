using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace FlickrDownloader
{
    class FlickrConnection
    {
        #region Private
        private static readonly HttpClient client = new HttpClient();
        private JSONObjectGenerator jog = new JSONObjectGenerator();

        private const string BASE_URL = "https://api.flickr.com/services/rest/?method=";
        private const int DEFAULT_IMAGE_NUMBER = 100;
        private const int DEFAULT_PAGE_NUMBER = 1;
        private int Images_Per_Page;
        private int Number_Of_Pages;

        #region Flickr Format Request
        private const string JSONFormatRequest = "&format=json&nojsoncallback=1";
        #endregion

        #region Flickr Methods
        private const string Galleries_GetPHotos = "flickr.galleries.getPhotos&api_key=";
        private const string People_NSID = "flickr.urls.lookupUser&api_key=";
        private const string GetPublicPhotos = "flickr.people.getPublicPhotos&api_key=";
        private const string GetSizes = "flickr.photos.getSizes&api_key=";
        #endregion



        #endregion



        #region Public
        public string API_KEY { get; set; }
        public FlickrConnection() { }

        private static async Task<string> GetMessage(string url)
        {
            var responseString = await client.GetStringAsync(url);
            return responseString;
        }

        #region Public Methods
        /*
          Checks if the API Key varriable is Empty or not 

       */
        public bool CheckAPIKey(string Key)
        {
            if (Key.Equals(""))
            {
                Console.WriteLine("Incorrect API Key, Try Again: ");
                return false;
            }
            else
            {
                API_KEY = Key;
                return true;
            }
        }
        /*
         Using flickr.urls.lookupUser& API Method to get User NSID
        */
        public string GenerateLookUpUserAPI(string User_URL)
        {
            string NSID = "";
            string USER_URL = "&url=\"" + User_URL + "\"";
            string UserNSIDAPIUrl = BASE_URL + People_NSID + API_KEY + USER_URL + JSONFormatRequest;
            NSID = jog.GetUserNSID(GetMessage(UserNSIDAPIUrl).Result);
            return NSID;
        }

        public bool Per_Page(string PerPage)
        {
            try
            {
                int num = Int32.Parse(PerPage);
                if (num > 500)
                {
                    Images_Per_Page = 500;
                }
                else
                {
                    Images_Per_Page = num;
                }
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Per Page Number is not correct. Try again");
                return false;
            }
        }

        public bool Num_Pages(string PagesNumber)
        {
            try
            {
                int num = Int32.Parse(PagesNumber);
                if (num <= 1)
                {
                    Number_Of_Pages = 1;
                }
                else
                {
                    Number_Of_Pages = num;
                }
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Number of Pages is not correct. Try again");
                return false;
            }
        }

        public string GenerateGetSizesAPI(string Photo_ID)
        {
            string photo_id = "&photo_id=" + Photo_ID;
            string Photos_GetSizes = BASE_URL + GetSizes + API_KEY + photo_id + JSONFormatRequest;
            return Photos_GetSizes;
        }

        public void DownloadPublicPhotos(string User_URL, string Download_Location)
        {
            string UserID = "&user_id=" + GenerateLookUpUserAPI(User_URL);

            for (int i = 1; i <= Number_Of_Pages; i++)
            {
                string PublicPhotosAPIUrl = BASE_URL + GetPublicPhotos + API_KEY + UserID + "&per_page=" + Images_Per_Page + "&page=" + i + "&format=json&nojsoncallback=1";
                string DL_Loc = Download_Location + "\\";
                Console.WriteLine(PublicPhotosAPIUrl);
                jog.GetPhotoId(GetMessage(PublicPhotosAPIUrl).Result);
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        foreach (string Photo_ID in jog.ListOfIDs)
                        {
                            string DownloadLink = jog.GetSizeDownload(GetMessage(GenerateGetSizesAPI(Photo_ID)).Result);
                            Console.WriteLine(DownloadLink);
                            client.DownloadFile(DownloadLink, DL_Loc + Photo_ID + ".jpg");
                            Console.WriteLine(DL_Loc + Photo_ID + ".jpg");
                        }
                        jog.EmptyListOfIDs();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message + " --MAIN METHOD " + Download_Location);
                }
            }
        }
        #endregion

        #endregion
    }
}
