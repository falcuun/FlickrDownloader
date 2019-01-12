# FlickrDownloader
This application uses Flickr API to provide the users with the ability to bulk download images from a specific user on Flickr

### How It Works
  - The Application asks user to input their developer API_KEY (This is to prevent abuse of my api_key) 
  - It Asks user for a Flickr URL of the user you want to download images from
  - It Asks for desired File Path 
  - It Obtains the total amount of public images the user has
  - It Asks user to input the amount of images they want to see per page (max 500) and the amount of pages they want to download from
 After All data was provided, the application then calls for flickr's getSizes method and downloads the original sized
 image to the defined path. 
 
 ### Run
  To Run this application (for now) you will need Visual studio, or some other C# editor, to compile the code.
  You will need Flickr Developer Account, and your own API_KEY
  You will also need internet connection. 
