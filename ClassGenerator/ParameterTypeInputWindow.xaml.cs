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
    /// Logika interakcji dla klasy ParameterTypeInputWindow.xaml
    /// </summary>
    public partial class ParameterTypeInputWindow : Window
    {
        EditPropertyWindow Owner;
        GeneratedProperty GenPam;

        public ParameterTypeInputWindow()
        {
            
        }
        public ParameterTypeInputWindow(EditPropertyWindow epw, GeneratedProperty gp)
        {
            this.Owner = epw;
            this.GenPam = gp;
            InitializeComponent();
        }
        private void AddTypeInList_Click(object sender, RoutedEventArgs e)
        {
            if (Type.Text != null)
            {
                Owner.ReturnValueComboBox.Items.Insert(Owner.ReturnValueComboBox.Items.Count - 1, Type.Text);
                GenPam.Type = Type.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Podaj nazwę typu");
            }
        }

        private void ExitTypeInList_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
