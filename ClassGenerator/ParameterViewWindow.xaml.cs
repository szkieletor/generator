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
    /// Logika interakcji dla klasy ParameterViewWindow.xaml
    /// </summary>
    public partial class ParameterViewWindow : Window
    {
        GeneratedClass ClassRef { get; set; }
        public void ToClassRef(GeneratedClass classref)
        {
            ClassRef = classref;
            ParameterViewList.ItemsSource = ClassRef.Properties;
        }
        public ParameterViewWindow()
        {
            InitializeComponent();
            
        }

        private void AddParameter_Click(object sender, RoutedEventArgs e)
        {
            var parameterEditWindow = new EditPropertyWindow();
            parameterEditWindow.ToClassRef(ClassRef);
            parameterEditWindow.ShowDialog();
        }

        private void EditParameter_Click(object sender, RoutedEventArgs e)
        {
            var parameterEditWindow = new EditPropertyWindow();
            parameterEditWindow.GetProperty((GeneratedProperty)ParameterViewList.SelectedItem);
            parameterEditWindow.ShowDialog();
        }

        private void RemoveParameter_Click(object sender, RoutedEventArgs e)
        {
            ClassRef.Properties.Remove((GeneratedProperty)ParameterViewList.SelectedItem);
        }
    }
}
