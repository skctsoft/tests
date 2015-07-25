using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gestcom.Toolbox
{
    public class ModelBase : INotifyPropertyChanging, INotifyPropertyChanged
    {

        #region Changing

        public event PropertyChangingEventHandler PropertyChanging;

        private void RaisePropertyChanging(string Pname)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(Pname));
            }
        }


        public void RaisePropertyChanging<T>(Expression<Func<T>> expression)
        {
            MemberExpression me = expression.Body as MemberExpression;

            if (me != null)
            {
                string Pname = me.Member.Name;
                RaisePropertyChanging(Pname);

            }

        }

        public void RaiseAllPropertyChanging()
        {
            RaisePropertyChanging(string.Empty);
        }

        #endregion
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
