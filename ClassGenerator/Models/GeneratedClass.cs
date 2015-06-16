using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGenerator.Models
{
    public class GeneratedClass : INotifyPropertyChanged
    {
        public ObservableCollection<GeneratedProperty> Properties { get; set; }
        public ObservableCollection<GeneratedMethod> Methods { get; set; }
        public string Name { get; set; }
        public Encapsulation Encapsulation { get; set; }
        public bool IsStatic { get; set; }
        public bool  IsAbstract { get; set; }
        public bool IsSealed { get; set; }
        public GeneratedClass BaseClass { get; set; }
        public List<string> ImplementedInterfaces { get; set; }
        public string SourceCode()
        {
            string SourceCode;
            SourceCode = " ";
            if (IsAbstract)
            {
                SourceCode += "Abstract ";
            }
            if (IsStatic)
            {
                SourceCode += "Static ";
            }
            if (IsSealed)
            {
                SourceCode += "Sealed ";
            }
            SourceCode += "Class " + Name;
            if (BaseClass != null)
            {
                SourceCode += ": " + BaseClass.Name;
            }
            SourceCode += "\n";
            SourceCode += "{\n";

            foreach (GeneratedProperty property in Properties)
            {
                SourceCode += property.Type + " " + property.Name;
                if (property.IsGetterIncluded && property.IsSetterIncluded)
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
            foreach (GeneratedMethod method in Methods)
            {
                SourceCode += method.Encapsulation.ToString() + " ";
                if (method.IsOverride)
                {
                    SourceCode += "Override ";
                }
                if (method.IsStatic)
                {
                    SourceCode += "Static ";
                }
                if (method.IsSealed)
                {
                    SourceCode += "Sealed ";
                }
                SourceCode += method.ReturnType + " " + method.Name + "(";
                foreach (string Parameter in method.Parameters)
                {
                    SourceCode = Parameter + ",";
                }
                SourceCode += ")\n";
            }
            SourceCode += "}\n";
            return SourceCode;
        }

        public override string ToString()
        {
            return Name;
        }

        public GeneratedClass()
        {
            Properties = new ObservableCollection<GeneratedProperty>();
            Methods = new ObservableCollection<GeneratedMethod>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(object sender, string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
