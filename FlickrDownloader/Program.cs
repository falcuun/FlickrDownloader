using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
namespace FlickrDownloader
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private const string BASE_URL = "https://api.flickr.com/services/rest/?method=";

        #region Methods
        private const string Galleries_GetPHotos = "flickr.galleries.getPhotos";
        private const string People_NSID = "flickr.urls.lookupUser";
        private const string People_GetPublicPhotos = "flickr.people.getPublicPhotos";
        #endregion


        static void Main(string[] args)
        {
            FlickrConnection flickrConnection = new FlickrConnection();

            Console.WriteLine("Enter your API KEY");
            while (!flickrConnection.CheckAPIKey(Console.ReadLine()));
            Console.WriteLine("Enter User Url");
            string user_url = Console.ReadLine();
            Console.WriteLine("Enter Amount of Pictures per page: ");
            while (!flickrConnection.Per_Page(Console.ReadLine()));
            Console.WriteLine("Enter Amount of Pages to Download From: ");
            while (!flickrConnection.Num_Pages(Console.ReadLine()));
            Console.WriteLine("Enter Targeted Download Location: ");
            string file_location = Console.ReadLine();

            flickrConnection.DownloadPublicPhotos(user_url, file_location);
            Console.ReadLine();
        }
    }
}




