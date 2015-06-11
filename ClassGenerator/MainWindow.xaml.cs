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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClassGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var classes = new ObservableCollection<GeneratedClass>();
            ClassListView.ItemsSource = classes;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addClassWindow = new ClassWindow();
            addClassWindow.ShowDialog();
            
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var editClassWindow = new ClassWindow();
            editClassWindow.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
