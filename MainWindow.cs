using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HashLib;

namespace Skeleton_Key
{
    public partial class MainWindow : Form
    {
        private System.ComponentModel.ComponentResourceManager rm = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));

        private Button newAccount;
        private Button editAccount;
        private Button removeAccount;
        private Button submit;
        private Button settings;
        private CheckBox showPassword;
        private TextBox password;
        private Label hashPassword;
        private ComboBox accounts;

        private KeyHandler ghk;
        
        private string[] hash;

        private string hashedPassword = "";

        private string uniquifier = "";

        private readonly string charsLowercase = "abcdefghijklmnopqrstuvwxyz";
        private readonly string charsUppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string charsNumbers = "1234567890";
        private readonly string charsSpecial = "!#$%&'*+,-.:<=>?@[]^_`{|}~";

        private readonly string fileName = @".\SkeletonKey.dat";

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(fileName))
            {
                using (FileStream fs = File.OpenRead(fileName))
                {
                    string t = "";
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (fs.Read(b, 0, b.Length) > 0)
                    {
                        t += temp.GetString(b);
                        string[] accounts = t.Split('\n');
                        for(int i = 0; i<accounts.Length-1;i++)
                        {
                            if(accounts[i].Length>16)
                                if(accounts[i].Substring(0,16)== "UNIQUIFIER-DATA:")
                                {
                                    uniquifier = accounts[i].Substring(16);
                                    Console.WriteLine(uniquifier);
                                    continue;
                                }
                            Account a = new Account();
                            if (a.loadData(accounts[i]))
                                this.accounts.Items.Add(a);
                        }
                        t = accounts[accounts.Length - 1];
                    }

                    if(t!="")
                    {
                        Account a = new Account();
                        if(a.loadData(t))
                            this.accounts.Items.Add(a);
                    }
                }

                
            }
            
            ghk = new KeyHandler(Keys.F8, this);
            
            ghk.Register();
            submit.Click += (OnGenerateClick);
            password.GotFocus += (PasswordGotFocus);
            password.LostFocus += (PasswordLostFocus);
            newAccount.Click += (OnAddClick);
            removeAccount.Hide();
            editAccount.Hide();
            accounts.SelectedIndexChanged += (OnGenerateClick);
            showPassword.CheckedChanged += (OnGenerateClick);

            Program.activeWindow = this;
            this.Activated += new EventHandler(MainWindow_Activated);
        }

        void MainWindow_Activated(object sender, EventArgs e)
        {
            Program.activeWindow = this;
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        public void SaveAccounts()
        {
            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (FileStream fs = File.Create(fileName))
            {
                if(uniquifier!="")
                    AddText(fs, "UNIQUIFIER-DATA:" + uniquifier);
                for (int i = 0; i < this.accounts.Items.Count; i++)
                {
                    AddText(fs, ((Account)this.accounts.Items[i]).saveData());
                }
            }
        }

        public void addAccount(string name, string user, string web, bool cases, bool numbers, bool special, int numchar, int numiteration)
        {
            Account a = new Account(name, user, web, cases, numbers, special, numchar, numiteration);
            accounts.Items.Add(a);
            accounts.Sorted = true;
            accounts.SelectedItem = a;
            SaveAccounts();
        }

        public void RemoveAccount()
        {
            if (accounts.SelectedIndex >= 0)
            {
                accounts.Items.Remove((Account)accounts.SelectedItem);
                SaveAccounts();
            }
        }

        private void OnAddClick(object sender, System.EventArgs e)
        {
            (new AddAccountForm(this)).ShowDialog(this);
        }

        private void OnGenerateClick(object sender, System.EventArgs e)
        {
            if(accounts.SelectedIndex<0)
            {
                this.editAccount.Hide();
                this.removeAccount.Hide();
                return;
            }
            else
            {
                this.editAccount.Show();
                this.removeAccount.Show();
            }
            if (password.Text.Length < 5 || password.Text == rm.GetString("password.Text"))
                return;

            Account selectedAccount = (Account)accounts.SelectedItem;

            IHash hashAlg = HashFactory.Crypto.SHA3.CreateKeccak256();
            string h = hashAlg.ComputeString("This string was changed for security reasons. Feel free to change it to make your copy of the program unique.~"+uniquifier).ToString();
            h = hashAlg.ComputeString(h + selectedAccount.getSite()).ToString();
            h = hashAlg.ComputeString(h + password.Text).ToString();
            h = hashAlg.ComputeString(h + selectedAccount.getUser()).ToString();

            if(selectedAccount.getIteration()>0)
            {
                for(int i = 0; i < selectedAccount.getIteration();i++)
                    h = hashAlg.ComputeString(h).ToString();
            }

            hash = h.Split('-');

            hashedPassword = "";

            bool valid = false;

            while(!valid)
            {
                hashedPassword = "";

                string chars = charsLowercase + (selectedAccount.usesCases() ? charsUppercase : "") + (selectedAccount.usesSomeNumbers() ? charsNumbers : "") + (selectedAccount.usesSpecial() ? charsSpecial : "");

                for (int i = 0; i < hash.Length && hashedPassword.Length < selectedAccount.getNumChars(); i++)
                {
                    string h2 = hash[i];
                    for (int j = 0; j < 6 && hashedPassword.Length < selectedAccount.getNumChars(); j += 2)
                    {
                        int index = Convert.ToInt32(h2.Substring(j, 2), 16);
                        hashedPassword += chars.ToCharArray()[index % chars.Length];
                    }
                }

                valid = !valid;

                if(selectedAccount.usesCases())
                {
                    //Validate cases
                    valid = (hashedPassword.IndexOfAny(charsLowercase.ToCharArray()) != -1) && (hashedPassword.IndexOfAny(charsUppercase.ToCharArray()) != -1);
                }
                if(selectedAccount.usesSomeNumbers() && valid)
                {
                    //Validate numbers
                    valid = (hashedPassword.IndexOfAny(charsNumbers.ToCharArray()) != -1);
                }
                if(selectedAccount.usesSpecial() && valid)
                {
                    //Validate special characters
                    valid = (hashedPassword.IndexOfAny(charsSpecial.ToCharArray()) != -1);
                }

                if(!valid)
                {
                    h = hashAlg.ComputeString(h + selectedAccount.getUser() + hashedPassword).ToString();
                    hash = h.Split('-');
                }
            }
            if(showPassword.Checked)
                hashPassword.Text = hashedPassword;
            else
            {
                string s = "";
                for (int i = 0; i < hashedPassword.Length; i++)
                    s += "•";
                hashPassword.Text = s;
            }
            //Clipboard.SetText(hashedPassword);
        }

        private void removeAccount_Click(object sender, EventArgs e)
        {
            (new RemoveConfirm(this)).ShowDialog(this);
        }

        private void editAccount_Click(object sender, EventArgs e)
        {
            Account a = (Account)accounts.SelectedItem;
            if (a != null)
            {
                accounts.Items.Remove(a);
                (new EditAccountForm(this, a.getName(), a.getSite(), a.getUser(), a.usesCases(), a.usesSomeNumbers(), a.usesSpecial(), a.getIteration(), a.getNumChars())).ShowDialog(this);
            }
        }

        private void settings_Click(object sender, EventArgs e)
        {
            (new Settings(uniquifier,this)).ShowDialog(this);
        }

        private void PasswordGotFocus(object sender, EventArgs e)
        {
            if(this.password.Text == rm.GetString("password.Text"))
            {
                this.password.PasswordChar = '•';
                this.password.Text = "";
                this.password.ForeColor = System.Drawing.SystemColors.WindowText;
            }
        }

        private void PasswordLostFocus(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(password.Text)||password.Text== rm.GetString("password.Text"))
            {
                password.Text = rm.GetString("password.Text");
                this.password.PasswordChar = '\0';
                this.password.ForeColor = System.Drawing.SystemColors.WindowFrame;
            }
        }

        private void HandlePasteCommand()
        {
            if(Program.activeWindow==this)
                SK_Util.pasteText(hashedPassword);
            else if(Program.activeWindow is EditAccountForm)
            {
                ((EditAccountForm)Program.activeWindow).typeText();
            }
        }

        public string getUniquifier()
        {
            return uniquifier;
        }

        public void setUniquifier(string s)
        {
            uniquifier = s;
            SaveAccounts();
            OnGenerateClick(null, null);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == SK_Util.WM_HOTKEY_MSG_ID)
                HandlePasteCommand();
            base.WndProc(ref m);
        }
    }

    public class Account
    {
        private string accountName;
        private string accountUserName;
        private string accountSite;

        private bool usesBothCases;
        private bool usesNumbers;
        private bool usesSpecialCharacters;

        private int numCharacters;
        private int iteration;

        public Account()
        {
            usesBothCases = true;
            usesNumbers = true;
            usesSpecialCharacters = true;
        }

        public Account(string name, string user, string site, bool cases, bool numbers, bool characters, int chars, int i)
        {
            accountName = name;
            accountUserName = user;
            accountSite = site;

            usesBothCases = cases;
            usesNumbers = numbers;
            usesSpecialCharacters = characters;

            numCharacters = chars;
            iteration = i;
        }

        public bool loadData(string d)
        {
            string[] data = d.Split('‡');
            if(data.Length!=8)
            {
                accountName = "INVALID DATA";
                accountUserName = "INVALID DATA";
                accountSite = "INVALID DATA";

                usesBothCases = true;
                usesNumbers = true;
                usesSpecialCharacters = true;

                numCharacters = 16;
                iteration = 0;

                return false;
            }
            accountName = data[0];
            accountUserName = data[1];
            accountSite = data[2];

            usesBothCases = (data[3] == "Y");
            usesNumbers = (data[4] == "Y");
            usesSpecialCharacters = (data[5] == "Y");

            if (!Int32.TryParse(data[6], out numCharacters))
            {
                numCharacters = 12;
            }
            if (!Int32.TryParse(data[7], out iteration))
            {
                iteration = 0;
            }

            return true;
        }

        public string saveData()
        {
            return "\n" + accountName + '‡' + accountUserName + '‡' + accountSite + '‡' +
                (usesBothCases ? "Y" : "N") + '‡' + (usesNumbers ? "Y" : "N") + '‡' + (usesSpecialCharacters ? "Y" : "N") + '‡' +
                numCharacters + '‡' + iteration;
        }

        override public string ToString()
        {
            return accountName + " - " + accountUserName + " (" + accountSite + ")";
        }

        public void incIteration()
        {
            iteration++;
            if (iteration >= 12)
                iteration = 0;
        }

        public string getUser()
        {
            return accountUserName;
        }
        public string getName()
        {
            return accountName;
        }

        public string getSite()
        {
            return accountSite;
        }

        public bool usesCases()
        {
            return usesBothCases;
        }

        public bool usesSomeNumbers()
        {
            return usesNumbers;
        }

        public bool usesSpecial()
        {
            return usesSpecialCharacters;
        }

        public int getIteration()
        {
            return iteration;
        }
        
        public int getNumChars()
        {
            return numCharacters;
        }
    }
}