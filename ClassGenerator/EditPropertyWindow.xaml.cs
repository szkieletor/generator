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
    /// Interaction logic for EditPropertyWindow.xaml
    /// </summary>
    public partial class EditPropertyWindow : Window
    {
        GeneratedClass classRef;
        GeneratedProperty propertyTemp {get; set;}
        public void ToClassRef(GeneratedClass ClassRef)
        {
            classRef = ClassRef;
        }
        public EditPropertyWindow()
        {
            propertyTemp = new GeneratedProperty();
            InitializeComponent();
            Binding NameB = new Binding();
            NameB.Source = propertyTemp;
            NameB.Path = new PropertyPath("Name");
            NameB.Mode = BindingMode.TwoWay;
            PropertyName.SetBinding(TextBox.TextProperty, NameB);
            Binding TypeB = new Binding("Type");
            TypeB.Source = propertyTemp;
            TypeB.Mode = BindingMode.TwoWay;
            ReturnValueComboBox.SetBinding(ComboBox.TextProperty, TypeB);
            Binding IsGetterIncludedB = new Binding("Type");
            IsGetterIncludedB.Source = propertyTemp;
            IsGetterIncludedB.Mode = BindingMode.TwoWay;
            GetterCheckBox.SetBinding(CheckBox.IsCheckedProperty, IsGetterIncludedB);
        }

        private void SaveParameter_Click(object sender, RoutedEventArgs e)
        {
            classRef.Properties.Add(propertyTemp);
        }

       
    }
}
