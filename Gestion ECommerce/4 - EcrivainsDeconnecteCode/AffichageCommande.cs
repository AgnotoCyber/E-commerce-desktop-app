using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _4___EcrivainsDeconnecteCode
{
    public partial class AffichageCommande : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public AffichageCommande()
        {
            InitializeComponent();
        }

        private void AffichageCommande_Load(object sender, EventArgs e)
        {
            var cmn = from c in db.Commandes
                      join cl in db.Clients on c.idClient equals cl.idClient
                      join pr in db.Produits on c.idProduit equals pr.idProduit
                      join tr in db.Transports on c.idTransport equals tr.idTransport
                      join sc in db.SocietéLivraisons on tr.idSocietéLivraison equals sc.idSocietéLivraison
                      join vi in db.Villes on c.idVille equals vi.idVille
                      select new { c.idCommande, cl.NomComplet, vi.NomVille, pr.Designation, pr.prixReel, c.StatutCommande };
            bunifuCustomDataGrid1.DataSource = cmn;

            ///Chiffre d'affaire
            var Chiff = from o in db.Commandes
                        join pr in db.Produits on o.idProduit equals pr.idProduit
                        select pr.prixReel;
            Chiff.Sum();
            label2.Text = Chiff.Sum().ToString() + " DH";
            ///Livre
            var CMDLivre = from c in db.Commandes
                           where c.StatutCommande == "Livre"
                           where c.DateCommande == bunifuDatepicker1.Value
                           select c.idCommande;
            CMDLivre.Count();
            label4.Text = CMDLivre.Count().ToString();
            ///Return
            var CMDReturn = from c in db.Commandes
                            where c.StatutCommande == "Retourne"
                            where c.DateCommande == bunifuDatepicker1.Value
                            select c.idCommande;
            CMDReturn.Count();
            label1.Text = CMDReturn.Count().ToString();

            //Chart-Filling
            //       DateTime calendar0 = DateTime.Now;
            //       DateTime calendar = DateTime.Now;
            //       DateTime calendar1 = DateTime.Now.AddDays(-7);
            //       DateTime calendar2 = DateTime.Now.AddDays(-6);
            //       DateTime calendar3 = DateTime.Now.AddDays(-5);
            //       DateTime calendar4 = DateTime.Now.AddDays(-4);
            //       DateTime calendar5 = DateTime.Now.AddDays(-3);
            //       DateTime calendar6 = DateTime.Now.AddDays(-2);
            //       DateTime calendar7 = DateTime.Now.AddDays(-1);

            //       string[] seriesArray = { "Command_Flow" };
            //       int[] pointsArray = {1,2,3,4,5,6,7};
            //       this.chart1.Palette = ChartColorPalette.Grayscale;
            //       this.chart1.Titles.Add(" hebdomadaire de cadence de commande ");



            ////       s.ChartType = SeriesChartType.Spline;
            //       for (int i = 7; i <= 0; i--)
            //       {
            //           Series s = chart1.Series.Add("Commande_Flow");
            //           string cmd = "select count(idCommande) from Commande where DateCommande like " + calendar + i;
            //           s.Points.AddXY(calendar.AddDays(-i), cmd);
            //           s.Points.Add(pointsArray[i]);

            //LINQ
            //var kart = (from k in db.Commande where k.DateCommande.Equals(bunifuDatepicker1.Value.ToShortTimeString()) select k.idCommande).Count();
            //this.chart1.DataSource = kart;
            //for (int i = 1; i >= 7; i++)
            //{ 
            //    this.chart1.Series[i].XValueMember = ""+i ;
            //    this.chart1.Series[i].YValueMembers = ""+kart;
            //    this.chart1.DataBind();

            //}

            DataPoint Dp = new DataPoint();
            Dp.SetValueY(5);
            chart1.Series.Add("ComandFlow");
            chart1.Series[0].Points.Add(Dp);
            chart1.Series["My Data"].Points.Add(Dp);

            Dp.SetValueY(3);
            chart1.Series["ComandFlow"].Points.Add(Dp);
            Dp.SetValueY(4);

        }
    }
}
