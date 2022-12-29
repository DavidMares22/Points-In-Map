using EGIS.ShapeFileLib;
using EGIS.Projections;
using EGIS.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace Example1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


            try
            {
                // This will get the current WORKING directory (i.e. \bin\Debug)
                string workingDirectory = Environment.CurrentDirectory;
                // or: Directory.GetCurrentDirectory() gives the same result

                // This will get the current PROJECT bin directory (ie ../bin/)
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;


                OpenShapefile(Path.Combine(projectDirectory, "wojewodztwa.shp"));
                this.toolStripStatusLabel1.Text = "wojewodztwa";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error : " + ex.Message);
            }


          


        }

        //private void miOpen_Click(object sender, EventArgs e)
        //{
           

                //try
                //{
                //    OpenShapefile(ofdShapefile.FileName);
                //    this.toolStripStatusLabel1.Text = ofdShapefile.FileName;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(this, "Error : " + ex.Message);
                //}
 
        //}

        private void OpenShapefile(string path)
        {
            // clear any shapefiles the map is currently displaying
            this.sfMap1.ClearShapeFiles();
            this.selectedRecordIndex = -1;

            // open the shapefile passing in the path, display name of the shapefile and
            // the field name to be used when rendering the shapes (we use an empty string
            // as the field name (3rd parameter) can not be null)
            this.sfMap1.AddShapeFile(path, "ShapeFile", "");

            // read the shapefile dbf field names and set the shapefiles's RenderSettings
            // to use the first field to label the shapes.
            EGIS.ShapeFileLib.ShapeFile sf = this.sfMap1[0];

            sf.RenderSettings.FieldName = sf.RenderSettings.DbfReader.GetFieldNames()[0];
            sf.RenderSettings.UseToolTip = true;
            sf.RenderSettings.ToolTipFieldName = sf.RenderSettings.FieldName;
            sf.RenderSettings.SelectFillColor = Color.Red;
            sf.RenderSettings.SelectOutlineColor = Color.Black;

            //   sf.RenderSettings.PointImageSymbol = "diamond.png";
            sf.RenderSettings.IsSelectable = true;

            this.sfMap1.MapCoordinateReferenceSystem = sf.CoordinateReferenceSystem;

       

            

            //select the first record
            // sf.SelectRecord(0, true);

        }

        private int selectedRecordIndex = -1;
        
        private void sfMap1_MouseDown(object sender, MouseEventArgs e)
        {

            PointD myPoint = new PointD(200, 80);
            var pt1 = sfMap1.PixelCoordToGisPoint(Convert.ToInt16(myPoint.X), Convert.ToInt16(myPoint.Y));

           MessageBox.Show( sfMap1[0].GetShapeIndexContainingPoint(pt1, 1).ToString());


            if (sfMap1.ShapeFileCount == 0) return;
            int recordIndex = sfMap1.GetShapeIndexAtPixelCoord(0, e.Location, 8);
           
            if (recordIndex >= 0)
            {
                this.selectedRecordIndex = recordIndex;

                if (displayAttributesOnClickToolStripMenuItem.Checked)
                {
                    string[] recordAttributes = sfMap1[0].GetAttributeFieldValues(recordIndex);
                    string[] attributeNames = sfMap1[0].GetAttributeFieldNames();
                    StringBuilder sb = new StringBuilder();
                    for (int n = 0; n < attributeNames.Length; ++n)
                    {
                        sb.Append(attributeNames[n]).Append(':').AppendLine(recordAttributes[n].Trim());
                    }
                    MessageBox.Show(this, sb.ToString(), "record attributes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                if (selectRecordOnClickToolStripMenuItem.Checked)
                {
                    
                    sfMap1[0].ClearSelectedRecords();
                    sfMap1[0].SelectRecord(recordIndex, true);
                    sfMap1.Refresh(true);
                }

            }
           

        }

        private void sfMap1_Paint(object sender, PaintEventArgs e)
        {

            // Create a Graphics object and a Pen object
       
            using (Pen p = new Pen(Brushes.Black,2))
            {
           
                e.Graphics.DrawEllipse(p, 200, 80, 1, 1);

            }

            DrawCursorCrosshair(e.Graphics);

            //using (Pen pen = new Pen(SystemColors.ControlDark, 1))
            //{
            //    e.Graphics.DrawRectangle(pen, 0, 0, sfMap1.ClientSize.Width-1, sfMap1.ClientSize.Height-1);
            //}

            if (this.selectedRecordIndex >= 0 && drawBoundingBoxOfSelectedRecordToolStripMenuItem.Checked)
            {
                RectangleD bounds = sfMap1[0].GetShapeBoundsD(selectedRecordIndex);

                using (EGIS.Projections.ICoordinateTransformation transform = EGIS.Projections.CoordinateReferenceSystemFactory.Default.CreateCoordinateTrasformation(sfMap1[0].CoordinateReferenceSystem, sfMap1.MapCoordinateReferenceSystem))
                {
                    bounds = transform.Transform(bounds);
                }

                //Console.Out.WriteLine("bounds = " + bounds);
               // ReadOnlyCollection<PointD[]> geometry = sfMap1[0].GetShapeDataD(selectedRecordIndex);
               // OutputRecordGeometry(geometry);

                var pt1 = sfMap1.GisPointToPixelCoord(new PointD(bounds.Left, bounds.Bottom));
                var pt2 = sfMap1.GisPointToPixelCoord(new PointD(bounds.Right, bounds.Top));
               // Console.Out.WriteLine("pt1 = " + pt1);
               // Console.Out.WriteLine("pt2 = " + pt2);
                Rectangle r = Rectangle.FromLTRB(pt1.X, pt1.Y, pt2.X, pt2.Y);
                if (r.Left > -1000 && r.Left < this.Width && r.Width < 10000)
                {
                    using (Pen p = new Pen(Color.Red))
                    {
                        e.Graphics.DrawRectangle(p, r);
                    }
                }

            }

        }

        private void OutputRecordGeometry(IList<PointD[]> geometry)
        {
            StringBuilder sb = new StringBuilder();
            double minX = double.PositiveInfinity, minY = double.PositiveInfinity, maxX = double.NegativeInfinity, maxY = double.NegativeInfinity;
            for (int n = 0; n < geometry.Count; ++n)
            {
                PointD[] pts = geometry[n];
                sb.Append("part:");
                for (int i = 0; i < pts.Length; ++i)
                {
                    if (i > 0) sb.Append(',');
                    sb.Append(pts[i]);
                    if (pts[i].X < minX) minX = pts[i].X;
                    if (pts[i].X > maxX) maxX = pts[i].X;
                    if (pts[i].Y < minY) minY = pts[i].Y;
                    if (pts[i].Y > maxY) maxY = pts[i].Y;


                }
                sb.AppendLine();
            }
            Console.Out.WriteLine(sb.ToString());
            Console.Out.WriteLine("minX:" +  minX);
            Console.Out.WriteLine("minY:" +  minY);
            Console.Out.WriteLine("maxX:" +  maxX);
            Console.Out.WriteLine("maxY:" +  maxY);



        }

        private void DrawCursorCrosshair(Graphics g)
        {
            if (currentMousePoint.IsEmpty) return;

            //Take a copy of the current transform because we want to reset it before we draw.
            //This is because if the mouse is down and the user drags the mouse (pans the map) a transform
            //is set on the graphics. 
            var transform = g.Transform;
            try
            {
                g.ResetTransform();

                using (Pen p = new Pen(Color.Red, 1))
                {
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    //draw a cross centred on the current mouse position
                    g.DrawLine(p, currentMousePoint.X, 0, currentMousePoint.X, sfMap1.ClientSize.Height);
                    g.DrawLine(p, 0, currentMousePoint.Y, sfMap1.ClientSize.Width, currentMousePoint.Y);
                }
            }
            finally
            {
                g.Transform = transform;
            }
            
        }

        private Point currentMousePoint;

		private void sfMap1_MouseMove(object sender, MouseEventArgs e)
		{
            label1.Text = "X " + e.X + "Y " + e.Y;
            currentMousePoint = e.Location;
            sfMap1.Refresh();            
		}

		private void sfMap1_MouseLeave(object sender, EventArgs e)
		{
            currentMousePoint = Point.Empty;
            sfMap1.Refresh();
        }

		private void selectRecordOnClickToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
            
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
            //this will disable control/shift mouse selection
            //if (e.Control || e.Shift) e.Handled = true;
		}

		private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
		{
            using (var bm = this.sfMap1.GetBitmap())
            {
                Console.Out.WriteLine("Size:" + sfMap1.Size);
                Console.Out.WriteLine("clientSize:" + sfMap1.ClientSize);
                Console.Out.WriteLine("bm.Size:" + bm.Size);
                bm.Save(@"c:\temp\test.png", System.Drawing.Imaging.ImageFormat.Png);
            }
		}

		private void sfMap1_SelectedRecordsChanged(object sender, EventArgs e)
		{
            if (sfMap1.ShapeFileCount > 0 && sfMap1[0].SelectedRecordIndices.Count==0)
            {
                this.selectedRecordIndex = -1;
            }
		}

		
	}
}