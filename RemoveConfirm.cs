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
    public partial class RemoveConfirm : Form
    {
        private Button ok;
        private Button cancel;
        private Label messageText;
        private Label messageSubText;

        private MainWindow main;


        public RemoveConfirm(MainWindow m)
        {
            main = m;
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            main.RemoveAccount();
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
