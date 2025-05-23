using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notePad.languages
{
    public class HtmlLanguage : ProgrammingLanguage
    {
        public HtmlLanguage() : base("HTML") { }

        public override bool Matches(string code)
        {
            return code.Contains("<html") || code.Contains("<!DOCTYPE html>") || code.Contains("<body>");
        }
    }
}

