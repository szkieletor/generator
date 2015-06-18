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
using ClassGenerator.Models;

namespace ClassGenerator
{
    /// <summary>
    /// Logika interakcji dla klasy ShowSourceCodeWindow.xaml
    /// </summary>
    public partial class ShowSourceCodeWindow : Window
    {
        public ShowSourceCodeWindow()
        {
            InitializeComponent();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            string codeTemp = ((GeneratedClass)(mainWindow.ClassListView).SelectedItem).GetSourceCode();
            SourceCodeTextBox.AppendText(codeTemp);
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
