namespace SimulateurBancaireGUI
{
    partial class FormClient
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtCodeClient;
        private Button btnConnexionClient;
        private Label lblNomClient;
        private Label lblPrenomClient;
        private Label lblSoldeClient;
        private DataGridView dgvMouvements;
        private Panel panelClient;
        private Button btnRetirer;
        private Button btnDeposer;
        private TextBox txtMontant;
        private Label lblMontant;
        private Panel panelConnexion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelConnexion = new Panel();
            txtCodeClient = new TextBox();
            btnConnexionClient = new Button();
            panelClient = new Panel();
            lblNomClient = new Label();
            lblPrenomClient = new Label();
            lblSoldeClient = new Label();
            dgvMouvements = new DataGridView();
            txtMontant = new TextBox();
            lblMontant = new Label();
            btnRetirer = new Button();
            btnDeposer = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            panelConnexion.SuspendLayout();
            panelClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMouvements).BeginInit();
            SuspendLayout();
            // 
            // panelConnexion
            // 
            panelConnexion.Controls.Add(txtCodeClient);
            panelConnexion.Controls.Add(btnConnexionClient);
            panelConnexion.Dock = DockStyle.Fill;
            panelConnexion.Location = new Point(0, 0);
            panelConnexion.Name = "panelConnexion";
            panelConnexion.Size = new Size(400, 500);
            panelConnexion.TabIndex = 1;
            // 
            // txtCodeClient
            // 
            txtCodeClient.Location = new Point(20, 20);
            txtCodeClient.Name = "txtCodeClient";
            txtCodeClient.PlaceholderText = "Code client";
            txtCodeClient.Size = new Size(150, 23);
            txtCodeClient.TabIndex = 0;
            // 
            // btnConnexionClient
            // 
            btnConnexionClient.Location = new Point(180, 20);
            btnConnexionClient.Name = "btnConnexionClient";
            btnConnexionClient.Size = new Size(100, 30);
            btnConnexionClient.TabIndex = 1;
            btnConnexionClient.Text = "Connexion";
            btnConnexionClient.Click += btnConnexionClient_Click;
            // 
            // panelClient
            // 
            panelClient.Controls.Add(lblNomClient);
            panelClient.Controls.Add(lblPrenomClient);
            panelClient.Controls.Add(lblSoldeClient);
            panelClient.Controls.Add(dgvMouvements);
            panelClient.Controls.Add(txtMontant);
            panelClient.Controls.Add(lblMontant);
            panelClient.Controls.Add(btnRetirer);
            panelClient.Controls.Add(btnDeposer);
            panelClient.Location = new Point(0, 0);
            panelClient.Name = "panelClient";
            panelClient.Size = new Size(373, 497);
            panelClient.TabIndex = 0;
            panelClient.Visible = false;
            // 
            // lblNomClient
            // 
            lblNomClient.Location = new Point(20, 70);
            lblNomClient.Name = "lblNomClient";
            lblNomClient.Size = new Size(100, 23);
            lblNomClient.TabIndex = 0;
            lblNomClient.Text = "Nom : ";
            // 
            // lblPrenomClient
            // 
            lblPrenomClient.Location = new Point(20, 90);
            lblPrenomClient.Name = "lblPrenomClient";
            lblPrenomClient.Size = new Size(100, 23);
            lblPrenomClient.TabIndex = 1;
            lblPrenomClient.Text = "Prénom : ";
            // 
            // lblSoldeClient
            // 
            lblSoldeClient.Location = new Point(20, 110);
            lblSoldeClient.Name = "lblSoldeClient";
            lblSoldeClient.Size = new Size(100, 23);
            lblSoldeClient.TabIndex = 2;
            lblSoldeClient.Text = "Solde : ";
            // 
            // dgvMouvements
            // 
            dgvMouvements.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dgvMouvements.Location = new Point(20, 150);
            dgvMouvements.Name = "dgvMouvements";
            dgvMouvements.Size = new Size(300, 150);
            dgvMouvements.TabIndex = 3;
            // 
            // txtMontant
            // 
            txtMontant.Location = new Point(100, 320);
            txtMontant.Name = "txtMontant";
            txtMontant.Size = new Size(100, 23);
            txtMontant.TabIndex = 4;
            // 
            // lblMontant
            // 
            lblMontant.Location = new Point(20, 320);
            lblMontant.Name = "lblMontant";
            lblMontant.Size = new Size(100, 23);
            lblMontant.TabIndex = 5;
            lblMontant.Text = "Montant : ";
            // 
            // btnRetirer
            // 
            btnRetirer.Location = new Point(20, 360);
            btnRetirer.Name = "btnRetirer";
            btnRetirer.Size = new Size(75, 23);
            btnRetirer.TabIndex = 6;
            btnRetirer.Text = "Retirer";
            btnRetirer.Click += btnRetirer_Click;
            // 
            // btnDeposer
            // 
            btnDeposer.Location = new Point(130, 360);
            btnDeposer.Name = "btnDeposer";
            btnDeposer.Size = new Size(75, 23);
            btnDeposer.TabIndex = 7;
            btnDeposer.Text = "Déposer";
            btnDeposer.Click += btnDeposer_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Type";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Montant";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Date";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // FormClient
            // 
            ClientSize = new Size(400, 500);
            Controls.Add(panelClient);
            Controls.Add(panelConnexion);
            Name = "FormClient";
            Text = "Client - Application bancaire";
            panelConnexion.ResumeLayout(false);
            panelConnexion.PerformLayout();
            panelClient.ResumeLayout(false);
            panelClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMouvements).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}