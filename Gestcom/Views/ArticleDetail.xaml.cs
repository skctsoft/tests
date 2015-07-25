using Gestcom.Models;
using Gestcom.Toolbox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gestcom.Views
{
    public partial class ArticleDetail : Window
    {
    private ArticleAll ArtiAll;

    public ArticleDetail()
        {
            InitializeComponent();

            //ArticleAll ArtiAll = new ArticleAll();
            ArtiAll = new ArticleAll();
            this.DataContext = this.ArtiAll;
        }

    }
}
