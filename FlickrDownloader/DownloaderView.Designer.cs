namespace FlickrDownloader
{
    partial class DownloaderView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.API_KEY_BOX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.TEXT_AMOUNT_PP_BOX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TEXT_PPP_BOX = new System.Windows.Forms.TextBox();
            this.SEARCH_BY_TEXT_BOX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.URL_AMOUNT_PP_BOX = new System.Windows.Forms.TextBox();
            this.URL_PPP_BOX = new System.Windows.Forms.TextBox();
            this.SEARCH_BY_URL_BOX = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SEARCH_URL_BUTTON = new System.Windows.Forms.Button();
            this.SEARCH_TEXT_BUTTON = new System.Windows.Forms.Button();
            this.TEXT_FILE_SAVE_BROWSER = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // API_KEY_BOX
            // 
            this.API_KEY_BOX.Location = new System.Drawing.Point(93, 12);
            this.API_KEY_BOX.Name = "API_KEY_BOX";
            this.API_KEY_BOX.Size = new System.Drawing.Size(695, 20);
            this.API_KEY_BOX.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "API Key: ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.TEXT_AMOUNT_PP_BOX);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TEXT_PPP_BOX);
            this.panel1.Controls.Add(this.SEARCH_BY_TEXT_BOX);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(15, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 114);
            this.panel1.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AllowDrop = true;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(280, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 9;
            // 
            // TEXT_AMOUNT_PP_BOX
            // 
            this.TEXT_AMOUNT_PP_BOX.Location = new System.Drawing.Point(101, 75);
            this.TEXT_AMOUNT_PP_BOX.Name = "TEXT_AMOUNT_PP_BOX";
            this.TEXT_AMOUNT_PP_BOX.Size = new System.Drawing.Size(100, 20);
            this.TEXT_AMOUNT_PP_BOX.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Amount Of Pages:";
            // 
            // TEXT_PPP_BOX
            // 
            this.TEXT_PPP_BOX.Location = new System.Drawing.Point(101, 48);
            this.TEXT_PPP_BOX.Name = "TEXT_PPP_BOX";
            this.TEXT_PPP_BOX.Size = new System.Drawing.Size(100, 20);
            this.TEXT_PPP_BOX.TabIndex = 5;
            // 
            // SEARCH_BY_TEXT_BOX
            // 
            this.SEARCH_BY_TEXT_BOX.Location = new System.Drawing.Point(101, 22);
            this.SEARCH_BY_TEXT_BOX.Name = "SEARCH_BY_TEXT_BOX";
            this.SEARCH_BY_TEXT_BOX.Size = new System.Drawing.Size(100, 20);
            this.SEARCH_BY_TEXT_BOX.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Pictures Per Page:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Search Query:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Search By Text";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.URL_AMOUNT_PP_BOX);
            this.panel2.Controls.Add(this.URL_PPP_BOX);
            this.panel2.Controls.Add(this.SEARCH_BY_URL_BOX);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(435, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 114);
            this.panel2.TabIndex = 4;
            // 
            // URL_AMOUNT_PP_BOX
            // 
            this.URL_AMOUNT_PP_BOX.Location = new System.Drawing.Point(101, 75);
            this.URL_AMOUNT_PP_BOX.Name = "URL_AMOUNT_PP_BOX";
            this.URL_AMOUNT_PP_BOX.Size = new System.Drawing.Size(100, 20);
            this.URL_AMOUNT_PP_BOX.TabIndex = 10;
            // 
            // URL_PPP_BOX
            // 
            this.URL_PPP_BOX.Location = new System.Drawing.Point(101, 48);
            this.URL_PPP_BOX.Name = "URL_PPP_BOX";
            this.URL_PPP_BOX.Size = new System.Drawing.Size(100, 20);
            this.URL_PPP_BOX.TabIndex = 9;
            // 
            // SEARCH_BY_URL_BOX
            // 
            this.SEARCH_BY_URL_BOX.Location = new System.Drawing.Point(101, 22);
            this.SEARCH_BY_URL_BOX.Name = "SEARCH_BY_URL_BOX";
            this.SEARCH_BY_URL_BOX.Size = new System.Drawing.Size(100, 20);
            this.SEARCH_BY_URL_BOX.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Amount Of Pages:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Pictures Per Page:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Flickr User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Search By User URL";
            // 
            // SEARCH_URL_BUTTON
            // 
            this.SEARCH_URL_BUTTON.Location = new System.Drawing.Point(429, 206);
            this.SEARCH_URL_BUTTON.Name = "SEARCH_URL_BUTTON";
            this.SEARCH_URL_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.SEARCH_URL_BUTTON.TabIndex = 1;
            this.SEARCH_URL_BUTTON.Text = "Search URL";
            this.SEARCH_URL_BUTTON.UseVisualStyleBackColor = true;
            this.SEARCH_URL_BUTTON.Click += new System.EventHandler(this.SEARCH_URL_BUTTON_Click);
            // 
            // SEARCH_TEXT_BUTTON
            // 
            this.SEARCH_TEXT_BUTTON.Location = new System.Drawing.Point(310, 206);
            this.SEARCH_TEXT_BUTTON.Name = "SEARCH_TEXT_BUTTON";
            this.SEARCH_TEXT_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.SEARCH_TEXT_BUTTON.TabIndex = 1;
            this.SEARCH_TEXT_BUTTON.Text = "Search Text";
            this.SEARCH_TEXT_BUTTON.UseVisualStyleBackColor = true;
            this.SEARCH_TEXT_BUTTON.Click += new System.EventHandler(this.SEARCH_TEXT_BUTTON_Click);
            // 
            // TEXT_FILE_SAVE_BROWSER
            // 
            this.TEXT_FILE_SAVE_BROWSER.Location = new System.Drawing.Point(310, 179);
            this.TEXT_FILE_SAVE_BROWSER.Name = "TEXT_FILE_SAVE_BROWSER";
            this.TEXT_FILE_SAVE_BROWSER.Size = new System.Drawing.Size(194, 23);
            this.TEXT_FILE_SAVE_BROWSER.TabIndex = 8;
            this.TEXT_FILE_SAVE_BROWSER.Text = "Browse Download Location";
            this.TEXT_FILE_SAVE_BROWSER.UseVisualStyleBackColor = true;
            this.TEXT_FILE_SAVE_BROWSER.Click += new System.EventHandler(this.TEXT_FILE_SAVE_BROWSER_Click);
            // 
            // DownloaderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TEXT_FILE_SAVE_BROWSER);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.API_KEY_BOX);
            this.Controls.Add(this.SEARCH_TEXT_BUTTON);
            this.Controls.Add(this.SEARCH_URL_BUTTON);
            this.Name = "DownloaderView";
            this.Text = "DownloaderView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox API_KEY_BOX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SEARCH_TEXT_BUTTON;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SEARCH_URL_BUTTON;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TEXT_PPP_BOX;
        private System.Windows.Forms.TextBox SEARCH_BY_TEXT_BOX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TEXT_AMOUNT_PP_BOX;
        private System.Windows.Forms.Button TEXT_FILE_SAVE_BROWSER;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox URL_AMOUNT_PP_BOX;
        private System.Windows.Forms.TextBox URL_PPP_BOX;
        private System.Windows.Forms.TextBox SEARCH_BY_URL_BOX;
        private System.Windows.Forms.Label label10;
    }
}