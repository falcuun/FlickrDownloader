using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
namespace FlickrDownloader
{
    class Program
    {
        public static string API_KEY { get; set; }

        public static bool CheckAPIKey(string Key)
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

        static void Main(string[] args)
        {

            Console.WriteLine("Enter your API KEY");
            while(CheckAPIKey(Console.ReadLine()))
            {
                Console.WriteLine("Choose the Option: \n 1: Search By User URL \n 2: Search By Text ");

                int option = Int32.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        SearchByUserURL();
                        break;
                    case 2:
                        SearchByText();
                        break;
                    default: break;
                }
            }

            Console.ReadLine();
        }

        private static void SearchByText()
        {
            TextSearchPhotosDownload tspd = new TextSearchPhotosDownload();
            Console.WriteLine("Enter Search Query");
            string query = Console.ReadLine();
            tspd.TotalImages(query);
            Console.WriteLine("Enter Amount of Pictures per page: ");
            while (!tspd.Per_Page(Console.ReadLine())) ;
            Console.WriteLine("Enter Amount of Pages to Download From: ");
            while (!tspd.Num_Pages(Console.ReadLine())) ;
            Console.WriteLine("Enter Targeted Download Location: ");
            string file_location = Console.ReadLine();
            tspd.ObtainSearchedPhotos(file_location, query);
        }

        private static void SearchByUserURL()
        {
            UserPhotosDownload userPhotosDownload = new UserPhotosDownload();
            Console.WriteLine("Enter User Url");
            string user_url = Console.ReadLine();
            Console.WriteLine("Enter Amount of Pictures per page: ");
            while (!userPhotosDownload.Per_Page(Console.ReadLine())) ;
            Console.WriteLine("Enter Amount of Pages to Download From: ");
            while (!userPhotosDownload.Num_Pages(Console.ReadLine())) ;
            Console.WriteLine("Enter Targeted Download Location: ");
            string file_location = Console.ReadLine();
            userPhotosDownload.ObtainUserPublicPhotos(user_url, file_location);
        }
    }
}




