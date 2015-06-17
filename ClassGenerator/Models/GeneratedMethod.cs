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
        public string GetSourceCode()
        {
            string temp = string.Empty;
            temp += Encapsulation + " ";
            if (IsStatic)
            {
                temp += "static ";
            }
            if (IsSealed)
            {
                temp += "sealed ";
            }
            if (IsOverride)
            {
                temp += "override ";
            }
            if (IsAbstract)
            {
                temp += "abstract ";
            }
            temp += ReturnType + " " + Name + "( ";
            foreach(var item in Parameters)
            {
                temp += item.GetSourceCode() + ",";
            }
            if (Parameters != null)
            temp = temp.Substring(0,temp.Length-1);
            temp += " ) {\n\n}\n";
            return temp;
        }
    }
}
