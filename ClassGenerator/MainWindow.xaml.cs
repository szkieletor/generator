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
        public ClassWindow ClassWindow { get; set; }
        public ObservableCollection<GeneratedClass> ClassList { get; set; }
        public MainWindow()
        {
            ClassList = new ObservableCollection<GeneratedClass>();
            InitializeComponent();
            ClassListView.ItemsSource = ClassList;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newClass = new GeneratedClass();
            ClassListView.SelectedItem = null;
            ClassWindow = new ClassWindow();
            ClassWindow.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ClassWindow = new ClassWindow();
            ClassWindow.ShowDialog();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClassListView.SelectedIndex != -1)
            {
                ClassList.RemoveAt(ClassListView.SelectedIndex);
            }
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            
            ClassWindow = new ClassWindow();
            ClassWindow.ShowDialog();
        }
    }
}
