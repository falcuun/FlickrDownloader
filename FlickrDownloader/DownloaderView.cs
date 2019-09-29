using System;
using System.Windows.Forms;
using System.Threading;

namespace FlickrDownloader
{
    public partial class DownloaderView : Form
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

        static string FileLocation { get; set; }
        TextSearchPhotosDownload tspd;
        UserPhotosDownload upd;


        public DownloaderView()
        {
            InitializeComponent();
            tspd = new TextSearchPhotosDownload();
            upd = new UserPhotosDownload();
        }

        private void TEXT_FILE_SAVE_BROWSER_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Custom Description";

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                FileLocation = fbd.SelectedPath;
            }
            label10.Text = FileLocation;
        }

        private void SEARCH_TEXT_BUTTON_Click(object sender, EventArgs e)
        {
            if (CheckAPIKey(API_KEY_BOX.Text))
            {
                if (SEARCH_BY_TEXT_BOX.Text != "" && TEXT_PPP_BOX.Text != "" && TEXT_AMOUNT_PP_BOX.Text != "")
                {
                    tspd.TotalImages(SEARCH_BY_TEXT_BOX.Text);
                    if (!tspd.Per_Page(TEXT_PPP_BOX.Text))
                    {
                        MessageBox.Show("Invalid Number (Pictures Per Page)");
                    }
                    else if (!tspd.Num_Pages(TEXT_AMOUNT_PP_BOX.Text))
                    {
                        MessageBox.Show("Invalid Number (Number Of Pages)");
                    }
                    else
                    {
                        tspd.ObtainSearchedPhotos(FileLocation, SEARCH_BY_TEXT_BOX.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Input Fields Are Empty!");
                }
            }
            else
            {
                MessageBox.Show("Invalid API Key");
            }
        }

        private void SEARCH_URL_BUTTON_Click(object sender, EventArgs e)
        {
            if (CheckAPIKey(API_KEY_BOX.Text))
            {
                if (SEARCH_BY_URL_BOX.Text != "" && URL_PPP_BOX.Text != "" && URL_AMOUNT_PP_BOX.Text != "")
                {
                    if (!upd.Per_Page(URL_PPP_BOX.Text))
                    {
                        MessageBox.Show("Invalid Number (Pictures Per Page)");
                    }
                    else if (!upd.Num_Pages(URL_AMOUNT_PP_BOX.Text))
                    {
                        MessageBox.Show("Invalid Number (Number Of Pages)");
                    }
                    else
                    {
                        string user = "https://www.flickr.com/photos/" +  SEARCH_BY_URL_BOX.Text + "/";
                        upd.ObtainUserPublicPhotos(user, FileLocation);
                    }
                }
                else
                {
                    MessageBox.Show("Input Fields Are Empty!");
                }
            }
            else
            {
                MessageBox.Show("Invalid API Key");
            }
        }
    }

}

