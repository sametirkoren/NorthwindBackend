using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogParameter
    {
        public string Name { get; set; } // Product örneğin

        public object Value { get; set; } // Product Name ' i Araba , Id si 1 gibi düşünebilirsiniz.

        public string Type { get; set; }
    }
}
