using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using framework.Interface;

namespace app.UI
{
    public partial class FrmQueryField : Form
    {
        IApp _app; 
        public FrmQueryField(IApp app)
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
            if (fieldLst == null)
            {
                return;
            }
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


        private void dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string selValue = dgv.SelectedCells.ToString();
        }

        private void dgv_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string fName = cbbLayer.SelectedItem.ToString();
            string fildName = cbField.SelectedItem.ToString();
            int rowIndex = dgv.SelectedCells[0].RowIndex;
            string selectValue = dgv.Rows[rowIndex].Cells[0].Value.ToString();
            var featLst  = _app.GISCore.Query(fName, $"{ fildName } = '{ selectValue }'");
            if (featLst.Count >0)
            {
                IGeometry geom = featLst[0].Shape;
                _app.GISCore.HightlightSelectedFeat(fName, featLst[0]);
                _app.GISCore.ZoomTo(geom);
            }
        }
    }
}
