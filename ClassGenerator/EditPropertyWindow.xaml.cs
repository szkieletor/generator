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
            GetterEncapsulationComboBox.IsEnabled = false;
            SetterEncapsulationComboBox.IsEnabled = false;
            Binding NameB = new Binding();
            NameB.Source = propertyTemp;
            NameB.Path = new PropertyPath("Name");
            NameB.Mode = BindingMode.TwoWay;
            PropertyName.SetBinding(TextBox.TextProperty, NameB);
            Binding TypeB = new Binding("Type");
            TypeB.Source = propertyTemp;
            TypeB.Mode = BindingMode.TwoWay;
            ReturnValueComboBox.SetBinding(ComboBox.TextProperty, TypeB);
            Binding GetterEncapsulationB = new Binding("GetterEncapsulation");
            GetterEncapsulationB.Source = propertyTemp;
            GetterEncapsulationB.Mode = BindingMode.TwoWay;
            GetterEncapsulationComboBox.SetBinding(ComboBox.TextProperty, GetterEncapsulationB);
            Binding SetterEncapsulationB = new Binding("SetterEncapsulation");
            SetterEncapsulationB.Source = propertyTemp;
            SetterEncapsulationB.Mode = BindingMode.TwoWay;
            SetterEncapsulationComboBox.SetBinding(ComboBox.TextProperty, SetterEncapsulationB);
            
            
        }

        private void SaveParameter_Click(object sender, RoutedEventArgs e)
        {
            classRef.Properties.Add(propertyTemp);
        }

        private void SetterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
                SetterEncapsulationComboBox.IsEnabled = true;
        }

        private void SetterCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            propertyTemp.SetterEncapsulation = Encapsulation.Brak;
            SetterEncapsulationComboBox.IsEnabled = false;
    
        }

        private void GetterCheckBox_Checked(object sender, RoutedEventArgs e)
        {
                GetterEncapsulationComboBox.IsEnabled = true;
               
        }

        private void GetterCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            propertyTemp.GetterEncapsulation = Encapsulation.Brak;
                GetterEncapsulationComboBox.IsEnabled = false;
                
        }

       
    }
}
