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

        public void GetProperty (GeneratedProperty prop)
        {
            propertyTemp = prop;
        }
        public void ToClassRef(GeneratedClass ClassRef)
        {
            classRef = ClassRef;
        }
        public EditPropertyWindow()
        {
            InitializeComponent();
            propertyTemp = new GeneratedProperty();
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
            if(PropertyName.Text!=null && ReturnValueComboBox.SelectedItem!=null)
            {
                classRef.Properties.Add(propertyTemp);
                this.Close();
            }
            else
            {
                if (PropertyName.Text == null && ReturnValueComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Pola nazwy i zwracanego typu nie mogą być puste", "Brak informacji o parametrze", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    if (PropertyName.Text == null)
                    {
                        MessageBox.Show("Nazwa parametru nie może być pusta", "Brak informacji o parametrze", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else 
                    {
                        MessageBox.Show("Parametr musi mieć jakiś konkretny zwracany typ", "Brak informacji o parametrze", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
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

        private void ZwracanyTyp_Selected(object sender, RoutedEventArgs e)
        {
            var ParameterTypeInputWindow = new ParameterTypeInputWindow(this,propertyTemp);
            ParameterTypeInputWindow.ShowDialog();
        }

        

       
    }
}
