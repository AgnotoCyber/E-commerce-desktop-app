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
    public partial class ModifierCommand : Form
    {

        DataSet datset = new DataSet();
        SqlConnection cn = new SqlConnection(Properties.Settings.Default.Gestion_EntrepriseConnectionString);
        SqlCommand sqlcom = new SqlCommand();
        SqlDataAdapter sqldatad;
        BindingSource bindsrc = new BindingSource();
        SqlCommandBuilder cb;


        SqlCommand com = new SqlCommand();
        SqlDataAdapter da;
        BindingSource bs = new BindingSource();
        public ModifierCommand()
        {
            InitializeComponent();
        }

        private void ModifierCommand_Load(object sender, EventArgs e)
        {
            cn.Open();
            com.CommandText = "select * from Ville";
            com.Connection = cn;
            da = new SqlDataAdapter(com);
            da.Fill(datset, "Ville");
            cb = new SqlCommandBuilder(da);

            bs.DataSource = datset;
            bs.DataMember = "Ville";


            comboBox1.DataSource = bs;
            comboBox1.DisplayMember = "NomVille";
            comboBox1.ValueMember = "idVille";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Vous etes sure ? ", "Add new Command !!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sqldatad.Fill(datset);
                try
                {
                    bindsrc.AddNew();
                    sqldatad.Update(datset.Tables["Commande"]);
                   
                  
                }
                catch { MessageBox.Show("Remplir tous les champs ", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
            }
        }
    }
}
