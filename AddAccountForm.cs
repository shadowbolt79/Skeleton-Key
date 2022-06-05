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
    public partial class AddAccountForm : Form
    {
        private System.ComponentModel.ComponentResourceManager rm = new System.ComponentModel.ComponentResourceManager(typeof(AddAccountForm));
        private TextBox AccountName;
        private TextBox AccountSite;
        private TextBox AccountUser;

        private Label charLabel;
        private Label iterLabel;

        private CheckBox UseBothCases;
        private CheckBox UseNumbers;
        private CheckBox UseSpecialCharacters;

        private TrackBar numIterationsBar;
        private TextBox numIterationsText;

        private TrackBar numCharactersBar;
        private TextBox numCharactersText;

        private Button Accept;
        private Button Cancel;

        private MainWindow callback;

        public AddAccountForm(MainWindow c)
        {
            callback = c;
            InitializeComponent();
            numIterationsBar.ValueChanged += (onISliderChanged);
            numIterationsText.TextChanged += (onITextChanged);
            numCharactersBar.ValueChanged += (onCSliderChanged);
            numCharactersText.TextChanged += (onCTextChanged);
            AccountName.GotFocus += (NameGotFocus);
            AccountName.LostFocus += (NameLostFocus);
            AccountSite.GotFocus += (SiteGotFocus);
            AccountSite.LostFocus += (SiteLostFocus);
            AccountUser.GotFocus += (UserGotFocus);
            AccountUser.LostFocus += (UserLostFocus);
            UseBothCases.Checked = true;
            UseNumbers.Checked = true;
            UseSpecialCharacters.Checked = true;
            Accept.Click += (AddEvent);
            Cancel.Click += (CancelEvent);
        }

        private void onCSliderChanged(object sender, System.EventArgs e)
        {
            this.numCharactersText.Text = this.numCharactersBar.Value.ToString();
        }
        private void onISliderChanged(object sender, System.EventArgs e)
        {
            this.numIterationsText.Text = this.numIterationsBar.Value.ToString();
        }
        private void onCTextChanged(object sender, System.EventArgs e)
        {
            int i = 16;
            if (Int32.TryParse(this.numCharactersText.Text, out i))
            {
                if (i < 0 || i > 22)
                {
                    i = 16;
                    this.numCharactersText.Text = i.ToString();
                }
                this.numCharactersBar.Value = i;
            }
            else
            {
                i = 16;
                this.numCharactersText.Text = i.ToString();
            }
        }
        private void onITextChanged(object sender, System.EventArgs e)
        {
            int i = 0;
            if (Int32.TryParse(this.numIterationsText.Text, out i))
            {
                if (i < 0 || i > 12)
                {
                    i = 0;
                    this.numIterationsText.Text = i.ToString();
                }
                this.numIterationsBar.Value = i;
            }
            else
            {
                i = 0;
                this.numIterationsText.Text = i.ToString();
            }
        }

        private void CancelEvent(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void AddEvent(object sender, System.EventArgs e)
        {
            //verify input data
            string accountName = this.AccountName.Text;
            string accountWebsite = this.AccountSite.Text;
            string accountUser = this.AccountUser.Text;

            bool usesCases = this.UseBothCases.Checked;
            bool usesNumbers = this.UseNumbers.Checked;
            bool usesSpecial = this.UseSpecialCharacters.Checked;

            if (accountName.Length > 3 && accountName != rm.GetString("AccountName.Text") && accountWebsite.Length > 3 && accountWebsite != rm.GetString("AccountSite.Text") && accountUser.Length > 3 && accountUser != rm.GetString("AccountUser.Text"))
            {
                callback.addAccount(accountName, accountUser, accountWebsite, usesCases, usesNumbers, usesSpecial, numCharactersBar.Value, numIterationsBar.Value);
                this.Close();
            }
        }

        private void NameGotFocus(object sender, EventArgs e)
        {
            if (this.AccountName.Text == rm.GetString("AccountName.Text"))
            {
                this.AccountName.Text = "";
                this.AccountName.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void NameLostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(AccountName.Text) || AccountName.Text == rm.GetString("AccountName.Text"))
            {
                AccountName.Text = rm.GetString("AccountName.Text");
                this.AccountName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            }
        }

        private void SiteGotFocus(object sender, EventArgs e)
        {
            if (this.AccountSite.Text == rm.GetString("AccountSite.Text"))
            {
                this.AccountSite.Text = "";
                this.AccountSite.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void SiteLostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(AccountSite.Text) || AccountSite.Text == rm.GetString("AccountSite.Text"))
            {
                AccountSite.Text = rm.GetString("AccountSite.Text");
                this.AccountSite.ForeColor = System.Drawing.SystemColors.WindowFrame;
            }
        }

        private void UserGotFocus(object sender, EventArgs e)
        {
            if (this.AccountUser.Text == rm.GetString("AccountUser.Text"))
            {
                this.AccountUser.Text = "";
                this.AccountUser.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void UserLostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(AccountUser.Text) || AccountUser.Text == rm.GetString("AccountUser.Text"))
            {
                AccountUser.Text = rm.GetString("AccountUser.Text");
                this.AccountUser.ForeColor = System.Drawing.SystemColors.WindowFrame;
            }
        }
    }
}
