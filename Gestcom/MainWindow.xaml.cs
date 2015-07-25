using Gestcom.Models;
using Gestcom.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gestcom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window                    //, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            ArticleAll aa = new ArticleAll();
            //this.DataContext = aa; //.OcArticle;
            this.DataContext = aa;
        }

        private void btnArticleDetail_Click(object sender, RoutedEventArgs e)
        {
            ArticleDetail arti_detail = new ArticleDetail();
            arti_detail.ShowDialog();
        }

    }
}
