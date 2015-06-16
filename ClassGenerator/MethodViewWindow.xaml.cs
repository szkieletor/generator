using ClassGenerator.Models;
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
using System.Windows.Shapes;

namespace ClassGenerator
{
    /// <summary>
    /// Logika interakcji dla klasy MethodViewWindow.xaml
    /// </summary>
    
    public partial class MethodViewWindow : Window
    {
        public EditMethodWindow EditMethodWindow { get; set; }


        public MethodViewWindow()
        {
            InitializeComponent();
            MethodList.ItemsSource = ((MainWindow)Application.Current.MainWindow).ClassWindow.CurrentClass.Methods;
        }

        private void AddMethod_Click(object sender, RoutedEventArgs e)
        {
            EditMethodWindow = new EditMethodWindow();
            EditMethodWindow.Show();
        }

        private void EditMethod_Click(object sender, RoutedEventArgs e)
        {
            EditMethodWindow = new EditMethodWindow();
            EditMethodWindow.Show();
        }
    }
}
