namespace Logistic
{
    partial class Login
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
            this.lblLoginPass = new System.Windows.Forms.Label();
            this.tbxLoginPassword = new System.Windows.Forms.TextBox();
            this.tbxLoginUsername = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLoginPass
            // 
            this.lblLoginPass.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblLoginPass.AutoSize = true;
            this.lblLoginPass.Location = new System.Drawing.Point(75, 97);
            this.lblLoginPass.Name = "lblLoginPass";
            this.lblLoginPass.Size = new System.Drawing.Size(60, 15);
            this.lblLoginPass.TabIndex = 35;
            this.lblLoginPass.Text = "Password:";
            // 
            // tbxLoginPassword
            // 
            this.tbxLoginPassword.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tbxLoginPassword.Location = new System.Drawing.Point(148, 94);
            this.tbxLoginPassword.Name = "tbxLoginPassword";
            this.tbxLoginPassword.PasswordChar = '*';
            this.tbxLoginPassword.Size = new System.Drawing.Size(100, 23);
            this.tbxLoginPassword.TabIndex = 34;
            // 
            // tbxLoginUsername
            // 
            this.tbxLoginUsername.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tbxLoginUsername.Location = new System.Drawing.Point(148, 65);
            this.tbxLoginUsername.Name = "tbxLoginUsername";
            this.tbxLoginUsername.Size = new System.Drawing.Size(100, 23);
            this.tbxLoginUsername.TabIndex = 33;
            // 
            // lblLogin
            // 
            this.lblLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(72, 68);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(63, 15);
            this.lblLogin.TabIndex = 32;
            this.lblLogin.Text = "Username:";
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnLogin.BackColor = System.Drawing.Color.DarkGray;
            this.btnLogin.Location = new System.Drawing.Point(163, 157);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(85, 29);
            this.btnLogin.TabIndex = 31;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 283);
            this.Controls.Add(this.lblLoginPass);
            this.Controls.Add(this.tbxLoginPassword);
            this.Controls.Add(this.tbxLoginUsername);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.btnLogin);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblLoginPass;
        private TextBox tbxLoginPassword;
        private TextBox tbxLoginUsername;
        private Label lblLogin;
        private Button btnLogin;
    }
}