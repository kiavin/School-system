namespace School_system
{
    partial class MiniLogin
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
            this.txtBoxUname = new System.Windows.Forms.TextBox();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.txtBoxPass = new System.Windows.Forms.Label();
            this.confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ebrima", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(198, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // txtBoxUname
            // 
            this.txtBoxUname.Location = new System.Drawing.Point(352, 182);
            this.txtBoxUname.Name = "txtBoxUname";
            this.txtBoxUname.Size = new System.Drawing.Size(209, 22);
            this.txtBoxUname.TabIndex = 1;
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Location = new System.Drawing.Point(352, 261);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.Size = new System.Drawing.Size(209, 22);
            this.txtBoxPassword.TabIndex = 3;
            // 
            // txtBoxPass
            // 
            this.txtBoxPass.AutoSize = true;
            this.txtBoxPass.Font = new System.Drawing.Font("Ebrima", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPass.Location = new System.Drawing.Point(198, 257);
            this.txtBoxPass.Name = "txtBoxPass";
            this.txtBoxPass.Size = new System.Drawing.Size(92, 25);
            this.txtBoxPass.TabIndex = 2;
            this.txtBoxPass.Text = "Password";
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.Color.SpringGreen;
            this.confirm.Font = new System.Drawing.Font("Comic Sans MS", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm.Location = new System.Drawing.Point(203, 369);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(358, 33);
            this.confirm.TabIndex = 4;
            this.confirm.Text = "login";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // MiniLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 517);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.txtBoxPass);
            this.Controls.Add(this.txtBoxUname);
            this.Controls.Add(this.label1);
            this.Name = "MiniLogin";
            this.Text = "MiniLogin";
            this.Load += new System.EventHandler(this.MiniLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxUname;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Label txtBoxPass;
        private System.Windows.Forms.Button confirm;
    }
}