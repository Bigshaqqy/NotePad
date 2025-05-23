using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notePad.main
{
    public class LanguageOption 
    {
        public string Name { get; set; }

        public LanguageOption() { }

        public LanguageOption(string name)
        {
            Name = name;
        }
    }
}
