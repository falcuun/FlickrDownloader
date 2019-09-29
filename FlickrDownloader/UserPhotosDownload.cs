using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace FlickrDownloader
{
    class UserPhotosDownload
    {
        private JSONObjectGenerator jog = new JSONObjectGenerator(); // JSONObjectGenerator class Object

        private const string BASE_URL = "https://api.flickr.com/services/rest/?method="; // Base URL For Flickr APIs
        private const string JSONFormatRequest = "&format=json&nojsoncallback=1";
        private const string People_NSID = "flickr.urls.lookupUser&api_key="; // Urls LookUpUser 
        private const string GetPublicPhotos = "flickr.people.getPublicPhotos&api_key="; // People GetPublicPhotos 
        private int Images_Per_Page; // User Entered Number of Images per Page
        private int Number_Of_Pages; // User Entered Number of Pages

        public string GenerateUserID(string User_URL)
        {
            string NSID = "";
            string USER_URL = "&url=\"" + User_URL + "\"";
            string UserNSIDAPIUrl = BASE_URL + People_NSID + DownloaderView.API_KEY + USER_URL + JSONFormatRequest;
            NSID = jog.GetUserNSID(jog.GetMessage(UserNSIDAPIUrl).Result);
            return "&user_id=" + NSID;
        }

        public bool Per_Page(string PerPage)
        {
            try
            {
                int num = int.Parse(PerPage);
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
                int num = int.Parse(PagesNumber);
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

        private string GenerateUserPublicPhotosURL(string user_url, int page_index)
        {
            return BASE_URL + GetPublicPhotos + DownloaderView.API_KEY + GenerateUserID(user_url) + "&per_page=" + Images_Per_Page + "&page=" + page_index + "&format=json&nojsoncallback=1";
        }

        private string FormDownloadPath(string path, string photo_id)
        {
            return path + "\\" + photo_id + ".jpg";
        }

        public void ObtainUserPublicPhotos(string User_URL, string Download_Location)
        {
            for (int i = 1; i <= Number_Of_Pages; i++)
            {
                jog.PopulateListOfPhotoIDs(jog.GetMessage(GenerateUserPublicPhotosURL(User_URL, i)).Result);
                foreach (string Photo_ID in jog.ListOfPhotoIDs)
                {
                    string DownloadLink = jog.GetSizeDownload(jog.GetMessage(DownloaderClass.GenerateGetSizesAPI(Photo_ID)).Result);
                    DownloaderClass.DownloadImage(DownloadLink, FormDownloadPath(Download_Location, Photo_ID));
                }
                jog.FlushTheListOfIDs();
            }
            Console.WriteLine("Download Complete");
        }
    }
}
