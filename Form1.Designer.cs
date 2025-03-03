namespace SubtitleExtractor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.labelCrop = new System.Windows.Forms.Label();
            this.transparentPanelVideo = new SubtitleExtractor.TransparentPanel();
            this.labelYScreen = new System.Windows.Forms.Label();
            this.labelXScreen = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxExtractFolder = new System.Windows.Forms.TextBox();
            this.videoViewMain = new LibVLCSharp.WinForms.VideoView();
            this.tkBrVolume = new System.Windows.Forms.TrackBar();
            this.btnPause = new System.Windows.Forms.Button();
            this.tkBrDuration = new System.Windows.Forms.TrackBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBoxCropHeight = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonTestcrop = new System.Windows.Forms.Button();
            this.checkBoxFullWidthCrop = new System.Windows.Forms.CheckBox();
            this.checkBoxFullHeightCrop = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCropWidth = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCropY = new System.Windows.Forms.TextBox();
            this.textBoxCropX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBoxCrop = new System.Windows.Forms.PictureBox();
            this.textBoxCropFolder = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButtonEasyOCR = new System.Windows.Forms.RadioButton();
            this.radioButtonTesseract = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBoxOCR = new System.Windows.Forms.PictureBox();
            this.textBoxOCR = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelGrayScaleTestID = new System.Windows.Forms.Label();
            this.buttonQuickTestOCR = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxNail = new System.Windows.Forms.CheckBox();
            this.labelGrayscaleName = new System.Windows.Forms.Label();
            this.checkBoxThreshhold = new System.Windows.Forms.CheckBox();
            this.checkBoxGrayscale = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGrayScaleOutput = new System.Windows.Forms.TextBox();
            this.pictureBoxGrayscale = new System.Windows.Forms.PictureBox();
            this.textBoxGrayScaleInput = new System.Windows.Forms.TextBox();
            this.buttonGrayscale = new System.Windows.Forms.Button();
            this.trckBarCropWidth = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBrVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBrDuration)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCrop)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOCR)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrayscale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarCropWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxLoading);
            this.panel1.Controls.Add(this.labelCrop);
            this.panel1.Controls.Add(this.transparentPanelVideo);
            this.panel1.Controls.Add(this.labelYScreen);
            this.panel1.Controls.Add(this.labelXScreen);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxExtractFolder);
            this.panel1.Controls.Add(this.videoViewMain);
            this.panel1.Controls.Add(this.tkBrVolume);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.tkBrDuration);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Location = new System.Drawing.Point(12, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 418);
            this.panel1.TabIndex = 0;
            // 
            // pictureBoxLoading
            // 
            this.pictureBoxLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxLoading.Location = new System.Drawing.Point(545, 366);
            this.pictureBoxLoading.Name = "pictureBoxLoading";
            this.pictureBoxLoading.Size = new System.Drawing.Size(45, 45);
            this.pictureBoxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLoading.TabIndex = 29;
            this.pictureBoxLoading.TabStop = false;
            // 
            // labelCrop
            // 
            this.labelCrop.AutoSize = true;
            this.labelCrop.Location = new System.Drawing.Point(17, 367);
            this.labelCrop.Name = "labelCrop";
            this.labelCrop.Size = new System.Drawing.Size(35, 13);
            this.labelCrop.TabIndex = 28;
            this.labelCrop.Text = "Crop: ";
            // 
            // transparentPanelVideo
            // 
            this.transparentPanelVideo.Location = new System.Drawing.Point(3, 38);
            this.transparentPanelVideo.Name = "transparentPanelVideo";
            this.transparentPanelVideo.Size = new System.Drawing.Size(550, 262);
            this.transparentPanelVideo.TabIndex = 27;
            this.transparentPanelVideo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.transparentPanelVideo_MouseClick);
            // 
            // labelYScreen
            // 
            this.labelYScreen.AutoSize = true;
            this.labelYScreen.Location = new System.Drawing.Point(398, 381);
            this.labelYScreen.Name = "labelYScreen";
            this.labelYScreen.Size = new System.Drawing.Size(23, 13);
            this.labelYScreen.TabIndex = 26;
            this.labelYScreen.Text = "Y:  ";
            // 
            // labelXScreen
            // 
            this.labelXScreen.AutoSize = true;
            this.labelXScreen.Location = new System.Drawing.Point(398, 366);
            this.labelXScreen.Name = "labelXScreen";
            this.labelXScreen.Size = new System.Drawing.Size(20, 13);
            this.labelXScreen.TabIndex = 25;
            this.labelXScreen.Text = "X: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Input:";
            // 
            // textBoxExtractFolder
            // 
            this.textBoxExtractFolder.Location = new System.Drawing.Point(43, 3);
            this.textBoxExtractFolder.Name = "textBoxExtractFolder";
            this.textBoxExtractFolder.Size = new System.Drawing.Size(400, 20);
            this.textBoxExtractFolder.TabIndex = 4;
            // 
            // videoViewMain
            // 
            this.videoViewMain.BackColor = System.Drawing.Color.White;
            this.videoViewMain.ForeColor = System.Drawing.Color.Transparent;
            this.videoViewMain.Location = new System.Drawing.Point(3, 38);
            this.videoViewMain.MediaPlayer = null;
            this.videoViewMain.Name = "videoViewMain";
            this.videoViewMain.Size = new System.Drawing.Size(550, 262);
            this.videoViewMain.TabIndex = 1;
            this.videoViewMain.Text = "videoViewMain";
            this.videoViewMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.videoViewMain_MouseClick);
            // 
            // tkBrVolume
            // 
            this.tkBrVolume.AutoSize = false;
            this.tkBrVolume.Location = new System.Drawing.Point(558, 38);
            this.tkBrVolume.Margin = new System.Windows.Forms.Padding(2);
            this.tkBrVolume.Maximum = 100;
            this.tkBrVolume.Name = "tkBrVolume";
            this.tkBrVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkBrVolume.Size = new System.Drawing.Size(32, 262);
            this.tkBrVolume.TabIndex = 20;
            this.tkBrVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkBrVolume.Value = 70;
            this.tkBrVolume.Scroll += new System.EventHandler(this.tkBrVolume_Scroll);
            // 
            // btnPause
            // 
            this.btnPause.Image = global::SubtitleExtractor.Properties.Resources.icon_pause_64;
            this.btnPause.Location = new System.Drawing.Point(290, 367);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(60, 40);
            this.btnPause.TabIndex = 23;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // tkBrDuration
            // 
            this.tkBrDuration.AutoSize = false;
            this.tkBrDuration.Location = new System.Drawing.Point(3, 305);
            this.tkBrDuration.Margin = new System.Windows.Forms.Padding(2);
            this.tkBrDuration.Maximum = 100;
            this.tkBrDuration.Name = "tkBrDuration";
            this.tkBrDuration.Size = new System.Drawing.Size(550, 32);
            this.tkBrDuration.TabIndex = 21;
            this.tkBrDuration.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkBrDuration.Scroll += new System.EventHandler(this.tkBrDuration_Scroll);
            // 
            // btnStart
            // 
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.Location = new System.Drawing.Point(224, 367);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(60, 40);
            this.btnStart.TabIndex = 22;
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBoxCropHeight
            // 
            this.textBoxCropHeight.Location = new System.Drawing.Point(140, 159);
            this.textBoxCropHeight.Name = "textBoxCropHeight";
            this.textBoxCropHeight.Size = new System.Drawing.Size(52, 20);
            this.textBoxCropHeight.TabIndex = 25;
            this.textBoxCropHeight.Text = "18";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.trckBarCropWidth);
            this.panel2.Controls.Add(this.buttonTestcrop);
            this.panel2.Controls.Add(this.checkBoxFullWidthCrop);
            this.panel2.Controls.Add(this.checkBoxFullHeightCrop);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.textBoxCropWidth);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBoxCropY);
            this.panel2.Controls.Add(this.textBoxCropX);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBoxCropHeight);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.pictureBoxCrop);
            this.panel2.Controls.Add(this.textBoxCropFolder);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(617, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 209);
            this.panel2.TabIndex = 1;
            // 
            // buttonTestcrop
            // 
            this.buttonTestcrop.Location = new System.Drawing.Point(300, 182);
            this.buttonTestcrop.Name = "buttonTestcrop";
            this.buttonTestcrop.Size = new System.Drawing.Size(65, 20);
            this.buttonTestcrop.TabIndex = 34;
            this.buttonTestcrop.Text = "Test crop";
            this.buttonTestcrop.UseVisualStyleBackColor = true;
            this.buttonTestcrop.Click += new System.EventHandler(this.buttonTestcrop_Click);
            // 
            // checkBoxFullWidthCrop
            // 
            this.checkBoxFullWidthCrop.AutoSize = true;
            this.checkBoxFullWidthCrop.Location = new System.Drawing.Point(198, 185);
            this.checkBoxFullWidthCrop.Name = "checkBoxFullWidthCrop";
            this.checkBoxFullWidthCrop.Size = new System.Drawing.Size(76, 17);
            this.checkBoxFullWidthCrop.TabIndex = 33;
            this.checkBoxFullWidthCrop.Text = "Full width?";
            this.checkBoxFullWidthCrop.UseVisualStyleBackColor = true;
            // 
            // checkBoxFullHeightCrop
            // 
            this.checkBoxFullHeightCrop.AutoSize = true;
            this.checkBoxFullHeightCrop.Location = new System.Drawing.Point(198, 164);
            this.checkBoxFullHeightCrop.Name = "checkBoxFullHeightCrop";
            this.checkBoxFullHeightCrop.Size = new System.Drawing.Size(80, 17);
            this.checkBoxFullHeightCrop.TabIndex = 17;
            this.checkBoxFullHeightCrop.Text = "Full height?";
            this.checkBoxFullHeightCrop.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(89, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Width%: ";
            // 
            // textBoxCropWidth
            // 
            this.textBoxCropWidth.Location = new System.Drawing.Point(140, 183);
            this.textBoxCropWidth.Name = "textBoxCropWidth";
            this.textBoxCropWidth.Size = new System.Drawing.Size(52, 20);
            this.textBoxCropWidth.TabIndex = 31;
            this.textBoxCropWidth.Text = "100";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(89, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Height%:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Y%:";
            // 
            // textBoxCropY
            // 
            this.textBoxCropY.Location = new System.Drawing.Point(33, 183);
            this.textBoxCropY.Name = "textBoxCropY";
            this.textBoxCropY.Size = new System.Drawing.Size(52, 20);
            this.textBoxCropY.TabIndex = 28;
            this.textBoxCropY.Text = "82";
            // 
            // textBoxCropX
            // 
            this.textBoxCropX.Location = new System.Drawing.Point(33, 159);
            this.textBoxCropX.Name = "textBoxCropX";
            this.textBoxCropX.Size = new System.Drawing.Size(52, 20);
            this.textBoxCropX.TabIndex = 27;
            this.textBoxCropX.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "X%:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Input:";
            // 
            // pictureBoxCrop
            // 
            this.pictureBoxCrop.BackgroundImage = global::SubtitleExtractor.Properties.Resources.crop_edit_interface_snniping_tool_cropping_reduce_64;
            this.pictureBoxCrop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxCrop.Location = new System.Drawing.Point(15, 29);
            this.pictureBoxCrop.Name = "pictureBoxCrop";
            this.pictureBoxCrop.Size = new System.Drawing.Size(350, 100);
            this.pictureBoxCrop.TabIndex = 4;
            this.pictureBoxCrop.TabStop = false;
            // 
            // textBoxCropFolder
            // 
            this.textBoxCropFolder.Location = new System.Drawing.Point(52, 3);
            this.textBoxCropFolder.Name = "textBoxCropFolder";
            this.textBoxCropFolder.Size = new System.Drawing.Size(242, 20);
            this.textBoxCropFolder.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(300, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 20);
            this.button3.TabIndex = 2;
            this.button3.Text = "Crop pic";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.radioButtonEasyOCR);
            this.panel3.Controls.Add(this.radioButtonTesseract);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.pictureBoxOCR);
            this.panel3.Controls.Add(this.textBoxOCR);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(1000, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(377, 209);
            this.panel3.TabIndex = 1;
            // 
            // radioButtonEasyOCR
            // 
            this.radioButtonEasyOCR.AutoSize = true;
            this.radioButtonEasyOCR.Checked = true;
            this.radioButtonEasyOCR.Location = new System.Drawing.Point(208, 136);
            this.radioButtonEasyOCR.Name = "radioButtonEasyOCR";
            this.radioButtonEasyOCR.Size = new System.Drawing.Size(71, 17);
            this.radioButtonEasyOCR.TabIndex = 16;
            this.radioButtonEasyOCR.TabStop = true;
            this.radioButtonEasyOCR.Text = "EasyOCR";
            this.radioButtonEasyOCR.UseVisualStyleBackColor = true;
            // 
            // radioButtonTesseract
            // 
            this.radioButtonTesseract.AutoSize = true;
            this.radioButtonTesseract.Location = new System.Drawing.Point(208, 153);
            this.radioButtonTesseract.Name = "radioButtonTesseract";
            this.radioButtonTesseract.Size = new System.Drawing.Size(72, 17);
            this.radioButtonTesseract.TabIndex = 15;
            this.radioButtonTesseract.TabStop = true;
            this.radioButtonTesseract.Text = "Tesseract";
            this.radioButtonTesseract.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Input:";
            // 
            // pictureBoxOCR
            // 
            this.pictureBoxOCR.BackgroundImage = global::SubtitleExtractor.Properties.Resources.document_scanning_QR_code_barcode_OCR_image_scanning__64;
            this.pictureBoxOCR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxOCR.Location = new System.Drawing.Point(15, 29);
            this.pictureBoxOCR.Name = "pictureBoxOCR";
            this.pictureBoxOCR.Size = new System.Drawing.Size(350, 100);
            this.pictureBoxOCR.TabIndex = 5;
            this.pictureBoxOCR.TabStop = false;
            // 
            // textBoxOCR
            // 
            this.textBoxOCR.Location = new System.Drawing.Point(52, 3);
            this.textBoxOCR.Name = "textBoxOCR";
            this.textBoxOCR.Size = new System.Drawing.Size(313, 20);
            this.textBoxOCR.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "OCR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Location = new System.Drawing.Point(12, 466);
            this.richTextBoxStatus.Name = "richTextBoxStatus";
            this.richTextBoxStatus.Size = new System.Drawing.Size(599, 110);
            this.richTextBoxStatus.TabIndex = 3;
            this.richTextBoxStatus.Text = "";
            this.richTextBoxStatus.TextChanged += new System.EventHandler(this.richTextBoxStatus_TextChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 583);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1389, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton6,
            this.toolStripButton7,
            this.toolStripSeparator2,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton12});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1389, 39);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = global::SubtitleExtractor.Properties.Resources._698831;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(65, 36);
            this.toolStripButton6.Text = "Add";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = global::SubtitleExtractor.Properties.Resources.focus_area_screenshot_take_picture_photography_64;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(78, 36);
            this.toolStripButton7.Text = "Extract";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::SubtitleExtractor.Properties.Resources.files_31_64;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(71, 36);
            this.toolStripButton1.Text = "Copy";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::SubtitleExtractor.Properties.Resources.scissorregular_106276;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(62, 36);
            this.toolStripButton2.Text = "Cut";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::SubtitleExtractor.Properties.Resources.Paste_26994;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(71, 36);
            this.toolStripButton3.Text = "Paste";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = global::SubtitleExtractor.Properties.Resources.delete_icon_129320;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(76, 36);
            this.toolStripButton4.Text = "Delete";
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.Image = global::SubtitleExtractor.Properties.Resources.refresh_14433;
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(82, 36);
            this.toolStripButton12.Text = "Refresh";
            this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelGrayScaleTestID);
            this.panel4.Controls.Add(this.buttonQuickTestOCR);
            this.panel4.Controls.Add(this.buttonShuffle);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.checkBoxNail);
            this.panel4.Controls.Add(this.labelGrayscaleName);
            this.panel4.Controls.Add(this.checkBoxThreshhold);
            this.panel4.Controls.Add(this.checkBoxGrayscale);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.textBoxGrayScaleOutput);
            this.panel4.Controls.Add(this.pictureBoxGrayscale);
            this.panel4.Controls.Add(this.textBoxGrayScaleInput);
            this.panel4.Controls.Add(this.buttonGrayscale);
            this.panel4.Location = new System.Drawing.Point(617, 257);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(760, 319);
            this.panel4.TabIndex = 5;
            // 
            // labelGrayScaleTestID
            // 
            this.labelGrayScaleTestID.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrayScaleTestID.Location = new System.Drawing.Point(287, 8);
            this.labelGrayScaleTestID.Name = "labelGrayScaleTestID";
            this.labelGrayScaleTestID.Size = new System.Drawing.Size(184, 18);
            this.labelGrayScaleTestID.TabIndex = 17;
            this.labelGrayScaleTestID.Text = "None";
            // 
            // buttonQuickTestOCR
            // 
            this.buttonQuickTestOCR.Location = new System.Drawing.Point(209, 290);
            this.buttonQuickTestOCR.Name = "buttonQuickTestOCR";
            this.buttonQuickTestOCR.Size = new System.Drawing.Size(108, 23);
            this.buttonQuickTestOCR.TabIndex = 16;
            this.buttonQuickTestOCR.Text = "Test nhanh OCR";
            this.buttonQuickTestOCR.UseVisualStyleBackColor = true;
            this.buttonQuickTestOCR.Click += new System.EventHandler(this.buttonQuickTestOCR_Click);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Location = new System.Drawing.Point(242, 261);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(75, 23);
            this.buttonShuffle.TabIndex = 15;
            this.buttonShuffle.Text = "Xóc";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Output:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Input:";
            // 
            // checkBoxNail
            // 
            this.checkBoxNail.AutoSize = true;
            this.checkBoxNail.Location = new System.Drawing.Point(201, 9);
            this.checkBoxNail.Name = "checkBoxNail";
            this.checkBoxNail.Size = new System.Drawing.Size(80, 17);
            this.checkBoxNail.TabIndex = 12;
            this.checkBoxNail.Text = "Neo lại ảnh";
            this.checkBoxNail.UseVisualStyleBackColor = true;
            // 
            // labelGrayscaleName
            // 
            this.labelGrayscaleName.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGrayscaleName.Location = new System.Drawing.Point(8, 8);
            this.labelGrayscaleName.Name = "labelGrayscaleName";
            this.labelGrayscaleName.Size = new System.Drawing.Size(184, 18);
            this.labelGrayscaleName.TabIndex = 11;
            this.labelGrayscaleName.Text = "None";
            // 
            // checkBoxThreshhold
            // 
            this.checkBoxThreshhold.AutoSize = true;
            this.checkBoxThreshhold.Location = new System.Drawing.Point(9, 283);
            this.checkBoxThreshhold.Name = "checkBoxThreshhold";
            this.checkBoxThreshhold.Size = new System.Drawing.Size(96, 17);
            this.checkBoxThreshhold.TabIndex = 10;
            this.checkBoxThreshhold.Text = "SISThreshhold";
            this.checkBoxThreshhold.UseVisualStyleBackColor = true;
            this.checkBoxThreshhold.CheckedChanged += new System.EventHandler(this.checkBoxThreshhold_CheckedChanged);
            // 
            // checkBoxGrayscale
            // 
            this.checkBoxGrayscale.AutoSize = true;
            this.checkBoxGrayscale.Location = new System.Drawing.Point(9, 260);
            this.checkBoxGrayscale.Name = "checkBoxGrayscale";
            this.checkBoxGrayscale.Size = new System.Drawing.Size(73, 17);
            this.checkBoxGrayscale.TabIndex = 9;
            this.checkBoxGrayscale.Text = "Grayscale";
            this.checkBoxGrayscale.UseVisualStyleBackColor = true;
            this.checkBoxGrayscale.CheckedChanged += new System.EventHandler(this.checkBoxGrayscale_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(481, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(267, 93);
            this.label1.TabIndex = 8;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // textBoxGrayScaleOutput
            // 
            this.textBoxGrayScaleOutput.Location = new System.Drawing.Point(56, 194);
            this.textBoxGrayScaleOutput.Name = "textBoxGrayScaleOutput";
            this.textBoxGrayScaleOutput.Size = new System.Drawing.Size(692, 20);
            this.textBoxGrayScaleOutput.TabIndex = 7;
            // 
            // pictureBoxGrayscale
            // 
            this.pictureBoxGrayscale.BackgroundImage = global::SubtitleExtractor.Properties.Resources.contrast_64;
            this.pictureBoxGrayscale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxGrayscale.Location = new System.Drawing.Point(8, 56);
            this.pictureBoxGrayscale.Name = "pictureBoxGrayscale";
            this.pictureBoxGrayscale.Size = new System.Drawing.Size(740, 132);
            this.pictureBoxGrayscale.TabIndex = 4;
            this.pictureBoxGrayscale.TabStop = false;
            // 
            // textBoxGrayScaleInput
            // 
            this.textBoxGrayScaleInput.Location = new System.Drawing.Point(56, 30);
            this.textBoxGrayScaleInput.Name = "textBoxGrayScaleInput";
            this.textBoxGrayScaleInput.Size = new System.Drawing.Size(692, 20);
            this.textBoxGrayScaleInput.TabIndex = 3;
            // 
            // buttonGrayscale
            // 
            this.buttonGrayscale.Location = new System.Drawing.Point(8, 220);
            this.buttonGrayscale.Name = "buttonGrayscale";
            this.buttonGrayscale.Size = new System.Drawing.Size(309, 35);
            this.buttonGrayscale.TabIndex = 2;
            this.buttonGrayscale.Text = "Grayscale";
            this.buttonGrayscale.UseVisualStyleBackColor = true;
            this.buttonGrayscale.Click += new System.EventHandler(this.button1_Click);
            // 
            // trckBarCropWidth
            // 
            this.trckBarCropWidth.AutoSize = false;
            this.trckBarCropWidth.Location = new System.Drawing.Point(2, 134);
            this.trckBarCropWidth.Margin = new System.Windows.Forms.Padding(2);
            this.trckBarCropWidth.Maximum = 100;
            this.trckBarCropWidth.Name = "trckBarCropWidth";
            this.trckBarCropWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trckBarCropWidth.Size = new System.Drawing.Size(373, 24);
            this.trckBarCropWidth.TabIndex = 30;
            this.trckBarCropWidth.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trckBarCropWidth.Scroll += new System.EventHandler(this.trckBarCropWidth_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 605);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.richTextBoxStatus);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoViewMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBrVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBrDuration)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCrop)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOCR)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrayscale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarCropWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBoxStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private LibVLCSharp.WinForms.VideoView videoViewMain;
        private System.Windows.Forms.TrackBar tkBrVolume;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.TrackBar tkBrDuration;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBoxCropFolder;
        private System.Windows.Forms.TextBox textBoxExtractFolder;
        private System.Windows.Forms.TextBox textBoxOCR;
        private System.Windows.Forms.PictureBox pictureBoxCrop;
        private System.Windows.Forms.PictureBox pictureBoxOCR;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxGrayScaleOutput;
        private System.Windows.Forms.PictureBox pictureBoxGrayscale;
        private System.Windows.Forms.TextBox textBoxGrayScaleInput;
        private System.Windows.Forms.Button buttonGrayscale;
        private System.Windows.Forms.CheckBox checkBoxThreshhold;
        private System.Windows.Forms.CheckBox checkBoxGrayscale;
        private System.Windows.Forms.Label labelGrayscaleName;
        private System.Windows.Forms.CheckBox checkBoxNail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCropHeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonQuickTestOCR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxCropWidth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxCropY;
        private System.Windows.Forms.TextBox textBoxCropX;
        private System.Windows.Forms.CheckBox checkBoxFullWidthCrop;
        private System.Windows.Forms.CheckBox checkBoxFullHeightCrop;
        private System.Windows.Forms.RadioButton radioButtonEasyOCR;
        private System.Windows.Forms.RadioButton radioButtonTesseract;
        private System.Windows.Forms.Label labelGrayScaleTestID;
        private System.Windows.Forms.Label labelYScreen;
        private System.Windows.Forms.Label labelXScreen;
        private TransparentPanel transparentPanelVideo;
        private System.Windows.Forms.Label labelCrop;
        private System.Windows.Forms.Button buttonTestcrop;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
        private System.Windows.Forms.TrackBar trckBarCropWidth;
    }
}

