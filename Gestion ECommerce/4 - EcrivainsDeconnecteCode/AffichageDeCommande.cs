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
    public partial class AffichageDeCommande : Form

    {
        DataSet ds = new DataSet();
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.Gestion_EntrepriseConnectionString);
        //   SqlConnection cn = new SqlConnection("Server=localhost,Authentication=Windows Authentication, Database=Gestion_Entreprise");
        SqlCommand sqlcom = new SqlCommand();
        SqlDataAdapter sqldatad;
        BindingSource bindsrc = new BindingSource();
        SqlCommandBuilder sqlcommbuild;
        public AffichageDeCommande()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            bunifuCustomDataGrid1.Visible = true;
        }

        private void AffichageDeCommande_Load(object sender, EventArgs e)
        {
            sqlcom.CommandText = "Select *from Commande where DateCommande between " + bunifuDatepicker1.Value.ToShortTimeString() + " and " + bunifuDatepicker2.Value.ToShortTimeString();
            sqlcom.Connection = cn;
            sqldatad = new SqlDataAdapter(sqlcom);
            sqldatad.Fill(ds, "Commande");
            bindsrc.DataSource = ds;
            bindsrc.DataMember = "Commande";
            bunifuCustomDataGrid1.DataSource = bindsrc;
        }
    }
}
