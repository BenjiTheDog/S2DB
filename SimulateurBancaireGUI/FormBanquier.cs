using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SimulateurBancaireGUI
{
    public partial class FormBanquier : Form
    {
        private int clientId;
        private string connectionString = "server=localhost;user=root;database=distribank;port=3306;password=";

        public FormBanquier()
        {
            InitializeComponent();
        }

        private void btnConnexionBanquier_Click(object sender, EventArgs e)
        {
            string nom = txtNomBanquier.Text;
            string mdp = txtMdpBanquier.Text;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT id_client FROM banquier WHERE nom = @nom AND mdp = @mdp";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@mdp", mdp);

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    clientId = Convert.ToInt32(result);
                    ChargerInfosClient();
                    ChargerMouvements();
                }
                else
                {
                    MessageBox.Show("Identifiants incorrects.");
                }
            }
        }

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

        private void btnModifierSolde_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNouveauSolde.Text, out int nouveauSolde))
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE user SET solde = @solde WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@solde", nouveauSolde);
                    cmd.Parameters.AddWithValue("@id", clientId);
                    cmd.ExecuteNonQuery();

                    string log = "INSERT INTO mouvements (id_user, type_operation, montant) VALUES (@id, 'Modification (banquier)', @montant)";
                    MySqlCommand logCmd = new MySqlCommand(log, conn);
                    logCmd.Parameters.AddWithValue("@id", clientId);
                    logCmd.Parameters.AddWithValue("@montant", nouveauSolde);
                    logCmd.ExecuteNonQuery();
                }

                ChargerInfosClient();
                ChargerMouvements();
                txtNouveauSolde.Text = "";
                MessageBox.Show("Solde modifié.");
            }
            else
            {
                MessageBox.Show("Entrez un montant valide.");
            }
        }
    }
}