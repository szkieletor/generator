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
    /// Logika interakcji dla klasy ParameterWindow.xaml
    /// </summary>
    public partial class ParameterMethodWindow : Window
    {
        public GeneratedParameter GeneratedParameter { get; set; }

        public ParameterMethodWindow()
        {
            InitializeComponent();
            GeneratedParameter = new GeneratedParameter();
            if (((MainWindow)Application.Current.MainWindow).ClassWindow.MethodViewWindow.EditMethodWindow.ParameterListView.SelectedIndex != -1)
            {
                GeneratedParameter = (GeneratedParameter)(((MainWindow)Application.Current.MainWindow).ClassWindow.MethodViewWindow.EditMethodWindow.ParameterListView.SelectedItem);
            }
            MethodParameterDetails.DataContext = GeneratedParameter;
        }

        private void AcceptMethod_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).ClassWindow.MethodViewWindow.EditMethodWindow.CurrentMethod.Parameters.Add(GeneratedParameter);
             Close();
        }
    }
}
