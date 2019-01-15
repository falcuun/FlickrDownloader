using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrDownloader
{
    class TextSearchPhotosDownload
    {
        private const string BASE_URL = "https://api.flickr.com/services/rest/?method="; // Base URL For Flickr APIs
        private const string JSONFormatRequest = "&format=json&nojsoncallback=1";
        private const string Search_By_Text = "flickr.photos.search&api_key=";
        private int Images_Per_Page; // User Entered Number of Images per Page
        private int Number_Of_Pages; // User Entered Number of Pages

        JSONObjectGenerator jog = new JSONObjectGenerator();

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

        private string GenerateTextSearchURL(string query, int page_index)
        {
            string url = BASE_URL + Search_By_Text + Program.API_KEY + "&tags=" + query + "&per_page=" + Images_Per_Page + "&page=" + page_index + JSONFormatRequest;
            return url;
        }

        private string FormDownloadPath(string path, string photo_id)
        {
            return path + "\\" + photo_id + ".jpg";
        }

        public void ObtainSearchedPhotos(string path, string query)
        {
            for (int i = 1; i <= Number_Of_Pages; i++)
            {
                jog.PopulateListOfPhotoIDs(jog.GetMessage(GenerateTextSearchURL(query, i)).Result);
                foreach (string Photo_ID in jog.ListOfPhotoIDs)
                { 
                    string DownloadLink = jog.GetSizeDownload(jog.GetMessage(DownloaderClass.GenerateGetSizesAPI(Photo_ID)).Result);
                    DownloaderClass.DownloadFile(DownloadLink, FormDownloadPath(path, Photo_ID));
                }
                jog.FlushTheListOfIDs();
            }
        }


    }
}
