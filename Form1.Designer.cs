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
            this.textBoxExtractFolder = new System.Windows.Forms.TextBox();
            this.videoViewMain = new LibVLCSharp.WinForms.VideoView();
            this.tkBrVolume = new System.Windows.Forms.TrackBar();
            this.btnPause = new System.Windows.Forms.Button();
            this.tkBrDuration = new System.Windows.Forms.TrackBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBoxCrop = new System.Windows.Forms.PictureBox();
            this.textBoxCropFolder = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxOCR = new System.Windows.Forms.PictureBox();
            this.textBoxOCR = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBoxStatus = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCrltCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutCtrlXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteCtrlVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllCrltAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGrayScaleOutput = new System.Windows.Forms.TextBox();
            this.pictureBoxGrayscale = new System.Windows.Forms.PictureBox();
            this.textBoxGrayScaleInput = new System.Windows.Forms.TextBox();
            this.buttonGrayscale = new System.Windows.Forms.Button();
            this.checkBoxGrayscale = new System.Windows.Forms.CheckBox();
            this.checkBoxThreshhold = new System.Windows.Forms.CheckBox();
            this.labelGrayscaleName = new System.Windows.Forms.Label();
            this.checkBoxNail = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPercentageFromBottom = new System.Windows.Forms.TextBox();
            this.buttonQuickTestOCR = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoViewMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBrVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBrDuration)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCrop)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOCR)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrayscale)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxPercentageFromBottom);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxExtractFolder);
            this.panel1.Controls.Add(this.videoViewMain);
            this.panel1.Controls.Add(this.tkBrVolume);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.tkBrDuration);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Location = new System.Drawing.Point(12, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(599, 367);
            this.panel1.TabIndex = 0;
            // 
            // textBoxExtractFolder
            // 
            this.textBoxExtractFolder.Location = new System.Drawing.Point(43, 3);
            this.textBoxExtractFolder.Name = "textBoxExtractFolder";
            this.textBoxExtractFolder.Size = new System.Drawing.Size(510, 20);
            this.textBoxExtractFolder.TabIndex = 4;
            // 
            // videoViewMain
            // 
            this.videoViewMain.BackColor = System.Drawing.Color.Black;
            this.videoViewMain.Location = new System.Drawing.Point(3, 38);
            this.videoViewMain.MediaPlayer = null;
            this.videoViewMain.Name = "videoViewMain";
            this.videoViewMain.Size = new System.Drawing.Size(550, 216);
            this.videoViewMain.TabIndex = 1;
            this.videoViewMain.Text = "videoViewMain";
            // 
            // tkBrVolume
            // 
            this.tkBrVolume.AutoSize = false;
            this.tkBrVolume.Location = new System.Drawing.Point(558, 38);
            this.tkBrVolume.Margin = new System.Windows.Forms.Padding(2);
            this.tkBrVolume.Maximum = 100;
            this.tkBrVolume.Name = "tkBrVolume";
            this.tkBrVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tkBrVolume.Size = new System.Drawing.Size(32, 144);
            this.tkBrVolume.TabIndex = 20;
            this.tkBrVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tkBrVolume.Value = 70;
            this.tkBrVolume.Scroll += new System.EventHandler(this.tkBrVolume_Scroll);
            // 
            // btnPause
            // 
            this.btnPause.Image = global::SubtitleExtractor.Properties.Resources.icon_pause_64;
            this.btnPause.Location = new System.Drawing.Point(290, 297);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(60, 40);
            this.btnPause.TabIndex = 23;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // tkBrDuration
            // 
            this.tkBrDuration.AutoSize = false;
            this.tkBrDuration.Location = new System.Drawing.Point(3, 260);
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
            this.btnStart.Location = new System.Drawing.Point(224, 297);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(60, 40);
            this.btnStart.TabIndex = 22;
            this.btnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.pictureBoxCrop);
            this.panel2.Controls.Add(this.textBoxCropFolder);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(617, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 182);
            this.panel2.TabIndex = 1;
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
            this.textBoxCropFolder.Size = new System.Drawing.Size(313, 20);
            this.textBoxCropFolder.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(106, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 35);
            this.button3.TabIndex = 2;
            this.button3.Text = "Crop pic";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.pictureBoxOCR);
            this.panel3.Controls.Add(this.textBoxOCR);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Location = new System.Drawing.Point(1000, 66);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(377, 179);
            this.panel3.TabIndex = 1;
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
            this.button2.Location = new System.Drawing.Point(106, 135);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 35);
            this.button2.TabIndex = 1;
            this.button2.Text = "OCR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBoxStatus
            // 
            this.richTextBoxStatus.Location = new System.Drawing.Point(12, 439);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 563);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1389, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1389, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.renameToolStripMenuItem,
            this.deleteDelToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.toolStripMenuItem1.Text = "New ";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.renameToolStripMenuItem.Text = "Rename        ";
            // 
            // deleteDelToolStripMenuItem
            // 
            this.deleteDelToolStripMenuItem.Name = "deleteDelToolStripMenuItem";
            this.deleteDelToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.deleteDelToolStripMenuItem.Text = "Delete        ";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exitToolStripMenuItem.Text = "Exit      ";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCrltCToolStripMenuItem,
            this.cutCtrlXToolStripMenuItem,
            this.pasteCtrlVToolStripMenuItem,
            this.toolStripSeparator1,
            this.selectAllCrltAToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // copyCrltCToolStripMenuItem
            // 
            this.copyCrltCToolStripMenuItem.Name = "copyCrltCToolStripMenuItem";
            this.copyCrltCToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.copyCrltCToolStripMenuItem.Text = "Copy          ";
            // 
            // cutCtrlXToolStripMenuItem
            // 
            this.cutCtrlXToolStripMenuItem.Name = "cutCtrlXToolStripMenuItem";
            this.cutCtrlXToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.cutCtrlXToolStripMenuItem.Text = "Cut            ";
            // 
            // pasteCtrlVToolStripMenuItem
            // 
            this.pasteCtrlVToolStripMenuItem.Name = "pasteCtrlVToolStripMenuItem";
            this.pasteCtrlVToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.pasteCtrlVToolStripMenuItem.Text = "Paste          ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // selectAllCrltAToolStripMenuItem
            // 
            this.selectAllCrltAToolStripMenuItem.Name = "selectAllCrltAToolStripMenuItem";
            this.selectAllCrltAToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.selectAllCrltAToolStripMenuItem.Text = "Select All    ";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconToolStripMenuItem,
            this.smallIconToolStripMenuItem,
            this.listToolStripMenuItem,
            this.detailsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // largeIconToolStripMenuItem
            // 
            this.largeIconToolStripMenuItem.Name = "largeIconToolStripMenuItem";
            this.largeIconToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.largeIconToolStripMenuItem.Text = "Large icons";
            // 
            // smallIconToolStripMenuItem
            // 
            this.smallIconToolStripMenuItem.Name = "smallIconToolStripMenuItem";
            this.smallIconToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.smallIconToolStripMenuItem.Text = "Small icons";
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.listToolStripMenuItem.Text = "List";
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.detailsToolStripMenuItem.Text = "Details";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for Update";
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
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
            this.toolStripButton7.Size = new System.Drawing.Size(79, 36);
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
            // 
            // panel4
            // 
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
            this.panel4.Location = new System.Drawing.Point(617, 254);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(760, 295);
            this.panel4.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(383, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(365, 80);
            this.label1.TabIndex = 8;
            this.label1.Text = "Bạn muốn Grayscale ảnh không? Thao tác này giúp giảm tải cho việc OCR bằng cách c" +
    "huyển màu ảnh thành trắng đen, nhưng đánh đổi độ chính xác đối với các font chữ " +
    "có màu sáng.\r\n";
            // 
            // textBoxGrayScaleOutput
            // 
            this.textBoxGrayScaleOutput.Location = new System.Drawing.Point(56, 162);
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
            this.pictureBoxGrayscale.Size = new System.Drawing.Size(740, 100);
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
            this.buttonGrayscale.Location = new System.Drawing.Point(56, 188);
            this.buttonGrayscale.Name = "buttonGrayscale";
            this.buttonGrayscale.Size = new System.Drawing.Size(309, 35);
            this.buttonGrayscale.TabIndex = 2;
            this.buttonGrayscale.Text = "Grayscale";
            this.buttonGrayscale.UseVisualStyleBackColor = true;
            this.buttonGrayscale.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxGrayscale
            // 
            this.checkBoxGrayscale.AutoSize = true;
            this.checkBoxGrayscale.Location = new System.Drawing.Point(57, 228);
            this.checkBoxGrayscale.Name = "checkBoxGrayscale";
            this.checkBoxGrayscale.Size = new System.Drawing.Size(73, 17);
            this.checkBoxGrayscale.TabIndex = 9;
            this.checkBoxGrayscale.Text = "Grayscale";
            this.checkBoxGrayscale.UseVisualStyleBackColor = true;
            this.checkBoxGrayscale.CheckedChanged += new System.EventHandler(this.checkBoxGrayscale_CheckedChanged);
            // 
            // checkBoxThreshhold
            // 
            this.checkBoxThreshhold.AutoSize = true;
            this.checkBoxThreshhold.Location = new System.Drawing.Point(57, 251);
            this.checkBoxThreshhold.Name = "checkBoxThreshhold";
            this.checkBoxThreshhold.Size = new System.Drawing.Size(96, 17);
            this.checkBoxThreshhold.TabIndex = 10;
            this.checkBoxThreshhold.Text = "SISThreshhold";
            this.checkBoxThreshhold.UseVisualStyleBackColor = true;
            this.checkBoxThreshhold.CheckedChanged += new System.EventHandler(this.checkBoxThreshhold_CheckedChanged);
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
            // checkBoxNail
            // 
            this.checkBoxNail.AutoSize = true;
            this.checkBoxNail.Location = new System.Drawing.Point(201, 9);
            this.checkBoxNail.Name = "checkBoxNail";
            this.checkBoxNail.Size = new System.Drawing.Size(44, 17);
            this.checkBoxNail.TabIndex = 12;
            this.checkBoxNail.Text = "Nail";
            this.checkBoxNail.UseVisualStyleBackColor = true;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Output:";
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Location = new System.Drawing.Point(290, 229);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(75, 23);
            this.buttonShuffle.TabIndex = 15;
            this.buttonShuffle.Text = "Shuffle";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Input:";
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
            // textBoxPercentageFromBottom
            // 
            this.textBoxPercentageFromBottom.Location = new System.Drawing.Point(429, 317);
            this.textBoxPercentageFromBottom.Name = "textBoxPercentageFromBottom";
            this.textBoxPercentageFromBottom.Size = new System.Drawing.Size(124, 20);
            this.textBoxPercentageFromBottom.TabIndex = 25;
            // 
            // buttonQuickTestOCR
            // 
            this.buttonQuickTestOCR.Location = new System.Drawing.Point(257, 258);
            this.buttonQuickTestOCR.Name = "buttonQuickTestOCR";
            this.buttonQuickTestOCR.Size = new System.Drawing.Size(108, 23);
            this.buttonQuickTestOCR.TabIndex = 16;
            this.buttonQuickTestOCR.Text = "Quick test OCR";
            this.buttonQuickTestOCR.UseVisualStyleBackColor = true;
            this.buttonQuickTestOCR.Click += new System.EventHandler(this.buttonQuickTestOCR_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1389, 585);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.richTextBoxStatus);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGrayscale)).EndInit();
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCrltCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutCtrlXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteCtrlVToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem selectAllCrltAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem largeIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smallIconToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
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
        private System.Windows.Forms.TextBox textBoxPercentageFromBottom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonQuickTestOCR;
    }
}

