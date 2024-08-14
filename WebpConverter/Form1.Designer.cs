namespace WebpConverter
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            addFileToolStripMenuItem = new ToolStripMenuItem();
            addDirectoryToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            modeToolStripMenuItem = new ToolStripMenuItem();
            encodeToolStripMenuItem = new ToolStripMenuItem();
            decodeToolStripMenuItem = new ToolStripMenuItem();
            toolToolStripMenuItem = new ToolStripMenuItem();
            optionToolStripMenuItem = new ToolStripMenuItem();
            concealableTabControl1 = new Controls.ConcealableTabControl();
            tabPage1 = new TabPage();
            button1 = new Button();
            groupBox1 = new GroupBox();
            checkBox3 = new CheckBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            comboBox1 = new ComboBox();
            button5 = new Button();
            progressBar1 = new ProgressBar();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            tabPage2 = new TabPage();
            button6 = new Button();
            groupBox2 = new GroupBox();
            checkBox4 = new CheckBox();
            label4 = new Label();
            numericUpDown2 = new NumericUpDown();
            label3 = new Label();
            comboBox2 = new ComboBox();
            button9 = new Button();
            button8 = new Button();
            button7 = new Button();
            button10 = new Button();
            progressBar2 = new ProgressBar();
            listView2 = new ListView();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog2 = new FolderBrowserDialog();
            menuStrip1.SuspendLayout();
            concealableTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            tabPage2.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, modeToolStripMenuItem, toolToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1384, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addFileToolStripMenuItem, addDirectoryToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(70, 20);
            fileToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // addFileToolStripMenuItem
            // 
            addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            addFileToolStripMenuItem.Size = new Size(183, 22);
            addFileToolStripMenuItem.Text = "ファイルを追加...(&F)";
            // 
            // addDirectoryToolStripMenuItem
            // 
            addDirectoryToolStripMenuItem.Name = "addDirectoryToolStripMenuItem";
            addDirectoryToolStripMenuItem.Size = new Size(183, 22);
            addDirectoryToolStripMenuItem.Text = "フォルダーを追加...(&D)";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(183, 22);
            exitToolStripMenuItem.Text = "終了(&X)";
            // 
            // modeToolStripMenuItem
            // 
            modeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { encodeToolStripMenuItem, decodeToolStripMenuItem });
            modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            modeToolStripMenuItem.Size = new Size(66, 20);
            modeToolStripMenuItem.Text = "モード(&M)";
            // 
            // encodeToolStripMenuItem
            // 
            encodeToolStripMenuItem.Checked = true;
            encodeToolStripMenuItem.CheckOnClick = true;
            encodeToolStripMenuItem.CheckState = CheckState.Checked;
            encodeToolStripMenuItem.Name = "encodeToolStripMenuItem";
            encodeToolStripMenuItem.Size = new Size(135, 22);
            encodeToolStripMenuItem.Text = "エンコード(&E)";
            // 
            // decodeToolStripMenuItem
            // 
            decodeToolStripMenuItem.CheckOnClick = true;
            decodeToolStripMenuItem.Name = "decodeToolStripMenuItem";
            decodeToolStripMenuItem.Size = new Size(135, 22);
            decodeToolStripMenuItem.Text = "デコード(&D)";
            // 
            // toolToolStripMenuItem
            // 
            toolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { optionToolStripMenuItem });
            toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            toolToolStripMenuItem.Size = new Size(66, 20);
            toolToolStripMenuItem.Text = "ツール(&T)";
            // 
            // optionToolStripMenuItem
            // 
            optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            optionToolStripMenuItem.Size = new Size(148, 22);
            optionToolStripMenuItem.Text = "オプション...(&O)";
            // 
            // concealableTabControl1
            // 
            concealableTabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            concealableTabControl1.ConcealedTab = false;
            concealableTabControl1.Controls.Add(tabPage1);
            concealableTabControl1.Controls.Add(tabPage2);
            concealableTabControl1.Location = new Point(12, 38);
            concealableTabControl1.Name = "concealableTabControl1";
            concealableTabControl1.SelectedIndex = 0;
            concealableTabControl1.Size = new Size(1360, 711);
            concealableTabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Controls.Add(button4);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(numericUpDown1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(button5);
            tabPage1.Controls.Add(progressBar1);
            tabPage1.Controls.Add(listView1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1352, 683);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "エンコード";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.Location = new Point(1151, 538);
            button1.Name = "button1";
            button1.Size = new Size(195, 23);
            button1.TabIndex = 8;
            button1.Text = "ファイルを追加...";
            button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(checkBox3);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(checkBox2);
            groupBox1.Location = new Point(1151, 74);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(193, 104);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "オプション";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(16, 72);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(139, 19);
            checkBox3.TabIndex = 4;
            checkBox3.Text = "Lossless モードで実行";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(16, 22);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(103, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "メタデータを保存";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(16, 47);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(139, 19);
            checkBox2.TabIndex = 2;
            checkBox2.Text = "アルファチャンネルを保存";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Location = new Point(1151, 625);
            button4.Name = "button4";
            button4.Size = new Size(195, 23);
            button4.TabIndex = 14;
            button4.Text = "全消去";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(1151, 596);
            button3.Name = "button3";
            button3.Size = new Size(195, 23);
            button3.TabIndex = 12;
            button3.Text = "削除";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(1151, 567);
            button2.Name = "button2";
            button2.Size = new Size(195, 23);
            button2.TabIndex = 10;
            button2.Text = "フォルダーを追加...";
            button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(1282, 15);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 5;
            label2.Text = "品質";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDown1.Location = new Point(1282, 37);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(62, 23);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.Value = new decimal(new int[] { 75, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(1151, 15);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 3;
            label1.Text = "圧縮方式";
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "最速", "速度重視", "標準 (※推奨)", "品質重視", "最高品質" });
            comboBox1.Location = new Point(1151, 37);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(119, 23);
            comboBox1.TabIndex = 2;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button5.Location = new Point(1151, 654);
            button5.Name = "button5";
            button5.Size = new Size(195, 23);
            button5.TabIndex = 16;
            button5.Text = "実行";
            button5.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(5, 654);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1139, 23);
            progressBar1.TabIndex = 1;
            // 
            // listView1
            // 
            listView1.AllowDrop = true;
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6, columnHeader7 });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(5, 7);
            listView1.Name = "listView1";
            listView1.OwnerDraw = true;
            listView1.Size = new Size(1139, 640);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ファイル名";
            columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "種類";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "サイズ (前)";
            columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "サイズ (後)";
            columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "サイズ割合";
            columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "パス";
            columnHeader6.Width = 280;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "ベースフォルダー";
            columnHeader7.Width = 280;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.White;
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(groupBox2);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(numericUpDown2);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Controls.Add(button9);
            tabPage2.Controls.Add(button8);
            tabPage2.Controls.Add(button7);
            tabPage2.Controls.Add(button10);
            tabPage2.Controls.Add(progressBar2);
            tabPage2.Controls.Add(listView2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1352, 683);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "デコード";
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button6.Location = new Point(1151, 538);
            button6.Name = "button6";
            button6.Size = new Size(195, 23);
            button6.TabIndex = 8;
            button6.Text = "ファイルを追加...";
            button6.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(checkBox4);
            groupBox2.Location = new Point(1151, 74);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(193, 54);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "オプション";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Checked = true;
            checkBox4.CheckState = CheckState.Checked;
            checkBox4.Location = new Point(16, 22);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(103, 19);
            checkBox4.TabIndex = 0;
            checkBox4.Text = "メタデータを保存";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(1282, 15);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 15;
            label4.Text = "JPG品質";
            // 
            // numericUpDown2
            // 
            numericUpDown2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDown2.Enabled = false;
            numericUpDown2.Location = new Point(1282, 37);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(62, 23);
            numericUpDown2.TabIndex = 4;
            numericUpDown2.Value = new decimal(new int[] { 75, 0, 0, 0 });
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(1151, 15);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 13;
            label3.Text = "フォーマット";
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "PNG", "JPG", "GIF", "BMP" });
            comboBox2.Location = new Point(1151, 37);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(119, 23);
            comboBox2.TabIndex = 2;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button9.Location = new Point(1151, 625);
            button9.Name = "button9";
            button9.Size = new Size(195, 23);
            button9.TabIndex = 14;
            button9.Text = "全消去";
            button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button8.Location = new Point(1151, 596);
            button8.Name = "button8";
            button8.Size = new Size(195, 23);
            button8.TabIndex = 12;
            button8.Text = "削除";
            button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button7.Location = new Point(1151, 567);
            button7.Name = "button7";
            button7.Size = new Size(195, 23);
            button7.TabIndex = 10;
            button7.Text = "フォルダーを追加...";
            button7.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            button10.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button10.Location = new Point(1151, 654);
            button10.Name = "button10";
            button10.Size = new Size(195, 23);
            button10.TabIndex = 16;
            button10.Text = "実行";
            button10.UseVisualStyleBackColor = true;
            // 
            // progressBar2
            // 
            progressBar2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar2.Location = new Point(5, 654);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(1139, 23);
            progressBar2.TabIndex = 2;
            // 
            // listView2
            // 
            listView2.AllowDrop = true;
            listView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader8, columnHeader9, columnHeader10, columnHeader11, columnHeader12, columnHeader13 });
            listView2.FullRowSelect = true;
            listView2.GridLines = true;
            listView2.Location = new Point(5, 7);
            listView2.Name = "listView2";
            listView2.OwnerDraw = true;
            listView2.Size = new Size(1139, 640);
            listView2.TabIndex = 0;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "ファイル名";
            columnHeader8.Width = 200;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "サイズ (前)";
            columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "サイズ (後)";
            columnHeader10.Width = 120;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "サイズ割合";
            columnHeader11.Width = 80;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "パス";
            columnHeader12.Width = 280;
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "ベースフォルダー";
            columnHeader13.Width = 280;
            // 
            // openFileDialog1
            // 
            openFileDialog1.Filter = "画像ファイル|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
            // 
            // openFileDialog2
            // 
            openFileDialog2.Filter = "WebPファイル|*.webp";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 761);
            Controls.Add(concealableTabControl1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(400, 420);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WebpConverter";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            concealableTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem modeToolStripMenuItem;
        private ToolStripMenuItem encodeToolStripMenuItem;
        private ToolStripMenuItem decodeToolStripMenuItem;
        private Controls.ConcealableTabControl concealableTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ProgressBar progressBar1;
        private ListView listView1;
        private Button button5;
        private ColumnHeader columnHeader1;
        private ListView listView2;
        private ColumnHeader columnHeader8;
        private Button button10;
        private ProgressBar progressBar2;
        private ToolStripMenuItem toolToolStripMenuItem;
        private ToolStripMenuItem optionToolStripMenuItem;
        private Label label1;
        private ComboBox comboBox1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private Button button4;
        private Button button3;
        private Button button2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private GroupBox groupBox1;
        private CheckBox checkBox3;
        private Button button9;
        private Button button8;
        private Button button7;
        private Label label3;
        private ComboBox comboBox2;
        private Label label4;
        private NumericUpDown numericUpDown2;
        private GroupBox groupBox2;
        private CheckBox checkBox4;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private ToolStripMenuItem addFileToolStripMenuItem;
        private ToolStripMenuItem addDirectoryToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private Button button1;
        private Button button6;
        private FolderBrowserDialog folderBrowserDialog1;
        private FolderBrowserDialog folderBrowserDialog2;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader9;
    }
}