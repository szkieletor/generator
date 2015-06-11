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
    /// Interaction logic for ClassWindow.xaml
    /// </summary>
    public partial class ClassWindow : Window
    {
        public string SourceCode;
        GeneratedClass generatedClass;
        public ClassWindow()
        {
            InitializeComponent();           
        }
        private void MethodViewButton_Click(object sender, RoutedEventArgs e)
        {
            var MethodViewWindow = new MethodViewWindow();
            MethodViewWindow.ShowDialog();
        }

        private void ParameterViewButton_Click(object sender, RoutedEventArgs e)
        {
            var ParameterViewWindow = new ParameterViewWindow();
            ParameterViewWindow.ShowDialog();
        }

        private void CodeGeneratorButton_Click(object sender, RoutedEventArgs e)
        {
            
            GeneratedClassTextBox.Document.Blocks.Add(new Paragraph(new Run(generatedClass.SourceCode())));
            }
        }
    }
