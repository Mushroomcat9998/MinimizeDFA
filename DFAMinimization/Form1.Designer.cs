namespace DFAMinimization
{
    partial class DFAMinimization
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
            this.pnl_MinimizedDFA = new System.Windows.Forms.Panel();
            this.btn_OpenDFAFile = new System.Windows.Forms.Button();
            this.btn_MinimizeOpenedDFA = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pnl_MinimizedDFA
            // 
            this.pnl_MinimizedDFA.Location = new System.Drawing.Point(12, 12);
            this.pnl_MinimizedDFA.Name = "pnl_MinimizedDFA";
            this.pnl_MinimizedDFA.Size = new System.Drawing.Size(839, 353);
            this.pnl_MinimizedDFA.TabIndex = 0;
            // 
            // btn_OpenDFAFile
            // 
            this.btn_OpenDFAFile.Location = new System.Drawing.Point(95, 406);
            this.btn_OpenDFAFile.Name = "btn_OpenDFAFile";
            this.btn_OpenDFAFile.Size = new System.Drawing.Size(149, 23);
            this.btn_OpenDFAFile.TabIndex = 1;
            this.btn_OpenDFAFile.Text = "Open DFA File";
            this.btn_OpenDFAFile.UseVisualStyleBackColor = true;
            this.btn_OpenDFAFile.Click += new System.EventHandler(this.btn_OpenDFAFile_Click);
            // 
            // btn_MinimizeOpenedDFA
            // 
            this.btn_MinimizeOpenedDFA.Location = new System.Drawing.Point(371, 406);
            this.btn_MinimizeOpenedDFA.Name = "btn_MinimizeOpenedDFA";
            this.btn_MinimizeOpenedDFA.Size = new System.Drawing.Size(149, 23);
            this.btn_MinimizeOpenedDFA.TabIndex = 2;
            this.btn_MinimizeOpenedDFA.Text = "Minimize Opened DFA";
            this.btn_MinimizeOpenedDFA.UseVisualStyleBackColor = true;
            this.btn_MinimizeOpenedDFA.Click += new System.EventHandler(this.btn_MinimizeOpenedDFA_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(629, 406);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(149, 23);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.Text = "Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // DFAMinimization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 479);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_MinimizeOpenedDFA);
            this.Controls.Add(this.btn_OpenDFAFile);
            this.Controls.Add(this.pnl_MinimizedDFA);
            this.Name = "DFAMinimization";
            this.Text = "DFA Minimization";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_MinimizedDFA;
        private System.Windows.Forms.Button btn_OpenDFAFile;
        private System.Windows.Forms.Button btn_MinimizeOpenedDFA;
        private System.Windows.Forms.Button btn_Exit;
    }
}

