
namespace app
{
    partial class AppFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppFrm));
            this.panelMap = new System.Windows.Forms.Panel();
            this.MapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.panelTop = new System.Windows.Forms.Panel();
            this.ToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.tsp = new System.Windows.Forms.ToolStrip();
            this.tsb = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.btnMove = new System.Windows.Forms.ToolStripButton();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbTest = new System.Windows.Forms.ToolStripSplitButton();
            this.btnTest = new System.Windows.Forms.ToolStripMenuItem();
            this.btnIOC = new System.Windows.Forms.ToolStripMenuItem();
            this.paneLeft = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbCoord = new System.Windows.Forms.TextBox();
            this.tbScale = new System.Windows.Forms.TextBox();
            this.TocControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.panelMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarControl)).BeginInit();
            this.tsp.SuspendLayout();
            this.paneLeft.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TocControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMap
            // 
            this.panelMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMap.Controls.Add(this.MapControl);
            this.panelMap.Location = new System.Drawing.Point(226, 45);
            this.panelMap.Margin = new System.Windows.Forms.Padding(4);
            this.panelMap.Name = "panelMap";
            this.panelMap.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.panelMap.Size = new System.Drawing.Size(858, 485);
            this.panelMap.TabIndex = 1;
            // 
            // MapControl
            // 
            this.MapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapControl.Location = new System.Drawing.Point(0, 3);
            this.MapControl.Margin = new System.Windows.Forms.Padding(4);
            this.MapControl.Name = "MapControl";
            this.MapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MapControl.OcxState")));
            this.MapControl.Size = new System.Drawing.Size(855, 479);
            this.MapControl.TabIndex = 1;
            this.MapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.MapControl_OnMouseDown);
            this.MapControl.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.MapControl_OnMouseUp);
            this.MapControl.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.MapControl_OnMouseMove);
            this.MapControl.OnDoubleClick += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnDoubleClickEventHandler(this.MapControl_OnDoubleClick);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(1022, 5);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(4);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 15;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.ToolbarControl);
            this.panelTop.Controls.Add(this.tsp);
            this.panelTop.Controls.Add(this.axLicenseControl1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1084, 45);
            this.panelTop.TabIndex = 0;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ToolbarControl
            // 
            this.ToolbarControl.Location = new System.Drawing.Point(0, 8);
            this.ToolbarControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ToolbarControl.Name = "ToolbarControl";
            this.ToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ToolbarControl.OcxState")));
            this.ToolbarControl.Size = new System.Drawing.Size(462, 28);
            this.ToolbarControl.TabIndex = 18;
            // 
            // tsp
            // 
            this.tsp.AllowDrop = true;
            this.tsp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tsp.Dock = System.Windows.Forms.DockStyle.None;
            this.tsp.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb,
            this.btnUndo,
            this.btnRedo,
            this.btnSelect,
            this.btnMove,
            this.btnAdd,
            this.btnDelete,
            this.tsbTest});
            this.tsp.Location = new System.Drawing.Point(562, 6);
            this.tsp.Name = "tsp";
            this.tsp.Size = new System.Drawing.Size(453, 31);
            this.tsp.TabIndex = 16;
            this.tsp.Text = "toolStrip1";
            // 
            // tsb
            // 
            this.tsb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStart,
            this.tsbSave,
            this.tsbEnd});
            this.tsb.Image = ((System.Drawing.Image)(resources.GetObject("tsb.Image")));
            this.tsb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb.Name = "tsb";
            this.tsb.Size = new System.Drawing.Size(84, 28);
            this.tsb.Text = "编辑模式";
            this.tsb.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // tsbStart
            // 
            this.tsbStart.Image = global::app.Properties.Resources.StartEditing;
            this.tsbStart.Name = "tsbStart";
            this.tsbStart.Size = new System.Drawing.Size(148, 26);
            this.tsbStart.Text = "开始编辑";
            this.tsbStart.Click += new System.EventHandler(this.tsbStart_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = global::app.Properties.Resources.SaveEdits;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(148, 26);
            this.tsbSave.Text = "保存编辑";
            // 
            // tsbEnd
            // 
            this.tsbEnd.Enabled = false;
            this.tsbEnd.Image = global::app.Properties.Resources.StopEditing;
            this.tsbEnd.Name = "tsbEnd";
            this.tsbEnd.Size = new System.Drawing.Size(148, 26);
            this.tsbEnd.Text = "结束编辑";
            this.tsbEnd.Click += new System.EventHandler(this.tsbEnd_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.AutoSize = false;
            this.btnUndo.Enabled = false;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(50, 28);
            this.btnUndo.Text = "撤销";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.AutoSize = false;
            this.btnRedo.Enabled = false;
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(50, 28);
            this.btnRedo.Text = "恢复";
            // 
            // btnSelect
            // 
            this.btnSelect.AutoSize = false;
            this.btnSelect.Enabled = false;
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(50, 22);
            this.btnSelect.Text = "选择";
            this.btnSelect.ToolTipText = "选择要素";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnMove
            // 
            this.btnMove.AutoSize = false;
            this.btnMove.Enabled = false;
            this.btnMove.Image = ((System.Drawing.Image)(resources.GetObject("btnMove.Image")));
            this.btnMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(50, 22);
            this.btnMove.Text = "移动";
            this.btnMove.ToolTipText = "移动要素";
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = false;
            this.btnAdd.Enabled = false;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 22);
            this.btnAdd.Text = "添加";
            this.btnAdd.ToolTipText = "添加要素";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 22);
            this.btnDelete.Text = "删除";
            this.btnDelete.ToolTipText = "删除要素";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tsbTest
            // 
            this.tsbTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTest,
            this.btnIOC});
            this.tsbTest.Image = ((System.Drawing.Image)(resources.GetObject("tsbTest.Image")));
            this.tsbTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTest.Name = "tsbTest";
            this.tsbTest.Size = new System.Drawing.Size(56, 28);
            this.tsbTest.Text = "测试";
            // 
            // btnTest
            // 
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(224, 26);
            this.btnTest.Text = "查询要素";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnIOC
            // 
            this.btnIOC.Name = "btnIOC";
            this.btnIOC.Size = new System.Drawing.Size(224, 26);
            this.btnIOC.Text = "IOC测试";
            this.btnIOC.Click += new System.EventHandler(this.btnIOC_Click);
            // 
            // paneLeft
            // 
            this.paneLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.paneLeft.AutoSize = true;
            this.paneLeft.Controls.Add(this.panel1);
            this.paneLeft.Controls.Add(this.TocControl);
            this.paneLeft.Location = new System.Drawing.Point(0, 45);
            this.paneLeft.Name = "paneLeft";
            this.paneLeft.Size = new System.Drawing.Size(219, 482);
            this.paneLeft.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbCoord);
            this.panel1.Controls.Add(this.tbScale);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 446);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 36);
            this.panel1.TabIndex = 1;
            // 
            // tbCoord
            // 
            this.tbCoord.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCoord.Location = new System.Drawing.Point(94, 9);
            this.tbCoord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbCoord.Name = "tbCoord";
            this.tbCoord.Size = new System.Drawing.Size(115, 20);
            this.tbCoord.TabIndex = 4;
            this.tbCoord.Text = "110.554,36.22";
            // 
            // tbScale
            // 
            this.tbScale.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbScale.Location = new System.Drawing.Point(9, 8);
            this.tbScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(77, 20);
            this.tbScale.TabIndex = 3;
            this.tbScale.Text = "1:100";
            // 
            // TocControl
            // 
            this.TocControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TocControl.Location = new System.Drawing.Point(0, 0);
            this.TocControl.Name = "TocControl";
            this.TocControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("TocControl.OcxState")));
            this.TocControl.Size = new System.Drawing.Size(219, 482);
            this.TocControl.TabIndex = 0;
            // 
            // AppFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 530);
            this.Controls.Add(this.paneLeft);
            this.Controls.Add(this.panelMap);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AppFrm";
            this.Text = "edit";
            this.Load += new System.EventHandler(this.AppFrm_Load);
            this.panelMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ToolbarControl)).EndInit();
            this.tsp.ResumeLayout(false);
            this.tsp.PerformLayout();
            this.paneLeft.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TocControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelMap;
        private ESRI.ArcGIS.Controls.AxMapControl MapControl;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip tsp;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
        private System.Windows.Forms.ToolStripButton btnSelect;
        private System.Windows.Forms.ToolStripButton btnMove;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSplitButton tsb;
        private System.Windows.Forms.ToolStripMenuItem tsbStart;
        private System.Windows.Forms.ToolStripMenuItem tsbSave;
        private System.Windows.Forms.ToolStripMenuItem tsbEnd;
        private System.Windows.Forms.Panel paneLeft;
        private ESRI.ArcGIS.Controls.AxTOCControl TocControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbCoord;
        private System.Windows.Forms.TextBox tbScale;
        private ESRI.ArcGIS.Controls.AxToolbarControl ToolbarControl;
        private System.Windows.Forms.ToolStripSplitButton tsbTest;
        private System.Windows.Forms.ToolStripMenuItem btnTest;
        private System.Windows.Forms.ToolStripMenuItem btnIOC;
    }
}

