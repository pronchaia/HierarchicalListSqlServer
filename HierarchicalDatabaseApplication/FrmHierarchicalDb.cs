using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HierarchicalDb;

namespace HierarchicalDatabaseApplication
{
    public partial class FrmHierarchicalDb : Form
    {

        public FrmHierarchicalDb()
        {
            InitializeComponent();
        }

        private void FrmHierarchicalDb_Load(object sender, EventArgs e)
        {
            InitControl();
        }

        private void btnLoadList_Click(object sender, EventArgs e)
        {
            treedb.Nodes.Clear();
            string connectionString = "Server=" + txtServer.Text.Trim() + ";Database=" + txtDatabase.Text.Trim() + ";User Id=" + txtUser.Text.Trim() + ";Password=" + txtPassword.Text.Trim() + ";Timeout=20000000;";
            SqlServerHierarchicalDb db = new SqlServerHierarchicalDb(connectionString);

            if(chkSaveConfig.Checked)
            {
                Properties.Settings.Default["SaveConfigDb"] = chkSaveConfig.Checked;
                Properties.Settings.Default["ServerDb"] = txtServer.Text.Trim();
                Properties.Settings.Default["DatabaseNameDb"] = txtDatabase.Text.Trim();
                Properties.Settings.Default["UserDb"] = txtUser.Text.Trim();
                Properties.Settings.Default["PasswordDb"] = txtPassword.Text.Trim();
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default["SaveConfigDb"] = false;
                Properties.Settings.Default["ServerDb"] = "";
                Properties.Settings.Default["DatabaseNameDb"] = "";
                Properties.Settings.Default["UserDb"] = "";
                Properties.Settings.Default["PasswordDb"] = "";
                Properties.Settings.Default.Save();
            }                         

            var lstTbls = db.GetHierarchicalTables();

            foreach (var tbl in lstTbls)
            {
                TreeNode masterNode = new TreeNode(tbl.Table.TableName);
                if (tbl.RefTable != null)
                {
                    GetNode(masterNode, tbl.RefTable);
                }
                treedb.Nodes.Add(masterNode);
                treedb.CollapseAll();
            }
        }

        private void GetNode(TreeNode masterNode, List<HierarchicalModel> refTbls)
        {
            foreach (var tbl in refTbls)
            {
                TreeNode node = new TreeNode(tbl.Table.TableName + "    [" + tbl.Table.ConstraintName + "] ");
                masterNode.Nodes.Add(node);

                if (tbl.RefTable != null)
                {
                    GetNode(node, tbl.RefTable);
                }
            }
        }

        private void InitControl()
        {
            rdoDbOption.Enabled = true;
            rdoTblOption.Enabled = false;
            txtTableName.Text = "";
            txtTableName.Enabled = false;
            chkSaveConfig.Checked = false;
            if (Properties.Settings.Default["SaveConfigDb"] != null)
            {
                chkSaveConfig.Checked = Convert.ToBoolean(Properties.Settings.Default["SaveConfigDb"]);
            }

            if (Properties.Settings.Default["ServerDb"] != null)
            {
                txtServer.Text = Properties.Settings.Default["ServerDb"].ToString();
            }
            if (Properties.Settings.Default["DatabaseNameDb"] != null)
            {
                txtDatabase.Text = Properties.Settings.Default["DatabaseNameDb"].ToString();
            }
            if (Properties.Settings.Default["UserDb"] != null)
            {
                txtUser.Text = Properties.Settings.Default["UserDb"].ToString();
            }
            if (Properties.Settings.Default["PasswordDb"] != null)
            {
                txtPassword.Text = Properties.Settings.Default["PasswordDb"].ToString();
            }
        }

    }
}
