using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGenerator.Models
{
    public class GeneratedProperty
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public Encapsulation GetterEncapsulation { get; set; }
        public Encapsulation SetterEncapsulation { get; set; }

        //public override string ToString()
        //{
        //    return "Type: "+this.Type + ", Name: " + this.Name;
        //}
    }
}
