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

namespace ThreadSafeCall
{
    public partial class FormThreadSafeCall : Form
    {
        // This thread is used to demonstrate both thread-safe and
        // unsafe ways to call a Windows Forms control.
        private Thread demoThread = null;

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void StringArgReturningVoidDelegate(string text);

        public FormThreadSafeCall()
        {
            InitializeComponent();
        }

        private void btnUnsafeCall_Click(object sender, EventArgs e)
        {
            try
            {
                this.demoThread = new Thread(new ThreadStart(this.ThreadProcUnsafe));
                this.demoThread.Start();
            }
            catch (Exception ex)
            {
                lblUnsafeCall.Text = ex.Message;
            }
        }

        private async void btnSafeCall_Click(object sender, EventArgs e)
        {
            btnSafeCall.Enabled = false;
   
            this.demoThread = new Thread(new ThreadStart(this.ThreadProcSafe));
            this.demoThread.Start();

            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();

            // Start a task - this runs on the background thread...
            Task<long> task1 = Task<long>.Factory.StartNew(() =>
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    for (int i = 1; i < 1000; i++)
                    {
                        Thread.Sleep(5);
                        Task.Factory.StartNew(() =>
                        {
                            lblSafeCall.Text = "Delay " + i.ToString() + " has completed";
                        }, CancellationToken.None, TaskCreationOptions.None, uiContext);
                    }

                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;

                    Task.Factory.StartNew(() =>
                    {
                        lblSafeCall.Text = "Elapsed: " + elapsedMs + " ms";
                    }, CancellationToken.None, TaskCreationOptions.None, uiContext);

                    return elapsedMs;
                });

            Task<long> task2 = Task<long>.Factory.StartNew(() =>
                {
                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    for (int i = 1; i < 500; i++)
                    {
                        Thread.Sleep(5);
                        Task.Factory.StartNew(() =>
                        {
                            lblSafeCall2.Text = "Delay " + i.ToString() + " has completed";
                        }, CancellationToken.None, TaskCreationOptions.None, uiContext);
                    }

                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;

                    Task.Factory.StartNew(() =>
                    {
                        lblSafeCall2.Text = "Elapsed: " + elapsedMs+ " ms";
                    }, CancellationToken.None, TaskCreationOptions.None, uiContext);

                    return elapsedMs;
                });

            await Task.WhenAll(task2, task1);

            //lblSafeCall.Text = task1.Result + " ms";
            //lblSafeCall2.Text = task2.Result + " ms";

            btnSafeCall.Enabled = true;
        }

        private void ThreadProcUnsafe()
        {
            this.lblUnsafeCall.Text = "This text was set unsafely.";
        }

        private void ThreadProcSafe()
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(10);
                this.SetText(String.Format("This text was set safely {0} %", i));
            }
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblSafeCall.InvokeRequired) {
                StringArgReturningVoidDelegate del = new StringArgReturningVoidDelegate(SetText);
                this.Invoke(del, text);
            }
            else
            {
                lblSafeCall3.Text = text;
            }
        }

        private void btnSafeCallBackgroundWorker_Click(object sender, EventArgs e)
        {
            this.backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lblSafeCallBackgroundWorker.Text = "This text was set safely by BackgroundWorker.";
        }

        private void FormThreadSafeCall_Load(object sender, EventArgs e)
        {

        }
    }
}
