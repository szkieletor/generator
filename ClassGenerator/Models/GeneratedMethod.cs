using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGenerator.Models
{
    public class GeneratedMethod
    {
        public Encapsulation Encapsulation { get; set; }
        public bool IsStatic { get; set; }
        public bool IsSealed { get; set; }
        public bool IsOverride { get; set; }
        public bool IsAbstract { get; set; }
        public string ReturnType { get; set; }
        public ObservableCollection<GeneratedParameter> Parameters { get; set; }
        public string Name { get; set; }

        public GeneratedMethod()
        {
            Parameters = new ObservableCollection<GeneratedParameter>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
