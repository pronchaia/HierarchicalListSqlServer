namespace HierarchicalDatabaseApplication
{
    partial class FrmHierarchicalDb
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLoadList = new System.Windows.Forms.Button();
            this.treedb = new System.Windows.Forms.TreeView();
            this.chkSaveConfig = new System.Windows.Forms.CheckBox();
            this.rdoDbOption = new System.Windows.Forms.RadioButton();
            this.rdoTblOption = new System.Windows.Forms.RadioButton();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(725, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "User : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(954, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password : ";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(99, 18);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(271, 26);
            this.txtServer.TabIndex = 4;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(483, 18);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(236, 26);
            this.txtDatabase.TabIndex = 5;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(786, 18);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(162, 26);
            this.txtUser.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(1050, 18);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(214, 26);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLoadList
            // 
            this.btnLoadList.Location = new System.Drawing.Point(99, 114);
            this.btnLoadList.Name = "btnLoadList";
            this.btnLoadList.Size = new System.Drawing.Size(159, 42);
            this.btnLoadList.TabIndex = 8;
            this.btnLoadList.Text = "Load";
            this.btnLoadList.UseVisualStyleBackColor = true;
            this.btnLoadList.Click += new System.EventHandler(this.btnLoadList_Click);
            // 
            // treedb
            // 
            this.treedb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treedb.Location = new System.Drawing.Point(12, 177);
            this.treedb.Name = "treedb";
            this.treedb.Size = new System.Drawing.Size(1661, 512);
            this.treedb.TabIndex = 9;
            // 
            // chkSaveConfig
            // 
            this.chkSaveConfig.AutoSize = true;
            this.chkSaveConfig.Location = new System.Drawing.Point(1270, 20);
            this.chkSaveConfig.Name = "chkSaveConfig";
            this.chkSaveConfig.Size = new System.Drawing.Size(161, 24);
            this.chkSaveConfig.TabIndex = 10;
            this.chkSaveConfig.Text = "Remember config";
            this.chkSaveConfig.UseVisualStyleBackColor = true;
            // 
            // rdoDbOption
            // 
            this.rdoDbOption.AutoSize = true;
            this.rdoDbOption.Checked = true;
            this.rdoDbOption.Location = new System.Drawing.Point(99, 65);
            this.rdoDbOption.Name = "rdoDbOption";
            this.rdoDbOption.Size = new System.Drawing.Size(177, 24);
            this.rdoDbOption.TabIndex = 11;
            this.rdoDbOption.Text = "All table in database";
            this.rdoDbOption.UseVisualStyleBackColor = true;
            // 
            // rdoTblOption
            // 
            this.rdoTblOption.AutoSize = true;
            this.rdoTblOption.Location = new System.Drawing.Point(300, 65);
            this.rdoTblOption.Name = "rdoTblOption";
            this.rdoTblOption.Size = new System.Drawing.Size(73, 24);
            this.rdoTblOption.TabIndex = 12;
            this.rdoTblOption.Text = "Table";
            this.rdoTblOption.UseVisualStyleBackColor = true;
            // 
            // txtTableName
            // 
            this.txtTableName.Enabled = false;
            this.txtTableName.Location = new System.Drawing.Point(379, 65);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(211, 26);
            this.txtTableName.TabIndex = 13;
            // 
            // FrmHierarchicalDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1685, 711);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.rdoTblOption);
            this.Controls.Add(this.rdoDbOption);
            this.Controls.Add(this.chkSaveConfig);
            this.Controls.Add(this.treedb);
            this.Controls.Add(this.btnLoadList);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmHierarchicalDb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hierarchical list of all tables sql server";
            this.Load += new System.EventHandler(this.FrmHierarchicalDb_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLoadList;
        private System.Windows.Forms.TreeView treedb;
        private System.Windows.Forms.CheckBox chkSaveConfig;
        private System.Windows.Forms.RadioButton rdoDbOption;
        private System.Windows.Forms.RadioButton rdoTblOption;
        private System.Windows.Forms.TextBox txtTableName;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}