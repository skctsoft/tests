using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestcom.Toolbox
{
    public abstract class ViewModelCollectionBase<T> : ViewModelBase
        where T : class
    {
        private ObservableCollection<T> _items;
        private T _Current;

        public T Current
        {
            get { return _Current; }
            set
            {
                if (_Current != value)
                {
                    _Current = value;
                    RaisePropertyChanged(() => Current);
                }
            }
        }

        public ObservableCollection<T> Items
        {
            get { return _items = _items ?? chargerItems(); }
        }



        protected abstract ObservableCollection<T> chargerItems();

    }
}
