using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4___EcrivainsDeconnecteCode
{
    public partial class DashBoard : Form
    {

        public DashBoard()
        {
            InitializeComponent();
            hide_panels();


        }
        //
        private void hide_panels()
        {
            panel_commande.Visible = false;
            panel_employe.Visible = false;
            panel_livreur.Visible = false;
            panel_produit.Visible = false;
        }
        private void hideMenu()
        {
            if (panel_commande.Visible == true)
                panel_commande.Visible = false;
            if (panel_employe.Visible == true)
                panel_employe.Visible = false;
            if (panel_livreur.Visible == true)
                panel_livreur.Visible = false;
            if (panel_produit.Visible == true)
                panel_produit.Visible = false;
        }
        private void showMenu(Panel Menu)
        {
            if (Menu.Visible == false)
            {
                hideMenu();
                Menu.Visible = true;
            }
            else
                Menu.Visible = false;
        }


        private void panel_left_lijam3om_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void btn_Commande_Click(object sender, EventArgs e)
        {
          
            panel_open_Forms(new AffichageCommande());
            showMenu(panel_commande);
        }

        private void btn_commande_modifier_Click(object sender, EventArgs e)
        {
            panel_open_Forms(new ModifierCommand());
            // code

            hideMenu();
        }

        private void btn_produit_Click(object sender, EventArgs e)
        {
            panel_open_Forms(new AfichageDeProduit());
            showMenu(panel_produit);
        }

        private void btn_livreur_Click(object sender, EventArgs e)
        {
            panel_open_Forms(new AffichageDeLivreur());
            showMenu(panel_livreur);
        }

        private void btn_employe_Click(object sender, EventArgs e)
        {
            showMenu(panel_employe);
        }

        private void btn_commande_statistique_Click(object sender, EventArgs e)
        {
            hideMenu();
        }

        private void btn_commande_ImprimerBon_Click(object sender, EventArgs e)
        {
            panel_open_Forms(new ImprimerBon());
            hideMenu();
        }

        private void btn_produit_modifier_Click(object sender, EventArgs e)
        {
            hideMenu();
        }

        private void btn_produit_statistique_Click(object sender, EventArgs e)
        {
            hideMenu();
        }

        private void btn_livreur_modifier_Click(object sender, EventArgs e)
        {
            hideMenu();
        }

        private void btn_livreur_statistique_Click(object sender, EventArgs e)
        {
            hideMenu();
        }

        private void btn_employe_modifier_Click(object sender, EventArgs e)
        {
            hideMenu();
        }

        private void btn_employe_statistique_Click(object sender, EventArgs e)
        {
            hideMenu();
        }

        private Form activeForm = null;
        private void panel_open_Forms(Form Form_open)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = Form_open;
            Form_open.TopLevel = false;
            Form_open.FormBorderStyle = FormBorderStyle.None;
            Form_open.Dock = DockStyle.Fill;
            panel_westani.Controls.Add(Form_open);
            panel_westani.Tag = Form_open;
            Form_open.BringToFront();
            Form_open.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_fo9ani_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_westani_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
