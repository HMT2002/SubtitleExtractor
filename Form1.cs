using AForge.Imaging;
using AForge.Imaging.Filters;
using Emgu.CV;
using Emgu.CV.ImgHash;
using Emgu.CV.Structure;
using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            toolStripProgressBar1.Value = 0;
            SetConsoleOutputCP(65001);
            //Console.OutputEncoding = Encoding.UTF8;
            //Console.InputEncoding = System.Text.Encoding.UTF8;
        }
        string FFMPEG_PATH = "../../ffmpeg.exe";
        public Random random;
        string output_filename = "";
        string filepath = "";

        public string RandomString(int length)
        {

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public void process(string strParam)
        {
            try
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
                startInfo.Arguments = "/k " + strParam;

                process.StartInfo = startInfo;

                //while (!process.StandardOutput.EndOfStream)
                //{
                //    string line = process.StandardOutput.ReadLine();
                //    // do something with line
                //    richTextBoxStatus.Text += line + "\n";
                //}

                process.Start();

                process.WaitForExit();

                textBoxCropFolder.Text = output_filename;
                richTextBoxStatus.Text += "Finish extract!\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {


        }
        private void OpenScreenshotFile()
        {
            if (!File.Exists(FFMPEG_PATH))
            {
                MessageBox.Show("Cannot find ffmpeg.exe.");
                return;
            }
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = false;
                //dialog.Multiselect = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {

                    //foreach (string filename in dialog.FileNames)
                    //{
                    //    string ext = Path.GetExtension(dialog.FileName);
                    //    ExtractScreenshot(filename, 2);
                    //}
                    string filename = dialog.FileName;
                    this.filepath = filename;
                    textBoxExtractFolder.Text = filename;
                }
            }
        }

        public void ExtractScreenshot(string filename, int shotNumberPerSecond)
        {
            string fileID = RandomString(5);
            string folderpath = Environment.CurrentDirectory + @"\" + fileID;
            output_filename = fileID;

            bool exists = System.IO.Directory.Exists(folderpath);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(folderpath);
            }
            string strParam = "ffmpeg -i \"" + filename + "\" -vf fps=" + shotNumberPerSecond + " \"" + folderpath + "/out%04d.png\"";
            //if (MessageBox.Show("", strParam, MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            //{
            //    Clipboard.SetText(strParam);
            //}

            process(strParam);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //OCRPic(System.Windows.Forms.Application.StartupPath + @"\" + textBoxOCR.Text);
            StartOCRProc(textBoxOCR.Text);

            //backgroundWorker1.RunWorkerAsync();//start worker

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
                    start.Arguments = @"/k chcp 65001 & @echo off & python -u ../../pyocr.py --folder " + output_folder + @" --image out0064.png";
                    start.UseShellExecute = false;
                    start.RedirectStandardOutput = true;
                    start.RedirectStandardError = true;
                    //start.CreateNoWindow = true;


                    using (Process process = new Process())
                    {
                        process.StartInfo = start;
                        process.EnableRaisingEvents = true;
                        process.ErrorDataReceived += Process_OutputDataReceived;
                        process.OutputDataReceived += Process_OutputDataReceived;
                        process.Start();
                        process.BeginErrorReadLine();
                        process.BeginOutputReadLine();

                        //using (StreamReader reader = process.StandardOutput)
                        //{
                        //    string result = reader.ReadToEnd();
                        //    Console.Write(result);
                        //    byte[] bytes = Encoding.Default.GetBytes(result);
                        //    string myString = Encoding.UTF8.GetString(bytes);
                        //    richTextBoxStatus.Text += myString + "\n";

                        //}
                    }


                    //Process process = new Process() { StartInfo = start ,EnableRaisingEvents = true};
                    //process.ErrorDataReceived += Process_OutputDataReceived;
                    //process.OutputDataReceived += Process_OutputDataReceived;
                    //process.Start();
                    //process.BeginErrorReadLine();
                    //process.BeginOutputReadLine();
                    //process.WaitForExit();
                    Console.Read();

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
                richTextBoxStatus.Text += myString + "\n";
            }

        }
        public void OCRPic(string folder_path)
        {
            foreach (FileInfo file in new DirectoryInfo(folder_path).GetFiles())
            {
                Bitmap bitmap = new Bitmap(file.FullName);
                // Chuyền thành màu xám
                Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
                Bitmap grImage = grayFilter.Apply(bitmap);
                SISThreshold filter = new SISThreshold();
                // thêm filter 1 lần nữa
                filter.ApplyInPlace(grImage);


                //Bitmap revBlackAndWhite = new Bitmap(grImage.Width, grImage.Height);
                //Color b = Color.Black;
                //Color w = Color.White;
                //Color c = Color.White;
                //for (int i = 0; i < grImage.Width; i++)
                //{
                //    for (int y = 0; y < grImage.Height; y++)
                //    {
                //        c = grImage.GetPixel(i, y);
                //        if (c.ToArgb().Equals(b.ToArgb()))
                //        {
                //            revBlackAndWhite.SetPixel(i, y, w);
                //        }
                //        else if (c.ToArgb().Equals(w.ToArgb()))
                //        {
                //            revBlackAndWhite.SetPixel(i, y, b);
                //        }
                //        else
                //        {
                //            revBlackAndWhite.SetPixel(i, y, c);
                //        }
                //        //string folder_cropped_path = System.Windows.Forms.Application.StartupPath + @"\" + folder_path + @"\";
                //        //revBlackAndWhite.Save(folder_cropped_path +@"\"+ "revBlackAndWhite_" + i + ".png");
                //    }
                //}


                string result = "";
                Task.Factory.StartNew(() =>
                {
                    result = OCR(grImage);
                    richTextBoxStatus.Text += result + "\n";
                });
                //Thread t = new Thread(() =>
                //{
                //    string result = OCR(grImage);
                //    richTextBoxStatus.Text += result + "\n";
                //});
                //t.Start();

            }

        }
        public void CropPic(string input_filepath, string output_filepath)
        {
            Mat img = CvInvoke.Imread(input_filepath, Emgu.CV.CvEnum.ImreadModes.AnyColor);
            richTextBoxStatus.Text += "Height: " + img.Height + "Width: " + img.Width + "\n";

            Rectangle myROI = new Rectangle(0, img.Height - (((img.Height + 1) * 15) / 100), img.Width, (((img.Height + 1) * 15) / 100));
            Mat cropped_im = new Mat(img, myROI);
            cropped_im.Save(output_filepath);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string source_folder = textBoxCropFolder.Text;
            if (source_folder.CompareTo("") == 0)
            {
                return;
            }

            try
            {
                string folder_path = System.Windows.Forms.Application.StartupPath + @"\" + source_folder;
                if (!Directory.Exists(folder_path))
                {
                    MessageBox.Show("Not found pictures path: " + folder_path);
                    return;
                }

                string folder_cropped_path = System.Windows.Forms.Application.StartupPath + @"\" + source_folder + "_cropped";
                if (!File.Exists(folder_cropped_path))
                {
                    System.IO.Directory.CreateDirectory(folder_cropped_path);
                }
                DirectoryInfo di = Directory.CreateDirectory(folder_cropped_path);

                // Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");


                foreach (FileInfo file in new DirectoryInfo(folder_path).GetFiles())
                {
                    CropPic(file.FullName, source_folder + @"_cropped\" + file.Name);
                }
                textBoxOCR.Text = source_folder + @"_cropped";

            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.Message);
            }


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
        }

        #region player
        public static LibVLC _libVLC = new LibVLC("--input-repeat=100");

        public const int defaultVolume = 70;
        public MediaPlayer _mp;
        public void initPlayer()
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
            ExtractScreenshot(textBoxExtractFolder.Text, 2);

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            OpenScreenshotFile();

        }
    }
}
