using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using framework.Interface;

namespace app.UI
{
    public partial class Frm : Form
    {
        IApp _app; 
        public Frm(IApp app)
        {
            InitializeComponent();
            _app = app;
        }

        private void cbbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var f in _app.GISCore.QueryFeatClassFields(cbbLayer.SelectedItem.ToString()))
            {
                cbField.Items.Add(f);
            }
        }

        private void Frm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < _app.GISCore.MapControl.LayerCount; i++)
            {
                cbbLayer.Items.Add(_app.GISCore.MapControl.get_Layer(i).Name);
            }
        }

        private void tbField_TextChanged(object sender, EventArgs e)
        {
            string fName = cbbLayer.SelectedItem.ToString();
            string fieldName = cbField.SelectedItem.ToString();
            DataTable dt = new DataTable();
            dt.Columns.Add(fieldName, typeof(string));
            List<string> fieldLst = _app.GISCore.QueryField(fName, fieldName, $"{fieldName} LIKE '%{tbField.Text}%'");
            foreach (var f in fieldLst)
            {
                DataRow dr = dt.NewRow();
                dr[fieldName] = f;
                dt.Rows.Add(dr);
            }
            dgv.DataSource = dt;
            dgv.AutoGenerateColumns = false;
            dgv.AutoSize = true;
            dgv.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
