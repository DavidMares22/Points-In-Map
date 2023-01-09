using System;
using System.IO;
using System.Windows.Forms;

namespace Example1
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRecordOnClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawBoundingBoxOfSelectedRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayAttributesOnClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdShapefile = new System.Windows.Forms.OpenFileDialog();
            this.sfMap1 = new EGIS.Controls.SFMap();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(783, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectRecordOnClickToolStripMenuItem,
            this.drawBoundingBoxOfSelectedRecordToolStripMenuItem,
            this.displayAttributesOnClickToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // selectRecordOnClickToolStripMenuItem
            // 
            this.selectRecordOnClickToolStripMenuItem.Checked = true;
            this.selectRecordOnClickToolStripMenuItem.CheckOnClick = true;
            this.selectRecordOnClickToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selectRecordOnClickToolStripMenuItem.Name = "selectRecordOnClickToolStripMenuItem";
            this.selectRecordOnClickToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.selectRecordOnClickToolStripMenuItem.Text = "Select Record On Click";
            this.selectRecordOnClickToolStripMenuItem.Click += new System.EventHandler(this.selectRecordOnClickToolStripMenuItem_Click);
            // 
            // drawBoundingBoxOfSelectedRecordToolStripMenuItem
            // 
            this.drawBoundingBoxOfSelectedRecordToolStripMenuItem.Checked = true;
            this.drawBoundingBoxOfSelectedRecordToolStripMenuItem.CheckOnClick = true;
            this.drawBoundingBoxOfSelectedRecordToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawBoundingBoxOfSelectedRecordToolStripMenuItem.Name = "drawBoundingBoxOfSelectedRecordToolStripMenuItem";
            this.drawBoundingBoxOfSelectedRecordToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.drawBoundingBoxOfSelectedRecordToolStripMenuItem.Text = "Draw Bounding Box of Selected Record";
            // 
            // displayAttributesOnClickToolStripMenuItem
            // 
            this.displayAttributesOnClickToolStripMenuItem.CheckOnClick = true;
            this.displayAttributesOnClickToolStripMenuItem.Name = "displayAttributesOnClickToolStripMenuItem";
            this.displayAttributesOnClickToolStripMenuItem.Size = new System.Drawing.Size(280, 22);
            this.displayAttributesOnClickToolStripMenuItem.Text = "Display Attributes On Click";
            // 
            // miOpen
            // 
            this.miOpen.Name = "miOpen";
            this.miOpen.Size = new System.Drawing.Size(32, 19);
            // 
            // ofdShapefile
            // 
            this.ofdShapefile.Filter = "ESRI ShapeFile|*.shp";
            this.ofdShapefile.InitialDirectory = ".";
            // 
            // sfMap1
            // 
            this.sfMap1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sfMap1.Cursor = System.Windows.Forms.Cursors.Default;
            this.sfMap1.DefaultMapCursor = System.Windows.Forms.Cursors.Default;
            this.sfMap1.DefaultSelectionCursor = System.Windows.Forms.Cursors.Hand;
            this.sfMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sfMap1.Location = new System.Drawing.Point(0, 24);
            this.sfMap1.MapBackColor = System.Drawing.SystemColors.Control;
            this.sfMap1.Margin = new System.Windows.Forms.Padding(0);
            this.sfMap1.MaxZoomLevel = 1.7976931348623157E+308D;
            this.sfMap1.MinZomLevel = 0D;
            this.sfMap1.MouseWheelZoomMode = EGIS.Controls.MouseWheelZoomMode.Disabled;
            this.sfMap1.Name = "sfMap1";
            this.sfMap1.PanSelectMode = EGIS.Controls.PanSelectMode.Pan;
            this.sfMap1.RenderQuality = EGIS.ShapeFileLib.RenderQuality.Auto;
            this.sfMap1.Size = new System.Drawing.Size(783, 401);
            this.sfMap1.TabIndex = 0;
            this.sfMap1.UseMemoryStreams = false;
            this.sfMap1.UseMercatorProjection = false;
            this.sfMap1.ZoomLevel = 1D;
            this.sfMap1.ZoomToSelectedExtentWhenCtrlKeydown = false;
            this.sfMap1.Paint += new System.Windows.Forms.PaintEventHandler(this.sfMap1_Paint);
            this.sfMap1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sfMap1_MouseDown);
            this.sfMap1.MouseLeave += new System.EventHandler(this.sfMap1_MouseLeave);
            //this.sfMap1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.sfMap1_MouseMove);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 425);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(783, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 447);
            this.Controls.Add(this.sfMap1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Example 1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private EGIS.Controls.SFMap sfMap1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miOpen;
        private System.Windows.Forms.OpenFileDialog ofdShapefile;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectRecordOnClickToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem drawBoundingBoxOfSelectedRecordToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem displayAttributesOnClickToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
    }
}

