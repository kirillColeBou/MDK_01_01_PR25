using System;
using System.Collections.Generic;
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

        List<object> AllItems_children = Classes.ChildrenContext().All();
        List<object> AllItems_sport = Classes.SportContext().All();
        List<object> AllItems_electronics = Classes.ElectronicsContext().All();

        public MainWindow()
        {
            InitializeComponent();
            CreateUI();
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
    }
}
