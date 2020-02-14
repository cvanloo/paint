using System.Windows.Forms;
namespace ProjektPaint
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mtbFrameThickness = new System.Windows.Forms.MaskedTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelDashStyle = new System.Windows.Forms.Label();
            this.btnDashDotted = new System.Windows.Forms.Button();
            this.btnDashDashed = new System.Windows.Forms.Button();
            this.btnDashSolid = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.cbFrameOuter = new System.Windows.Forms.CheckBox();
            this.cbFrameInner = new System.Windows.Forms.CheckBox();
            this.btnColFrame = new System.Windows.Forms.Button();
            this.cbFill = new System.Windows.Forms.CheckBox();
            this.btnColFill = new System.Windows.Forms.Button();
            this.btnColorForm = new System.Windows.Forms.Button();
            this.labelColor = new System.Windows.Forms.Label();
            this.labelStrenght = new System.Windows.Forms.Label();
            this.trackBarFormThickness = new System.Windows.Forms.TrackBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnSquare = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnFreehand = new System.Windows.Forms.Button();
            this.labelisSave = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiMenue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveUnder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiStartmenue = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFormThickness)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.BackColor = System.Drawing.SystemColors.Desktop;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1073, 566);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1073, 594);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.mtbFrameThickness);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnRedo);
            this.panel1.Controls.Add(this.btnUndo);
            this.panel1.Controls.Add(this.cbFrameOuter);
            this.panel1.Controls.Add(this.cbFrameInner);
            this.panel1.Controls.Add(this.btnColFrame);
            this.panel1.Controls.Add(this.cbFill);
            this.panel1.Controls.Add(this.btnColFill);
            this.panel1.Controls.Add(this.btnColorForm);
            this.panel1.Controls.Add(this.labelColor);
            this.panel1.Controls.Add(this.labelStrenght);
            this.panel1.Controls.Add(this.trackBarFormThickness);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1073, 54);
            this.panel1.TabIndex = 1;
            // 
            // mtbFrameThickness
            // 
            this.mtbFrameThickness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mtbFrameThickness.ForeColor = System.Drawing.Color.White;
            this.mtbFrameThickness.HidePromptOnLeave = true;
            this.mtbFrameThickness.Location = new System.Drawing.Point(656, 2);
            this.mtbFrameThickness.Mask = "00";
            this.mtbFrameThickness.Name = "mtbFrameThickness";
            this.mtbFrameThickness.Size = new System.Drawing.Size(75, 20);
            this.mtbFrameThickness.TabIndex = 18;
            this.mtbFrameThickness.Text = "1";
            this.toolTip1.SetToolTip(this.mtbFrameThickness, "Gibt die Strichdicke des Rahmens an. \r\nAkzeptierter Wert: 1 - 20");
            this.mtbFrameThickness.Click += new System.EventHandler(this.mtbFrameThickness_Click);
            this.mtbFrameThickness.TextChanged += new System.EventHandler(this.mtbFrameThickness_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelDashStyle);
            this.panel2.Controls.Add(this.btnDashDotted);
            this.panel2.Controls.Add(this.btnDashDashed);
            this.panel2.Controls.Add(this.btnDashSolid);
            this.panel2.Location = new System.Drawing.Point(224, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 49);
            this.panel2.TabIndex = 1;
            // 
            // labelDashStyle
            // 
            this.labelDashStyle.AutoSize = true;
            this.labelDashStyle.BackColor = System.Drawing.Color.Black;
            this.labelDashStyle.ForeColor = System.Drawing.Color.White;
            this.labelDashStyle.Location = new System.Drawing.Point(7, 6);
            this.labelDashStyle.Name = "labelDashStyle";
            this.labelDashStyle.Size = new System.Drawing.Size(58, 13);
            this.labelDashStyle.TabIndex = 9;
            this.labelDashStyle.Text = "DashStyle:";
            // 
            // btnDashDotted
            // 
            this.btnDashDotted.BackColor = System.Drawing.Color.DimGray;
            this.btnDashDotted.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDashDotted.BackgroundImage")));
            this.btnDashDotted.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDashDotted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashDotted.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashDotted.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnDashDotted.Location = new System.Drawing.Point(172, 22);
            this.btnDashDotted.Name = "btnDashDotted";
            this.btnDashDotted.Size = new System.Drawing.Size(75, 23);
            this.btnDashDotted.TabIndex = 8;
            this.btnDashDotted.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDashDotted.UseVisualStyleBackColor = false;
            this.btnDashDotted.Click += new System.EventHandler(this.btnDash_Click);
            // 
            // btnDashDashed
            // 
            this.btnDashDashed.BackColor = System.Drawing.Color.DimGray;
            this.btnDashDashed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDashDashed.BackgroundImage")));
            this.btnDashDashed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashDashed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashDashed.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnDashDashed.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDashDashed.Location = new System.Drawing.Point(91, 22);
            this.btnDashDashed.Name = "btnDashDashed";
            this.btnDashDashed.Size = new System.Drawing.Size(75, 23);
            this.btnDashDashed.TabIndex = 7;
            this.btnDashDashed.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDashDashed.UseVisualStyleBackColor = false;
            this.btnDashDashed.Click += new System.EventHandler(this.btnDash_Click);
            // 
            // btnDashSolid
            // 
            this.btnDashSolid.BackColor = System.Drawing.Color.DimGray;
            this.btnDashSolid.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDashSolid.BackgroundImage")));
            this.btnDashSolid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDashSolid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashSolid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashSolid.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnDashSolid.Location = new System.Drawing.Point(10, 22);
            this.btnDashSolid.Name = "btnDashSolid";
            this.btnDashSolid.Size = new System.Drawing.Size(75, 23);
            this.btnDashSolid.TabIndex = 6;
            this.btnDashSolid.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDashSolid.UseVisualStyleBackColor = false;
            this.btnDashSolid.Click += new System.EventHandler(this.btnDash_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.BackColor = System.Drawing.Color.DimGray;
            this.btnRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedo.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.Location = new System.Drawing.Point(923, 16);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(58, 23);
            this.btnRedo.TabIndex = 17;
            this.btnRedo.UseVisualStyleBackColor = false;
            this.btnRedo.Click += new System.EventHandler(this.UndoRedo_Click);
            this.btnRedo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUndo_MouseDown);
            this.btnRedo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUndo_MouseUp);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.DimGray;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.Location = new System.Drawing.Point(859, 16);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(58, 23);
            this.btnUndo.TabIndex = 16;
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.UndoRedo_Click);
            this.btnUndo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUndo_MouseDown);
            this.btnUndo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnUndo_MouseUp);
            // 
            // cbFrameOuter
            // 
            this.cbFrameOuter.AutoSize = true;
            this.cbFrameOuter.BackColor = System.Drawing.Color.Black;
            this.cbFrameOuter.ForeColor = System.Drawing.Color.White;
            this.cbFrameOuter.Location = new System.Drawing.Point(603, 11);
            this.cbFrameOuter.Name = "cbFrameOuter";
            this.cbFrameOuter.Size = new System.Drawing.Size(52, 17);
            this.cbFrameOuter.TabIndex = 15;
            this.cbFrameOuter.Text = "Outer";
            this.toolTip1.SetToolTip(this.cbFrameOuter, "Rahmen Aussen");
            this.cbFrameOuter.UseVisualStyleBackColor = false;
            this.cbFrameOuter.CheckStateChanged += new System.EventHandler(this.cb_frame_O_CheckStateChanged);
            // 
            // cbFrameInner
            // 
            this.cbFrameInner.AutoSize = true;
            this.cbFrameInner.BackColor = System.Drawing.Color.Black;
            this.cbFrameInner.ForeColor = System.Drawing.Color.White;
            this.cbFrameInner.Location = new System.Drawing.Point(603, 32);
            this.cbFrameInner.Name = "cbFrameInner";
            this.cbFrameInner.Size = new System.Drawing.Size(50, 17);
            this.cbFrameInner.TabIndex = 14;
            this.cbFrameInner.Text = "Inner";
            this.toolTip1.SetToolTip(this.cbFrameInner, "Rahmen Innen");
            this.cbFrameInner.UseVisualStyleBackColor = false;
            this.cbFrameInner.CheckStateChanged += new System.EventHandler(this.cb_frame_I_CheckStateChanged);
            // 
            // btnColFrame
            // 
            this.btnColFrame.BackColor = System.Drawing.Color.Red;
            this.btnColFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColFrame.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColFrame.ForeColor = System.Drawing.Color.White;
            this.btnColFrame.Location = new System.Drawing.Point(656, 25);
            this.btnColFrame.Margin = new System.Windows.Forms.Padding(0);
            this.btnColFrame.Name = "btnColFrame";
            this.btnColFrame.Size = new System.Drawing.Size(75, 23);
            this.btnColFrame.TabIndex = 13;
            this.btnColFrame.Text = "Rahmen";
            this.btnColFrame.UseVisualStyleBackColor = false;
            this.btnColFrame.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // cbFill
            // 
            this.cbFill.AutoSize = true;
            this.cbFill.Location = new System.Drawing.Point(749, 21);
            this.cbFill.Name = "cbFill";
            this.cbFill.Size = new System.Drawing.Size(15, 14);
            this.cbFill.TabIndex = 12;
            this.cbFill.UseVisualStyleBackColor = true;
            this.cbFill.CheckStateChanged += new System.EventHandler(this.cb_fill_CheckStateChanged);
            // 
            // btnColFill
            // 
            this.btnColFill.BackColor = System.Drawing.Color.White;
            this.btnColFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColFill.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColFill.ForeColor = System.Drawing.Color.Black;
            this.btnColFill.Location = new System.Drawing.Point(766, 16);
            this.btnColFill.Name = "btnColFill";
            this.btnColFill.Size = new System.Drawing.Size(75, 23);
            this.btnColFill.TabIndex = 11;
            this.btnColFill.Text = "Füllung";
            this.btnColFill.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnColFill.UseVisualStyleBackColor = false;
            this.btnColFill.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnColorForm
            // 
            this.btnColorForm.AccessibleDescription = "";
            this.btnColorForm.BackColor = System.Drawing.Color.Black;
            this.btnColorForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColorForm.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColorForm.ForeColor = System.Drawing.Color.White;
            this.btnColorForm.Location = new System.Drawing.Point(511, 19);
            this.btnColorForm.Margin = new System.Windows.Forms.Padding(0);
            this.btnColorForm.Name = "btnColorForm";
            this.btnColorForm.Size = new System.Drawing.Size(75, 23);
            this.btnColorForm.TabIndex = 7;
            this.btnColorForm.Text = "Form";
            this.btnColorForm.UseVisualStyleBackColor = false;
            this.btnColorForm.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.BackColor = System.Drawing.Color.Black;
            this.labelColor.ForeColor = System.Drawing.Color.White;
            this.labelColor.Location = new System.Drawing.Point(508, 3);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(43, 13);
            this.labelColor.TabIndex = 6;
            this.labelColor.Text = "Farben:";
            // 
            // labelStrenght
            // 
            this.labelStrenght.AutoSize = true;
            this.labelStrenght.BackColor = System.Drawing.Color.Black;
            this.labelStrenght.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStrenght.ForeColor = System.Drawing.Color.White;
            this.labelStrenght.Location = new System.Drawing.Point(191, 17);
            this.labelStrenght.Name = "labelStrenght";
            this.labelStrenght.Size = new System.Drawing.Size(18, 20);
            this.labelStrenght.TabIndex = 1;
            this.labelStrenght.Text = "1";
            this.toolTip1.SetToolTip(this.labelStrenght, "Strichdicke");
            // 
            // trackBarFormThickness
            // 
            this.trackBarFormThickness.BackColor = System.Drawing.Color.DimGray;
            this.trackBarFormThickness.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackBarFormThickness.Location = new System.Drawing.Point(9, 3);
            this.trackBarFormThickness.Maximum = 50;
            this.trackBarFormThickness.Minimum = 1;
            this.trackBarFormThickness.Name = "trackBarFormThickness";
            this.trackBarFormThickness.Size = new System.Drawing.Size(176, 45);
            this.trackBarFormThickness.TabIndex = 0;
            this.trackBarFormThickness.TickFrequency = 5;
            this.toolTip1.SetToolTip(this.trackBarFormThickness, "Strichdicke 1 - 50");
            this.trackBarFormThickness.Value = 1;
            this.trackBarFormThickness.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Desktop;
            this.splitContainer1.Location = new System.Drawing.Point(0, 54);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.splitContainer1.Panel1.Controls.Add(this.btnEllipse);
            this.splitContainer1.Panel1.Controls.Add(this.btnCircle);
            this.splitContainer1.Panel1.Controls.Add(this.btnLine);
            this.splitContainer1.Panel1.Controls.Add(this.btnSquare);
            this.splitContainer1.Panel1.Controls.Add(this.btnRectangle);
            this.splitContainer1.Panel1.Controls.Add(this.btnFreehand);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.WindowText;
            this.splitContainer1.Panel2.Controls.Add(this.labelisSave);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel2_MouseDown);
            this.splitContainer1.Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel2_MouseMove);
            this.splitContainer1.Panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel2_MouseUp);
            this.splitContainer1.Size = new System.Drawing.Size(1073, 516);
            this.splitContainer1.SplitterDistance = 89;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnEllipse
            // 
            this.btnEllipse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEllipse.BackColor = System.Drawing.Color.DimGray;
            this.btnEllipse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEllipse.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnEllipse.Image = ((System.Drawing.Image)(resources.GetObject("btnEllipse.Image")));
            this.btnEllipse.Location = new System.Drawing.Point(10, 267);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(75, 60);
            this.btnEllipse.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btnEllipse, "Ellipse");
            this.btnEllipse.UseVisualStyleBackColor = false;
            this.btnEllipse.Click += new System.EventHandler(this.btnShape_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCircle.BackColor = System.Drawing.Color.DimGray;
            this.btnCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCircle.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnCircle.Image = ((System.Drawing.Image)(resources.GetObject("btnCircle.Image")));
            this.btnCircle.Location = new System.Drawing.Point(9, 333);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(75, 60);
            this.btnCircle.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnCircle, "Kreis");
            this.btnCircle.UseVisualStyleBackColor = false;
            this.btnCircle.Click += new System.EventHandler(this.btnShape_Click);
            // 
            // btnLine
            // 
            this.btnLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLine.BackColor = System.Drawing.Color.DimGray;
            this.btnLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLine.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.Location = new System.Drawing.Point(10, 69);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(75, 60);
            this.btnLine.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnLine, "Linie");
            this.btnLine.UseVisualStyleBackColor = false;
            this.btnLine.Click += new System.EventHandler(this.btnShape_Click);
            // 
            // btnSquare
            // 
            this.btnSquare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSquare.BackColor = System.Drawing.Color.DimGray;
            this.btnSquare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSquare.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnSquare.Image = ((System.Drawing.Image)(resources.GetObject("btnSquare.Image")));
            this.btnSquare.Location = new System.Drawing.Point(10, 201);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(75, 60);
            this.btnSquare.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnSquare, "Quadrat");
            this.btnSquare.UseVisualStyleBackColor = false;
            this.btnSquare.Click += new System.EventHandler(this.btnShape_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRectangle.BackColor = System.Drawing.Color.DimGray;
            this.btnRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRectangle.ForeColor = System.Drawing.Color.SlateBlue;
            this.btnRectangle.Image = ((System.Drawing.Image)(resources.GetObject("btnRectangle.Image")));
            this.btnRectangle.Location = new System.Drawing.Point(10, 135);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(75, 60);
            this.btnRectangle.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnRectangle, "Rechteck");
            this.btnRectangle.UseVisualStyleBackColor = false;
            this.btnRectangle.Click += new System.EventHandler(this.btnShape_Click);
            // 
            // btnFreehand
            // 
            this.btnFreehand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFreehand.BackColor = System.Drawing.Color.DimGray;
            this.btnFreehand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFreehand.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnFreehand.Image = ((System.Drawing.Image)(resources.GetObject("btnFreehand.Image")));
            this.btnFreehand.Location = new System.Drawing.Point(10, 3);
            this.btnFreehand.Name = "btnFreehand";
            this.btnFreehand.Size = new System.Drawing.Size(75, 60);
            this.btnFreehand.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnFreehand, "Freihand");
            this.btnFreehand.UseVisualStyleBackColor = false;
            this.btnFreehand.Click += new System.EventHandler(this.btnShape_Click);
            // 
            // labelisSave
            // 
            this.labelisSave.AutoSize = true;
            this.labelisSave.BackColor = System.Drawing.Color.White;
            this.labelisSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelisSave.ForeColor = System.Drawing.Color.Black;
            this.labelisSave.Location = new System.Drawing.Point(4, 3);
            this.labelisSave.Name = "labelisSave";
            this.labelisSave.Size = new System.Drawing.Size(109, 15);
            this.labelisSave.TabIndex = 0;
            this.labelisSave.Text = "Keine Änderungen";
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Black;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMenue});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1073, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiMenue
            // 
            this.tsmiMenue.BackColor = System.Drawing.Color.Black;
            this.tsmiMenue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsmiMenue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsmiMenue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.tsmiOpen,
            this.tsmiSave,
            this.tsmiSaveUnder,
            this.tsmiExportAs,
            this.tsmiStartmenue});
            this.tsmiMenue.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiMenue.ForeColor = System.Drawing.Color.Aqua;
            this.tsmiMenue.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.tsmiMenue.Name = "tsmiMenue";
            this.tsmiMenue.Size = new System.Drawing.Size(58, 24);
            this.tsmiMenue.Text = "Menü";
            // 
            // tsmiNew
            // 
            this.tsmiNew.BackColor = System.Drawing.SystemColors.Control;
            this.tsmiNew.ForeColor = System.Drawing.Color.Black;
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(196, 24);
            this.tsmiNew.Text = "Neu";
            this.tsmiNew.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.BackColor = System.Drawing.SystemColors.Control;
            this.tsmiOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsmiOpen.ForeColor = System.Drawing.Color.Black;
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(196, 24);
            this.tsmiOpen.Text = "Öffnen";
            this.tsmiOpen.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
            // 
            // tsmiSave
            // 
            this.tsmiSave.BackColor = System.Drawing.SystemColors.Control;
            this.tsmiSave.ForeColor = System.Drawing.Color.Black;
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.Size = new System.Drawing.Size(196, 24);
            this.tsmiSave.Text = "Speichern";
            this.tsmiSave.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // tsmiSaveUnder
            // 
            this.tsmiSaveUnder.BackColor = System.Drawing.SystemColors.Control;
            this.tsmiSaveUnder.ForeColor = System.Drawing.Color.Black;
            this.tsmiSaveUnder.Name = "tsmiSaveUnder";
            this.tsmiSaveUnder.Size = new System.Drawing.Size(196, 24);
            this.tsmiSaveUnder.Text = "Speichern Unter";
            this.tsmiSaveUnder.Click += new System.EventHandler(this.mnuSaveUnder_Click);
            // 
            // tsmiExportAs
            // 
            this.tsmiExportAs.BackColor = System.Drawing.SystemColors.Control;
            this.tsmiExportAs.ForeColor = System.Drawing.Color.Black;
            this.tsmiExportAs.Name = "tsmiExportAs";
            this.tsmiExportAs.Size = new System.Drawing.Size(196, 24);
            this.tsmiExportAs.Text = "Exportieren als.. >";
            this.tsmiExportAs.Click += new System.EventHandler(this.tsmiExportAs_Click);
            // 
            // tsmiStartmenue
            // 
            this.tsmiStartmenue.BackColor = System.Drawing.SystemColors.Control;
            this.tsmiStartmenue.ForeColor = System.Drawing.Color.Black;
            this.tsmiStartmenue.Name = "tsmiStartmenue";
            this.tsmiStartmenue.Size = new System.Drawing.Size(196, 24);
            this.tsmiStartmenue.Text = "Startmenü";
            this.tsmiStartmenue.Click += new System.EventHandler(this.tsmiStartmenue_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 250;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 594);
            this.Controls.Add(this.toolStripContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paint v.1.0 - Zeichnungsprogramm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFormThickness)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiMenue;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveUnder;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBarFormThickness;
        private System.Windows.Forms.Label labelStrenght;
        private System.Windows.Forms.Button btnColorForm;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button btnColFill;
        private System.Windows.Forms.CheckBox cbFill;
        private System.Windows.Forms.CheckBox cbFrameInner;
        private System.Windows.Forms.Button btnColFrame;
        private System.Windows.Forms.CheckBox cbFrameOuter;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportAs;
        private System.Windows.Forms.Label labelisSave;
        private System.Windows.Forms.Button btnFreehand;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.Button btnSquare;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.ToolStripMenuItem tsmiStartmenue;
        private Panel panel2;
        private Label labelDashStyle;
        private Button btnDashDotted;
        private Button btnDashDashed;
        private Button btnDashSolid;
        private MaskedTextBox mtbFrameThickness;
        private ToolTip toolTip1;
    }
}

