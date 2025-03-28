using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubtitleExtractor
{
    public class CrawlWorker
    {
        private static CrawlWorker _Ins;
        public static CrawlWorker Ins
        {
            get
            {
                if (_Ins == null)
                    _Ins = new CrawlWorker();
                return _Ins;
            }
            set
            {
                _Ins = value;
            }
        }


        public CrawlWorker()
        {
            InitHttpClient();
        }
        HttpClient httpClient;
        HttpClientHandler handler;
        CookieContainer cookie = new CookieContainer();
        public string currentURL = @"";


        public static void SetSilent(WebBrowser browser, bool silent)
        {

            Guid IID_IWebBrowserApp = new Guid("0002DF05-0000-0000-C000-000000000046");
            Guid IID_IWebBrowser2 = new Guid("D30C1661-CDAF-11d0-8A3E-00C04FC9E26E");

        }

        [ComImport, Guid("6D5140C1-7436-11CE-8034-00AA006009FA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IOleServiceProvider
        {
            [PreserveSig]
            int QueryService([In] ref Guid guidService, [In] ref Guid riid, [MarshalAs(UnmanagedType.IDispatch)] out object ppvObject);
        }


        void InitHttpClient()
        {
            handler = new HttpClientHandler
            {
                CookieContainer = cookie,
                ClientCertificateOptions = ClientCertificateOption.Automatic,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                AllowAutoRedirect = true,
                UseDefaultCredentials = false,
            };
            httpClient = new HttpClient(handler);

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.80 Safari/537.36 Edg/98.0.1108.50");

            httpClient.BaseAddress = new Uri("https://vision.googleapis.com/v1/images:annotate");
        }
        public string CrawlDataFromURL(string url, bool writeToFile = false)
        {
            try
            {
                this.currentURL = url;

                string html = WebUtility.HtmlDecode(httpClient.GetStringAsync(currentURL).Result);


                if (writeToFile)
                {
                    WriteHTMLToFileForTest(html, Helper.Ins.RandomString(7));
                }

                return html;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }


        }
        public void WriteHTMLToFileForTest(string html, string url)
        {
            string path = @"test/" + url + ".html";
            System.IO.File.WriteAllText(path, html);
        }
    }

}
