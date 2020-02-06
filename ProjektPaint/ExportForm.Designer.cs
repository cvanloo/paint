namespace ProjektPaint
{
    partial class ExportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm));
            this.labelExportAs = new System.Windows.Forms.Label();
            this.labelRecommended = new System.Windows.Forms.Label();
            this.labelOriginalPicture = new System.Windows.Forms.Label();
            this.cbJpegQuality = new System.Windows.Forms.ComboBox();
            this.labelJpegQuality = new System.Windows.Forms.Label();
            this.btnBmp = new System.Windows.Forms.PictureBox();
            this.btnJpeg = new System.Windows.Forms.PictureBox();
            this.btnPng = new System.Windows.Forms.PictureBox();
            this.pbExportIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnBmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnJpeg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExportIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelExportAs
            // 
            this.labelExportAs.AutoSize = true;
            this.labelExportAs.BackColor = System.Drawing.Color.Black;
            this.labelExportAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExportAs.ForeColor = System.Drawing.Color.White;
            this.labelExportAs.Location = new System.Drawing.Point(-1, 4);
            this.labelExportAs.Name = "labelExportAs";
            this.labelExportAs.Size = new System.Drawing.Size(115, 18);
            this.labelExportAs.TabIndex = 3;
            this.labelExportAs.Text = "Exportieren Als..";
            // 
            // labelRecommended
            // 
            this.labelRecommended.AutoSize = true;
            this.labelRecommended.ForeColor = System.Drawing.Color.LightGreen;
            this.labelRecommended.Location = new System.Drawing.Point(248, 32);
            this.labelRecommended.Name = "labelRecommended";
            this.labelRecommended.Size = new System.Drawing.Size(63, 13);
            this.labelRecommended.TabIndex = 5;
            this.labelRecommended.Text = "(Empfohlen)";
            // 
            // labelOriginalPicture
            // 
            this.labelOriginalPicture.AutoSize = true;
            this.labelOriginalPicture.ForeColor = System.Drawing.Color.LightGreen;
            this.labelOriginalPicture.Location = new System.Drawing.Point(248, 160);
            this.labelOriginalPicture.Name = "labelOriginalPicture";
            this.labelOriginalPicture.Size = new System.Drawing.Size(64, 13);
            this.labelOriginalPicture.TabIndex = 7;
            this.labelOriginalPicture.Text = "(Originalbild)";
            // 
            // cbJpegQuality
            // 
            this.cbJpegQuality.BackColor = System.Drawing.SystemColors.WindowText;
            this.cbJpegQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJpegQuality.ForeColor = System.Drawing.Color.LightGreen;
            this.cbJpegQuality.FormattingEnabled = true;
            this.cbJpegQuality.Items.AddRange(new object[] {
            "50L",
            "100L",
            "150L",
            "200L"});
            this.cbJpegQuality.Location = new System.Drawing.Point(295, 91);
            this.cbJpegQuality.Name = "cbJpegQuality";
            this.cbJpegQuality.Size = new System.Drawing.Size(84, 21);
            this.cbJpegQuality.TabIndex = 1;
            this.cbJpegQuality.SelectedIndexChanged += new System.EventHandler(this.cbJpegQuality_SelectedIndexChanged);
            // 
            // labelJpegQuality
            // 
            this.labelJpegQuality.AutoSize = true;
            this.labelJpegQuality.ForeColor = System.Drawing.Color.LightGreen;
            this.labelJpegQuality.Location = new System.Drawing.Point(248, 95);
            this.labelJpegQuality.Name = "labelJpegQuality";
            this.labelJpegQuality.Size = new System.Drawing.Size(46, 13);
            this.labelJpegQuality.TabIndex = 9;
            this.labelJpegQuality.Text = "Qualität:";
            // 
            // btnBmp
            // 
            this.btnBmp.BackgroundImage = global::ProjektPaint.Properties.Resources.File_Format_BitMap;
            this.btnBmp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBmp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBmp.Location = new System.Drawing.Point(194, 140);
            this.btnBmp.Name = "btnBmp";
            this.btnBmp.Size = new System.Drawing.Size(47, 52);
            this.btnBmp.TabIndex = 12;
            this.btnBmp.TabStop = false;
            this.btnBmp.Click += new System.EventHandler(this.btnChooseType_Click);
            // 
            // btnJpeg
            // 
            this.btnJpeg.BackgroundImage = global::ProjektPaint.Properties.Resources.File_Format_JPEG;
            this.btnJpeg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnJpeg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJpeg.Location = new System.Drawing.Point(194, 76);
            this.btnJpeg.Name = "btnJpeg";
            this.btnJpeg.Size = new System.Drawing.Size(45, 49);
            this.btnJpeg.TabIndex = 11;
            this.btnJpeg.TabStop = false;
            this.btnJpeg.Click += new System.EventHandler(this.btnChooseType_Click);
            // 
            // btnPng
            // 
            this.btnPng.BackgroundImage = global::ProjektPaint.Properties.Resources.File_Format_PNG1;
            this.btnPng.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPng.Location = new System.Drawing.Point(196, 12);
            this.btnPng.Name = "btnPng";
            this.btnPng.Size = new System.Drawing.Size(45, 58);
            this.btnPng.TabIndex = 10;
            this.btnPng.TabStop = false;
            this.btnPng.Click += new System.EventHandler(this.btnChooseType_Click);
            // 
            // pbExportIcon
            // 
            this.pbExportIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbExportIcon.Image = global::ProjektPaint.Properties.Resources.Data_Export;
            this.pbExportIcon.Location = new System.Drawing.Point(46, 41);
            this.pbExportIcon.Name = "pbExportIcon";
            this.pbExportIcon.Size = new System.Drawing.Size(132, 132);
            this.pbExportIcon.TabIndex = 6;
            this.pbExportIcon.TabStop = false;
            // 
            // ExportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(406, 199);
            this.Controls.Add(this.btnBmp);
            this.Controls.Add(this.btnJpeg);
            this.Controls.Add(this.btnPng);
            this.Controls.Add(this.labelJpegQuality);
            this.Controls.Add(this.cbJpegQuality);
            this.Controls.Add(this.labelOriginalPicture);
            this.Controls.Add(this.pbExportIcon);
            this.Controls.Add(this.labelRecommended);
            this.Controls.Add(this.labelExportAs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExportForm";
            this.ShowInTaskbar = false;
            this.Text = "Exportieren Als..";
            this.Load += new System.EventHandler(this.ExportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnBmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnJpeg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExportIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelExportAs;
        private System.Windows.Forms.Label labelRecommended;
        private System.Windows.Forms.PictureBox pbExportIcon;
        private System.Windows.Forms.Label labelOriginalPicture;
        private System.Windows.Forms.ComboBox cbJpegQuality;
        private System.Windows.Forms.Label labelJpegQuality;
        private System.Windows.Forms.PictureBox btnPng;
        private System.Windows.Forms.PictureBox btnJpeg;
        private System.Windows.Forms.PictureBox btnBmp;
    }
}