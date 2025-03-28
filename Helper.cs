using SubtitleExtractor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleExtractor
{
    public class Helper
    {
        private static Helper _Ins;
        public static Helper Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new Helper();
                return _Ins;
            }
            set
            {
                _Ins = value;
            }
        }

        public Helper() { }
        public Random random;

        public string RandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public string GetContent(string html)
        {
            string content = "";
            return content;

        }

        public string ImageFromFileToBase64(string filepath = "")
        {

            string result = null;

            using (Image image = Image.FromFile(filepath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    result = Convert.ToBase64String(imageBytes);
                }
            }
            return result;
        }


        public string ImageFromTestToBase64(string filepath = "")
        {

            string result = null;

            using (Image image = Resources.out0000123)
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    result = Convert.ToBase64String(imageBytes);
                }
            }
            return result;
        }
    }

}
