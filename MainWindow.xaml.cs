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
using System.Threading;
using System.Diagnostics;
using System.Windows.Threading;

namespace MyAgriculture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static AllDataBases alldatabases;
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            alldatabases = new AllDataBases("Pesticides");
            alldatabases.Visibility = Visibility.Hidden;
            mainGrid.Children.Add(alldatabases);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.Zero;
            timer.Tick += timer_Tick;
            alldatabases.IsVisibleChanged += alldatabases_IsVisibleChanged;
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







            void MinimizedListViewItem_MouseUp(object sender, MouseButtonEventArgs e)
            {
                this.WindowState = WindowState.Minimized;
            }

            private void CloseListViewItem_MouseUp(object sender, MouseButtonEventArgs e)
            {
                Environment.Exit(1);
            }

            private void Pesticides_MouseUp(object sender, MouseButtonEventArgs e)
            {
                var x = alldatabases.Width;

                mainGrid.Children.Remove(alldatabases);
                alldatabases = new AllDataBases("Pesticides");
                alldatabases.Width = x;
                alldatabases.mainGrid.Width = x;
                alldatabases.Operation.Width = x;
                alldatabases.Visibility = Visibility.Visible;
                mainGrid.Children.Add(alldatabases);
            }

            private void Engrais_MouseUp(object sender, MouseButtonEventArgs e)
            {
                var x = alldatabases.Width;

                mainGrid.Children.Remove(alldatabases);
                alldatabases = new AllDataBases("Engrais");
                alldatabases.Width = x;
                alldatabases.mainGrid.Width = x;
                alldatabases.Operation.Width = x;
                alldatabases.Visibility = Visibility.Visible;
                mainGrid.Children.Add(alldatabases);
            }

            private void Irrigation_MouseUp(object sender, MouseButtonEventArgs e)
            {
                var x = alldatabases.Width;

                mainGrid.Children.Remove(alldatabases);
                alldatabases = new AllDataBases("Irrigation");
                alldatabases.Width = x;
                alldatabases.mainGrid.Width = x;
                alldatabases.Operation.Width = x;
                alldatabases.Visibility = Visibility.Visible;
                mainGrid.Children.Add(alldatabases);
            }

            void alldatabases_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                //   MessageBox.Show("Test");
                if (this.MainImage.Visibility == Visibility.Hidden)
                {
                    //   MessageBox.Show("Tesdcsdcsdcsdccsdcsdst");
                    this.MainImage.Visibility = Visibility.Visible;
                }
                else
                {
                    this.MainImage.Visibility = Visibility.Hidden;
                }
            }



            double m1 = 150;
            double m2 = 44;
            bool a;
            void timer_Tick(object sender, EventArgs e)
            {
                if (test&&!a)
                {
                    if (alldatabases.Visibility==Visibility.Visible)
                    {
                        whenDataGridVisible(); return;
                    }
                    foreach (TextBlock item in MyClass.FindVisualChildren<TextBlock>(this))
                    {
                        item.Visibility = Visibility.Hidden;
                    }
                    if (Slide.Width.Value>=44)
                    {
                        Slide.Width = new GridLength(m1--);
                        Footer.Width += 1;
                        return;
                    }
                    if (Slide.Width.Value <= 44)
                    {
                            alldatabases.ReloadData();
                        //    alldatabases.Width = 856;
                        //alldatabases.mainGrid.Width=856;
                        //alldatabases.Operation.Width = 856;
                        m1 = 150;
                        timer.Stop();
                        a = true;
                        return;
                    }
                }
                if (!test&&a)
                {
                    if (alldatabases.Visibility == Visibility.Visible)
                    {
                        whenDataGridVisible(); return;
                    }
                    if (Slide.Width.Value<=150)
                    {
                        Slide.Width = new GridLength(m2++);
                        Footer.Width -= 1;
                        return;
                    }
                    if (Slide.Width.Value>=150)
                    {
                        foreach (TextBlock item in MyClass.FindVisualChildren<TextBlock>(this))
                        {
                            item.Visibility = Visibility.Visible;
                        }
                            alldatabases.ReloadData();
                            //alldatabases.Width = 750;
                            //alldatabases.mainGrid.Width = 750;
                            //alldatabases.Operation.Width = 750;
                        m2 = 44;
                        timer.Stop();
                        a = false;
                        return;
                    }
                }

            }


            bool test = false;
            private void AgricultureImage_MouseEnter(object sender, MouseEventArgs e)
            {
                timer.Start();
                test = false;
            }

            private void mainBorder_MouseEnter(object sender, MouseEventArgs e)
            {
                timer.Start();
                test = true;
            }


            void whenDataGridVisible()
            {
                if (test && !a)
                {

                    foreach (TextBlock item in MyClass.FindVisualChildren<TextBlock>(this))
                    {
                        item.Visibility = Visibility.Hidden;
                    }
                    while (Slide.Width.Value >= 44)
                    {
                        Slide.Width = new GridLength(m1 -= 10);
                        Footer.Width += 10;
                        return;
                    }
                    if (Slide.Width.Value <= 44)
                    {
                        alldatabases.ReloadData();
                        m1 = 150;
                        timer.Stop();
                        a = true;
                        if (AllDataBases.name == "Pesticides")
                        {
                            Pesticides_MouseUp(new object(), null);
                        }
                        if (AllDataBases.name == "Irrigation")
                        {
                            Irrigation_MouseUp(new object(), null);
                        }
                        if (AllDataBases.name == "Engrais")
                        {
                            Engrais_MouseUp(new object(), null);
                        }
                        return;
                    }
                }
                if (!test && a)
                {
                    while (Slide.Width.Value <= 150)
                    {
                        Slide.Width = new GridLength(m2+=10);
                        Footer.Width -= 10;
                        return;
                    }
                    if (Slide.Width.Value >= 150)
                    {
                        foreach (TextBlock item in MyClass.FindVisualChildren<TextBlock>(this))
                        {
                            item.Visibility = Visibility.Visible;
                        }
                        alldatabases.ReloadData();
                        m2 = 44;
                        timer.Stop();
                        a = false;
                        if (AllDataBases.name=="Pesticides")
                        {
                            Pesticides_MouseUp(new object(), null);
                        }
                        if (AllDataBases.name == "Irrigation")
                        {
                            Irrigation_MouseUp(new object(), null);
                        }
                        if (AllDataBases.name == "Engrais")
                        {
                            Engrais_MouseUp(new object(), null);
                        }
                        return;
                    }
                }
            }


    }
    class MyClass
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
