namespace WindowsFormsApplication1
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTownMapBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.openWorldMapBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.openMineMapBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.showPassableStateBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom25Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom50Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom100Btn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mapPicture = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(950, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomLevelToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.showPassableStateBtn});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(45, 22);
            this.toolStripDropDownButton1.Text = "View";
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTownMapBtn,
            this.openWorldMapBtn,
            this.openMineMapBtn});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // openTownMapBtn
            // 
            this.openTownMapBtn.Name = "openTownMapBtn";
            this.openTownMapBtn.Size = new System.Drawing.Size(115, 22);
            this.openTownMapBtn.Text = "TOWN";
            this.openTownMapBtn.Click += new System.EventHandler(this.openTownMapBtn_Click);
            // 
            // openWorldMapBtn
            // 
            this.openWorldMapBtn.Name = "openWorldMapBtn";
            this.openWorldMapBtn.Size = new System.Drawing.Size(115, 22);
            this.openWorldMapBtn.Text = "WORLD";
            this.openWorldMapBtn.Click += new System.EventHandler(this.openWorldMapBtn_Click);
            // 
            // openMineMapBtn
            // 
            this.openMineMapBtn.Name = "openMineMapBtn";
            this.openMineMapBtn.Size = new System.Drawing.Size(115, 22);
            this.openMineMapBtn.Text = "MINE";
            this.openMineMapBtn.Click += new System.EventHandler(this.openMineMapBtn_Click);
            // 
            // showPassableStateBtn
            // 
            this.showPassableStateBtn.Name = "showPassableStateBtn";
            this.showPassableStateBtn.Size = new System.Drawing.Size(180, 22);
            this.showPassableStateBtn.Text = "Show passable state";
            this.showPassableStateBtn.Click += new System.EventHandler(this.showPassableStateBtn_Click);
            // 
            // zoomLevelToolStripMenuItem
            // 
            this.zoomLevelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoom25Btn,
            this.zoom50Btn,
            this.zoom100Btn});
            this.zoomLevelToolStripMenuItem.Name = "zoomLevelToolStripMenuItem";
            this.zoomLevelToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.zoomLevelToolStripMenuItem.Text = "Zoom Level";
            // 
            // zoom25Btn
            // 
            this.zoom25Btn.Name = "zoom25Btn";
            this.zoom25Btn.Size = new System.Drawing.Size(180, 22);
            this.zoom25Btn.Text = "25%";
            this.zoom25Btn.Click += new System.EventHandler(this.zoom25Btn_Click);
            // 
            // zoom50Btn
            // 
            this.zoom50Btn.Name = "zoom50Btn";
            this.zoom50Btn.Size = new System.Drawing.Size(180, 22);
            this.zoom50Btn.Text = "50%";
            this.zoom50Btn.Click += new System.EventHandler(this.zoom50Btn_Click);
            // 
            // zoom100Btn
            // 
            this.zoom100Btn.Name = "zoom100Btn";
            this.zoom100Btn.Size = new System.Drawing.Size(180, 22);
            this.zoom100Btn.Text = "100%";
            this.zoom100Btn.Click += new System.EventHandler(this.zoom100Btn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2MinSize = 180;
            this.splitContainer1.Size = new System.Drawing.Size(950, 625);
            this.splitContainer1.SplitterDistance = 766;
            this.splitContainer1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.mapPicture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 625);
            this.panel2.TabIndex = 1;
            // 
            // mapPicture
            // 
            this.mapPicture.Location = new System.Drawing.Point(0, 0);
            this.mapPicture.Name = "mapPicture";
            this.mapPicture.Size = new System.Drawing.Size(0, 0);
            this.mapPicture.TabIndex = 0;
            this.mapPicture.TabStop = false;
            this.mapPicture.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(180, 625);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 650);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem showPassableStateBtn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTownMapBtn;
        private System.Windows.Forms.ToolStripMenuItem openWorldMapBtn;
        private System.Windows.Forms.ToolStripMenuItem openMineMapBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox mapPicture;
        private System.Windows.Forms.ToolStripMenuItem zoomLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom25Btn;
        private System.Windows.Forms.ToolStripMenuItem zoom50Btn;
        private System.Windows.Forms.ToolStripMenuItem zoom100Btn;
    }
}

