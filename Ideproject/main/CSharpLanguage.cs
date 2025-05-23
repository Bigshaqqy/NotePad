using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notePad.languages
{
    public class CSharpLanguage : ProgrammingLanguage
    {
        public CSharpLanguage() : base("C#") { }

        public override bool Matches(string code)
        {
            return code.Contains("using") || code.Contains("namespace") || code.Contains("public class") || code.Contains("Console.WriteLine");
        }
    }
}

