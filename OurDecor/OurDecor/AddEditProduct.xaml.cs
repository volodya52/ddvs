using Microsoft.EntityFrameworkCore;
using OurDecor.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace OurDecor
{
    /// <summary>
    /// Логика взаимодействия для AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Window
    {
        public Product product = new Product();
        public OurDecorContext db = new OurDecorContext();
        public ObservableCollection<Product> products {get; set;} = new ObservableCollection<Product>();
        public ObservableCollection<ProductType> productTypes { get; set; } = new ObservableCollection<ProductType>();
        public AddEditProduct()
        {
            products = new ObservableCollection<Product>(db.Products.Include(p=>p.IdProductTypeNavigation));
            productTypes = new ObservableCollection<ProductType>(db.ProductTypes);
            InitializeComponent();   
            Types.ItemsSource = productTypes; //Добавление в ComboBox типов продуктов
            DataContext = product;
        }

        public int Commit() => db.SaveChanges();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Добавление нового товара
            product.IdProductType = Types.SelectedIndex + 1;
            var _product = new Product
            {
                Articul = product.Articul,
                IdProductType = product.IdProductType,
                ProductionName = product.ProductionName,
                MinPriceForPartner = product.MinPriceForPartner,
                ShirinaRulona = product.ShirinaRulona,
            };

            db.Add<Product>(_product);
            Commit();
            products.Add(_product);
            MessageBox.Show("Продукт успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);            
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
