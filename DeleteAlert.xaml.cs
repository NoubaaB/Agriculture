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
    /// Interaction logic for DeleteAlert.xaml
    /// </summary>
    public partial class DeleteAlert : Window
    {
        int idGlobal = 0;
        public DeleteAlert(int id, string name)
        {
            InitializeComponent();
            this.HorizontalAlignment = HorizontalAlignment.Center;
            this.VerticalAlignment = VerticalAlignment.Center;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.messageTextbox.Text += " Nom : " + name + " ,ID :" + id.ToString();
            idGlobal = id;
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            DBagricultureEntities db = new DBagricultureEntities();
            if (AllDataBases.name == "Engrais")
            {
                engrai p = new engrai() { id = idGlobal };
                db.engrais.Attach(p);
                db.engrais.Remove(p);
                db.SaveChanges();
                AllDataBases.AlldataGrid.ItemsSource = (from s in db.engrais select s).ToList();
                this.Close();
                return;
            }
            if (AllDataBases.name == "Irrigation")
            {
                Irrigation p = new Irrigation() { id = idGlobal };
                db.Irrigations.Attach(p);
                db.Irrigations.Remove(p);
                db.SaveChanges();
                AllDataBases.AlldataGrid.ItemsSource = (from s in db.Irrigations select s).ToList();
                this.Close();
                return;
            }
            if (AllDataBases.name == "Pesticides")
            {
                Pesticide p = new Pesticide() { id = idGlobal };
                db.Pesticides.Attach(p);
                db.Pesticides.Remove(p);
                db.SaveChanges();
                AllDataBases.AlldataGrid.ItemsSource = (from s in db.Pesticides select s).ToList();
                this.Close();
                return;
            }

        }
        //End Region :forms
    }
}
