using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestcom.Toolbox;

namespace Gestcom.Models
{
    public class Article : ViewModelBase     // INotifyPropertyChanged  //,ViewModelBase
    {
        int _Id;
        string _Refnum;
        string _Libelle;
        string _Groupe;
        float _Prixhtva;
        int _Codetva;
        int _Codeven;
        int _Qtemin;
        int _Qtemax;

        public Article(){}

        public Article(string refnum)
        {
            this.Refnum = refnum;
        }

        public Article(string refnum, string libelle)  
        {
            this.Refnum = refnum;
            this.Libelle = libelle;
        }

        public int Id
        {
            get { return _Id; }
            set { _Id = value; RaisePropertyChanged("Id"); }
        }

        public string Refnum
        {
            get { return _Refnum; }
            set { _Refnum = value; RaisePropertyChanged("Refnum"); }
        }

        public string Libelle
        {
            get { return _Libelle; }
            set { _Libelle = value; RaisePropertyChanged("Libelle"); }
        }

        public string Groupe
        {
            get { return _Groupe; }
            set { _Groupe = value; RaisePropertyChanged("Groupe"); }
        }

        public float Prixhtva
        {
            get { return _Prixhtva; }
            set { _Prixhtva = value; RaisePropertyChanged("Prixhtva"); }
        }

        public int Codetva
        {
            get { return _Codetva; }
            set { _Codetva = value; RaisePropertyChanged("Codetva"); }
        }

        public int Codeven
        {
            get { return _Codeven; }
            set { _Codeven = value; RaisePropertyChanged("Codeven"); }
        }

        public int Qtemin
        {
            get { return _Qtemin; }
            set { _Qtemin = value; RaisePropertyChanged("Qtemin"); }
        }

        public int Qtemax
        {
            get { return _Qtemax; }
            set { _Qtemax = value; RaisePropertyChanged("Qtemax"); }
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
