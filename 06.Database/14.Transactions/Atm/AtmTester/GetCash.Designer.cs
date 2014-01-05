namespace AtmTester
{
    partial class GetCash
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbCardNumber = new System.Windows.Forms.TextBox();
            this.tbWantedCash = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btGetCash = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAvailableCash = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Номер на сметка";
            // 
            // tbCardNumber
            // 
            this.tbCardNumber.Location = new System.Drawing.Point(114, 19);
            this.tbCardNumber.Name = "tbCardNumber";
            this.tbCardNumber.Size = new System.Drawing.Size(100, 20);
            this.tbCardNumber.TabIndex = 3;
            // 
            // tbWantedCash
            // 
            this.tbWantedCash.Location = new System.Drawing.Point(114, 79);
            this.tbWantedCash.Name = "tbWantedCash";
            this.tbWantedCash.Size = new System.Drawing.Size(100, 20);
            this.tbWantedCash.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Сума за изтегляне";
            // 
            // btGetCash
            // 
            this.btGetCash.Location = new System.Drawing.Point(77, 112);
            this.btGetCash.Name = "btGetCash";
            this.btGetCash.Size = new System.Drawing.Size(75, 23);
            this.btGetCash.TabIndex = 5;
            this.btGetCash.Text = "Изтегли";
            this.btGetCash.UseVisualStyleBackColor = true;
            this.btGetCash.Click += new System.EventHandler(this.BtGetCash_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Налична сума";
            // 
            // lblAvailableCash
            // 
            this.lblAvailableCash.AutoSize = true;
            this.lblAvailableCash.Location = new System.Drawing.Point(117, 52);
            this.lblAvailableCash.Name = "lblAvailableCash";
            this.lblAvailableCash.Size = new System.Drawing.Size(0, 13);
            this.lblAvailableCash.TabIndex = 7;
            // 
            // getCash
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 147);
            this.Controls.Add(this.lblAvailableCash);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btGetCash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbWantedCash);
            this.Controls.Add(this.tbCardNumber);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "getCash";
            this.Text = "Изтегляне на средства";
            this.Load += new System.EventHandler(this.GetCash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCardNumber;
        private System.Windows.Forms.TextBox tbWantedCash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGetCash;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAvailableCash;
    }
}