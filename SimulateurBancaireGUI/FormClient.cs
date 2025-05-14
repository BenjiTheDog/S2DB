using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulateurBancaireGUI
{
    public partial class FormClient : Form
    {
        private int clientId;
        private string connectionString = "server=localhost;user=root;database=distribank;port=3306;password=";

        public FormClient()
        {
            InitializeComponent();
        }

        // Connexion client
        private void btnConnexionClient_Click(object sender, EventArgs e)
        {
            string code = txtCodeClient.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id FROM user WHERE code = @code";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@code", code);

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    clientId = Convert.ToInt32(result);
                    ChargerInfosClient();
                    ChargerMouvements();
                    panelClient.Visible = true;
                    panelConnexion.Visible = false;
                }
                else
                {
                    MessageBox.Show("Code client incorrect.");
                }
            }
        }

        // Charger les informations du client
        private void ChargerInfosClient()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT nom, prenom, solde FROM user WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", clientId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblNomClient.Text = reader.GetString("nom");
                        lblPrenomClient.Text = reader.GetString("prenom");
                        lblSoldeClient.Text = reader.GetInt32("solde") + " €";
                    }
                }
            }
        }

        // Charger les mouvements du client
        private void ChargerMouvements()
        {
            dgvMouvements.Rows.Clear();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT type_operation, montant, date_operation FROM mouvements WHERE id_user = @id ORDER BY date_operation DESC";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", clientId);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvMouvements.Rows.Add(
                            reader.GetString("type_operation"),
                            reader.GetInt32("montant"),
                            reader.GetDateTime("date_operation").ToString("g")
                        );
                    }
                }
            }
        }

        // Retirer de l'argent
        private void btnRetirer_Click(object sender, EventArgs e)
        {
            int montant = Convert.ToInt32(txtMontant.Text);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string querySolde = "SELECT solde FROM user WHERE id = @id";
                    MySqlCommand cmdSolde = new MySqlCommand(querySolde, conn);
                    cmdSolde.Parameters.AddWithValue("@id", clientId);
                    int soldeActuel = Convert.ToInt32(cmdSolde.ExecuteScalar());

                    if (soldeActuel >= montant)
                    {
                        // Mise à jour du solde
                        string queryRetrait = "UPDATE user SET solde = solde - @montant WHERE id = @id";
                        MySqlCommand cmdRetrait = new MySqlCommand(queryRetrait, conn);
                        cmdRetrait.Parameters.AddWithValue("@montant", montant);
                        cmdRetrait.Parameters.AddWithValue("@id", clientId);
                        cmdRetrait.ExecuteNonQuery();

                        // Enregistrer le mouvement
                        string queryMouvement = "INSERT INTO mouvements (id_user, type_operation, montant) VALUES (@id, 'Retrait', @montant)";
                        MySqlCommand cmdMouvement = new MySqlCommand(queryMouvement, conn);
                        cmdMouvement.Parameters.AddWithValue("@id", clientId);
                        cmdMouvement.Parameters.AddWithValue("@montant", montant);
                        cmdMouvement.ExecuteNonQuery();

                        // Commit
                        transaction.Commit();

                        MessageBox.Show("Retrait effectué avec succès.");
                        ChargerInfosClient();
                        ChargerMouvements();
                    }
                    else
                    {
                        MessageBox.Show("Solde insuffisant.");
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erreur lors du retrait : " + ex.Message);
                }
            }
        }

        // Déposer de l'argent
        private void btnDeposer_Click(object sender, EventArgs e)
        {
            int montant = Convert.ToInt32(txtMontant.Text);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Mise à jour du solde
                    string queryDepot = "UPDATE user SET solde = solde + @montant WHERE id = @id";
                    MySqlCommand cmdDepot = new MySqlCommand(queryDepot, conn);
                    cmdDepot.Parameters.AddWithValue("@montant", montant);
                    cmdDepot.Parameters.AddWithValue("@id", clientId);
                    cmdDepot.ExecuteNonQuery();

                    // Enregistrer le mouvement
                    string queryMouvement = "INSERT INTO mouvements (id_user, type_operation, montant) VALUES (@id, 'Dépôt', @montant)";
                    MySqlCommand cmdMouvement = new MySqlCommand(queryMouvement, conn);
                    cmdMouvement.Parameters.AddWithValue("@id", clientId);
                    cmdMouvement.Parameters.AddWithValue("@montant", montant);
                    cmdMouvement.ExecuteNonQuery();

                    // Commit
                    transaction.Commit();

                    MessageBox.Show("Dépôt effectué avec succès.");
                    ChargerInfosClient();
                    ChargerMouvements();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Erreur lors du dépôt : " + ex.Message);
                }
            }
        }
    }
}