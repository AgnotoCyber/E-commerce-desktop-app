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
    public partial class AfichageDeProduit : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        DataSet ds = new DataSet();
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.Gestion_EntrepriseConnectionString);
        ///Produit
        SqlCommand cmdProduit = new SqlCommand();
        SqlDataAdapter dataPr;
        BindingSource bsPr = new BindingSource();
        ///Commande
        SqlCommand cmdCom = new SqlCommand();
        SqlDataAdapter dataCom;
        BindingSource BsCmd = new BindingSource();

        public AfichageDeProduit()
        {
            InitializeComponent();
        }

        private void AfichageDeProduit_Load(object sender, EventArgs e)
        {
            cn.Open();
            //commande
            cmdProduit.CommandText = "select distinct * from Produit";
            cmdCom.CommandText = "select cl.idClient,c.idCommande ,cl.NomComplet as 'Client',p.idProduit,p.prixReel as 'Prix',c.DateCommande,c.StatutCommande from Commande c inner join Produit p on c.idProduit=p.idProduit  inner join Client cl on c.idClient = cl.idClient ";
            //SQL Commande
            cmdProduit.Connection = cn;
            cmdCom.Connection = cn;
            //Adapter
            dataCom = new SqlDataAdapter(cmdCom);
            dataCom.Fill(ds, "Commande");
            dataPr = new SqlDataAdapter(cmdProduit);
            dataPr.Fill(ds, "Produit");

            ///relation 
            DataColumn c1 = ds.Tables["Produit"].Columns["idProduit"];
            DataColumn c2 = ds.Tables["Commande"].Columns["idProduit"];
            DataRelation r1 = new DataRelation("fk_pr_cm", c1, c2);
            ds.Relations.Add(r1);
            //charge Bindiging source
            bsPr.DataSource = ds;
            bsPr.DataMember = "Produit";

            BsCmd.DataSource = bsPr;
            BsCmd.DataMember = "fk_pr_cm";

            //ListBox
            listBox1.DataSource = bsPr;
            listBox1.DisplayMember = "Designation";
            listBox1.ValueMember = "idProduit";

            //DataGV
            bunifuCustomDataGrid1.DataSource = BsCmd;
            bunifuCustomDataGrid1.Columns[0].Visible = false;
            bunifuCustomDataGrid1.Columns[3].Visible = false;
            //TextBox
            bunifuMetroTextbox1.DataBindings.Add("text", bsPr, "Designation");
            bunifuMetroTextbox2.DataBindings.Add("text", bsPr, "prixReel");
            bunifuMetroTextbox3.DataBindings.Add("text", bsPr, "Quantite");

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

            bunifuMetroTextbox1.Enabled = true;
            bunifuMetroTextbox2.Enabled = true;
            bunifuMetroTextbox3.Enabled = true;
            bunifuThinButton22.Visible = true;
        }
    }
}
