using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGenerator.Models
{
    class GeneratedProperty
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public bool IsGetterIncluded { get; set; }
        public Encapsulation GetterEncapsulation { get; set; }
        public bool IsSetterIncluded  { get; set; }
        public Encapsulation SetterEncapsulation { get; set; }
    }
}
