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
    public partial class LogIn : Form
    {
            DataClasses1DataContext DB = new DataClasses1DataContext();
        private bool Wahlen = true;

        public LogIn()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (Wahlen == true)
            {
                var cmd = from ad in DB.logpassadmins join adm in DB.adminstrateurs on ad.idlogpassAdmin equals adm.idlogpassAdmin where bunifuMaterialTextbox1.Text == ad.logwordAdmin && bunifuMaterialTextbox2.Text == ad.paswordAdmin select adm.nomAdmin;
                foreach (var aa in cmd)
                {
                    MessageBox.Show("Welcome " + bunifuMaterialTextbox1.Text + " !");
                  //  DashBoard dash = new DashBoard();
                  //  dash.ShowDialog();
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox2.Text = "";
                    timer1.Start();
                 //   label1.Text = frm2.Left.ToString();

                }
            }
            else
            {
                var cmd = from em in DB.logpasses join emp in DB.Employes on em.idlogpass equals emp.idlogpass where bunifuMaterialTextbox1.Text == em.logword && bunifuMaterialTextbox2.Text == em.pasword select emp.NomEmploye;
                foreach (var aa in cmd)
                {
                    MessageBox.Show("Welcome " + bunifuMaterialTextbox1.Text + " !");
             //       DashBoard dash = new DashBoard();
         //           dash.ShowDialog();
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox2.Text = "";
                    timer1.Start();
      //              label1.Text = frm2.Left.ToString();

                }
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
