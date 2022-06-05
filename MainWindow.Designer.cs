namespace Skeleton_Key
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.newAccount = new System.Windows.Forms.Button();
            this.editAccount = new System.Windows.Forms.Button();
            this.removeAccount = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.submit = new System.Windows.Forms.Button();
            this.hashPassword = new System.Windows.Forms.Label();
            this.accounts = new System.Windows.Forms.ComboBox();
            this.password = new System.Windows.Forms.TextBox();
            this.showPassword = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // newAccount
            // 
            this.newAccount.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.newAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.newAccount, "newAccount");
            this.newAccount.Name = "newAccount";
            // 
            // editAccount
            // 
            this.editAccount.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.editAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.editAccount, "editAccount");
            this.editAccount.Name = "editAccount";
            this.editAccount.Click += new System.EventHandler(this.editAccount_Click);
            // 
            // removeAccount
            // 
            this.removeAccount.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.removeAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.removeAccount, "removeAccount");
            this.removeAccount.Name = "removeAccount";
            this.removeAccount.Click += new System.EventHandler(this.removeAccount_Click);
            // 
            // settings
            // 
            resources.ApplyResources(this.settings, "settings");
            this.settings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.settings.FlatAppearance.BorderSize = 0;
            this.settings.Image = global::Skeleton_Key.Properties.Resources.Settings3;
            this.settings.Name = "settings";
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // submit
            // 
            this.submit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.submit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.submit, "submit");
            this.submit.Name = "submit";
            // 
            // hashPassword
            // 
            this.hashPassword.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.hashPassword, "hashPassword");
            this.hashPassword.Name = "hashPassword";
            this.hashPassword.UseMnemonic = false;
            // 
            // accounts
            // 
            this.accounts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.accounts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.accounts.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.accounts.ForeColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.accounts, "accounts");
            this.accounts.Name = "accounts";
            // 
            // password
            // 
            this.password.ForeColor = System.Drawing.SystemColors.WindowFrame;
            resources.ApplyResources(this.password, "password");
            this.password.Name = "password";
            // 
            // showPassword
            // 
            resources.ApplyResources(this.showPassword, "showPassword");
            this.showPassword.Name = "showPassword";
            // 
            // MainWindow
            // 
            this.AcceptButton = this.submit;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.BackgroundImage = global::Skeleton_Key.Properties.Resources.SkeletonKey;
            this.Controls.Add(this.newAccount);
            this.Controls.Add(this.editAccount);
            this.Controls.Add(this.removeAccount);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.hashPassword);
            this.Controls.Add(this.accounts);
            this.Controls.Add(this.password);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.settings);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

