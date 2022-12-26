using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyApp.Pattern
{
    public interface ITextSearcher
    {
        List<string> SearchByWord(string text);
    }
}
