using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4___EcrivainsDeconnecteCode
{
    public partial class AffichageDeLivreur : Form
    {

        DataSet ds = new DataSet();
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.Gestion_EntrepriseConnectionString);

        SqlCommand vil = new SqlCommand();
        SqlCommand liv = new SqlCommand();
        SqlCommand cmd = new SqlCommand();

        SqlDataAdapter da_vil;
        SqlDataAdapter da_liv;
        SqlDataAdapter da_cmd;

        BindingSource bs_vil = new BindingSource();
        BindingSource bs_liv = new BindingSource();
        BindingSource bs_cmd = new BindingSource();
        public AffichageDeLivreur()
        {
            InitializeComponent();
        }

        private void AffichageDeLivreur_Load(object sender, EventArgs e)
        {

            cn.Open();

            vil.CommandText = "select * from ville";
            liv.CommandText = "select * from livreur";
            cmd.CommandText = "select c.idCommande,cl.NomComplet, c.DateCommande,c.StatutCommande,c.Commentaire ,cl.idVille from commande c inner join Client cl on c.idClient = cl.idClient ";

            vil.Connection = cn;
            liv.Connection = cn;
            cmd.Connection = cn;

            da_vil = new SqlDataAdapter(vil);
            da_vil.Fill(ds, "ville");

            da_liv = new SqlDataAdapter(liv);
            da_liv.Fill(ds, "livreur");

            da_cmd = new SqlDataAdapter(cmd);
            da_cmd.Fill(ds, "Commande");
            //relation entre livreur et Ville
            DataColumn c1 = ds.Tables["Livreur"].Columns["idVille"];
            DataColumn c2 = ds.Tables["Ville"].Columns["idVille"];
            DataRelation r1 = new DataRelation("fk_Livreur_ville", c2, c1);
            ds.Relations.Add(r1);
            //relation entre commande et ville
            DataColumn c3 = ds.Tables["Ville"].Columns["idVille"];
            DataColumn c4 = ds.Tables["Commande"].Columns["idVille"];
            DataRelation r2 = new DataRelation("fk_ville_Commande", c3, c4);
            ds.Relations.Add(r2);

            //Remplir ComboBox
            bs_vil.DataSource = ds;
            bs_vil.DataMember = "ville";
            comboBox1.DataSource = bs_vil;
            comboBox1.DisplayMember = "NomVille";
            comboBox1.ValueMember = "idVille";
            //remplir text
            bs_liv.DataSource = bs_vil;
            bs_liv.DataMember = "fk_Livreur_ville";
            bunifuMetroTextbox1.DataBindings.Add("text", bs_liv, "NomComplet");
            bunifuMetroTextbox4.DataBindings.Add("text", bs_liv, "telephoneLivreur");
            bunifuMetroTextbox3.DataBindings.Add("text", bs_liv, "AdresseLivreur");
            //remplir datagrid

            bs_cmd.DataSource = bs_vil;
            bs_cmd.DataMember = "fk_ville_Commande";

            bunifuCustomDataGrid1.DataSource = bs_cmd;

            bunifuCustomDataGrid1.Columns[5].Visible = false;

        }
    }
}
