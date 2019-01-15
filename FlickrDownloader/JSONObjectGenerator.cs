using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;



namespace FlickrDownloader
{
    class JSONObjectGenerator
    {

        public List<string> ListOfPhotoIDs = new List<string>();
        private static readonly HttpClient client = new HttpClient();

        public async Task<string> GetMessage(string url)
        {
            string responseString = await client.GetStringAsync(url);
            return responseString;
        }
        
        /*
         *  Method that takes in JSON String as an argument along with amount of images to download per page
         *  Then prints out the information about USER that was searched for
         */
        public void User_Information(string jsonValue, int per_page)
        {
            JSONModels UserInformation = JsonConvert.DeserializeObject<JSONModels>(jsonValue);
            Console.WriteLine("User Has a Total of: " + UserInformation.photos.total + " Public Image(s)");
            if (UserInformation.photos.total > per_page)
            {
                int Available_Pages = UserInformation.photos.total / per_page;
                if (Available_Pages == 0)
                {
                    Available_Pages = 1;
                }
                Console.WriteLine("With " + per_page + " Image(s) per page, User has: " + Available_Pages + " Page(s) Available");
            }
            else
            {
                Console.WriteLine("With " + per_page + " images per page, User has: " + 1 + " Page(s) Available");
            }
        }
        /*
         *  Method that takes in JSON String as an Argument and then parses it to return the ID Of the Image
         *  And add it to the List Of Photo IDs
         */
        public void PopulateListOfPhotoIDs(string jsonValue)
        {
            JSONModels PhotoIDs = JsonConvert.DeserializeObject<JSONModels>(jsonValue);

            try
            {
                foreach (PhotoModel model in PhotoIDs.photos.photo)
                {
                    ListOfPhotoIDs.Add(model.id);
                }
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre.Message + " --POPULATELISTOFPHOTOIDS");
            }
        }
        /*
         * Method that takes in JSON String as an argument and parses it to return
         * The User NSID 
         */
        public string GetUserNSID(string message)
        {
            JSONModels UserIDs = JsonConvert.DeserializeObject<JSONModels>(message);
            return UserIDs.user.id;
        }
        /*
         * Method That Takes in JSON String as an Argument and Parses it to iterate through a list of sizes returned by API call
         * When the method finds the Original image (With Original size) it returns the link to it (From JSON Response)
         * And adds the _d.jpg to it for downloading purposes.
         */
        public string GetSizeDownload(string message)
        {
            string jsonValue = message;
            string Download_Link = "";
            JSONModels GetSizesDownload = JsonConvert.DeserializeObject<JSONModels>(jsonValue);
            try
            {
                foreach (SizeModel model in GetSizesDownload.sizes.size)
                {
                    if (model.Label.Equals("Original") || model.Label.Equals("original"))
                    {
                        string Download_Source = model.Source.Replace(".jpg", "_d.jpg");
                        Download_Link = Download_Source;
                    }
                }
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre.Message + " --GETSIZEDOWNLOAD");
            }

            return Download_Link;
        }
        /*
         * Method that Flushes the List of Photo IDs so that list would be empty
         */
        public void FlushTheListOfIDs()
        {
            ListOfPhotoIDs.RemoveRange(0, ListOfPhotoIDs.Count);
        }
    }
}
