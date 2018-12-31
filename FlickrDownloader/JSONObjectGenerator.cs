using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace FlickrDownloader
{
    class JSONObjectGenerator
    {

        public List<string> ListOfIDs = new List<string>();

        public void User_Information(string jsonValue, int per_page)
        {
            JSON UserInformation = JsonConvert.DeserializeObject<JSON>(jsonValue);
            Console.WriteLine("User Has a Total of: " + UserInformation.photos.total + " Public Image(s)");
            if (UserInformation.photos.total > per_page)
            {
                int Available_Pages = UserInformation.photos.total / per_page;
                Console.WriteLine("With " + per_page + " Image(s) per page, User has: " + Available_Pages + " Page(s) Available");
            }
            else
            {
                Console.WriteLine("With " + per_page + " images per page, User has: " + 1 + " Page(s) Available");
            }
        }


        public void GetPhotoId(string jsonValue)
        {
            JSON PhotoIDs = JsonConvert.DeserializeObject<JSON>(jsonValue);
            
            try
            {
                foreach (PhotoModel model in PhotoIDs.photos.photo)
                {
                    ListOfIDs.Add(model.id);
                }
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine(nre.Message + " --GETPHOTOID");
            }
        }

        public string GetUserNSID(string message)
        {
            JSON UserIDs = JsonConvert.DeserializeObject<JSON>(message);
            return UserIDs.user.id; 
        }

        public string GetSizeDownload(string message)
        {
            string jsonValue = message;
            string Download_Link = "";
            JSON GetSizesDownload = JsonConvert.DeserializeObject<JSON>(jsonValue);
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

        public void EmptyListOfIDs()
        {
            ListOfIDs.RemoveRange(0, ListOfIDs.Count);
        }
    }
}
