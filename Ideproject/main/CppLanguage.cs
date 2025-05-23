using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notePad.languages
{
    public class CppLanguage : ProgrammingLanguage
    {
        public CppLanguage() : base("C++") { }

        public override bool Matches(string code)
        {
            return code.Contains("#include") || code.Contains("std::") || code.Contains("int main(");
        }
    }
}

