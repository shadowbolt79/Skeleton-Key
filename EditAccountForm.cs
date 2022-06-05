using HashLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skeleton_Key
{
    public partial class EditAccountForm : Form
    {
        System.ComponentModel.ComponentResourceManager rm = new System.ComponentModel.ComponentResourceManager(typeof(EditAccountForm));

        private string oldName;
        private TextBox AccountName;
        private string oldSite;
        private TextBox AccountSite;
        private string oldUser;
        private TextBox AccountUser;

        private bool oldCases;
        private CheckBox UseBothCases;
        private bool oldNumbers;
        private CheckBox UseNumbers;
        private bool oldSpeical;
        private CheckBox UseSpecialCharacters;

        private int oldIter;
        private TrackBar numIterationsBar;
        private TextBox numIterationsText;

        private int oldCharacters;
        private TrackBar numCharactersBar;
        private TextBox numCharactersText;

        private Label OldPassword;
        private Label NewPassword;
        private CheckBox showOldPassword;
        private CheckBox showNewPassword;
        private TextBox key;

        private Button Accept;
        private Button Cancel;

        private Label charLabel;
        private Label iterLabel;

        private string oldHashPassword;
        private string newHashPassword;
        private int selectedBox;

        private MainWindow callback;

        private readonly string charsLowercase = "abcdefghijklmnopqrstuvwxyz";
        private readonly string charsUppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string charsNumbers = "1234567890";
        private readonly string charsSpecial = "!#$%&'*+,-.:<=>?@[]^_`{|}~";

        private bool editSaved = false;

        public EditAccountForm(MainWindow c, string name, string site, string user, bool cases, bool numbers, bool special, int iterations, int characters)
        {
            callback = c;
            InitializeComponent();
            numIterationsBar.ValueChanged += (onISliderChanged);
            numIterationsText.TextChanged += (onITextChanged);
            numCharactersBar.ValueChanged += (onCSliderChanged);
            numCharactersText.TextChanged += (onCTextChanged);
            oldName = name;
            AccountName.Text = name;
            AccountName.GotFocus += (NameGotFocus);
            AccountName.LostFocus += (NameLostFocus);
            oldSite = site;
            AccountSite.Text = site;
            AccountSite.GotFocus += (SiteGotFocus);
            AccountSite.LostFocus += (SiteLostFocus);
            oldUser = user;
            AccountUser.Text = user;
            AccountUser.GotFocus += (UserGotFocus);
            AccountUser.LostFocus += (UserLostFocus);
            oldCases = cases;
            UseBothCases.Checked = cases;
            oldNumbers = numbers;
            UseNumbers.Checked = numbers;
            oldSpeical = special;
            UseSpecialCharacters.Checked = special;
            oldIter = iterations;
            AccountSite.TextChanged += (OnNewGenerateClick);
            AccountUser.TextChanged += (OnNewGenerateClick);
            UseBothCases.CheckedChanged += (OnNewGenerateClick);
            UseNumbers.CheckedChanged += (OnNewGenerateClick);
            UseSpecialCharacters.CheckedChanged += (OnNewGenerateClick);
            showNewPassword.CheckedChanged += (OnNewGenerateClick);
            showOldPassword.CheckedChanged += (OnOldGenerateClick);
            key.TextChanged += (OnNewGenerateClick);
            key.TextChanged += (OnOldGenerateClick);
            key.GotFocus += (PasswordGotFocus);
            key.LostFocus += (PasswordLostFocus);
            numIterationsBar.Value = iterations;
            numIterationsText.Text = iterations.ToString();
            oldCharacters = characters;
            numCharactersBar.Value = characters;
            numCharactersText.Text = characters.ToString();
            Accept.Click += (AddEvent);
            Cancel.Click += (CancelEvent);
            this.FormClosing += (CloseEvent);
            selectedBox = 0;

            Program.activeWindow = this;
            this.Activated += new EventHandler(EditAccountForm_Activated);
        }

        void EditAccountForm_Activated(object sender, EventArgs e)
        {
            Program.activeWindow = this;
        }

        public void typeText()
        {
            if (selectedBox == 1)
                SK_Util.pasteText(oldHashPassword);
            else if (selectedBox == 2)
                SK_Util.pasteText(newHashPassword);
        }

        private void OnOldGenerateClick(object sender, System.EventArgs e)
        {
            if (key.Text.Length < 5 || key.Text == rm.GetString("key.Text"))
                return;

            IHash hashAlg = HashFactory.Crypto.SHA3.CreateKeccak256();
            string h = hashAlg.ComputeString("in the modern erb, the pony of the left has developed at an astounding rate. Leaving behind the country's policies, they managed to create a new nation for all to be equal. However, such equality struck a coord in the good ponies of the generation, and dissarray and discord began to rule over the hearts and mInds of the once great equines.~").ToString();
            h = hashAlg.ComputeString(h + oldSite).ToString();
            h = hashAlg.ComputeString(h + key.Text).ToString();
            h = hashAlg.ComputeString(h + oldUser).ToString();

            if (oldIter > 0)
            {
                for (int i = 0; i < oldIter; i++)
                    h = hashAlg.ComputeString(h).ToString();
            }

            string[] hash;

            hash = h.Split('-');

            string hashedPassword = "";

            bool valid = false;

            while (!valid)
            {
                hashedPassword = "";

                string chars = charsLowercase + (oldCases ? charsUppercase : "") + (oldNumbers ? charsNumbers : "") + (oldSpeical ? charsSpecial : "");

                for (int i = 0; i < hash.Length && hashedPassword.Length < oldCharacters; i++)
                {
                    string h2 = hash[i];
                    for (int j = 0; j < 6 && hashedPassword.Length < oldCharacters; j += 2)
                    {
                        int index = Convert.ToInt32(h2.Substring(j, 2), 16);
                        hashedPassword += chars.ToCharArray()[index % chars.Length];
                    }
                }

                valid = !valid;

                if (oldCases)
                {
                    //Validate cases
                    valid = (hashedPassword.IndexOfAny(charsLowercase.ToCharArray()) != -1) && (hashedPassword.IndexOfAny(charsUppercase.ToCharArray()) != -1);
                }
                if (oldNumbers && valid)
                {
                    //Validate numbers
                    valid = (hashedPassword.IndexOfAny(charsNumbers.ToCharArray()) != -1);
                }
                if (oldSpeical && valid)
                {
                    //Validate special characters
                    valid = (hashedPassword.IndexOfAny(charsSpecial.ToCharArray()) != -1);
                }

                if (!valid)
                {
                    h = hashAlg.ComputeString(h + oldUser + hashedPassword).ToString();
                    hash = h.Split('-');
                }
            }
            if (showOldPassword.Checked)
                OldPassword.Text = hashedPassword;
            else
            {
                string s = "";
                for (int i = 0; i < hashedPassword.Length; i++)
                    s += "•";
                OldPassword.Text = s;
            }
            oldHashPassword = hashedPassword;
        }

        private void OnNewGenerateClick(object sender, System.EventArgs e)
        {

            if (key.Text.Length < 5)
                return;

            if (!((AccountName.Text.Length > 3 && AccountName.Text != rm.GetString("AccountName.Text") && key.Text != rm.GetString("key.Text") && AccountSite.Text.Length > 3 && AccountSite.Text != rm.GetString("AccountSite.Text") && AccountUser.Text.Length > 3 && AccountUser.Text != rm.GetString("AccountUser.Text"))))
                return;

            IHash hashAlg = HashFactory.Crypto.SHA3.CreateKeccak256();
            string h = hashAlg.ComputeString("in the modern erb, the pony of the left has developed at an astounding rate. Leaving behind the country's policies, they managed to create a new nation for all to be equal. However, such equality struck a coord in the good ponies of the generation, and dissarray and discord began to rule over the hearts and mInds of the once great equines.~").ToString();
            h = hashAlg.ComputeString(h + AccountSite.Text).ToString();
            h = hashAlg.ComputeString(h + key.Text).ToString();
            h = hashAlg.ComputeString(h + AccountUser.Text).ToString();

            if (numIterationsBar.Value > 0)
            {
                for (int i = 0; i < numIterationsBar.Value; i++)
                    h = hashAlg.ComputeString(h).ToString();
            }

            string[] hash;

            hash = h.Split('-');

            string hashedPassword = "";

            bool valid = false;

            while (!valid)
            {
                hashedPassword = "";

                string chars = charsLowercase + (UseBothCases.Checked ? charsUppercase : "") + (UseNumbers.Checked ? charsNumbers : "") + (UseSpecialCharacters.Checked ? charsSpecial : "");

                for (int i = 0; i < hash.Length && hashedPassword.Length < numCharactersBar.Value; i++)
                {
                    string h2 = hash[i];
                    for (int j = 0; j < 6 && hashedPassword.Length < numCharactersBar.Value; j += 2)
                    {
                        int index = Convert.ToInt32(h2.Substring(j, 2), 16);
                        hashedPassword += chars.ToCharArray()[index % chars.Length];
                    }
                }

                valid = !valid;

                if (UseBothCases.Checked)
                {
                    //Validate cases
                    valid = (hashedPassword.IndexOfAny(charsLowercase.ToCharArray()) != -1) && (hashedPassword.IndexOfAny(charsUppercase.ToCharArray()) != -1);
                }
                if (UseNumbers.Checked && valid)
                {
                    //Validate numbers
                    valid = (hashedPassword.IndexOfAny(charsNumbers.ToCharArray()) != -1);
                }
                if (UseSpecialCharacters.Checked && valid)
                {
                    //Validate special characters
                    valid = (hashedPassword.IndexOfAny(charsSpecial.ToCharArray()) != -1);
                }

                if (!valid)
                {
                    h = hashAlg.ComputeString(h + AccountUser.Text + hashedPassword).ToString();
                    hash = h.Split('-');
                }
            }
            if (showNewPassword.Checked)
                NewPassword.Text = hashedPassword;
            else
            {
                string s = "";
                for (int i = 0; i < hashedPassword.Length; i++)
                    s += "•";
                NewPassword.Text = s;
            }
            newHashPassword = hashedPassword;
        }

        private void onCSliderChanged(object sender, System.EventArgs e)
        {
            this.numCharactersText.Text = this.numCharactersBar.Value.ToString();
            OnNewGenerateClick(sender, e);
        }
        private void onISliderChanged(object sender, System.EventArgs e)
        {
            this.numIterationsText.Text = this.numIterationsBar.Value.ToString();
            OnNewGenerateClick(sender, e);
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
            OnNewGenerateClick(sender, e);
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
            OnNewGenerateClick(sender, e);
        }

        private void CancelEvent(object sender, System.EventArgs e)
        {
            //callback.addAccount(oldName, oldUser, oldSite, oldCases, oldNumbers, oldSpeical, oldCharacters, oldIter);
            this.Close();
        }
        
        private void CloseEvent(object sender, System.EventArgs e)
        {
            if(!this.editSaved)
                callback.addAccount(oldName, oldUser, oldSite, oldCases, oldNumbers, oldSpeical, oldCharacters, oldIter);
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

            if(accountName.Length>3 && accountName != rm.GetString("AccountName.Text") && accountWebsite.Length > 3 && accountWebsite != rm.GetString("AccountSite.Text") && accountUser.Length > 3 && accountUser != rm.GetString("AccountUser.Text"))
            {
                callback.addAccount(accountName, accountUser, accountWebsite, usesCases, usesNumbers, usesSpecial, numCharactersBar.Value, numIterationsBar.Value);
                editSaved = true;
                this.Close();
            }
        }

        private void OldPassword_Click(object sender, EventArgs e)
        {
            selectedBox = 1;
            this.NewPassword.BackColor = Color.DimGray;
            this.OldPassword.BackColor = Color.DarkGray;
        }

        private void NewPassword_Click(object sender, EventArgs e)
        {
            selectedBox = 2;
            this.NewPassword.BackColor = Color.DarkGray;
            this.OldPassword.BackColor = Color.DimGray;
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

        private void PasswordGotFocus(object sender, EventArgs e)
        {
            if (this.key.Text == rm.GetString("key.Text"))
            {
                this.key.PasswordChar = '•';
                this.key.Text = "";
                this.key.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void PasswordLostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(key.Text) || key.Text == rm.GetString("key.Text"))
            {
                key.Text = rm.GetString("key.Text");
                this.key.PasswordChar = '\0';
                this.key.ForeColor = System.Drawing.SystemColors.WindowFrame;
            }
        }
    }
}
