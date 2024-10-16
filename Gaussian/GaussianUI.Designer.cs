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
            listView = new ListView();
            pictureBefore = new PictureBox();
            pictureAfter = new PictureBox();
            pictureSplitContainer = new SplitContainer();
            tabControl1 = new TabControl();
            tabPageSet = new TabPage();
            groupBox3 = new GroupBox();
            button3 = new Button();
            label11 = new Label();
            button2 = new Button();
            textBox2 = new TextBox();
            label10 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            label3 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            trackBar1 = new TrackBar();
            groupBox1 = new GroupBox();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            comboBox1 = new ComboBox();
            label1 = new Label();
            tabPageView = new TabPage();
            histSplitContainer = new SplitContainer();
            histBefore = new PictureBox();
            histAfter = new PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            tabPageView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)histSplitContainer).BeginInit();
            histSplitContainer.Panel1.SuspendLayout();
            histSplitContainer.Panel2.SuspendLayout();
            histSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)histBefore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)histAfter).BeginInit();
            SuspendLayout();
            // 
            // listView
            // 
            listView.Location = new Point(0, 0);
            listView.Name = "listView";
            listView.Size = new Size(268, 530);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBefore
            // 
            pictureBefore.Dock = DockStyle.Fill;
            pictureBefore.Location = new Point(0, 0);
            pictureBefore.Name = "pictureBefore";
            pictureBefore.Size = new Size(309, 376);
            pictureBefore.TabIndex = 1;
            pictureBefore.TabStop = false;
            // 
            // pictureAfter
            // 
            pictureAfter.Dock = DockStyle.Fill;
            pictureAfter.Location = new Point(0, 0);
            pictureAfter.Name = "pictureAfter";
            pictureAfter.Size = new Size(308, 376);
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
            pictureSplitContainer.Size = new Size(621, 376);
            pictureSplitContainer.SplitterDistance = 309;
            pictureSplitContainer.TabIndex = 3;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPageSet);
            tabControl1.Controls.Add(tabPageView);
            tabControl1.Location = new Point(274, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(641, 530);
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
            tabPageSet.Size = new Size(633, 502);
            tabPageSet.TabIndex = 1;
            tabPageSet.Text = "Settings";
            tabPageSet.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(button3);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(textBox2);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Location = new Point(6, 266);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(621, 114);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Process";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top;
            button3.Location = new Point(274, 80);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 11;
            button3.Text = "Start";
            button3.UseVisualStyleBackColor = true;
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
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(540, 51);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "Browse...";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(136, 51);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(398, 23);
            textBox2.TabIndex = 8;
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
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(540, 22);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Browse...";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(136, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(398, 23);
            textBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(trackBar1);
            groupBox2.Location = new Point(6, 120);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(621, 140);
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
            label9.Location = new Point(285, 114);
            label9.Name = "label9";
            label9.Size = new Size(48, 15);
            label9.TabIndex = 7;
            label9.Text = "Threads";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Location = new Point(357, 55);
            label8.Name = "label8";
            label8.Size = new Size(19, 15);
            label8.TabIndex = 6;
            label8.Text = "64";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Location = new Point(357, 31);
            label7.Name = "label7";
            label7.Size = new Size(19, 15);
            label7.TabIndex = 5;
            label7.Text = "64";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Location = new Point(226, 55);
            label6.Name = "label6";
            label6.Size = new Size(125, 15);
            label6.TabIndex = 4;
            label6.Text = "Selected thread count:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new Point(243, 31);
            label5.Name = "label5";
            label5.Size = new Size(108, 15);
            label5.TabIndex = 3;
            label5.Text = "Logical CPU count:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(592, 114);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 2;
            label4.Text = "64";
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBar1.BackColor = SystemColors.Window;
            trackBar1.Location = new Point(6, 84);
            trackBar1.Maximum = 64;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(609, 45);
            trackBar1.TabIndex = 1;
            trackBar1.Value = 1;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(numericUpDown1);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(621, 108);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gaussian blur";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new Point(194, 65);
            label2.Name = "label2";
            label2.Size = new Size(75, 15);
            label2.TabIndex = 3;
            label2.Text = "Kernel radius";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top;
            numericUpDown1.Location = new Point(274, 63);
            numericUpDown1.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(122, 23);
            numericUpDown1.TabIndex = 2;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(275, 34);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new Point(208, 37);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Algorithm";
            // 
            // tabPageView
            // 
            tabPageView.Controls.Add(histSplitContainer);
            tabPageView.Controls.Add(pictureSplitContainer);
            tabPageView.Location = new Point(4, 24);
            tabPageView.Name = "tabPageView";
            tabPageView.Padding = new Padding(3);
            tabPageView.Size = new Size(633, 502);
            tabPageView.TabIndex = 0;
            tabPageView.Text = "View";
            tabPageView.UseVisualStyleBackColor = true;
            // 
            // histSplitContainer
            // 
            histSplitContainer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            histSplitContainer.Location = new Point(6, 388);
            histSplitContainer.Name = "histSplitContainer";
            // 
            // histSplitContainer.Panel1
            // 
            histSplitContainer.Panel1.Controls.Add(histBefore);
            // 
            // histSplitContainer.Panel2
            // 
            histSplitContainer.Panel2.Controls.Add(histAfter);
            histSplitContainer.Size = new Size(621, 106);
            histSplitContainer.SplitterDistance = 309;
            histSplitContainer.TabIndex = 5;
            // 
            // histBefore
            // 
            histBefore.Dock = DockStyle.Fill;
            histBefore.Location = new Point(0, 0);
            histBefore.Name = "histBefore";
            histBefore.Size = new Size(309, 106);
            histBefore.TabIndex = 1;
            histBefore.TabStop = false;
            // 
            // histAfter
            // 
            histAfter.Dock = DockStyle.Fill;
            histAfter.Location = new Point(0, 0);
            histAfter.Name = "histAfter";
            histAfter.Size = new Size(308, 106);
            histAfter.TabIndex = 2;
            histAfter.TabStop = false;
            // 
            // GaussianUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 530);
            Controls.Add(tabControl1);
            Controls.Add(listView);
            Name = "GaussianUI";
            Text = "Gaussian";
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
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            tabPageView.ResumeLayout(false);
            histSplitContainer.Panel1.ResumeLayout(false);
            histSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)histSplitContainer).EndInit();
            histSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)histBefore).EndInit();
            ((System.ComponentModel.ISupportInitialize)histAfter).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListView listView;
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
        private TrackBar trackBar1;
        private Label label3;
        private GroupBox groupBox1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private ComboBox comboBox1;
        private Label label1;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label9;
        private GroupBox groupBox3;
        private Button button3;
        private Label label11;
        private Button button2;
        private TextBox textBox2;
        private Label label10;
        private Button button1;
        private TextBox textBox1;
    }
}
