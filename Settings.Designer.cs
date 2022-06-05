using System.Windows.Forms;

namespace Skeleton_Key
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Button editUniquifier;
        private Button accept;
        private Button cancel;
        private CheckBox makeUnique;
        private Label descriptionText;
        private Label uniquifierBox;
        private TextBox uniquifierTextBox;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.editUniquifier = new System.Windows.Forms.Button();
            this.accept = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.makeUnique = new System.Windows.Forms.CheckBox();
            this.descriptionText = new System.Windows.Forms.Label();
            this.uniquifierBox = new System.Windows.Forms.Label();
            this.uniquifierTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // editUniquifier
            // 
            this.editUniquifier.Location = new System.Drawing.Point(245, 82);
            this.editUniquifier.Name = "editUniquifier";
            this.editUniquifier.Size = new System.Drawing.Size(75, 23);
            this.editUniquifier.TabIndex = 0;
            this.editUniquifier.Text = "Edit";
            // 
            // accept
            // 
            this.accept.Location = new System.Drawing.Point(283, 159);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(75, 23);
            this.accept.TabIndex = 1;
            this.accept.Text = "OK";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(202, 159);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "CANCEL";
            // 
            // makeUnique
            // 
            this.makeUnique.Location = new System.Drawing.Point(145, 82);
            this.makeUnique.Name = "makeUnique";
            this.makeUnique.Size = new System.Drawing.Size(94, 26);
            this.makeUnique.TabIndex = 3;
            this.makeUnique.Text = "Make Unique";
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(6, 9);
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(358, 70);
            this.descriptionText.TabIndex = 4;
            this.descriptionText.Text = resources.GetString("descriptionText.Text");
            // 
            // uniquifierBox
            // 
            this.uniquifierBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.uniquifierBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uniquifierBox.Location = new System.Drawing.Point(6, 111);
            this.uniquifierBox.Name = "uniquifierBox";
            this.uniquifierBox.Size = new System.Drawing.Size(358, 45);
            this.uniquifierBox.TabIndex = 5;
            this.uniquifierBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uniquifierTextBox
            // 
            this.uniquifierTextBox.AcceptsReturn = true;
            this.uniquifierTextBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.uniquifierTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.uniquifierTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uniquifierTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.uniquifierTextBox.Location = new System.Drawing.Point(12, 121);
            this.uniquifierTextBox.Name = "uniquifierTextBox";
            this.uniquifierTextBox.Size = new System.Drawing.Size(346, 25);
            this.uniquifierTextBox.TabIndex = 6;
            this.uniquifierTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Settings
            // 
            this.AcceptButton = this.accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(370, 186);
            this.Controls.Add(this.editUniquifier);
            this.Controls.Add(this.accept);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.makeUnique);
            this.Controls.Add(this.descriptionText);
            this.Controls.Add(this.uniquifierTextBox);
            this.Controls.Add(this.uniquifierBox);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Skeleton Key: Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}