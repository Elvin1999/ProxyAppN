using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace ProxyApp.Pattern
{
    public class LocalTextSearcher : ITextSearcher
    {
        public List<string> LocalData { get; set; }
        private ITextSearcher _globalTextSearcher;
        public LocalTextSearcher(ITextSearcher globalTextSearcher)
        {
            LocalData = new List<string>
            {
            "aberdeen    ",
            "abilities   ",
            "ability     ",
            "able        ",
            "aboriginal  ",
            "abortion    ",
            "about       ",
            "above       ",
            "abraham     ",
            "abroad      ",
            "abs         ",
            "absence     ",
            "absent      ",
            "absolute    ",
            "absolutely  ",
            "absorption  ",
            "abstract    ",
            "abstracts   ",
            "abu         ",
            "abuse       ",
            };
            _globalTextSearcher = globalTextSearcher;
        }
        public List<string> SearchByWord(string text)
        {
            if (LocalData.Any(x => x.Contains(text)))
            {
                return LocalData.Where(x => x.Contains(text)).ToList();
            }
            else
            {
                var fromGlobal = _globalTextSearcher.SearchByWord(text);
                LocalData.AddRange(fromGlobal);
                return fromGlobal;
            }
        }
    }
}
