namespace _323milestone2
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxUserSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.listBoxPortfolios = new System.Windows.Forms.ListBox();
            this.listBoxProjects = new System.Windows.Forms.ListBox();
            this.textBoxPortfolioDesc = new System.Windows.Forms.TextBox();
            this.textBoxProjectDesc = new System.Windows.Forms.TextBox();
            this.buttonAddProject = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.OracleTab = new System.Windows.Forms.TabPage();
            this.MongoDBTab = new System.Windows.Forms.TabPage();
            this.listBoxArtistsMongo = new System.Windows.Forms.ListBox();
            this.buttonAddProjectMongo = new System.Windows.Forms.Button();
            this.textBoxSearchMongo = new System.Windows.Forms.TextBox();
            this.textBoxProjDescMongo = new System.Windows.Forms.TextBox();
            this.buttonSearchMongo = new System.Windows.Forms.Button();
            this.listBoxProjectsMongo = new System.Windows.Forms.ListBox();
            this.textBoxPortDescMongo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxPortfoliosMongo = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.OracleTab.SuspendLayout();
            this.MongoDBTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Search...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxUserSearch
            // 
            this.textBoxUserSearch.Location = new System.Drawing.Point(98, 8);
            this.textBoxUserSearch.Name = "textBoxUserSearch";
            this.textBoxUserSearch.Size = new System.Drawing.Size(244, 20);
            this.textBoxUserSearch.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search for user:";
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(98, 34);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(244, 407);
            this.listBoxUsers.TabIndex = 4;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxUsers_SelectedIndexChanged);
            // 
            // listBoxPortfolios
            // 
            this.listBoxPortfolios.FormattingEnabled = true;
            this.listBoxPortfolios.Location = new System.Drawing.Point(456, 34);
            this.listBoxPortfolios.Name = "listBoxPortfolios";
            this.listBoxPortfolios.Size = new System.Drawing.Size(318, 277);
            this.listBoxPortfolios.TabIndex = 5;
            this.listBoxPortfolios.SelectedIndexChanged += new System.EventHandler(this.listBoxPortfolios_SelectedIndexChanged);
            // 
            // listBoxProjects
            // 
            this.listBoxProjects.FormattingEnabled = true;
            this.listBoxProjects.Location = new System.Drawing.Point(780, 34);
            this.listBoxProjects.Name = "listBoxProjects";
            this.listBoxProjects.Size = new System.Drawing.Size(318, 277);
            this.listBoxProjects.TabIndex = 6;
            this.listBoxProjects.SelectedIndexChanged += new System.EventHandler(this.listBoxProjects_SelectedIndexChanged);
            // 
            // textBoxPortfolioDesc
            // 
            this.textBoxPortfolioDesc.Location = new System.Drawing.Point(456, 323);
            this.textBoxPortfolioDesc.Multiline = true;
            this.textBoxPortfolioDesc.Name = "textBoxPortfolioDesc";
            this.textBoxPortfolioDesc.ReadOnly = true;
            this.textBoxPortfolioDesc.Size = new System.Drawing.Size(318, 118);
            this.textBoxPortfolioDesc.TabIndex = 7;
            // 
            // textBoxProjectDesc
            // 
            this.textBoxProjectDesc.Location = new System.Drawing.Point(780, 323);
            this.textBoxProjectDesc.Multiline = true;
            this.textBoxProjectDesc.Name = "textBoxProjectDesc";
            this.textBoxProjectDesc.ReadOnly = true;
            this.textBoxProjectDesc.Size = new System.Drawing.Size(318, 118);
            this.textBoxProjectDesc.TabIndex = 8;
            // 
            // buttonAddProject
            // 
            this.buttonAddProject.Location = new System.Drawing.Point(1012, 446);
            this.buttonAddProject.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddProject.Name = "buttonAddProject";
            this.buttonAddProject.Size = new System.Drawing.Size(86, 24);
            this.buttonAddProject.TabIndex = 9;
            this.buttonAddProject.Text = "&Add Project...";
            this.buttonAddProject.UseVisualStyleBackColor = true;
            this.buttonAddProject.Click += new System.EventHandler(this.buttonAddProject_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.OracleTab);
            this.tabControl1.Controls.Add(this.MongoDBTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1109, 498);
            this.tabControl1.TabIndex = 10;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // OracleTab
            // 
            this.OracleTab.Controls.Add(this.listBoxUsers);
            this.OracleTab.Controls.Add(this.buttonAddProject);
            this.OracleTab.Controls.Add(this.textBoxUserSearch);
            this.OracleTab.Controls.Add(this.textBoxProjectDesc);
            this.OracleTab.Controls.Add(this.button1);
            this.OracleTab.Controls.Add(this.listBoxProjects);
            this.OracleTab.Controls.Add(this.textBoxPortfolioDesc);
            this.OracleTab.Controls.Add(this.label2);
            this.OracleTab.Controls.Add(this.listBoxPortfolios);
            this.OracleTab.Location = new System.Drawing.Point(4, 22);
            this.OracleTab.Name = "OracleTab";
            this.OracleTab.Padding = new System.Windows.Forms.Padding(3);
            this.OracleTab.Size = new System.Drawing.Size(1101, 472);
            this.OracleTab.TabIndex = 0;
            this.OracleTab.Text = "Oracle";
            this.OracleTab.UseVisualStyleBackColor = true;
            // 
            // MongoDBTab
            // 
            this.MongoDBTab.Controls.Add(this.listBoxArtistsMongo);
            this.MongoDBTab.Controls.Add(this.buttonAddProjectMongo);
            this.MongoDBTab.Controls.Add(this.textBoxSearchMongo);
            this.MongoDBTab.Controls.Add(this.textBoxProjDescMongo);
            this.MongoDBTab.Controls.Add(this.buttonSearchMongo);
            this.MongoDBTab.Controls.Add(this.listBoxProjectsMongo);
            this.MongoDBTab.Controls.Add(this.textBoxPortDescMongo);
            this.MongoDBTab.Controls.Add(this.label1);
            this.MongoDBTab.Controls.Add(this.listBoxPortfoliosMongo);
            this.MongoDBTab.Location = new System.Drawing.Point(4, 22);
            this.MongoDBTab.Name = "MongoDBTab";
            this.MongoDBTab.Padding = new System.Windows.Forms.Padding(3);
            this.MongoDBTab.Size = new System.Drawing.Size(1101, 472);
            this.MongoDBTab.TabIndex = 1;
            this.MongoDBTab.Text = "MongoDB";
            this.MongoDBTab.UseVisualStyleBackColor = true;
            // 
            // listBoxArtistsMongo
            // 
            this.listBoxArtistsMongo.FormattingEnabled = true;
            this.listBoxArtistsMongo.Location = new System.Drawing.Point(98, 34);
            this.listBoxArtistsMongo.Name = "listBoxArtistsMongo";
            this.listBoxArtistsMongo.Size = new System.Drawing.Size(244, 407);
            this.listBoxArtistsMongo.TabIndex = 13;
            this.listBoxArtistsMongo.SelectedIndexChanged += new System.EventHandler(this.listBoxArtistsMongo_SelectedIndexChanged);
            // 
            // buttonAddProjectMongo
            // 
            this.buttonAddProjectMongo.Location = new System.Drawing.Point(1012, 446);
            this.buttonAddProjectMongo.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddProjectMongo.Name = "buttonAddProjectMongo";
            this.buttonAddProjectMongo.Size = new System.Drawing.Size(86, 24);
            this.buttonAddProjectMongo.TabIndex = 18;
            this.buttonAddProjectMongo.Text = "&Add Project...";
            this.buttonAddProjectMongo.UseVisualStyleBackColor = true;
            this.buttonAddProjectMongo.Click += new System.EventHandler(this.buttonAddProjectMongo_Click);
            // 
            // textBoxSearchMongo
            // 
            this.textBoxSearchMongo.Location = new System.Drawing.Point(98, 8);
            this.textBoxSearchMongo.Name = "textBoxSearchMongo";
            this.textBoxSearchMongo.Size = new System.Drawing.Size(244, 20);
            this.textBoxSearchMongo.TabIndex = 11;
            // 
            // textBoxProjDescMongo
            // 
            this.textBoxProjDescMongo.Location = new System.Drawing.Point(780, 323);
            this.textBoxProjDescMongo.Multiline = true;
            this.textBoxProjDescMongo.Name = "textBoxProjDescMongo";
            this.textBoxProjDescMongo.ReadOnly = true;
            this.textBoxProjDescMongo.Size = new System.Drawing.Size(318, 118);
            this.textBoxProjDescMongo.TabIndex = 17;
            // 
            // buttonSearchMongo
            // 
            this.buttonSearchMongo.Location = new System.Drawing.Point(348, 6);
            this.buttonSearchMongo.Name = "buttonSearchMongo";
            this.buttonSearchMongo.Size = new System.Drawing.Size(75, 23);
            this.buttonSearchMongo.TabIndex = 10;
            this.buttonSearchMongo.Text = "&Search...";
            this.buttonSearchMongo.UseVisualStyleBackColor = true;
            this.buttonSearchMongo.Click += new System.EventHandler(this.buttonSearchMongo_Click);
            // 
            // listBoxProjectsMongo
            // 
            this.listBoxProjectsMongo.FormattingEnabled = true;
            this.listBoxProjectsMongo.Location = new System.Drawing.Point(780, 34);
            this.listBoxProjectsMongo.Name = "listBoxProjectsMongo";
            this.listBoxProjectsMongo.Size = new System.Drawing.Size(318, 277);
            this.listBoxProjectsMongo.TabIndex = 15;
            this.listBoxProjectsMongo.SelectedIndexChanged += new System.EventHandler(this.listBoxProjectsMongo_SelectedIndexChanged);
            // 
            // textBoxPortDescMongo
            // 
            this.textBoxPortDescMongo.Location = new System.Drawing.Point(456, 323);
            this.textBoxPortDescMongo.Multiline = true;
            this.textBoxPortDescMongo.Name = "textBoxPortDescMongo";
            this.textBoxPortDescMongo.ReadOnly = true;
            this.textBoxPortDescMongo.Size = new System.Drawing.Size(318, 118);
            this.textBoxPortDescMongo.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Search for user:";
            // 
            // listBoxPortfoliosMongo
            // 
            this.listBoxPortfoliosMongo.FormattingEnabled = true;
            this.listBoxPortfoliosMongo.Location = new System.Drawing.Point(456, 34);
            this.listBoxPortfoliosMongo.Name = "listBoxPortfoliosMongo";
            this.listBoxPortfoliosMongo.Size = new System.Drawing.Size(318, 277);
            this.listBoxPortfoliosMongo.TabIndex = 14;
            this.listBoxPortfoliosMongo.SelectedIndexChanged += new System.EventHandler(this.listBoxPortfoliosMongo_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 522);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.OracleTab.ResumeLayout(false);
            this.OracleTab.PerformLayout();
            this.MongoDBTab.ResumeLayout(false);
            this.MongoDBTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxUserSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.ListBox listBoxPortfolios;
        private System.Windows.Forms.ListBox listBoxProjects;
        private System.Windows.Forms.TextBox textBoxPortfolioDesc;
        private System.Windows.Forms.TextBox textBoxProjectDesc;
        private System.Windows.Forms.Button buttonAddProject;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage OracleTab;
        private System.Windows.Forms.TabPage MongoDBTab;
        private System.Windows.Forms.ListBox listBoxArtistsMongo;
        private System.Windows.Forms.Button buttonAddProjectMongo;
        private System.Windows.Forms.TextBox textBoxSearchMongo;
        private System.Windows.Forms.TextBox textBoxProjDescMongo;
        private System.Windows.Forms.Button buttonSearchMongo;
        private System.Windows.Forms.ListBox listBoxProjectsMongo;
        private System.Windows.Forms.TextBox textBoxPortDescMongo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxPortfoliosMongo;
    }
}

