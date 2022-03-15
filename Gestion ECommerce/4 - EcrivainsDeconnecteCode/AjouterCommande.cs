using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;


namespace _4___EcrivainsDeconnecteCode
{
    public partial class AjouterCommande : Form
    {

        DataSet ds = new DataSet();
        //       SqlConnection cn = new SqlConnection(@"data source=.\testexpress; initial catalog=librairie;integrated security=true;");

        //SqlConnection cn = new SqlConnection("Data Source = KAJERO-PC\SQLEXPRESS; Initial Catalog = Gestion_Entreprise; Integrated Security = True");
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.Gestion_EntrepriseConnectionString);
        SqlCommand com =    new SqlCommand();
        SqlDataAdapter da; 
        BindingSource bs = new BindingSource();
        SqlCommandBuilder cb;

        //ProduitStuff
        SqlCommand cmdproduit = new SqlCommand();
        SqlDataAdapter datpoduit;
        BindingSource bsproduit = new BindingSource();



        public AjouterCommande()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           cn.Open();
           com.CommandText = "select * from Ville";
           com.Connection = cn;
           da = new SqlDataAdapter(com);
           da.Fill(ds, "Ville");
           cb = new SqlCommandBuilder(da);
        
           bs.DataSource = ds;
           bs.DataMember = "Ville";
         

           comboBox1.DataSource = bs;
           comboBox1.DisplayMember = "NomVille";
           comboBox1.ValueMember = "idVille";
            //Products 

            //cmdproduit.CommandText = "select Designation from Produit ";
            //cmdproduit.Connection = cn;
            //datpoduit = new SqlDataAdapter(cmdproduit);
            //datpoduit.Fill(ds, "Commande");
            //bsproduit.DataSource = ds;
            //bsproduit.DataMember = "Produit";

            //comboBox2.DataSource = bsproduit;
            //comboBox2.DisplayMember = "Designation";
            //comboBox2.ValueMember = "idProduit";




        }

        private void btnDernier_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
           
        }

        private void btnPremier_Click(object sender, EventArgs e)
        {
            bs.MoveFirst();
        }

        private void ntnEnregistrer_Click(object sender, EventArgs e)
        {
          
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            da.Update(ds.Tables["ecrivain"]);
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }
    }
}
