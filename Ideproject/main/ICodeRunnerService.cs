using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notePad.main
{
    public interface ICodeRunnerService
    {
        Task<string> RunCSharpCodeAsync(string code);
    }
}


