namespace AtmTester
{
    partial class ReportForAvailableCash
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
            this.tbBalance = new System.Windows.Forms.TextBox();
            this.tbCardNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCardCash = new System.Windows.Forms.Button();
            this.btnGetCash = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbBalance
            // 
            this.tbBalance.Enabled = false;
            this.tbBalance.Location = new System.Drawing.Point(134, 71);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.Size = new System.Drawing.Size(100, 20);
            this.tbBalance.TabIndex = 0;
            // 
            // tbCardNumber
            // 
            this.tbCardNumber.Location = new System.Drawing.Point(134, 27);
            this.tbCardNumber.Name = "tbCardNumber";
            this.tbCardNumber.Size = new System.Drawing.Size(100, 20);
            this.tbCardNumber.TabIndex = 1;
            this.tbCardNumber.Validating += tbCardNumber_Validating;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Номер на сметка";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Наличност по сметка";
            // 
            // btnCardCash
            // 
            this.btnCardCash.Location = new System.Drawing.Point(59, 120);
            this.btnCardCash.Name = "btnCardCash";
            this.btnCardCash.Size = new System.Drawing.Size(136, 23);
            this.btnCardCash.TabIndex = 3;
            this.btnCardCash.Text = "Справка за наличност";
            this.btnCardCash.UseVisualStyleBackColor = true;
            this.btnCardCash.Click += new System.EventHandler(this.btnCardCash_Click);
            // 
            // btnGetCash
            // 
            this.btnGetCash.Location = new System.Drawing.Point(59, 162);
            this.btnGetCash.Name = "btnGetCash";
            this.btnGetCash.Size = new System.Drawing.Size(136, 23);
            this.btnGetCash.TabIndex = 3;
            this.btnGetCash.Text = "Изтегляне на средства";
            this.btnGetCash.UseVisualStyleBackColor = true;
            this.btnGetCash.Click += new System.EventHandler(this.btnGetCash_Click);
            // 
            // ReportForAvailableCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 206);
            this.Controls.Add(this.btnGetCash);
            this.Controls.Add(this.btnCardCash);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCardNumber);
            this.Controls.Add(this.tbBalance);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportForAvailableCash";
            this.Text = "Справка за наличност";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Validating += ReportForAvailableCash_GotFocus;
        }

        #endregion

        private System.Windows.Forms.TextBox tbBalance;
        private System.Windows.Forms.TextBox tbCardNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCardCash;
        private System.Windows.Forms.Button btnGetCash;
    }
}

