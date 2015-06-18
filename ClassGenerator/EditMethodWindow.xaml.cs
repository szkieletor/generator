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
    /// Interaction logic for EditMethodWindow.xaml
    /// </summary>
    public partial class EditMethodWindow : Window
    {
        public GeneratedMethod CurrentMethod { get; set; }
        public EditMethodWindow()
        {
            InitializeComponent();
            EncapsulationComboBox.ItemsSource = Enum.GetValues(typeof(Encapsulation)).Cast<Encapsulation>();
            CurrentMethod = new GeneratedMethod();
            if (((MainWindow)Application.Current.MainWindow).ClassWindow.MethodViewWindow.MethodListView.SelectedIndex != -1)
            {
                CurrentMethod = (GeneratedMethod)((MainWindow)Application.Current.MainWindow).ClassWindow.MethodViewWindow.MethodListView.SelectedItem;
            }
            MethodDetails.DataContext = CurrentMethod;
            ParameterListView.ItemsSource = CurrentMethod.Parameters;
        }

        private void AddParameter_Click(object sender, RoutedEventArgs e)
        {
            var parameterMethodWindow = new ParameterMethodWindow();
            parameterMethodWindow.ShowDialog();
        }

        private void EditParameter_Click(object sender, RoutedEventArgs e)
        {
            var parameterMethodWindow = new ParameterMethodWindow();
            parameterMethodWindow.ShowDialog();
        }

        private void AcceptMethod_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ClassWindow.CurrentClass.Methods.Add(CurrentMethod);
            Close();
        }

        private void RemoveParameterFromList_Click(object sender, RoutedEventArgs e)
        {
            if (ParameterListView.SelectedIndex != -1)
            {
                CurrentMethod.Parameters.RemoveAt(ParameterListView.SelectedIndex);
            }
        }
    }
}
