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
        public bool IsOwnType { get; set; }

        public Encapsulation GetterEncapsulation { get; set; }
        public Encapsulation SetterEncapsulation { get; set; }

        //public override string ToString()
        //{
        //    return "Type: "+this.Type + ", Name: " + this.Name;
        //}

        public string GetSourceCode()
        {
            string temp = string.Empty;
            temp += Type + " " + Name;
            if(GetterEncapsulation != Encapsulation.Brak && SetterEncapsulation != Encapsulation.Brak)
            {
                temp += " { " + GetterEncapsulation + " get;" + " " + SetterEncapsulation + " set;}\n";    
            }
            if (GetterEncapsulation != Encapsulation.Brak && SetterEncapsulation == Encapsulation.Brak)
            {
                temp += " { " + GetterEncapsulation + " get;}\n";
            }

            if (GetterEncapsulation == Encapsulation.Brak && SetterEncapsulation != Encapsulation.Brak)
            {
                temp += " { " + SetterEncapsulation + " set;}\n";
            }
            if (GetterEncapsulation == Encapsulation.Brak && SetterEncapsulation == Encapsulation.Brak)
            {
                temp += ";\n";
            }
            return temp;
        }
    }
}
