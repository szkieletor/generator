using ClassGenerator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<GeneratedMethod> CurrentMethodList { get; set;}

        public MethodViewWindow()
        {
            InitializeComponent();
            CurrentMethodList = ((MainWindow)Application.Current.MainWindow).ClassWindow.CurrentClass.Methods;
            MethodListView.ItemsSource = CurrentMethodList;
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
