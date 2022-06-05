using HashLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skeleton_Key
{
    public partial class Settings : Form
    {
        private string uniquifierKey;
        private MainWindow callback;

        public Settings(string key, MainWindow callback)
        {
            this.callback = callback;
            this.uniquifierKey = key;
            InitializeComponent();

            if (uniquifierKey != "")
            {
                this.makeUnique.Checked = true;
                this.uniquifierBox.Text = uniquifierKey;
                this.uniquifierTextBox.Text = uniquifierKey;
            }

            this.uniquifierTextBox.LostFocus += this.uniquifierTextBox_lostFocus;
            this.makeUnique.CheckedChanged += this.makeUnique_checkedChanged;
            this.cancel.Click += this.cancel_Clicked;
            this.accept.Click += this.ok_Clicked;
            this.editUniquifier.Click += this.edit_Clicked;
            this.uniquifierTextBox.Hide();

        }

        private void makeUnique_checkedChanged(object sender, EventArgs e)
        {
            //TODO:
            if(makeUnique.Checked)
            {
                uniquifierKey = HashFactory.Crypto.SHA3.CreateKeccak256().ComputeInt((new Random()).Next()).ToString().Substring(0,17);
                uniquifierBox.Text = uniquifierKey;
                uniquifierTextBox.Text = uniquifierKey;
            }
            else
            {
                uniquifierKey = "";
                uniquifierBox.Text = "";
                uniquifierTextBox.Text = "";
            }
        }

        private void edit_Clicked(object sender, EventArgs e)
        {
            if (makeUnique.Checked)
            {
                this.uniquifierTextBox.Show();
                this.uniquifierTextBox.Focus();
            }
        }

        private void uniquifierTextBox_lostFocus(object sender, EventArgs e)
        {
            uniquifierBox.Text = uniquifierTextBox.Text;
            uniquifierKey = uniquifierTextBox.Text;
            uniquifierTextBox.Hide();
        }

        private void cancel_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Clicked(object sender, EventArgs e)
        {
            if (uniquifierTextBox.Visible)
                uniquifierTextBox_lostFocus(sender, e);

            if (makeUnique.Checked)
                callback.setUniquifier(uniquifierKey);

            else
                callback.setUniquifier("");
            this.Close();
        }
    }
}
