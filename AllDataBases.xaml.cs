using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;

namespace MyAgriculture
{
    /// <summary>
    /// Interaction logic for AllDataBases.xaml
    /// </summary>
    public partial class AllDataBases : UserControl
    {
        public static DataGridTextColumn dgtc;
        public static Grid g;
        public AllDataBases()
        {
            InitializeComponent();
            myDataGrid.IsReadOnly = true;
            myDataGrid.Width += 100;
            dgtc = Des;
            //g = mainGrid;
            this.HorizontalContentAlignment = HorizontalAlignment.Left;
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Center;
            this.Visibility = Visibility.Visible;
            if (name == "Engrais")
            {
                myDataGrid.ItemsSource = (from s in db.engrais select s).ToArray();
                AlldataGrid = myDataGrid;
            }
            if (name == "Irrigation")
            {
                myDataGrid.ItemsSource = (from s in db.Irrigations select s).ToArray();
                AlldataGrid = myDataGrid;
            }
            if (name == "Pesticides")
            {
                myDataGrid.ItemsSource = (from s in db.Pesticides select s).ToArray();
                AlldataGrid = myDataGrid;
            }
        }



        DBagricultureEntities db = new DBagricultureEntities();
        public static DataGrid AlldataGrid;
        public static string name;
        public AllDataBases(string tableName)
        { 
            InitializeComponent();
            myDataGrid.IsReadOnly = true;
            myDataGrid.Width += 100;
            this.HorizontalContentAlignment = HorizontalAlignment.Left;
            this.HorizontalAlignment = HorizontalAlignment.Left;
            this.VerticalAlignment = VerticalAlignment.Center;
            this.Visibility = Visibility.Visible;
            name = tableName;
            if (tableName == "Engrais")
            {
                myDataGrid.ItemsSource = (from s in db.engrais select s).ToArray();
                AlldataGrid = myDataGrid;
            }
            if (tableName == "Irrigation")
            {
                myDataGrid.ItemsSource = (from s in db.Irrigations select s).ToArray();
                AlldataGrid = myDataGrid;
            }
            if (tableName == "Pesticides")
            {
                myDataGrid.ItemsSource = (from s in db.Pesticides select s).ToArray();
                AlldataGrid = myDataGrid;
            }
        }

        private void Ajoute_Click(object sender, RoutedEventArgs e)
        {
            Ajouter a = new Ajouter();
            a.Show();

        }

        private void Delete_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (name=="Engrais")
            {
                engrai p = myDataGrid.SelectedItem as engrai;
                DeleteAlert da = new DeleteAlert(p.id, p.nom);
                da.ShowDialog();
                return;
            }
            if (name == "Irrigation")
            {
                Irrigation p = myDataGrid.SelectedItem as Irrigation;
                DeleteAlert da = new DeleteAlert(p.id, p.nom);
                da.ShowDialog();
                return;
            }
            if (name == "Pesticides")
            {
                Pesticide p = myDataGrid.SelectedItem as Pesticide;
                DeleteAlert da = new DeleteAlert(p.id, p.nom);
                da.ShowDialog();
                return;
            }

        }

        private void Edit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (name == "Engrais")
            {
                engrai p = myDataGrid.SelectedItem as engrai;
                edite d = new edite(p.id);
                d.Show();
                return;
            }
            if (name == "Irrigation")
            {
                Irrigation p = myDataGrid.SelectedItem as Irrigation;
                edite d = new edite(p.id);
                d.Show();
                return;
            }
            if (name == "Pesticides")
            {
                Pesticide p = myDataGrid.SelectedItem as Pesticide;
                edite d = new edite(p.id);
                d.Show();
                return;
            }
        }

        private void retour_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Edit_MouseEnter(object sender, MouseEventArgs e)
        {
            ((PackIcon)sender).Foreground = Brushes.White;
        }

        private void Edit_MouseLeave(object sender, MouseEventArgs e)
        {
            ((PackIcon)sender).Foreground = Brushes.Yellow;
        }

        private void Delete_MouseEnter(object sender, MouseEventArgs e)
        {
            ((PackIcon)sender).Foreground = Brushes.White;
            ((PackIcon)sender).Kind = PackIconKind.DeleteEmpty;
        }

        private void Delete_MouseLeave(object sender, MouseEventArgs e)
        {
            ((PackIcon)sender).Foreground = Brushes.Red;
            ((PackIcon)sender).Kind = PackIconKind.Delete;
        }

        public void ReloadData()
        {
            //if (name == "Engrais")
            //{
            //    myDataGrid.ItemsSource = (from s in db.engrais select s).ToArray();
            //    AlldataGrid = myDataGrid;
            //}
            //if (name == "Irrigation")
            //{
            //    myDataGrid.ItemsSource = (from s in db.Irrigations select s).ToArray();
            //    AlldataGrid = myDataGrid;
            //}
            //if (name == "Pesticides")
            //{
            //    myDataGrid.ItemsSource = (from s in db.Pesticides select s).ToArray();
            //    AlldataGrid = myDataGrid;
            //}

            //retour.Content = "Return";
            //Ajoute.Content = "Ajouter";
           //// AlldataGrid.Columns[0].Header = "ID";
           // AlldataGrid.Columns[1].Header = "Nom";
           // AlldataGrid.Columns[2].Header = "Taille(cm)";
           // AlldataGrid.Columns[3].Header = "Prix(DH)";
           // AlldataGrid.Columns[4].Header = "Quantity";
           // AlldataGrid.Columns[5].Header = "Tarif(DH/TTC)";
           // AlldataGrid.Columns[6].Header = "Description";
           // AlldataGrid.Columns[7].Header = "Date D'Ajoute";
           // AlldataGrid.Columns[8].Header = "Action";                
        }
         List<int> listID = new List<int>();
         int ittirate = 0;
        private void Check_Checked(object sender, RoutedEventArgs e)
        {
            if (name == "Engrais")
            {
                engrai p = myDataGrid.SelectedItem as engrai;
                p = p == null ? myDataGrid.SelectedItems[ittirate++] as engrai : p;
                listID.Add(p.id);
                return;
            }
            if (name == "Irrigation")
            {
                Irrigation p = myDataGrid.SelectedItem as Irrigation;
                p = p == null ? myDataGrid.SelectedItems[ittirate++] as Irrigation : p;
                listID.Add(p.id);
                return;
            }
            if (name == "Pesticides")
            {
                Pesticide p = myDataGrid.SelectedItem as Pesticide;
                p = p == null ? myDataGrid.SelectedItems[ittirate++] as Pesticide : p;
                listID.Add(p.id);
                return;
            }
        }
        private void Check_Unchecked(object sender, RoutedEventArgs e)
        {
            if (name == "Engrais")
            {
                engrai p = myDataGrid.SelectedItem as engrai;
                listID.Remove(p.id);
                ittirate = 0;
                return;
            }
            if (name == "Irrigation")
            {
                Irrigation p = myDataGrid.SelectedItem as Irrigation;
                listID.Remove(p.id);
                ittirate = 0;
                return;
            }
            if (name == "Pesticides")
            {
                Pesticide p = myDataGrid.SelectedItem as Pesticide;
                listID.Remove(p.id);
                ittirate = 0;
                return;
            }
        }

        private void Supprimier_Click(object sender, RoutedEventArgs e)
        {

                    if (name == "Engrais")
                    {
                        foreach (var item in listID)
                        {
                            engrai p = new engrai() { id = item };
                            db.engrais.Attach(p);
                            db.engrais.Remove(p);  
                        }

                        db.SaveChanges();
                        AllDataBases.AlldataGrid.ItemsSource = (from s in db.engrais select s).ToList();
                        return;
                    }
                    if (name == "Irrigation")
                    {
                        foreach (var item in listID)
                        {
                            Irrigation p = new Irrigation() { id = item };
                            db.Irrigations.Attach(p);
                            db.Irrigations.Remove(p);
                        }

                        db.SaveChanges();
                        AllDataBases.AlldataGrid.ItemsSource = (from s in db.Irrigations select s).ToList();
                        return;
                    }
                    if (name == "Pesticides")
                    {
                        foreach (var item in listID)
                        {
                            Pesticide p = new Pesticide() { id = item };
                            db.Pesticides.Attach(p);
                            db.Pesticides.Remove(p);
                        }

                        db.SaveChanges();
                        AllDataBases.AlldataGrid.ItemsSource = (from s in db.Pesticides select s).ToList();
                        return;
                    }

        }

        private void CheckAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ittirate == 0)
            {
                myDataGrid.SelectedIndex = 0;
            }
            foreach (CheckBox item in ForeachClass.FindVisualChildren<CheckBox>(this))
            {
                item.IsChecked = false;
            }
            myDataGrid.SelectedIndex = -1;
        }

        private void CheckAll_Checked(object sender, RoutedEventArgs e)
        {
            if (ittirate == 0)
            {
                myDataGrid.SelectedIndex = 0;
            }
            foreach (CheckBox item in ForeachClass.FindVisualChildren<CheckBox>(this))
            {
                item.IsChecked = true;
            }
            myDataGrid.SelectedIndex = -1;
        }


    }
    class ForeachClass
    {
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
