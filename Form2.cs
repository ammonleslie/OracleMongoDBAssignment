using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _323milestone2
{
    public partial class AddProjectForm : Form
    {
        private string selectedUser;
        private string selectedPortfolio;
        private bool isOracle;

        string oradb = "Data Source=oracle.cms.waikato.ac.nz:1521/teaching;User Id=COMPX323_22;Password=NCfDzZYMN7;";
        OracleConnection conn;

        public AddProjectForm()
        {
            InitializeComponent();

        }

        public AddProjectForm(string selectedUser, string selectedPortfolio, bool isOracle)
        {
            InitializeComponent();

            this.selectedUser = selectedUser;
            this.selectedPortfolio = selectedPortfolio;
            this.isOracle = isOracle;

            labelUserInfo.Text = "for " + selectedUser + " in " + selectedPortfolio;

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (isOracle)
            {
                string name = textBoxName.Text;
                string desc = textBoxDesc.Text;
                int intIsPublic;

                if (checkBoxIsPublic.Checked)
                {
                    intIsPublic = 1;
                }
                else
                {
                    intIsPublic = 0;
                }

                try
                {
                    conn = new OracleConnection(oradb);
                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Project VALUES('" + name + "', '" + selectedPortfolio + "', '" + selectedUser + "', '" + desc + "', :datePara, " + intIsPublic + ")";
                    cmd.Parameters.Add(new OracleParameter("datePara", OracleDbType.Date));
                    cmd.Parameters[0].Value = DateTime.Now;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                    conn.Dispose();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    if (name.Length > 255 || desc.Length > 255)
                    {
                        MessageBox.Show("Please ensure your name and description are both less than 256 characters long.");
                    }

                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            else
            {
                // TODO: IMPLEMENT MONGO INSERT HERE
            }
        }
    }
}
