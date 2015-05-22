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
        public EditMethodWindow()
        {
            InitializeComponent();
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
    }
}
