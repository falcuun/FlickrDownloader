using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleApp2
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

            Console.WriteLine("Write your API KEY");
            string API_KEY = Console.ReadLine();
            if (API_KEY != "")
            {
                //string Method_Name;

                int number = 100;
                int page = 1;

                ObjectGenerator og = new ObjectGenerator();

                Console.WriteLine("Enter Absolute Path for Saving Images: (Example: C:\\Users\\user\\Desktop\\) ");
                string File_Name = Console.ReadLine() + "\\";

                Console.WriteLine("Eneter Flickr User URL (Example: https://www.flickr.com/photos/nasa2explore/)");
                string User_URL = Console.ReadLine();

                string api_url = "https://api.flickr.com/services/rest/?method=flickr.urls.lookupUser&api_key=" + API_KEY + "&url=" + "\"" + User_URL + "\"" + "&format=json&nojsoncallback=1";

                string NSID = og.GetUserNSID(GetMessage(api_url).Result);

                

                Console.WriteLine("Enter The Amount of images you want to download per page (in digits): (Max: 500/Default: 100)");
                string Number_Of_Photos = Console.ReadLine();
                try
                {
                    number = Int32.Parse(Number_Of_Photos);
                }
                catch (System.FormatException fe)
                {
                    Console.WriteLine("Incorrect Number Format; Default number set to 100; Default page set to 1");
                }
            
                    string Method_GetPublicImages = BASE_URL + "flickr.people.getPublicPhotos&api_key=" + API_KEY + "&" +
                   "user_id=" + NSID + "&format=json&nojsoncallback=1";
                og.User_Information(GetMessage(Method_GetPublicImages).Result, number);

                Console.WriteLine("Enter Number of Pages you want to Download from: (Default 1)");
                string Page_Number = Console.ReadLine();

                try
                {
                    page = Int32.Parse(Page_Number);
                }
                catch (System.FormatException fe)
                {
                    Console.WriteLine("Incorrect Number Format; Default number of pages set to 1");
                }

                for (int i = 1; i <= page; i++)
                {
                    Method_GetPublicImages = BASE_URL + "flickr.people.getPublicPhotos&api_key=" + API_KEY + "&" +
                                            "user_id=" + NSID + "&per_page=" + number + "&page=" + i + "&format=json&nojsoncallback=1";
                    Console.WriteLine(Method_GetPublicImages);
                    og.GetPhotoId(GetMessage(Method_GetPublicImages).Result);
                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            foreach (string Photo_ID in og.ListOfIDs)
                            {
                                string Photos_GetSizes = BASE_URL + "flickr.photos.getSizes&api_key=" + API_KEY + "&" +
                                 "photo_id=" + Photo_ID + "&format=json&nojsoncallback=1";
                                string DownloadLink = og.GetSizeDownload(GetMessage(Photos_GetSizes).Result);
                                Console.WriteLine(DownloadLink);
                                client.DownloadFile(DownloadLink, File_Name + Photo_ID + ".jpg");
                                Console.WriteLine(File_Name + Photo_ID + ".jpg");
                            }
                        }
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine(err.Message + " --MAIN METHOD " + File_Name);
                    }
                }
                Console.ReadLine();
            }
        }

        public string Generate_Link(string Method_Name, string API_Key)
        {
            string url = BASE_URL + Method_Name + "&api_key=" + API_Key;
            return url;
        }

        private static async Task<string> GetMessage(string url)
        {
            var responseString = await client.GetStringAsync(url);
            return responseString;
        }
    }
}




