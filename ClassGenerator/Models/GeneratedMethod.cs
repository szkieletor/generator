using System;
using System.Collections.Generic;
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
        public string ReturnType { get; set; }
        public List<string> Parameters { get; set; }
    }
}
