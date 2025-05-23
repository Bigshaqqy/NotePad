using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notePad.languages
{
    public class PythonLanguage : ProgrammingLanguage
    {
        public PythonLanguage() : base("Python") { }

        public override bool Matches(string code)
        {
            return code.Contains("def ") || code.Contains("import ") || code.Contains("print(");
        }
    }
}

