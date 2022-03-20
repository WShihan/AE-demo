
namespace GISDemo
{
    partial class appMainUI
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(appMainUI));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.ToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelTip = new System.Windows.Forms.Panel();
            this.tbCoord = new System.Windows.Forms.TextBox();
            this.tbScale = new System.Windows.Forms.TextBox();
            this.TocControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.panelMap = new System.Windows.Forms.Panel();
            this.MapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.panelLeft.SuspendLayout();
            this.panelTip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TocControl)).BeginInit();
            this.panelMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.ToolbarControl);
            this.panel1.Controls.Add(this.axLicenseControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 37);
            this.panel1.TabIndex = 0;
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(523, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(66, 27);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // ToolbarControl
            // 
            this.ToolbarControl.Location = new System.Drawing.Point(13, 4);
            this.ToolbarControl.Name = "ToolbarControl";
            this.ToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ToolbarControl.OcxState")));
            this.ToolbarControl.Size = new System.Drawing.Size(477, 28);
            this.ToolbarControl.TabIndex = 1;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(900, 8);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLeft.AutoSize = true;
            this.panelLeft.Controls.Add(this.panelTip);
            this.panelLeft.Controls.Add(this.TocControl);
            this.panelLeft.Location = new System.Drawing.Point(0, 37);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(5, 5, 1, 5);
            this.panelLeft.Size = new System.Drawing.Size(206, 456);
            this.panelLeft.TabIndex = 1;
            // 
            // panelTip
            // 
            this.panelTip.Controls.Add(this.tbCoord);
            this.panelTip.Controls.Add(this.tbScale);
            this.panelTip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTip.Location = new System.Drawing.Point(5, 417);
            this.panelTip.Name = "panelTip";
            this.panelTip.Size = new System.Drawing.Size(200, 34);
            this.panelTip.TabIndex = 3;
            // 
            // tbCoord
            // 
            this.tbCoord.Location = new System.Drawing.Point(83, 6);
            this.tbCoord.Name = "tbCoord";
            this.tbCoord.Size = new System.Drawing.Size(112, 25);
            this.tbCoord.TabIndex = 2;
            this.tbCoord.Text = "110.554,36.22";
            // 
            // tbScale
            // 
            this.tbScale.Location = new System.Drawing.Point(2, 6);
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(75, 25);
            this.tbScale.TabIndex = 1;
            this.tbScale.Text = "1:100";
            // 
            // TocControl
            // 
            this.TocControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TocControl.Location = new System.Drawing.Point(5, 5);
            this.TocControl.Name = "TocControl";
            this.TocControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("TocControl.OcxState")));
            this.TocControl.Size = new System.Drawing.Size(200, 446);
            this.TocControl.TabIndex = 0;
            // 
            // panelMap
            // 
            this.panelMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMap.Controls.Add(this.MapControl);
            this.panelMap.Location = new System.Drawing.Point(212, 37);
            this.panelMap.Name = "panelMap";
            this.panelMap.Padding = new System.Windows.Forms.Padding(0, 6, 6, 6);
            this.panelMap.Size = new System.Drawing.Size(730, 456);
            this.panelMap.TabIndex = 2;
            // 
            // MapControl
            // 
            this.MapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapControl.Location = new System.Drawing.Point(0, 6);
            this.MapControl.Name = "MapControl";
            this.MapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MapControl.OcxState")));
            this.MapControl.Size = new System.Drawing.Size(724, 444);
            this.MapControl.TabIndex = 0;
            this.MapControl.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.MapControl_OnMouseMove);
            // 
            // appMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 493);
            this.Controls.Add(this.panelMap);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "appMainUI";
            this.Text = "MiniGIS";
            this.Load += new System.EventHandler(this.appMainUI_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelTip.ResumeLayout(false);
            this.panelTip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TocControl)).EndInit();
            this.panelMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelMap;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl ToolbarControl;
        private ESRI.ArcGIS.Controls.AxMapControl MapControl;
        private ESRI.ArcGIS.Controls.AxTOCControl TocControl;
        private System.Windows.Forms.TextBox tbCoord;
        private System.Windows.Forms.TextBox tbScale;
        private System.Windows.Forms.Panel panelTip;
        private System.Windows.Forms.Button btnTest;
    }
}

