using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGenerator.Models
{
    public class GeneratedClass : INotifyPropertyChanged
    {
        public List<GeneratedProperty> Properties { get; set; }
        public List<GeneratedMethod> Methods { get; set; }
        public string Name { get; set; }
        public Encapsulation Encapsulation { get; set; }
        public bool IsStatic { get; set; }
        public bool  IsAbstract { get; set; }
        public bool IsSealed { get; set; }
        public GeneratedClass BaseClass { get; set; }
        public List<string> ImplementedInterfaces { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public GeneratedClass()
        {
            Properties = new List<GeneratedProperty>();
            Methods = new List<GeneratedMethod>();
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
