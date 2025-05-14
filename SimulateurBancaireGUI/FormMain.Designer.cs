namespace SimulateurBancaireGUI
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnClient;
        private System.Windows.Forms.Button btnBanquier;

        private void InitializeComponent()
        {
            this.btnClient = new System.Windows.Forms.Button();
            this.btnBanquier = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // btnClient
            this.btnClient.Name = "btnClient";
            this.btnClient.Text = "Connexion Client";
            this.btnClient.Location = new System.Drawing.Point(50, 30);
            this.btnClient.Size = new System.Drawing.Size(150, 40);
            this.btnClient.Click += new System.EventHandler(this.btnClient_Click);

            // btnBanquier
            this.btnBanquier.Name = "btnBanquier";
            this.btnBanquier.Text = "Connexion Banquier";
            this.btnBanquier.Location = new System.Drawing.Point(50, 90);
            this.btnBanquier.Size = new System.Drawing.Size(150, 40);
            this.btnBanquier.Click += new System.EventHandler(this.btnBanquier_Click);

            // FormMain
            this.ClientSize = new System.Drawing.Size(250, 170);
            this.Controls.Add(this.btnClient);
            this.Controls.Add(this.btnBanquier);
            this.Name = "FormMain";
            this.Text = "Accueil Banque";
            this.ResumeLayout(false);
        }
    }
}
