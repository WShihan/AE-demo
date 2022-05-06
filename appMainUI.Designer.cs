
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
            this.panelFunc = new System.Windows.Forms.Panel();
            this.btn = new System.Windows.Forms.Button();
            this.btnSelectByLocation = new System.Windows.Forms.Button();
            this.LicenseControl = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.btnHighlight = new System.Windows.Forms.Button();
            this.btnLoadCSV = new System.Windows.Forms.Button();
            this.btnSelectFeat = new System.Windows.Forms.Button();
            this.ToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.MapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panelMap = new System.Windows.Forms.Panel();
            this.tabMap = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pageLayoutControl = new ESRI.ArcGIS.Controls.AxPageLayoutControl();
            this.panelTip = new System.Windows.Forms.Panel();
            this.tbScale = new System.Windows.Forms.TextBox();
            this.tbCoord = new System.Windows.Forms.TextBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.TocControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.panel1.SuspendLayout();
            this.panelFunc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LicenseControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).BeginInit();
            this.panelMap.SuspendLayout();
            this.tabMap.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageLayoutControl)).BeginInit();
            this.panelTip.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TocControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelFunc);
            this.panel1.Controls.Add(this.ToolbarControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 38);
            this.panel1.TabIndex = 0;
            // 
            // panelFunc
            // 
            this.panelFunc.Controls.Add(this.btn);
            this.panelFunc.Controls.Add(this.btnSelectByLocation);
            this.panelFunc.Controls.Add(this.LicenseControl);
            this.panelFunc.Controls.Add(this.btnHighlight);
            this.panelFunc.Controls.Add(this.btnLoadCSV);
            this.panelFunc.Controls.Add(this.btnSelectFeat);
            this.panelFunc.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelFunc.Location = new System.Drawing.Point(457, 0);
            this.panelFunc.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelFunc.Name = "panelFunc";
            this.panelFunc.Size = new System.Drawing.Size(484, 38);
            this.panelFunc.TabIndex = 3;
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(123, 8);
            this.btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(64, 28);
            this.btn.TabIndex = 7;
            this.btn.Text = "测试";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSelectByLocation
            // 
            this.btnSelectByLocation.Location = new System.Drawing.Point(401, 6);
            this.btnSelectByLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectByLocation.Name = "btnSelectByLocation";
            this.btnSelectByLocation.Size = new System.Drawing.Size(67, 28);
            this.btnSelectByLocation.TabIndex = 6;
            this.btnSelectByLocation.Text = "空间查询";
            this.btnSelectByLocation.UseVisualStyleBackColor = true;
            this.btnSelectByLocation.Click += new System.EventHandler(this.btnSelectByLocation_Click);
            // 
            // LicenseControl
            // 
            this.LicenseControl.Enabled = true;
            this.LicenseControl.Location = new System.Drawing.Point(467, -1);
            this.LicenseControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LicenseControl.Name = "LicenseControl";
            this.LicenseControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("LicenseControl.OcxState")));
            this.LicenseControl.Size = new System.Drawing.Size(32, 32);
            this.LicenseControl.TabIndex = 5;
            // 
            // btnHighlight
            // 
            this.btnHighlight.Location = new System.Drawing.Point(335, 8);
            this.btnHighlight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(61, 28);
            this.btnHighlight.TabIndex = 4;
            this.btnHighlight.Text = "选择高亮";
            this.btnHighlight.UseVisualStyleBackColor = true;
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // btnLoadCSV
            // 
            this.btnLoadCSV.Location = new System.Drawing.Point(261, 6);
            this.btnLoadCSV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadCSV.Name = "btnLoadCSV";
            this.btnLoadCSV.Size = new System.Drawing.Size(68, 28);
            this.btnLoadCSV.TabIndex = 3;
            this.btnLoadCSV.Text = "加载CSV";
            this.btnLoadCSV.UseVisualStyleBackColor = true;
            // 
            // btnSelectFeat
            // 
            this.btnSelectFeat.Location = new System.Drawing.Point(192, 8);
            this.btnSelectFeat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelectFeat.Name = "btnSelectFeat";
            this.btnSelectFeat.Size = new System.Drawing.Size(64, 28);
            this.btnSelectFeat.TabIndex = 2;
            this.btnSelectFeat.Text = "选择要素";
            this.btnSelectFeat.UseVisualStyleBackColor = true;
            this.btnSelectFeat.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // ToolbarControl
            // 
            this.ToolbarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolbarControl.Location = new System.Drawing.Point(0, 0);
            this.ToolbarControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ToolbarControl.Name = "ToolbarControl";
            this.ToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ToolbarControl.OcxState")));
            this.ToolbarControl.Size = new System.Drawing.Size(423, 28);
            this.ToolbarControl.TabIndex = 1;
            // 
            // MapControl
            // 
            this.MapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapControl.Location = new System.Drawing.Point(4, 4);
            this.MapControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MapControl.Name = "MapControl";
            this.MapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MapControl.OcxState")));
            this.MapControl.Size = new System.Drawing.Size(696, 407);
            this.MapControl.TabIndex = 0;
            this.MapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.MapControl_OnMouseDown);
            this.MapControl.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.MapControl_OnMouseUp);
            this.MapControl.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.MapControl_OnMouseMove);
            // 
            // panelMap
            // 
            this.panelMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMap.Controls.Add(this.tabMap);
            this.panelMap.Location = new System.Drawing.Point(225, 38);
            this.panelMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMap.Name = "panelMap";
            this.panelMap.Padding = new System.Windows.Forms.Padding(0, 6, 5, 6);
            this.panelMap.Size = new System.Drawing.Size(717, 456);
            this.panelMap.TabIndex = 2;
            // 
            // tabMap
            // 
            this.tabMap.Controls.Add(this.tabPage1);
            this.tabMap.Controls.Add(this.tabPage2);
            this.tabMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMap.Location = new System.Drawing.Point(0, 6);
            this.tabMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabMap.Name = "tabMap";
            this.tabMap.SelectedIndex = 0;
            this.tabMap.Size = new System.Drawing.Size(712, 444);
            this.tabMap.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MapControl);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(704, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pageLayoutControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(704, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pageLayoutControl
            // 
            this.pageLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageLayoutControl.Location = new System.Drawing.Point(4, 4);
            this.pageLayoutControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pageLayoutControl.Name = "pageLayoutControl";
            this.pageLayoutControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pageLayoutControl.OcxState")));
            this.pageLayoutControl.Size = new System.Drawing.Size(696, 407);
            this.pageLayoutControl.TabIndex = 0;
            // 
            // panelTip
            // 
            this.panelTip.Controls.Add(this.tbCoord);
            this.panelTip.Controls.Add(this.tbScale);
            this.panelTip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTip.Location = new System.Drawing.Point(5, 417);
            this.panelTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTip.Name = "panelTip";
            this.panelTip.Size = new System.Drawing.Size(213, 34);
            this.panelTip.TabIndex = 3;
            // 
            // tbScale
            // 
            this.tbScale.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbScale.Location = new System.Drawing.Point(7, 9);
            this.tbScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(77, 20);
            this.tbScale.TabIndex = 1;
            this.tbScale.Text = "1:100";
            // 
            // tbCoord
            // 
            this.tbCoord.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCoord.Location = new System.Drawing.Point(92, 10);
            this.tbCoord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCoord.Name = "tbCoord";
            this.tbCoord.Size = new System.Drawing.Size(115, 20);
            this.tbCoord.TabIndex = 2;
            this.tbCoord.Text = "110.554,36.22";
            // 
            // panelLeft
            // 
            this.panelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelLeft.AutoSize = true;
            this.panelLeft.Controls.Add(this.panelTip);
            this.panelLeft.Controls.Add(this.TocControl);
            this.panelLeft.Location = new System.Drawing.Point(0, 38);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(5, 5, 1, 5);
            this.panelLeft.Size = new System.Drawing.Size(219, 456);
            this.panelLeft.TabIndex = 1;
            // 
            // TocControl
            // 
            this.TocControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TocControl.Location = new System.Drawing.Point(5, 5);
            this.TocControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TocControl.Name = "TocControl";
            this.TocControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("TocControl.OcxState")));
            this.TocControl.Size = new System.Drawing.Size(213, 446);
            this.TocControl.TabIndex = 0;
            this.TocControl.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.TocControl_OnMouseDown);
            // 
            // appMainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 492);
            this.Controls.Add(this.panelMap);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "appMainUI";
            this.Text = "Demo";
            this.Load += new System.EventHandler(this.appMainUI_Load);
            this.panel1.ResumeLayout(false);
            this.panelFunc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LicenseControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).EndInit();
            this.panelMap.ResumeLayout(false);
            this.tabMap.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageLayoutControl)).EndInit();
            this.panelTip.ResumeLayout(false);
            this.panelTip.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TocControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ESRI.ArcGIS.Controls.AxToolbarControl ToolbarControl;
        private System.Windows.Forms.Button btnSelectFeat;
        private System.Windows.Forms.Panel panelFunc;
        private System.Windows.Forms.Button btnLoadCSV;
        private ESRI.ArcGIS.Controls.AxMapControl MapControl;
        private System.Windows.Forms.Panel panelMap;
        private System.Windows.Forms.TabControl tabMap;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxPageLayoutControl pageLayoutControl;
        private System.Windows.Forms.Button btnHighlight;
        private ESRI.ArcGIS.Controls.AxLicenseControl LicenseControl;
        private System.Windows.Forms.Button btnSelectByLocation;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Panel panelTip;
        private System.Windows.Forms.TextBox tbCoord;
        private System.Windows.Forms.TextBox tbScale;
        private System.Windows.Forms.Panel panelLeft;
        private ESRI.ArcGIS.Controls.AxTOCControl TocControl;
    }
}

