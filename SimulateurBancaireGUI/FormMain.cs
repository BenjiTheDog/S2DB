using System;
using System.Windows.Forms;

namespace SimulateurBancaireGUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            FormClient formClient = new FormClient();
            formClient.Show();
        }

        private void btnBanquier_Click(object sender, EventArgs e)
        {
            FormBanquier formBanquier = new FormBanquier();
            formBanquier.Show();
        }
    }
}