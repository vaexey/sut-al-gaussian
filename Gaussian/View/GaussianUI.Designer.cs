namespace Gaussian
{
    partial class GaussianUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            historyList = new ListView();
            pictureBefore = new PictureBox();
            pictureAfter = new PictureBox();
            pictureSplitContainer = new SplitContainer();
            tabControl1 = new TabControl();
            tabPageSet = new TabPage();
            groupBox3 = new GroupBox();
            startBtn = new Button();
            label11 = new Label();
            destBtn = new Button();
            destBox = new TextBox();
            label10 = new Label();
            sourceBtn = new Button();
            sourceBox = new TextBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            label9 = new Label();
            threadsLabel = new Label();
            logicalCpuLabel = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            threadsTrack = new TrackBar();
            groupBox1 = new GroupBox();
            algorithmCombo = new ComboBox();
            label1 = new Label();
            tabPageView = new TabPage();
            histSplitContainer = new SplitContainer();
            histBefore = new PictureBox();
            histAfter = new PictureBox();
            tabPageAbout = new TabPage();
            label2 = new Label();
            mainTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBefore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureAfter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureSplitContainer).BeginInit();
            pictureSplitContainer.Panel1.SuspendLayout();
            pictureSplitContainer.Panel2.SuspendLayout();
            pictureSplitContainer.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageSet.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)threadsTrack).BeginInit();
            groupBox1.SuspendLayout();
            tabPageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)histSplitContainer).BeginInit();
            histSplitContainer.Panel1.SuspendLayout();
            histSplitContainer.Panel2.SuspendLayout();
            histSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)histBefore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)histAfter).BeginInit();
            tabPageAbout.SuspendLayout();
            SuspendLayout();
            // 
            // historyList
            // 
            historyList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            historyList.Location = new Point(0, 0);
            historyList.Name = "historyList";
            historyList.Size = new Size(367, 574);
            historyList.TabIndex = 0;
            historyList.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBefore
            // 
            pictureBefore.Dock = DockStyle.Fill;
            pictureBefore.Location = new Point(0, 0);
            pictureBefore.Name = "pictureBefore";
            pictureBefore.Size = new Size(397, 420);
            pictureBefore.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBefore.TabIndex = 1;
            pictureBefore.TabStop = false;
            // 
            // pictureAfter
            // 
            pictureAfter.Dock = DockStyle.Fill;
            pictureAfter.Location = new Point(0, 0);
            pictureAfter.Name = "pictureAfter";
            pictureAfter.Size = new Size(382, 420);
            pictureAfter.SizeMode = PictureBoxSizeMode.Zoom;
            pictureAfter.TabIndex = 2;
            pictureAfter.TabStop = false;
            // 
            // pictureSplitContainer
            // 
            pictureSplitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureSplitContainer.Location = new Point(6, 6);
            pictureSplitContainer.Name = "pictureSplitContainer";
            // 
            // pictureSplitContainer.Panel1
            // 
            pictureSplitContainer.Panel1.Controls.Add(pictureBefore);
            // 
            // pictureSplitContainer.Panel2
            // 
            pictureSplitContainer.Panel2.Controls.Add(pictureAfter);
            pictureSplitContainer.Size = new Size(783, 420);
            pictureSplitContainer.SplitterDistance = 397;
            pictureSplitContainer.TabIndex = 3;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPageSet);
            tabControl1.Controls.Add(tabPageView);
            tabControl1.Controls.Add(tabPageAbout);
            tabControl1.Location = new Point(373, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(803, 574);
            tabControl1.TabIndex = 4;
            // 
            // tabPageSet
            // 
            tabPageSet.Controls.Add(groupBox3);
            tabPageSet.Controls.Add(groupBox2);
            tabPageSet.Controls.Add(groupBox1);
            tabPageSet.Location = new Point(4, 24);
            tabPageSet.Name = "tabPageSet";
            tabPageSet.Padding = new Padding(3);
            tabPageSet.Size = new Size(795, 546);
            tabPageSet.TabIndex = 1;
            tabPageSet.Text = "Settings";
            tabPageSet.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(startBtn);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(destBtn);
            groupBox3.Controls.Add(destBox);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(sourceBtn);
            groupBox3.Controls.Add(sourceBox);
            groupBox3.Location = new Point(6, 228);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(783, 114);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Process";
            // 
            // startBtn
            // 
            startBtn.Anchor = AnchorStyles.Top;
            startBtn.Location = new Point(355, 80);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(75, 23);
            startBtn.TabIndex = 11;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(26, 54);
            label11.Name = "label11";
            label11.Size = new Size(104, 15);
            label11.TabIndex = 10;
            label11.Text = "Destination folder:";
            // 
            // destBtn
            // 
            destBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            destBtn.Location = new Point(702, 51);
            destBtn.Name = "destBtn";
            destBtn.Size = new Size(75, 23);
            destBtn.TabIndex = 9;
            destBtn.Text = "Browse...";
            destBtn.UseVisualStyleBackColor = true;
            destBtn.Click += destBtn_Click;
            // 
            // destBox
            // 
            destBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            destBox.Location = new Point(136, 51);
            destBox.Name = "destBox";
            destBox.Size = new Size(560, 23);
            destBox.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(65, 26);
            label10.Name = "label10";
            label10.Size = new Size(65, 15);
            label10.TabIndex = 7;
            label10.Text = "Source file:";
            // 
            // sourceBtn
            // 
            sourceBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sourceBtn.Location = new Point(702, 22);
            sourceBtn.Name = "sourceBtn";
            sourceBtn.Size = new Size(75, 23);
            sourceBtn.TabIndex = 1;
            sourceBtn.Text = "Browse...";
            sourceBtn.UseVisualStyleBackColor = true;
            sourceBtn.Click += sourceBtn_Click;
            // 
            // sourceBox
            // 
            sourceBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            sourceBox.Location = new Point(136, 22);
            sourceBox.Name = "sourceBox";
            sourceBox.Size = new Size(560, 23);
            sourceBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(threadsLabel);
            groupBox2.Controls.Add(logicalCpuLabel);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(threadsTrack);
            groupBox2.Location = new Point(6, 82);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(783, 140);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Threading";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 114);
            label3.Name = "label3";
            label3.Size = new Size(13, 15);
            label3.TabIndex = 0;
            label3.Text = "1";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Location = new Point(366, 114);
            label9.Name = "label9";
            label9.Size = new Size(48, 15);
            label9.TabIndex = 7;
            label9.Text = "Threads";
            // 
            // threadsLabel
            // 
            threadsLabel.Anchor = AnchorStyles.Top;
            threadsLabel.AutoSize = true;
            threadsLabel.Location = new Point(438, 55);
            threadsLabel.Name = "threadsLabel";
            threadsLabel.Size = new Size(19, 15);
            threadsLabel.TabIndex = 6;
            threadsLabel.Text = "64";
            // 
            // logicalCpuLabel
            // 
            logicalCpuLabel.Anchor = AnchorStyles.Top;
            logicalCpuLabel.AutoSize = true;
            logicalCpuLabel.Location = new Point(438, 31);
            logicalCpuLabel.Name = "logicalCpuLabel";
            logicalCpuLabel.Size = new Size(19, 15);
            logicalCpuLabel.TabIndex = 5;
            logicalCpuLabel.Text = "64";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(307, 55);
            label6.Name = "label6";
            label6.Size = new Size(125, 15);
            label6.TabIndex = 4;
            label6.Text = "Selected thread count:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new Point(324, 31);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 3;
            label5.Text = "Logical CPU count:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(754, 114);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 2;
            label4.Text = "64";
            // 
            // threadsTrack
            // 
            threadsTrack.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            threadsTrack.BackColor = SystemColors.Window;
            threadsTrack.Location = new Point(6, 84);
            threadsTrack.Maximum = 64;
            threadsTrack.Minimum = 1;
            threadsTrack.Name = "threadsTrack";
            threadsTrack.Size = new Size(771, 45);
            threadsTrack.TabIndex = 1;
            threadsTrack.Value = 1;
            threadsTrack.ValueChanged += threadsTrack_ValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(algorithmCombo);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(783, 70);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gaussian blur";
            // 
            // algorithmCombo
            // 
            algorithmCombo.Anchor = AnchorStyles.Top;
            algorithmCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            algorithmCombo.FormattingEnabled = true;
            algorithmCombo.Items.AddRange(new object[] { "GaussianHLL", "GaussianASM" });
            algorithmCombo.Location = new Point(356, 34);
            algorithmCombo.Name = "algorithmCombo";
            algorithmCombo.Size = new Size(121, 23);
            algorithmCombo.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(289, 37);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Algorithm:";
            // 
            // tabPageView
            // 
            tabPageView.Controls.Add(histSplitContainer);
            tabPageView.Controls.Add(pictureSplitContainer);
            tabPageView.Location = new Point(4, 24);
            tabPageView.Name = "tabPageView";
            tabPageView.Padding = new Padding(3);
            tabPageView.Size = new Size(795, 546);
            tabPageView.TabIndex = 0;
            tabPageView.Text = "View";
            tabPageView.UseVisualStyleBackColor = true;
            // 
            // histSplitContainer
            // 
            histSplitContainer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            histSplitContainer.Location = new Point(6, 432);
            histSplitContainer.Name = "histSplitContainer";
            // 
            // histSplitContainer.Panel1
            // 
            histSplitContainer.Panel1.Controls.Add(histBefore);
            // 
            // histSplitContainer.Panel2
            // 
            histSplitContainer.Panel2.Controls.Add(histAfter);
            histSplitContainer.Size = new Size(783, 106);
            histSplitContainer.SplitterDistance = 397;
            histSplitContainer.TabIndex = 5;
            // 
            // histBefore
            // 
            histBefore.Dock = DockStyle.Fill;
            histBefore.Location = new Point(0, 0);
            histBefore.Name = "histBefore";
            histBefore.Size = new Size(397, 106);
            histBefore.TabIndex = 1;
            histBefore.TabStop = false;
            // 
            // histAfter
            // 
            histAfter.Dock = DockStyle.Fill;
            histAfter.Location = new Point(0, 0);
            histAfter.Name = "histAfter";
            histAfter.Size = new Size(382, 106);
            histAfter.TabIndex = 2;
            histAfter.TabStop = false;
            // 
            // tabPageAbout
            // 
            tabPageAbout.Controls.Add(label2);
            tabPageAbout.Location = new Point(4, 24);
            tabPageAbout.Name = "tabPageAbout";
            tabPageAbout.Size = new Size(795, 546);
            tabPageAbout.TabIndex = 2;
            tabPageAbout.Text = "About";
            tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(795, 546);
            label2.TabIndex = 0;
            label2.Text = "Gaussian UI\r\n(c) 2024";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainTimer
            // 
            mainTimer.Enabled = true;
            mainTimer.Tick += mainTimer_Tick;
            // 
            // GaussianUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1188, 574);
            Controls.Add(tabControl1);
            Controls.Add(historyList);
            Name = "GaussianUI";
            Text = "Gaussian";
            Load += GaussianUI_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBefore).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureAfter).EndInit();
            pictureSplitContainer.Panel1.ResumeLayout(false);
            pictureSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureSplitContainer).EndInit();
            pictureSplitContainer.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageSet.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)threadsTrack).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPageView.ResumeLayout(false);
            histSplitContainer.Panel1.ResumeLayout(false);
            histSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)histSplitContainer).EndInit();
            histSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)histBefore).EndInit();
            ((System.ComponentModel.ISupportInitialize)histAfter).EndInit();
            tabPageAbout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView historyList;
        private PictureBox pictureBefore;
        private PictureBox pictureAfter;
        private SplitContainer pictureSplitContainer;
        private TabControl tabControl1;
        private TabPage tabPageView;
        private TabPage tabPageSet;
        private SplitContainer histSplitContainer;
        private PictureBox histBefore;
        private PictureBox histAfter;
        private GroupBox groupBox2;
        private TrackBar threadsTrack;
        private Label label3;
        private GroupBox groupBox1;
        private ComboBox algorithmCombo;
        private Label label1;
        private Label threadsLabel;
        private Label logicalCpuLabel;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label9;
        private GroupBox groupBox3;
        private Button startBtn;
        private Label label11;
        private Button destBtn;
        private TextBox destBox;
        private Label label10;
        private Button sourceBtn;
        private TextBox sourceBox;
        private TabPage tabPageAbout;
        private Label label2;
        private System.Windows.Forms.Timer mainTimer;
    }
}
