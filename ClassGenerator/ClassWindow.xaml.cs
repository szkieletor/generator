﻿using ClassGenerator.Models;
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
        public string SourceCode;
        public GeneratedClass CurrentClass { get; set; }
        public ParameterViewWindow ParameterViewWindow { get; set; }
        public MethodViewWindow MethodViewWindow { get; set; }
        public ClassWindow()
        {
            InitializeComponent();           
            CurrentClass = new GeneratedClass();
            var mainWindow = (MainWindow)Application.Current.MainWindow;

            if (mainWindow.ClassListView.SelectedItem != null) //Edit
            {
                Binding nameBinding = new Binding();
                nameBinding.Source = mainWindow.ClassList[mainWindow.ClassListView.SelectedIndex];
                nameBinding.Path = new PropertyPath("Name");
                nameBinding.Mode = BindingMode.TwoWay;
                ClassName.SetBinding(TextBox.TextProperty, nameBinding);

                Binding encapsulationBinding = new Binding("Encapsulation");
                encapsulationBinding.Source = mainWindow.ClassList[mainWindow.ClassListView.SelectedIndex];
                encapsulationBinding.Mode = BindingMode.TwoWay;
                EncapsulationComboBox.SetBinding(ComboBox.TextProperty, encapsulationBinding);

                Binding abstractBinding = new Binding("IsAbstract");
                abstractBinding.Source = mainWindow.ClassList[mainWindow.ClassListView.SelectedIndex];
                abstractBinding.Mode = BindingMode.TwoWay;
                IsAbstract.SetBinding(CheckBox.IsCheckedProperty, abstractBinding);

                Binding staticBinding = new Binding("IsStatic");
                staticBinding.Source = mainWindow.ClassList[mainWindow.ClassListView.SelectedIndex];
                staticBinding.Mode = BindingMode.TwoWay;
                IsStatic.SetBinding(CheckBox.IsCheckedProperty, staticBinding);
            }
            else
            {
                Binding nameBinding = new Binding();
                nameBinding.Source = CurrentClass;
                nameBinding.Path = new PropertyPath("Name");
                nameBinding.Mode = BindingMode.TwoWay;
                ClassName.SetBinding(TextBox.TextProperty, nameBinding);

                Binding encapsulationBinding = new Binding("Encapsulation");
                encapsulationBinding.Source = CurrentClass;
                encapsulationBinding.Mode = BindingMode.TwoWay;
                EncapsulationComboBox.SetBinding(ComboBox.TextProperty, encapsulationBinding);

                Binding abstractBinding = new Binding("IsAbstract");
                abstractBinding.Source = CurrentClass;
                abstractBinding.Mode = BindingMode.TwoWay;
                IsAbstract.SetBinding(CheckBox.IsCheckedProperty, abstractBinding);

                Binding staticBinding = new Binding("IsStatic");
                staticBinding.Source = CurrentClass;
                staticBinding.Mode = BindingMode.TwoWay;
                IsStatic.SetBinding(CheckBox.IsCheckedProperty, staticBinding); 
        }
        }
        private void MethodViewButton_Click(object sender, RoutedEventArgs e)
        {
            MethodViewWindow = new MethodViewWindow();
            MethodViewWindow.ShowDialog();
        }

        private void ParameterViewButton_Click(object sender, RoutedEventArgs e)
        {
            ParameterViewWindow = new ParameterViewWindow();
            ParameterViewWindow.ToClassRef(CurrentClass);
            ParameterViewWindow.ShowDialog();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddEditButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            CurrentClass.Methods = MethodViewWindow.CurrentMethodList;
            
            if (mainWindow.ClassListView.SelectedItem == null) //Edit
            {
                mainWindow.ClassList.Add(CurrentClass);
            }
        }

        private void CodeGeneratorButton_Click(object sender, RoutedEventArgs e)
        {
           string codeTemp = CurrentClass.GetSourceCode();
           GeneratedClassTextBox.AppendText(codeTemp);
        }

        private void ClassName_TextChanged(object sender, TextChangedEventArgs e)
        {
            CurrentClass.Name = ClassName.Text;
            string codeTemp = CurrentClass.GetSourceCode();
            GeneratedClassTextBox.Document.Blocks.Clear();
            GeneratedClassTextBox.AppendText(codeTemp);
        }

        private void EncapsulationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentClass.Encapsulation = EncapsulationComboBox.Text;
            string codeTemp = CurrentClass.GetSourceCode();
            GeneratedClassTextBox.Document.Blocks.Clear();
            GeneratedClassTextBox.AppendText(codeTemp);
        }

        private void IsAbstract_Checked(object sender, RoutedEventArgs e)
        {
            CurrentClass.IsAbstract = (bool)IsAbstract.IsChecked;
            string codeTemp = CurrentClass.GetSourceCode();
            GeneratedClassTextBox.Document.Blocks.Clear();
            GeneratedClassTextBox.AppendText(codeTemp);
        }

        private void IsStatic_Checked(object sender, RoutedEventArgs e)
        {
            CurrentClass.IsStatic = (bool)IsStatic.IsChecked;
            string codeTemp = CurrentClass.GetSourceCode();
            GeneratedClassTextBox.Document.Blocks.Clear();
            GeneratedClassTextBox.AppendText(codeTemp);
        }

        private void IsStatic_Unchecked(object sender, RoutedEventArgs e)
        {
            CurrentClass.IsStatic = (bool)IsStatic.IsChecked;
            string codeTemp = CurrentClass.GetSourceCode();
            GeneratedClassTextBox.Document.Blocks.Clear();
            GeneratedClassTextBox.AppendText(codeTemp);
        }

        private void IsAbstract_Unchecked(object sender, RoutedEventArgs e)
        {
            CurrentClass.IsStatic = (bool)IsStatic.IsChecked;
            string codeTemp = CurrentClass.GetSourceCode();
            GeneratedClassTextBox.Document.Blocks.Clear();
            GeneratedClassTextBox.AppendText(codeTemp);
        }
    }
}
