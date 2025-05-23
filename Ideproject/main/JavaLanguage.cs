using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notePad.languages
{
    public class JavaLanguage : ProgrammingLanguage
    {
        public JavaLanguage() : base("Java") { }

        public override bool Matches(string code)
        {
            return code.Contains("public static void main") || code.Contains("class ") || code.Contains("System.out.println");
        }
    }
}

