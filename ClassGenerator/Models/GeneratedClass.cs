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
        public GeneratedClass BaseClass { get; set; }
        public List<string> ImplementedInterfaces { get; set; }

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

        public string GetSourceCode()
        {
            string temp = string.Empty;
            temp += Encapsulation + " ";
            if (IsStatic)
            {
                temp += "static ";
            }
            if (IsAbstract)
            {
                temp += "abstract ";
            }
            temp += "class " + Name + " {\n";
            foreach ( var item in Properties)
            {
                temp += item.GetSourceCode();
            }
            foreach (var item in Methods)
            {
                temp += item.GetSourceCode();
            }
            temp += "\n}";
            return temp;
        }
    }
}
