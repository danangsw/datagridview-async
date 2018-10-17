namespace ThreadSafeCall
{
    partial class FormThreadSafeCall
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
            this.btnUnsafeCall = new System.Windows.Forms.Button();
            this.lblUnsafeCall = new System.Windows.Forms.Label();
            this.btnSafeCall = new System.Windows.Forms.Button();
            this.lblSafeCall = new System.Windows.Forms.Label();
            this.btnSafeCallBackgroundWorker = new System.Windows.Forms.Button();
            this.lblSafeCallBackgroundWorker = new System.Windows.Forms.Label();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lblSafeCall2 = new System.Windows.Forms.Label();
            this.lblSafeCall3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUnsafeCall
            // 
            this.btnUnsafeCall.Location = new System.Drawing.Point(12, 12);
            this.btnUnsafeCall.Name = "btnUnsafeCall";
            this.btnUnsafeCall.Size = new System.Drawing.Size(75, 23);
            this.btnUnsafeCall.TabIndex = 0;
            this.btnUnsafeCall.Text = "Unsafe call";
            this.btnUnsafeCall.UseVisualStyleBackColor = true;
            this.btnUnsafeCall.Click += new System.EventHandler(this.btnUnsafeCall_Click);
            // 
            // lblUnsafeCall
            // 
            this.lblUnsafeCall.AutoSize = true;
            this.lblUnsafeCall.Location = new System.Drawing.Point(130, 17);
            this.lblUnsafeCall.Name = "lblUnsafeCall";
            this.lblUnsafeCall.Size = new System.Drawing.Size(10, 13);
            this.lblUnsafeCall.TabIndex = 1;
            this.lblUnsafeCall.Text = "-";
            // 
            // btnSafeCall
            // 
            this.btnSafeCall.Location = new System.Drawing.Point(13, 52);
            this.btnSafeCall.Name = "btnSafeCall";
            this.btnSafeCall.Size = new System.Drawing.Size(75, 23);
            this.btnSafeCall.TabIndex = 2;
            this.btnSafeCall.Text = "Safe call";
            this.btnSafeCall.UseVisualStyleBackColor = true;
            this.btnSafeCall.Click += new System.EventHandler(this.btnSafeCall_Click);
            // 
            // lblSafeCall
            // 
            this.lblSafeCall.AutoSize = true;
            this.lblSafeCall.Location = new System.Drawing.Point(331, 81);
            this.lblSafeCall.Name = "lblSafeCall";
            this.lblSafeCall.Size = new System.Drawing.Size(10, 13);
            this.lblSafeCall.TabIndex = 3;
            this.lblSafeCall.Text = "-";
            // 
            // btnSafeCallBackgroundWorker
            // 
            this.btnSafeCallBackgroundWorker.Location = new System.Drawing.Point(13, 102);
            this.btnSafeCallBackgroundWorker.Name = "btnSafeCallBackgroundWorker";
            this.btnSafeCallBackgroundWorker.Size = new System.Drawing.Size(165, 23);
            this.btnSafeCallBackgroundWorker.TabIndex = 4;
            this.btnSafeCallBackgroundWorker.Text = "Safe call BackgroundWorker";
            this.btnSafeCallBackgroundWorker.UseVisualStyleBackColor = true;
            this.btnSafeCallBackgroundWorker.Click += new System.EventHandler(this.btnSafeCallBackgroundWorker_Click);
            // 
            // lblSafeCallBackgroundWorker
            // 
            this.lblSafeCallBackgroundWorker.AutoSize = true;
            this.lblSafeCallBackgroundWorker.Location = new System.Drawing.Point(219, 107);
            this.lblSafeCallBackgroundWorker.Name = "lblSafeCallBackgroundWorker";
            this.lblSafeCallBackgroundWorker.Size = new System.Drawing.Size(10, 13);
            this.lblSafeCallBackgroundWorker.TabIndex = 5;
            this.lblSafeCallBackgroundWorker.Text = "-";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // lblSafeCall2
            // 
            this.lblSafeCall2.AutoSize = true;
            this.lblSafeCall2.Location = new System.Drawing.Point(331, 57);
            this.lblSafeCall2.Name = "lblSafeCall2";
            this.lblSafeCall2.Size = new System.Drawing.Size(10, 13);
            this.lblSafeCall2.TabIndex = 6;
            this.lblSafeCall2.Text = "-";
            // 
            // lblSafeCall3
            // 
            this.lblSafeCall3.AutoSize = true;
            this.lblSafeCall3.Location = new System.Drawing.Point(130, 57);
            this.lblSafeCall3.Name = "lblSafeCall3";
            this.lblSafeCall3.Size = new System.Drawing.Size(10, 13);
            this.lblSafeCall3.TabIndex = 7;
            this.lblSafeCall3.Text = "-";
            // 
            // FormThreadSafeCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 137);
            this.Controls.Add(this.lblSafeCall3);
            this.Controls.Add(this.lblSafeCall2);
            this.Controls.Add(this.lblSafeCallBackgroundWorker);
            this.Controls.Add(this.btnSafeCallBackgroundWorker);
            this.Controls.Add(this.lblSafeCall);
            this.Controls.Add(this.btnSafeCall);
            this.Controls.Add(this.lblUnsafeCall);
            this.Controls.Add(this.btnUnsafeCall);
            this.Name = "FormThreadSafeCall";
            this.Text = "Form Thread Safe Calls";
            this.Load += new System.EventHandler(this.FormThreadSafeCall_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUnsafeCall;
        private System.Windows.Forms.Label lblUnsafeCall;
        private System.Windows.Forms.Button btnSafeCall;
        private System.Windows.Forms.Label lblSafeCall;
        private System.Windows.Forms.Button btnSafeCallBackgroundWorker;
        private System.Windows.Forms.Label lblSafeCallBackgroundWorker;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label lblSafeCall2;
        private System.Windows.Forms.Label lblSafeCall3;
    }
}

