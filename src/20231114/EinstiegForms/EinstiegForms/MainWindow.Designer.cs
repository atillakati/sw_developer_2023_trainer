namespace EinstiegForms
{
    partial class MainWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btt_cancel = new System.Windows.Forms.Button();
            this.btt_ok = new System.Windows.Forms.Button();
            this.lbl_result = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(120, 64);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(292, 20);
            this.txt_name.TabIndex = 1;
            this.txt_name.Text = "Please enter here!";
            // 
            // btt_cancel
            // 
            this.btt_cancel.Location = new System.Drawing.Point(242, 156);
            this.btt_cancel.Name = "btt_cancel";
            this.btt_cancel.Size = new System.Drawing.Size(75, 23);
            this.btt_cancel.TabIndex = 2;
            this.btt_cancel.Text = "&Abbruch";
            this.btt_cancel.UseVisualStyleBackColor = true;
            // 
            // btt_ok
            // 
            this.btt_ok.Location = new System.Drawing.Point(337, 156);
            this.btt_ok.Name = "btt_ok";
            this.btt_ok.Size = new System.Drawing.Size(75, 23);
            this.btt_ok.TabIndex = 3;
            this.btt_ok.Text = "&OK";
            this.btt_ok.UseVisualStyleBackColor = true;
            this.btt_ok.Click += new System.EventHandler(this.btt_ok_Click);
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_result.ForeColor = System.Drawing.Color.Blue;
            this.lbl_result.Location = new System.Drawing.Point(70, 111);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(95, 24);
            this.lbl_result.TabIndex = 4;
            this.lbl_result.Text = "Ergebniss";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 210);
            this.Controls.Add(this.lbl_result);
            this.Controls.Add(this.btt_ok);
            this.Controls.Add(this.btt_cancel);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "WIFI Forms Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btt_cancel;
        private System.Windows.Forms.Button btt_ok;
        private System.Windows.Forms.Label lbl_result;
    }
}

