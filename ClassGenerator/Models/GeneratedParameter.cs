using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassGenerator.Models
{
    public class GeneratedParameter
    {
        public string Type { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Type + " " + Name;
        }
    }
}
