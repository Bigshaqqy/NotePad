using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notePad.languages
{
    public class LuaLanguage : ProgrammingLanguage
    {
        public LuaLanguage() : base("Lua") { }

        public override bool Matches(string code)
        {
            return code.Contains("function ") || code.Contains("end") || code.Contains("print(");
        }
    }
}

