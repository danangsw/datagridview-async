namespace LoadAsync.Presentation
{
    partial class LoadDataGridViewAsync
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.dgvAsync = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.pbLoad = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chbClear = new System.Windows.Forms.CheckBox();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsync)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.chbClear);
            this.pnlContainer.Controls.Add(this.btnCancel);
            this.pnlContainer.Controls.Add(this.pbLoad);
            this.pnlContainer.Controls.Add(this.btnLoad);
            this.pnlContainer.Controls.Add(this.dgvAsync);
            this.pnlContainer.Location = new System.Drawing.Point(12, 12);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(776, 426);
            this.pnlContainer.TabIndex = 0;
            // 
            // dgvAsync
            // 
            this.dgvAsync.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsync.Location = new System.Drawing.Point(0, 3);
            this.dgvAsync.Name = "dgvAsync";
            this.dgvAsync.Size = new System.Drawing.Size(776, 363);
            this.dgvAsync.TabIndex = 0;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(17, 385);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // pbLoad
            // 
            this.pbLoad.Location = new System.Drawing.Point(114, 385);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(357, 23);
            this.pbLoad.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(566, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chbClear
            // 
            this.chbClear.AutoSize = true;
            this.chbClear.Location = new System.Drawing.Point(662, 389);
            this.chbClear.Name = "chbClear";
            this.chbClear.Size = new System.Drawing.Size(88, 17);
            this.chbClear.TabIndex = 4;
            this.chbClear.Text = "Clear records";
            this.chbClear.UseVisualStyleBackColor = true;
            // 
            // LoadDataGridViewAsync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContainer);
            this.Name = "LoadDataGridViewAsync";
            this.Text = "Load DataGridView Async";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsync)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar pbLoad;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvAsync;
        private System.Windows.Forms.CheckBox chbClear;
    }
}

