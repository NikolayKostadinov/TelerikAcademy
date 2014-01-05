namespace AtmTester
{
    partial class EnterPinCode
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
            this.tbPinCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbPinCode
            // 
            this.tbPinCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPinCode.Location = new System.Drawing.Point(55, 12);
            this.tbPinCode.Name = "tbPinCode";
            this.tbPinCode.PasswordChar = '*';
            this.tbPinCode.Size = new System.Drawing.Size(43, 26);
            this.tbPinCode.TabIndex = 0;
            this.tbPinCode.KeyPress += tbPinCode_KeyPress;
            // 
            // EnterPinCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 60);
            this.Controls.Add(this.tbPinCode);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterPinCode";
            this.Text = "Въведете PIN код";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPinCode;
    }
}