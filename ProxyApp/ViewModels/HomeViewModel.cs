using ProxyApp.Commands;
using ProxyApp.Pattern;
using ProxyApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyApp.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        public RelayCommand SubmitCommand { get; set; }
        public RelayCommand UpCommand { get; set; }
        public RelayCommand DownCommand { get; set; }

        private ITextSearcher _searcher;

        private string currentText;

        public string CurrentText
        {
            get { return currentText; }
            set { currentText = value; OnPropertyChanged(); }
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; OnPropertyChanged();CallGetData(); }
        }

        private ObservableCollection<string> allTexts;

        public ObservableCollection<string> AllTexts
        {
            get { return allTexts; }
            set { allTexts = value; OnPropertyChanged();  }
        }


        public void CallGetData()
        {
                AllTexts = new ObservableCollection<string>(_searcher.SearchByWord(SearchText));
        }
        public HomeViewModel()
        {
            _searcher = new LocalTextSearcher(new GlobalTextSearcher());


            SubmitCommand = new RelayCommand((o) =>
            {
                CurrentText += $" {SearchText}";
                FileHelper.AppendTextToFile(SearchText);
                SearchText = String.Empty;
            });
         
        }
    }
}
