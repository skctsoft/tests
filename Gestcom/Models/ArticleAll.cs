using Gestcom.Toolbox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Gestcom.Models
{
    public class ArticleAll : ViewModelBase,INotifyPropertyChanged,ICommand
    {
        private ObservableCollection<Article> _OcArticle;
        private Article _SelectedArticle;
        private string _LibelleArticleFiltre; 

        public string LibelleArticleFiltre
        {
            get { return _LibelleArticleFiltre = _LibelleArticleFiltre ?? string.Empty;  }
            set { _LibelleArticleFiltre = value; RaisePropertyChanged("LibelleArticleFiltre"); }
        }

        //private CollectionViewSource cvs_Article = new CollectionViewSource();
        //cvs_Article.ItemsSource = _OcArticle;
         


        public Article SelectedArticle
        {
            get { return _SelectedArticle; }
            set { _SelectedArticle = value; RaisePropertyChanged("SelectedArticle"); }
        }

        public ObservableCollection<Article> OcArticle
        {
            get { return _OcArticle = _OcArticle ?? getAllArticles(); }
            set { _OcArticle = value; RaisePropertyChanged("OcArticle"); }
        }

        public ObservableCollection<Article> getAllArticles()
        {
            ObservableCollection<Article> lstArticle = new ObservableCollection<Article>();

            lstArticle.Add(new Article("000001","Premier article"));
            lstArticle.Add(new Article("000002", "Deuxième article"));
            lstArticle.Add(new Article("000003", "Troisième article"));
            lstArticle.Add(new Article("000004", "Quatrième article"));
            //lstArticle = (ObservableCollection<Article>)lstArticle.Select(a => a.Libelle.Contains("eux"));  //------------------------------------------------------------------------------
            //var lstArticleFiltree = new ObservableCollection<Article>(lstArticle.Select(p => p.Prixhtva>2 ));
            var matchingArticles = new ObservableCollection<Article>(lstArticle.Where(d => d.Libelle.Contains(this.LibelleArticleFiltre)));
            SelectedArticle = lstArticle[0];
            Debug.WriteLine("getAllArticles() : this.LibelleArticleFiltre vaut : {0}", this.LibelleArticleFiltre);

            return matchingArticles; // lstArticle;
        }

        // FIRST RECORD COMMAND ======================================================
        private ICommand _FirstCommand;
        public ICommand FirstCommand
        {
            get { return _FirstCommand = _FirstCommand ?? new Commande(FirstArticle); }
        }
        private void FirstArticle()
        {
            int indice = 0;
            this.SelectedArticle = this.OcArticle[indice];
        }

        // NEXT RECORD COMMAND ======================================================
        private ICommand _NextCommand;
        public ICommand NextCommand
        {
            get { return _NextCommand = _NextCommand ?? new Commande(NextArticle); }
        }
        private void NextArticle()
        {
            int indice = this.OcArticle.IndexOf(this.SelectedArticle) + 1;
            if (indice < this.OcArticle.Count())
            {
                this.SelectedArticle = this.OcArticle[indice];
            }
        }

        // PREVIOUS RECORD COMMAND ======================================================
        private ICommand _PrevCommand;
        public ICommand PrevCommand
        {
            get { return _PrevCommand = _PrevCommand ?? new Commande(PrevArticle); }
        }
        private void PrevArticle()
        {
            int indice = this.OcArticle.IndexOf(this.SelectedArticle) - 1;
            if (indice >=0)
            {
                this.SelectedArticle = this.OcArticle[indice];
            }
        }


        // LAST RECORD COMMAND ======================================================
        private ICommand _LastCommand;
        public ICommand LastCommand
        {
            get { return _LastCommand = _LastCommand ?? new Commande(LastArticle); }
        }
        private void LastArticle()
        {
            int indice = this.OcArticle.Count() - 1;
            this.SelectedArticle = this.OcArticle[indice];
        }

        // FIRST RECORD COMMAND ======================================================
        private ICommand _FiltreCommand;
        public ICommand FiltreCommand
        {
            get { return _FiltreCommand = _FiltreCommand ?? new Commande(FiltreArticleLibelle); }
        }
        private void FiltreArticleLibelle()
        {
            Debug.WriteLine("Filtrer le libelle ICI !");
            OcArticle = null;

        }
        //void ArticleLibelle_Filter(object sender, FilterEventArgs e)
        //{
        //    if (e.Item != null)
        //        e.Accepted = ((string)e.Item).Contains("eux");
        //}



        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        
        /* EN PREVISION DE FUTURS CONTROLES QUAND L'OBSERVABLE COLLECTION CHANGE (ADD, DEL de RECORD ETC*/
        public ArticleAll()
        {
            OcArticle.CollectionChanged += OcArticle_CollectionChanged;
        }
        void OcArticle_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }

/*
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
*/

    }
}
