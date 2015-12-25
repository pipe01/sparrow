namespace SLFEditor
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
            this.components = new System.ComponentModel.Container();
            this.lbLangs = new System.Windows.Forms.ListBox();
            this.btnCreateLan = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.listView1 = new System.Windows.Forms.ListView();
            this.colKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button5 = new System.Windows.Forms.Button();
            this.cmsTranslate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.googleTranslateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTranslate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLangs
            // 
            this.lbLangs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbLangs.FormattingEnabled = true;
            this.lbLangs.Location = new System.Drawing.Point(12, 12);
            this.lbLangs.Name = "lbLangs";
            this.lbLangs.Size = new System.Drawing.Size(89, 290);
            this.lbLangs.TabIndex = 3;
            this.lbLangs.SelectedIndexChanged += new System.EventHandler(this.lbLangs_SelectedIndexChanged);
            // 
            // btnCreateLan
            // 
            this.btnCreateLan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateLan.Location = new System.Drawing.Point(12, 308);
            this.btnCreateLan.Name = "btnCreateLan";
            this.btnCreateLan.Size = new System.Drawing.Size(89, 35);
            this.btnCreateLan.TabIndex = 4;
            this.btnCreateLan.Text = "Create language";
            this.btnCreateLan.UseVisualStyleBackColor = true;
            this.btnCreateLan.Click += new System.EventHandler(this.btnCreateLan_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(548, 308);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Create entry";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(467, 308);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 35);
            this.button3.TabIndex = 6;
            this.button3.Text = "Delete entry";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(107, 308);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 35);
            this.button4.TabIndex = 7;
            this.button4.Text = "Create from template";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 349);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Load folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colKey,
            this.colValue});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(107, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(516, 290);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_BeforeLabelEdit);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // colKey
            // 
            this.colKey.Text = "Key";
            this.colKey.Width = 128;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 150;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(386, 308);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 35);
            this.button5.TabIndex = 10;
            this.button5.Text = "Edit entry";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cmsTranslate
            // 
            this.cmsTranslate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.googleTranslateToolStripMenuItem});
            this.cmsTranslate.Name = "cmsTranslate";
            this.cmsTranslate.Size = new System.Drawing.Size(164, 48);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(305, 308);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 35);
            this.button6.TabIndex = 12;
            this.button6.Text = "Translate";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button6_MouseClick);
            // 
            // googleTranslateToolStripMenuItem
            // 
            this.googleTranslateToolStripMenuItem.Name = "googleTranslateToolStripMenuItem";
            this.googleTranslateToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.googleTranslateToolStripMenuItem.Text = "Google Translate";
            this.googleTranslateToolStripMenuItem.Click += new System.EventHandler(this.googleTranslateToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 391);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCreateLan);
            this.Controls.Add(this.lbLangs);
            this.Name = "Form1";
            this.Text = "Sparrow Language File Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cmsTranslate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lbLangs;
        private System.Windows.Forms.Button btnCreateLan;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader colKey;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ContextMenuStrip cmsTranslate;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ToolStripMenuItem googleTranslateToolStripMenuItem;
    }
}

