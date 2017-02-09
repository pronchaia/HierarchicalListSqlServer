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

        private void btnLoadList_Click(object sender, EventArgs e)
        {
            treedb.Nodes.Clear();
            string connectionString = "Server=" + txtServer.Text.Trim() + ";Database=" + txtDatabase.Text.Trim() + ";User Id=" + txtUser.Text.Trim() + ";Password=" + txtPassword.Text.Trim() + ";Timeout=20000000;";
            SqlServerHierarchicalDb db = new SqlServerHierarchicalDb(connectionString);

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
    }
}
