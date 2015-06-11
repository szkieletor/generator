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
    /// Interaction logic for ClassWindow.xaml
    /// </summary>
    public partial class ClassWindow : Window
    {
        public GeneratedClass CurrentClass { get; set; }
        public ClassWindow()
        {
            InitializeComponent();
            CurrentClass = new GeneratedClass();
            var mainWindow = (MainWindow)Application.Current.MainWindow;

            if (mainWindow.ClassListView.SelectedItem != null) //Edit
            {
                Binding classBinding = new Binding();
                classBinding.Source = mainWindow.ClassList[mainWindow.ClassListView.SelectedIndex];
                classBinding.Path = new PropertyPath("Name");
                classBinding.Mode = BindingMode.TwoWay;
                ClassName.SetBinding(TextBox.TextProperty, classBinding);
            }
            else
            {
                Binding classBinding = new Binding();
                classBinding.Source = CurrentClass;
                classBinding.Path = new PropertyPath("Name");
                classBinding.Mode = BindingMode.TwoWay;
                ClassName.SetBinding(TextBox.TextProperty, classBinding);
            }
        }
        private void MethodViewButton_Click(object sender, RoutedEventArgs e)
        {
            var MethodViewWindow = new MethodViewWindow();
            MethodViewWindow.ShowDialog();
        }

        private void ParameterViewButton_Click(object sender, RoutedEventArgs e)
        {
            var ParameterViewWindow = new ParameterViewWindow();
            ParameterViewWindow.ShowDialog();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddEditButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            if (mainWindow.ClassListView.SelectedItem == null) //Edit
            {
                mainWindow.ClassList.Add(CurrentClass);
            }
        }
    }
}
