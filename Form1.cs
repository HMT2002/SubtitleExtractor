using AForge.Imaging;
using AForge.Imaging.Filters;
using Emgu.CV;
using Emgu.CV.Flann;
using Emgu.CV.ImgHash;
using Emgu.CV.ML;
using Emgu.CV.Structure;
using Emgu.CV.XFeatures2D;
using Emgu.Util.TypeEnum;
using FFMpegCore;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Tesseract;
using static System.Net.Mime.MediaTypeNames;
namespace SubtitleExtractor
{
    public partial class Form1 : Form
    {

        public static int PROCESS_MAXIMUM = 1000;
        public static int PROCESS_STEP = 10;
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleOutputCP(uint wCodePageID);
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            toolStripProgressBar1.Maximum = PROCESS_MAXIMUM;
            //toolStripProgressBar1.Step=PROCESS_STEP;
            toolStripProgressBar1.Step = 1;
            toolStripProgressBar1.Value = 0;
            SetConsoleOutputCP(65001);
            //Console.OutputEncoding = Encoding.UTF8;
            //Console.InputEncoding = System.Text.Encoding.UTF8;
            GlobalFFOptions.Configure(new FFOptions { BinaryFolder = @"D:\ffmpeg-app\", TemporaryFilesFolder = Environment.CurrentDirectory + "/tmp" });
        }
        string FFMPEG_PATH = @"D:\ffmpeg-full_build\bin\ffmpeg.exe";
        public Random random = new Random();
        string output_filename = "";
        string filepath = "";


        public string RandomString(int length)
        {

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void process(string strParam)
        {
            try
            {
                Thread t = new Thread(() =>
                {
                    //Process ffmpeg = new Process();
                    //ffmpeg.StartInfo.UseShellExecute = false;
                    //ffmpeg.StartInfo.RedirectStandardOutput = true;
                    //ffmpeg.StartInfo.FileName = Path_FFMPEG;
                    //ffmpeg.StartInfo.Arguments = strParam;
                    //ffmpeg.Start();
                    //ffmpeg.WaitForExit();

                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.WorkingDirectory = Environment.CurrentDirectory;
                    startInfo.Arguments = "/k " + strParam + " & exit"; ;

                    process.StartInfo = startInfo;

                    //while (!process.StandardOutput.EndOfStream)
                    //{
                    //    string line = process.StandardOutput.ReadLine();
                    //    // do something with line
                    //    richTextBoxStatus.Text += line + "\n";
                    //}

                    process.Start();

                    process.WaitForExit();

                    textBoxCropFolder.Text = "_extract_" + output_filename;
                    richTextBoxStatus.Text += "Finish extract!\n";
                    if (pictureBoxLoading.Image != null)
                    {
                        pictureBoxLoading.Image.Dispose();
                        pictureBoxLoading.Image = null;
                        pictureBoxLoading.Update();
                        pictureBoxLoading.Image = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                        pictureBoxLoading.Refresh();

                    }


                });
                t.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OpenScreenshotFile()
        {
            //if (!File.Exists(FFMPEG_PATH))
            //{
            //    MessageBox.Show("Cannot find ffmpeg.exe.");
            //    return;
            //}
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = false;
                //dialog.Multiselect = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = dialog.FileName;
                    this.filepath = filename;
                    textBoxExtractFolder.Text = filename;

                }
            }
        }

        public string ExtractScreenshot(string filename, int shotNumberPerSecond)
        {
            string fileID = RandomString(5);
            string folderpath = System.Windows.Forms.Application.StartupPath + @"\_extract_" + fileID;
            output_filename = fileID;

            bool exists = System.IO.Directory.Exists(folderpath);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(folderpath);
            }
            string strParam = FFMPEG_PATH + " -i \"" + filename + "\" -vf fps=" + shotNumberPerSecond + " \"" + folderpath + "\\out%07d.png\"";
            //if (MessageBox.Show("", strParam, MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            //{
            //    Clipboard.SetText(strParam);
            //}
            Console.WriteLine(strParam);
            richTextBoxStatus.Text += "\nStart extracting...\n";
            pictureBoxLoading.Image = Properties.Resources.loading_gif;
            pictureBoxLoading.Refresh();
            process(strParam);
            return fileID;
        }

        public void ExtractScreenshotFFMPEGCore(string inputfilename, string outputfolder, int shotNumberPerSecond)
        {

            FFMpeg.Snapshot(inputfilename, outputfolder, new Size(200, 400), TimeSpan.FromSeconds(1));


        }

        public void StartOCRProc(string output_folder)
        {
            try
            {
                Thread t = new Thread(() =>
                {
                    ProcessStartInfo start = new ProcessStartInfo();
                    start.WorkingDirectory = Environment.CurrentDirectory;
                    start.FileName = "cmd.exe";
                    start.Arguments = @"/k chcp 65001 & @echo off & python -u ../../pyocr.py --folder " + output_folder + @" --image out0064.png --subname " + output_folder;
                    Console.WriteLine(start.Arguments);
                    start.UseShellExecute = false;
                    start.RedirectStandardOutput = true;
                    start.RedirectStandardError = true;
                    //start.CreateNoWindow = true;

                    Process process = new Process();
                    process.StartInfo = start;
                    process.EnableRaisingEvents = true;
                    process.ErrorDataReceived += Process_OutputDataReceived;
                    process.OutputDataReceived += Process_OutputDataReceived;
                    process.Exited += delegate
                    {
                        richTextBoxStatus.Text += "\nFinish EasyOCR!\n";
                        if (pictureBoxLoading.Image != null)
                        {
                            pictureBoxLoading.Image.Dispose();
                            pictureBoxLoading.Image = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                            pictureBoxLoading.Refresh();
                            pictureBoxOCR.BackgroundImage = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                            pictureBoxOCR.Refresh();
                        }
                    };
                    process.Start();
                    process.BeginErrorReadLine();
                    process.BeginOutputReadLine();

                    process.WaitForExit();

                    richTextBoxStatus.Text += "\nFinish EasyOCR!\n";
                    if (pictureBoxLoading.Image != null)
                    {
                        pictureBoxLoading.Image.Dispose();
                        pictureBoxLoading.Image = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                        pictureBoxLoading.Update();
                        pictureBoxOCR.BackgroundImage = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                        pictureBoxOCR.Refresh();

                    }
                    pictureBoxCrop.Image = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                    pictureBoxCrop.Refresh();

                    pictureBoxOCR.BackgroundImage = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                    pictureBoxOCR.Refresh();
                    //using (StreamReader reader = process.StandardOutput)
                    //{
                    //    string result = reader.ReadToEnd();
                    //    Console.Write(result);
                    //    byte[] bytes = Encoding.Default.GetBytes(result);
                    //    string myString = Encoding.UTF8.GetString(bytes);
                    //    richTextBoxStatus.Text += myString + "\n";

                    //}

                    //using (Process process = new Process())
                    //{
                    //    process.StartInfo = start;
                    //    process.EnableRaisingEvents = true;
                    //    process.ErrorDataReceived += Process_OutputDataReceived;
                    //    process.OutputDataReceived += Process_OutputDataReceived;
                    //    process.Exited += delegate
                    //    {
                    //        richTextBoxStatus.Text += "\nFinish EasyOCR!\n";
                    //        if (pictureBoxLoading.Image != null)
                    //        {
                    //            pictureBoxLoading.Image.Dispose();
                    //            pictureBoxLoading.Image = null;
                    //            pictureBoxLoading.Update();
                    //pictureBoxCrop.Refresh();
                    //pictureBoxCrop.Image = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;

                    //        }
                    //    };
                    //    process.Start();
                    //    process.BeginErrorReadLine();
                    //    process.BeginOutputReadLine();

                    //    process.WaitForExit();

                    //    //using (StreamReader reader = process.StandardOutput)
                    //    //{
                    //    //    string result = reader.ReadToEnd();
                    //    //    Console.Write(result);
                    //    //    byte[] bytes = Encoding.Default.GetBytes(result);
                    //    //    string myString = Encoding.UTF8.GetString(bytes);
                    //    //    richTextBoxStatus.Text += myString + "\n";

                    //    //}

                    //}
                    //Console.Read();

                });
                t.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                Console.WriteLine(e.Data);
                byte[] bytes = Encoding.Default.GetBytes(e.Data);
                string myString = Encoding.UTF8.GetString(bytes);
                //richTextBoxStatus.Text += myString + "\n"+ e.Data + "\n";
                richTextBoxStatus.Text += myString + "\n";
                //toolStripProgressBar1.PerformStep();
                if (myString.CompareTo(@"@___Finished___@") == 0)
                {
                    richTextBoxStatus.Text += "\nFinish EasyOCR!\n";
                    if (pictureBoxLoading.Image != null)
                    {
                        pictureBoxLoading.Image = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                        pictureBoxLoading.Refresh();
                        pictureBoxOCR.BackgroundImage = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                        pictureBoxOCR.Refresh();
                        //pictureBoxLoading.Update();


                    }

                }

            }

        }
        public string OCRPic(string filepath)
        {

            Bitmap bitmap = new Bitmap(filepath);
            string result = "";
            richTextBoxStatus.Text += "Start Tesseract test: \n";
            Task<string> ocr = Task<string>.Factory.StartNew(() =>
            {
                result = OCR(bitmap);
                richTextBoxStatus.Text += "Tesseract: " + result + "\n";
                return result;
            });
            return ocr.Result;
            //Thread t = new Thread(() =>
            //{
            //    string result = OCR(grImage);
            //    richTextBoxStatus.Text += result + "\n";
            //});
            //t.Start();



        }
        public void CropPic(string input_filepath, string output_filepath)
        {
            try
            {
                Mat img = CvInvoke.Imread(input_filepath, Emgu.CV.CvEnum.ImreadModes.AnyColor);
                richTextBoxStatus.Text += "Height: " + img.Height + "Width: " + img.Width + "\n";

                int input_crop_X = 0;
                int input_crop_Y = (int)((img.Height) * (decimal)(0.82));
                int input_crop_height = (int)((img.Height) * ((decimal)(0.18)));
                int input_crop_width = img.Width;
                if (textBoxCropX.Text.Trim().CompareTo("") != 0)
                {
                    input_crop_X = (int)((double)((Int32.Parse(textBoxCropX.Text.Trim())) * img.Width / 100));

                }
                if (textBoxCropY.Text.Trim().CompareTo("") != 0)
                {
                    input_crop_Y = (int)(((double)(Int32.Parse(textBoxCropY.Text.Trim())) * img.Height / 100));
                }
                if (textBoxCropHeight.Text.Trim().CompareTo("") != 0)
                {
                    input_crop_height = (int)(((double)(Int32.Parse(textBoxCropHeight.Text.Trim())) * img.Height / 100));
                }
                if (textBoxCropWidth.Text.Trim().CompareTo("") != 0)
                {
                    input_crop_width = (int)(((double)(Int32.Parse(textBoxCropWidth.Text.Trim())) * img.Width / 100));
                }
                if (checkBoxFullWidthCrop.Checked)
                {
                    input_crop_X = 0;
                    input_crop_width = img.Width;
                }
                if (checkBoxFullHeightCrop.Checked)
                {
                    input_crop_Y = 0;
                    input_crop_height = img.Height;
                }
                Rectangle myROI = new Rectangle(input_crop_X, input_crop_Y, input_crop_width, input_crop_height);
                Mat cropped_img = new Mat(img, myROI);
                if (output_filepath != null)
                {
                    cropped_img.Save(output_filepath);

                }
                SwitchImageHighSpeed(cropped_img.ToBitmap(), pictureBoxCrop, 200);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        string displayFile = "";
        string displayFileName = "";

        public void checkOption()
        {
            if (textBoxGrayScaleInput.Text.CompareTo("") == 0)
            {
                return;
            }
            bool useSISThreshHold = checkBoxThreshhold.Checked;
            bool useGrayscale = checkBoxGrayscale.Checked;
            string grayscale_filepath = "";

            if (checkBoxNail.Checked && displayFile.CompareTo("") != 0)
            {
                grayscale_filepath = displayFile;
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(textBoxGrayScaleInput.Text);
                if (!dir.Exists)
                {
                    return;
                }
                int randomIndex = random.Next(dir.GetFiles().Length - 1);
                FileInfo file = dir.GetFiles()[randomIndex];
                labelGrayscaleName.Text = file.Name;
                grayscale_filepath = file.FullName;
                displayFile = file.FullName;
                displayFileName = file.Name;
            }

            Bitmap bitmap = new Bitmap(grayscale_filepath);


            Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            if (useGrayscale)
            {
                // Chuyền thành màu xám
                bitmap = grayFilter.Apply(bitmap);
            }
            else if (useSISThreshHold)
            {
                //Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
                Bitmap grImage = grayFilter.Apply(bitmap);
                SISThreshold filter = new SISThreshold();
                filter.ApplyInPlace(grImage);
                bitmap = grImage;

            }
            else if (useGrayscale && useSISThreshHold)
            {
                //Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
                bitmap = grayFilter.Apply(bitmap);
                //Bitmap grImage = grayFilter.Apply(bitmap);
                // thêm filter 1 lần nữa
                //SISThreshold filter = new SISThreshold();
                //filter.ApplyInPlace(grImage);
                //bitmap = grImage;
            }
            pictureBoxGrayscale.BackgroundImage = bitmap;
            pictureBoxGrayscale.Refresh();
        }
        private void checkBoxGrayscale_CheckedChanged(object sender, EventArgs e)
        {

            checkOption();
        }

        private void checkBoxThreshhold_CheckedChanged(object sender, EventArgs e)
        {
            checkOption();

        }
        public void GrayScalePic(string input_filepath, string output_filepath, int index)
        {
            bool useSISThreshHold = checkBoxThreshhold.Checked;
            bool useGrayscale = checkBoxGrayscale.Checked;
            if (!useGrayscale && !useSISThreshHold)
            {

                return;
            }
            Bitmap bitmap = new Bitmap(input_filepath);
            Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            if (useGrayscale)
            {
                // Chuyền thành màu xám
                bitmap = grayFilter.Apply(bitmap);
            }
            if (useSISThreshHold)
            {
                //Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
                Bitmap grImage = grayFilter.Apply(bitmap);
                SISThreshold filter = new SISThreshold();
                filter.ApplyInPlace(grImage);
                bitmap = grImage;

            }
            else if (useGrayscale && useSISThreshHold)
            {
                bitmap = grayFilter.Apply(bitmap);
                //Bitmap grImage = grayFilter.Apply(bitmap);
                //// thêm filter 1 lần nữa
                //SISThreshold filter = new SISThreshold();
                //filter.ApplyInPlace(grImage);
                //bitmap = grImage;
            }

            bitmap.Save(output_filepath);
            bitmap.Dispose();

        }
        private string OCR(Bitmap b)
        {
            string res = "";
            try
            {
                using (var engine = new TesseractEngine("./tessdata", "vie", EngineMode.Default))
                {
                    using (var page = engine.Process(b, PageSegMode.Auto))
                        res = page.GetText();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return res;
        }
        public async void SwitchImageHighSpeed(Bitmap bitmap, PictureBox pictureBox, int delayMs)
        {
            pictureBox.BackgroundImage = bitmap;
            pictureBox.Refresh();
            //bitmap.Dispose();
            await Task.Delay(delayMs);//<--Note Task.Delay don't block UI
        }
        public void GrayScaleFolder(string inputFolder, string outputFolder)
        {
            DirectoryInfo input_folder = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + @"\" + inputFolder);
            if (!input_folder.Exists)
            {
                MessageBox.Show("Not found pictures path: " + inputFolder);
                return;
            }

            if (!input_folder.Exists)
            {
                MessageBox.Show("Not found pictures path: " + inputFolder);
                return;
            }

            DirectoryInfo output_grayscale_folder = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + @"\" + outputFolder);
            string folder_grayscale_path = System.Windows.Forms.Application.StartupPath + @"\" + outputFolder;
            if (!output_grayscale_folder.Exists)
            {
                System.IO.Directory.CreateDirectory(folder_grayscale_path);
            }
            toolStripProgressBar1.Maximum = input_folder.GetFiles().Length;
            toolStripProgressBar1.Value = 0;
            int index = 0;
            foreach (FileInfo file in input_folder.GetFiles())
            {
                GrayScalePic(file.FullName, folder_grayscale_path + @"\" + file.Name, index);
                index++;
                toolStripProgressBar1.PerformStep();
            }
            toolStripProgressBar1.Value = 0;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            GrayscaleProc();
        }

        public void GrayscaleProc()
        {
            if (textBoxGrayScaleInput.Text.CompareTo("") == 0)
            {
                return;
            }
            string grayscaleInput = textBoxGrayScaleInput.Text;
            string job = "";
            bool useSISThreshHold = checkBoxThreshhold.Checked;
            bool useGrayscale = checkBoxGrayscale.Checked;

            if (!useGrayscale && !useSISThreshHold)
            {
                return;
            }

            if (useGrayscale)
            {
                job = "grayscale";
            }
            else if (useSISThreshHold)
            {
                job = "sisthreshold";
            }
            else if (useGrayscale && useSISThreshHold)
            {
                job= "grayscale_sisthreshold";
            }

            grayscaleInput += "_"+ job;
            StartGrayscale(grayscaleInput);
            AddToXMLAndToTreeView(fileID, job, grayscaleInput);
        }

        public void StartGrayscale(string grayScaleInput = "")
        {
            pictureBoxLoading.Image = Properties.Resources.loading_gif;
            pictureBoxLoading.Refresh();
            Thread t = new Thread(() =>
            {
                GrayScaleFolder(textBoxGrayScaleInput.Text, grayScaleInput);
                textBoxGrayScaleOutput.Text = grayScaleInput;
                textBoxOCR.Text = grayScaleInput;
                pictureBoxLoading.Image = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                pictureBoxLoading.Refresh();
            });
            t.Start();
        }


        public CrawlWorker worker = CrawlWorker.Ins;
        static System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

        // đây là overloading, cùng tên khác tham số
        //overriding là kề thừa từ lớp cha, cùng tên, cùng tham số, cùng kiểu dữ liệu trả về
        public async Task<string> SendGoogleOCRRequest(string filename = "", string project_id = "", string auth_key = "")
        {
            string text = "";
            string res = @"
        {
            ""responses"": {
                ""textAnnotations"": [],
                ""fullTextAnnotation"":{
                    ""pages"":[],
                    ""text"":""""
                }
            }
        }";
            try
            {
                /*
                Request body sample

                {
                  "requests": [
                    {
                      "image": {
                        "content": "base64image"
                      },
                      "features": [
                        {
                          "type": "TEXT_DETECTION"
                        }
                      ]
                    }
                  ]
                }

                 */
                var resquestBody = new JsonObject();
                var requestsArray = new JsonArray();
                var requestsObject = new JsonObject();
                var imageJson = new JsonObject();
                var base64Image = Helper.Ins.ImageFromFileToBase64(filename);
                imageJson.Add("content", base64Image);
                var featuresJson = new JsonObject();
                var featuresArray = new JsonArray();
                var feature = new JsonObject();
                feature.Add("type", "TEXT_DETECTION");
                featuresArray.Add(feature);
                requestsObject.Add("image", imageJson);
                requestsObject.Add("features", featuresArray);
                requestsArray.Add(requestsObject);
                resquestBody.Add("requests", requestsArray);
                var content = new System.Net.Http.StringContent(resquestBody.ToString(), Encoding.UTF8, "application/json"); ;

                //get gcloud token
                //gcloud auth print-access-token 
                var httpRequestMessage = new System.Net.Http.HttpRequestMessage
                {
                    Method = System.Net.Http.HttpMethod.Post,
                    RequestUri = new Uri($"https://vision.googleapis.com/v1/images:annotate"),
                    Headers = {
            { System.Net.HttpRequestHeader.Authorization.ToString(), "Bearer "+ auth_key},
            { System.Net.HttpRequestHeader.ContentType.ToString(), "application/json; charset=utf-8" },
            { "x-goog-user-project", project_id },
            //"nodejs-deploy-406708"
        },
                    Content = content
                };
                System.Net.Http.HttpResponseMessage response = await client.SendAsync(httpRequestMessage);
                response.EnsureSuccessStatusCode();

                // Deserialize the updated product from the response body.
                res = await response.Content.ReadAsStringAsync();



            }
            catch (Exception ex)
            {
                throw ex;
            }
            try
            {
                JObject obj = JObject.Parse(res);
                if (obj["responses"][0]["fullTextAnnotation"] != null)
                {
                    JToken token = obj["responses"][0]["fullTextAnnotation"]["text"];
                    text = token.ToString();
                    richTextBoxStatus.Text += "\n " + text + "\n";
                    Console.WriteLine(token.Path + " -> " + text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return text;
        }


        public async void SendGoogleOCRRequest()
        {
            try
            {
                /*
                Request body sample

                {
                  "requests": [
                    {
                      "image": {
                        "content": "base64image"
                      },
                      "features": [
                        {
                          "type": "TEXT_DETECTION"
                        }
                      ]
                    }
                  ]
                }

                 */
                var resquestBody = new JsonObject();
                var requestsArray = new JsonArray();
                var requestsObject = new JsonObject();
                var imageJson = new JsonObject();
                var base64Image = Helper.Ins.ImageFromTestToBase64();
                imageJson.Add("content", base64Image);
                var featuresJson = new JsonObject();
                var featuresArray = new JsonArray();
                var feature = new JsonObject();
                feature.Add("type", "TEXT_DETECTION");
                featuresArray.Add(feature);
                requestsObject.Add("image", imageJson);
                requestsObject.Add("features", featuresArray);
                requestsArray.Add(requestsObject);
                resquestBody.Add("requests", requestsArray);
                var content = new System.Net.Http.StringContent(resquestBody.ToString(), Encoding.UTF8, "application/json"); ;

                //get gcloud token
                //gcloud auth print-access-token 
                var httpRequestMessage = new System.Net.Http.HttpRequestMessage
                {
                    Method = System.Net.Http.HttpMethod.Post,
                    RequestUri = new Uri($"https://vision.googleapis.com/v1/images:annotate"),
                    Headers = {
            { System.Net.HttpRequestHeader.Authorization.ToString(), "Bearer ya29.a0AeXRPp5JeVJQ9eVnExDARs_iTu54Ve1TOrwRJ0OsgQgo427GddbAut1qBzeyR2obtUkYrPt5cSvQE5gxSK-I79wwOOH9xfh-RvDlFf76qlC9JbHM6ulVbJlt833Dskk-005cTJa5FTyC1w62-z38CrV_dMnSeyWURxC0ECxiN7RiJXYaCgYKAToSARMSFQHGX2MiDRMDSNXrtV2y9oYp_QX_7Q0182" },
            { System.Net.HttpRequestHeader.ContentType.ToString(), "application/json; charset=utf-8" },
            { "x-goog-user-project", "nodejs-deploy-406708" },

        },
                    Content = content
                };
                System.Net.Http.HttpResponseMessage response = await client.SendAsync(httpRequestMessage);
                response.EnsureSuccessStatusCode();

                // Deserialize the updated product from the response body.
                string res = await response.Content.ReadAsStringAsync();
                Console.WriteLine(response.Content);
                Console.WriteLine(res);

                JObject json = JObject.Parse(res);
                richTextBoxStatus.Text += "\n " + res + "\n";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OCRProc();

        }

        public void OCRProc()
        {
            string OCRInput = textBoxOCR.Text;
            DirectoryInfo input_folder = new DirectoryInfo(System.Windows.Forms.Application.StartupPath + @"\" + OCRInput);
            if (!input_folder.Exists)
            {
                return;
            }                
            string auth_key = richTextBoxAuthKey.Text;
            string project_id = textBoxProject.Text;
            StartOCR(OCRInput, input_folder, auth_key, project_id);
            
        }

        private void StartOCR(string OCRInput="", DirectoryInfo input_folder=null, string auth_key="", string project_id="")
        {
            toolStripProgressBar1.Maximum = input_folder.GetFiles().Length;
            toolStripProgressBar1.Value = 0;
            pictureBoxLoading.Image = Properties.Resources.loading_gif;
            pictureBoxOCR.BackgroundImage = Properties.Resources.loading_gif;
            pictureBoxOCR.Refresh();
            pictureBoxLoading.Refresh();
            string fullJobName = "";
            string job = "";
            if (radioButtonEasyOCR.Checked)
            {
                richTextBoxStatus.Text += "\nStart EasyOCR...\n";
                StartOCRProc(OCRInput);
                fullJobName = OCRInput + "_easyocr";
                job = "easyocr";
            }
            else if (radioButtonGoogleCloudAIOCR.Checked)
            {
                int step = 0;
                int index = 1;
                File.WriteAllText(System.Windows.Forms.Application.StartupPath + @"\" + OCRInput + "_google_vision.srt", "");

                if (auth_key.Equals("") || project_id.Equals(""))
                {
                    richTextBoxStatus.Text += "\n" + @"Cần có auth key và project id nếu dùng google api";
                    return;
                }
                Thread t = new Thread(async () =>
                {
                    foreach (FileInfo file in input_folder.GetFiles())
                    {
                        try
                        {
                            string result = await SendGoogleOCRRequest(file.FullName, project_id, auth_key);
                            if (result.Trim().CompareTo("") != 0)
                            {
                                string formatted = formatSubtitle(result, step, step + (1000 / 2), index);
                                index++;
                                File.AppendAllText(System.Windows.Forms.Application.StartupPath + @"\" + OCRInput + "_google_vision.srt", formatted);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                        step += (1000 / 2);
                        toolStripProgressBar1.PerformStep();
                    }
                    toolStripProgressBar1.Value = 0;
                    pictureBoxLoading.Image = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                    pictureBoxOCR.BackgroundImage = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                    pictureBoxLoading.Refresh();
                    pictureBoxOCR.Refresh();

                });
                t.Start();

                fullJobName = OCRInput + "_google_vision";
                job = "google_vision";
            }
            else if (radioButtonTesseract.Checked)
            {
                int step = 0;
                int index = 1;
                File.WriteAllText(System.Windows.Forms.Application.StartupPath + @"\" + OCRInput + "_tesseract.srt", "");
                Thread t = new Thread(() =>
                {
                    foreach (FileInfo file in input_folder.GetFiles())
                    {

                        string result = OCRPic(file.FullName);
                        if (result.Trim().CompareTo("") != 0)
                        {
                            string formatted = formatSubtitle(result, step, step + (1000 / 2), index);
                            index++;
                            File.AppendAllText(System.Windows.Forms.Application.StartupPath + @"\" + OCRInput + "_tesseract.srt", formatted);
                        }
                        step += (1000 / 2);
                        toolStripProgressBar1.PerformStep();
                    }
                    toolStripProgressBar1.Value = 0;
                    pictureBoxLoading.Image = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                    pictureBoxOCR.BackgroundImage = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                    pictureBoxLoading.Refresh();
                    pictureBoxOCR.Refresh();

                });
                t.Start();
                fullJobName = OCRInput + "_tesseract";
                job = "tesseract";
            }
            //backgroundWorker1.RunWorkerAsync();//start worker



            //Displaying thôi đừng grayscale, out of memory ngay đấy
            //foreach (FileInfo file in input_folder.GetFiles())
            //{
            //    Bitmap bitmap = new Bitmap(file.FullName);
            //    //// Chuyền thành màu xám
            //    //Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            //    //Bitmap grImage = grayFilter.Apply(bitmap);
            //    //SISThreshold filter = new SISThreshold();
            //    //// thêm filter 1 lần nữa
            //    //filter.ApplyInPlace(grImage);
            //    SwitchImageHighSpeed(bitmap, pictureBoxOCR, 200);
            //}

            AddToXMLAndToTreeView(fileID, job, fullJobName);
        }

        public string formatSubtitle(string text, int timeFrom, int timeTo, int index)
        {
            string formated = "";

            int milisecTimeFrom = timeFrom % 1000;
            int secTimeFrom = timeFrom / 1000;
            int hourTimeFrom = (int)(Math.Floor((double)secTimeFrom / (60 * 60)));
            secTimeFrom = secTimeFrom - (hourTimeFrom * (60 * 60));
            int minuteTimeFrom = (int)(Math.Floor((double)secTimeFrom / (60)));
            secTimeFrom = secTimeFrom - (minuteTimeFrom * (60));

            int milisecTimeTo = timeTo % 1000;
            int secTimeTo = timeTo / 1000;
            int hourTimeTo = (int)(Math.Floor((double)secTimeTo / (60 * 60)));
            secTimeTo = secTimeTo - (hourTimeTo * (60 * 60));
            int minuteTimeTo = (int)(Math.Floor((double)secTimeTo / (60)));
            secTimeTo = secTimeTo - (minuteTimeTo * (60));

            string milisecFromStr = milisecTimeFrom.ToString();
            string secTimeFromStr = secTimeFrom.ToString();
            string minuteTimeFromStr = minuteTimeFrom.ToString();
            string hourTimeFromStr = hourTimeFrom.ToString();

            string milisecToStr = milisecTimeTo.ToString();
            string secTimeToStr = secTimeTo.ToString();
            string minuteTimeToStr = minuteTimeTo.ToString();
            string hourTimeToStr = hourTimeTo.ToString();

            if (hourTimeFrom < 10)
            {
                hourTimeFromStr = "0" + hourTimeFromStr;
            }
            if (hourTimeTo < 10)
            {
                hourTimeToStr = "0" + hourTimeToStr;

            }

            if (minuteTimeFrom < 10)
            {
                minuteTimeFromStr = "0" + minuteTimeFromStr;

            }
            if (minuteTimeTo < 10)
            {
                minuteTimeToStr = "0" + minuteTimeToStr;

            }
            if (secTimeFrom < 10)
            {
                secTimeFromStr = "0" + secTimeFromStr;
            }

            if (secTimeTo < 10)
            {
                secTimeToStr = "0" + secTimeToStr;
            }

            if (milisecTimeFrom < 100)
            {
                if (milisecTimeFrom < 10)
                {
                    milisecFromStr = "00" + milisecFromStr;

                }
                else
                {
                    milisecFromStr = "0" + milisecFromStr;

                }
            }
            if (milisecTimeTo < 100)
            {
                if (milisecTimeTo < 10)
                {
                    milisecToStr = "00" + milisecToStr;
                }
                else
                {
                    milisecToStr = "0" + milisecToStr;
                }
            }
            text = preProcessTextInSub(text);
            formated = index.ToString() + "\n" + hourTimeFromStr + ":" + minuteTimeFromStr + ":" + secTimeFromStr + "," + milisecFromStr + " --> " + hourTimeToStr + ":" + minuteTimeToStr + ":" + secTimeToStr + "," + milisecToStr + "\n " + text + "\n" + "\n";


            return formated;
        }
        public string preProcessTextInSub(string text)
        {
            if (text.CompareTo("") == 0)
            {
                return text;
            }
            string proceedText = text;
            var collection = Regex.Matches(text, @"^\d+$", RegexOptions.Multiline);
            foreach (Match record in collection)
            {
                proceedText = proceedText.Replace(record.Value, "");
                int i = 0;
            }

            return proceedText;
        }
        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            ShuffleProc();
        }

        public void ShuffleProc()
        {
            if (textBoxGrayScaleInput.Text.CompareTo("") == 0)
            {
                return;
            }
            bool useSISThreshHold = checkBoxThreshhold.Checked;
            bool useGrayscale = checkBoxGrayscale.Checked;
            string grayscale_filepath = "";
            DirectoryInfo dir = new DirectoryInfo(textBoxGrayScaleInput.Text);
            if (!dir.Exists)
            {
                return;
            }
            int randomIndex = random.Next(dir.GetFiles().Length - 1);
            FileInfo file = dir.GetFiles()[randomIndex];
            labelGrayscaleName.Text = file.Name;
            grayscale_filepath = file.FullName;
            displayFile = file.FullName;
            displayFileName = file.Name;
            Bitmap bitmap = new Bitmap(grayscale_filepath);
            Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            if (useGrayscale)
            {
                // Chuyền thành màu xám
                bitmap = grayFilter.Apply(bitmap);
            }
            else if (useSISThreshHold)
            {
                Bitmap grImage = grayFilter.Apply(bitmap);
                SISThreshold filter = new SISThreshold();
                filter.ApplyInPlace(grImage);
                bitmap = grImage;

            }
            else if (useGrayscale && useSISThreshHold)
            {
                bitmap = grayFilter.Apply(bitmap);
            }
            pictureBoxGrayscale.BackgroundImage = bitmap;
            pictureBoxGrayscale.Refresh();
            bitmap.Dispose();
        }
        private void buttonQuickTestOCR_Click(object sender, EventArgs e)
        {

            try
            {
                bool useSISThreshHold = checkBoxThreshhold.Checked;
                bool useGrayscale = checkBoxGrayscale.Checked;
                if (displayFile.CompareTo("") == 0 || !File.Exists(displayFile))
                {
                    return;
                }
                string picPath = displayFile;
                Bitmap bitmap = new Bitmap(displayFile);
                string randomtest = RandomString(7);
                labelGrayScaleTestID.Text = randomtest;
                string bitmapSavePath = "quick_test_" + randomtest + "_" + displayFileName;
                Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
                if (useGrayscale)
                {
                    // Chuyền thành màu xám
                    bitmap = grayFilter.Apply(bitmap);
                }
                else if (useSISThreshHold)
                {
                    Bitmap grImage = grayFilter.Apply(bitmap);
                    SISThreshold filter = new SISThreshold();
                    filter.ApplyInPlace(grImage);
                    bitmap = grImage;

                }
                else if (useGrayscale && useSISThreshHold)
                {
                    bitmap = grayFilter.Apply(bitmap);
                }
                bitmap.Save(System.Windows.Forms.Application.StartupPath + @"\" + bitmapSavePath);
                bitmap.Dispose();
                if (radioButtonEasyOCR.Checked)
                {
                    Thread t = new Thread(() =>
                    {
                        ProcessStartInfo start = new ProcessStartInfo();
                        start.WorkingDirectory = Environment.CurrentDirectory;
                        start.FileName = "cmd.exe";
                        start.Arguments = @"/k chcp 65001 & @echo off & python -u ../../pyocrsingle.py --image " + bitmapSavePath + " & exit";
                        start.UseShellExecute = false;
                        start.RedirectStandardOutput = true;
                        start.RedirectStandardError = true;
                        start.CreateNoWindow = true;


                        using (Process process = new Process())
                        {
                            process.StartInfo = start;
                            process.EnableRaisingEvents = true;
                            process.ErrorDataReceived += Process_OutputDataReceived;
                            process.OutputDataReceived += Process_OutputDataReceived;
                            process.Start();
                            process.BeginErrorReadLine();
                            process.BeginOutputReadLine();
                        }
                        Console.Read();

                    });
                    t.Start();
                }
                else
                {
                    string result = OCRPic(bitmapSavePath);
                    File.WriteAllText(bitmapSavePath.Split('.')[0] + "_tesseract.txt", result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }
        private void button3_Click(object sender, EventArgs e)
        {
            

        }
        public void CropProc()
        {
            string cropInput = textBoxCropFolder.Text;
            if (cropInput.CompareTo("") == 0)
            {
                return;
            }
            string folder_path = System.Windows.Forms.Application.StartupPath + @"\" + cropInput;
            DirectoryInfo input_folder = new DirectoryInfo(folder_path);
            if (!input_folder.Exists)
            {
                MessageBox.Show("Not found pictures path: " + folder_path);
                return;
            }
            string folder_cropped_path = System.Windows.Forms.Application.StartupPath + @"\" + cropInput + "_cropped";
            if (!File.Exists(folder_cropped_path))
            {
                System.IO.Directory.CreateDirectory(folder_cropped_path);
            }

            StartCropped(cropInput);
        }

        public void StartCropped(string cropInput = "", DirectoryInfo input_folder=null)
        {
            try
            {
                //DirectoryInfo di = Directory.CreateDirectory(folder_cropped_path);

                // Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");

                toolStripProgressBar1.Maximum = input_folder.GetFiles().Length;
                toolStripProgressBar1.Value = 0;
                pictureBoxLoading.Image = Properties.Resources.loading_gif;
                pictureBoxLoading.Refresh();

                Thread t = new Thread(() =>
                {
                    int index = 0;
                    foreach (FileInfo file in input_folder.GetFiles())
                    {
                        CropPic(file.FullName, cropInput + @"_cropped\" + file.Name);
                        index++;
                        toolStripProgressBar1.PerformStep();
                    }
                    textBoxOCR.Text = cropInput + @"_cropped";
                    textBoxGrayScaleInput.Text = cropInput + @"_cropped";
                    toolStripProgressBar1.Value = 0;

                    pictureBoxLoading.Image = Properties.Resources._1398911_correct_mark_success_tick_valid_icon;
                    pictureBoxLoading.Refresh();
                });
                t.Start();

                AddToXMLAndToTreeView(fileID, "cropped", cropInput + "_cropped");

            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.Message);
            }
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            output_filename = "";
            filepath = "";
            displayFile = "";
            displayFileName = "";
            textBoxCropFolder.Clear();
            textBoxCropHeight.Clear();
            textBoxCropWidth.Clear();
            textBoxCropX.Clear();
            textBoxCropY.Clear();
            textBoxExtractFolder.Clear();
            textBoxGrayScaleInput.Clear();
            textBoxGrayScaleOutput.Clear();
            textBoxOCR.Clear();
            richTextBoxStatus.Clear();
            checkBoxFullHeightCrop.Checked = false;
            checkBoxGrayscale.Checked = false;
            checkBoxNail.Checked = false;
            checkBoxThreshhold.Checked = false;
            pictureBoxLoading.Image.Dispose();
            pictureBoxLoading.Image = null;
            pictureBoxLoading.Refresh();

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            for (int j = 0; j < PROCESS_MAXIMUM; j++)
            {
                backgroundWorker.ReportProgress(j);
            }


        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            richTextBoxStatus.Text += "Finish run proc\n";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initPlayer();

            initToolTip();

            initTreviewLog();
        }
        public static string LogFileName = System.Windows.Forms.Application.StartupPath + "//log.xml";
        public XDocument xml = null;
        public void WriteToXMLLogFile(string filename)
        {
            xml.Save(filename);
        }

        public void ReadXMLLogFile(string filename)
        {
            if (!File.Exists(filename))
            {
                File.WriteAllText(filename, @"<?xml version=""1.0""?>
                    <!-- This is a sample XML document -->
                    <!DOCTYPE Items [<!ENTITY number ""123"">]>
                    <Logs>
                      <Log SessionName="""">
                        <Extract></Extract>
                        <Crop></Crop>
                        <Crop_GrayScale></Crop_GrayScale>
                      </Log>
                    </Logs>");
                return;
            }
            try
            {
                xml = XDocument.Load(filename);
                foreach (XElement c in xml.Descendants("Logs"))
                {
                    foreach (XElement t in xml.Descendants("Log"))
                    {
                        TreeNode node = ReadXMLAndGenerateTreeNode(t);
                        treeViewLog.Nodes.Add(node);
                    }

                }
                //Console.WriteLine(xml.Descendants("Logs").First().Element("Log").Element("SessionName").Value);

            }
            catch { }
            finally
            {
                if (xml != null)
                {

                }
            }

        }

        private void initTreviewLog()
        {
            //treeViewLog.Nodes.Clear();
            //TreeNode treeNode = new TreeNode() { Text = "Test" };
            //TreeNode treeChild = new TreeNode() { Text = "Test2" };
            //AddTreeNodeToParentTreeNode(treeChild, treeNode);
            //treeViewLog.Nodes.Add(treeNode);

            

            ReadXMLLogFile(LogFileName);
            treeViewLog.AfterSelect += TreeViewLog_AfterSelect;

        }

        private void TreeViewLog_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var fullNodePath = e.Node.FullPath;
            var selectedNode = e.Node;
            XElement xElement = null;

            try
            {
                var parentNode= selectedNode.Parent;
                if(parentNode != null)
                {
                    var parentXML=parentNode.Tag as XElement;
                    fileID=parentXML.Attribute("SessionName").Value.ToString();

                }
                else
                {
                    var selectedXML=selectedNode.Tag as XElement;
                    fileID = selectedXML.Attribute("SessionName").Value.ToString();
                }

                
                xElement=selectedNode.Tag as XElement;
                if(xElement == null)
                {
                    return;
                }
                string xmlValue = xElement.Value.ToString();
                string xmlName=xElement.Name.ToString();

                //textBoxOCR.Text = xmlValue;
                //switch (xmlName)
                //{

                //    case "":

                //        break;

                //    case "extract":
                //        textBoxCropFolder.Text= xmlValue;
                //        break;

                //    default:
                //        break;
                //}

                Clipboard.SetText(xmlValue);

            }
            catch
            {
            }
            finally { }
        }

        public TreeNode ReadXMLAndGenerateTreeNode(XElement element)
        {
            TreeNode treeNode = new TreeNode();
            if (element != null)
            {

                if ("Log".Equals(element.Name.ToString()))
                {
                    treeNode.Text = element.Attribute("SessionName").Value;
                    treeNode.Tag = element;
                }
                foreach (XElement t in element.Elements())
                {
                    
                    TreeNode child = new TreeNode();
                    child.Text = t.Value;
                    child.Tag = t;
                    AddTreeNodeToParentTreeNode(child, treeNode);
                    ReadXMLAndGenerateTreeNode(t);
                }

            }
            return treeNode;
        }

        public void AddTreeNodeToParentTreeNode(TreeNode node, TreeNode parent)
        {
            parent.Nodes.Add(node);
        }

        private void initToolTip()
        {
            toolTipGrayscale.SetToolTip(buttonGrayscale, "Bạn muốn grayscale ảnh không? Thao tác này giúp giảm tải cho việc OCR bằng cách chuyển màu ảnh thành trắng đen.\r\nNhưng đừng áp dụng đối với những video có font chữ sáng, sẽ bị giảm độ chính xác\r\nVà xin đừng grayscale video Bad Apple, vô nghĩa lắm.\r\nĐối với GoogleOCR, cần thiết lập API auth key, và nên dùng 1k ảnh mỗi tháng thôi.\r\n");
        }

        #region player
        public static LibVLC _libVLC = new LibVLC("--input-repeat=100");

        public const int defaultVolume = 70;
        public MediaPlayer _mp;
        public async void initPlayer()
        {

            _mp = new MediaPlayer(_libVLC);
            videoViewMain.MediaPlayer = _mp;
            _mp.Volume = defaultVolume;
            CheckForIllegalCrossThreadCalls = false;

            _mp.TimeChanged += delegate
            {
                try
                {
                    if (_mp.Time < 1 || _mp.Length < 1)
                    {
                        return;
                    };
                    decimal timeValue = Math.Round(Decimal.Divide(_mp.Time, _mp.Length) * 100, 3);
                    tkBrDuration.Value = (int)timeValue;
                }
                catch { }


            };
            _mp.MediaChanged += playerMediaChangedFunc;
            _mp.Playing += playerPlayingFunc;
            _mp.LengthChanged += playerLengthChangeFunc;
            _mp.TimeChanged += playerTimeChangedFunc;

        }

        public void playerMediaChangedFunc(object sender, EventArgs e)
        {
            ResetPlayer();
        }
        public void ResetPlayer()
        {
            _mp.Volume = defaultVolume;
            tkBrVolume.Value = defaultVolume;
            prevPlayedAudioBuffers = 0;
            prevDecodedAudio = 0;
        }
        public void playerLengthChangeFunc(object sender, EventArgs e)
        {

        }
        public int prevPlayedAudioBuffers = 0;
        public int prevDecodedAudio = 0;
        public void playerTimeChangedFunc(object sender, EventArgs e)
        {
            try
            {
                if (_mp.Media.Statistics.PlayedAudioBuffers > prevPlayedAudioBuffers)
                {
                    int currPlayedAudioBuffers = _mp.Media.Statistics.PlayedAudioBuffers - prevPlayedAudioBuffers;
                    prevPlayedAudioBuffers = _mp.Media.Statistics.PlayedAudioBuffers;

                }
                if (_mp.Media.Statistics.DecodedAudio > prevDecodedAudio)
                {
                    int currDecodedAudio = _mp.Media.Statistics.DecodedAudio - prevDecodedAudio;
                    prevPlayedAudioBuffers = _mp.Media.Statistics.DecodedAudio;

                }

                //Logger(currPlayedAudioBuffers.ToString(), NOTIFICATION.NORMAL);
                //Logger(currDecodedAudio.ToString(), NOTIFICATION.NORMAL);

                //_mp.Media.Statistics.DemuxReadBytes.ToString();
                foreach (var track in _mp.Media.Tracks)
                {
                    switch (track.TrackType)
                    {
                        case TrackType.Audio:
                            //lblBitrate.Text = _mp.Media.Statistics.ReadBytes.ToString() + " kbps";
                            //lblSampleRate.Text = _mp.Media.Statistics.DemuxBitrate + " kbps";
                            break;
                        case TrackType.Video:

                            break;
                        default: break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger(ex.Message, NOTIFICATION.EXCEPTION);
            }
        }
        public void LoadMediaInfo()
        {
            try
            {
                if (_mp.Media == null)
                {
                    return;
                }
                if (_mp.Media.Tracks.Length == 0)
                {
                    return;
                }
                foreach (var track in _mp.Media.Tracks)
                {
                    switch (track.TrackType)
                    {
                        case TrackType.Audio:
                            string encode = "";
                            switch (track.Codec.ToString())
                            {
                                case "1630826605":
                                    encode = "aac";
                                    break;
                                case "1937076303":
                                    encode = "opus";
                                    break;
                                case "1667329126":
                                    encode = "flac";
                                    break;
                                default: break;
                            }
                            break;
                        case TrackType.Video:
                            track.Data.Video.SarDen.ToString();
                            track.Data.Video.Projection.ToString();
                            track.Data.Video.FrameRateDen.ToString();
                            track.Data.Video.FrameRateNum.ToString();
                            track.Data.Video.Height.ToString();
                            track.Data.Video.Width.ToString();
                            track.Data.Video.Pose.ToString();

                            break;
                        default: break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger(ex.Message, NOTIFICATION.EXCEPTION);
                return;

            }


        }
        public void playerPlayingFunc(object sender, EventArgs e)
        {
            LoadMediaInfo();
        }

        public void player_play()
        {
            try
            {
                if (filepath.CompareTo("") == 0)
                {
                    return;
                }
                //_mp.Play(new Media(_libVLC, "https://chunk.lab.zalo.ai/12e44706386dd133887c/12e44706386dd133887c", FromType.FromLocation));
                _mp.Play(new Media(_libVLC, filepath, FromType.FromPath));
                int i = 0;
            }
            catch (Exception ex)
            {

            }
        }
        public void player_pause()
        {
            try
            {
                _mp.Pause();
            }
            catch (Exception ex)
            {

            }
        }
        public void player_stop()
        {
            try
            {
                _mp.Stop();
            }
            catch (Exception ex)
            {

            }
        }
        public void player_load()
        {
            try
            {
                _mp.Play(new Media(_libVLC, "../../tewi.mp4", FromType.FromLocation));
            }
            catch (Exception ex)
            {

            }
        }
        public void player_update() { }
        private void tkBrVolume_Scroll(object sender, EventArgs e)
        {

            _mp.Volume = tkBrVolume.Value;

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            player_play();
        }
        private void btnPause_Click(object sender, EventArgs e)
        {
            player_pause();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            player_stop();
        }


        private void tkBrDuration_Scroll(object sender, EventArgs e)
        {
            try
            {
                _mp.Pause();
                _mp.Position = (float)(tkBrDuration.Value) / 100;
                _mp.Play();
            }
            catch (Exception ex)
            {
                Logger(ex.Message, NOTIFICATION.EXCEPTION);

            }
        }

        #endregion

        #region Logger
        public int logCounter = 0;
        private void Logger(string message, NOTIFICATION level)
        {
            logCounter++;
            richTextBoxStatus.Text += "[" + level + "]: " + message + "\n";
            switch (level)
            {

                default: break;
            }
            if (logCounter == 100)
            {
                richTextBoxStatus.Clear();
                logCounter = 0;
            }
        }
        #endregion

        private void richTextBoxStatus_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            richTextBoxStatus.SelectionStart = richTextBoxStatus.Text.Length;
            // scroll it automatically
            richTextBoxStatus.ScrollToCaret();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {

            if (textBoxExtractFolder.Text.Trim().Length == 0)
            {
                return;
            }
            fileID = ExtractScreenshot(textBoxExtractFolder.Text, 2);


            AddToXMLAndToTreeView(fileID, "extract", "_extract_" + fileID);

            //ExtractScreenshotFFMPEGCore(textBoxExtractFolder.Text, folder_cropped_path, 2);



        }
        public string fileID = "";

        public void AddToXMLAndToTreeView(string fileID="",string job="",string fullJobName="")
        {
            XElement checkXml = xml.Descendants("Logs").Descendants("Log").FirstOrDefault(el => el.Attribute("SessionName") != null && fileID.Equals(el.Attribute("SessionName").Value.ToString()));
            XElement xmlLog = checkXml != null ? checkXml : new XElement("Log");

            
            if (checkXml == null) {
                xmlLog.SetAttributeValue("SessionName", fileID);
                xml.Element("Logs").AddFirst(xmlLog);
            }

            XElement logElement = new XElement(job, fullJobName);
         
            xmlLog.Add(logElement);

            WriteToXMLLogFile(LogFileName);//save to xml file


            TreeNode checkNode = treeViewLog.Nodes.Cast<TreeNode>().Where(r => r.Text.Equals(fileID)).ToArray().FirstOrDefault();
            TreeNode treeNode = checkNode != null ? checkNode : new TreeNode() { Text = fileID, Tag = xmlLog };

            TreeNode checkJobNode=treeNode.Nodes.Cast<TreeNode>().Where(r => r.Text.Equals(fullJobName)).ToArray().FirstOrDefault();
            TreeNode jobNode = checkJobNode!=null? checkJobNode : new TreeNode() { Text = fullJobName, Tag = xmlLog };

            if (checkNode == null) { 
                treeNode.Nodes.Add(jobNode);
                treeViewLog.Nodes.Add(treeNode);
            }
            if (checkJobNode == null)
            {
                //dùng Insert thì như dùng Add nhưng có khai báo vị trí thêm vào
                treeNode.Nodes.Add(jobNode);

            }
            
            if (treeNode != null)
            {
                Console.WriteLine(treeNode.Tag);
            }
            
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            OpenScreenshotFile();

        }

        #region Draw crop section

        private void videoViewMain_MouseClick(object sender, MouseEventArgs e)
        {
            //GetVideoCropShot(e, videoViewMain);



            double x = videoViewMain.PointToClient(Cursor.Position).X;
            double y = videoViewMain.PointToClient(Cursor.Position).Y;
            double videoViewMain_width = videoViewMain.Width;
            double videoViewMain_height = videoViewMain.Height;
            double x_percentage = (x / videoViewMain_width) * 100;
            double y_percentage = (y / videoViewMain_height) * 100;



            labelXScreen.Text = "X: " + x.ToString();
            labelYScreen.Text = "Y: " + y.ToString();

            labelXPercentScreen.Text = "%X: " + x_percentage.ToString();
            labelYPercentScreen.Text = "%Y: " + y_percentage.ToString();
        }
        private const uint Width = 320;
        private const uint Height = 180;

        private const uint BytePerPixel = 4;

        public void GetVideoCropShot(MouseEventArgs e, Control ctrl)
        {

            labelYScreen.Text = e.X.ToString() + " : " + e.Y.ToString();

            if (_mp != null)
            {
                uint video_width = 0;
                uint video_height = 0;
                uint video_pixel = 0;
                var size = videoViewMain.MediaPlayer.Size(video_pixel, ref video_width, ref video_height);
                labelXScreen.Text = video_pixel.ToString() + " : " + video_width.ToString() + " : " + video_height.ToString();
                string randomID = RandomString(8);
                string tempcropPath = System.Windows.Forms.Application.StartupPath + @"/crop_preview_" + randomID + ".png";

                int input_crop_X_percentage = (int)((double)(e.X * 100) / ctrl.Width);
                int input_crop_Y_percentage = (int)((double)(e.Y * 100) / ctrl.Height);
                int input_crop_X = (int)(video_width * (decimal)input_crop_X_percentage / 100);
                int input_crop_Y = (int)(video_height * (decimal)input_crop_Y_percentage / 100);
                int input_crop_height = (int)(video_height * (decimal)(100 - input_crop_Y_percentage) / 100);
                int input_crop_width = (int)(video_width * (decimal)(100 - input_crop_X_percentage) / 100);
                textBoxCropX.Text = input_crop_X_percentage.ToString();
                textBoxCropY.Text = input_crop_Y_percentage.ToString();
                textBoxCropHeight.Text = (100 - input_crop_Y_percentage).ToString();
                textBoxCropWidth.Text = (100 - input_crop_X_percentage).ToString();

                labelCrop.Text = "X%: " + input_crop_X_percentage + "; X:" + input_crop_X + "; Y%: " + input_crop_Y_percentage + "; Y:" + input_crop_Y + "\n" + "Width: " + input_crop_width + "; Height:" + input_crop_height + "\n" + "TotalX: " + (input_crop_width + input_crop_X) + "; TotalY: " + (input_crop_height + input_crop_Y);

                //var bitmap = FFMpeg.Snapshot(textBoxExtractFolder.Text, tempcropPath, new Size((int)video_width, (int)video_height), TimeSpan.FromSeconds((int)(_mp.Position*_mp.Length)));
                _mp.TakeSnapshot(0, tempcropPath, 0, 0);
                delete_files_path.Add(tempcropPath);
                Rectangle myROI = new Rectangle(input_crop_X, input_crop_Y, input_crop_width, input_crop_height);
                Mat img = CvInvoke.Imread(tempcropPath, Emgu.CV.CvEnum.ImreadModes.AnyColor);
                Mat cropped_img = new Mat(img, myROI);
                pictureBoxCrop.Refresh();
                pictureBoxCrop.BackgroundImage = cropped_img.ToBitmap();
                cropped_img.Dispose();
                img.Dispose();
                //cropped_img.Save(System.Windows.Forms.Application.StartupPath + @"/crop_preview_" + randomID + "_cropped.png");
                //cropped_img.Dispose();
                //img.Dispose();
                //File.Delete(tempcropPath);
            }
        }


        private void transparentPanelVideo_MouseClick(object sender, MouseEventArgs e)
        {
            //GetVideoCropShot(e, transparentPanelVideo);



            double x = transparentPanelVideo.PointToClient(Cursor.Position).X;
            double y = transparentPanelVideo.PointToClient(Cursor.Position).Y;
            double transparentPanelVideo_width = transparentPanelVideo.Width;
            double transparentPanelVideo_height = transparentPanelVideo.Height;
            double x_percentage = (x / transparentPanelVideo_width) * 100;
            double y_percentage = (y / transparentPanelVideo_height) * 100;



            labelXScreen.Text = "X: " + x.ToString();
            labelYScreen.Text = "Y: " + y.ToString();

            labelXPercentScreen.Text = "%X: " + x_percentage.ToString();
            labelYPercentScreen.Text = "%Y: " + y_percentage.ToString();
        }

        #endregion

        private void buttonTestcrop_Click(object sender, EventArgs e)
        {
            string source_folder = textBoxCropFolder.Text;
            if (source_folder.CompareTo("") == 0)
            {
                return;
            }

            try
            {
                string folder_path = System.Windows.Forms.Application.StartupPath + @"\" + source_folder;
                DirectoryInfo input_folder = new DirectoryInfo(folder_path);

                if (!input_folder.Exists)
                {
                    MessageBox.Show("Not found pictures path: " + folder_path);
                    return;
                }


                int randomIndex = random.Next(input_folder.GetFiles().Length - 1);
                FileInfo file = input_folder.GetFiles()[randomIndex];
                CropPic(file.FullName, null);


            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.Message);
            }
        }


        #region Clean temp files
        List<string> delete_files_path = new List<string>();
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (string file in delete_files_path)
            {
                File.Delete(file);
            }
        }
        #endregion

        private void trckBarCropWidth_Scroll(object sender, EventArgs e)
        {
            textBoxCropWidth.Text = (trckBarCropWidth.Value - Int32.Parse(textBoxCropX.Text)).ToString();
        }

        private void trckBarCropHeight_Scroll(object sender, EventArgs e)
        {
            textBoxCropHeight.Text = (trckBarCropHeight.Value).ToString();
        }

        public void enterNumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxCropX_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterNumberOnly(sender, e);
        }

        private void textBoxCropHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterNumberOnly(sender, e);
        }

        private void textBoxCropY_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterNumberOnly(sender, e);
        }

        private void textBoxCropWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterNumberOnly(sender, e);
        }

        private void transparentPnCrop_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.Black, 3);
                var point1 = new Point(0, 0);
                var point2 = new Point(50, 0);
                g.DrawLine(p, point1, point2);
            }
        }

        private void pictureBoxCrop_MouseDown(object sender, MouseEventArgs e)
        {
            double x = e.Location.X;
            double y = e.Location.Y;
            double crop_width = Convert.ToDouble(textBoxCropWidth.Text);
            double crop_height = Convert.ToDouble(textBoxCropHeight.Text);
            double picturebox_width = pictureBoxCrop.Width;
            double picturebox_height = pictureBoxCrop.Height;
            double x_percentage = (x / picturebox_width) * 100;
            double y_percentage = (y / picturebox_height) * 100;

            double over_width_percentage = (crop_width + x_percentage) < 100 ? crop_width : 100;
            double over_height_percentage = (crop_height + y_percentage) < 100 ? crop_height : 100;

            double draw_width = over_width_percentage >= 100 ? picturebox_width * (((100 - x_percentage)) / 100) : picturebox_width * (over_width_percentage / 100);
            double draw_height = over_height_percentage >= 100 ? picturebox_height * (((100 - y_percentage)) / 100) : picturebox_height * (over_height_percentage / 100);


            textBoxCropX.Text = Convert.ToInt32(x_percentage).ToString();
            textBoxCropY.Text = Convert.ToInt32(y_percentage).ToString();

            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                endPoint = new Point(e.Location.X + Convert.ToInt32(x_percentage + draw_width),
                     +Convert.ToInt32(y_percentage + draw_height));
                cropRect = new Rectangle();
                cropRect.X = Convert.ToInt32(e.Location.X);
                cropRect.Y = Convert.ToInt32(e.Location.Y);
                cropRect.Width = Convert.ToInt32(draw_width - 2);
                cropRect.Height = Convert.ToInt32(draw_height - 2);

                //cropRect.X = Convert.ToInt32(pictureBoxCrop.Width-70);
                //cropRect.Y = Convert.ToInt32(pictureBoxCrop.Height-30);
                //cropRect.Width = Convert.ToInt32(68);
                //cropRect.Height = Convert.ToInt32(28);

                ((PictureBox)sender).Invalidate(); // Force final redraw
            }
        }
        private Pen drawPen = new Pen(Color.Black, 2);
        private Point startPoint;
        private Point endPoint;
        private Rectangle cropRect;
        private void pictureBoxCrop_Paint(object sender, PaintEventArgs e)
        {
            // Draw the line on the panel
            if (startPoint != null)
            {
                e.Graphics.DrawRectangle(drawPen, cropRect);
                //e.Graphics.DrawLine(drawPen, startPoint, endPoint);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                SendGoogleOCRRequest();
            }
            catch (Exception ex)
            {
                richTextBoxStatus.Text = ex.Message;
            }


        }
    }


}
