namespace Skeleton_Key
{
    partial class EditAccountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAccountForm));
            this.AccountName = new System.Windows.Forms.TextBox();
            this.AccountSite = new System.Windows.Forms.TextBox();
            this.AccountUser = new System.Windows.Forms.TextBox();
            this.UseBothCases = new System.Windows.Forms.CheckBox();
            this.UseNumbers = new System.Windows.Forms.CheckBox();
            this.UseSpecialCharacters = new System.Windows.Forms.CheckBox();
            this.numIterationsBar = new System.Windows.Forms.TrackBar();
            this.numIterationsText = new System.Windows.Forms.TextBox();
            this.numCharactersBar = new System.Windows.Forms.TrackBar();
            this.numCharactersText = new System.Windows.Forms.TextBox();
            this.OldPassword = new System.Windows.Forms.Label();
            this.NewPassword = new System.Windows.Forms.Label();
            this.showOldPassword = new System.Windows.Forms.CheckBox();
            this.showNewPassword = new System.Windows.Forms.CheckBox();
            this.key = new System.Windows.Forms.TextBox();
            this.Accept = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.charLabel = new System.Windows.Forms.Label();
            this.iterLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numIterationsBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCharactersBar)).BeginInit();
            this.SuspendLayout();
            // 
            // AccountName
            // 
            this.AccountName.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.AccountName, "AccountName");
            this.AccountName.Name = "AccountName";
            // 
            // AccountSite
            // 
            this.AccountSite.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.AccountSite, "AccountSite");
            this.AccountSite.Name = "AccountSite";
            // 
            // AccountUser
            // 
            this.AccountUser.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.AccountUser, "AccountUser");
            this.AccountUser.Name = "AccountUser";
            // 
            // UseBothCases
            // 
            resources.ApplyResources(this.UseBothCases, "UseBothCases");
            this.UseBothCases.Name = "UseBothCases";
            // 
            // UseNumbers
            // 
            resources.ApplyResources(this.UseNumbers, "UseNumbers");
            this.UseNumbers.Name = "UseNumbers";
            // 
            // UseSpecialCharacters
            // 
            resources.ApplyResources(this.UseSpecialCharacters, "UseSpecialCharacters");
            this.UseSpecialCharacters.Name = "UseSpecialCharacters";
            // 
            // numIterationsBar
            // 
            resources.ApplyResources(this.numIterationsBar, "numIterationsBar");
            this.numIterationsBar.Maximum = 12;
            this.numIterationsBar.Name = "numIterationsBar";
            // 
            // numIterationsText
            // 
            resources.ApplyResources(this.numIterationsText, "numIterationsText");
            this.numIterationsText.Name = "numIterationsText";
            // 
            // numCharactersBar
            // 
            resources.ApplyResources(this.numCharactersBar, "numCharactersBar");
            this.numCharactersBar.Maximum = 22;
            this.numCharactersBar.Minimum = 6;
            this.numCharactersBar.Name = "numCharactersBar";
            this.numCharactersBar.Value = 16;
            // 
            // numCharactersText
            // 
            resources.ApplyResources(this.numCharactersText, "numCharactersText");
            this.numCharactersText.Name = "numCharactersText";
            // 
            // OldPassword
            // 
            this.OldPassword.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.OldPassword, "OldPassword");
            this.OldPassword.Name = "OldPassword";
            this.OldPassword.UseMnemonic = false;
            this.OldPassword.Click += new System.EventHandler(this.OldPassword_Click);
            // 
            // NewPassword
            // 
            this.NewPassword.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            resources.ApplyResources(this.NewPassword, "NewPassword");
            this.NewPassword.Name = "NewPassword";
            this.NewPassword.UseMnemonic = false;
            this.NewPassword.Click += new System.EventHandler(this.NewPassword_Click);
            // 
            // showOldPassword
            // 
            resources.ApplyResources(this.showOldPassword, "showOldPassword");
            this.showOldPassword.Name = "showOldPassword";
            // 
            // showNewPassword
            // 
            resources.ApplyResources(this.showNewPassword, "showNewPassword");
            this.showNewPassword.Name = "showNewPassword";
            // 
            // key
            // 
            this.key.ForeColor = System.Drawing.SystemColors.WindowFrame;
            resources.ApplyResources(this.key, "key");
            this.key.Name = "key";
            // 
            // Accept
            // 
            this.Accept.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Accept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.Accept, "Accept");
            this.Accept.Name = "Accept";
            // 
            // Cancel
            // 
            this.Cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.Cancel, "Cancel");
            this.Cancel.Name = "Cancel";
            // 
            // charLabel
            // 
            resources.ApplyResources(this.charLabel, "charLabel");
            this.charLabel.Name = "charLabel";
            // 
            // iterLabel
            // 
            resources.ApplyResources(this.iterLabel, "iterLabel");
            this.iterLabel.Name = "iterLabel";
            // 
            // EditAccountForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.AccountName);
            this.Controls.Add(this.AccountUser);
            this.Controls.Add(this.AccountSite);
            this.Controls.Add(this.UseBothCases);
            this.Controls.Add(this.UseNumbers);
            this.Controls.Add(this.UseSpecialCharacters);
            this.Controls.Add(this.numIterationsBar);
            this.Controls.Add(this.numIterationsText);
            this.Controls.Add(this.numCharactersBar);
            this.Controls.Add(this.numCharactersText);
            this.Controls.Add(this.OldPassword);
            this.Controls.Add(this.NewPassword);
            this.Controls.Add(this.showOldPassword);
            this.Controls.Add(this.showNewPassword);
            this.Controls.Add(this.key);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.charLabel);
            this.Controls.Add(this.iterLabel);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "EditAccountForm";
            ((System.ComponentModel.ISupportInitialize)(this.numIterationsBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCharactersBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}