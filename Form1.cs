using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _323milestone2
{
    public partial class Form1 : Form
    {
        string oradb = "Data Source=oracle.cms.waikato.ac.nz:1521/teaching;User Id=COMPX323_22;Password=NCfDzZYMN7;";
        MongoClient dbClient;
        IMongoDatabase db;
        OracleConnection conn;

        IMongoCollection<BsonDocument> artistColl;
        IMongoCollection<BsonDocument> portColl;
        IMongoCollection<BsonDocument> projColl;

        string selectedUser, selectedPortfolio, selectedProject;
        string userID, portID, projID;

        public Form1()
        {
            InitializeComponent();

            dbClient = new MongoClient("mongodb://compx323-29:Ls2RqdwR-w@mongodb.cms.waikato.ac.nz:27017");

            db = dbClient.GetDatabase("compx323-29");
            var collList = db.ListCollections().ToList();

            artistColl = db.GetCollection<BsonDocument>("Artist");
            portColl = db.GetCollection<BsonDocument>("Portfolio");
            projColl = db.GetCollection<BsonDocument>("Project");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxUsers.Items.Clear();
                listBoxPortfolios.Items.Clear();
                listBoxProjects.Items.Clear();

                textBoxPortfolioDesc.Clear();
                textBoxProjectDesc.Clear();

                string input = textBoxUserSearch.Text;

                conn = new OracleConnection(oradb);  // C#
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT username FROM Artist WHERE LOWER(username) LIKE LOWER('%" + input + "%') AND username IN(SELECT username FROM Portfolio WHERE isPublic = 1) ORDER BY username ASC";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listBoxUsers.Items.Add(dr.GetString(0));
                } 

                conn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBoxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxProjectDesc.Clear();

            selectedProject = (string)listBoxProjects.SelectedItem;

            conn = new OracleConnection(oradb);  // C#
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT description FROM Project WHERE projectName = '"+selectedProject+"' AND portfolioName = '" + selectedPortfolio + "' AND username = '" + selectedUser + "'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
                textBoxProjectDesc.Text = dr.GetString(0);

            conn.Dispose();
        }

        private void buttonAddProject_Click(object sender, EventArgs e)
        {
            if (selectedUser != null && selectedPortfolio != null)
            {
                Form addForm = new AddProjectForm(selectedUser, selectedPortfolio, true);

                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Project successfully added!");

                    listBoxProjects.Items.Clear();
                    textBoxProjectDesc.Clear();

                    conn = new OracleConnection(oradb);  // C#
                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT * FROM Project WHERE portfolioName = '" + selectedPortfolio + "' AND username = '" + selectedUser + "'";
                    cmd.CommandType = CommandType.Text;
                    OracleDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        listBoxProjects.Items.Add(dr.GetString(0));
                    }

                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT description FROM Portfolio WHERE portfolioName = '" + selectedPortfolio + "' AND username = '" + selectedUser + "'";
                    cmd.CommandType = CommandType.Text;

                    dr = cmd.ExecuteReader();

                    dr.Read();

                    textBoxPortfolioDesc.Text = dr.GetString(0);

                    conn.Dispose();
                }
            }
            else
            {
                MessageBox.Show("Please select a user and portfolio to add a project to.");


            }
        }

        private void buttonSearchMongo_Click(object sender, EventArgs e)
        {
            listBoxArtistsMongo.Items.Clear();
            listBoxPortfoliosMongo.Items.Clear();
            listBoxProjectsMongo.Items.Clear();

            List<BsonDocument> result = artistColl.Find(new BsonDocument()).ToList();

            string regexString = textBoxSearchMongo.Text;

            foreach (BsonDocument item in result)
            {
                if (Regex.IsMatch(item.GetValue("username").ToString(), regexString, RegexOptions.IgnoreCase))
                {
                    listBoxArtistsMongo.Items.Add(item.GetValue("username"));
                }
            }
        }

        private void listBoxArtistsMongo_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxPortfoliosMongo.Items.Clear();
            listBoxProjectsMongo.Items.Clear();

            textBoxProjDescMongo.Clear();
            textBoxPortDescMongo.Clear();

            if (listBoxArtistsMongo.SelectedItem != null)
            {
                selectedUser = listBoxArtistsMongo.SelectedItem.ToString();

                string[] portfolioArray = null;

                

                List<BsonDocument> result = artistColl.Find(new BsonDocument()).ToList();

                foreach (BsonDocument item in result)
                {
                    if (item.GetValue("username").ToString() == selectedUser)
                    {
                        userID = item.GetValue("_id").ToString();
                        portfolioArray = item.GetValue("Portfolio").ToString().Replace("[", string.Empty).Replace("]", string.Empty).Replace(" ", string.Empty).Split(',');
                    }
                }

                result = portColl.Find(new BsonDocument()).ToList();

                foreach (BsonDocument item in result)
                {
                    if (portfolioArray.Contains(item.GetValue("_id").ToString()))
                    {
                        listBoxPortfoliosMongo.Items.Add(item.GetValue("portfolioName"));
                    }

                }
            }
        }

        private void listBoxProjectsMongo_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxProjDescMongo.Clear();

            if (listBoxProjectsMongo.SelectedItem != null)
            {
                selectedProject = listBoxProjectsMongo.SelectedItem.ToString();

                string[] portfolioArray = null;
                string[] projArray = null;



                List<BsonDocument> result = artistColl.Find(new BsonDocument()).ToList();

                // Find selected artist
                foreach (BsonDocument artist in result)
                {
                    if (artist.GetValue("username").ToString() == selectedUser)
                    {
                        portfolioArray = artist.GetValue("Portfolio").ToString().Replace("[", string.Empty).Replace("]", string.Empty).Replace(" ", string.Empty).Split(',');

                        // Find selected portfolio
                        foreach (string id in portfolioArray)
                        {
                            List<BsonDocument> portList = portColl.Find(new BsonDocument()).ToList();

                            foreach (BsonDocument port in portList)
                            {
                                // found portfolio
                                if (port.GetValue("_id").ToString() == id && port.GetValue("portfolioName").ToString() == selectedPortfolio)
                                {
                                    projArray = port.GetValue("Project").ToString().Replace("[", string.Empty).Replace("]", string.Empty).Replace(" ", string.Empty).Split(',');

                                    foreach (string projID in projArray)
                                    {
                                        List<BsonDocument> projList = projColl.Find(new BsonDocument()).ToList();

                                        foreach (BsonDocument proj in projList)
                                        {
                                            if (proj.GetValue("_id").ToString() == projID && proj.GetValue("projectName").ToString() == selectedProject)
                                            {
                                                textBoxProjDescMongo.Text = proj.GetValue("description").ToString();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void buttonAddProjectMongo_Click(object sender, EventArgs e)
        {
            if (selectedUser != null && selectedPortfolio != null)
            {
                Form addForm = new AddProjectForm(selectedUser, selectedPortfolio, false);

                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Project successfully added!");

                    // TODO: REFRESH THE PROJECTS LIST
                }
            }
            else
            {
                MessageBox.Show("Please select a user and portfolio to add a project to.");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedUser = null;
            selectedPortfolio = null;
            selectedProject = null;

            userID = null;
            portID = null;
            projID = null;

            foreach (TabPage t in tabControl1.TabPages)
            {
                foreach (Control c in t.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                    else if (c is ListBox)
                    {
                        ListBox l = (ListBox)c;
                        l.Items.Clear();
                    }
                }
            }
        }

        private void listBoxPortfoliosMongo_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxProjectsMongo.Items.Clear();
            textBoxPortDescMongo.Clear();

            if (listBoxPortfoliosMongo.SelectedItem != null)
            {
                selectedPortfolio = listBoxPortfoliosMongo.SelectedItem.ToString();

                string[] portfolioArray = null;
                string[] projArray = null;
                


                List<BsonDocument> result = artistColl.Find(new BsonDocument()).ToList();

                // Find selected artist
                foreach (BsonDocument artist in result)
                {
                    if (artist.GetValue("username").ToString() == selectedUser)
                    {
                        portfolioArray = artist.GetValue("Portfolio").ToString().Replace("[", string.Empty).Replace("]", string.Empty).Replace(" ", string.Empty).Split(',');

                        // Find selected portfolio
                        foreach (string id in portfolioArray)
                        {
                            List<BsonDocument> portList = portColl.Find(new BsonDocument()).ToList();

                            foreach (BsonDocument port in portList)
                            {
                                // found portfolio
                                if (port.GetValue("_id").ToString() == id && port.GetValue("portfolioName").ToString() == selectedPortfolio)
                                {
                                    portID = port.GetValue("_id").ToString();
                                    projArray = port.GetValue("Project").ToString().Replace("[", string.Empty).Replace("]", string.Empty).Replace(" ", string.Empty).Split(',');

                                    textBoxPortDescMongo.Text = port.GetValue("description").ToString();
                                }
                            }
                        }
                    }
                }

                result = projColl.Find(new BsonDocument()).ToList();

                // populate projects
                foreach (BsonDocument item in result)
                {
                    if (projArray.Contains(item.GetValue("_id").ToString()))
                    {
                        listBoxProjectsMongo.Items.Add(item.GetValue("projectName"));
                    }

                }
            }
        }



        private void listBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxPortfolios.Items.Clear();
            listBoxProjects.Items.Clear();

            textBoxPortfolioDesc.Clear();
            textBoxProjectDesc.Clear();

            selectedUser = (string)listBoxUsers.SelectedItem;

            conn = new OracleConnection(oradb);  // C#
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT portfolioName FROM Portfolio WHERE username = '"+ selectedUser + "'";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                listBoxPortfolios.Items.Add(dr.GetString(0));
            }

            conn.Dispose();
        }

        private void listBoxPortfolios_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxProjects.Items.Clear();

            textBoxPortfolioDesc.Clear();
            textBoxProjectDesc.Clear();

            selectedPortfolio = (string)listBoxPortfolios.SelectedItem;

            if (selectedPortfolio != null)
            {

                conn = new OracleConnection(oradb);  // C#
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Project WHERE portfolioName = '" + selectedPortfolio + "' AND username = '" + selectedUser + "'";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listBoxProjects.Items.Add(dr.GetString(0));
                }

                cmd.Connection = conn;
                cmd.CommandText = "SELECT description FROM Portfolio WHERE portfolioName = '" + selectedPortfolio + "' AND username = '" + selectedUser + "'";
                cmd.CommandType = CommandType.Text;

                dr = cmd.ExecuteReader();

                dr.Read();

                textBoxPortfolioDesc.Text = dr.GetString(0);

                conn.Dispose();
            }
        }
    }
}
