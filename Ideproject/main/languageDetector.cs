using System;
using System.Collections.Generic;
using System.Collections.Generic;
using notePad.languages;

namespace notePad.main
{


    public class LanguageDetector
    {
        private readonly List<ProgrammingLanguage> _languages = new()
        {
    new CSharpLanguage(),
    new PythonLanguage(),
    new HtmlLanguage(),
    new JavaLanguage(),
    new LuaLanguage(),
    new CppLanguage()
        };

        public string DetectLanguage(string code)
        {
            foreach (var language in _languages)
            {
                if (language.Matches(code))
                    return language.Name;
            }

            return "Unknown";
        }

        public List<ProgrammingLanguage> GetAllLanguages() => _languages;
    }
}


