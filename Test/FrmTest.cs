using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Test
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
            LoadData();
            this.ConnectDB();
        }
        public void LoadData()
        {
            List<entity> entityLst = new List<entity>();
            entityLst.Add(new entity("a", "yunnan", "man", 12, 2, 4));
            entityLst.Add(new entity("a", "yunnan", "man", 12, 2, 4));
            entityLst.Add(new entity("a", "yunnan", "man", 12, 2, 4));
            entityLst.Add(new entity("a", "yunnan", "man", 12, 2, 4));
            dgv.DataSource = entityLst;

        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Dictionary<string, List<int>> orderDic = new Dictionary<string, List<int>>();
            orderDic.Add("Name", new List<int>{ 1,4});
            orderDic.Add("Home", new List<int> { 0, 2 });
            orderDic.Add("Gender", new List<int> { 1, 0 });
            orderDic.Add("Age", new List<int> { 1, 3 });
            orderDic.Add("Grade", new List<int> { 1, 2 });
            orderDic.Add("Cls", new List<int> { 1, 1 });

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                string dcName = dgv.Columns[i].Name;
                var info = orderDic[dcName];
                if (info[0] == 0)
                {
                    dgv.Columns[i].Visible = false;
                }
                else
                {
                    dgv.Columns[i].DisplayIndex = info[1];
                }
            }
            ConnectDB();
        }
        public void ConnectDB()
        {
            SQLiteConnection sqliteConn = new SQLiteConnection(@"Data Source=C:\Users\Administrator\Desktop\AE-demo\asset\data\db.db");
            try
            {
                // sqlite connection;
                SQLiteDataAdapter sqliteAdpt = new SQLiteDataAdapter("select * from test", sqliteConn);
                sqliteConn.Open();
                SQLiteCommand cmd = new SQLiteCommand("select * from test", sqliteConn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Name:" + reader["name"]);
                    Console.ReadLine();
                }
                sqliteConn.Close();
            }
            finally
            {
                sqliteConn.Close();
            }
        }
    }
}
