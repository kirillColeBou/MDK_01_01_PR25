using Shop_Тепляков.Classes;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
using System.Xml.Linq;

namespace Shop_Тепляков
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<object> AllItems_children = new Classes.ChildrenContext().All();
        List<object> AllItems_sport = new Classes.SportContext().All();
        List<object> AllItems_electronics = new Classes.ElectronicsContext().All();
        public static bool discountIsApply = false;

        public MainWindow()
        {
            InitializeComponent();
            CreateUI();
            DeleteDiscount();
            AddDiscount();
        }

        public void CreateUI()
        {
            foreach (object item in AllItems_children)
            {
                parent.Children.Add(new Elements.item(item));
            }
            foreach (object item in AllItems_sport)
            {
                parent.Children.Add(new Elements.item(item));
            }
            foreach (object item in AllItems_electronics)
            {
                parent.Children.Add(new Elements.item(item));
            }
        }

        private void searchItem(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            int search_age = 0;
            int search_size = 0;
            string result = search.Text;
            if (search.Text != "")
            {
                foreach (Models.Children children in AllItems_children)
                {
                    if (children.Age.ToString().Contains(result))
                    {
                        MessageBox.Show($"Товар найден!\n{children.Name}", "Результаты поиска", MessageBoxButton.OK, MessageBoxImage.Information);
                        search_age++;
                        flag = true;
                    }
                }
                if (search_age == 0)
                {
                    foreach (Models.Sport sport in AllItems_sport)
                    {
                        if (sport.Size.ToString().Contains(result))
                        {
                            MessageBox.Show($"Товар найден!\n{sport.Name}", "Результаты поиска", MessageBoxButton.OK, MessageBoxImage.Information);
                            search_size++;
                            flag = true;
                        }
                    }
                    if (search_size == 0)
                    {
                        foreach (Models.Electronics electronics in AllItems_electronics)
                        {
                            if (electronics.Capacity.ToString().Contains(result) || electronics.drivingSpeed.ToString().Contains(result))
                            {
                                MessageBox.Show($"Товар найден!\n{electronics.Name}", "Результаты поиска", MessageBoxButton.OK, MessageBoxImage.Information);
                                flag = true;
                            }
                        }
                    }
                }
                if (flag == false)
                {
                    MessageBox.Show("Товары не найдены!", "Результаты поиска", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else MessageBox.Show("Поле поиска пустое, введите значение!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void discountItem(object sender, RoutedEventArgs e)
        {
            string text = discount.Text;
            double discountTb;
            if (text.Contains("."))
                discountTb = 1 - double.Parse(text, System.Globalization.CultureInfo.InvariantCulture);
            else
                discountTb = 1 - double.Parse(text);
            string numberWithDot = discountTb.ToString(System.Globalization.CultureInfo.InvariantCulture);
            OleDbConnection connection = Classes.Common.DBConnection.Connection();
            Classes.Common.DBConnection.Query($"UPDATE [Скидка] SET [Стоимость] = [Стоимость] * {numberWithDot}", connection);
            Classes.Common.DBConnection.CloseConnection(connection);
            discountIsApply = true;
            parent.Children.Clear();
            AllItems_children.Clear();
            AllItems_sport.Clear();
            AllItems_electronics.Clear();
            AllItems_children = new Classes.ChildrenContext().All();
            AllItems_sport = new Classes.SportContext().All();
            AllItems_electronics = new Classes.ElectronicsContext().All();
            CreateUI();
        }

        public void AddDiscount()
        {
            OleDbConnection connection = Classes.Common.DBConnection.Connection();
            Classes.Common.DBConnection.Query("INSERT INTO [Скидка] SELECT [Код],[Наименование],[Стоимость] FROM [Товар]", connection);
            Classes.Common.DBConnection.CloseConnection(connection);
        }

        public void DeleteDiscount()
        {
            OleDbConnection connection = Classes.Common.DBConnection.Connection();
            Classes.Common.DBConnection.Query("DELETE FROM [Скидка]", connection);
            Classes.Common.DBConnection.CloseConnection(connection);
        }
    }
}
