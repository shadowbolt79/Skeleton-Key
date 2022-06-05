namespace Skeleton_Key
{
    partial class RemoveConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveConfirm));
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.messageText = new System.Windows.Forms.Label();
            this.messageSubText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ok.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.ok, "ok");
            this.ok.Name = "ok";
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.Name = "cancel";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // messageText
            // 
            resources.ApplyResources(this.messageText, "messageText");
            this.messageText.Name = "messageText";
            // 
            // messageSubText
            // 
            resources.ApplyResources(this.messageSubText, "messageSubText");
            this.messageSubText.Name = "messageSubText";
            // 
            // RemoveConfirm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.messageText);
            this.Controls.Add(this.messageSubText);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "RemoveConfirm";
            this.ResumeLayout(false);

        }

        #endregion
    }
}