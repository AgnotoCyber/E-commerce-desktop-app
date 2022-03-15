using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4___EcrivainsDeconnecteCode
{
    public partial class ImprimerBon : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ImprimerBon()
        {
            InitializeComponent();
        }

        private void ImprimerBon_Load(object sender, EventArgs e)
        {

        }

        private void bunifuDatepicker1_onValueChanged(object sender, EventArgs e)
        {
            var ti = from tD in db.BonLivraisons
                     where (bunifuDatepicker1.Value == tD.Date_bon_livraison)
                     select new { Nom = tD.Nom_bon_livraison, Date = tD.Date_bon_livraison, NbrColis = tD.Nombre_colis };

            bunifuCustomDataGrid1.DataSource = ti;

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            AjouterBon ajtbon = new AjouterBon();
            ajtbon.ShowDialog();
        }
    }
}
