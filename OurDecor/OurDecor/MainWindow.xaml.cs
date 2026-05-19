using Microsoft.EntityFrameworkCore;
using OurDecor.Models;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OurDecor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product>products { get; set; } = new ObservableCollection<Product>();
        public OurDecorContext db = new OurDecorContext();
        public MainWindow()
        {
            products = new ObservableCollection<Product>(db.Products.Include(p => p.IdProductTypeNavigation));
            InitializeComponent();
           
        }
    }
}