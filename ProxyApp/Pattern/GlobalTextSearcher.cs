using ProxyApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyApp.Pattern
{
    public class GlobalTextSearcher : ITextSearcher
    {
        public List<string> SearchByWord(string text)
        {
            var allData = FileHelper.GetAllData();
            var result = allData.Where(x => x.Contains(text)).ToList();
            return result;
        }
    }
}
