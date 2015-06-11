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
            SourceCode= " ";
            if(generatedClass.IsAbstract)
            {
                SourceCode += "Abstract ";
            }
            if(generatedClass.IsStatic)
            {
                SourceCode += "Static ";
            }
            if(generatedClass.IsSealed)
            {
                SourceCode += "Sealed ";
            }
            SourceCode += "Class " + generatedClass.Name;
            if(generatedClass.BaseClass!=null)
            {
                SourceCode += ": "+generatedClass.BaseClass.Name; 
            }
                SourceCode += "\n";
            SourceCode += "{\n";
            
            foreach(GeneratedProperty property in generatedClass.Properties)
            {
                SourceCode += property.Type + " " + property.Name;
                if(property.IsGetterIncluded && property.IsSetterIncluded)
                {
                    SourceCode += " { get; set;}\n";
                }
                else
                {
                    if (property.IsGetterIncluded && !property.IsSetterIncluded)
                    {
                        SourceCode += " { get;}\n";
                    }
                    else
                    {
                        if (!property.IsGetterIncluded && property.IsSetterIncluded)
                        {
                            SourceCode += " { set;}\n";
                        }
                        else
                        {
                            SourceCode += "\n";
                        }
                    }
                }
            }
            foreach(GeneratedMethod method in generatedClass.Methods)
            {
                SourceCode += method.Encapsulation.ToString()+ " ";
                if(method.IsOverride)
                {
                    SourceCode += "Override ";
                }
                if(method.IsStatic)
                {
                    SourceCode += "Static ";
                }
                if(method.IsSealed)
                {
                    SourceCode += "Sealed ";
                }
                    SourceCode += method.ReturnType + " " +method.Name + "(";
                    foreach(string Parameter in method.Parameters)
                    {
                        SourceCode = Parameter+",";
                    }
                    SourceCode +=")\n";
            }
            SourceCode+="}\n";
            GeneratedClassTextBox.Document.Blocks.Add(new Paragraph(new Run(SourceCode)));
            }
        }
    }
