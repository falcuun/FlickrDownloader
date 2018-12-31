using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
namespace FlickrDownloader
{
    class Program
    {
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




