
namespace edit
{
    partial class edit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(edit));
            this.panelMap = new System.Windows.Forms.Panel();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.tsp = new System.Windows.Forms.ToolStrip();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.btnEnd = new System.Windows.Forms.ToolStripButton();
            this.btnSelect = new System.Windows.Forms.ToolStripButton();
            this.btnMove = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.MapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panelMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.tsp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMap
            // 
            this.panelMap.Controls.Add(this.MapControl);
            this.panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMap.Location = new System.Drawing.Point(0, 45);
            this.panelMap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(1067, 517);
            this.panelMap.TabIndex = 1;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(1022, 5);
            this.axLicenseControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 15;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.btnTest);
            this.panelTop.Controls.Add(this.tsp);
            this.panelTop.Controls.Add(this.axLicenseControl1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1067, 45);
            this.panelTop.TabIndex = 0;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(652, 8);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 29);
            this.btnTest.TabIndex = 17;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tsp
            // 
            this.tsp.AllowDrop = true;
            this.tsp.Dock = System.Windows.Forms.DockStyle.None;
            this.tsp.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStart,
            this.btnUndo,
            this.btnRedo,
            this.btnSelect,
            this.btnMove,
            this.toolStripButton1,
            this.btnDelete,
            this.btnEnd});
            this.tsp.Location = new System.Drawing.Point(12, 5);
            this.tsp.Name = "tsp";
            this.tsp.Size = new System.Drawing.Size(452, 31);
            this.tsp.TabIndex = 16;
            this.tsp.Text = "toolStrip1";
            // 
            // btnStart
            // 
            this.btnStart.AutoSize = false;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(50, 22);
            this.btnStart.Text = "开始";
            this.btnStart.ToolTipText = "开始编辑";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.AutoSize = false;
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(50, 22);
            this.btnEnd.Text = "结束";
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AutoSize = false;
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
            this.btnMove.Image = ((System.Drawing.Image)(resources.GetObject("btnMove.Image")));
            this.btnMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(50, 22);
            this.btnMove.Text = "移动";
            this.btnMove.ToolTipText = "移动要素";
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(50, 22);
            this.toolStripButton1.Text = "添加";
            this.toolStripButton1.ToolTipText = "添加要素";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(50, 22);
            this.btnDelete.Text = "删除";
            this.btnDelete.ToolTipText = "删除要素";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.AutoSize = false;
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
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(50, 28);
            this.btnRedo.Text = "恢复";
            // 
            // MapControl
            // 
            this.MapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapControl.Location = new System.Drawing.Point(0, 0);
            this.MapControl.Margin = new System.Windows.Forms.Padding(4);
            this.MapControl.Name = "MapControl";
            this.MapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MapControl.OcxState")));
            this.MapControl.Size = new System.Drawing.Size(1067, 517);
            this.MapControl.TabIndex = 1;
            this.MapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.MapControl_OnMouseDown);
            this.MapControl.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.MapControl_OnMouseUp);
            this.MapControl.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.MapControl_OnMouseMove);
            this.MapControl.OnDoubleClick += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnDoubleClickEventHandler(this.MapControl_OnDoubleClick);
            // 
            // edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.panelMap);
            this.Controls.Add(this.panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "edit";
            this.Text = "edit";
            this.Load += new System.EventHandler(this.edit_Load);
            this.panelMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.tsp.ResumeLayout(false);
            this.tsp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMap;
        private ESRI.ArcGIS.Controls.AxMapControl MapControl;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.ToolStrip tsp;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.ToolStripButton btnSelect;
        private System.Windows.Forms.ToolStripButton btnMove;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnEnd;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
    }
}

