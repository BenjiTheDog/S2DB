namespace SimulateurBancaireGUI
{
    partial class FormBanquier
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNomBanquier;
        private TextBox txtMdpBanquier;
        private Button btnConnexionBanquier;
        private Label lblNomClient;
        private Label lblPrenomClient;
        private Label lblSoldeClient;
        private TextBox txtNouveauSolde;
        private Button btnModifierSolde;
        private DataGridView dgvMouvements;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtNomBanquier = new TextBox();
            this.txtMdpBanquier = new TextBox();
            this.btnConnexionBanquier = new Button();
            this.lblNomClient = new Label();
            this.lblPrenomClient = new Label();
            this.lblSoldeClient = new Label();
            this.txtNouveauSolde = new TextBox();
            this.btnModifierSolde = new Button();
            this.dgvMouvements = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)(this.dgvMouvements)).BeginInit();
            this.SuspendLayout();

            // txtNomBanquier
            this.txtNomBanquier.Location = new System.Drawing.Point(20, 20);
            this.txtNomBanquier.Name = "txtNomBanquier";
            this.txtNomBanquier.PlaceholderText = "Nom";
            this.txtNomBanquier.Size = new System.Drawing.Size(150, 23);

            // txtMdpBanquier
            this.txtMdpBanquier.Location = new System.Drawing.Point(20, 50);
            this.txtMdpBanquier.Name = "txtMdpBanquier";
            this.txtMdpBanquier.PasswordChar = '*';
            this.txtMdpBanquier.PlaceholderText = "Mot de passe";
            this.txtMdpBanquier.Size = new System.Drawing.Size(150, 23);

            // btnConnexionBanquier
            this.btnConnexionBanquier.Location = new System.Drawing.Point(180, 35);
            this.btnConnexionBanquier.Name = "btnConnexionBanquier";
            this.btnConnexionBanquier.Size = new System.Drawing.Size(100, 30);
            this.btnConnexionBanquier.Text = "Connexion";
            this.btnConnexionBanquier.Click += new System.EventHandler(this.btnConnexionBanquier_Click);

            // lblNomClient
            this.lblNomClient.Location = new System.Drawing.Point(20, 90);
            this.lblNomClient.Size = new System.Drawing.Size(300, 20);
            this.lblNomClient.Text = "Nom : ";

            // lblPrenomClient
            this.lblPrenomClient.Location = new System.Drawing.Point(20, 110);
            this.lblPrenomClient.Size = new System.Drawing.Size(300, 20);
            this.lblPrenomClient.Text = "Prénom : ";

            // lblSoldeClient
            this.lblSoldeClient.Location = new System.Drawing.Point(20, 130);
            this.lblSoldeClient.Size = new System.Drawing.Size(300, 20);
            this.lblSoldeClient.Text = "Solde : ";

            // txtNouveauSolde
            this.txtNouveauSolde.Location = new System.Drawing.Point(20, 160);
            this.txtNouveauSolde.Name = "txtNouveauSolde";
            this.txtNouveauSolde.PlaceholderText = "Nouveau solde";
            this.txtNouveauSolde.Size = new System.Drawing.Size(100, 23);

            // btnModifierSolde
            this.btnModifierSolde.Location = new System.Drawing.Point(130, 160);
            this.btnModifierSolde.Name = "btnModifierSolde";
            this.btnModifierSolde.Size = new System.Drawing.Size(100, 23);
            this.btnModifierSolde.Text = "Modifier solde";
            this.btnModifierSolde.Click += new System.EventHandler(this.btnModifierSolde_Click);

            // dgvMouvements
            this.dgvMouvements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMouvements.Columns.Add("Type", "Type");
            this.dgvMouvements.Columns.Add("Montant", "Montant");
            this.dgvMouvements.Columns.Add("Date", "Date");
            this.dgvMouvements.Location = new System.Drawing.Point(20, 200);
            this.dgvMouvements.Name = "dgvMouvements";
            this.dgvMouvements.RowTemplate.Height = 25;
            this.dgvMouvements.Size = new System.Drawing.Size(360, 150);

            // FormBanquier
            this.ClientSize = new System.Drawing.Size(400, 370);
            this.Controls.Add(this.txtNomBanquier);
            this.Controls.Add(this.txtMdpBanquier);
            this.Controls.Add(this.btnConnexionBanquier);
            this.Controls.Add(this.lblNomClient);
            this.Controls.Add(this.lblPrenomClient);
            this.Controls.Add(this.lblSoldeClient);
            this.Controls.Add(this.txtNouveauSolde);
            this.Controls.Add(this.btnModifierSolde);
            this.Controls.Add(this.dgvMouvements);
            this.Name = "FormBanquier";
            this.Text = "Espace Banquier";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMouvements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}