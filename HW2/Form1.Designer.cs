namespace HW2
{
    partial class Form1
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
            this.lblHelloWorld3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblHelloWorld3
            // 
            this.lblHelloWorld3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHelloWorld3.Location = new System.Drawing.Point(0, 0);
            this.lblHelloWorld3.Multiline = true;
            this.lblHelloWorld3.Name = "lblHelloWorld3";
            this.lblHelloWorld3.Size = new System.Drawing.Size(800, 450);
            this.lblHelloWorld3.TabIndex = 0;
            this.lblHelloWorld3.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblHelloWorld3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lblHelloWorld3;
    }
}

