using System;
using System.Net;

namespace FlickrDownloader
{
    class DownloaderClass
    {
        private const string GetSizes = "flickr.photos.getSizes&api_key=";
        private const string BASE_URL = "https://api.flickr.com/services/rest/?method=";
        private const string JSONFormatRequest = "&format=json&nojsoncallback=1";

        public static string GenerateGetSizesAPI(string Photo_ID)
        {
            string photo_id = "&photo_id=" + Photo_ID;
            string Photos_GetSizes = BASE_URL + GetSizes + Program.API_KEY + photo_id + JSONFormatRequest;
            return Photos_GetSizes;
        }

        public static void DownloadImage(string URL, string file_path)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFileAsync(new Uri(URL), file_path);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
        }
    }
}
