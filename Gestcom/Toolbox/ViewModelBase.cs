using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gestcom.Toolbox
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Changed
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string Pname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(Pname));
            }
        }

        public void RaisePropertyChanged<T>(Expression<Func<T>> expression)
        {
            MemberExpression me = expression.Body as MemberExpression;

            if (me != null)
            {
                string Pname = me.Member.Name;
                RaisePropertyChanged(Pname);

            }

        }
        public void RaiseAllPropertyChanged()
        {
            RaisePropertyChanged(string.Empty);
        }
        #endregion
    }
}
