using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using ProjektPaint.Model;
using ProjektPaint.Model.Enums;

namespace ProjektPaint
{
    public partial class FormMain : Form
    {
        //Bild wird in diese Bitmap gezeichnet
        private Bitmap bmp;

        //Strichdicke
        private int thickness = 1;

        //Farbe Form
        private Color colorForm = Color.Black;

        //Farbe Rahmen Aussen und Innen
        private Color colorFrameOut = Color.FromArgb(0, 0, 0, 0);
        private Color colorFrameIn = Color.FromArgb(0, 0, 0, 0);

        //Farbe Füllung
        private Color colorFill = Color.FromArgb(0, 0, 0, 0);

        //Startpunkt der aktuellen Form
        private Point sPoint = new Point();
        
        //Muster
        private DashType pattern = DashType.Solid;

        //Graphics um Zeichnung zu zeichnen
        private Graphics graphBMP;

        //Alle Formen werden darin gespeichert
        private List<Shape> listForms = new List<Shape>();

        //Alle Punkte eines Freehand-Objekts werden darin gespeichert
        private List<Point> freehandPoints = new List<Point>();

        //Pfad der abgespeicherten Datei
        private string path = null;

        //Gibt an, ob aktuell geöffnete Datei gespeichert ist
        private bool isSaved = true;

        //Strichdicke des Rahmens
        private int frameThickness = 1;

        //Gibt an, welche Form gezeichnet werden sollte
        private DrawShape selectedShape = DrawShape.Freehand; //Standard: Freehand

        private ImageDrawing imgDraw;

        private FileOp fop;

        //Hintergrundbild
        Image img;

        public FormMain(string newPath, List<Shape> newForm, Image newImage)
        {
            InitializeComponent();

            if (newPath != null)
            {
                listForms = newForm;
                path = newPath;
            }

            if (newImage != null)
            {
                img = newImage;
            }

            fop = new FileOp();
        }
        
        /// <summary>
        /// Wird aufgerufen wenn das Zeichnenfeld dargestellt wird. Dabei wird die Bitmap initialisiert.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            if (bmp == null)
            {
                //Bitmap mit Grösse initialisieren
                bmp = new Bitmap(this.splitContainer1.Panel2.Width - 50, this.splitContainer1.Panel2.Height - 50);

                //Bitmap an graphBMP zuweisen
                graphBMP = Graphics.FromImage(bmp);

                //Bild in Bitmap zeichnen
                imgDraw = new ImageDrawing(graphBMP, splitContainer1, bmp);
                imgDraw.DrawImage(listForms, img);
            }

            //Bitmap in Panel2 zeichnen
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        /// <summary>
        /// Wird aufgerufen wenn eine Maustaste gedrückt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_Panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                /*Linke Maustaste wird gedrückt*/
                
                if (selectedShape == DrawShape.Freehand)
                {
                    //Freihandzeichnung
                    freehandPoints.Add(e.Location);
                }
                else
                {
                    sPoint = e.Location;
                }
            }
        }

        /// <summary>
        /// Wird aufgerufen wenn die Maus verschoben wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_Panel2_MouseMove(object sender, MouseEventArgs e)
        {
            //Maus wird bewegt
            if (e.Button == MouseButtons.Left)
            {
                Point ePoint = new Point(e.X, e.Y);

                createNewShape(ePoint);

                imgDraw.DrawImage(listForms, img);
                listForms.RemoveAt(listForms.Count - 1);
            }
        }

        /// <summary>
        /// Wird aufgerufen wenn eine Maustaste losgelassen wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_Panel2_MouseUp(object sender, MouseEventArgs e)
        {
            //Maustaste wird losgelassen
            Point ePoint = new Point(e.X, e.Y);

            createNewShape(ePoint);

            imgDraw.DrawImage(listForms, img);
            isSaved = false;
            labelisSave.Text = "Ungespeichert";

            //FreeHand-Liste löschen
            freehandPoints.Clear();
        }

        /// <summary>
        /// Erstellt ein neues Shape vom richtigen Typ und fügt es zur Liste hinzu
        /// </summary>
        /// <param name="ePoint">Endpunkt vom Shape</param>
        private void createNewShape(Point ePoint)
        {
            Shape shapeElement = null;
            Point newSPoint = new Point();
            int[] iArr = new int[4];

            if (selectedShape == DrawShape.Rectangle || selectedShape == DrawShape.Square || selectedShape == DrawShape.Ellipse || selectedShape == DrawShape.Circle)
            {
                //Startpunkte, Länge und Breite berechnen
                if (selectedShape == DrawShape.Rectangle || selectedShape == DrawShape.Ellipse)
                {
                    iArr = imgDraw.convertPointsToLengthAndWidth(sPoint, ePoint, false);
                }
                else if (selectedShape == DrawShape.Square || selectedShape == DrawShape.Circle)
                {
                    iArr = imgDraw.convertPointsToLengthAndWidth(sPoint, ePoint, true);
                }
                newSPoint.X = iArr[2];
                newSPoint.Y = iArr[3];
            }

            if (selectedShape == DrawShape.Rectangle)
            {
                //Form ist ein Rechteck
                shapeElement = new ProjektPaint.Model.Rectangle(thickness, colorForm, newSPoint, pattern, iArr[0], iArr[1], colorFill, colorFrameOut, colorFrameIn, frameThickness);
            }
            else if (selectedShape == DrawShape.Line)
            {
                //Form ist eine Linie
                shapeElement = new ProjektPaint.Model.Line(thickness, colorForm, sPoint, ePoint, pattern);
            }
            else if (selectedShape == DrawShape.Circle)
            {
                //Form ist ein Kreis
                shapeElement = new ProjektPaint.Model.Circle(thickness, colorForm, newSPoint, pattern, iArr[0], colorFill, colorFrameOut, colorFrameIn, frameThickness);
            }
            else if (selectedShape == DrawShape.Square)
            {
                //Form ist ein Quadrat
                shapeElement = new ProjektPaint.Model.Square(thickness, colorForm, newSPoint, pattern, iArr[0], colorFill, colorFrameOut, colorFrameIn, frameThickness);
            }
            else if (selectedShape == DrawShape.Freehand)
            {
                //Form ist eine Freihandzeichnung
                freehandPoints.Add(ePoint);

                List<Point> ownPoints = new List<Point>();

                for (int i = 0; i < freehandPoints.Count; i++)
                {
                    ownPoints.Add(freehandPoints.ElementAt(i));
                }

                shapeElement = new ProjektPaint.Model.Freehand(thickness, colorForm, pattern, ownPoints);
            }
            else if (selectedShape == DrawShape.Ellipse)
            {
                //Form ist eine Ellipse
                shapeElement = new ProjektPaint.Model.Ellipse(thickness, colorForm, newSPoint, pattern, iArr[0], iArr[1], colorFill, colorFrameOut, colorFrameIn, frameThickness);
            }

            listForms.Add(shapeElement);
        }

        /// <summary>
        /// Event der aufgerufen wird, wenn einer der Shape-Buttons geklickt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShape_Click(object sender, EventArgs e)
        {
            //Die zu zeichnende Form wird hier festgelegt
            if (sender == btnFreehand)
            {
                selectedShape = DrawShape.Freehand;
            }
            else if (sender == btnLine)
            {
                selectedShape = DrawShape.Line;
            }
            else if (sender == btnRectangle)
            {
                selectedShape = DrawShape.Rectangle;
            }
            else if (sender == btnSquare)
            {
                selectedShape = DrawShape.Square;
            }
            else if (sender == btnEllipse)
            {
                selectedShape = DrawShape.Ellipse;
            }
            else if (sender == btnCircle)
            {
                selectedShape = DrawShape.Circle;
            }
            
            setButtonColor((Button)sender, splitContainer1.Panel1);
        }

        /// <summary>
        /// Ändert Farben des Aktiven und der Nicht-Aktiven Buttons
        /// </summary>
        /// <param name="activeButton">Der Aktive Button</param>
        /// <param name="panel">Das Panel beinhaltet alle anzupassenden Buttons</param>
        private void setButtonColor(Button activeButton, Panel panel)
        {
            //Farbe der Buttons ändern, damit man sieht, welcher aktiv ist 
            foreach (Control control in panel.Controls.OfType<Button>())
            {
                if (control != activeButton)
                {
                    control.ForeColor = Color.SlateBlue;
                }
                else
                {
                    control.ForeColor = Color.OrangeRed;
                }
            }
            
        }

        /// <summary>
        /// Wird aufgerufen wenn der Menüpunkt Speichern Unter angeklickt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuSaveUnder_Click(object sender, EventArgs e)
        {
            SaveFileUnder(); //Speichern Unter
        }

        /// <summary>
        /// Wird aufgerufen wenn der Menüpunkt Speichern angeklickt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(); //Speichern
        }

        /// <summary>
        /// Wird aufgerufen wenn der Menüpunkt Öffnen angeklickt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile(); //Öffnen
            imgDraw.DrawImage(listForms, img);
        }

        /// <summary>
        /// Wird aufgerufen wenn der Menüpunkt Neu angeklickt wird
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFile(); //Neu
            imgDraw.DrawImage(listForms, bmp);
        }

        /// <summary>
        /// Wird aufgerufen wenn die Trackbar verstellt wird. Legt den Wert für die Strichdicke fest.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //Stärke festlegen
            thickness = trackBarFormThickness.Value;
            labelStrenght.Text = trackBarFormThickness.Value.ToString();
        }

        /// <summary>
        /// Verändert das Muster
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDash_Click(object sender, EventArgs e)
        {
            //Muster wird festgelegt (fest, gestrichelt, gepunktet)
            if (sender == btnDashSolid)
            {
                pattern = DashType.Solid;
            }
            else if (sender == btnDashDashed)
            {
                pattern = DashType.Dashed;
            }
            else if (sender == btnDashDotted)
            {
                pattern = DashType.Dotted;
            }

            setButtonColor((Button)sender, panel2);
        }

        /// <summary>
        /// Verändert die ForeColor je nach Helligkeit der BackColor
        /// </summary>
        /// <param name="button">Button dessen Farbe gesetzt werden sollte</param>
        private void setButtonColorFromBrightness(Button button)
        {
            float brightness = button.BackColor.GetBrightness();

            if (brightness < 0.5)
            {
                button.ForeColor = Color.White;
            }
            else if (brightness >= 0.5)
            {
                button.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// Verändert die Farben
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColor_Click(object sender, EventArgs e)
        {
            //Farben werden festgelegt
            colorDialog.ShowDialog();

            //Farbe der Form
            if (sender == btnColorForm)
            {
                btnColorForm.BackColor = colorDialog.Color;
                colorForm = btnColorForm.BackColor;

                setButtonColorFromBrightness(btnColorForm);
            }
            //Farbe des Rahmens
            else if (sender == btnColFrame)
            {
                btnColFrame.BackColor = colorDialog.Color;

                if (cbFrameOuter.CheckState == CheckState.Checked)
                {
                    colorFrameOut = btnColFrame.BackColor;
                }

                if (cbFrameInner.CheckState == CheckState.Checked)
                {
                    colorFrameIn = btnColFrame.BackColor;
                }

                setButtonColorFromBrightness(btnColFrame);
            }
            //Farbe der Füllung
            else if (sender == btnColFill)
            {
                btnColFill.BackColor = colorDialog.Color;

                if (cbFill.CheckState == CheckState.Checked)
                {
                    colorFill = btnColFill.BackColor;
                }

                setButtonColorFromBrightness(btnColFill);
            }
        }

        /// <summary>
        /// Legt fest ob eine Füllung gezeichnet werden sollte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_fill_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbFill.CheckState == CheckState.Checked)
            {
                colorFill = btnColFill.BackColor;
            }
            else if (cbFill.CheckState == CheckState.Unchecked)
            {
                colorFill = Color.FromArgb(0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Legt fest ob ein Aussen-Rahmen gezeichnet werden sollte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_frame_O_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbFrameOuter.CheckState == CheckState.Checked)
            {
                colorFrameOut = btnColFrame.BackColor;
            }
            else if (cbFrameOuter.CheckState == CheckState.Unchecked)
            {
                colorFrameOut = Color.FromArgb(0, 0, 0, 0);
            }
        }

        /// <summary>
        /// Legt fest ob ein Innen-Rahmen gezeichnet werden sollte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_frame_I_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbFrameInner.CheckState == CheckState.Checked)
            {
                colorFrameIn = btnColFrame.BackColor;
            }
            else if (cbFrameInner.CheckState == CheckState.Unchecked)
            {
                colorFrameIn = Color.FromArgb(0, 0, 0, 0);
            }
        }

        private List<Shape> rForms = new List<Shape>();

        /// <summary>
        /// Löscht das letzte Shape oder stellt es wieder her
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndoRedo_Click(object sender, EventArgs e)
        {
            if (sender == btnUndo)
            {
                if (listForms.Count > 0)
                {
                    //Letzen Schritt rückgängig machen
                    imgDraw.Undo(ref listForms, ref rForms);

                    isSaved = false;
                    labelisSave.Text = "Ungespeichert";
                }
            }
            else if (sender == btnRedo)
            {
                if (rForms.Count > 0)
                {
                    //Zuletzt rückgängig gemachter Schritt wiederherstellen
                    imgDraw.Redo(ref listForms, ref rForms);

                    isSaved = false;
                    labelisSave.Text = "Ungespeichert";
                }
            }

            imgDraw.DrawImage(listForms, img);   
        }

        /// <summary>
        /// Wird aufgerufen wenn die Form geschlossen wird
        /// Fordert den Benutzer zum Speichern auf, falls das Bild ungespeichert ist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Applikation wird beendet, wenn diese Form geschlossen wird
            if (!isSaved)
            {
                DialogResult result = MessageBox.Show("Möchten Sie das Bild speichern?", "Datei nicht gespeichert!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    SaveFile();

                    if (path == null)
                    {
                        e.Cancel = true;
                        showOpener = false;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    showOpener = false;
                }
            }
        }

        /// <summary>
        /// Wird aufgerufen wenn die Form geschlossen wurde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (showOpener)
            {
                FormStart fstart = new FormStart();
                fstart.Show();
                this.Dispose();
            }
            else
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Registriert Tastendrücke für Shortcuts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Taste/n die gedrückt werden</param>
        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                //Shortcut Speichern Unter
                SaveFileUnder();
            }
            else if (e.KeyData == (Keys.Control | Keys.S))
            {
                //Shortcut Speichern
                SaveFile();
            }
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.O))
            {
                //Shortcut Öffnen
                OpenFile();
            }
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.N))
            {
                //Shortcut Neues Bild
                NewFile();
            }
            else if (e.KeyData == (Keys.Control | Keys.Z))
            {
                //Shortcut Undo
                if (listForms.Count > 0)
                {
                    imgDraw.Undo(ref listForms, ref rForms);

                    isSaved = false;
                    labelisSave.Text = "Ungespeichert";
                }
            }
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.Z) || e.KeyData == (Keys.Control | Keys.Y))
            {
                //Shortcut Redo
                if (rForms.Count > 0)
                {
                    imgDraw.Redo(ref listForms, ref rForms);
                    
                    isSaved = false;
                    labelisSave.Text = "Ungespeichert";
                }
            }
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.E))
            {
                //Shortcut Exportieren Als..
                fop.ExportAs(bmp);
            }

            //Bild neu zeichnen
            imgDraw.DrawImage(listForms, img);
        }

        /// <summary>
        /// Wird aufgerufen wenn im Menü Exportieren Als.. angeklickt wurde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiExportAs_Click(object sender, EventArgs e)
        {
            fop.ExportAs(bmp);
        }

        private bool showOpener = false;

        /// <summary>
        /// Wird aufgerufen wenn im Menü Startmenü angeklickt wurde
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiStartmenue_Click(object sender, EventArgs e)
        {
            showOpener = true;
            this.Close();
        }

        /// <summary>
        /// Wird aufgerufen wenn der Button Undo/Redo gedrückt wird
        /// Verändert die Farbe des aktiven Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUndo_MouseDown(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.OrangeRed;
        }

        /// <summary>
        /// Wird aufgerufen wenn der Button Undo/Redo gedrückt wurde
        /// Verändert die Farbe des nicht-aktiven Buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUndo_MouseUp(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            button.ForeColor = Color.SlateBlue;
        }

        /// <summary>
        /// Speichert das Bild an einem existierenden Pfad
        /// </summary>
        private void SaveFile()
        {
            if (img == null)
            {
                isSaved = fop.SaveFile(listForms, path); 
            }
            else
            {
                isSaved = fop.SaveImg(bmp, path);
            }

            if (isSaved)
            {
                labelisSave.Text = "Gespeichert";
            }
            else
            {
                SaveFileUnder();
            }
        }

        private void SaveFileUnder()
        {
            SaveFileDialog sfd = new SaveFileDialog();

            if (img == null)
            {
                sfd.Filter = "Projekt Paint (*.prjp)|*.prjp";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    isSaved = fop.SaveFile(listForms, sfd.FileName);
                }

                sfd.Dispose();
            }
            else
            {
                sfd.Filter = "Alle Bilddateien|*.png;*.jpg;*.bmp";

                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    isSaved = fop.SaveImg(bmp, sfd.FileName);
                }
            }

            if (isSaved)
            {
                path = sfd.FileName;

                labelisSave.Text = "Gespeichert";
            }
        }

        /// <summary>
        /// Öffnet eine Datei
        /// </summary>
        private void OpenFile()
        {
            DialogResult result = new DialogResult();

            if (!isSaved)
            {
                result = MessageBox.Show("Möchten Sie die Datei speichern?", "Datei Ungespeichert", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    //Speichern aufrufen
                    SaveFile();
                }
            }

            if (isSaved)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Alle Dateien|*.prjp;*.jpg;*.png;*.bmp";
                ofd.Filter += "| Projekt Paint (*.prjp)|*.prjp";
                ofd.Filter += "| JPEG (*.jpg)|*.jpg";
                ofd.Filter += "| PNG (*.png)|*.png";
                ofd.Filter += "| Bitmap (*.bmp)|*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(ofd.FileName) == ".prjp")
                    {
                        isSaved = fop.OpenFile(ref listForms, ofd.FileName);
                    }
                    else
                    {
                        isSaved = fop.OpenFile(ref img, ofd.FileName);
                        listForms.Clear();
                    }

                    if (isSaved)
                    {
                        path = ofd.FileName;
                        labelisSave.Text = "Keine Änderungen";
                    }
                }
            }
        }

        /// <summary>
        /// Erstellt ein neues Bild
        /// </summary>
        private void NewFile()
        {
            DialogResult result = new DialogResult();

            if (!isSaved)
            {
                result = MessageBox.Show("Möchten Sie die Datei speichern?", "Datei Ungespeichert", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    //Speichern aufrufen
                    SaveFile();

                    if (!isSaved)
                    {
                        result = DialogResult.Cancel;
                    }
                }
            }

            if (result != DialogResult.Cancel)
            {
                listForms.Clear();
                img = null;
                path = null;

                isSaved = true;
                labelisSave.Text = "Keine Änderungen";
            }
        }

        /// <summary>
        /// Wird aufgerufen wenn sich der Text in der MaskTextBox geändert hat
        /// Überprüft auf nicht zugelassene Zeichen und legt den Wert für die Strichdicke des Rahmens fest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtbFrameThickness_TextChanged(object sender, EventArgs e)
        {
            char[] charsToTrim = { '_' };
            mtbFrameThickness.Text.Trim(charsToTrim);

            if (mtbFrameThickness.Text != "")
            {
                if (Convert.ToInt16(mtbFrameThickness.Text) < 21)
                {
                    frameThickness = Convert.ToInt16(mtbFrameThickness.Text);
                }
                else
                {
                    mtbFrameThickness.Text = frameThickness.ToString();
                }
            }
        }

        /// <summary>
        /// Wird aufgerufen wenn in die MaskTextBox geklickt wird
        /// Selektiert den gesamten Text in der Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mtbFrameThickness_Click(object sender, EventArgs e)
        {
            mtbFrameThickness.SelectAll();
        }
    }
}
