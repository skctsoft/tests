
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gestcom.Toolbox
{
    public class Commande : ICommand
    {
        private readonly Func<bool> DelFuncVerification;
        private readonly Action DelActionAExecuter;

        public Commande(Action MaMethodeAExecuterDansMonDataContextPrincipal)
            : this(null, MaMethodeAExecuterDansMonDataContextPrincipal)
        { }

        public Commande(Func<bool> MaMethodeDeVerificationDansMonDataContextPrincipal,
            Action MaMethodeAExecuterDansMonDataContextPrincipal)
        {
            DelFuncVerification = MaMethodeDeVerificationDansMonDataContextPrincipal;
            DelActionAExecuter = MaMethodeAExecuterDansMonDataContextPrincipal;
        }

        #region Implementation ICommand
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (DelFuncVerification != null)
                {
                    CommandManager.RequerySuggested += value;
                }

            }

            remove
            {
                if (DelFuncVerification != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        void CommandManager_RequerySuggested(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public bool CanExecute(object parameter)
        {
            //Exécution de mon Func<bool>
            if (DelFuncVerification != null)
            {
                return DelFuncVerification();
            }
            else
            {
                return true;
            }

        }

        public void Execute(object parameter)
        {
            DelActionAExecuter();
        }
        #endregion
    }
}
