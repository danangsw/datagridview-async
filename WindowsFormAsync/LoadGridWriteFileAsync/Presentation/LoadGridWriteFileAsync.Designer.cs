namespace LoadGridWriteFileAsync
{
    partial class LoadGridWriteFileAsync
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDataGenerate = new System.Windows.Forms.Label();
            this.dgvAsync = new System.Windows.Forms.DataGridView();
            this.pnlContainer = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsync)).BeginInit();
            this.pnlContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(17, 385);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(680, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblDataGenerate
            // 
            this.lblDataGenerate.AutoSize = true;
            this.lblDataGenerate.Location = new System.Drawing.Point(109, 390);
            this.lblDataGenerate.Name = "lblDataGenerate";
            this.lblDataGenerate.Size = new System.Drawing.Size(117, 13);
            this.lblDataGenerate.TabIndex = 5;
            this.lblDataGenerate.Text = "Generated {0} record/s";
            // 
            // dgvAsync
            // 
            this.dgvAsync.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsync.Location = new System.Drawing.Point(0, 0);
            this.dgvAsync.Name = "dgvAsync";
            this.dgvAsync.Size = new System.Drawing.Size(776, 368);
            this.dgvAsync.TabIndex = 6;
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.dgvAsync);
            this.pnlContainer.Controls.Add(this.lblDataGenerate);
            this.pnlContainer.Controls.Add(this.btnCancel);
            this.pnlContainer.Controls.Add(this.btnLoad);
            this.pnlContainer.Location = new System.Drawing.Point(11, 13);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(776, 426);
            this.pnlContainer.TabIndex = 1;
            // 
            // LoadGridWriteFileAsync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 487);
            this.Controls.Add(this.pnlContainer);
            this.Name = "LoadGridWriteFileAsync";
            this.Text = "Load Grid Write File Async";
            this.Load += new System.EventHandler(this.LoadGridWriteFileAsync_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsync)).EndInit();
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDataGenerate;
        private System.Windows.Forms.DataGridView dgvAsync;
        private System.Windows.Forms.Panel pnlContainer;
    }
}

