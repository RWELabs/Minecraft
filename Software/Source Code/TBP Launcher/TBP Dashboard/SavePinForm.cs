using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TBP_Dashboard.Properties;

namespace TBP_Dashboard
{
    public partial class SavePinForm : Form
    {
        private string _url;
        private string _faviconBase64;
        public string PinName => txtPinName.Text;
        public string PinUrl => _url;
        public string FaviconBase64 => _faviconBase64;

        public SavePinForm(string defaultName, string url, string faviconBase64)
        {
            InitializeComponent();
            txtPinName.Text = defaultName;
            webURL.Text = url;
            _url = url;
            _faviconBase64 = faviconBase64;

            // Load favicon from Google's favicon service
            _ = LoadFaviconAsync(url);

            if (!string.IsNullOrEmpty(faviconBase64))
            {
                try
                {
                    byte[] bytes = Convert.FromBase64String(faviconBase64);
                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        PBfavicon.Image = new Bitmap(Image.FromStream(ms), new Size(32, 32));
                    }
                }
                catch { }
            }
        }

        private async Task LoadFaviconAsync(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    Uri uri = new Uri(url);
                    string domain = uri.Host;
                    string faviconUrl = $"https://www.google.com/s2/favicons?sz=16&domain={domain}";

                    using (HttpClient client = new HttpClient())
                    {
                        byte[] bytes = await client.GetByteArrayAsync(faviconUrl);
                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            Image favicon = Image.FromStream(ms);
                            
                            // Marshal back to UI thread
                            if (this.InvokeRequired)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    PBfavicon.Image = new Bitmap(favicon, new Size(32, 32));
                                }));
                            }
                            else
                            {
                                PBfavicon.Image = new Bitmap(favicon, new Size(32, 32));
                            }
                        }
                    }
                }
            }
            catch
            {
                // If favicon loading fails, keep the existing image or set a default
                // The existing faviconBase64 logic will handle fallback
            }
        }

        private void SavePin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPinName.Text))
            {
                MessageBox.Show("Please enter a name for the pin.", "Save Pin | TBPlay", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
