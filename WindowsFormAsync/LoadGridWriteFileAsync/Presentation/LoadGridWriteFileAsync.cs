using LoadGridWriteFileAsync.Classes;
using LoadGridWriteFileAsync.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadGridWriteFileAsync
{
    public partial class LoadGridWriteFileAsync : Form
    {
        private bool InstanceFieldsInitialized = false;
        private string _filename;
        private string _path;

        private void InitializeInstanceFields()
        {
            token = tokenSource.Token;
        }

        private DataTable dt = new DataTable { TableName = "MyGridView" };
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private CancellationToken token;
        private bool CurrentlyRunning = false;

        public delegate void UpdateDataTableDelegateProgress(int Total, PersonViewModel[] person);

        public LoadGridWriteFileAsync()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }

            InitializeComponent();

            lblDataGenerate.Text = String.Format("Generated {0} record/s", 0);
            this.dgvAsync.DataSource = dt;
            this.FormClosing += LoadGridWriteFileAsync_FormClosing;
        }

        public void UpDateDataTableDelegate(int Total, PersonViewModel[] person)
        {
            PersonViewModel p;

            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateDataTableDelegateProgress(UpDateDataTableDelegate), Total, person);
            }
            else
            {
                if (dt.Columns.Count > 0)
                {
                    p = (PersonViewModel)person.FirstOrDefault();
                    dt.Rows.Add(new object[] { p.Identifier, p.FirstName, p.LastName });

                    lblDataGenerate.Text = String.Format("Generated {0} record/s", Total);

                    // Append text to an existing file name path.
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(_path, _filename), true))
                    {
                        outputFile.WriteLine("{0},{1},{2}", p.Identifier, p.FirstName, p.LastName);
                    }
                }
            }
        }

        private void LoadGridWriteFileAsync_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentlyRunning == true)
            {
                if (!token.IsCancellationRequested)
                {
                    tokenSource.Cancel();
                }
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            if (!CurrentlyRunning)
            {
                dt.Rows.Clear();
                lblDataGenerate.Text = String.Format("Generated {0} record/s", 0);

                CurrentlyRunning = true;
                //dgvAsync.DataSource = dt;
                GenerateDataAccess da = new GenerateDataAccess(this);

                _filename = string.Format("{0}.csv", DateTime.Now.TimeOfDay.Ticks.ToString());
                _path = ConfigurationManager.AppSettings["GeneratedFolder"];
                if (!Directory.Exists(_path))
                    Directory.CreateDirectory(_path);
                File.Create(Path.Combine(_path, _filename)).Dispose();

                foreach (var item in da.LoadData(token))
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }

                    await Task.Factory.StartNew(() => System.Threading.Thread.Sleep(1), token);

                }

                if (token.IsCancellationRequested)
                {
                    tokenSource = new CancellationTokenSource();
                    token = tokenSource.Token;
                }
            }
            else {
                MessageBox.Show("Other process is running!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Cancel loading of data?", "Info", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                CurrentlyRunning = false;
                tokenSource.Cancel();
                lblDataGenerate.Text = String.Format("Generated {0} record/s", 0);
            }
        }

        private void LoadGridWriteFileAsync_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn { ColumnName = "Identifier", DataType = typeof(Int32) });
            dt.Columns.Add(new DataColumn { ColumnName = "FirstName", DataType = typeof(string) });
            dt.Columns.Add(new DataColumn { ColumnName = "LastName", DataType = typeof(string) });
        }
    }
}
