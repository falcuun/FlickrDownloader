# FlickrDownloader
This application uses Flickr API to provide the users with the ability to bulk download images from a specific user on Flickr

C# .NET FrameWork 4.7 used
### How It Works
  - The Application asks user to input their developer API_KEY (This is to prevent abuse of my api_key) 
  - User is prompted with 2 choices of downloaing methods, by text or by username.
  - There is a button that opens a file chooser and prompts user to choose the save location for the images.
  - Regardles of the method, user is prompted to input the amount of images per page, and amount of pages they want.
 After All data was provided, the application then calls for flickr's getSizes method and downloads the original sized
 image to the defined path. 
 
 ### Run
  To Run this application (for now) you will need Visual studio, or some other C# editor, to compile the code.
  You will need Flickr Developer Account, and your own API_KEY,
  You will also need internet connection. 
  
  
  Note: Executable (.exe) to be built and configured once code is done (few minor adjustments left)
   
 
