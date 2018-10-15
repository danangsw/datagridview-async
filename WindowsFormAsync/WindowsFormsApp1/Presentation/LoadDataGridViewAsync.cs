using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Classes;
using WindowsFormsApp1.Data;

namespace LoadAsync.Presentation
{
    public partial class LoadDataGridViewAsync : Form
    {
        private bool InstanceFieldsInitialized = false;

        private void InitializeInstanceFields()
        {
            token = tokenSource.Token;
        }

        private DataTable dt = new DataTable { TableName = "MyGridView" };
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private CancellationToken token;
        private bool CurrentlyRunning = false;

        public delegate void UpdateDataTableDelegateProgress(int CurrentPosition, int Total, PersonViewModel[] person);

        public LoadDataGridViewAsync()
        {
            if (!InstanceFieldsInitialized)
            {
                InitializeInstanceFields();
                InstanceFieldsInitialized = true;
            }

            InitializeComponent();

            this.dgvAsync.DataSource = dt;
            this.FormClosing += LoadDataGridViewAsync_FormClosing;
        }

        public void UpDateDataTable(int CurrentPosition, int Total, PersonViewModel[] person)
        {
            PersonViewModel p;

            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateDataTableDelegateProgress(UpDateDataTable), CurrentPosition, Total, person);
            }
            else
            {
                if (dt.Columns.Count > 0)
                {
                    p = (PersonViewModel)person.FirstOrDefault();
                    dt.Rows.Add(new object[] { p.Identifier, p.FirstName, p.LastName });
                    pbLoad.Value = CurrentPosition;
                    if (CurrentPosition == Total)
                    {
                        MessageBox.Show("Finished loading data");
                    }
                }
            }
        }

        private void LoadDataGridViewAsync_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentlyRunning == true)
            {
                if (!token.IsCancellationRequested)
                {
                    tokenSource.Cancel();
                }
            }
        }

        private void LoadDataGridViewAsync_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(new DataColumn { ColumnName = "Identifier", DataType = typeof(Int32) });
            dt.Columns.Add(new DataColumn { ColumnName = "FirstName", DataType = typeof(string) });
            dt.Columns.Add(new DataColumn { ColumnName = "LastName", DataType = typeof(string) });
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            pbLoad.Visible = true;

            CurrentlyRunning = true;
            dgvAsync.DataSource = dt;
            AppDataAccess da = new AppDataAccess(this);

            pbLoad.Maximum = da.RowCount();

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

                if (chbClear.Checked)
                {
                    dt.Rows.Clear();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Cancel loading of data?", "Info", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                CurrentlyRunning = false;
                tokenSource.Cancel();
                pbLoad.Visible = false;
            }
        }
    }
}
