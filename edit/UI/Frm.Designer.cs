
namespace app.UI
{
    partial class Frm
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.cbbLayer = new System.Windows.Forms.ComboBox();
            this.gbDgv = new System.Windows.Forms.GroupBox();
            this.cbField = new System.Windows.Forms.ComboBox();
            this.tbField = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.gbDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(2, 16);
            this.dgv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 27;
            this.dgv.Size = new System.Drawing.Size(289, 325);
            this.dgv.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbInfo);
            this.panel1.Controls.Add(this.gbDgv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 449);
            this.panel1.TabIndex = 1;
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInfo.Controls.Add(this.tbField);
            this.gbInfo.Controls.Add(this.cbField);
            this.gbInfo.Controls.Add(this.cbbLayer);
            this.gbInfo.Location = new System.Drawing.Point(2, 2);
            this.gbInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbInfo.Size = new System.Drawing.Size(293, 106);
            this.gbInfo.TabIndex = 2;
            this.gbInfo.TabStop = false;
            // 
            // cbbLayer
            // 
            this.cbbLayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbLayer.FormattingEnabled = true;
            this.cbbLayer.Location = new System.Drawing.Point(2, 14);
            this.cbbLayer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbLayer.Name = "cbbLayer";
            this.cbbLayer.Size = new System.Drawing.Size(290, 20);
            this.cbbLayer.TabIndex = 0;
            this.cbbLayer.SelectedIndexChanged += new System.EventHandler(this.cbbLayer_SelectedIndexChanged);
            // 
            // gbDgv
            // 
            this.gbDgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDgv.Controls.Add(this.dgv);
            this.gbDgv.Location = new System.Drawing.Point(2, 103);
            this.gbDgv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbDgv.Name = "gbDgv";
            this.gbDgv.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbDgv.Size = new System.Drawing.Size(293, 343);
            this.gbDgv.TabIndex = 1;
            this.gbDgv.TabStop = false;
            // 
            // cbField
            // 
            this.cbField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbField.FormattingEnabled = true;
            this.cbField.Location = new System.Drawing.Point(2, 43);
            this.cbField.Margin = new System.Windows.Forms.Padding(2);
            this.cbField.Name = "cbField";
            this.cbField.Size = new System.Drawing.Size(289, 20);
            this.cbField.TabIndex = 1;
            // 
            // tbField
            // 
            this.tbField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbField.Location = new System.Drawing.Point(2, 68);
            this.tbField.Name = "tbField";
            this.tbField.Size = new System.Drawing.Size(289, 21);
            this.tbField.TabIndex = 2;
            this.tbField.TextChanged += new System.EventHandler(this.tbField_TextChanged);
            // 
            // Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 449);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Frm";
            this.Text = "Frm";
            this.Load += new System.EventHandler(this.Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.GroupBox gbDgv;
        private System.Windows.Forms.ComboBox cbbLayer;
        private System.Windows.Forms.TextBox tbField;
        private System.Windows.Forms.ComboBox cbField;
    }
}