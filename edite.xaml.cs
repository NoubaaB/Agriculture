using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyAgriculture
{
    /// <summary>
    /// Interaction logic for edite.xaml
    /// </summary>
    public partial class edite : Window
    {
        DBagricultureEntities db = new DBagricultureEntities();
        int idGlobal = 0;
        public edite(int id)
        {
            InitializeComponent();
            idGlobal = id;
            if (AllDataBases.name=="Engrais")
            {
             nomCombo.ItemsSource = (from s in db.engrais select s.nom).ToArray();
            tailleCombo.ItemsSource = (from s in db.Pesticides select s.Taille).ToArray();
            nomCombo.SelectedItem = (from s in db.engrais where s.id == id select s.nom).First().ToString();
            tailleCombo.SelectedItem = (from s in db.engrais where s.id == id select s.Taille).First();
            prixText.Text = (from s in db.prixes where s.NomEquip == nomCombo.Text select s.Prix1).First().ToString();
               
            }
            if (AllDataBases.name=="Irrigation")
            {
             nomCombo.ItemsSource = (from s in db.Irrigations select s.nom).ToArray();
            tailleCombo.ItemsSource = (from s in db.Irrigations select s.Taille).ToArray();
            nomCombo.SelectedItem = (from s in db.Irrigations where s.id == id select s.nom).First().ToString();
            tailleCombo.SelectedItem = (from s in db.Irrigations where s.id == id select s.Taille).First();
            prixText.Text = (from s in db.prixes where s.NomEquip == nomCombo.Text select s.Prix1).First().ToString();
               
            }
            if (AllDataBases.name=="Pesticides")
            {
            nomCombo.ItemsSource = (from s in db.Pesticides select s.nom).ToArray();
            tailleCombo.ItemsSource = (from s in db.Pesticides select s.Taille).ToArray();
            nomCombo.SelectedItem = (from s in db.Pesticides where s.id == id select s.nom).First().ToString();
            tailleCombo.SelectedItem = (from s in db.Pesticides where s.id == id select s.Taille).First();
            prixText.Text = (from s in db.prixes where s.NomEquip == nomCombo.Text select s.Prix1).First().ToString();
            }
            nomCombo.SelectionChanged +=nomCombo_SelectionChanged;
            // hado ghadi ikono fkol forms
            #region:myStaticForm
            this.MouseDown += MainWindow_MouseDown;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
        }

        void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

            #endregion
                //End Region :forms

        private void quantiteText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void modifier_Click(object sender, RoutedEventArgs e)
        {
            if (AllDataBases.name == "Engrais")
            {
                engrai pp = (from s in db.engrais where s.id == idGlobal select s).Single();
                pp.nom = nomCombo.Text == string.Empty ? pp.nom : nomCombo.Text;
                pp.Prix = prixText.Text == string.Empty ? pp.Prix : Convert.ToSingle(prixText.Text);
                pp.Quantite = quantiteText.Text == string.Empty ? pp.Quantite : Convert.ToInt16(quantiteText.Text);
                pp.Taille = tailleCombo.Text == string.Empty ? pp.Taille : Convert.ToSingle(tailleCombo.Text);
                pp.descript = descriptionText.Text == string.Empty ? pp.descript : descriptionText.Text;
                pp.Date_D__Ajoute = DateTime.Now;
                db.SaveChanges();
                AllDataBases.AlldataGrid.ItemsSource = (from s in db.engrais select s).ToList();
                this.Close();
                return;
            }
            if (AllDataBases.name == "Irrigation")
            {
                Irrigation pp = (from s in db.Irrigations where s.id == idGlobal select s).Single();
                pp.nom = nomCombo.Text == string.Empty ? pp.nom : nomCombo.Text;
                pp.Prix = prixText.Text == string.Empty ? pp.Prix : Convert.ToSingle(prixText.Text);
                pp.Quantite = quantiteText.Text == string.Empty ? pp.Quantite : Convert.ToInt16(quantiteText.Text);
                pp.Taille = tailleCombo.Text == string.Empty ? pp.Taille : Convert.ToSingle(tailleCombo.Text);
                pp.descript = descriptionText.Text == string.Empty ? pp.descript : descriptionText.Text;
                pp.Date_D__Ajoute = DateTime.Now;
                db.SaveChanges();
                AllDataBases.AlldataGrid.ItemsSource = (from s in db.Irrigations select s).ToList();
                this.Close();
                return;
            }
            if (AllDataBases.name == "Pesticides")
            {
                Pesticide pp = (from s in db.Pesticides where s.id == idGlobal select s).Single();
                pp.nom = nomCombo.Text == string.Empty ? pp.nom : nomCombo.Text;
                pp.Prix = prixText.Text == string.Empty ? pp.Prix : Convert.ToSingle(prixText.Text);
                pp.Quantite = quantiteText.Text == string.Empty ? pp.Quantite : Convert.ToInt16(quantiteText.Text);
                pp.Taille = tailleCombo.Text == string.Empty ? pp.Taille : Convert.ToSingle(tailleCombo.Text);
                pp.descript = descriptionText.Text == string.Empty ? pp.descript : descriptionText.Text;
                pp.Date_D__Ajoute = DateTime.Now;
                db.SaveChanges();
                AllDataBases.AlldataGrid.ItemsSource = (from s in db.Pesticides select s).ToList();
                this.Close();
                return;
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void nomCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            prixText.Text = (from s in db.prixes where s.NomEquip == (string)nomCombo.SelectedItem select s.Prix1).First().ToString();
        }
    }
}
