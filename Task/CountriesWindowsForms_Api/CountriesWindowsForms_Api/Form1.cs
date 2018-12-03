using Newtonsoft.Json;
using Svg;
using Svg.Transforms;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace CountriesWindowsForms_Api
{
    public partial class Form1 : Form
    {

        string basicUrl = "https://restcountries.eu/rest/v2/";
        static WebClient client = new WebClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void cob_names_countries_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change img
            var flags = _download_serialized_json_data<Flag>($"{basicUrl}name/{cob_names_countries.SelectedItem}?fields=flag");
            if (flags== null)
            {
                MessageBox.Show("there isn't flag update");
                return;
            }
            string[] filenames = Directory.GetFiles(@"./");
            picCountry.Load("ברור יותר.JPG");
          
            foreach (string filename in filenames)
            {
                if(filename == "./card.svg"|| filename == "./png.png")
                {
                    File.Delete(filename);
                     
                }
            }
            WebClient webClient = new WebClient();
            webClient.DownloadFile(flags[0].flag, "card.svg");
            var byteArray = Encoding.ASCII.GetBytes(flags[0].flag);
            using (var stream = new MemoryStream(byteArray))
            {
                var svgDocument = SvgDocument.Open("card.svg");
                svgDocument.Width = 141;
                svgDocument.Height = 195;
                var bitmap = svgDocument.Draw();
                bitmap.Save("png.png", ImageFormat.Png);
            }
            flags.ForEach(flag => picCountry.Load("png.png"));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //fill combobox    

            // attempt to download JSON data as a string
            //   string downloadString = client.DownloadString(url);
            var countries = _download_serialized_json_data<Country>($"{basicUrl}all?fields=name");
            countries.ForEach(p => cob_names_countries.Items.Add(p.name));
        }
        private static List<T> _download_serialized_json_data<T>(string url)
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return JsonConvert.DeserializeObject<List<T>>(json_data);
            }
        }
    }
    class Country
    {
        public string name { get; set; }
    }
    class Flag
    {
        public string flag { get; set; }
    }
}
