using ProxyApp.Commands;
using ProxyApp.Pattern;
using ProxyApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProxyApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public RelayCommand SubmitCommand { get; set; }
        public RelayCommand UpCommand { get; set; }
        public RelayCommand DownCommand { get; set; }
        public RelayCommand ChangeTextCommand { get; set; }

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
            set { searchText = value; OnPropertyChanged();  }
        }

        private ObservableCollection<string> allTexts;

        public ObservableCollection<string> AllTexts
        {
            get { return allTexts; }
            set { allTexts = value; OnPropertyChanged(); }
        }

        public void CallGetData()
        {
            AllTexts = new ObservableCollection<string>(_searcher.SearchByWord(SearchText));
        }
        public int Index { get; set; } = 0;
        public HomeViewModel()
        {
            _searcher = new LocalTextSearcher(new GlobalTextSearcher());

            ChangeTextCommand = new RelayCommand((o) =>
            {
                CallGetData();
            });


            UpCommand = new RelayCommand((o) =>
            {
                if (Index > 0)
                {
                    --Index;
                    SearchText = _searcher.SearchByWord(searchText[0].ToString()).Skip(Index).Take(1).First();
                    AllTexts = new ObservableCollection<string>(_searcher.SearchByWord(searchText[0].ToString()));
                }
            });

            DownCommand = new RelayCommand((o) =>
            {
                if (Index < AllTexts.Count)
                {
                    Index++;
                }
                SearchText = _searcher.SearchByWord(searchText[0].ToString()).Skip(Index).Take(1).First();
                AllTexts = new ObservableCollection<string>(_searcher.SearchByWord(searchText[0].ToString()));
            });

            SubmitCommand = new RelayCommand((o) =>
            {
                CurrentText += $" {SearchText}";
                SearchText = String.Empty;
            });

        }
    }
}
