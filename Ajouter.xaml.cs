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
    /// Interaction logic for Ajouter.xaml
    /// </summary>
    public partial class Ajouter : Window
    {
        DBagricultureEntities db = new DBagricultureEntities();
        public Ajouter()
        {
            InitializeComponent();
            if (AllDataBases.name=="Engrais")
            {
                nomCombo.ItemsSource = (from s in db.engrais select s.nom).ToArray();
                tailleCombo.ItemsSource = (from s in db.engrais select s.Taille).ToArray();
                nomCombo.SelectedItem = (from s in db.engrais where s.id == 1 select s.nom).First().ToString();
                tailleCombo.SelectedItem = (from s in db.engrais where s.id == 1 select s.Taille).First();                
            }
            if (AllDataBases.name == "Irrigation")
            {
                nomCombo.ItemsSource = (from s in db.Irrigations select s.nom).ToArray();
                tailleCombo.ItemsSource = (from s in db.Irrigations select s.Taille).ToArray();
                nomCombo.SelectedItem = (from s in db.Irrigations where s.id == 1 select s.nom).First().ToString();
                tailleCombo.SelectedItem = (from s in db.Irrigations where s.id == 1 select s.Taille).First();
            }
            if (AllDataBases.name == "Pesticides")
            {
                nomCombo.ItemsSource = (from s in db.Pesticides select s.nom).ToArray();
                tailleCombo.ItemsSource = (from s in db.Pesticides select s.Taille).ToArray();
                nomCombo.SelectedItem = (from s in db.Pesticides where s.id == 1 select s.nom).First().ToString();
                tailleCombo.SelectedItem = (from s in db.Pesticides where s.id == 1 select s.Taille).First();
            }
            prixText.Text = (from s in db.prixes where s.NomEquip == nomCombo.Text select s.Prix1).First().ToString();
            nomCombo.SelectionChanged += nomCombo_SelectionChanged;
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
        private void quantiteText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
#endregion
        //End Region :forms

        void nomCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            prixText.Text = (from s in db.prixes where s.NomEquip == (string)nomCombo.SelectedItem select s.Prix1).First().ToString();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ajoute_Click(object sender, RoutedEventArgs e)
        {
            if (AllDataBases.name=="Engrais")
            {
                db.engrais.Add(new engrai()
                {
                    nom = nomCombo.Text,
                    Taille = Convert.ToSingle(tailleCombo.Text),
                    Prix = Convert.ToSingle(prixText.Text),
                    Quantite = Convert.ToInt16(quantiteText.Text),
                    Tarif = 0.5,
                    descript = descriptionText.Text,
                    Date_D__Ajoute = DateTime.Now
                });
                db.SaveChanges();
                AllDataBases.AlldataGrid.ItemsSource = (from s in db.engrais select s).ToList();
                MessageBox.Show("Ajoute avec Succsess", "Ajoute", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (AllDataBases.name == "Irrigation")
            {
                db.Irrigations.Add(new Irrigation()
                {
                    nom = nomCombo.Text,
                    Taille = Convert.ToSingle(tailleCombo.Text),
                    Prix = Convert.ToSingle(prixText.Text),
                    Quantite = Convert.ToInt16(quantiteText.Text),
                    Tarif = 0.5,
                    descript = descriptionText.Text,
                    Date_D__Ajoute = DateTime.Now
                });
                db.SaveChanges();
                AllDataBases.AlldataGrid.ItemsSource = (from s in db.Irrigations select s).ToList();
                MessageBox.Show("Ajoute avec Succsess", "Ajoute", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (AllDataBases.name == "Pesticides")
            {
                db.Pesticides.Add(new Pesticide()
                {
                    nom = nomCombo.Text,
                    Taille = Convert.ToSingle(tailleCombo.Text),
                    Prix = Convert.ToSingle(prixText.Text),
                    Quantite = Convert.ToInt16(quantiteText.Text),
                    Tarif = 0.5,
                    descript = descriptionText.Text,
                    Date_D__Ajoute = DateTime.Now
                });
                db.SaveChanges();
                AllDataBases.AlldataGrid.ItemsSource = (from s in db.Pesticides select s).ToList();
                MessageBox.Show("Ajoute avec Succsess", "Ajoute", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        }


    }
}
