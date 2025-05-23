using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using notePad.languages;


namespace notePad.languages
{
    public abstract class ProgrammingLanguage
    {
        public string Name { get; protected set; }

        protected ProgrammingLanguage(string name)
        {
            Name = name;
        }
         
        public abstract bool Matches(string code);
    }
}

